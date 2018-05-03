using System;
using CountingInstances.Shapes;
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
            // 5 squares
            var square1 = new Square ();
            var square2 = new Square ();
            var square3 = new Square ();
            var square4 = new Square ();
            var square5 = new Square ();

            // + 5 more squares
            square5.externalSquare ();

            // 3 circles
            var circle1 = new Circle ();
            var circle2 = new Circle ();
            var circle3 = new Circle ();

            // 2 triangles
            var triangle1 = new Triangle ();
            var triangle2 = new Triangle ();

            // 4 rhombi + 1 for each square (4 + 10)
            var rhombus1 = new Rhombus ();
            var rhombus2 = new Rhombus ();
            var rhombus3 = new Rhombus ();
            var rhombus4 = new Rhombus ();

            // trigger GC to prove it all works
            System.GC.Collect();

            // Output
            Console.WriteLine ("Here are the instances of each of the classes: ");

            Console.WriteLine ("Square: " + InstanceTracker.GetInstance().CountInstances (typeof (Square)));
            Console.WriteLine ("Square (alive instances): " + InstanceTracker.GetInstance().CountInstances (typeof (Square), true));
            Console.WriteLine ();

            Console.WriteLine ("Circle: " + InstanceTracker.GetInstance().CountInstances (typeof (Circle)));
            Console.WriteLine ("Circle: (alive instances): " + InstanceTracker.GetInstance().CountInstances (typeof (Circle), true));
            Console.WriteLine ();

            Console.WriteLine ("Triangle: " + InstanceTracker.GetInstance().CountInstances (typeof (Triangle)));
            Console.WriteLine ("Triangle (alive instances): " + InstanceTracker.GetInstance().CountInstances (typeof (Triangle), true));
            Console.WriteLine ();

            Console.WriteLine ("Rhombus: " + InstanceTracker.GetInstance().CountInstances (typeof (Rhombus)));
            Console.WriteLine ("Rhombus (alive instances): " + InstanceTracker.GetInstance().CountInstances (typeof (Rhombus), true));
        }
    }
}