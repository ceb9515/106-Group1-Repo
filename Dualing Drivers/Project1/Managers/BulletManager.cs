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
       
        
        public void  ProcessCollition(List<Tile> TileList,List<Player>PlayerList)
        {
            for (int i = 0; i < BulletList.Count; i++)
            {
                BulletList[i].Move();
                for (int j = 0; j < TileList.Count; j++)
                {
                    if (BulletList[i].IsColliding(TileList[j].Rect) && TileList[j].Type == TileType.breakable)
                    {
                        TileList[j].TakeDamage();
                        BulletList[i].Destroy();
                    }
                }
                for(int k=0; k<PlayerList.Count;k++)
                {
                    if (BulletList[i].IsColliding(PlayerList[k].rect))
                    {
                        PlayerList[k].TakeDamage(PlayerList[k]);
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
