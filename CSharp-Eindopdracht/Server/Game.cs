using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication
{
    class Game
    {

        public List<ServerClient> players;
        
        public Game(ServerClient player1)
        {
            this.players = new List<ServerClient>();
        }

        public void playerJoin(ServerClient player2)
        {
            this.players.Add(player2);
        }


    }
}
