using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelTerraria
{
    class Item
    {
        public Texture2D look;
        public string name;
       
        public Item(Section sect)
        {
            this.look = sect.texture;
            this.name = sect.ID;
           
        }
        
    }
}
