namespace gamesapi.infra
{
    public abstract class objeto_de_valor<T>
    {
        protected objeto_de_valor() { }

        protected objeto_de_valor(T valor)
        {
            this.valor = valor;
        }
        
        public T? valor { get; protected set; }
    }
}
