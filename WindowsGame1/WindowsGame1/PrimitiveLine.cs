using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    class PrimitiveLine//specifically for drawing; no length, no angle
    {
        private RefVector2 start;
        public RefVector2 Start
        {
            get { return Start; }
            set { Start = value; }
        }
        private RefVector2 end;
        public RefVector2 End
        {
            get { return end; }
            set { end = value; }
        }


        public PrimitiveLine(RefVector2 start, RefVector2 end) {

            this.start = start;
            this.end = end;
        
        }

    }
}
