using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MugPlugin.Model
{
    public class MugParameters
    {
        private Dictionary<MugParametersType, MugParameter> _parameters;

        public MugParameters()
        {
            _parameters = new Dictionary<MugParametersType, MugParameter>()
            {
                { MugParametersType.Diameter, new MugParameter(70, 105) },
                { MugParametersType.Height, new MugParameter(85, 105) },
                { MugParametersType.Thickness, new MugParameter(5, 10) },
                { MugParametersType.HandleLength, new MugParameter(30, 46) },
                { MugParametersType.HandleDiameter, new MugParameter(60, 92) },
            };
        }

        public void SetParameterValue(MugParametersType type, double value)
        {
            if(_parameters.TryGetValue(type, out MugParameter parameter))
            {
                parameter.Value = value;
            }
        }

        public double GetParameterValue(MugParametersType type)
        {
            if(_parameters.TryGetValue(type, out MugParameter parameter))
            {
                throw new ArgumentOutOfRangeException("type");
            }
            return parameter.Value;
        }
    }
}
