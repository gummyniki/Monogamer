using monogamer.classes.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace monogamer.classes.components
{
    public class topDownMovementComp(float speed)
    {
        

        public void addComponent(ICharacter character)
        {
            Microsoft.Xna.Framework.Vector2 position = character.Position;

            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Up) || keyboard.IsKeyDown(Keys.W))
            {
                position.Y -= speed;
            }

            if (keyboard.IsKeyDown(Keys.Down) || keyboard.IsKeyDown(Keys.S))
            {

                position.Y += speed;
            }

            if (keyboard.IsKeyDown(Keys.Left) || keyboard.IsKeyDown(Keys.A))
            {
                position.X -= speed;
            }

            if (keyboard.IsKeyDown(Keys.Right) || keyboard.IsKeyDown(Keys.D))
            {

                position.X += speed;
            }

            character.Position = position; // Update the position property of the ICharacter object

        }
        
        


    }
}
