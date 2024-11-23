
using System;
using System.Numerics;

namespace Game10003
{
   
    public class Game
    {
        // Place your variables here:
        Platform[] platforms = new Platform[24];
        public Vector2 position;
        public Vector2 velocity;
        Vector2 gravity = new Vector2(0, +10);
        Vector2 playerposition = new Vector2(100, 100);

        Color Svelt = new Color(22, 14, 0, 255);
        Color Pink = new Color(255, 195, 233, 255);
        Color Brick = new Color(110, 40, 0, 200);

        public void Setup()
        {
            Window.SetTitle ("Rise up");
            Window.SetSize(800, 600);
            Window.TargetFPS = (45);
            for (int i = 0; i < platforms.Length/2; i++)
            {
                platforms[i] = new Platform(i); // initializes the platforms and makes sure they are offset
                platforms[i+platforms.Length / 2] = new Platform(i); // makes it so there are 2 platforms on each y level
            }
        }

        public void SimGrav()
        {
            Vector2 gravityForce = gravity * Time.DeltaTime;
            velocity += gravityForce;
            position += velocity;
        }
      
        public void Update()
        {
            Window.ClearBackground(Brick);

            bool isTouchingPlatform = false; // this resets the collision check every frame
            foreach (Platform platform in platforms)
            {
                isTouchingPlatform = platform.PlatformUpdate(playerposition) || isTouchingPlatform; // if any of the platforms are touching the player this bool will be true
            }

            Draw.FillColor = Svelt;
            Draw.LineColor = Color.Black;
            Draw.Rectangle(playerposition, gravity);
             
            
        }
    }
}
