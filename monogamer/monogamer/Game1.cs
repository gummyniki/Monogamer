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

        moveableSprite ball = new moveableSprite();
        moveableSprite ball2 = new moveableSprite();
        moveableSprite ball3 = new moveableSprite();
        Text text = new Text();

        AnimatableSpriteComp ballAnimation;
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
            ball.name = "player";
            ball.sprite = Content.Load<Texture2D>("ball");
            ball.position = new Vector2(100, 100);
            ball.size = 1;
            ball.debugFont = Content.Load<SpriteFont>("testFont");

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

            ball2.Colliders = new List<Rectangle>
            {
                new Rectangle((int)ball2.position.X, (int)ball2.position.Y, 50, 50)
            };

            // Load ball3 texture and set initial properties
            ball3.sprite = Content.Load<Texture2D>("ball");
            ball3.position = new Vector2(300, 300);
            ball3.size = 1;
            ball3.debugFont = Content.Load<SpriteFont>("testFont");

            ball3.Colliders = new List<Rectangle>
            {
                new Rectangle((int)ball3.position.X, (int)ball3.position.Y, 50, 50)
            };

            // Load text font and set initial properties
            text.font = Content.Load<SpriteFont>("testFont");
            text.Position = new Vector2(200, 200);

            // Initialize animation component
            //Texture2D ballTexture = Content.Load<Texture2D>("ball_spritesheet");
            //ballAnimation = new AnimatableSpriteComp(ball, ballTexture, 1, 8, _spriteBatch, 10f, 8); // 1 row, 8 columns, 10 frames per second, 8 frames to play
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

            topDownMovementComp movementComp = new topDownMovementComp(5f);
            RigidBodyComp rigidBodyComp = new RigidBodyComp();
            rigidBodyComp.addComponent(ball3, true, 0.1f, 1, 0.05f);

            movementComp.addComponent(ball);

            // Update colliders based on the new position (increased the size by 55 because the current size is too small)
            ball.Colliders[0] = new Rectangle((int)ball.position.X, (int)ball.position.Y, (int)ball2.size + 55, (int)ball2.size + 55);
            ball.Colliders[1] = new Rectangle((int)ball.position.X, (int)ball.position.Y, (int)ball3.size + 55, (int)ball3.size + 55);

            ball3.Colliders[0] = new Rectangle((int)ball3.position.X, (int)ball3.position.Y, (int)ball3.size + 55, (int)ball3.size + 55);

            others = new ICharacter[] { ball2, ball3 };

            // Create collision components for ball and others
            RectangleCollisionComp ballCollision = new RectangleCollisionComp();
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

            //READ: Update animation (animation is not used in this example, but it's included for reference, to enable it, uncomment the code related to the animation component and delete "ball.sprite = Content.Load<Texture2D>("ball");" at the top)
            //ballAnimation.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // Draw ball animation
            //ballAnimation.Draw();


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
