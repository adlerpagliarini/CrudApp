namespace Crud.App.Domain.Usuarios.ValueObjects
{
    public class Telefone
    {
        public Telefone(string ddd, string numero)
        {
            DDD = ddd;
            Numero = numero;
        }

        protected Telefone() { }

        public string DDD { get; private set; }
        public string Numero { get; private set; }
    }
}
