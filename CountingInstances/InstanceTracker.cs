using System;
using System.Collections.Generic;
using System.Linq;

namespace CountingInstances
{
    /// <summary>
    /// A singleton that provides the functionality to track instances of classes as they are created.
    /// </summary>
    public class InstanceTracker
    {
        static InstanceTracker instanceTrackerInstance;

        // A store for tracking all of the instances per each type of class
        static IDictionary<Type, IList<WeakReference>> instances = new Dictionary<Type, IList<WeakReference>> ();

        InstanceTracker ()
        {
            // singleton class constructor
        }

        public static InstanceTracker GetInstance ()
        {
            if (instanceTrackerInstance == null) {
                instanceTrackerInstance = new InstanceTracker();
            }

            return instanceTrackerInstance;
        }

        /// <summary>
        /// Every time a new instance is created, update instance tracking.
        /// This function should go in the constructor of every class desired to include instance tracking.
        /// </summary>
        /// <param name="instance">The new instance just created that needs to be tracked.</param>
        public void TrackInstance (Object instance)
        {
            Type instanceType = instance.GetType ();

            if (instances.ContainsKey (instanceType)) {
                instances[instanceType].Add (new WeakReference (instance));
            } else {
                instances.Add(instanceType, new List<WeakReference> { new WeakReference (instance) });
            }
        }

        /// <summary>
        /// Counts the number of instances of a class.
        /// </summary>
        /// <returns>
        /// Defaults to return the number of all instances ever instantiated.
        /// If onlyAliveInstances is set to <c>true</c>, only return a count of the alive (non garbage collected) instances.
        /// </returns>
        /// <param name="instanceType">The type of the class for which to count the number of instances of.</param>
        /// <param name="onlyAliveInstances">If set to <c>true</c> only count the alive instances.</param>
        public int CountInstances (Type instanceType, bool onlyAliveInstances=false)
        {
            // if no instances
            if (!instances.ContainsKey (instanceType)) {
                return 0;
            }

            if (onlyAliveInstances) {
                return (instances[instanceType].Where (x => x.IsAlive)).Count ();
            }

            return instances[instanceType].Count;
        }
    }
}
