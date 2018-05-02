using System;
/*
 * 1. A mechanism to count the number of times a set of classes have been instantiated. 
 * 2. The solution must be generic enough such that it can count instances of an arbitrary number of different classes. 
 * 3. The solution must be extensible such that defining new classes to be counted is trivially easy using standard OO principles.
 * 4. Demonstrate the solution by instantiating a number of different classes, and then output the name of the class followed by the number of instances created. 
 * 5. Submit complete source code, and sample output of running the program.  It must compile and run cleanly without errors or warnings.  Include an explanation of your design choices, any trade-offs, and potential alternative considerations. 
 * 
 * For example, the output of such a program might look like this: 
 * CountMe 5
 * CountMeToo 4
 * AndMe 12
 * Counted 5
 * 
 * Bonus #1:  For additional bonus points, consider a mechanism that does not require each class counted to inherit from a common base class. 
 * Bonus #2:  For even more bonus points, in addition to the number of instances created, also display the count of the number of instances that are still alive (i.e. reachable).
*/
namespace CountingInstances
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

// could do v1, v2, v3 to encompass the "bonuses"