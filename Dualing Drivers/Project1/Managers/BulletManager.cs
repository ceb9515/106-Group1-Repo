using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Managers
{
    internal class BulletManager
    {
        public List<Bullet> BulletList=new List<Bullet>();
        private Texture2D bulletTexture;
        private Rectangle GameBound;
        public void AddBullet(Bullet newBullet,Player player)
        {
            while (!newBullet.IsColliding(player.rect))
            {
                newBullet.Move();
            }
            BulletList.Add(newBullet);
            
        }


        public void ProcessCollision(List<List<Tile>> tileList, List<Player> playerList, List<Bullet> bulletList)
        {
            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].Move();

                // Check collision with tiles
                for (int j = 0; j < tileList.Count; j++)
                {
                    for (int k = 0; k < tileList[j].Count; k++)
                    {
                        Tile currentTile = tileList[j][k];
                        if (bulletList[i].IsColliding(currentTile.Rect))
                        {
                            if (currentTile.Type == TileType.breakable)
                            {
                                currentTile.TakeDamage();
                                bulletList[i].Destroy();
                                break; 
                            }
                            else if (currentTile.Type == TileType.solid)
                            {
                                bulletList[i].Destroy();
                                break; 
                            }
                        }
                    }
                }

                

                // Check collision with players
                for (int k = 0; k < playerList.Count; k++)
                {
                    if (bulletList[i].IsColliding(playerList[k].rect))
                    {
                        playerList[k].TakeDamage(playerList[k]); 
                        bulletList[i].Destroy();
                        break; 
                    }
                }
            }
        }
        public void  DrawBullet(SpriteBatch sb)
        {
            for(int i = 0;i < BulletList.Count; i++)
            {
                BulletList[i].Draw(sb);
            }
        }
        public void cleanUp()
        {
            for( int i = 0;i<BulletList.Count;i++)
            {
                BulletList[i].Destroy();
            }
        }
        
    }
}
