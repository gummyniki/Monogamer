using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//READ: remember to start the spritebatch in your main file, otherwise the class will NOT work!

public interface ICharacter
{
    Vector2 Position { get; set; }

    Rectangle collsion { get; set; }
    void Draw(SpriteBatch spriteBatch);
}

public class moveableSprite : ICharacter
{
    public Rectangle collision;
    public string name = "staticSprite";
    public Texture2D sprite;
    public Vector2 position = new Vector2(50, 50);
    public float layerDepth = 0.0f;
    public SpriteEffects spriteEffects = SpriteEffects.None;
    public float size = 3;
    public float rotation;
    public Vector2 origin;
    public Color color = Color.Wheat;

    private bool debug = false;
    public SpriteFont debugFont;

    

    public Vector2 Position
    {
        get => position;
        set => position = value;
    }

    Rectangle ICharacter.collsion
    {
        get => collision;
        set => collision = value;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(sprite, position, null, color, rotation, origin, size, spriteEffects, layerDepth);
    }

    public void activateDebug(SpriteBatch spriteBatch) // run the function in your game loop to activate debug mode
    {
        
            spriteBatch.DrawString(debugFont, name + "\n" + position + "\n" , position + new Vector2(0, -50), Color.Black);
        
    }
    

}

// Similarly, implement ICharacter for other character types like "text"

