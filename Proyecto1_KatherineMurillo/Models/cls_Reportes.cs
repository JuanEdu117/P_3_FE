namespace Proyecto1_KatherineMurillo.Models
{
    public class cls_Reportes
    {
        #region VARIABLES PUBLICAS
        public int id_Reporte { get; set; }
        public int id_Cliente { get; set; }
        public int id_Mantenimiento { get; set; }
        public string nombre_Cliente { get; set; }
        public DateTime fecha_Ultimo_Servicio { get; set; }
        public DateTime proxima_Fecha_Contacto { get; set; }
        public DateTime fecha_Reporte { get; set; }
        public string motivo { get; set; }
        public cls_Reportes()
        {
            id_Reporte = 0;
            id_Cliente = 0;
            id_Mantenimiento = 0;
            nombre_Cliente = string.Empty;
            fecha_Ultimo_Servicio = DateTime.MinValue;
            proxima_Fecha_Contacto = DateTime.MinValue;
            fecha_Reporte = DateTime.MinValue;
            motivo = string.Empty;
        }
        #endregion
    }
}
