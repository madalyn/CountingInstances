﻿using System;
namespace CountingInstances.Shapes
{
    public class Triangle
    {
        public Triangle ()
        {
            Countable.TrackInstance (this);
        }
    }
}
