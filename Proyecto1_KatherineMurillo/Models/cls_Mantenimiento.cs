using System.ComponentModel.DataAnnotations;

namespace Proyecto1_KatherineMurillo.Models
{
    public class cls_Mantenimiento
    {
        #region VARIABLES PUBLICAS
        [Required(ErrorMessage = "El ID del mamtenimiento es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "ID de mantenimiento")]
        public int idMantenimiento { get; set; }
        [Required(ErrorMessage = "El ID del cliente es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "ID del cliente")]
        public int idCliente { get; set; }
        [Required(ErrorMessage = "La fecha de ejecutado es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Fecha de ejecutado")]
        public DateTime fechaEjecutado { get; set; }
        [Required(ErrorMessage = "La fecha de agendado es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Fecha de agendado")]
        public DateTime fechaAgendado { get; set; }
        [Required(ErrorMessage = "La cantidad de metros cuadrados de la propiedad es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Metros de la propiedad")]
        public float metrosPropiedad { get; set; }
        [Required(ErrorMessage = "La cantidad de metros cuadrados de cerca viva es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Metros de cerca viva")]
        public float metrosCercaViva { get; set; }
        [Required(ErrorMessage = "La cantidad de días sin chapia es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Días sin chapia")]
        public string diasSinChapia { get; set; }
        [Required(ErrorMessage = "La fecha aproximada de la siguiente chapia es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Fecha de la siguiente chapia")]
        public string fechaOtraChapia { get; set; }
        [Required(ErrorMessage = "El tipo de zacate es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Tipo de zacate")]
        public string tipoZacate { get; set; }
        [Required(ErrorMessage = "Si se le ha aplicado algún producto es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Aplicación de producto")]
        public string aplicacionProducto { get; set; }
        [Required(ErrorMessage = "El producto aplicado es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Producto aplicado")]
        public string productoAplicado { get; set; }
        [Required(ErrorMessage = "El costo de la chapia es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Costo de la chapia")]
        public float costoChapia { get; set; }
        [Required(ErrorMessage = "El costo de la aplicación es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Costo de la aplicación del producto")]
        public float costoAplicacionProducto { get; set; }
        [Required(ErrorMessage = "El estado del mantenimiento es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Estado del mantenimiento")]
        public string estadoMantenimiento { get; set; }
        public cls_Mantenimiento()
        {
            idMantenimiento = 0;
            idCliente = 0;
            fechaEjecutado = DateTime.MinValue;
            fechaAgendado = DateTime.MinValue;
            metrosPropiedad = 0;
            metrosCercaViva = 0;
            diasSinChapia = string.Empty;
            fechaOtraChapia = string.Empty;
            tipoZacate = string.Empty;
            aplicacionProducto = string.Empty;
            productoAplicado = string.Empty;
            costoChapia = 0;
            costoAplicacionProducto = 0;
            estadoMantenimiento = string.Empty;
        }
        #endregion
    }
}
