using System;
namespace CountingInstances.Shapes
{
    public class Circle
    {
        public Circle ()
        {
            Countable.TrackInstance (this);
        }
    }
}
