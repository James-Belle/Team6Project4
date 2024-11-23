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
        Platform[] platforms = new Platform[24];
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            for (int i = 0; i < platforms.Length/2; i++)
            {
                platforms[i] = new Platform(i); // initializes the platforms and makes sure they are offset
                platforms[i+platforms.Length / 2] = new Platform(i); // makes it so there are 2 platforms on each y level
            }
        }
        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            bool isTouchingPlatform = false; // this resets the collision check every frame
            foreach (Platform platform in platforms)
            { // if any of the platforms are touching the player this bool will be true
                isTouchingPlatform = platform.PlatformUpdate(Input.GetMousePosition()) || isTouchingPlatform; // replace with player position
            }
        }
    }
}
