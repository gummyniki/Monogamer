using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monogamer.classes;

namespace monogamer.classes.components
{
    public class RigidBodyComp : Component
    {

        public string Name { get; set; } = nameof(RigidBodyComp);

        private bool hasAdded = false;

        public void addComponent(ICharacter character, bool canFall, float minFallSpeed, float maxFallSpeed, float accelerationAmount)
        {

            // Create an instance of the functions class
            functions func = new functions();

            

            // Add the component name to the character's components list

            if (!hasAdded)
            {
                character.components = func.AddElementToArray(character.components, Name);
                hasAdded = true;
            }


            float acceleration = 0;



            if (!canFall) return;
            else
            {


                minFallSpeed += acceleration;

                acceleration += accelerationAmount;


                var position = character.Position;
                position.Y += acceleration;
                character.Position = position;
            }
        }

       
    }
}

    
    
