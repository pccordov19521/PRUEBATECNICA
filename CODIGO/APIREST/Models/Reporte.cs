using Microsoft.EntityFrameworkCore;

namespace APIREST.Models
{
    [Keyless]
    public class Reporte
    {
        public DateTime fecha {  get; set; }
        public string cliente {  get; set; }
        public string numerodecuenta {  get; set; }
        public string tipocuenta { get; set; }
        public decimal saldoinicial { get; set; }
        public decimal movimiento { get; set; }
        public decimal saldodisponible { get; set; }

    }
}
