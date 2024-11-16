using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_KatherineMurillo.Models;
using System.Text.RegularExpressions;

namespace Proyecto1_KatherineMurillo.Controllers
{
    public class RegistroReportes : Controller
    {
        #region EVENTOS DE APERTURA VIEW
        public async Task<IActionResult> ListadoReportes()  //Método para obtener y mostrar la lista 
        {
            cls_GestorCNXApis Obj_CNX = new cls_GestorCNXApis(); //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            List<cls_Reportes> lstResultado = await Obj_CNX.ListarReport(); //Llama al método para obtener la lista 
            return View(lstResultado);
        }
        public async Task<IActionResult> FiltrarReportes(string _sIdBuscar) //Método para filtrar 
        {
            cls_GestorCNXApis Obj_CNX = new cls_GestorCNXApis();   //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            List<cls_Reportes> lstResultado = await Obj_CNX.ListarReport(); //Llama al método para obtener la lista 
            if (!string.IsNullOrEmpty(_sIdBuscar))
            {
                //Filtra si cuyo ID contiene la cadena de búsqueda, ignorando mayúsculas y minúsculas
                lstResultado = lstResultado.FindAll(item => item.id_Reporte.ToString().Contains(_sIdBuscar, System.StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            return View(lstResultado);
        }
        public IActionResult AbrirCrearReportes()
        {
            return View();
        }
        public async Task<IActionResult> AbrirModificarReportes(int _iId_Reportes)
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();   //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            //List<cls_Clientes> _lstResultado = await Obj_Gestor.ConsultarClientes(new cls_Clientes { identificacion = _iId_Clientes }); //Llama al método para obtener la lista 
            List<cls_Reportes> _lstResultado = await Obj_Gestor.ListarReport();
            //cls_Clientes Obj_Encontrado = _lstResultado.FirstOrDefault();  //ENCUENTRA EL PRIMER DATO DE LA LISTA
            cls_Reportes Obj_Encontrado = _lstResultado.Where(item => item.id_Reporte.Equals(_iId_Reportes)).FirstOrDefault();
            return View(Obj_Encontrado);
        }

        [HttpGet]
        public async Task<IActionResult> AbrirEliminarReportes(int _iId_Reportes) //Método para eliminar
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis(); //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            await Obj_Gestor.EliminarReport(new cls_Reportes { id_Reporte = _iId_Reportes });
            return RedirectToAction("ListadoReportes", "RegistroReportes");
        }
        #endregion

        #region EVENTOS MANTENIMIENTOS
        [HttpPost]
        public async Task<IActionResult> InsertReportes(cls_Reportes P_Entidad) //Método para insertar 
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis(); //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            await Obj_Gestor.AlmacenarReport(P_Entidad);
            return RedirectToAction("ListadoReportes", "RegistroReportes");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReportes(cls_Reportes P_Entidad) //Método para editar
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis(); //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            await Obj_Gestor.AlmacenarReport(P_Entidad);
            return RedirectToAction("ListadoReportes", "RegistroReportes");
        }
        #endregion      
    }
}
