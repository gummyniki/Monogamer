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
           
            // TODO: Add your initialization logic here

            base.Initialize();

            ball.sprite = Content.Load<Texture2D>("ball");
            ball.position = new Vector2(100, 100);
            ball.size = 1;
            ball.debugFont = Content.Load<SpriteFont>("testFont");

            
            ball2.sprite = Content.Load<Texture2D>("ball");
            ball2.position = new Vector2(200, 200);
            ball2.size = 1;
            ball2.debugFont = Content.Load<SpriteFont>("testFont");

            

            text.font = Content.Load<SpriteFont>("testFont");
            text.Position = new Vector2(200, 200);

            text.textString = "yo this is some crazy text";

            

            


        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            

            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            ball.Draw(_spriteBatch);
            ball.activateDebug(_spriteBatch);
            ball2.Draw(_spriteBatch);
            ball2.activateDebug(_spriteBatch);
            text.Draw(_spriteBatch);

            topDownMovementComp movementComp = new topDownMovementComp(5);

            movementComp.addComponent(ball);

            RectangleCollision ballCollision = new RectangleCollision();

            RectangleCollision ball2Collision = new RectangleCollision();

            ballCollision.addComponent(ball, ball2, ball.size + 5, ball2.size + 5);

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



            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        
    }
}
