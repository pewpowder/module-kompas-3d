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
        ///  Значение параметра.
        /// </summary>
        private double _value;

        /// <summary>
        /// Устанавливает и возвращает значение параметра.
        /// </summary>
        public double Value
        {
            get => _value;
            set 
            {
                if(IsRangeOut(value))
                {
                    throw new ArgumentException($"Value must be between {MinValue} and {MaxValue}");
                }
                _value = value;
            }
        }

        /// <summary>
        /// Получить минимальное допустимое значение параметра.
        /// </summary>
        public double MinValue {  get; }
        
        /// <summary>
        /// Получить максимальное допустимое значение параметра.
        /// </summary>
        public double MaxValue { get; }


        /// <summary>
        /// Конструктор MugParamter.
        /// </summary>
        /// <param name="value">Значение параметра.</param>
        /// <param name="minValue">Минимальное допустимое значение параметра.</param>
        /// <param name="maxValue">Максимальное допустимое значение параметра.</param>
        public MugParameter(double minValue, double maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }


        /// <summary>
        /// Проверка не выходит ли параметр за диапазон допустимых значений.
        /// </summary>
        /// <param name="value">Значение параметра.</param>
        /// <returns></returns>
        private bool IsRangeOut(double value)
        {
            if(value < MinValue || value > MaxValue)
            {
                return true;
            } 

            return false;
        }
    }
}
