﻿using System;
namespace CountingInstances.Shapes
{
    public class Rhombus
    {
        public Rhombus ()
        {
            Countable.TrackInstance (this);
        }
    }
}
