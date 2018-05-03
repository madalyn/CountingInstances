using System;
namespace CountingInstances.Shapes
{
    public class Square
    {
        public Square()
        {
            Countable.TrackInstance(this);
        }
    }
}
    