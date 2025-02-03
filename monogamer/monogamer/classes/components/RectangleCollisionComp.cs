using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace monogamer.classes.components
{
    public class RectangleCollisionComp : Component
    {

        public string Name { get; set; } = nameof(RectangleCollisionComp);

        // Flag to indicate if a collision has occurred
        public bool isCollided = false;

        private bool hasAdded = false;

        // Method to add a collision component to a character
        public void addComponent(ICharacter character, ICharacter[] others)
        {
            // Create an instance of the functions class
            functions func = new functions();

            

            // Add the component name to the character's components list

            if (!hasAdded)
            {
                character.components = func.AddElementToArray(character.components, Name);
                hasAdded = true;
            }

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

        // Implementing the interface method
        
    }
}