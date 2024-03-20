using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
        public void AddBullet(Bullet newBullet)
        {
            BulletList.Add(newBullet);
        }
        public void override Update()
        {
            for(int i = 0; i < BulletList.Count; i++)
            {
                BulletList[i].Move();
                for(int j = 0;j<TileList.Count;j++)
                {
                    if (BulletList[i].IsColliding(TileList[j]) && TileList[j].Tiletype== breakable)
                    {
                        TileList[j].TakeDamage();
                        BulletList[i].Destroy();
                    }
                }
            }
        }
    }
}
