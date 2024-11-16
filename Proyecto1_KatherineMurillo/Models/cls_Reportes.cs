namespace Proyecto1_KatherineMurillo.Models
{
    public class cls_Reportes
    {
        #region VARIABLES PUBLICAS
        public int id_Reporte { get; set; }
        public int id_Cliente { get; set; }
        public int id_Mantenimiento { get; set; }
        public string nombre_Cliente { get; set; }
        public DateTime fecha_ultimo_servicio { get; set; }
        public DateTime proxima_fecha_contacto { get; set; }
        public DateTime fecha_reporte { get; set; }
        public string motivo { get; set; }
        public cls_Reportes()
        {
            id_Reporte = 0;
            id_Cliente = 0;
            id_Mantenimiento = 0;
            nombre_Cliente = string.Empty;
            fecha_ultimo_servicio = DateTime.MinValue;
            proxima_fecha_contacto = DateTime.MinValue;
            fecha_reporte = DateTime.MinValue;
            motivo = string.Empty;
        }
        #endregion
    }
}
