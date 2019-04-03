namespace Crud.App.Domain.Usuarios.ValueObjects
{
    public class NomeCompleto
    {
        public NomeCompleto(string primeiroNome, string segundoNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            SegundoNome = segundoNome;
            UltimoNome = ultimoNome;
        }

        protected NomeCompleto() { }

        public string PrimeiroNome { get; private set; }
        public string SegundoNome { get; private set; }
        public string UltimoNome { get; private set; }
    }
}
