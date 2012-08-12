using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    class LineBatch : SpriteBatch
    {
        private Texture2D blank;

        public LineBatch(GraphicsDevice device, Texture2D blank) : base(device) {
            this.blank = blank;
        }



        public void DrawLine(float width, Color color, Vector2 point1, Vector2 point2)
        {
            float angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            float length = Vector2.Distance(point1, point2);

            this.Draw(blank, point1, null, color,
                       angle, Vector2.Zero, new Vector2(length, width),
                       SpriteEffects.None, 0);
        }


        public void DrawLine(float width, Color color, Line line)
        {
            float angle = (float)Math.Atan2(line.End.Y - line.Start.Y, line.End.X - line.Start.X);
            float length = (float)line.Length;

            this.Draw(blank, line.Start, null, color,
                       angle, Vector2.Zero, new Vector2(length, width),
                       SpriteEffects.None, 0);
        }
    }
}
