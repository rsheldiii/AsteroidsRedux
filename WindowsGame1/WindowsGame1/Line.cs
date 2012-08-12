using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    class Line
    {
        private Vector2 start;
        public Vector2 Start {
            get{return this.start;}
            set{this.start = value;}
        }
        private double length;
        public Double Length {
            get { return this.length; }
            set { this.length = value; }
        }
        private double angle;
        public double Angle {
            get { return angle;}
            set 
            { 
                this.angle = value;
                if (angle > 2 * Math.PI) {
                    angle -= 2 * Math.PI;
                }
                    }
        }

        public Vector2 End {//calculated end based off of above three pieces of information
            get { return new Vector2((float)(Math.Cos(this.angle) * this.length + start.X), (float)(Math.Sin(this.angle) * this.length + start.Y)); }
            set {
                this.length = Math.Pow(Math.Pow(start.X - value.X, 2) + Math.Pow(start.Y - value.Y, 2), .5);
                double adjacent =  value.X - this.start.X;
                double opposite = value.Y - this.start.Y;
                this.angle = Math.Atan2(opposite,adjacent);
            }
        }
            

        public Line(Vector2 start, double length, double angle) {
            //angle is in RADIANS MOTHERFUCKER DO YOU SPEAK THEM
            this.start = start;
            this.length = length;
            this.angle = angle;
        
        }

        public Line(Vector2 start, Vector2 end) {
            this.start = start;
            End = end;//fyeah
        }

        /*static public explicit operator Vector2(Line line) { //only problem: position, or magnitude?

            return new Vector2((float)line.lengthX(), (float)line.lengthY());
        
        }*/

        public double lengthX()
        {
            return Math.Cos(angle) * length;
        }
        public double lengthY()
        {
            return Math.Sin(angle) * length;
        }

        public void Compose(Line other) {

            double totalx = this.lengthX() + other.lengthX();
            double totaly = this.lengthY() + other.lengthY();


            this.End = this.start + new Vector2((float)totalx, (float)totaly);

        
        }
        
    }
}
