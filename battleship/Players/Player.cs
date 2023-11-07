using System.Transactions;
using System.Globalization;
using System;

namespace battleship
{
    class Player : IPlayer
    {
        private string name;
        public List<Ship> ships;
        public GameBoard gameBoard;
        public FiringBoard firingBoard;

        public Player(string name)
        {
            this.name = name;
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
                return ships.All(sh => sh.IsSunk);
            } 
            set {}
        }

        public string Name
        {
            get
            {
                return name;
            }
            set{}
        }

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