using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// Interface for character objects
public interface ICharacter
{
    Vector2 Position { get; set; } // Property for character position

    Rectangle collsion { get; set; } // Property for character collision rectangle
    void Draw(SpriteBatch spriteBatch); // Method to draw the character
}

// Class for moveable sprites implementing ICharacter interface
public class moveableSprite : ICharacter
{
    public Rectangle collision; // Collision rectangle for the sprite
    public string name = "staticSprite"; // Name of the sprite
    public Texture2D sprite; // Texture of the sprite
    public Vector2 position = new Vector2(50, 50); // Initial position of the sprite
    public float layerDepth = 0.0f; // Layer depth for drawing order
    public SpriteEffects spriteEffects = SpriteEffects.None; // Sprite effects (e.g., flipping)
    public float size = 3; // Size of the sprite
    public float rotation; // Rotation of the sprite
    public Vector2 origin; // Origin point for rotation and scaling
    public Color color = Color.Wheat; // Color tint of the sprite

    private bool debug = false; // Debug mode flag
    public SpriteFont debugFont; // Font for debug text

    // Property for sprite position
    public Vector2 Position
    {
        get => position;
        set => position = value;
    }

    // Explicit interface implementation for collision property
    Rectangle ICharacter.collsion
    {
        get => collision;
        set => collision = value;
    }

    // Method to draw the sprite
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(sprite, position, null, color, rotation, origin, size, spriteEffects, layerDepth);
    }

    // Method to activate debug mode and draw debug information
    public void activateDebug(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(debugFont, name + "\n" + position + "\n", position + new Vector2(0, -50), Color.Black);
    }
}

// Similarly, implement ICharacter for other character types like "text"

