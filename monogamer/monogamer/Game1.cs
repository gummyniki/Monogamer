using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using monogamer.classes;
using monogamer.classes.components;
using monogamer.classes.objects;
using System;


namespace monogamer
{

    

public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        moveableSprite ball = new moveableSprite();
        moveableSprite ball2 = new moveableSprite();
        Text text = new Text();

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

            // Load ball2 texture and set initial properties
            ball2.sprite = Content.Load<Texture2D>("ball");
            ball2.position = new Vector2(200, 200);
            ball2.size = 1;
            ball2.debugFont = Content.Load<SpriteFont>("testFont");

            // Load text font and set initial properties
            text.font = Content.Load<SpriteFont>("testFont");
            text.Position = new Vector2(200, 200);
            text.textString = "yo this is some crazy text";
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // Draw ball and activate debug mode
            ball.Draw(_spriteBatch);
            ball.activateDebug(_spriteBatch);

            // Draw ball2 and activate debug mode
            ball2.Draw(_spriteBatch);
            ball2.activateDebug(_spriteBatch);

            // Draw text
            text.Draw(_spriteBatch);

            // Create movement component and add ball to it
            topDownMovementComp movementComp = new topDownMovementComp(5);
            movementComp.addComponent(ball);

            // Create collision components for ball and ball2
            RectangleCollision ballCollision = new RectangleCollision();
            RectangleCollision ball2Collision = new RectangleCollision();

            // Add ball and ball2 to collision detection
            ballCollision.addComponent(ball, ball2, ball.size + 5, ball2.size + 5);

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

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
