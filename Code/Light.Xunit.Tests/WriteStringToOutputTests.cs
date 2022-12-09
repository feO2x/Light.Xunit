using System;
using FluentAssertions;
using Xunit;

namespace Light.Xunit.Tests;

public sealed class WriteStringToOutputTests
{
    private OutputMock Output { get; } = new ();

    [Theory]
    [InlineData("Foo")]
    [InlineData("Bar")]
    [InlineData("Baz")]
    [InlineData("")]
    public void WriteStringToOutput(string message)
    {
        message.ShouldBeWrittenTo(Output);

        Output.CapturedMessage.Should().BeSameAs(message);
    }

    [Fact]
    public static void OutputNull()
    {
        var act = () => "Foo".ShouldBeWrittenTo(null!);

        act.Should().Throw<ArgumentNullException>()
           .And.ParamName.Should().Be("output");
    }
}