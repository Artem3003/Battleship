using System;

namespace battleship
{
    class Bot : IPlayer
    {
        private string name;
        private List<Ship> ships;
        private GameBoard gameBoard;
        private FiringBoard firingBoard;

        public Bot()
        {
            this.name = "Bot";
            this.ships = new List<Ship>()
            {
                new Battleship(),
                new Destroyer(),
                new Cruiser(),
                new Cruiser(),
                new Submarine(),
                new Submarine(),
                new Submarine()
            };
            gameBoard = new GameBoard();
            firingBoard = new FiringBoard();
        }

        public bool HasLost
        {
            get
            {
                return Ships.All(sh => sh.IsSunk);
            } 
            set {}
        }

        public string Name => name;

        public List<Ship> Ships
        {
            get
            {
                return ships;
            }
            set
            {
                ships = value;
            }
        }

        public GameBoard GameBoard
        {
            get
            {
                return gameBoard;
            }
            set
            {
                gameBoard = value;
            }
        }

        public FiringBoard FiringBoard
        {
            get
            {
                return firingBoard;
            }
            set
            {
                firingBoard = value;
            }
        }
    }
}