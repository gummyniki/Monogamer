using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogamer.classes.objects
{
    public class Text
    {
        // Name of the text object
        public string name = "staticText";

        // The string to be displayed
        public string textString = "testString";

        // Rotation of the text
        public float rotation = 0.0f;

        // Layer depth for drawing order
        public float layerDepth = 0.0f;

        // Scale of the text
        public float scale = 1;

        // Font used to draw the text
        public SpriteFont font;

        // Position of the text
        public Vector2 position;

        // Property to get or set the position of the text
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        // Origin point of the text
        public Vector2 origin = Vector2.One;

        // Color of the text
        public Color color = Color.Wheat;

        // Sprite effects to apply to the text
        public SpriteEffects effect = SpriteEffects.None;

        // Debug flag
        public bool debug;

        // Method to draw the text using SpriteBatch
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, textString, Position, color, rotation, origin, scale, effect, layerDepth);
        }
    }
}
