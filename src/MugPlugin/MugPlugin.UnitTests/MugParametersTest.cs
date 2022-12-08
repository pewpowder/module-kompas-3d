using NUnit.Framework;
using MugPlugin.Model;

namespace MugPlugin.UnitTests;

[TestFixture]
public class MugParametersTest
{
    //const double height = 100;
    //const double firstExpectedValue = 100 * 0.7;
    //const double secondExpectedValue = 100 * 0.7 * 0.5;

    //var actual = _parameters.GetDependentValues(height);

    //Assert.That(actual[0], Is.EqualTo(firstExpectedValue));
    //Assert.That(actual[1], Is.EqualTo(secondExpectedValue));

    private readonly MugParameters _parameters = new MugParameters();

    [Test(Description = "Positive test set parameter value.")]
    public void TestGetDependentValues_CorrectValues()
    {
        const double expected = ;
        _parameters.
    }
}