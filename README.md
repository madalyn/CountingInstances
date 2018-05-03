# Counting Instances
<i>A coding project to count the number of times a class has been instantiated.</i>

This was an interesting challenge, as it is not a problem I'd normally consider. It became clear to me that the way to "track" instances of a class, would be to have some code in the constructor that registers when the class is called (since the constructor is going to be called when the class is instantiated). That way, we'd be able to know about any and all classes created.

The first approach I took didn't turn out to work the way I'd planned. In order to minimize the amount of shared code as much as possible, my initial instinct was to use inheritance, where all classes created would extend a base class that did the constructor logging. However, I forgot that since I was using the constructor to update a static list, my subclasses would not inherit their own versions of this list, and all instances would be added to the one 'global' list. Because of inheritance, all child classes would resolve to the base class, and the functionality would be implied on the base class instead of what I'd intended.

Example:

```
baseClass.Add (instance);
child1.Add (instance); // inherits ‘Add’ from baseClass
child2.Add (instance);
child1.CountInstances  3; // not 1 instance on the child, 3 total instances
```

I definitely didn't want to duplicate any of the tracking code across child classes, and I was still trying to think of a solution that didn't use inheritance (as asked for in <b>Bonus #1</b>). That’s when I came up with the idea to have a class with static methods (modified this to be a Singleton) that was responsible solely as the “Global Instance Tracker.”

I felt that a Singleton made sense for this problem, because it is challenging to come up with a simple way to keep track of every instance of every class across an entire project without having to make too many modifications to all future classes. To me, this called out for a Global State that could be in charge of all this and leave the rest of the functionality of the program pretty much alone.

I don’t love how the user will have to remember to add a call to the singleton in every class constructor, but thinking about it, there has to be some way for the user to decide if a class should be “trackable” or not. I also feel that this is not more code than if a user had to have every class inherit from a base class, and a one line function call is not much to setup.

I found it simple to use a dictionary to store all of the instances for each class. This made a lot of sense, because the class name makes an obvious ‘Key’, and by checking the dictionary for that Key, instances can be easily tracked by class, and instances of new classes can be added no problem.

I chose to use WeakRefrences to store the instances because a `WeakRefrence` allows you to maintain a reference to an object that is still able to be garbage-collected. I knew that I wouldn’t be able to check for unused object references eligible for garbage collection (<b>Bonus #2</b>) if I was tying them up myself by referencing them.

Furthermore, I was able to check to see which objects were still referenced by using the `refrence.IsAlive` property. I realize this `IsAlive` isn’t a guarantee (read more here: https://blogs.msdn.microsoft.com/clyon/2006/04/20/why-you-shouldnt-rely-on-weakreference-isalive/), but for my proof of concept it would be fine, since I didn’t see myself running into the potential edge cases others pointed out for how I would be using it (aka, I would only be querying `IsAlive` after everything had run, not in the middle of a block).

MSDN recommends only checking false values with `IsAlive`, as those are at least guaranteed. I changed my CountInstances method to do this, by checking false values instead of true, and subtracting the count of those from the total count of all instances. I checked that this was the same result I had expected before when checking with true (it was). I decided to stick with the original version, since both worked for what I was doing here. If I wanted to not use `IsAlive` altogether, I would have used deconstructors to track when the class instances were cleaned up.

I wrote some unit tests that more or less mimic what the main program will print out. I also wanted to check that we count zero instances when no classes have been instantiated. I did have to add an extra method to my singleton class to reset the instances dictionary to mimic each standalone case in the tests. I tried to avoid doing this at first, but it didn’t seem like an unreasonable thing to do. If I really chose to not go this route, I would have changed my class implementations to take in an `InstanceTracker` in each constructor (dependency injection), and then for my unit tests I could have passed in my mock InstanceTrackers.

I struggled this morning with getting NUnit to play nice with VS for Mac (I couldn’t get the Project references to work) so I switched to XUnit to write the unit tests with.

Thanks for reading! Enjoy!


