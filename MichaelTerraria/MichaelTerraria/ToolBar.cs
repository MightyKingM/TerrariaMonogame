using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelTerraria
{
    class ToolBar
    {
        List<Item> item;
        public int inuse = 1;
        public ToolBar(Inventory inv)
        {
            item = inv.items;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < item.Count(); i++)
                spriteBatch.Draw(item[i].look, new Rectangle(i * 50, 1900, 40, 40), Color.White);
        }
        public void SetInv(Inventory inv)
        {
            item = inv.items;
        }
        public void Next()
        {
            if(inuse<item.Count())
            inuse++;

            else
            {
                inuse = 1;
            }
        }
        
    }
}
