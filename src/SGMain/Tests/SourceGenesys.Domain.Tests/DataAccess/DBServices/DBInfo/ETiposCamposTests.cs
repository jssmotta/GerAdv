namespace SourceGenesys.Domain.Tests.DataAccess.DBServices.DBInfo;

public class ETiposCamposTests
{
    [Theory]
    [InlineData(ETiposCampos.FNumber, 0)]
    [InlineData(ETiposCampos.FDate, 1)]
    [InlineData(ETiposCampos.FString, 2)]
    [InlineData(ETiposCampos.FBoolean, 3)]
    [InlineData(ETiposCampos.FMemo, 4)]
    [InlineData(ETiposCampos.FDouble, 5)]
    [InlineData(ETiposCampos.FNow, 6)]
    [InlineData(ETiposCampos.FNumberNull, 7)]
    [InlineData(ETiposCampos.FDoubleNotNull, 8)]
    [InlineData(ETiposCampos.FDateUltraFull, 9)]
    [InlineData(ETiposCampos.FDecimal, 10)]
    [InlineData(ETiposCampos.FByte, 11)]
    [InlineData(ETiposCampos.FByteArray, 12)]
    public void ETiposCampos_Should_Have_Expected_Values(ETiposCampos campo, int expectedValue)
    {
        ((int)campo).Should().Be(expectedValue);
    }

    [Fact]
    public void ETiposCampos_Should_Be_Serializable()
    {
        var campo = ETiposCampos.FString;
        var type = campo.GetType();
        var isSerializable = type.IsSerializable;
        isSerializable.Should().BeTrue();
    }
}
