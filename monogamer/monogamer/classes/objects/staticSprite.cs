using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace monogamer.classes.objects
{
    public class staticSprite
    {
        private static bool _spritePositionSet = false;
        private static Vector2 _spritePosition;
        public static Vector2 SpritePosition
        {
            get => _spritePosition;
            set
            {
                if (!_spritePositionSet)
                {
                    _spritePosition = value;
                    _spritePositionSet = true;
                }
                else
                {
                    throw new InvalidOperationException("SpritePosition can only be set once.");
                }
            }
        }

        public string name = "staticSprite";
        public Texture2D sprite;
        public float layerDepth = 0.0f;
        public SpriteEffects spriteEffects = SpriteEffects.None;
        public float size = 1;
        public float rotation;
        public Vector2 origin;
        public Color color = Color.Wheat;
        public bool canCollide = false;
        private bool debug = false;
        public SpriteFont debugFont;

        public staticSprite(Vector2 position)
        {
            SpritePosition = position;
        }

        public void draw(SpriteBatch _spritebatch)
        {
            _spritebatch.Draw(sprite, SpritePosition, null, color, rotation, origin, size, spriteEffects, layerDepth);

            
            
                
            
        }

        public void activateDebug(SpriteBatch spriteBatch) // run the function in your game loop to activate debug mode
        {
            if (debug)
            {
                spriteBatch.DrawString(debugFont, name + "\n" + SpritePosition + "\n", SpritePosition + new Vector2(0, -50), Color.Black);
            }
        }
    }
}