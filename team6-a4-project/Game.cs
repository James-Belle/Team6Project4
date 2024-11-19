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
        Player player = new Player();

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(600, 800);
            Window.SetTitle("Player test");
            //Player's default variables
            player.position = new Vector2(350, 450);
            player.sideLength = 50;
            player.speed = 400;
            player.jumpHeight = new Vector2(0, 12);
            player.lastPosition = new Vector2(0, 0);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.White);
            player.lastPosition = player.position;
            player.drawPlayer();
            player.playerControl();
        }
    }
}
