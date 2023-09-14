namespace gamesapi.infra
{
    public class conexao_do_repositorio : objeto_de_valor<string>
    {
        public conexao_do_repositorio() { }
        public conexao_do_repositorio(string connectionString) : base(connectionString) { }
    }
}
