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
        public string name = "staticText";
        public string textString = "testString";
        public float rotation = 0.0f;
        public float layerDepth = 0.0f;
        public float scale = 1;
        public SpriteFont font;
        public Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }


        

       

        public Vector2 origin = Vector2.One;
        public Color color = Color.Wheat;
        public SpriteEffects effect = SpriteEffects.None;
        public bool debug;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, textString, Position, color, rotation, origin, scale, effect, layerDepth);
        }
    }
}
