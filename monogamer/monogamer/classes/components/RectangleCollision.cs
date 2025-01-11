using System;
using System;
using Microsoft.Xna.Framework;
using monogamer.classes.objects;

namespace monogamer.classes.components
{
    public class RectangleCollision
    {
        public bool isCollided = false;

        public void addComponent(ICharacter character, ICharacter other, float size, float otherSize)
        {
            Vector2 position = character.Position;
            Vector2 otherPosition = other.Position;

            Rectangle collision = new Rectangle((int)position.X, (int)position.Y, (int)size * 10, (int)size * 10);
            Rectangle otherCollision = new Rectangle((int)otherPosition.X, (int)otherPosition.Y, (int)otherSize * 10, (int)otherSize * 10);

            if (collision.Intersects(otherCollision))
            {
                isCollided = true;
                Console.WriteLine("collided");
            }
            else
            {
                isCollided = false;
                Console.WriteLine("not collided");
            }
        }

        public bool getIsCollided()
        {
            return isCollided;
        }
    }
}