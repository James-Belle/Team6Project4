using System;
using System.Diagnostics.Metrics;
using System.Numerics;
namespace Game10003
{
	public class Platform
	{
		Vector2 position;
		bool isTouched = false;
		Color platGrey = new Color(50, 255);
		int Timer = 255;
		public Platform()
		{
			position.X = Random.Integer(50, Window.Width - 50);
			position.Y = 120;
		}

		public void Spawn()
		{
			
		}
		public void DrawPlatform()
		{
            if (isTouched)
            {
                Timer -= 2;
            }
            platGrey = new Color(50, Timer);
            if (Timer < 0)
            {
				isTouched = false;
                Timer = 255;
            }
            Vector2 size = new Vector2(100, 20);
			Draw.FillColor = platGrey;
			Draw.LineColor = platGrey;
			Draw.Rectangle(position, size);
			
		}
		public void Hitbox(Vector2 playerPosition)
		{
			bool left = playerPosition.X < position.X;
            bool right = playerPosition.X > position.X + 100;

            bool above = playerPosition.Y < position.Y;
            bool below = playerPosition.Y > position.Y + 20;
			if (above && below)
			{
				Draw.FillColor = Color.Blue;
			}
			if (above)
			{
				Draw.FillColor = Color.Green;
			}
			else if (below) 
			{
				Draw.FillColor = Color.Red;
			}
			else
			{
				Draw.FillColor = Color.Black;
			}
			if (left && right)
			{
				Draw.LineColor = Color.Blue;
			}
            if (left)
            {
                Draw.LineColor = Color.Green;
            }
            else if (right)
            {
                Draw.LineColor = Color.Red;
            }
            else
            {
                Draw.LineColor = Color.Black;
            }

			if (!above && !below && !left && !right)
			{
				isTouched = true;
			}
            Draw.Circle(position, 20);
            
            
			

        }
	}
}
