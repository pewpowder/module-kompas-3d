using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MugPlugin.Model
{
    /// <summary>
    /// Перечисление параметров кружки.
    /// </summary>
    public enum MugParametersType
    {
        /// <summary>
        /// Диаметер горла кружки.
        /// </summary>
        Diameter,

        /// <summary>
        /// Высота кружки.
        /// </summary>
        Height,

        /// <summary>
        /// Толщина стенок кружки.
        /// </summary>
        Thickness,

        /// <summary>
        /// Длина ручки кружки.
        /// </summary>
        HandleLength,

        /// <summary>
        /// Диаметер внутренней части ручки.
        /// </summary>
        HandleDiameter
    }
}
