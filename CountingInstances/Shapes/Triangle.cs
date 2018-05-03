using System;
namespace CountingInstances.Shapes
{
    public class Triangle
    {
        public Triangle ()
        {
            InstanceTracker.GetInstance().TrackInstance(this);
        }
    }
}
