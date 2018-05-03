using System;
using System.Collections.Generic;
using System.Linq;

namespace CountingInstances
{
    /// <summary>
    /// A class that provides the functionality to count instances of itself as they are created.
    /// Classes that extend Countable inherit the ability to be "countable" themselves.
    /// </summary>
    public class Countable
    {
        // all of the refrence objects that are the instances of this class
        //static IList<WeakReference> instances2 = new List<WeakReference>();
        static IDictionary<Type, IList<WeakReference>> instances = new Dictionary<Type, IList<WeakReference>>();

        private Countable()
        {
        }

        /// <summary>
        /// The number of all instances ever instantiated.
        /// </summary>
        /// <value>Count of the instances</value>
        //public static int Instances { get { return instances2.Count; } }

        /// <summary>
        /// The number of the instances that are still alive (aka: those still referenced).
        /// </summary>
        /// <value>Count of the alive instances</value>
        //public static int AliveInstances { get { return (instances2.Where(x => x.IsAlive)).Count(); } }

        // every time a new instance is created, update instance tracking
        public static void TrackInstance (Object instance)
        {
            Type instanceType = instance.GetType();

            if (instances.ContainsKey(instanceType)) {
                instances[instanceType].Add(new WeakReference(instance));
            } else {
                instances.Add(instanceType, new List<WeakReference> { new WeakReference(instance) });
            }
        }

        public static int CountInstances (Type instanceType, bool onlyAliveInstances=false)
        {
            // if no instances
            if (!instances.ContainsKey(instanceType)) {
                return 0;
            }

            if (onlyAliveInstances) {
                return (instances[instanceType].Where(x => x.IsAlive)).Count();
            }

            return instances[instanceType].Count;
        }
    }
}
