using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monogamer.classes.components
{
    public class RigidBodyComp
    {
        public void addComponent(ICharacter character, bool canFall, float minFallSpeed, float maxFallSpeed, float acceleration)
        {
            

            

            if (!canFall) return;
            else
            {


                minFallSpeed += acceleration;   

                acceleration += 0.1f;


                var position = character.Position;
                position.Y += minFallSpeed;
                character.Position = position;
            }
        }
    }
}
