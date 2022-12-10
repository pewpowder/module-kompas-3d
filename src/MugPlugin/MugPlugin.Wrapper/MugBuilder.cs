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
            var mugThickness = (mugParameters.GetParameterValue(MugParametersType.Thickness)) / 2;
            var mugHandleLength = mugParameters.GetParameterValue(MugParametersType.HandleLength);
            var mugHandleDiameter = mugParameters.GetParameterValue(MugParametersType.HandleDiameter) / 3;
            var pocketHeight = mugParameters.GetParameterValue(MugParametersType.PocketHeight);
            BuildMugBody(mugRadius, mugHeight, mugThickness, pocketHeight);
            BuildMugHandle(mugRadius, mugHeight, mugHandleDiameter, mugHandleLength);

            BuildCookiesPocket(mugRadius, pocketHeight, mugThickness);
            _wrapper.Fillet(mugThickness / 3);
        }

        /// <summary>
        /// Build mug body.
        /// </summary>
        /// <param name="radius">Mug radius.</param>
        /// <param name="mugHeight">Mug mugHeight.</param>
        /// <param name="thickness">Mug thickness.</param>
        /// /// <param name="pocketHeight">Pocket height.</param>
        private void BuildMugBody(double radius, double mugHeight, double thickness, double pocketHeight)
        {
            // Create mug body.
            var point = new Point2D(0, 0);
            var sketch = _wrapper.CreateSketch(3);
            sketch.CreateCircle(point, radius);
            sketch.EndEdit();
            _wrapper.Extrude(sketch, mugHeight, true);


            // Cut mug body.
            sketch = _wrapper.CreateSketch(3, mugHeight);
            sketch.CreateCircle(point, radius - thickness);
            sketch.EndEdit();
            _wrapper.CutExtrude(sketch, mugHeight - pocketHeight - thickness);
        }

        /// <summary>
        /// Build mug handle.
        /// </summary>
        /// <param name="radius">Mug radius.</param>
        /// <param name="height">Mug mugHeight.</param>
        /// <param name="handleDiameter">Mug handle diameter.</param>
        /// <param name="handleLength">Mug handle length.</param>
        private void BuildMugHandle(double radius, double height, double handleDiameter, double handleLength)
        {
            // Draw axial line.
            var mugCenterY = -height / 2;
            var sketch = _wrapper.CreateSketch(2, radius - 2);
            var start = new Point2D(-radius, mugCenterY);
            var end = new Point2D(radius, mugCenterY);
            sketch.CreateLineSeg(start, end, 3);

            // Draw circle.
            var circleCenter = new Point2D(0, -handleDiameter);
            sketch.CreateCircle(circleCenter, handleLength - (handleLength * 80) / 100);
            sketch.EndEdit();

            //Extrude circle by rotation.
            _wrapper.ExtrudeRotation(sketch);
        }


        /// <summary>
        /// Create pocket for cookies.
        /// </summary>
        /// <param name="radius">Mug radius.</param>
        /// <param name="height">Pocket mugHeight.</param>
        /// <param name="thickness">Mug thickness.</param>
        private void BuildCookiesPocket(double radius, double height, double thickness)
        {
            // Create circle.
            var center = new Point2D(0, 0);
            var sketch = _wrapper.CreateSketch(3, thickness);
            sketch.CreateCircle(center, radius - thickness);
            sketch.EndEdit();

            // Extrude circle.
            _wrapper.CutExtrude(sketch, -height + thickness);

            // Plane XZ.
            sketch = _wrapper.CreateSketch(2, thickness);

            // Axis
            var endAxisLine = new Point2D(0, -height);
            sketch.CreateLineSeg(center, endAxisLine, 3);

            // Radius
            var startMainLine = new Point2D(radius + thickness, -thickness);
            var endMainLine = new Point2D(radius + thickness, -height);
            sketch.CreateLineSeg(startMainLine, endMainLine, 1);
            sketch.EndEdit();

            // Cut extrusion line.
            _wrapper.CutExtrudeRotation(sketch, -180);
        }
    }
}