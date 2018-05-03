using System;

namespace CountingInstances.Shapes
{
    public class Circle
    {
        public Circle ()
        {
            InstanceTracker.GetInstance().TrackInstance(this);
        }
    }
}
