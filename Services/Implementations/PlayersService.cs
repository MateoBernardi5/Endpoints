using jugadores.Entities;
using jugadores.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;


namespace jugadores.Services.Implementations
{
    public class PlayersService : IPlayers
    {
        static List<Player> Players { get; }

        static PlayersService()
        {
            Players = new List<Player>
            {
                new Player { Id = 1, Name = "Benedetto", Goals = 3 },
                new Player { Id = 2, Name = "Merentiel", Goals = 4 },
                new Player { Id = 3, Name = "Cavani", Goals = 2 }
            };
        }

        public List<Player> AllPlayers() //La lista contiene los jugadores, y AllPlayers es el metodo que contiene a esa lista
        {
            return Players;
        }

        public Player? OnePlayer(int id)
        {
            return Players.SingleOrDefault(player => player.Id == id);
        }

        public Player CreatePlayer(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            // Asigna un nuevo ID al jugador
            int newPlayerId = Players.Max(p => p.Id) + 1;
            player.Id = newPlayerId;

            // Agrega el jugador a la lista
            Players.Add(player);

            return player;
        }

    }
}
