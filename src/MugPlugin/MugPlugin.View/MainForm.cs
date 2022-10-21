using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MugPlugin.Model;

namespace MugPlugin.View
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Параметры кружки.
        /// </summary>
        private MugParameters Parameters;


        private Dictionary<TextBox, MugParametersType> TextBoxToParameter;

        public MainForm()
        {
            InitializeComponent();
            Parameters = new MugParameters();
            TextBoxToParameter = new Dictionary<TextBox, MugParametersType>()
            {
                { diameter, MugParametersType.Diameter },
                { height, MugParametersType.Height },
                { thickness, MugParametersType.Thickness },
                { handleLength, MugParametersType.HandleLength },
                { handleDiameter, MugParametersType.HandleDiameter },
            };
        }


        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="type"></param>
        /// 
        private void SetParameter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Boolean isType = TextBoxToParameter.TryGetValue(textBox, out MugParametersType type);
            Boolean isValue = Double.TryParse(textBox.Text, out double value);


            if (isType)
            {
                try
                {
                    Parameters.SetParameterValue(type, value);
                    errorProvider.Clear();

                }
                catch (Exception error)
                {
                    errorProvider.SetError(textBox, error.Message);
                }
            }
        }

        /// <summary>
        /// Строит кружку с минимальными параметрами.
        /// </summary>
        private void SetMinParameters()
        {

        }

        /// <summary>
        /// Строит кружку с максимальными параметрами.
        /// </summary>
        private void SetMaxParameters()
        {

        }

        /// <summary>
        /// Строит кружку с средними параметрами.
        /// </summary>
        private void SetAvgParameters()
        {

        }

        
        private void Build()
        {
            // Перед отправкой проходимся циклом и смотрим остались ли не заполненные параметры.
        }

        /// <summary>
        /// Проверяет зависимые параметры
        /// </summary>
        private void CheckDependentParameters()
        {
        }
    }
}
