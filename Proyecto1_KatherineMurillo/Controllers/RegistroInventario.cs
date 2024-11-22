using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_KatherineMurillo.Models;
using System.Text.RegularExpressions;

namespace Proyecto1_KatherineMurillo.Controllers
{
    public class RegistroInventario : Controller
    {
        #region EVENTOS DE APERTURA VIEW
        public async Task<IActionResult> ListadoInventario()                    //Método para obtener y mostrar la lista 
        {
            cls_GestorCNXApis Obj_CNX = new cls_GestorCNXApis();               //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            List<cls_Inventario> lstResultado = await Obj_CNX.ListarInvent(); //Llama al método para obtener la lista 
            return View(lstResultado);
        }
        public async Task<IActionResult> FiltrarInventario(string _sIdBuscar)       //Método para filtrar 
        {
            cls_GestorCNXApis Obj_CNX = new cls_GestorCNXApis();                    //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            List<cls_Inventario> lstResultado = await Obj_CNX.ListarInvent();       //Llama al método para obtener la lista 
            if (!string.IsNullOrEmpty(_sIdBuscar))
            {
                //Filtra si cuyo ID contiene la cadena de búsqueda, ignorando mayúsculas y minúsculas
                lstResultado = lstResultado.FindAll(item => item.idInventario.ToString().Contains(_sIdBuscar, System.StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            return View(lstResultado);
        }
        public IActionResult AbrirCrearInventario()
        {
            return View();
        }
        public async Task<IActionResult> AbrirModificarInventario(int _iId_Inventario) 
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis();             //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            //List<cls_Inventario> _lstResultado = await Obj_Gestor.ConsultarInventario(new cls_Inventario { idInventario = _iId_Inventario }); //Llama al método para obtener la lista 
            List<cls_Inventario> _lstResultado = await Obj_Gestor.ListarInvent();
            //cls_Inventario Obj_Encontrado = _lstResultado.FirstOrDefault();     //ENCUENTRA EL PRIMER DATO DE LA LISTA
            cls_Inventario Obj_Encontrado = _lstResultado.Where(item => item.idInventario.Equals(_iId_Inventario)).FirstOrDefault();
            return View(Obj_Encontrado);
        }

        [HttpGet]
        public async Task<IActionResult> AbrirEliminarInventario(int _iId_Inventario) //Método para eliminar
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis(); //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            await Obj_Gestor.EliminarInvent(new cls_Inventario { idInventario = _iId_Inventario });
            return RedirectToAction("ListadoInventario", "RegistroInventario");
        }
        #endregion

        #region EVENTOS MANTENIMIENTOS
        [HttpPost]
        public async Task<IActionResult> InsertInventario(cls_Inventario P_Entidad) //Método para insertar 
        {
            if (!ModelState.IsValid) //Valida los atributos requeridos
            {
                return View("AbrirCrearInventario", P_Entidad); //Devuelve la vista con errores
            }
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis(); //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            //Verifica si el ID ya existe en la lista de inventarios
            List<cls_Inventario> lstInventario = await Obj_Gestor.ListarInvent();
            if (lstInventario.Any(item => item.idInventario == P_Entidad.idInventario))
            {
                ModelState.AddModelError("idInventario", "El ID del inventario ya existe");
                return View("AbrirCrearInventario", P_Entidad); // Devuelve a la vista con el error
            }
            await Obj_Gestor.AlmacenarInvent(P_Entidad);
            return RedirectToAction("ListadoInventario", "RegistroInventario");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInventario(cls_Inventario P_Entidad) //Método para editar
        {
            cls_GestorCNXApis Obj_Gestor = new cls_GestorCNXApis(); //INSTANCIO OBJ DE LA CLASE GESTORCONEX
            await Obj_Gestor.AlmacenarInvent(P_Entidad);
            return RedirectToAction("ListadoInventario", "RegistroInventario");
        }
        #endregion               
    }
}
