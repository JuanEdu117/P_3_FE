using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace Proyecto1_KatherineMurillo.Models
{
    public class cls_Empleados
    {
        #region VARIABLES PUBLICAS            
        [Required(ErrorMessage = "La cédula es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Cédula")]
        public int iCedula { get; set; }
        [Required(ErrorMessage = "El nombre completo es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Nombre completo")]
        public string sNombreCompleto{ get; set; }
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Fecha de nacimiento")]
        public DateTime dtmFechaNacimiento { get; set; }
        [Required(ErrorMessage = "La lateralidad es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Lateralidad")]
        public string sLateralidad { get; set; }
        [Required(ErrorMessage = "La fecha de ingreso es requerida")] //Valida que no se dejen campos en blanco
        [Display(Name = "Fecha de ingreso")]
        public DateTime dtmFechaIngreso { get; set; }
        [Required(ErrorMessage = "El salario por hora es requerido")] //Valida que no se dejen campos en blanco
        [Display(Name = "Salario por hora")]
        public float fSalarioHora { get; set; }
        public cls_Empleados()
        {
            iCedula = 0;
            sNombreCompleto = string.Empty;
            dtmFechaNacimiento = DateTime.MinValue;
            sLateralidad = string.Empty;
            dtmFechaIngreso = DateTime.MinValue;
            fSalarioHora = 0;
        }
        #endregion
    }
}
