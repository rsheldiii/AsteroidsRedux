using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    class AstObj
    {
        public Dictionary<string, Line> Lines = new Dictionary<string, Line>();//can now refer to lines by name. Can now construct a list of 2 strings to signify lines
        //TODO: currently public to get this code up faster. Should probably reassess
        public List<string[]> Connections = new List<string[]>();//defines connections between points defined by Lines
        public bool DEBUG = true;

        private Vector2 center;
        public Vector2 Center {
            get { return center; }
            set { center = value;
                    foreach (KeyValuePair<String, Line> entry in Lines)
                    {
                        entry.Value.Start = center;
                    }
                }
        }



        public AstObj(Vector2 center, int size, Dictionary<string, Line> Lines, List<string[]> connections, bool debug) {
            this.Center = center;
            this.DEBUG = debug;
            this.Lines = Lines;
            this.Connections = connections; 
        
        
        }

        public AstObj() {
        //base object. Seeing as almost all objects will have a predetermined shape, thus editing their own lines and connections directly, it seems silly to force them to pass to a super
        }


        public void update() { }

        public void Draw(GameTime gameTime, LineBatch batch)
        {
            for (int i = 0; i < Connections.Count; i++)
            {
                batch.DrawLine(1.0f, Color.White, Lines[Connections[i][0]].End, Lines[Connections[i][1]].End);//draws each connection in connections
            }



            if (DEBUG)
            {
                foreach (KeyValuePair<String, Line> entry in Lines)//draws debug lines to each point
                {
                    batch.DrawLine(1.0f, Color.Blue, entry.Value);
                }
            }
        }

    }
}
