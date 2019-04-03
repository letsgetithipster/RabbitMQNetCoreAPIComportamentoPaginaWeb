namespace MqConsumer.Models
{
    public class Comportamento
    {
        public int Id { get; set; }
        public string IP { get; set; }
        public string NomePagina { get; set; }
        public string Browser { get; set; }
        public string Parametros { get; set; }

        public override string ToString()
        {
            return $"{IP},{NomePagina},{Browser},{Parametros}";
        }
    }
}
