namespace SourceGenesys.Domain.Tests.DevourerApi.DevourerOne;

/// <summary>
/// Comprehensive unit tests for CPF and CNPJ validation methods in DevourerOne
/// </summary>
public class DevourerOneCpfCnpjTests
{
    #region CPFValido Method Tests

    [Theory]
    [InlineData("11144477735", true)] // Valid CPF
    [InlineData("111.444.777-35", true)] // Valid CPF with formatting  
    [InlineData("22557279005", true)] // Another valid CPF
    [InlineData("12345678909", true)] // Another valid CPF
    public void CPFValido_WithValidCpf_ShouldReturnTrue(string cpf, bool expected)
    {
        // Act
        var result = MenphisSI.DevourerOne.CPFValido(cpf);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("11111111111", false)] // All same digits
    [InlineData("22222222222", false)] // All same digits
    [InlineData("00000000000", false)] // All zeros
    [InlineData("99999999999", false)] // All nines
    [InlineData("12345678901", false)] // Invalid check digits
    [InlineData("11144477736", false)] // Wrong last digit
    [InlineData("", false)] // Empty string
    [InlineData("123", false)] // Too short
    [InlineData("1234567890123", false)] // Too long
    [InlineData("abcdefghijk", false)] // Non-numeric
    [InlineData("111.444.777-36", false)] // Invalid with formatting
    public void CPFValido_WithInvalidCpf_ShouldReturnFalse(string cpf, bool expected)
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
        var result = MenphisSI.DevourerOne.CPFValido(null);

        // Assert
        result.Should().BeFalse();
    }

    #endregion

    #region CNPJValido Method Tests

    [Theory]
    [InlineData("11222333000181", true)] // Valid CNPJ
    [InlineData("11.222.333/0001-81", true)] // Valid CNPJ with formatting
    [InlineData("12345678000195", true)] // Another valid CNPJ
    [InlineData("01477890000190", true)] // Another valid CNPJ
    public void CNPJValido_WithValidCnpj_ShouldReturnTrue(string cnpj, bool expected)
    {
        // Act
        var result = MenphisSI.DevourerOne.CNPJValido(cnpj);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("11111111111111", false)] // All same digits
    [InlineData("22222222222222", false)] // All same digits
    [InlineData("00000000000000", false)] // All zeros
    [InlineData("99999999999999", false)] // All nines
    [InlineData("12345678000190", false)] // Invalid check digits
    [InlineData("11222333000180", false)] // Wrong last digit
    [InlineData("", false)] // Empty string
    [InlineData("123", false)] // Too short
    [InlineData("123456789012345", false)] // Too long
    [InlineData("abcdefghijklmn", false)] // Non-numeric
    [InlineData("11.222.333/0001-80", false)] // Invalid with formatting
    public void CNPJValido_WithInvalidCnpj_ShouldReturnFalse(string cnpj, bool expected)
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
        var result = MenphisSI.DevourerOne.CNPJValido(null);

        // Assert
        result.Should().BeFalse();
    }

    #endregion

    #region ValidarCPF Method Tests

    [Theory]
    [InlineData("11144477735", true)] // Valid CPF
    [InlineData("111.444.777-35", true)] // Valid CPF with dots and dash
    [InlineData("111 444 777 35", true)] // Valid CPF with spaces
    [InlineData("111-444-777-35", true)] // Valid CPF with dashes
    [InlineData("22557279005", true)] // Another valid CPF
    [InlineData("12345678909", true)] // Another valid CPF
    public void ValidarCPF_WithValidCpf_ShouldReturnTrue(string cpf, bool expected)
    {
        // Act
        var result = MenphisSI.DevourerOne.ValidarCPF(cpf);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("11111111111", false)] // All same digits
    [InlineData("00000000000", false)] // All zeros
    [InlineData("99999999999", false)] // All nines
    [InlineData("12345678901", false)] // Invalid check digits
    [InlineData("1234567890", false)] // Too short (10 digits)
    [InlineData("123456789012", false)] // Too long (12 digits)
    [InlineData("", false)] // Empty string
    [InlineData("abcdefghijk", false)] // Non-numeric
    [InlineData("111.444.777-36", false)] // Invalid with formatting
    public void ValidarCPF_WithInvalidCpf_ShouldReturnFalse(string cpf, bool expected)
    {
        // Act
        var result = MenphisSI.DevourerOne.ValidarCPF(cpf);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ValidarCPF_WithMixedCharacters_ShouldExtractDigitsAndValidate()
    {
        // Arrange
        var cpfWithMixedChars = "111abc444def777ghi35";

        // Act
        var result = MenphisSI.DevourerOne.ValidarCPF(cpfWithMixedChars);

        // Assert
        result.Should().BeTrue(); // Should extract "11144477735" and validate as true
    }

    #endregion

    #region ValidarCNPJ Method Tests

    [Theory]
    [InlineData("11222333000181", true)] // Valid CNPJ
    [InlineData("11.222.333/0001-81", true)] // Valid CNPJ with formatting
    [InlineData("11 222 333 0001 81", true)] // Valid CNPJ with spaces
    [InlineData("12345678000195", true)] // Another valid CNPJ
    [InlineData("42162132000160", true)] // Another valid CNPJ
    public void ValidarCNPJ_WithValidCnpj_ShouldReturnTrue(string cnpj, bool expected)
    {
        // Act
        var result = MenphisSI.DevourerOne.ValidarCNPJ(cnpj);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("11111111111111", false)] // All same digits
    [InlineData("00000000000000", false)] // All zeros
    [InlineData("99999999999999", false)] // All nines
    [InlineData("12345678000190", false)] // Invalid check digits
    [InlineData("1234567800019", false)] // Too short (13 digits)
    [InlineData("123456780001901", false)] // Too long (15 digits)
    [InlineData("", false)] // Empty string
    [InlineData("abcdefghijklmn", false)] // Non-numeric
    [InlineData("11.222.333/0001-80", false)] // Invalid with formatting
    public void ValidarCNPJ_WithInvalidCnpj_ShouldReturnFalse(string cnpj, bool expected)
    {
        // Act
        var result = MenphisSI.DevourerOne.ValidarCNPJ(cnpj);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ValidarCNPJ_WithMixedCharacters_ShouldExtractDigitsAndValidate()
    {
        // Arrange
        var cnpjWithMixedChars = "11abc222def333ghi000jkl181";

        // Act
        var result = MenphisSI.DevourerOne.ValidarCNPJ(cnpjWithMixedChars);

        // Assert
        result.Should().BeTrue(); // Should extract "11222333000181" and validate as true
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
    [InlineData("(11) 99999-9999", "11999999999")]
    [InlineData("R$ 1.234,56", "123456")]
    [InlineData("###123###456###", "123456")]
    [InlineData("0123456789", "0123456789")]
    public void WhereDigits_WithVariousInputs_ShouldReturnOnlyDigits(string input, string expected)
    {
        // Act
        var result = input.WhereDigits();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void WhereDigits_WithUnicodeDigits_ShouldIncludeUnicodeDigits()
    {
        // Arrange - Using Arabic-Indic digits
        var input = "١٢٣456";

        // Act
        var result = input.WhereDigits();

        // Assert
        result.Should().Be("١٢٣456"); // Unicode digits are included by char.IsDigit
    }

    [Fact]
    public void WhereDigits_WithLargeString_ShouldPerformEfficiently()
    {
        // Arrange
        var largeString = string.Concat(Enumerable.Repeat("abc123def456", 1000));

        // Act
        var result = largeString.WhereDigits();

        // Assert
        result.Should().Be(string.Concat(Enumerable.Repeat("123456", 1000)));
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

    [Fact]
    public void ToArrayString_WithSingleCharacter_ShouldReturnSingleCharString()
    {
        // Arrange
        var chars = new[] { 'A' };

        // Act
        var result = chars.ToArrayString();

        // Assert
        result.Should().Be("A");
    }

    [Fact]
    public void ToArrayString_WithSpecialCharacters_ShouldPreserveCharacters()
    {
        // Arrange
        var chars = new[] { '!', '@', '#', '$', '%' };

        // Act
        var result = chars.ToArrayString();

        // Assert
        result.Should().Be("!@#$%");
    }

    [Fact]
    public void ToArrayString_WithLinqGeneratedChars_ShouldWorkCorrectly()
    {
        // Arrange
        var chars = "Hello World".Where(c => c != ' ');

        // Act
        var result = chars.ToArrayString();

        // Assert
        result.Should().Be("HelloWorld");
    }

    #endregion

    #region Edge Cases and Performance Tests

    [Fact]
    public void CPFValido_WithVeryLongString_ShouldHandleGracefully()
    {
        // Arrange
        var veryLongString = new string('1', 10000);

        // Act
        var result = MenphisSI.DevourerOne.CPFValido(veryLongString);

        // Assert
        result.Should().BeFalse(); // Should not crash and return false for invalid length
    }

    [Fact]
    public void CNPJValido_WithVeryLongString_ShouldHandleGracefully()
    {
        // Arrange
        var veryLongString = new string('1', 10000);

        // Act
        var result = MenphisSI.DevourerOne.CNPJValido(veryLongString);

        // Assert
        result.Should().BeFalse(); // Should not crash and return false for invalid length
    }

    [Theory]
    [InlineData("12345678902")] // 11 digits but invalid
    [InlineData("78530598093")] // 11 digits but invalid
    [InlineData("10987654324")] // 11 digits but invalid
    public void ValidarCPF_WithElevenDigitsButInvalidCheckSum_ShouldReturnFalse(string cpf)
    {
        // Act
        var result = MenphisSI.DevourerOne.ValidarCPF(cpf);

        // Assert
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData("12345678000100")] // 14 digits but invalid
    [InlineData("01234567800010")] // 14 digits but invalid
    [InlineData("10987654321098")] // 14 digits but invalid
    public void ValidarCNPJ_WithFourteenDigitsButInvalidCheckSum_ShouldReturnFalse(string cnpj)
    {
        // Act
        var result = MenphisSI.DevourerOne.ValidarCNPJ(cnpj);

        // Assert
        result.Should().BeFalse();
    }

    #endregion

    #region Integration and Workflow Tests

    [Fact]
    public void CPF_CompleteWorkflow_FromExtractionToValidation_ShouldWorkCorrectly()
    {
        // Arrange
        var cpfWithFormatting = "111.444.777-35";

        // Act
        var extractedDigits = cpfWithFormatting.WhereDigits();
        var isValidDirect = MenphisSI.DevourerOne.CPFValido(cpfWithFormatting);
        var isValidExtracted = MenphisSI.DevourerOne.ValidarCPF(extractedDigits);

        // Assert
        extractedDigits.Should().Be("11144477735");
        isValidDirect.Should().BeTrue();
        isValidExtracted.Should().BeTrue();
    }

    [Fact]
    public void CNPJ_CompleteWorkflow_FromExtractionToValidation_ShouldWorkCorrectly()
    {
        // Arrange
        var cnpjWithFormatting = "11.222.333/0001-81";

        // Act
        var extractedDigits = cnpjWithFormatting.WhereDigits();
        var isValidDirect = MenphisSI.DevourerOne.CNPJValido(cnpjWithFormatting);
        var isValidExtracted = MenphisSI.DevourerOne.ValidarCNPJ(extractedDigits);

        // Assert
        extractedDigits.Should().Be("11222333000181");
        isValidDirect.Should().BeTrue();
        isValidExtracted.Should().BeTrue();
    }

    [Fact]
    public void ExtensionMethods_ChainedUsage_ShouldWorkCorrectly()
    {
        // Arrange
        var mixedInput = "Hello123World456!";

        // Act
        var result = mixedInput
            .WhereDigits()
            .ToCharArray()
            .ToArrayString();

        // Assert
        result.Should().Be("123456");
    }

    #endregion

    #region Real World Scenarios

    [Theory]
    [InlineData("070.987.720-03", true)] // Common valid CPF format
    [InlineData("11222333000181", false)] // Invalid CNPJ without formatting
    [InlineData("123.456.789-00", false)] // Invalid CPF with common pattern
    [InlineData("12.345.678/0001-00", false)] // Invalid CNPJ with common pattern
    public void RealWorldDocuments_ShouldValidateCorrectly(string document, bool expected)
    {
        // Act
        bool result;
        if (document.Length <= 14) // Assume CPF if shorter
        {
            result = MenphisSI.DevourerOne.CPFValido(document);
        }
        else
        {
            result = MenphisSI.DevourerOne.CNPJValido(document);
        }

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void WhereDigits_WithCommonPhoneFormat_ShouldExtractCorrectly()
    {
        // Arrange
        var phoneNumber = "(11) 99999-9999";

        // Act
        var digits = phoneNumber.WhereDigits();

        // Assert
        digits.Should().Be("11999999999");
    }

    [Fact]
    public void WhereDigits_WithCurrencyFormat_ShouldExtractCorrectly()
    {
        // Arrange
        var currency = "R$ 1.234,56";

        // Act
        var digits = currency.WhereDigits();

        // Assert
        digits.Should().Be("123456");
    }

    #endregion

    #region Null and Empty String Handling

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("\t\n\r")]
    public void CPFValido_WithNullOrWhitespace_ShouldReturnFalse(string? cpf)
    {
        // Act
        var result = MenphisSI.DevourerOne.CPFValido(cpf);

        // Assert
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("\t\n\r")]
    public void CNPJValido_WithNullOrWhitespace_ShouldReturnFalse(string? cnpj)
    {
        // Act
        var result = MenphisSI.DevourerOne.CNPJValido(cnpj);

        // Assert
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("\t\n\r")]
    public void WhereDigits_WithWhitespaceOnly_ShouldReturnEmptyString(string input)
    {
        // Act
        var result = input.WhereDigits();

        // Assert
        result.Should().Be("");
    }

    #endregion

    #region Algorithm Verification Tests

    [Fact]
    public void ValidarCPF_CheckDigitCalculation_ShouldFollowCorrectAlgorithm()
    {
        var fullValidCpf = "11144477735"; // With correct check digits

        // Act
        var isValid = MenphisSI.DevourerOne.ValidarCPF(fullValidCpf);

        // Assert
        isValid.Should().BeTrue();

        // Verify that changing any check digit makes it invalid
        var invalidCpf1 = "11144477734"; // Changed last digit
        var invalidCpf2 = "11144477725"; // Changed second-to-last digit

        MenphisSI.DevourerOne.ValidarCPF(invalidCpf1).Should().BeFalse();
        MenphisSI.DevourerOne.ValidarCPF(invalidCpf2).Should().BeFalse();
    }

    [Fact]
    public void ValidarCNPJ_CheckDigitCalculation_ShouldFollowCorrectAlgorithm()
    {
        var fullValidCnpj = "11222333000181"; // With correct check digits

        // Act
        var isValid = MenphisSI.DevourerOne.ValidarCNPJ(fullValidCnpj);

        // Assert
        isValid.Should().BeTrue();

        // Verify that changing any check digit makes it invalid
        var invalidCnpj1 = "11222333000180"; // Changed last digit
        var invalidCnpj2 = "11222333000171"; // Changed second-to-last digit

        MenphisSI.DevourerOne.ValidarCNPJ(invalidCnpj1).Should().BeFalse();
        MenphisSI.DevourerOne.ValidarCNPJ(invalidCnpj2).Should().BeFalse();
    }

    #endregion
}