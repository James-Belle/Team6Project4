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
        Platform[] platforms = new Platform[12];
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(800, 600);

            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i] = new Platform(i);
            }
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.White);
            foreach (Platform platform in platforms)
            {
                platform.PlatformUpdate();
            }
        }
    }
}
