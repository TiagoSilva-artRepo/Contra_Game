using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace contra
{
    public class CollisionDetector
    {
        public bool PlayerInjured(Sprite player, Sprite enemyBullet)
        {

            if (player.Position.X - enemyBullet.Position.X > -3 && player.Position.X - enemyBullet.Position.X < 5 && enemyBullet.Position.Y < player.Rectangle.Bottom)
            {
                return true;
            }
            return false;
        }
    }
}
