
using System;
using System.Numerics;

namespace Game10003
{
    public class Game
    {
        // Place your variables here:
        Vector2 CircleLoacation = new Vector2(200, 400);
        Vector2 LineSize = new Vector2(50, 120);
        Vector2 CircleLastPosition;
        public float x = 120;
        public float y = 100;
        public float radius = 170;
        public float CircleCenterX = 120;
        public float CircleCenterY = 100;
        public float Circleradius = 170;

        Player player = new Player();

        Platform[] platforms = new Platform[24];
        public Vector2 position;
        public Vector2 velocity;
        Vector2 gravity = new Vector2(0, +10);
        Vector2 playerposition = new Vector2(100, 100);

        Texture2D texture;
        Color Svelt = new Color(22, 14, 0, 255);
        Color Pink = new Color(255, 195, 233, 255);
        Color Brick = new Color(110, 40, 0, 200);

        public void Setup()
        {
            Window.SetTitle("Load Asset Example");
            Window.SetSize(400, 400);

            string cwd = System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine(cwd);

            string filePath = "\"C:\\Users\\User\\Documents\\Brick Background.png\"";
            texture = Graphics.LoadTexture(filePath);

            Window.SetTitle ("Rise up");
            Window.SetSize(800, 600);
            Window.TargetFPS = (45);
            for (int i = 0; i < platforms.Length/2; i++)
            {
                platforms[i] = new Platform(i); // initializes the platforms and makes sure they are offset
                platforms[i+platforms.Length / 2] = new Platform(i); // makes it so there are 2 platforms on each y level
            }
            //player positions being set
            player.position.X = 350;
            player.position.Y = 250;
            player.bottomSide = 50;
        }

        public void SimGrav()
        {
            Vector2 gravityForce = gravity * Time.DeltaTime;
            velocity += gravityForce;
            position += velocity;
        }
      
        public void Update()
        {
            if (player.bottomSide < 600) // this checks if player is still onscreen
            {
                Window.ClearBackground(Color.Blue);

                Circle();

                x = 640;
                y = 485;
                radius = 50;
                Draw.Circle(x, y, radius);

                x = 510;
                y = 485;
                radius = 50;
                Draw.Circle(x, y, radius);

                x = 380;
                y = 485;
                radius = 50;
                Draw.Circle(x, y, radius);

                x = 250;
                y = 485;
                radius = 50;
                Draw.Circle(x, y, radius);

                x = 125;
                y = 485;
                radius = 50;
                Draw.Circle(x, y, radius);

                x = 640;
                y = 360;
                radius = 50;
                Draw.Circle(x, y, radius);

                x = 510;
                y = 360;
                radius = 50;
                Draw.Circle(x, y, radius);

                x = 380;
                y = 360;
                radius = 50;
                Draw.Circle(x, y, radius);

                x = 250;
                y = 360;
                radius = 50;
                Draw.Circle(x, y, radius);

                x = 125;
                y = 360;
                radius = 50;
                Draw.Circle(x, y, radius);

                x = 640;
                y = 230;
                radius = 50;
                Draw.Circle(x, y, radius);

                x = 510;
                y = 230;
                radius = 50;
                Draw.Circle(x, y, radius);

                x = 380;
                y = 230;
                radius = 50;
                Draw.Circle(x, y, radius);

                x = 250;
                y = 230;
                radius = 50;
                Draw.Circle(x, y, radius);

                x = 122;
                y = 230;
                radius = 50;
                Draw.Circle(x, y, radius);

                x = 640;
                y = 100;
                radius = 50;
                Draw.Circle(x, y, radius);

                x = 510;
                y = 100;
                radius = 50;
                Draw.Circle(x, y, radius);

                x = 380;
                y = 100;
                radius = 50;
                Draw.Circle(x, y, radius);

                x = 120;
                y = 100;
                radius = 50;
                Draw.Circle(x, y, radius);

                x = 250;
                y = 100;
                radius = 50;

                Draw.Circle(x, y, radius);

                Graphics.Draw(texture, 10, 10);

                bool isTouchingPlatform = false; // this resets the collision check every frame
                foreach (Platform platform in platforms)
                {
                    isTouchingPlatform = platform.PlatformUpdate(playerposition) || isTouchingPlatform; // if any of the platforms are touching the player this bool will be true
                }
                if (isTouchingPlatform)
                {
                    //player.position.Y = player.lastPosition.Y;
                    if (player.velocity.Y > 0)
                    {
                        player.isInAir = false;
                        player.velocity.Y = 0;
                    }
                }
                Draw.FillColor = Svelt;
                Draw.LineColor = Color.Black;
                Draw.Rectangle(playerposition, gravity);

                player.lastPosition = player.position;
                player.drawPlayer();
                player.playerControl();

                playerposition = player.position;
            }

            if (player.bottomSide >= 600 ) // game over happens when player falls below zero
            {
                Window.ClearBackground(Brick);
                Text.Draw("Game over! \n\nRestart: press 'r' key", 300, 250);
                if (Input.IsKeyboardKeyDown(KeyboardInput.R)) { // reset variables to restart game
                    Setup();
                }
            }
        }

        public void Circle()
        {
            Draw.FillColor = Color.OffWhite;
            Draw.LineColor = Color.Black;
            Draw.LineSize = 4;
        }
    }
}
