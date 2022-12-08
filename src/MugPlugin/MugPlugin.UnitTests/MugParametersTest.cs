using NUnit.Framework;
using MugPlugin.Model;
using Newtonsoft.Json.Linq;

namespace MugPlugin.UnitTests;

[TestFixture]
public class MugParametersTest
{
    /// <summary>
    /// Mug parameters.
    /// </summary>
    private readonly MugParameters _parameters = new MugParameters();

    [Test(Description = "Positive test set dependent parameter values.")]
    public void TestSetDependentParameter_CorrectValues()
    {
        // Set dependent value. 95 - its height
        var expectedHandleDiameter = _parameters.GetParameterValue(MugParametersType.HandleDiameter);
        var expectedHandleLength = _parameters.GetParameterValue(MugParametersType.HandleLength);

        _parameters.SetParameterValue(MugParametersType.HandleDiameter, expectedHandleDiameter);
        _parameters.SetParameterValue(MugParametersType.HandleLength, expectedHandleLength);

        Assert.Multiple(() =>
        {
            Assert.That(_parameters.GetParameterValue(MugParametersType.HandleDiameter),
                Is.EqualTo(expectedHandleDiameter));
            Assert.That(_parameters.GetParameterValue(MugParametersType.HandleLength),
                Is.EqualTo(expectedHandleLength));
        });
    }

    [Test(Description = "Negative test set dependent parameter values.")]
    public void TestSetDependentParameter_IncorrectValues()
    {
        const string expectedHandleLengthException =
            "Handle diameter depends on the handle length in the ratio (Handle diameter * 0.5)";
        const string expectedHandleDiameterException =
            "Handle length depends on the handle diameter in the ratio (Height * 0.7)";
       

        var actualHandleDiameterException = Assert.Throws<ArgumentOutOfRangeException>(() =>
            _parameters.SetParameterValue(MugParametersType.HandleDiameter, 20));
        var actualHandleLengthException = Assert.Throws<ArgumentOutOfRangeException>(() =>
            _parameters.SetParameterValue(MugParametersType.HandleLength, 20));

        Assert.Multiple(() =>
        {
            Assert.That(actualHandleDiameterException?.ParamName, Is.EqualTo(expectedHandleDiameterException));
            Assert.That(actualHandleLengthException?.ParamName, Is.EqualTo(expectedHandleLengthException));
        });
    }
}