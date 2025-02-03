using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using monogamer.classes.components;
using monogamer.classes.objects;


namespace monogamer.classes.components
{
    public class AnimatableSpriteComp : Component
    {
        private ICharacter _character; // Reference to the character object
        private Texture2D _texture; // Texture containing the sprite sheet
        private int _rows; // Number of rows in the sprite sheet
        private int _columns; // Number of columns in the sprite sheet
        private SpriteBatch _spriteBatch; // SpriteBatch used for drawing
        private int _currentFrame; // Current frame of the animation
        private int _totalFrames; // Total number of frames in the sprite sheet
        private int _frameCount; // Number of frames in the animation
        private float _timePerFrame; // Time per frame based on animation speed
        private float _timeSinceLastFrame; // Time elapsed since the last frame change

        
        public string Name { get; set; } = nameof(AnimatableSpriteComp);

        private bool hasAdded = false;

        public AnimatableSpriteComp(ICharacter character, Texture2D texture, int rows, int columns, SpriteBatch spriteBatch, float animationSpeed, int frameCount)
        {
            // Create an instance of the functions class
            functions func = new functions();

            

            // Add the component name to the character's components list

            if (!hasAdded)
            {
                character.components = func.AddElementToArray(character.components, Name);
                hasAdded = true;
            }
            

            _character = character;
            _texture = texture;
            _rows = rows;
            _columns = columns;
            _spriteBatch = spriteBatch;
            _currentFrame = 0;
            _totalFrames = rows * columns;
            _frameCount = frameCount <= _totalFrames ? frameCount : _totalFrames;
            _timePerFrame = 1f / animationSpeed;
            _timeSinceLastFrame = 0f;
        }

        public void Update(GameTime gameTime)
        {
            // Update the time since the last frame
            _timeSinceLastFrame += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Check if it's time to advance to the next frame
            if (_timeSinceLastFrame >= _timePerFrame)
            {
                _currentFrame++;
                // Loop back to the first frame if we've reached the end
                if (_currentFrame >= _frameCount)
                {
                    _currentFrame = 0;
                }
                _timeSinceLastFrame = 0f;
            }
        }

        public void Draw()
        {
            // Calculate the width and height of a single frame
            int width = _texture.Width / _columns;
            int height = _texture.Height / _rows;
            // Determine the row and column of the current frame
            int row = _currentFrame / _columns;
            int column = _currentFrame % _columns;

            // Create source and destination rectangles for drawing
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)_character.Position.X, (int)_character.Position.Y, width, height);

            // Draw the current frame
            _spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    
    }