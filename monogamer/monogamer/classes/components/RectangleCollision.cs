using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace monogamer.classes.components
{
    public class RectangleCollision
    {
        // Flag to indicate if a collision has occurred
        public bool isCollided = false;

        // Method to add a collision component to a character
        public void addComponent(ICharacter character, ICharacter[] others)
        {
            foreach (var collider in character.Colliders)
            {
                foreach (var other in others)
                {
                    foreach (var otherCollider in other.Colliders)
                    {
                        // Check if the rectangles intersect (i.e., if a collision has occurred)
                        if (collider.Intersects(otherCollider))
                        {
                            isCollided = true;
                            Console.WriteLine("collided");
                            return; // Exit early if a collision is detected
                        }
                    }
                }
            }

            isCollided = false;
            Console.WriteLine("not collided");
        }

        // Method to get the collision status
        public bool getIsCollided()
        {
            return isCollided;
        }
    }
}