using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MugPlugin.Model;
using MugPlugin.Wrapper;

namespace MugPlugin.View
{
    /// <summary>
    /// Class for interacting with the form.
    /// </summary>
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

        /// <summary>
        /// Main form constructor.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _parameters = new MugParameters();
            _textBoxToParameterType = new Dictionary<TextBox, MugParametersType>
            {
                { diameter, MugParametersType.Diameter },
                { height, MugParametersType.Height },
                { thickness, MugParametersType.Thickness },
                { handleDiameter, MugParametersType.HandleDiameter },
                { handleLength, MugParametersType.HandleLength },
                { pocketHeight, MugParametersType.PocketHeight },
            };
            _textBoxAndError = new Dictionary<TextBox, string>
            {
                { diameter, "" },
                { height, "" },
                { thickness, "" },
                { handleDiameter, "" },
                { handleLength, "" },
                { pocketHeight, "" }
            };
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
            catch (ArgumentOutOfRangeException error)
            {
                _textBoxAndError[textBox] = error.ParamName;
                errorProvider.SetError(textBox, error.ParamName);
            }
        }


        /// <summary>
        /// Sets default values.
        /// </summary>
        /// <param name="diameterValue">Mug diameter.</param>
        /// <param name="heightValue">Mug height.</param>
        /// <param name="thicknessValue">Mug wall thickness.</param>
        /// <param name="handleLengthValue">Mug handle length.</param>
        /// <param name="handleDiameterValue">Mug handle diameter.</param>
        /// <param name="pocketHeightValue">Mug pocket height.</param>
        private void SetParameters(double diameterValue, double heightValue,
            double thicknessValue, double handleLengthValue, double handleDiameterValue, double pocketHeightValue)
        {
            _parameters.SetParameterValue(MugParametersType.Diameter, diameterValue);
            _parameters.SetParameterValue(MugParametersType.Height, heightValue);
            _parameters.SetParameterValue(MugParametersType.Thickness, thicknessValue);
            _parameters.SetParameterValue(MugParametersType.HandleDiameter, handleDiameterValue);
            _parameters.SetParameterValue(MugParametersType.HandleLength, handleLengthValue);
            _parameters.SetParameterValue(MugParametersType.PocketHeight, pocketHeightValue);

            diameter.Text = diameterValue.ToString();
            height.Text = heightValue.ToString();
            thickness.Text = thicknessValue.ToString();
            handleDiameter.Text = handleDiameterValue.ToString();
            handleLength.Text = handleLengthValue.ToString();
            pocketHeight.Text = pocketHeightValue.ToString();
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
        private void Build(object sender, EventArgs e)
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

        /// <summary>
        /// Set default mug parameters.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetDefaultParameters(object sender, EventArgs e)
        {
            var buttonName = (sender as Button)?.Name;

            switch (buttonName)
            {
                case "setParametersMin":
                {
                    var dependentValues = _parameters.GetDependentValues(85);
                    SetParameters(70, 85, 5, dependentValues[1], dependentValues[0], dependentValues[2]);
                    break;
                }
                case "setParametersAvg":
                {
                    var dependentValues = _parameters.GetDependentValues(95);
                    SetParameters(87, 95, 7, dependentValues[1], dependentValues[0], dependentValues[2]);
                    break;
                }
                case "setParametersMax":
                {
                    var dependentValues = _parameters.GetDependentValues(130);
                    SetParameters(105, 130, 10, dependentValues[1], dependentValues[0], dependentValues[2]);
                    break;
                }
                default:
                {
                    var dependentValues = _parameters.GetDependentValues(95);
                    SetParameters(87, 95, 7, dependentValues[1], dependentValues[0], dependentValues[2]);
                    break;
                }
            }
        }

        /// <summary>
        /// Clear text field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearField(object sender, EventArgs e)
        { 
            var textBox = sender as TextBox;
            textBox.Text = "";
        }
    }
}