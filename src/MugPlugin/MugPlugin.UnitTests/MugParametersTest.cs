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
    public void TestDependentParameterSet_CorrectValues()
    {
        var expectedHandleDiameter = _parameters.GetParameterValue(MugParametersType.HandleDiameter);
        var expectedHandleLength = _parameters.GetParameterValue(MugParametersType.HandleLength);
        var expectedPocketHeight = _parameters.GetParameterValue(MugParametersType.PocketHeight);

        _parameters.SetParameterValue(MugParametersType.HandleDiameter, expectedHandleDiameter);
        _parameters.SetParameterValue(MugParametersType.HandleLength, expectedHandleLength);
        _parameters.SetParameterValue(MugParametersType.PocketHeight, expectedPocketHeight);

        Assert.Multiple(() =>
        {
            Assert.That(_parameters.GetParameterValue(MugParametersType.HandleDiameter),
                Is.EqualTo(expectedHandleDiameter));
            Assert.That(_parameters.GetParameterValue(MugParametersType.HandleLength),
                Is.EqualTo(expectedHandleLength));
            Assert.That(_parameters.GetParameterValue(MugParametersType.PocketHeight),
                Is.EqualTo(expectedPocketHeight));
        });
    }

    [Test(Description = "Negative test set dependent parameter values.")]
    public void TestDependentParameterSet_IncorrectValues()
    {
        var actualHandleDiameterException = Assert.Throws<ArgumentOutOfRangeException>(() =>
            _parameters.SetParameterValue(MugParametersType.HandleDiameter, 20));
        var actualHandleLengthException = Assert.Throws<ArgumentOutOfRangeException>(() =>
            _parameters.SetParameterValue(MugParametersType.HandleLength, 20));
        var actualPocketHeightException = Assert.Throws<ArgumentOutOfRangeException>(() =>
            _parameters.SetParameterValue(MugParametersType.PocketHeight, 20));


        Assert.Multiple(() =>
        {
            Assert.That(actualHandleDiameterException?.GetType(), Is.EqualTo(typeof(ArgumentOutOfRangeException)));
            Assert.That(actualHandleLengthException?.GetType(), Is.EqualTo(typeof(ArgumentOutOfRangeException)));
            Assert.That(actualPocketHeightException?.GetType(), Is.EqualTo(typeof(ArgumentOutOfRangeException)));
        });
    }
}