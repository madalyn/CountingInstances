using System;

namespace CountingInstances.Shapes
{
    public class Rhombus
    {
        public Rhombus ()
        {
            InstanceTracker.GetInstance().TrackInstance(this);
        }
    }
}
