using gamesapi.infra;
using gamesapi.infra.modelo;
using Microsoft.AspNetCore.Mvc;

namespace gamesapi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class SaveCharController : ControllerBase
{
    private readonly conexao_do_repositorio conn;

    public SaveCharController(conexao_do_repositorio conn)
    {
        this.conn = conn;
    }

    [HttpPost]
    public IActionResult Save([FromBody] Amiibo saver)
    {
        var repo = new repositorio_de_dados(conn);
        repo.TranslateToAmiibooo(saver, out var enviar);        
        return Ok(repo.Save(enviar));
    }
    
}