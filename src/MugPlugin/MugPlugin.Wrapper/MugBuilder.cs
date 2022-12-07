using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MugPlugin.Wrapper;

namespace MugPlugin.Model
{
    public class MugBuilder
    {
        private readonly KompasWrapper _wrapper = new KompasWrapper();

        public void BuildMug(MugParameters mugParameters)
        {
            _wrapper.StartKompas();
            _wrapper.CreateDocument();
            _wrapper.SetProperties();

            var mugRadius = mugParameters.GetParameterValue(MugParametersType.Diameter) / 2;
            var mugHeight = mugParameters.GetParameterValue(MugParametersType.Height);
            var mugThickness = mugParameters.GetParameterValue(MugParametersType.Thickness) / 2;
            var mugHandleLength = mugParameters.GetParameterValue(MugParametersType.HandleLength);
            var mugHandleDiameter = mugParameters.GetParameterValue(MugParametersType.HandleDiameter) / 3;
            CreateMugBody(mugRadius, mugHeight, mugThickness);
            CreateMugHandle(mugRadius, mugHeight, mugHandleDiameter, mugHandleLength);

            _wrapper.Fillet(mugThickness / 2.5);
        }

        /// 1 - ZY; 2 - ZX; 3 - XY.
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