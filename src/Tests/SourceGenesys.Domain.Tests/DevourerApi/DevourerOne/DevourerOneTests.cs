namespace SourceGenesys.Domain.Tests.DevourerApi.DevourerOne;

public class DevourerOneTests
{
    #region PopupBox Tests

    [Fact]
    public void PopupBox_WithValidTabAndMessage_ShouldWriteToConsole()
    {
        // Arrange
        var originalOut = Console.Out;
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        var tab = "Tab1";
        var message = "Test message";

        // Act
        tab.PopupBox(message);

        // Assert
        var output = stringWriter.ToString();
        output.Should().Be("Tab1 Test message");
        
        // Cleanup
        Console.SetOut(originalOut);
    }

    [Fact]
    public void PopupBox_WithNullTab_ShouldWriteMessageWithSpacePrefix()
    {
        // Arrange
        var originalOut = Console.Out;
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        string? tab = null;
        var message = "Test message";

        // Act
        tab.PopupBox(message);

        // Assert
        var output = stringWriter.ToString();
        output.Should().Be(" Test message");
        
        // Cleanup
        Console.SetOut(originalOut);
    }

    [Fact]
    public void PopupBox_WithEmptyTab_ShouldWriteMessageWithSpacePrefix()
    {
        // Arrange
        var originalOut = Console.Out;
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        var tab = "";
        var message = "Test message";

        // Act
        tab.PopupBox(message);

        // Assert
        var output = stringWriter.ToString();
        output.Should().Be(" Test message");
        
        // Cleanup
        Console.SetOut(originalOut);
    }

    #endregion

    #region InteropOperId32 Tests

    [Fact]
    public void InteropOperId32_ShouldAlwaysReturnOne()
    {
        // Act
        var result = MenphisSI.DevourerOne.InteropOperId32();

        // Assert
        result.Should().Be(1);
    }

    #endregion

    #region ExplodeErrorWindows Tests

    [Fact]
    public void ExplodeErrorWindows_WithValidParameters_ShouldThrowExceptionWithFormattedMessage()
    {
        // Arrange
        var tabela = "TestTable";
        var texto = "Error occurred";
        var errorDescription = "Database connection failed";
        var cSql = "SELECT * FROM TestTable";

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => 
            MenphisSI.DevourerOne.ExplodeErrorWindows(tabela, texto, errorDescription, cSql));
        
        exception.Message.Should().Be("Error occurred : Database connection failed - Erro sql: [SELECT * FROM TestTable]");
    }

    [Fact]
    public void ExplodeErrorWindows_WithEmptyParameters_ShouldThrowExceptionWithEmptyValues()
    {
        // Arrange
        var tabela = "";
        var texto = "";
        var errorDescription = "";
        var cSql = "";

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => 
            MenphisSI.DevourerOne.ExplodeErrorWindows(tabela, texto, errorDescription, cSql));
        
        exception.Message.Should().Be(" :  - Erro sql: []");
    }

    #endregion

    #region ClassRating Tests

    [Theory]
    [InlineData("6", 0)]
    [InlineData("1", 7)]
    [InlineData("A", 6)]
    [InlineData("B", 5)]
    [InlineData("C", 4)]
    [InlineData("D", 3)]
    [InlineData("E", 2)]
    [InlineData("Z", 1)]
    public void ClassRating_WithValidClass_ShouldReturnCorrectRating(string cClass, int expectedRating)
    {
        // Act
        var result = MenphisSI.DevourerOne.ClassRating(cClass);

        // Assert
        result.Should().Be(expectedRating);
    }

    [Theory]
    [InlineData("X")]
    [InlineData("")]
    [InlineData("InvalidClass")]
    [InlineData("a")] // lowercase
    [InlineData("2")]
    public void ClassRating_WithInvalidClass_ShouldReturnDefaultRating(string cClass)
    {
        // Act
        var result = MenphisSI.DevourerOne.ClassRating(cClass);

        // Assert
        result.Should().Be(1);
    }

    #endregion

    #region ConvertString2Decimal Tests

    [Theory]
    [InlineData("123,45", 123.45)]
    [InlineData("1000,50", 1000.50)]
    [InlineData("0", 0)]
    [InlineData("999999", 999999)]
    [InlineData("1234567,89", 1234567.89)]
    public void ConvertString2Decimal_WithValidNumericString_ShouldReturnCorrectDecimal(string value, decimal expected)
    {
        // Act
        var result = MenphisSI.DevourerOne.ConvertString2Decimal(value);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("", 0)]
    [InlineData("abc", 0)]
    [InlineData("12.34.56", 123456)]
    [InlineData("invalid", 0)]
    [InlineData("12abc", 0)]
    public void ConvertString2Decimal_WithInvalidString_ShouldReturnZero(string value, decimal retValue)
    {
        // Act
        var result = MenphisSI.DevourerOne.ConvertString2Decimal(value);

        // Assert
        result.Should().Be(retValue);
    }

    [Fact]
    public void ConvertString2Decimal_WithNullString_ShouldReturnZero()
    {
        // Act
        var result = MenphisSI.DevourerOne.ConvertString2Decimal(null!);

        // Assert
        result.Should().Be(0);
    }

    #endregion

    #region MaskCep Tests

    [Theory]
    [InlineData("01234567", "01.234-567")]
    [InlineData("12345678", "12.345-678")]
    [InlineData("00000000", "00.000-000")]
    [InlineData("99999999", "99.999-999")]
    public void MaskCep_WithValidEightDigitCep_ShouldReturnFormattedCep(string cep, string expected)
    {
        // Act
        var result = cep.MaskCep();

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("1234567")] // 7 digits
    [InlineData("123456789")] // 9 digits
    [InlineData("")]
    [InlineData("abc")]
    [InlineData("12-345-67")]
    public void MaskCep_WithInvalidCep_ShouldReturnOriginalValue(string cep)
    {
        // Act
        var result = cep.MaskCep();

        // Assert
        result.Should().Be(cep);
    }

    [Fact]
    public void MaskCep_WithNullOrEmptyString_ShouldReturnEmpty()
    {
        // Act
        var resultNull = ((string)null!).MaskCep();
        var resultEmpty = "".MaskCep();

        // Assert
        resultNull.Should().Be("");
        resultEmpty.Should().Be("");
    }

    #endregion

    #region MaskCpf Tests

    [Fact]
    public void MaskCpf_WithValidCpf_ShouldReturnFormattedCpf()
    {
        // Arrange
        var cpf = "22557279005";

        // Act
        var result = cpf.MaskCpf();

        // Assert
        result.Should().Be("225.572.790-05");
    }

    [Fact]
    public void MaskCpf_WithInvalidCpf_ShouldReturnOriginalValue()
    {
        // Arrange
        var cpf = "123456789"; // Invalid length

        // Act
        var result = cpf.MaskCpf();

        // Assert
        result.Should().Be(cpf);
    }

    [Fact]
    public void MaskCpf_WithNullCpf_ShouldReturnEmpty()
    {
        // Act
        var result = ((string)null!).MaskCpf();

        // Assert
        result.Should().Be("");
    }

    #endregion

    #region MaskCnpj Tests

    [Fact]
    public void MaskCnpj_WithValidCnpj_ShouldReturnFormattedCnpj()
    {
        // Arrange
        var cnpj = "12345678000190";

        // Act
        var result = cnpj.MaskCnpj();

        // Assert
        result.Should().Be("12.345.678/0001-90");
    }

    [Theory]
    [InlineData("123456789")] // Too short
    [InlineData("123456789012345")] // Too long
    [InlineData("")]
    [InlineData("abc")]
    public void MaskCnpj_WithInvalidCnpj_ShouldReturnOriginalValue(string cnpj)
    {
        // Act
        var result = cnpj.MaskCnpj();

        // Assert
        result.Should().Be(cnpj);
    }

    [Fact]
    public void MaskCnpj_WithNullCnpj_ShouldReturnEmpty()
    {
        // Act
        var result = ((string)null!).MaskCnpj();

        // Assert
        result.Should().Be("");
    }

    #endregion

    #region IsCpf Tests

    [Theory]
    [InlineData("11144477735", true)] // Valid CPF
    [InlineData("111.444.777-35", true)] // Valid CPF with formatting
    [InlineData("11111111111", false)] // Invalid sequence
    [InlineData("12345678901", false)] // Invalid CPF
    [InlineData("", false)] // Empty
    [InlineData("123", false)] // Too short
    public void IsCpf_WithVariousCpfFormats_ShouldReturnCorrectValidation(string cpf, bool expected)
    {
        // Act
        var result = cpf.IsCpf();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void IsCpf_WithNullCpf_ShouldReturnFalse()
    {
        // Act
        var result = ((string)null!).IsCpf();

        // Assert
        result.Should().BeFalse();
    }

    #endregion

    #region CPFValido Tests

    [Theory]
    [InlineData("11144477735", true)] // Valid CPF
    [InlineData("111.444.777-35", true)] // Valid CPF with formatting
    [InlineData("11111111111", false)] // Invalid sequence
    [InlineData("00000000000", false)] // Invalid sequence
    [InlineData("12345678901", false)] // Invalid CPF
    [InlineData("", false)] // Empty
    [InlineData("123", false)] // Too short
    [InlineData("1234567890123", false)] // Too long
    public void CPFValido_WithVariousCpfValues_ShouldReturnCorrectValidation(string cpf, bool expected)
    {
        // Act
        var result = MenphisSI.DevourerOne.CPFValido(cpf);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void CPFValido_WithNullCpf_ShouldReturnFalse()
    {
        // Act
        var result = MenphisSI.DevourerOne.CPFValido(null!);

        // Assert
        result.Should().BeFalse();
    }

    #endregion

    #region CNPJValido Tests

    [Theory]
    [InlineData("11222333000181", true)] // Valid CNPJ
    [InlineData("11.222.333/0001-81", true)] // Valid CNPJ with formatting
    [InlineData("11111111111111", false)] // Invalid sequence
    [InlineData("00000000000000", false)] // Invalid sequence
    [InlineData("12345678000195", true)] // Invalid CNPJ
    [InlineData("", false)] // Empty
    [InlineData("123", false)] // Too short
    [InlineData("123456789012345", false)] // Too long
    public void CNPJValido_WithVariousCnpjValues_ShouldReturnCorrectValidation(string cnpj, bool expected)
    {
        // Act
        var result = MenphisSI.DevourerOne.CNPJValido(cnpj);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void CNPJValido_WithNullCnpj_ShouldReturnFalse()
    {
        // Act
        var result = MenphisSI.DevourerOne.CNPJValido(null!);

        // Assert
        result.Should().BeFalse();
    }

    #endregion

    #region WhereDigits Extension Method Tests

    [Theory]
    [InlineData("123abc456", "123456")]
    [InlineData("!@#123$%^", "123")]
    [InlineData("", "")]
    [InlineData("abcdef", "")]
    [InlineData("123.456.789-01", "12345678901")]
    [InlineData("12.345.678/0001-90", "12345678000190")]
    public void WhereDigits_WithVariousInputs_ShouldReturnOnlyDigits(string input, string expected)
    {
        // Act
        var result = input.WhereDigits();

        // Assert
        result.Should().Be(expected);
    }

    #endregion

    #region ToArrayString Extension Method Tests

    [Fact]
    public void ToArrayString_WithCharEnumerable_ShouldReturnString()
    {
        // Arrange
        var chars = new[] { 'H', 'e', 'l', 'l', 'o' };

        // Act
        var result = chars.ToArrayString();

        // Assert
        result.Should().Be("Hello");
    }

    [Fact]
    public void ToArrayString_WithEmptyEnumerable_ShouldReturnEmptyString()
    {
        // Arrange
        var chars = Array.Empty<char>();

        // Act
        var result = chars.ToArrayString();

        // Assert
        result.Should().Be("");
    }

    #endregion

    #region Integration Tests

    [Fact]
    public void CpfValidationWorkflow_FromMaskingToValidation_ShouldWorkCorrectly()
    {
        // Arrange
        var rawCpf = "11144477735";

        // Act
        var maskedCpf = rawCpf.MaskCpf();
        var isValid = maskedCpf.IsCpf();

        // Assert
        maskedCpf.Should().Be("111.444.777-35");
        isValid.Should().BeTrue();
    }

    [Fact]
    public void CnpjValidationWorkflow_FromMaskingToValidation_ShouldWorkCorrectly()
    {
        // Arrange
        var rawCnpj = "11222333000181";

        // Act
        var maskedCnpj = rawCnpj.MaskCnpj();
        var isValid = MenphisSI.DevourerOne.CNPJValido(maskedCnpj);

        // Assert
        maskedCnpj.Should().Be("11.222.333/0001-81");
        isValid.Should().BeTrue();
    }

    [Fact]
    public void CepMaskingWorkflow_ShouldFormatCorrectly()
    {
        // Arrange
        var rawCep = "01234567";

        // Act
        var maskedCep = rawCep.MaskCep();

        // Assert
        maskedCep.Should().Be("01.234-567");
    }

    #endregion
}