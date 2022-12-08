using Kompas6API5;
using Kompas6Constants3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MugPlugin.Model;

namespace MugPlugin.Wrapper
{
    /// <summary>
    /// Sketch class.
    /// </summary>
    public class KompasSketch
    {
        /// <summary>
        /// Document 2D.
        /// </summary>
        private ksDocument2D _document2D;

        /// <summary>
        /// Sketch definition.
        /// </summary>
        private ksSketchDefinition _sketchDefinition;

        /// <summary>
        /// Return sketch.
        /// </summary>
        public ksEntity Sketch { get; set; }

        /// <summary>
        /// KompasSketch constructor.
        /// </summary>
        /// <param name="part"></param>
        /// <param name="type">1 - ZY; 2 - ZX; 3 - XY.</param>
        public KompasSketch(ksPart part, int type, double offset = 0)
        {
            ksEntity plane = (ksEntity)part.NewEntity((short)Obj3dType.o3d_planeOffset);
            ksPlaneOffsetDefinition planeDefinition = (ksPlaneOffsetDefinition)plane.GetDefinition();
            if (type == 1)
            {
                planeDefinition.SetPlane(part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ));
            }
            else if (type == 2)
            {
                planeDefinition.SetPlane(part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ));
            }
            else
            {
                planeDefinition.SetPlane(part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY));
            }

            planeDefinition.direction = true;
            planeDefinition.offset = offset;
            plane.Create();

            Sketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
            _sketchDefinition = (ksSketchDefinition)Sketch.GetDefinition();
            _sketchDefinition.SetPlane(plane);
            Sketch.Create();
            _document2D = (ksDocument2D)_sketchDefinition.BeginEdit();
        }

        /// <summary>
        /// End edit.
        /// </summary>
        public void EndEdit()
        {
            _sketchDefinition.EndEdit();
        }

        /// <summary>
        /// Creates a circle on a sketch.
        /// </summary>
        /// <param name="center">Circle center.</param>
        /// <param name="radius">Circle radius.</param>
        public void CreateCircle(Point2D center, double radius)
        {
            _document2D.ksCircle(center.X, center.Y, radius, 1);
        }

        /// <summary>
        /// Creates a line on a sketch.
        /// </summary>
        /// <param name="start">Start coordinates.</param>
        /// <param name="end">End coordinates.</param>
        /// <param name="style">Line style.</param>
        public void CreateLineSeg(Point2D start, Point2D end, int style)
        {
            _document2D.ksLineSeg(start.X, start.Y, end.X, end.Y, style);
        }

    }
}
