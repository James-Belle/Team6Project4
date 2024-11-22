using System;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Numerics;
namespace Game10003
{
	public class Platform
	{
		Vector2 position = Vector2.Zero;
		bool isTouched = false; // if the platform is touched by the player it starts fading.
        bool isTouchedRightNow = true;
		Color platGrey = new Color(50, 255);
		int Timer = 255;
		float speed = (float)1;
		Vector2 size = new Vector2(120, 20);
		int yOffset = 0;
		float originPosition = 0;
		public Platform(int Offset)
		{
			yOffset = Offset;
			position.Y = Window.Height - yOffset * 100;
			originPosition = 0 - Window.Height;
            position.X = Random.Integer((int)size.X, Window.Width - (int)size.X);
        }
		public bool PlatformUpdate()
		{
            if (isTouched)
            {
                Timer--;
            }
			position.Y += speed;
            platGrey = new Color(50, Timer);
            if (position.Y > Window.Height+20)
            {
				Spawn();
            }
			if (Timer > 0)
			{
				Hitbox(Input.GetMousePosition()); // replace with character position.
			}
			DrawPlatform();
			return isTouchedRightNow;
        }
		public void Spawn()
		{ // this re-spawns in the platform
            position.X = Random.Integer((int)size.X, Window.Width - (int)size.X);
			position.Y = originPosition;
            Timer = 255;
            isTouched = false;
        }
		
		public void DrawPlatform()
		{
			Draw.FillColor = platGrey;
			Draw.LineColor = platGrey;
			Draw.Rectangle(position, size);
			
		}
		public void Hitbox(Vector2 playerPosition)
		{
            isTouchedRightNow = true;
            bool leftOf = playerPosition.X < position.X;
            bool rightOf = playerPosition.X > position.X + size.X;
            bool above = playerPosition.Y < position.Y;
            bool below = playerPosition.Y > position.Y + size.Y;
            if (!above && !below && !leftOf && !rightOf)
            {
                isTouched = true;
				isTouchedRightNow = true;

            }
        }
	}
}
