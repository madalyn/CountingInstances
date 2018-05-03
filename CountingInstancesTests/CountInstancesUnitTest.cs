using System;
using CountingInstances;
using CountingInstances.Shapes;
using Xunit;

namespace CountingInstancesTests
{
    public class CountInstancesUnitTest
    {
        void SetUp ()
        {
            InstanceTracker.GetInstance().ResetInstances();
        }

        [Fact]
        public void SquareTest ()
        {
            SetUp ();

            // 5 squares
            var square1 = new Square ();
            var square2 = new Square ();
            var square3 = new Square ();
            var square4 = new Square ();
            var square5 = new Square ();

            // + 5 more squares
            square5.ExternalSquare();

            // trigger GC
            System.GC.Collect();

            Assert.Equal (10, InstanceTracker.GetInstance ().CountInstances (typeof (Square)));
            Assert.Equal (5, InstanceTracker.GetInstance ().CountInstances (typeof (Square), true));
        }

        [Fact]
        public void CircleTest ()
        {
            SetUp();

            // 3 circles
            var circle1 = new Circle ();
            var circle2 = new Circle ();
            var circle3 = new Circle ();

            // trigger GC
            System.GC.Collect();

            Assert.Equal (3, InstanceTracker.GetInstance ().CountInstances (typeof (Circle)));
            Assert.Equal (3, InstanceTracker.GetInstance ().CountInstances (typeof (Circle), true));
        }

        [Fact]
        public void TriangleTest ()
        {
            SetUp();

            // 2 triangles
            var triangle1 = new Triangle ();
            var triangle2 = new Triangle ();

            // trigger GC
            System.GC.Collect();

            Assert.Equal (2, InstanceTracker.GetInstance ().CountInstances (typeof (Triangle)));
            Assert.Equal (2, InstanceTracker.GetInstance ().CountInstances (typeof (Triangle), true));
        }

        [Fact]
        public void RhombusTest ()
        {
            SetUp();

            // 1 + 5 more squares
            var square = new Square ();
            square.ExternalSquare ();

            // 4 rhombi + 1 for each square (4 + 6)
            var rhombus1 = new Rhombus ();
            var rhombus2 = new Rhombus ();
            var rhombus3 = new Rhombus ();
            var rhombus4 = new Rhombus ();

            // trigger GC
            System.GC.Collect();

            Assert.Equal (10, InstanceTracker.GetInstance ().CountInstances (typeof (Rhombus)));
            Assert.Equal (4, InstanceTracker.GetInstance ().CountInstances (typeof (Rhombus), true));
        }

        // If there are no instances created, CountInstances should return 0
        [Fact]
        public void NoShapesTest ()
        {
            SetUp();

            Assert.Equal (0, InstanceTracker.GetInstance ().CountInstances (typeof (Square)));
            Assert.Equal (0, InstanceTracker.GetInstance ().CountInstances (typeof (Square), true));
            Assert.Equal (0, InstanceTracker.GetInstance ().CountInstances (typeof (Circle)));
            Assert.Equal (0, InstanceTracker.GetInstance ().CountInstances (typeof (Circle), true));
            Assert.Equal (0, InstanceTracker.GetInstance ().CountInstances (typeof (Triangle)));
            Assert.Equal (0, InstanceTracker.GetInstance ().CountInstances (typeof (Triangle), true));
            Assert.Equal (0, InstanceTracker.GetInstance ().CountInstances (typeof (Rhombus)));
            Assert.Equal (0, InstanceTracker.GetInstance ().CountInstances (typeof (Rhombus), true));
        }
    }
}
