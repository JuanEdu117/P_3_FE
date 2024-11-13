using System.ComponentModel.DataAnnotations;

namespace Proyecto1_KatherineMurillo.Models
{
    public class cls_Inventario
    {
        #region VARIABLES PUBLICAS  
        [Required(ErrorMessage = "El ID del inventario es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "ID de inventario")]
        public int idInventario { get; set; }
        [Required(ErrorMessage = "La descripción es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }
        [Required(ErrorMessage = "El tipo de máquina es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Tipo de máquina")]
        public string tipoMaquina { get; set; }
        [Required(ErrorMessage = "Las horas de uso actuales son requeridas")] //Valida que no se dejen campos en blanco
        [Display(Name = "Horas de uso actuales")]
        public float horasActuales { get; set; }
        [Required(ErrorMessage = "Las horas de uso máximas al día son requeridas")] //Valida que no se dejen campos en blanco
        [Display(Name = "Horas de uso máximas")]
        public float horasMaximas { get; set; }
        [Required(ErrorMessage = "Las horas de uso para dar mantenimiento son requeridas")] //Valida que no se dejen campos en blanco
        [Display(Name = "Horas de uso para mantenimiento")]
        public float horasMantenimiento { get; set; }
        public cls_Inventario()
        {
            idInventario = 0;
            descripcion = string.Empty;
            tipoMaquina = string.Empty;
            horasActuales = 0;
            horasMaximas = 0;
            horasMantenimiento = 0;
        }
        #endregion
    }
}
