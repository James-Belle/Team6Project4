using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Game10003
{
	public class Platform
	{
		Vector2 position = Vector2.Zero; // position of the platform
        Vector2 size = new Vector2(120, 20);
		float originPosition; // position the platforms will return to
        float speed = (float)1; // platform speed.
		int fadeTimer = 255; // tracks how faded the platform is
        int yOffset = 0;
        bool isTouched = false; // if the platform is touched by the player it starts fading.
        bool isTouchedRightNow = false;
		Color platGrey = new Color(90, 90, 90, 255); // colour of the platforms unfortunantly first three numbers can be changes, last one is occupacity
        public Platform(int Offset)
		{
			yOffset = Offset; // inputs the y offset for each platform
			position.Y = Window.Height - yOffset * 100; // sets their inistial position
			originPosition = 0 - Window.Height; // sets the position they will return to when they reach the bottom of the screen.
            position.X = Random.Integer((int)size.X, Window.Width - (int)size.X); // random x position
        }
		public bool PlatformUpdate(Vector2 playerPosition)
		{
			isTouchedRightNow = false; // resets the detection each frame
            position.Y += speed; // sends down the platform
            platGrey = new Color(90, 90, 90, fadeTimer); //first three numbers can be changes, just not the variable
            if (isTouched)
            { // once the platform has been touched is will start to fade.
                fadeTimer--;
            }
            if (position.Y > Window.Height+20)
            { // respawns when they get bellow screen
				Spawn();
            }
			if (fadeTimer > 0)
			{ // once they are invisible they still decend so that the platforms loop smoothly
				Hitbox(playerPosition); // replace with character position.
			}
			DrawPlatform();
			return isTouchedRightNow; // returns if the platform is being touched
        }
		public void Spawn()
		{ // this re-spawns in the platform
            position.X = Random.Integer((int)size.X, Window.Width - (int)size.X);
			position.Y = originPosition;
            fadeTimer = 255;
            isTouched = false;
        }
		public void DrawPlatform()
		{ // draws the platform
			Draw.FillColor = platGrey;
			Draw.LineColor = platGrey;
			Draw.Rectangle(position, size);
		}
		public void Hitbox(Vector2 playerPosition)
		{ // this checks if the player is touching the platform
            bool leftOf = playerPosition.X < position.X;
            bool rightOf = playerPosition.X > position.X + size.X;
            bool above = playerPosition.Y < position.Y;
            bool below = playerPosition.Y > position.Y + size.Y;
            if (!above && !below && !leftOf && !rightOf)
            {
                isTouched = true; //fading
				isTouchedRightNow = true; // current detection
            }
        }
	}
}
