﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MugPlugin.Model
{
    /// <summary>
    /// Class with all mug parameters.
    /// </summary>
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
            var avgDependentValues = GetDependentValues(95);
            var maxDependentValues = GetDependentValues(130);
            var minDependentValues = GetDependentValues(85);

            _parameters = new Dictionary<MugParametersType, MugParameter>()
            {
                { MugParametersType.Diameter, new MugParameter(87, 70, 105) },
                { MugParametersType.Height, new MugParameter(95, 85, 130) },
                { MugParametersType.Thickness, new MugParameter(7, 5, 10) },
                {
                    MugParametersType.HandleDiameter,
                    new MugParameter(avgDependentValues[0], minDependentValues[0], maxDependentValues[0])
                },
                {
                    MugParametersType.HandleLength,
                    new MugParameter(avgDependentValues[1], minDependentValues[1], maxDependentValues[1])
                },
                {
                    MugParametersType.PocketHeight,
                    new MugParameter(avgDependentValues[2], minDependentValues[2], maxDependentValues[2])
                }
            };
        }

        /// <summary>
        /// Sets parameter value.
        /// </summary>
        /// <param name="type">Mug parameter type.</param>
        /// <param name="value">Parameter value.</param>
        public void SetParameterValue(MugParametersType type, double value)
        {
            var parameter = _parameters[type];
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
            return _parameters[type].Value;
        }


        /// <summary>
        /// Get Dependent Parameters.
        /// </summary>
        /// <param name="height">Mug height.</param>
        /// <returns></returns>
        public double[] GetDependentValues(double height)
        {
            var dependentValues = new double[]
            {
                Math.Round(height * 0.7, 1),
                Math.Round(height * 0.7 * 0.5, 1),
                Math.Round(height * 0.3)
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

            if (type == MugParametersType.HandleLength)
            {
                if (value != dependentValues[1])
                {
                    throw new ArgumentOutOfRangeException(
                        "Handle length depends on the handle diameter in the ratio (Height * 0.7)");
                    
                }
            }

            if (type == MugParametersType.HandleDiameter)
            {
                if (value != dependentValues[0])
                {
                    throw new ArgumentOutOfRangeException(
                        "Handle diameter depends on the mug height in the ratio (Handle diameter * 0.5)");
                }
            }

            if (type == MugParametersType.PocketHeight)
            {
                if (value != dependentValues[2])
                {
                    throw new ArgumentOutOfRangeException(
                        "Pocket height depends on the mug height in the ratio (Height * 0.3)");
                }
            }
        }
    }
}