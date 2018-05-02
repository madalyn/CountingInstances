using System;
using System.Collections.Generic;
using System.Linq;

namespace CountingInstances
{
    /// <summary>
    /// A class that provides the functionality to count instances of itself as they are created.
    /// Classes that extend Countable inherit the ability to be "countable" themselves.
    /// </summary>
    public abstract class Countable
    {
        // all of the refrence objects that are the instances of this class
        static IList<WeakReference> instances = new List<WeakReference>();

        public Countable()
        {
            // every time a new instance is created, update instance tracking
            instances.Add(new WeakReference(this));
        }

        /// <summary>
        /// The number of all instances ever instantiated.
        /// </summary>
        /// <value>Count of the instances</value>
        public static int Instances { get { return instances.Count; } }

        /// <summary>
        /// The number of the instances that are still alive (aka: those still referenced).
        /// </summary>
        /// <value>Count of the alive instances</value>
        public static int AliveInstances { get { return (instances.Where(x => x.IsAlive)).Count(); } }
    }
}
