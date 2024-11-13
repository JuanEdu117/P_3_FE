using Proyecto1_KatherineMurillo.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Proyecto1_KatherineMurillo.Controllers
{
    public class cls_GestorCNXApis
    {
        #region VARIABLE PÚBLICAS
        public HttpClient hcCNXApi;
        public cls_GestorCNXApis() 
        {
            //Inicializa un nuevo cliente HTTP para realizar solicitudes a la API
            hcCNXApi = new HttpClient();
            //Llama al método para establecer la conexión 
            EstablecerConexion();
        }
        #endregion
     
        #region PRIVADOS
        private void EstablecerConexion()                                // AL OBJ CONEXIONAPIS LE DEBO DE ESTABLECER CIERTOS DATOS
        {                                                               // INDICAR QUE EL TRASLADO DE DATOS VA EN FORMATO JSON Y QUE CUAL ES LA DIRECCION BASE AL QUE VA APUNTAR
            hcCNXApi.BaseAddress = new Uri("http://localhost:35464");  
            hcCNXApi.DefaultRequestHeaders.Accept.Clear();            //SE LIMPIAN LOS VALORES POR DEFECTO   
            hcCNXApi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion

        #region MÉTODOS

        #region EMPLEADOS
        //Método para listar empleados
        public async Task<List<cls_Empleados>> ListarEmpleados()
        {
            //Crea una lista que almacenará el resultado
            List<cls_Empleados> Obj_lstResultado = new List<cls_Empleados>();
            string _sRutaAPI = @"api/Empleados/ListarEmpleados"; //VA A CONCATENAR A LA RUTA BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.GetAsync(_sRutaAPI); //Realiza una solicitud a la API
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync(); //Lee la respuesta como JSON
                Obj_lstResultado = JsonSerializer.Deserialize<List<cls_Empleados>>(jsonstring); //Se deserializa en una lista de objetos 
            }
            return Obj_lstResultado;
        }
        public async Task<List<cls_Empleados>> ConsultarEmpleados(cls_Empleados P_Entidad)
        {
            //Crea una lista que almacenará el resultado
            List<cls_Empleados> Obj_lstResultado = new List<cls_Empleados>(); 
            string _sRutaAPI = @"api/Empleados/ConsultarEmpleados"; //VA A CONCATENAR A LA RUTA BASE

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.iCedula.ToString()); //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.GetAsync(_sRutaAPI); //Realiza una solicitud a la API
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync(); //Lee la respuesta como JSON
                Obj_lstResultado = JsonSerializer.Deserialize<List<cls_Empleados>>(jsonstring); //Se deserializa en una lista de objetos 
            }
            return Obj_lstResultado;
        }
        public async Task<bool> AgregarEmpleados(cls_Empleados P_Entidad)
        {
            string _sRutaAPI = @"api/Empleados/AgregarEmpleados";    //VA A CONCATENAR A LA RUTA BASE     

            HttpResponseMessage resultadoconsumo = await hcCNXApi.PostAsJsonAsync(_sRutaAPI, P_Entidad); //Realiza una solicitud a la API
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> ModificarEmpleados(cls_Empleados P_Entidad)
        {
            string _sRutaAPI = @"api/Empleados/ModificarEmpleados";    //VA A CONCATENAR A LA RUTA BASE     

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.iCedula.ToString());        //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.PutAsJsonAsync(_sRutaAPI, P_Entidad); //Realiza una solicitud a la API
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> EliminarEmpleados(cls_Empleados P_Entidad)
        {
            string _sRutaAPI = @"api/Empleados/EliminarEmpleados";    //VA A CONCATENAR A LA RUTA BASE     

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.iCedula.ToString());        //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.DeleteAsync(_sRutaAPI); //Realiza una solicitud a la API
            return resultadoconsumo.IsSuccessStatusCode;
        }
        #endregion

        #region INVENTARIO
        public async Task<List<cls_Inventario>> ListarInventario()
        {
            //Crea una lista que almacenará el resultado
            List<cls_Inventario> Obj_lstResultado = new List<cls_Inventario>();
            string _sRutaAPI = @"api/Inventario/ListarInventario";  //VA A CONCATENAR A LA RUTA BASE     

            HttpResponseMessage resultadoconsumo = await hcCNXApi.GetAsync(_sRutaAPI); //Realiza una solicitud a la API
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync(); //Lee la respuesta como JSON
                Obj_lstResultado = JsonSerializer.Deserialize<List<cls_Inventario>>(jsonstring); //Se deserializa en una lista de objetos 
            }
            return Obj_lstResultado;
        }
        public async Task<List<cls_Inventario>> ConsultarInventario(cls_Inventario P_Entidad)
        {
            //Crea una lista que almacenará el resultado
            List<cls_Inventario> Obj_lstResultado = new List<cls_Inventario>();
            string _sRutaAPI = @"api/Inventario/ConsultarInventario";  //VA A CONCATENAR A LA RUTA BASE     

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.idInventario.ToString()); //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.GetAsync(_sRutaAPI); //Realiza una solicitud a la API
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync(); //Lee la respuesta como JSON
                Obj_lstResultado = JsonSerializer.Deserialize<List<cls_Inventario>>(jsonstring); //Se deserializa en una lista de objetos 
            }
            return Obj_lstResultado;
        }
        public async Task<bool> AgregarInventario(cls_Inventario P_Entidad)
        {
            string _sRutaAPI = @"api/Inventario/AgregarInventario";    //VA A CONCATENAR A LA RUTA BASE     

            HttpResponseMessage resultadoconsumo = await hcCNXApi.PostAsJsonAsync(_sRutaAPI, P_Entidad); //Realiza una solicitud a la API
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> ModificarInventario(cls_Inventario P_Entidad)
        {
            string _sRutaAPI = @"api/Inventario/ModificarInventario";    //VA A CONCATENAR A LA RUTA BASE     

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.idInventario.ToString());        //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.PutAsJsonAsync(_sRutaAPI, P_Entidad); //Realiza una solicitud a la API
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> EliminarInventario(cls_Inventario P_Entidad)
        {
            string _sRutaAPI = @"api/Inventario/EliminarInventario";    //VA A CONCATENAR A LA RUTA BASE     

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.idInventario.ToString());        //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.DeleteAsync(_sRutaAPI); //Realiza una solicitud a la API
            return resultadoconsumo.IsSuccessStatusCode;
        }
        #endregion

        #region CLIENTES
        public async Task<List<cls_Clientes>> ListarClientes()
        {
            //Crea una lista que almacenará el resultado
            List<cls_Clientes> Obj_lstResultado = new List<cls_Clientes>();
            string _sRutaAPI = @"api/Clientes/ListarClientes";  //VA A CONCATENAR A LA RUTA BASE     

            HttpResponseMessage resultadoconsumo = await hcCNXApi.GetAsync(_sRutaAPI); //Realiza una solicitud a la API
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync(); //Lee la respuesta como JSON
                Obj_lstResultado = JsonSerializer.Deserialize<List<cls_Clientes>>(jsonstring); //Se deserializa en una lista de objetos 
            }
            return Obj_lstResultado;
        }
        public async Task<List<cls_Clientes>> ConsultarClientes(cls_Clientes P_Entidad)
        {
            //Crea una lista que almacenará el resultado
            List<cls_Clientes> Obj_lstResultado = new List<cls_Clientes>();
            string _sRutaAPI = @"api/Clientes/ConsultarClientes";  //VA A CONCATENAR A LA RUTA BASE     

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.identificacion.ToString()); //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.GetAsync(_sRutaAPI); //Realiza una solicitud a la API
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync(); //Lee la respuesta como JSON
                Obj_lstResultado = JsonSerializer.Deserialize<List<cls_Clientes>>(jsonstring); //Se deserializa en una lista de objetos 
            }
            return Obj_lstResultado;
        }
        public async Task<bool> AgregarClientes(cls_Clientes P_Entidad)
        {
            string _sRutaAPI = @"api/Clientes/AgregarClientes";    //VA A CONCATENAR A LA RUTA BASE     

            HttpResponseMessage resultadoconsumo = await hcCNXApi.PostAsJsonAsync(_sRutaAPI, P_Entidad); //Realiza una solicitud a la API
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> ModificarClientes(cls_Clientes P_Entidad)
        {
            string _sRutaAPI = @"api/Clientes/ModificarClientes";    //VA A CONCATENAR A LA RUTA BASE     

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.identificacion.ToString());        //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.PutAsJsonAsync(_sRutaAPI, P_Entidad); //Realiza una solicitud a la API
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> EliminarClientes(cls_Clientes P_Entidad)
        {
            string _sRutaAPI = @"api/Clientes/EliminarClientes";    //VA A CONCATENAR A LA RUTA BASE     

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.identificacion.ToString());        //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.DeleteAsync(_sRutaAPI); //Realiza una solicitud a la API
            return resultadoconsumo.IsSuccessStatusCode;
        }
        #endregion

        #region MANTENIMIENTO
        public async Task<List<cls_Mantenimiento>> ListarMantenimiento()
        {
            //Crea una lista que almacenará el resultado
            List<cls_Mantenimiento> Obj_lstResultado = new List<cls_Mantenimiento>();
            string _sRutaAPI = @"api/Mantenimiento/ListarMantenimiento";  //VA A CONCATENAR A LA RUTA BASE     

            HttpResponseMessage resultadoconsumo = await hcCNXApi.GetAsync(_sRutaAPI); //Realiza una solicitud a la API
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync(); //Lee la respuesta como JSON
                Obj_lstResultado = JsonSerializer.Deserialize<List<cls_Mantenimiento>>(jsonstring); //Se deserializa en una lista de objetos 
            }
            return Obj_lstResultado;
        }
        public async Task<List<cls_Mantenimiento>> ConsultarMantenimiento(cls_Mantenimiento P_Entidad)
        {
            //Crea una lista que almacenará el resultado
            List<cls_Mantenimiento> Obj_lstResultado = new List<cls_Mantenimiento>();
            string _sRutaAPI = @"api/Mantenimiento/ConsultarMantenimiento";  //VA A CONCATENAR A LA RUTA BASE     

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.idMantenimiento.ToString()); //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.GetAsync(_sRutaAPI); //Realiza una solicitud a la API
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync(); //Lee la respuesta como JSON
                Obj_lstResultado = JsonSerializer.Deserialize<List<cls_Mantenimiento>>(jsonstring); //Se deserializa en una lista de objetos 
            }
            return Obj_lstResultado;
        }
        public async Task<bool> AgregarMantenimiento(cls_Mantenimiento P_Entidad)
        {
            string _sRutaAPI = @"api/Mantenimiento/AgregarMantenimiento";    //VA A CONCATENAR A LA RUTA BASE     

            HttpResponseMessage resultadoconsumo = await hcCNXApi.PostAsJsonAsync(_sRutaAPI, P_Entidad); //Realiza una solicitud a la API
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> ModificarMantenimiento(cls_Mantenimiento P_Entidad)
        {
            string _sRutaAPI = @"api/Mantenimiento/ModificarMantenimiento";    //VA A CONCATENAR A LA RUTA BASE     

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.idMantenimiento.ToString());        //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.PutAsJsonAsync(_sRutaAPI, P_Entidad); //Realiza una solicitud a la API
            return resultadoconsumo.IsSuccessStatusCode;
        }
        public async Task<bool> EliminarMantenimiento(cls_Mantenimiento P_Entidad)
        {
            string _sRutaAPI = @"api/Mantenimiento/EliminarMantenimiento";    //VA A CONCATENAR A LA RUTA BASE     

            hcCNXApi.DefaultRequestHeaders.Add("id", P_Entidad.idMantenimiento.ToString());        //HAY UN PARAMETRO "id" DEL CONTROLLER DE LA SOLUCION BASE

            HttpResponseMessage resultadoconsumo = await hcCNXApi.DeleteAsync(_sRutaAPI); //Realiza una solicitud a la API
            return resultadoconsumo.IsSuccessStatusCode;
        }
        #endregion

        #region REPORTES

        #endregion
        #endregion
    }
}
