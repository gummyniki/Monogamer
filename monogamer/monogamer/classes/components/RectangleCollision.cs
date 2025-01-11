using System;
using System;
using Microsoft.Xna.Framework;
using monogamer.classes.objects;

namespace monogamer.classes.components
{
    public class RectangleCollision
    {
        // Flag to indicate if a collision has occurred
        public bool isCollided = false;

        // Method to add a collision component to a character
        public void addComponent(ICharacter character, ICharacter other, float size, float otherSize)
        {
            // Get the positions of the characters
            Vector2 position = character.Position;
            Vector2 otherPosition = other.Position;

            // Create rectangles for collision detection based on character positions and sizes
            Rectangle collision = new Rectangle((int)position.X, (int)position.Y, (int)size * 10, (int)size * 10);
            Rectangle otherCollision = new Rectangle((int)otherPosition.X, (int)otherPosition.Y, (int)otherSize * 10, (int)otherSize * 10);

            // Check if the rectangles intersect (i.e., if a collision has occurred)
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

        // Method to get the collision status
        public bool getIsCollided()
        {
            return isCollided;
        }
    }
}