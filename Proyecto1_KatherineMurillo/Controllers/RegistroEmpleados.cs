using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_KatherineMurillo.Models;
using System.Text.RegularExpressions;

namespace Proyecto1_KatherineMurillo.Controllers
{
    public class RegistroEmpleados : Controller
    {
        #region EVENTOS DE APERTURA VIEW
        public async Task<IActionResult> ListadoEmpleados()  //Método para obtener y mostrar la lista 
        {
            cls_GestorCNXApis Obj_CNX = new cls_GestorCNXApis();
            List<cls_Empleados> lstResultado = await Obj_CNX.ListarEmpleados(); //Llama al método para obtener la lista 
            return View(lstResultado);
        }
        public async Task<IActionResult> FiltrarEmpleado(string _sIdBuscar) //Método para filtrar 
        {
            cls_GestorCNXApis Obj_CNX = new cls_GestorCNXApis();   //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            List<cls_Empleados> lstResultado = await Obj_CNX.ListarEmpleados(); //Llama al método para obtener la lista 
            if (!string.IsNullOrEmpty(_sIdBuscar))
            {
                //Filtra si cuyo ID contiene la cadena de búsqueda, ignorando mayúsculas y minúsculas
                lstResultado = lstResultado.FindAll(item => item.iCedula.ToString().Contains(_sIdBuscar, System.StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            return View(lstResultado);
        }
        public IActionResult AbrirCrearEmpleado() 
        {
            return View();
        }
        public async Task<IActionResult> AbrirModificarEmpleado(int _iId_Empleado) 
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();   //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            List<cls_Empleados> _lstResultado = await Obj_Gestor.ConsultarEmpleados(new cls_Empleados { iCedula = _iId_Empleado }); //Llama al método para obtener la lista 
            cls_Empleados Obj_Encontrado = _lstResultado.FirstOrDefault();  //ENCUENTRA EL PRIMER DATO DE LA LISTA
            return View(Obj_Encontrado);
        }

        [HttpGet]
        public async Task<IActionResult> AbrirEliminarEmpleado(int _iId_Empleado) //Método para eliminar
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();
            await Obj_Gestor.EliminarEmpleados(new cls_Empleados { iCedula = _iId_Empleado });
            return RedirectToAction("ListadoEmpleados", "RegistroEmpleados");
        }
        #endregion

        #region EVENTOS MANTENIMIENTOS
        [HttpPost]
        public async Task<IActionResult> InsertEmpleados(cls_Empleados P_Entidad) //Método para insertar 
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();
            await Obj_Gestor.AgregarEmpleados(P_Entidad);
            return RedirectToAction("ListadoEmpleados", "RegistroEmpleados");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmpleados(cls_Empleados P_Entidad) //Método para insertar 
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();
            await Obj_Gestor.ModificarEmpleados(P_Entidad);
            return RedirectToAction("ListadoEmpleados", "RegistroEmpleados");
        }
        #endregion           
    }
}
