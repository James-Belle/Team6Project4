using System;
using System.Numerics;

namespace Game10003
{
    public class Player
    {
        //players variables
        public Vector2 position;
        public Vector2 lastPosition;
        public int sideLength;
        public Vector2 velocity;
        public Vector2 gravity = new Vector2(0, +15);
        public Vector2 gravityForce;
        public Vector2 jumpHeight;
        public float speed;
        //player square's sides
        public void drawPlayer()
        {
            Draw.FillColor = Color.Red;
            Draw.Square(position, sideLength);
            //player's gravity
            gravityForce = gravity * Time.DeltaTime;
            velocity += gravityForce;
            position += velocity;
            //constrain to bottom of screen
            if (position.Y > 750)
            {
                position.Y = lastPosition.Y;
                velocity.Y = 0;
            }
        }

        public void playerControl()
        {
            //player's input
            if (Input.IsKeyboardKeyDown(KeyboardInput.Left))
            {
                position.X -= speed * Time.DeltaTime;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.Right))
            {
                position.X += speed * Time.DeltaTime;
            }
            if (velocity.Y == 0)
            {
                if (Input.IsKeyboardKeyDown(KeyboardInput.Up))
                {
                    velocity = velocity - jumpHeight;
                }
            }
            
        }
    }
}
