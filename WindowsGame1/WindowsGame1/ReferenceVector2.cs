using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    class RefVector2
    {
            public float X { get; set; }
            public float Y { get; set; }

            public RefVector2(Vector2 re)
            {
                X = re.X;
                Y = re.Y;
            }


            public RefVector2(float X, float Y)
            {
                this.X = X;
                this.Y = Y;
            }

            public RefVector2(RefVector2 copy) {
                X = copy.X;
                Y = copy.Y;
            }


            public static RefVector2 operator +(RefVector2 a, RefVector2 b) {
                return new RefVector2(a.X + b.X, a.Y + b.Y);
            }

            public static explicit operator Vector2(RefVector2 a) {

                return new Vector2(a.X, a.Y);
            }
    }

   
}
