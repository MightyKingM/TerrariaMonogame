using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelTerraria
{
    class Section
    {
        public Texture2D texture;
        Point point;
        public Rectangle rect;
        public string ID;
        public Section(Texture2D texture,Point point,string ID)
        {
            this.texture = texture;
            this.point = point;
            this.ID = ID;
            rect = new Rectangle(point.X, point.Y, 50, 50);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            rect = new Rectangle(point.X, point.Y, 50, 50);
            spriteBatch.Draw(texture, rect, Color.White);
        }
    }
}
