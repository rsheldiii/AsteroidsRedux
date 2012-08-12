using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{

    /*
     * The Idea About AstObjs:
     * I want to bea able to draw lines but I also want to be able to rotate them.
     *  Theoretically I could store points and a central point to rotate around, but then whenever I rotated I would need to create line structures to the center, rotate the lines, then redraw the points.
     *  While storing points sounds like a great idea, you can do rotation via trigonometry one of two ways: you can make a line that's two points and find its angle, change the angle, and see where the point ends up, or you can make a line thats one point, an angle, and a length, change the angle, and recalculate the point. The former has rounding errors, the latter does not
     *  so I decided to go with the second option, which meant that I would need to create a line based off the angle and length every time, which means just expressing the code as lines makes more sense
     */
    class Ship : AstObj
    {
        const int SHIPSIZE = 25;
        
        private Line ThrustVector;

      
        

        public Ship(Vector2 center, int size) {
            this.Center = center;

            Lines.Add("front", new Line( center, new Vector2(center.X, center.Y + SHIPSIZE * size)));
            Lines.Add("right", new Line( center, SHIPSIZE*size*1.2, -(40 / 180.0) * Math.PI));
            Lines.Add("left",new Line( center,SHIPSIZE*size*1.2,-(140/180.0)*Math.PI));
            Lines.Add("back",new Line(center,new Vector2(center.X,(float)(center.Y - .3 * SHIPSIZE * size))));

            Connections.Add(new String[] { "front", "right" });
            Connections.Add(new String[] { "left", "back" });
            Connections.Add(new String[] { "right", "back" });
            Connections.Add(new String[] { "front", "left" });

            ThrustVector = new Line(center, center);
        
        
        }


        public void update() {
            
            this.incCenter( new Vector2((float)ThrustVector.lengthX(), (float)ThrustVector.lengthY()));
            ThrustVector.Start = this.Center;//to easier display thrustvector

            /*foreach (KeyValuePair<String, Line> entry in Lines)
            {
                //entry.Value.Start += new Vector2((float)ThrustVector.lengthX(), (float)ThrustVector.lengthY());//this REALLY should be a reference
            }*/


        }

        public void incCenter(Vector2 inc) {
            this.Center += inc;
            foreach (KeyValuePair<String, Line> entry in Lines)
            {
                entry.Value.Start = this.Center;
            }
        }

        public void increaseThrust(double magnitude) {

            ThrustVector.Compose(new Line(this.Center,magnitude,Lines["front"].Angle));//using the front line's angle to add thrust of magnitude 'magnitude' to the thrust vector using compose
        
        }

        public void decreaseThrust(double magnitude)
        {

            ThrustVector.Compose(new Line(this.Center, magnitude, Lines["back"].Angle));

        }


        public void Draw(GameTime gameTime, LineBatch batch) {
            for (int i = 0; i < Connections.Count; i++) {
                batch.DrawLine(1.0f, Color.White, Lines[Connections[i][0]].End, Lines[Connections[i][1]].End);//draws each connection in connections
            }


            batch.DrawLine(1.0f, Color.Red, ThrustVector);

            if (DEBUG)
            {
                foreach (KeyValuePair<String, Line> entry in Lines)//draws debug lines to each point
                {
                    batch.DrawLine(1.0f, Color.Blue, entry.Value);
                }
            }
        }




        public void rotate(double radii) {

            foreach (KeyValuePair<String, Line> entry in Lines)
            {
                entry.Value.Angle += radii;
            }
        
        }


    }
}
