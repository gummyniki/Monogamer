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
        // Method to add movement component to a character
        public void addComponent(ICharacter character)
        {
            // Get the current position of the character
            Microsoft.Xna.Framework.Vector2 position = character.Position;

            // Get the current state of the keyboard
            KeyboardState keyboard = Keyboard.GetState();

            // Check if the Up or W key is pressed
            if (keyboard.IsKeyDown(Keys.Up) || keyboard.IsKeyDown(Keys.W))
            {
                position.Y -= speed; // Move character up
            }

            // Check if the Down or S key is pressed
            if (keyboard.IsKeyDown(Keys.Down) || keyboard.IsKeyDown(Keys.S))
            {
                position.Y += speed; // Move character down
            }

            // Check if the Left or A key is pressed
            if (keyboard.IsKeyDown(Keys.Left) || keyboard.IsKeyDown(Keys.A))
            {
                position.X -= speed; // Move character left
            }

            // Check if the Right or D key is pressed
            if (keyboard.IsKeyDown(Keys.Right) || keyboard.IsKeyDown(Keys.D))
            {
                position.X += speed; // Move character right
            }

            // Update the position property of the ICharacter object
            character.Position = position;
        }
    }
}
