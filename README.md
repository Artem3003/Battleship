# Battleship

Each player gets a 10-by-10 grid on which to place five ships: the eponymous Battleship, as well as an Aircraft Carrier, a Cruiser, a Submarine, and a Destroyer. The ships have differing lengths, and larger ships can take more hits. Players cannot see the opposing player's game board.

Players also have a blank firing board from which they can call out shots. On each player's turn, they call out a panel (by using the panel coordinates, e.g. "A5" which means row A, column 5) on their opponent's board. The opponent will then tell them if that shot is a hit or a miss. If it's a hit, the player marks that panel with a red peg; if it is a miss, the player marks that panel with a white peg. It then becomes the other player's turn to call a shot.

When a ship is sunk, the player who owned that ship should call out what ship it was, so the other player can take note. Finally, when one player loses all five of his/her ships, that player loses.

## Classes

* Game 

It's the main class which start your game and creates all necessary classes.

* BattleshipField

Write a method that takes a field for well-known board game "Battleship" as an argument and returns true if it has a valid disposition of ships, false otherwise. Argument is guaranteed to be 10*10 two-dimension array. Elements in the array are numbers, 0 if the cell is free and 1 if occupied by ship.

* ShipStatus

To determine how many boats are sunk damaged and untouched from a set amount of attacks. You will need to create a function that takes two arguments, the playing board and the attacks.

* ShotCoordinates

Gets coordinates from the player and rebuild into good format for shooting on battleship field.

* OccupationType 

Show type of panel.

* GameBoard

GameBoard

* FiringBoard