namespace APIREST.Models
{
    public class Cuenta
    {
        public int cuentaid { get; set; }
        public string? numerocuenta { get; set; }
        public string? tipocuenta { get; set; }
        public decimal saldoinicial { get; set; }
        public Boolean? estado { get; set; }

        public int clienteid { get; set; }

        public decimal saldofinal { get; set; }

       
    }
}
