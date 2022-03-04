using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOn
{
    class Tile
    {
        public int[] AdjacentTiles { get; private set; }
        public int Id { get; }
        public bool LightOn { get; private set; }

        public Tile(int id)
        {
            Id = id;
        }
        public void SetAdjacentTiles(int[] adjacentTiles)
        {
            AdjacentTiles = adjacentTiles;
        }

        public void ToggleLight()
        {
            LightOn = !LightOn;
        }
    }
}
