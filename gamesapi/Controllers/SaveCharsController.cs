using gamesapi.infra;
using gamesapi.infra.modelo;
using Microsoft.AspNetCore.Mvc;

namespace gamesapi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class SaveCharsController : ControllerBase
{
    private readonly conexao_do_repositorio conn;
    
    public SaveCharsController(conexao_do_repositorio conn)
    {
        this.conn = conn;
    }

    [HttpPost]
    public IActionResult Save([FromBody] Amiibo[] saver)
    {
        var repo = new repositorio_de_dados(conn);
        repo.TranslateToAmiiboooList(saver.ToList(), out var enviar);
        enviar.ForEach(a => repo.Save(a));
        return Ok(true);
    }
    
}