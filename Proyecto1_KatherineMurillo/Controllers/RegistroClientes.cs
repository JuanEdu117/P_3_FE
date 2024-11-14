using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_KatherineMurillo.Models;
using System.Text.RegularExpressions;

namespace Proyecto1_KatherineMurillo.Controllers
{
    public class RegistroClientes : Controller
    {
        #region EVENTOS DE APERTURA VIEW
        public async Task<IActionResult> ListadoClientes()  //Método para obtener y mostrar la lista 
        {
            cls_GestorCNXApis Obj_CNX = new cls_GestorCNXApis(); //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            List<cls_Clientes> lstResultado = await Obj_CNX.ListarClient(); //Llama al método para obtener la lista 
            return View(lstResultado);
        }
        public async Task<IActionResult> FiltrarClientes(string _sIdBuscar) //Método para filtrar 
        {
            cls_GestorCNXApis Obj_CNX = new cls_GestorCNXApis();   //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            List<cls_Clientes> lstResultado = await Obj_CNX.ListarClient(); //Llama al método para obtener la lista 
            if (!string.IsNullOrEmpty(_sIdBuscar)) 
            {
                //Filtra si cuyo ID contiene la cadena de búsqueda, ignorando mayúsculas y minúsculas
                lstResultado = lstResultado.FindAll(item => item.identificacion.ToString().Contains(_sIdBuscar, System.StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            return View(lstResultado);
        }
        public IActionResult AbrirCrearClientes()
        {
            return View();
        }
        public async Task<IActionResult> AbrirModificarClientes(int _iId_Clientes) 
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();   //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            //List<cls_Clientes> _lstResultado = await Obj_Gestor.ConsultarClientes(new cls_Clientes { identificacion = _iId_Clientes }); //Llama al método para obtener la lista 
            List<cls_Clientes> _lstResultado = await Obj_Gestor.ListarClient();
            //cls_Clientes Obj_Encontrado = _lstResultado.FirstOrDefault();  //ENCUENTRA EL PRIMER DATO DE LA LISTA
            cls_Clientes Obj_Encontrado = _lstResultado.Where(item => item.identificacion.Equals(_iId_Clientes)).FirstOrDefault();
            return View(Obj_Encontrado);
        }

        [HttpGet]
        public async Task<IActionResult> AbrirEliminarClientes(int _iId_Clientes) //Método para eliminar
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis(); //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            await Obj_Gestor.EliminarClient(new cls_Clientes { identificacion = _iId_Clientes });
            return RedirectToAction("ListadoClientes", "RegistroClientes");
        }
        #endregion

        #region EVENTOS MANTENIMIENTOS
        [HttpPost]
        public async Task<IActionResult> InsertClientes(cls_Clientes P_Entidad) //Método para insertar 
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis(); //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            await Obj_Gestor.AlmacenarClient(P_Entidad);
            return RedirectToAction("ListadoClientes", "RegistroClientes");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateClientes(cls_Clientes P_Entidad) //Método para editar
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis(); //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            await Obj_Gestor.AlmacenarClient(P_Entidad);
            return RedirectToAction("ListadoClientes", "RegistroClientes");
        }
        #endregion              
    }
}
