namespace APIREST.Models
{
    public class Movimientos
    {
        public int movimientosid { get; set; }
        public DateTime fecha { get; set; }
        public string tipomovimiento { get; set; }
        public decimal valor { get; set; }
        public decimal saldo { get; set; }
        public int cuentaid { get; set; }

        //public void ActualizarSaldo()
        //{

        //    saldo += valor;
        //}

    }
}
