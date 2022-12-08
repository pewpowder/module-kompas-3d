using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MugPlugin.Model
{
    public class Point2D: IEquatable<Point2D>
    {
        /// <summary>
        /// Point on x-axis.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Point on y-axis.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Point2D constructor.
        /// </summary>
        /// <param name="x">Point on x-axis.</param>
        /// <param name="y">Point on y-axis.</param>
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Checking for equality of class objects.
        /// </summary>
        /// <param name="expected">Compared object.</param>
        /// <returns>Returns true if the elements are equal,
        /// false - otherwise.</returns>
        public bool Equals(Point2D expected)
        {
            return expected != null &&
                   expected.X.Equals(X) &&
                   expected.Y.Equals(Y);
        }
    }
}
