using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOn
{
    class Game
    {
        public Tile[] Board = new Tile[25];

        public Game()
        {
            for (int i = 0; i < 25; i++)
            {
                Board[i] = new Tile(i + 1);
                SetAdjacentTiles(i + 1);
            }
        }

        private void SetAdjacentTiles(int tile_Id)
        {
            List<int> adjacentTiles = new();

            int row = (int)Math.Ceiling(tile_Id / 5.0);
            int column = tile_Id % 5;
            if (column == 0) column = 5;

            if (row > 1) adjacentTiles.Add(tile_Id - 5);
            if (row < 5) adjacentTiles.Add(tile_Id + 5);
            if (column < 5) adjacentTiles.Add(tile_Id + 1);
            if (column > 1) adjacentTiles.Add(tile_Id - 1);

            Board[tile_Id - 1].SetAdjacentTiles(adjacentTiles.ToArray());
        }

        public int[] Click_Tile_And_Get_Adjacent_Tiles_Ids(int tile_Id)
        {
            var tile = Board[tile_Id - 1];
            tile.ToggleLight();
            foreach (int id in tile.AdjacentTiles) Board[id - 1].ToggleLight();
            return tile.AdjacentTiles;
        }

        internal bool IsLightOn(int id)
        {
            return Board[id-1].LightOn;
        }
    }
}