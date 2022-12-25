using NUnit.Framework;
using MugPlugin.Model;

namespace MugPlugin.UnitTests;

[TestFixture]
public class MugParameterTest
{
    [Test(Description = "Positive getter test.")]
    public void TestValueGet_CorrectValue()
    {
        const double expected = 5;

        var mugParameter = new MugParameter(5, 1, 10);
        var actual = mugParameter.Value;

        Assert.That(actual, Is.EqualTo(expected));
    }


    [Test(Description = "Negative getter test. Value less then minValue")]
    public void TestMinValueSet_IncorrectValue()
    {
        const double minValue = 10;
        const double maxValue = 15;
        const double value = 5;

        var actual = Assert.Throws<ArgumentOutOfRangeException>(() => new MugParameter(value, minValue, maxValue));
        var expected = $"Value must be between {minValue} and {maxValue}";

        Assert.That(actual?.ParamName, Is.EqualTo(expected));
    }



    [Test(Description = "Negative getter test. Value bigger then maxValue")]
    public void TestValueMaxSet_IncorrectValue()
    {
        const double minValue = 10;
        const double maxValue = 15;
        const double value = 20;

        var actual = Assert.Throws<ArgumentOutOfRangeException>(() => new MugParameter(value, minValue, maxValue));
        var expected = $"Value must be between {minValue} and {maxValue}";

        Assert.That(actual?.GetType(), Is.EqualTo(typeof(ArgumentOutOfRangeException)));
    }

}