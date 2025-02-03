using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace monogamer.classes.objects
{
    public class staticSprite
    {
        // Indicates if the sprite position has been set
        private static bool _spritePositionSet = false;
        // Stores the position of the sprite
        private static Vector2 _spritePosition;

        // Property to get or set the sprite position
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

        // Name of the sprite
        public string name = "staticSprite";
        // Texture of the sprite
        public Texture2D sprite;
        // Layer depth of the sprite
        public float layerDepth = 0.0f;
        // Effects to apply to the sprite
        public SpriteEffects spriteEffects = SpriteEffects.None;
        // Size of the sprite
        public float size = 1;
        // Rotation of the sprite
        public float rotation;
        // Origin point of the sprite
        public Vector2 origin;
        // Color of the sprite
        public Color color = Color.Wheat;
        // Indicates if the sprite can collide
        public bool canCollide = false;
        // Debug mode flag
        private bool debug = false;
        // Font for debug text
        public SpriteFont debugFont;

        // Constructor to initialize the sprite position
        public staticSprite(Vector2 position)
        {
            SpritePosition = position;
        }

        // Method to draw the sprite
        public void draw(SpriteBatch _spritebatch)
        {
            _spritebatch.Draw(sprite, SpritePosition, null, color, rotation, origin, size, spriteEffects, layerDepth);
        }


        
    }
}