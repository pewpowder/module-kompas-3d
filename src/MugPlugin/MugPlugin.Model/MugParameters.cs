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
            //SetDefaultValues(87, 95, 7, dependentValues[1], dependentValues[0]);
            var avgDependentValues = GetDependentValues(95);
            var maxDependentValues = GetDependentValues(130);
            var minDependentValues = GetDependentValues(85);

            _parameters = new Dictionary<MugParametersType, MugParameter>()
            {
                { MugParametersType.Diameter, new MugParameter(87, 70, 105) },
                { MugParametersType.Height, new MugParameter(95, 85, 130) },
                { MugParametersType.Thickness, new MugParameter(7, 5, 10) },
                { MugParametersType.HandleDiameter, new MugParameter(avgDependentValues[0], minDependentValues[0], maxDependentValues[0]) },
                { MugParametersType.HandleLength, new MugParameter(avgDependentValues[1], minDependentValues[1], maxDependentValues[1]) },
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

        public double[] GetDependentValues(double height)
        {
            double[] dependentValues = new double[]
            {
                Math.Round(height * 0.7, 1),
                Math.Round(height * 0.7 * 0.5, 1),
            };

            return dependentValues;
        }

        /// <summary>
        /// Checks dependent parameters.
        /// </summary>
        /// <param name="type">Mug parameter type.</param>
        /// <param name="value">Parameter value.</param>
        /// <exception cref="Exception">If the parameter values ​​are set incorrectly.</exception>
        private void CheckDependencies(MugParametersType type, double value)
        {
            _parameters.TryGetValue(MugParametersType.Height, out var parameter);
            var dependentValues = GetDependentValues(parameter.Value);
            switch (type)
            {
                case MugParametersType.HandleLength:
                {
                    if (value != dependentValues[1])
                    {
                        throw new Exception(
                            "Handle diameter depends on the handle length in the ratio (Handle diameter * 0.5)");
                    }
                    break;
                }
                case MugParametersType.HandleDiameter:
                {
                    if (value != dependentValues[0])
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
