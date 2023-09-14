using gamesapi.infra;
using gamesapi.infra.modelo;
using Microsoft.AspNetCore.Mvc;

namespace gamesapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AmiiboAPIController : ControllerBase
    {
        private readonly conexao_do_repositorio conn;
        private readonly repositorio_de_logs Ilogger;

        public AmiiboAPIController(conexao_do_repositorio conn)
        {
            this.conn = conn;
            Ilogger = new repositorio_de_logs(this.conn);
        }

        [HttpGet]
        public IActionResult Get(string search)
        {
            var repositorio = new repositorio_de_dados(conn);

            var items = repositorio.GetFiltrado(new filter() { charname = search });

            Ilogger.LogInformation(items);

            return Ok(items);
        }

        [HttpGet]
        public IActionResult GetData(string search)
        {
            var repositorio = new repositorio_de_dados(conn);
            var items = repositorio.GetFiltered(search);

            repositorio.TranslateFromAmiiboooList(items.ToList(), out var retorno);

            Ilogger.LogInformation(retorno.ToArray());

            if (ValidateReturn(retorno, search, repositorio))
            {
                return Ok(retorno.ToArray());
            }
            else
            {
                return Ok("Ocorreu um problema de validação de itens");
            }
        }

        private bool ValidateReturn(List<Amiibo> items, string search, repositorio_de_dados repositorio)
        {
            var itensFiltrados = from ga in repositorio.GetAll()
                where ga.name.Contains(search) || ga.thecharacter.Contains(search) || ga.gameSeries.Contains(search)
                select ga;

            repositorio.TranslateFromAmiiboooList(itensFiltrados.ToList(), out var itensReais);

            if (itensReais.Count <= items.Count)
                return true;
            else
            {
                return false;
            }
        }
    }
}