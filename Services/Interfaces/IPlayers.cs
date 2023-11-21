using jugadores.Entities;
using Microsoft.AspNetCore.Mvc;

namespace jugadores.Services.Interfaces
{
    public interface IPlayers
    {
        List<Player> AllPlayers();
        Player? OnePlayer(int id);
        Player CreatePlayer([FromBody] Player player);
    }
}
