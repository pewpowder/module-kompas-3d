using NUnit.Framework;
using MugPlugin.Model;

namespace MugPlugin.UnitTests;

[TestFixture]
public class MugParameterTest
{
    private const double MIN_VALUE = 10;
    private const double MAX_VALUE = 15;

    [Test(Description = "Positive getter test.")]
    public void TestValueGet_CorrectValue()
    {
        const double expected = 12;

        var mugParameter = new MugParameter(12, MIN_VALUE, MAX_VALUE);
        var actual = mugParameter.Value;

        Assert.That(actual, Is.EqualTo(expected));
    }


    [Test(Description = "Negative getter test. Value less then minValue")]
    public void TestMinValueSet_IncorrectValue()
    {
        const double value = 5;

        var actual = Assert.Throws<ArgumentOutOfRangeException>(() => new MugParameter(value, MIN_VALUE, MAX_VALUE));
        var expected = $"Value must be between {MIN_VALUE} and {MAX_VALUE}";

        Assert.That(actual?.ParamName, Is.EqualTo(expected));
    }



    [Test(Description = "Negative getter test. Value bigger then maxValue")]
    public void TestValueMaxSet_IncorrectValue()
    {
        const double value = 20;

        var actual = Assert.Throws<ArgumentOutOfRangeException>(() => new MugParameter(value, MIN_VALUE, MAX_VALUE));
        var expected = $"Value must be between {MIN_VALUE} and {MAX_VALUE}";

        Assert.That(actual?.GetType(), Is.EqualTo(typeof(ArgumentOutOfRangeException)));
    }

}