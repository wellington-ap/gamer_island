using gamesapi.infra.modelo;
using MySql.Data.MySqlClient;

namespace gamesapi.infra;

public class repositorio_de_logs
{
    private readonly conexao_do_repositorio conn;
    private const string date = ", current_date()";

    public repositorio_de_logs(conexao_do_repositorio conn)
    {
        this.conn = conn;
    }

    public bool LogInformation(Amiibo[] itens)
    {
        string[] insertCom = new string[]
        {
            "insert into amiibooLog (amiiboSeries, thecharacter, gameSeries, head, image, name, tail, type, searchdata)"
        };
        

        foreach (var insert in insertCom)
        {
            itens.ToList().ForEach((x) =>
            {
                string sqlToInsert =
                    $@"{insert} values (@amiiboSeries, @character, @gameSeries, @head, @image, @name, @tail, @type{ insertDate(insert) });";
                
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(conn.valor))
                    {
                        connection.Open();
                        using (MySqlCommand cmd = new MySqlCommand(sqlToInsert, connection))
                        {
                            cmd.Parameters.AddWithValue("amiiboSeries", x.amiiboSeries);
                            cmd.Parameters.AddWithValue("character", x.character);
                            cmd.Parameters.AddWithValue("gameSeries", x.gameSeries);
                            cmd.Parameters.AddWithValue("head", x.head);
                            cmd.Parameters.AddWithValue("image", x.image);
                            cmd.Parameters.AddWithValue("name", x.name);
                            cmd.Parameters.AddWithValue("tail", x.tail);
                            cmd.Parameters.AddWithValue("type", x.type);
                            int rowsAffected = cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            });
        }

        return true;
    }

    public string insertDate(string insertCom)
    {
        return insertCom.Contains("searchdata") ? date : string.Empty;
    }
}