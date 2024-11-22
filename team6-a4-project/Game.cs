// Include code libraries you need below (use the namespace).
using System;
using System.Numerics;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Platform[] platforms = new Platform[1];
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(800, 600);

            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i] = new Platform();
            }
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.White);
            if (Input.IsMouseButtonDown(MouseInput.Left))
            {
                foreach (Platform platform in platforms)
                {
                    platform.Hitbox(Input.GetMousePosition());
                }
            }
            foreach (Platform platform in platforms)
            {
                platform.DrawPlatform();
            }
        }
    }
}
