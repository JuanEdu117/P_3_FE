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
            List<cls_Mantenimiento> lstResultado = await Obj_CNX.ListarMantenimiento(); //Llama al método para obtener la lista 
            return View(lstResultado);
        }
        public async Task<IActionResult> FiltrarMantenimiento(string _sIdBuscar) //Método para filtrar 
        {
            cls_GestorCNXApis Obj_CNX = new cls_GestorCNXApis();   //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            List<cls_Mantenimiento> lstResultado = await Obj_CNX.ListarMantenimiento(); //Llama al método para obtener la lista 
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
            List<cls_Mantenimiento> _lstResultado = await Obj_Gestor.ConsultarMantenimiento(new cls_Mantenimiento { idMantenimiento = _iId_Mantenimiento }); //Llama al método para obtener la lista 
            cls_Mantenimiento Obj_Encontrado = _lstResultado.FirstOrDefault();  //ENCUENTRA EL PRIMER DATO DE LA LISTA
            return View(Obj_Encontrado);
        }

        [HttpGet]
        public async Task<IActionResult> AbrirEliminarMantenimiento(int _iId_Mantenimiento) //Método para eliminar
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis(); //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            await Obj_Gestor.EliminarMantenimiento(new cls_Mantenimiento { idMantenimiento = _iId_Mantenimiento });
            return RedirectToAction("ListadoMantenimiento", "RegistroMantenimiento");
        }
        #endregion

        #region EVENTOS MANTENIMIENTOS
        [HttpPost]
        public async Task<IActionResult> InsertMantenimiento(cls_Mantenimiento P_Entidad) //Método para insertar 
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis(); //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            await Obj_Gestor.AgregarMantenimiento(P_Entidad);
            return RedirectToAction("ListadoMantenimiento", "RegistroMantenimiento");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMantenimiento(cls_Mantenimiento P_Entidad) //Método para editar
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis(); //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            await Obj_Gestor.ModificarMantenimiento(P_Entidad);
            return RedirectToAction("ListadoMantenimiento", "RegistroMantenimiento");
        }
        #endregion       
    }
}
