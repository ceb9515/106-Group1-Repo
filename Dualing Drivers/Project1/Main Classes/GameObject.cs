using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class GameObject : Object
    {
        Rectangle rectangle;

        public virtual void Draw(SpriteBatch sb)
        {

        }

        public void Move()
        {

        }

        public void Destroy()
        {

        }

        public bool IsColliding(Rectangle rectangle)
        {
            if(this.rectangle.IntersectsWith(rectangle))
            {
                return true;
            }
            else { return false; }
        }

        
    }
}
