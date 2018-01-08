
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelTerraria
{
    class Inventory
    {
        public List<Item> items;
        public List<Item> toolist;
        public Inventory()
        {
            items = new List<Item>();
        }
        public void Add(Section sect)
        {
            items.Add(new Item(sect));
        }
       
    }
}
