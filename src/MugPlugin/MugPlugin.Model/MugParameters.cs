using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MugPlugin.Model
{
    public class MugParameters
    {
        /// <summary>
        /// Stores the parameter type and its values.
        /// </summary>
        private readonly Dictionary<MugParametersType, MugParameter> _parameters;

        /// <summary>
        /// MugParameters constructor.
        /// </summary>
        public MugParameters()
        {
            _parameters = new Dictionary<MugParametersType, MugParameter>()
            {
                { MugParametersType.Diameter, new MugParameter(87, 70, 105) },
                { MugParametersType.Height, new MugParameter(95, 85, 130) },
                { MugParametersType.Thickness, new MugParameter(7, 5, 10) },
                { MugParametersType.HandleDiameter, new MugParameter(76, 59.5, 91) },
                { MugParametersType.HandleLength, new MugParameter(38, 29.75, 45.5) },
            };
        }

        /// <summary>
        /// Sets parameter value.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void SetParameterValue(MugParametersType type, double value)
        {
            if (!_parameters.TryGetValue(type, out var parameter)) return;

            CheckDependencies(type, value);
            parameter.Value = value;
        }

        /// <summary>
        /// Gets parameter value.
        /// </summary>
        /// <param name="type">Mug parameter type.</param>
        /// <returns>Parameter value.</returns>
        /// <exception cref="Exception">If parameter value does not exist.</exception>
        public double GetParameterValue(MugParametersType type)
        {
            if (_parameters.TryGetValue(type, out var parameter))
            {
                return parameter.Value;
            }
            throw new Exception("Parameter does not exist");
        }

        /// <summary>
        /// Checks dependent parameters.
        /// </summary>
        /// <param name="type">Mug parameter type.</param>
        /// <param name="value">Parameter value.</param>
        /// <exception cref="Exception">If the parameter values ​​are set incorrectly.</exception>
        private void CheckDependencies(MugParametersType type, double value)
        {
            switch (type)
            {
                case MugParametersType.HandleLength:
                {
                    _parameters.TryGetValue(MugParametersType.HandleDiameter, out var parameter);
                    if (value + parameter.Value * 0.5 != parameter.Value)
                    {
                        throw new Exception(
                            "Handle diameter depends on the handle length in the ratio (Handle diameter * 0.5)");
                    }

                    break;
                }
                case MugParametersType.HandleDiameter:
                {
                    _parameters.TryGetValue(MugParametersType.Height, out var parameter);
                    if (value + parameter.Value * 0.7 == parameter.Value)
                    {
                        throw new Exception(
                            "Handle length depends on the handle diameter in the ratio (Height * 0.7)");
                        
                    }
                    break;
                }
                default:
                {
                    return;
                }
            }
        }
    }
}
