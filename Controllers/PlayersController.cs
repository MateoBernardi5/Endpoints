using jugadores.Entities;
using jugadores.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jugadores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        //Aca arranco a inyectar en el controlador
        private readonly IPlayers _playersService;

        public PlayersController(IPlayers playersService)
        {
            _playersService = playersService;
        }
        //aca termina la inyeccion

        [HttpGet("MostrarJugadores")]
        public IActionResult AllPlayers() 
        {
            return Ok(_playersService.AllPlayers());
        }

        [HttpGet("{id}")]
        public IActionResult OnePlayer([FromRoute]int id)
        {
            Player? player = _playersService.OnePlayer(id);

            if (player == null)
            {
                return BadRequest("No se encontró jugador con esa id");
            }

            return Ok(player);
        }

        [HttpPost("CrearJugador")] // Añade este atributo para indicar que esta acción es para solicitudes HTTP POST
        public IActionResult CreatePlayer([FromBody] Player player)
        {
            if (player == null)
            {
                return BadRequest("Datos del jugador no proporcionados");
            }


            // Devuelve una respuesta apropiada, por ejemplo, un Created con la ubicación del nuevo jugador
            return Created("/api/players/" + player.Id, player);
        }



    }
}
