using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelTerraria
{
    class Terrain : TerrainGenerator
    {
        int basenum;
        Random rand;
        int x = 1;
        int y = 1;
        List<int> Seeds;
        List<List<Section>> platforms;
        
        public Terrain(Texture2D water, Texture2D landbase, Texture2D landheight1, Texture2D landheight2, Texture2D village)
            :base(water,landbase,landheight1, landheight2,village)
        {
            rand = new Random();
            Seeds = new List<int>();
            platforms = new List<List<Section>>();
           
        }
        
        public void setPlat(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void WriteAllTerrain()
        {
            GenerateTerrain(3000, 1500, Seeds[0]);
            platforms.Add(Tiles);
            GenerateTerrain(3000, 1500, Seeds[1]);
            platforms.Add(Tiles);
            GenerateTerrain(3000, 1500, Seeds[2]);
            platforms.Add(Tiles);
            GenerateTerrain(3000, 1500, Seeds[3]);
            platforms.Add(Tiles);
            GenerateTerrain(3000, 1500, Seeds[4]);
            platforms.Add(Tiles);
            GenerateTerrain(3000, 1500, Seeds[5]);
            platforms.Add(Tiles);
            GenerateTerrain(3000, 1500, Seeds[6]);
            platforms.Add(Tiles);
            GenerateTerrain(3000, 1500, Seeds[7]);
            platforms.Add(Tiles);
            GenerateTerrain(3000, 1500, Seeds[8]);
            platforms.Add(Tiles);
        }
        public void CreateTerrain()
        {
            if(x == 1 && y ==1)
            {
                Tiles = platforms[0];
            }
            if (x == 2 && y == 1)
            {
                
                Tiles = platforms[1];
            }
            if (x == 3 && y == 1)
            {
                
                Tiles = platforms[2];
            }
            if (x == 1 && y == 2)
            {
                
                Tiles = platforms[3];
            }
            if (x == 2 && y == 2)
            {
                
                Tiles = platforms[4];
            }
            if (x == 3 && y == 2)
            {
                
                Tiles = platforms[5];
            }
            if (x == 1 && y == 3)
            {
                
                Tiles = platforms[6];
            }
            if (x == 2 && y == 3)
            {
                
                Tiles = platforms[7];
            }
            if (x == 3 && y == 3)
            {
                
                Tiles = platforms[8];
            }

        }
        public void BreakBlock(Rectangle rect, Inventory inv)
        {
            for(int i = 0; i<Tiles.Count(); i++)
            {
                if(rect == Tiles[i].rect)
                {
                    inv.items.Add(new Item(Tiles[i]));
                    Tiles.RemoveAt(i);
                    break;
                }
            }
        }
        public void CreateBlock(Rectangle rect,Texture2D t2,string ID)
        {
            Tiles.Add(new Section(t2, new Point(rect.X, rect.Y), ID));
        }
        public void makeRandTerrain()
        {
            basenum = rand.Next(1, 4);
            Seeds.Clear();
            for(int i = 1; i < 10; i++)
            {
                Seeds.Add(basenum + i);
            }
        }
         public string seedsToStrind()
         {
            string t = "";
            for(int i = 0; i < Seeds.Count(); i++)
            {
                t += Seeds[i].ToString();
            }
            return t;
         }
        

    }
}
