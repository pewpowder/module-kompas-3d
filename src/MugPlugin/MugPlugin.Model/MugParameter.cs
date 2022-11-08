using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MugPlugin.Model
{
    public class MugParameter
    {
        /// <summary>
        /// Parameter value.
        /// </summary>
        private double _value;

        /// <summary>
        /// Sets and returns the value of a parameter.
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                if (IsRangeOut(value))
                {
                    throw new ArgumentException($"Value must be between {_minValue} and {_maxValue}");
                }
                _value = value;
            }
        }

        /// <summary>
        /// Get the minimum allowed parameter value.
        /// </summary>
        private readonly double _minValue;

        /// <summary>
        /// Get the maximum allowed parameter value.
        /// </summary>
        private readonly double _maxValue;


        /// <summary>
        /// MugParameter constructor.
        /// </summary>
        /// <param name="value">Parameter value.</param>
        /// <param name="minValue">Minimum allowed parameter value.</param>
        /// <param name="maxValue">Maximum allowed parameter value.</param>
        public MugParameter(double value, double minValue, double maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            Value = value;
        }


        /// <summary>
        /// Checking if the parameter is out of range of valid values.
        /// </summary>
        /// <param name="value">Parameter value.</param>
        /// <returns></returns>
        private bool IsRangeOut(double value)
        {
            return value < _minValue || value > _maxValue;
        }
    }
}
