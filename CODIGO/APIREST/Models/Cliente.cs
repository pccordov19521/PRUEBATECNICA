namespace APIREST.Models
{
    public class Cliente : Persona
    {

        public int clienteid { get; set; }
        public string? contrasenia { get; set; }
        public Boolean estado { get; set; }

        
    }
}
