using System.ComponentModel.DataAnnotations;

namespace Proyecto1_KatherineMurillo.Models
{
    public class cls_Clientes
    {
        #region VARIABLES PUBLICAS
        [Required(ErrorMessage = "La identificación del cliente es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Identificación")]
        public int identificacion { get; set; }
        [Required(ErrorMessage = "El nombre completo es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Nombre completo")]
        public string nombreCompleto { get; set; }
        [Required(ErrorMessage = "La provincia es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Provincia")]
        public string provincia { get; set; }
        [Required(ErrorMessage = "El cantón es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Cantón")]
        public string canton { get; set; }
        [Required(ErrorMessage = "El distrito es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Distrito")]
        public string distrito { get; set; }
        [Required(ErrorMessage = "La dirección exacta es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Dirección exacta")]                                                              
        public string direccionExacta { get; set; }
        [Required(ErrorMessage = "La preferencia de mantenimiento en invierno es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Mantenimiento en invierno")]
        public int mantenimientoInvierno { get; set; }
        [Required(ErrorMessage = "La preferencia de mantenimiento en verano es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Mantenimiento en verano")]
        public int mantenimientoVerano { get; set; }
        public cls_Clientes()
        {
            identificacion = 0;
            nombreCompleto = string.Empty;
            provincia = string.Empty;
            canton = string.Empty;
            distrito = string.Empty;
            direccionExacta = string.Empty;
            mantenimientoInvierno = 0;
            mantenimientoVerano = 0;
        }
        #endregion
    }
}
