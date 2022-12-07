using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MugPlugin.Model;

namespace MugPlugin.View
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Mug parameters.
        /// </summary>
        private readonly MugParameters _parameters;

        /// <summary>
        /// Stores a text field and its error.
        /// </summary>
        private readonly Dictionary<TextBox, string> _textBoxAndError;

        /// <summary>
        /// Stores a text field and its corresponding parameter type.
        /// </summary>
        private readonly Dictionary<TextBox, MugParametersType> _textBoxToParameterType;


        public MainForm()
        {
            InitializeComponent();
            _parameters = new MugParameters();
            _textBoxToParameterType = new Dictionary<TextBox, MugParametersType>
            {
                { diameter, MugParametersType.Diameter },
                { height, MugParametersType.Height },
                { thickness, MugParametersType.Thickness },
                { handleDiameter, MugParametersType.HandleLength },
                { handleLength, MugParametersType.HandleDiameter }
            };
            _textBoxAndError = new Dictionary<TextBox, string>
            {
                { diameter, "" },
                { height, "" },
                { thickness, "" },
                { handleDiameter, "" },
                { handleLength, "" }
            };
        }

        /// <summary>
        /// Sets default values ​​on form load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            var dependentValues = _parameters.GetDependentValues(95);
            SetDefaultValues(87, 95, 7, dependentValues[1], dependentValues[0]);
        }

        /// <summary>
        /// Sets parameter value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetParameter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            var isType = _textBoxToParameterType.TryGetValue(textBox, out var type);
            var textValue = textBox.Text.Replace('.', ',');
            double.TryParse(textValue, out var value);
            value = Math.Round(value, 1);

            if (!isType) return;

            try
            {
                _parameters.SetParameterValue(type, value);
                _textBoxAndError[textBox] = "";
                errorProvider.Clear();
            }
            catch (Exception error)
            {
                _textBoxAndError[textBox] = error.Message;
                errorProvider.SetError(textBox, error.Message);
            }
        }

        private string ReplaceDotWithComma(string value)
        {
            return value.Replace('.', ',');
        }

        /// <summary>
        /// Clears a text field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearTextBox(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).Text = "";
        }

        /// <summary>
        /// Sets the minimum parameters of the mug.
        /// </summary>
        private void SetMinParameters(object sender, MouseEventArgs e)
        {
            var dependentValues = _parameters.GetDependentValues(85);
            SetDefaultValues(70, 85, 5, dependentValues[1], dependentValues[0]);
        }

        /// <summary>
        /// Sets the average parameters of the mug.
        /// </summary>
        private void SetAvgParameters(object sender, EventArgs e)
        {
            var dependentValues = _parameters.GetDependentValues(95);
            SetDefaultValues(87, 95, 7, dependentValues[1], dependentValues[0]);
        }

        /// <summary>
        ///  Sets the maximum parameters for the mug.
        /// </summary>
        private void SetMaxParameters(object sender, EventArgs e)
        {
            var dependentValues = _parameters.GetDependentValues(130);
            SetDefaultValues(105, 130, 10, dependentValues[1], dependentValues[0]);
        }

        /// <summary>
        /// Sets default values.
        /// </summary>
        /// <param name="diameterValue">Mug diameter.</param>
        /// <param name="heightValue">Mug height.</param>
        /// <param name="thicknessValue">Mug wall thickness.</param>
        /// <param name="handleLengthValue">Mug handle length.</param>
        /// <param name="handleDiameterValue">Mug handle diameter.</param>
        private void SetDefaultValues(double diameterValue, double heightValue,
            double thicknessValue, double handleLengthValue, double handleDiameterValue)
        {
            _parameters.SetParameterValue(MugParametersType.Diameter, diameterValue);
            _parameters.SetParameterValue(MugParametersType.Height, heightValue);
            _parameters.SetParameterValue(MugParametersType.Thickness, thicknessValue);
            _parameters.SetParameterValue(MugParametersType.HandleDiameter, handleDiameterValue);
            _parameters.SetParameterValue(MugParametersType.HandleLength, handleLengthValue);

            diameter.Text = diameterValue.ToString();
            height.Text = heightValue.ToString();
            thickness.Text = thicknessValue.ToString();
            handleDiameter.Text = handleLengthValue.ToString();
            handleLength.Text = handleDiameterValue.ToString();
        }

        /// <summary>
        /// Checks if all text fields are filled correctly.
        /// </summary>
        /// <returns></returns>
        private bool CheckTextBoxes()
        {
            var isError = true;
            foreach (var item in 
                     _textBoxAndError.Where(item => item.Value != ""))
            {
                isError = false;
                errorProvider.SetError(item.Key, item.Value);
            }

            return isError;
        }

        /// <summary>
        /// Build mug in Kompas 3D.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void build_click(object sender, EventArgs e)
        {
            if (CheckTextBoxes())
            {
                var builder = new MugBuilder();
                builder.BuildMug(_parameters);
            }
            else
            {
                MessageBox.Show(@"Fill all required parameters correctly");
            }
        }
    }
}