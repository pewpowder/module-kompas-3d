using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MugPlugin.Wrapper;

namespace MugPlugin.Model
{
    /// <summary>
    /// Class for constructing a mug.
    /// </summary>
    public class MugBuilder
    {
        /// <summary>
        /// Kompas wrapper.
        /// </summary>
        private readonly KompasWrapper _wrapper = new KompasWrapper();

        /// <summary>
        /// Build a mug by parameters.
        /// </summary>
        /// <param name="mugParameters">Mug parameters.</param>
        public void BuildMug(MugParameters mugParameters)
        {
            _wrapper.StartKompas();
            _wrapper.CreateDocument();
            _wrapper.SetProperties();

            var mugRadius = mugParameters.GetParameterValue(MugParametersType.Diameter) / 2;
            var mugHeight = mugParameters.GetParameterValue(MugParametersType.Height);
            var mugThickness = (mugParameters.GetParameterValue(MugParametersType.Thickness) + 1) / 2;
            var mugHandleLength = mugParameters.GetParameterValue(MugParametersType.HandleLength);
            var mugHandleDiameter = mugParameters.GetParameterValue(MugParametersType.HandleDiameter) / 3;
            CreateMugBody(mugRadius, mugHeight, mugThickness);
            CreateMugHandle(mugRadius, mugHeight, mugHandleDiameter, mugHandleLength);

            _wrapper.Fillet(mugThickness / 2);
        }

        /// <summary>
        /// Build mug body.
        /// </summary>
        /// <param name="radius">Mug radius.</param>
        /// <param name="height">Mug height.</param>
        /// <param name="thickness">Mug thickness.</param>
        private void CreateMugBody(double radius, double height, double thickness)
        {
            // Create mug body.
            var point = new Point2D(0, 0);
            var sketch = _wrapper.CreateSketch(3);
            sketch.CreateCircle(point, radius);
            sketch.EndEdit();
            _wrapper.Extrude(sketch, height, true);


            // Cut mug body.
            sketch = _wrapper.CreateSketch(3, height);
            sketch.CreateCircle(point, radius - thickness);
            sketch.EndEdit();
            _wrapper.CutExtrude(sketch, height - thickness, true);
        }

        /// <summary>
        /// Build mug handle.
        /// </summary>
        /// <param name="radius">Mug radius.</param>
        /// <param name="height">Mug height.</param>
        /// <param name="handleDiameter">Mug handle diameter.</param>
        /// <param name="handleLength">Mug handle length.</param>
        private void CreateMugHandle(double radius, double height, double handleDiameter, double handleLength)
        {
            // Draw axial line
            var mugCenterY = -height / 2;
            var sketch = _wrapper.CreateSketch(2, radius - 3);
            var start = new Point2D(-radius, mugCenterY);
            var end = new Point2D(radius, mugCenterY);
            sketch.CreateLineSeg(start, end, 3);

            // Draw circle
            var circleCenter = new Point2D(0, -handleDiameter);
            sketch.CreateCircle(circleCenter, handleLength - (handleLength * 80) / 100);
            sketch.EndEdit();

            //Extrude circle by rotation
            _wrapper.ExtrudeRotation(sketch);
        }
    }
}