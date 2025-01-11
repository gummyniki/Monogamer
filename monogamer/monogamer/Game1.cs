using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using monogamer.classes;
using monogamer.classes.components;
using monogamer.classes.objects;
using System;
using System.Collections.Generic;

namespace monogamer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        // Create instances of moveableSprite and Text
        moveableSprite ball = new moveableSprite();
        moveableSprite ball2 = new moveableSprite();
        moveableSprite ball3 = new moveableSprite();
        Text text = new Text();

        ICharacter[] others;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            // Load ball texture and set initial properties
            ball.sprite = Content.Load<Texture2D>("ball");
            ball.position = new Vector2(100, 100);
            ball.size = 1;
            ball.debugFont = Content.Load<SpriteFont>("testFont");

            // Define colliders for ball
            ball.Colliders = new List<Rectangle>
                {
                    new Rectangle((int)ball.position.X, (int)ball.position.Y, 50, 50),
                    new Rectangle((int)ball.position.X + 50, (int)ball.position.Y + 50, 50, 50)
                };

            // Load ball2 texture and set initial properties
            ball2.sprite = Content.Load<Texture2D>("ball");
            ball2.position = new Vector2(200, 200);
            ball2.size = 1;
            ball2.debugFont = Content.Load<SpriteFont>("testFont");

            // Define colliders for ball2
            ball2.Colliders = new List<Rectangle>
                {
                    new Rectangle((int)ball2.position.X, (int)ball2.position.Y, 50, 50)
                };

            // Load ball3 texture and set initial properties
            ball3.sprite = Content.Load<Texture2D>("ball");
            ball3.position = new Vector2(300, 300);
            ball3.size = 1;
            ball3.debugFont = Content.Load<SpriteFont>("testFont");

            // Define colliders for ball3
            ball3.Colliders = new List<Rectangle>
                {
                    new Rectangle((int)ball3.position.X, (int)ball3.position.Y, 50, 50)
                };

            // Load text font and set initial properties
            text.font = Content.Load<SpriteFont>("testFont");
            text.Position = new Vector2(250, 250);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            // Get the current state of the keyboard
            KeyboardState state = Keyboard.GetState();
            // Exit the game if the Back button on the gamepad or the Escape key on the keyboard is pressed
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Create a new top-down movement component with a speed of 5
            topDownMovementComp movementComp = new topDownMovementComp(5);

            // Add the ball to the movement component
            movementComp.addComponent(ball);

            // Update colliders based on the new position (added 55 to the sizes because the initial sizes are too small)
            ball.Colliders[0] = new Rectangle((int)ball.position.X, (int)ball.position.Y, (int)ball2.size + 55, (int)ball2.size + 55);
            ball.Colliders[1] = new Rectangle((int)ball.position.X, (int)ball.position.Y, (int)ball3.size + 55, (int)ball3.size + 55);

            // Define other characters for collision detection
            others = new ICharacter[] { ball2, ball3 };

            // Create collision components for ball and ball2
            RectangleCollision ballCollision = new RectangleCollision();
            ballCollision.addComponent(ball, others);

            // Check for collision and update text accordingly
            bool iscollided = ballCollision.getIsCollided();
            if (iscollided)
            {
                text.textString = "collided";
            }
            else
            {
                text.textString = "not collided";
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Clear the screen with a blue color
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // Draw ball and activate debug mode
            ball.Draw(_spriteBatch);
            ball.activateDebug(_spriteBatch);

            // Draw ball2 and activate debug mode
            ball2.Draw(_spriteBatch);
            ball2.activateDebug(_spriteBatch);

            // Draw ball3 and activate debug mode
            ball3.Draw(_spriteBatch);
            ball3.activateDebug(_spriteBatch);

            // Draw text
            text.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}