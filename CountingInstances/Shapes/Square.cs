using System;
namespace CountingInstances.Shapes
{
    public class Square
    {
        public Square ()
        {
            Countable.TrackInstance (this);
            this.dummySquare ();
        }

        void dummySquare ()
        {
            var rhombus = new Rhombus ();
        }

        // creates five squares when called
        public void externalSquare ()
        {
            var square1 = new Square ();
            var square2 = new Square ();
            var square3 = new Square ();
            var square4 = new Square ();
            var square5 = new Square ();
        }
    }
}
    