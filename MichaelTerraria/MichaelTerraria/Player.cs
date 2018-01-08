using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelTerraria
{
    class Player
    {
        Texture2D TA;
        Texture2D TB;
        Texture2D TC;
        Texture2D TD;
        Texture2D p;
        public Rectangle rect;
        public Rectangle Hitzone;
        int direction = 1;
        public int x = 1;
        public int y = 1;
        int MOVE = 5;
        public int inuse;
        public Inventory inventory;
        public Player(Texture2D TA, Texture2D TB, Texture2D TC, Texture2D TD,Texture2D p, Rectangle rect)
        {
            this.TA = TA;
            this.TB = TB;
            this.TC = TC;
            this.TD = TD;
            this.rect = rect;
            this.p = p;
            inventory = new Inventory();
        }
        public void Draw(SpriteBatch SB)
        {
            if(direction == 1)
            {
                SB.Draw(TA, rect, Color.White);
            }
            if (direction == 2)
            {
                SB.Draw(TB, rect, Color.White);
            }
            if (direction == 3)
            {
                SB.Draw(TC, rect, Color.White);
            }
            if (direction == 4)
            {
                SB.Draw(TD, rect, Color.White);
            }
            SB.Draw(p,Hitzone, Color.Red * 0.2f);
        }
        public void Move(KeyboardState KS,KeyboardState PK, ref Terrain terrain,int width, int height)
        {
            if(rect.X <= 1)
            {
                if(x!= 1)
                {
                    x = x-1;
                    rect.X = 2900; 
                    terrain.setPlat(x, y);
                    terrain.CreateTerrain();
                }
                else
                {
                   
                }
            }
            if(rect.Y - rect.Height < 1)
            {
               if(y!= 3)
                {
                    y = y + 1;
                    rect.Y = 1400;
                    terrain.setPlat(x, y);
                    terrain.CreateTerrain();
                }
               else
                {
                   
                }
            }
            if(rect.X + rect.Width > width)
            {
                if(x!=3)
                {
                    
                    x = x + 1;
                    rect.X = 100;
                    terrain.setPlat(x, y);
                    terrain.CreateTerrain();
                }
               
            }
            if(rect.Y > height)
            {
                if(y!=1)
                {
                    rect.Y = 100;
                    y = y - 1;
                    terrain.setPlat(x,y);
                    terrain.CreateTerrain();
                }
            }
            if(PK.IsKeyDown(Keys.LeftShift)&&KS.IsKeyUp(Keys.LeftShift))
            {
                terrain.BreakBlock(Hitzone,inventory);
            }
            if (PK.IsKeyDown(Keys.RightShift) && KS.IsKeyUp(Keys.RightShift))
            {
                terrain.CreateBlock(Hitzone, inventory.items[inuse].look, inventory.items[inuse].name);         
            }
            if (PK.IsKeyDown(Keys.W)&& MOVE != 1 && KS.IsKeyUp(Keys.W))
            {
                direction = 1;
                rect.Y = rect.Y - 50;
                Hitzone = new Rectangle(rect.X, rect.Y - rect.Height, 50, 50);
            }
            if (PK.IsKeyDown(Keys.A) && MOVE != 2 &&  KS.IsKeyUp(Keys.A))
            {
                direction = 4;
                rect.X = rect.X - 50;
                Hitzone = new Rectangle(rect.X -1* rect.Width, rect.Y, 50,50);
            }
            if (PK.IsKeyDown(Keys.S) && MOVE != 3 && KS.IsKeyUp(Keys.S ))
            {
                direction = 3;
                rect.Y = rect.Y + 50;
                Hitzone = new Rectangle(rect.X, rect.Y+ 1*rect.Height, 50,50);
            }
            if (PK.IsKeyDown(Keys.D) && MOVE != 4 && KS.IsKeyUp(Keys.D)
                )
            {
                direction = 2;
                rect.X = rect.X + 50;
                Hitzone = new Rectangle(rect.X + rect.Width,rect.Y,50,50);
            }
            
        }
    }
}
