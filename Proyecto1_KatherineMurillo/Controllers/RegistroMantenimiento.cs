using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_KatherineMurillo.Models;
using System.Drawing;

namespace Proyecto1_KatherineMurillo.Controllers
{
    public class RegistroMantenimiento : Controller
    {
        #region EVENTOS DE APERTURA VIEW
        public async Task<IActionResult> ListadoMantenimiento()  //Método para obtener y mostrar la lista 
        {
            cls_GestorCNXApis Obj_CNX = new cls_GestorCNXApis(); //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            List<cls_Mantenimiento> lstResultado = await Obj_CNX.ListarMaintenance(); //Llama al método para obtener la lista 
            return View(lstResultado);
        }
        public async Task<IActionResult> FiltrarMantenimiento(string _sIdBuscar) //Método para filtrar 
        {
            cls_GestorCNXApis Obj_CNX = new cls_GestorCNXApis();   //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            List<cls_Mantenimiento> lstResultado = await Obj_CNX.ListarMaintenance(); //Llama al método para obtener la lista 
            if (!string.IsNullOrEmpty(_sIdBuscar))
            {
                //Filtra si cuyo ID contiene la cadena de búsqueda, ignorando mayúsculas y minúsculas
                lstResultado = lstResultado.FindAll(item => item.idMantenimiento.ToString().Contains(_sIdBuscar, System.StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            return View(lstResultado);
        }
        public IActionResult AbrirCrearMantenimiento()
        {
            return View();
        }
        public async Task<IActionResult> AbrirModificarMantenimiento(int _iId_Mantenimiento) 
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();   //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            //List<cls_Mantenimiento> _lstResultado = await Obj_Gestor.ConsultarMantenimiento(new cls_Mantenimiento { idMantenimiento = _iId_Mantenimiento }); //Llama al método para obtener la lista 
            List<cls_Mantenimiento> _lstResultado = await Obj_Gestor.ListarMaintenance();
            //cls_Mantenimiento Obj_Encontrado = _lstResultado.FirstOrDefault();  //ENCUENTRA EL PRIMER DATO DE LA LISTA
            cls_Mantenimiento Obj_Encontrado = _lstResultado.Where(item => item.idMantenimiento.Equals(_iId_Mantenimiento)).FirstOrDefault();
            return View(Obj_Encontrado);
        }

        [HttpGet]
        public async Task<IActionResult> AbrirEliminarMantenimiento(int _iId_Mantenimiento) //Método para eliminar
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis(); //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            await Obj_Gestor.EliminarMaintenance(new cls_Mantenimiento { idMantenimiento = _iId_Mantenimiento });
            return RedirectToAction("ListadoMantenimiento", "RegistroMantenimiento");
        }
        #endregion

        #region EVENTOS MANTENIMIENTOS
        [HttpPost]
        public async Task<IActionResult> InsertMantenimiento(cls_Mantenimiento P_Entidad) //Método para insertar 
        {
            cls_GestorCNXApis Obj_GestorCNX = new cls_GestorCNXApis(); //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            await Obj_GestorCNX.AlmacenarMaintenance(P_Entidad);

            DateTime hoy = DateTime.Today;
            DateTime ultimaFecha = P_Entidad.fechaEjecutado;

            // Verificar si la última fecha de mantenimiento es dentro de los próximos 7 días.
            if (ultimaFecha <= hoy.AddDays(7) && ultimaFecha >= hoy)
            {
                // Lógica para contactar clientes que deben agendar en la próxima semana.
                await Obj_GestorCNX.AlmacenarReport(new cls_Reportes
                {
                    id_Cliente = P_Entidad.idCliente,
                    id_Mantenimiento = P_Entidad.idMantenimiento,
                    fecha_Ultimo_Servicio = P_Entidad.fechaEjecutado,
                    proxima_Fecha_Contacto = Convert.ToDateTime(P_Entidad.fechaOtraChapia),
                    fecha_Reporte = DateTime.Now,
                    motivo = "Contactar para mantenimiento"
                });
            }
            // Verificar si no se ha agendado un servicio en más de 60 días.
            else if (ultimaFecha < hoy.AddDays(-60))
            {
                // Lógica para clientes que no han agendado en más de dos meses.
                await Obj_GestorCNX.AlmacenarReport(new cls_Reportes
                {
                    id_Cliente = P_Entidad.idCliente,
                    id_Mantenimiento = P_Entidad.idMantenimiento,
                    fecha_Ultimo_Servicio = P_Entidad.fechaEjecutado,
                    proxima_Fecha_Contacto = Convert.ToDateTime(P_Entidad.fechaOtraChapia),
                    fecha_Reporte = DateTime.Now,
                    motivo = "No ha agendado en más de dos meses"
                });
            }


            return RedirectToAction("ListadoMantenimiento", "RegistroMantenimiento");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMantenimiento(cls_Mantenimiento P_Entidad) //Método para editar
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis(); //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            await Obj_Gestor.AlmacenarMaintenance(P_Entidad);
            return RedirectToAction("ListadoMantenimiento", "RegistroMantenimiento");
        }
        #endregion       
    }
}
