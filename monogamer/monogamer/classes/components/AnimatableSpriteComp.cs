using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace monogamer.classes.components
{
    public class AnimatableSpriteComp
    {
        private ICharacter _character;
        private Texture2D _texture;
        private int _rows;
        private int _columns;
        private SpriteBatch _spriteBatch;
        private int _currentFrame;
        private int _totalFrames;
        private int _frameCount;
        private float _timePerFrame;
        private float _timeSinceLastFrame;

        public AnimatableSpriteComp(ICharacter character, Texture2D texture, int rows, int columns, SpriteBatch spriteBatch, float animationSpeed, int frameCount)
        {
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
            _timeSinceLastFrame += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timeSinceLastFrame >= _timePerFrame)
            {
                _currentFrame++;
                if (_currentFrame >= _frameCount)
                {
                    _currentFrame = 0;
                }
                _timeSinceLastFrame = 0f;
            }
        }

        public void Draw()
        {
            int width = _texture.Width / _columns;
            int height = _texture.Height / _rows;
            int row = _currentFrame / _columns;
            int column = _currentFrame % _columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)_character.Position.X, (int)_character.Position.Y, width, height);

            _spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}