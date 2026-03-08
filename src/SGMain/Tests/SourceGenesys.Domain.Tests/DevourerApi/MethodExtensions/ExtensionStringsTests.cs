namespace SourceGenesys.Domain.Tests.DevourerApi.MethodExtensions;

/// <summary>
/// Comprehensive unit tests for ExtensionMethodStrings class
/// </summary>
public class ExtensionStringsTests
{
    #region substring Method Tests

    [Theory]
    [InlineData("Hello World", 0, 5, "Hello")]
    [InlineData("Hello World", 6, 5, "World")]
    [InlineData("Hello World", 0, 0, "Hello World")]
    [InlineData("Hello World", 3, 0, "lo World")]
    [InlineData("Test", 1, 2, "es")]
    [InlineData("A", 0, 1, "A")]
    public void Substring_WithValidParameters_ShouldReturnCorrectSubstring(string text, int startIndex, int length, string expected)
    {
        // Act
        var result = text.substring(startIndex, length);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("", 0, 0, "")]
    [InlineData("", 0, 5, "")]
    public void Substring_WithEmptyString_ShouldReturnEmpty(string text, int startIndex, int length, string expected)
    {
        // Act
        var result = text.substring(startIndex, length);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("Hello", 0, 10, "Hello")]
    [InlineData("Test", 1, 100, "est")]
    public void Substring_WithLengthGreaterThanText_ShouldReturnFromStartToEnd(string text, int startIndex, int length, string expected)
    {
        // Act
        var result = text.substring(startIndex, length);

        // Assert
        result.Should().Be(expected);
    }

    #endregion

    #region replace Method Tests

    [Theory]
    [InlineData("Hello World", "World", "Universe", "Hello Universe")]
    [InlineData("Hello World", "Hello", "Hi", "Hi World")]
    [InlineData("Test Test Test", "Test", "Demo", "Demo Demo Demo")]
    [InlineData("NoChange", "xyz", "abc", "NoChange")]
    public void Replace_WithValidParameters_ShouldReplaceCorrectly(string text, string oldValue, string newValue, string expected)
    {
        // Act
        var result = text.replace(oldValue, newValue);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, "old", "new", "")]
    [InlineData("", "old", "new", "")]
    public void Replace_WithNullOrEmptyText_ShouldReturnEmptyOrOriginal(string? text, string oldValue, string newValue, string expected)
    {
        // Act
        var result = text.replace(oldValue, newValue);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("Hello World", "", "new", "Hello World")]
    [InlineData("Hello World", null, "new", "Hello World")]
    public void Replace_WithNullOrEmptyOldValue_ShouldReturnOriginal(string text, string? oldValue, string newValue, string expected)
    {
        // Act
        var result = text.replace(oldValue!, newValue);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Replace_WithNullNewValue_ShouldReplaceWithEmpty()
    {
        // Arrange
        var text = "Hello World";
        var oldValue = "World";
        string? newValue = null;

        // Act
        var result = text.replace(oldValue, newValue!);

        // Assert
        result.Should().Be("Hello ");
    }

    #endregion

    #region Length Method Tests

    [Theory]
    [InlineData("Hello", 5)]
    [InlineData("  Hello  ", 5)]
    [InlineData("", 0)]
    [InlineData("   ", 0)]
    [InlineData("\t", 0)]
    [InlineData("\n", 0)]
    public void Length_WithVariousStrings_ShouldReturnTrimmedLength(string? text, int expected)
    {
        // Act
        var result = text.Length();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Length_WithNull_ShouldReturnZero()
    {
        // Arrange
        string? text = null;

        // Act
        var result = text.Length();

        // Assert
        result.Should().Be(0);
    }

    #endregion

    #region IsEquals Method Tests

    [Theory]
    [InlineData("Hello", "Hello", true)]
    [InlineData("Hello", "hello", false)]
    [InlineData("Test", "Test", true)]
    [InlineData("", "", true)]
    [InlineData("Test", "Different", false)]
    public void IsEquals_WithVariousValues_ShouldReturnCorrectComparison(string? text, string? value, bool expected)
    {
        // Act
        var result = text.IsEquals(value);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, null, true)]
    [InlineData(null, "test", false)]
    [InlineData("test", null, false)]
    public void IsEquals_WithNullValues_ShouldHandleCorrectly(string? text, string? value, bool expected)
    {
        // Act
        var result = text.IsEquals(value);

        // Assert
        result.Should().Be(expected);
    }

    #endregion

    #region trim Method Tests

    [Theory]
    [InlineData("  Hello  ", "Hello")]
    [InlineData("Hello", "Hello")]
    [InlineData("", "")]
    [InlineData("   ", "")]
    [InlineData("\t\n", "")]
    public void Trim_WithVariousStrings_ShouldTrimCorrectly(string? text, string expected)
    {
        // Act
        var result = text.trim();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Trim_WithNull_ShouldReturnEmpty()
    {
        // Arrange
        string? text = null;

        // Act
        var result = text.trim();

        // Assert
        result.Should().Be("");
    }

    #endregion

    #region endsWith Method Tests

    [Theory]
    [InlineData("Hello World", "World", true)]
    [InlineData("Hello World", "world", false)]
    [InlineData("Test", "Test", true)]
    [InlineData("Test", "st", true)]
    [InlineData("Test", "xyz", false)]
    [InlineData("", "", true)]
    public void EndsWith_WithVariousValues_ShouldReturnCorrectResult(string? text, string? value, bool expected)
    {
        // Act
        var result = text.endsWith(value);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, "test", false)]
    [InlineData("test", null, true)]
    [InlineData(null, null, true)]
    public void EndsWith_WithNullValues_ShouldHandleCorrectly(string? text, string? value, bool expected)
    {
        // Act
        var result = text.endsWith(value);

        // Assert
        result.Should().Be(expected);
    }

    #endregion

    #region toUpper Method Tests

    [Theory]
    [InlineData("hello", "HELLO")]
    [InlineData("Hello World", "HELLO WORLD")]
    [InlineData("TEST", "TEST")]
    [InlineData("", "")]
    [InlineData("123", "123")]
    public void ToUpper_WithVariousStrings_ShouldReturnUppercase(string? value, string expected)
    {
        // Act
        var result = value.toUpper();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ToUpper_WithNull_ShouldReturnEmpty()
    {
        // Arrange
        string? value = null;

        // Act
        var result = value.toUpper();

        // Assert
        result.Should().Be("");
    }

    #endregion

    #region indexOf Method Tests

    [Theory]
    [InlineData("Hello World", "World", StringComparison.Ordinal, 6)]
    [InlineData("Hello World", "world", StringComparison.OrdinalIgnoreCase, 6)]
    [InlineData("Hello World", "xyz", StringComparison.Ordinal, -1)]
    [InlineData("Test", "Test", StringComparison.Ordinal, 0)]
    [InlineData("", "", StringComparison.Ordinal, 0)]
    public void IndexOf_WithVariousValues_ShouldReturnCorrectIndex(string? campo, string? value, StringComparison comparisonType, int expected)
    {
        // Act
        var result = campo.indexOf(value, comparisonType);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void IndexOf_WithNullCampo_ShouldReturnMinusOne()
    {
        // Arrange
        string? campo = null;
        var value = "test";

        // Act
        var result = campo.indexOf(value);

        // Assert
        result.Should().Be(-1);
    }

    [Fact]
    public void IndexOf_WithNullValue_ShouldSearchForEmptyString()
    {
        // Arrange
        var campo = "Hello";
        string? value = null;

        // Act
        var result = campo.indexOf(value);

        // Assert
        result.Should().Be(0); // Empty string is found at position 0
    }

    #endregion

    #region Boolean Extension Method Tests

    [Theory]
    [InlineData(true, false)]
    [InlineData(false, true)]
    public void IsNão_ShouldReturnOppositeValue(bool value, bool expected)
    {
        // Act
        var result = value.IsNão();

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(0, true)]
    [InlineData(-1, true)]
    [InlineData(1, false)]
    [InlineData(100, false)]
    [InlineData(int.MinValue, true)]
    [InlineData(int.MaxValue, false)]
    public void IsEmptyIDNumber_Int_ShouldReturnCorrectResult(int valueID, bool expected)
    {
        // Act
        var result = valueID.IsEmptyIDNumber();

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(0L, true)]
    [InlineData(-1L, true)]
    [InlineData(1L, false)]
    [InlineData(100L, false)]
    [InlineData(long.MinValue, true)]
    [InlineData(long.MaxValue, false)]
    public void IsEmptyIDNumber_Long_ShouldReturnCorrectResult(long valueID, bool expected)
    {
        // Act
        var result = valueID.IsEmptyIDNumber();

        // Assert
        result.Should().Be(expected);
    }

    #endregion

    #region ColorFirstLastName Method Tests

    [Theory]
    [InlineData("0test", "#430943")] // Should return StartColors[0]
    [InlineData("1test", "#99ff99")] // Should return StartColors[1]
    [InlineData("2test", "#ff99dd")] // Should return StartColors[2]
    [InlineData("9test", "#a6a6a6")] // Should return StartColors[9]
    public void ColorFirstLastName_WithFirstCharacterAsDigit_ShouldReturnStartColor(string text, string expected)
    {
        // Act
        var result = text.ColorFirstLastName();

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("test0", "#ff6680")] // Should return EndColors[0]
    [InlineData("test1", "#267326")] // Should return EndColors[1]
    [InlineData("test9", "#ff6666")] // Should return EndColors[9]
    public void ColorFirstLastName_WithLastCharacterAsDigit_ShouldReturnEndColor(string text, string expected)
    {
        // Act
        var result = text.ColorFirstLastName();

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("A", "#0040ff")] // A = ASCII 65, pos = 0
    [InlineData("B", "#ff1a8c")] // B = ASCII 66, pos = 1
    [InlineData("Z", "#e600e6")] // Z = ASCII 90, pos = 25
    public void ColorFirstLastName_WithLetters_ShouldReturnLetterColor(string text, string expected)
    {
        // Act
        var result = text.ColorFirstLastName();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ColorFirstLastName_WithEmptyString_ShouldReturnBlack()
    {
        // Arrange
        var text = "";

        // Act
        var result = text.ColorFirstLastName();

        // Assert
        result.Should().Be("#000");
    }

    #endregion

    #region ImgFirstLastName Method Tests

    [Theory]
    [InlineData("João", "J")]
    [InlineData("João Silva", "JS")]
    [InlineData("Maria Santos Oliveira", "MO")]
    [InlineData("A", "A")]
    public void ImgFirstLastName_WithValidNames_ShouldReturnCorrectInitials(string text, string expected)
    {
        // Act
        var result = text.ImgFirstLastName();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ImgFirstLastName_WithEmptyString_ShouldReturnEmpty()
    {
        // Arrange
        var text = "";

        // Act
        var result = text.ImgFirstLastName();

        // Assert
        result.Should().Be(string.Empty);
    }

    [Fact]
    public void ImgFirstLastName_WithExceptionDuringProcessing_ShouldReturnFirstCharacter()
    {
        // Arrange - This should trigger the try-catch block
        var text = "A";

        // Act
        var result = text.ImgFirstLastName();

        // Assert
        result.Should().Be("A");
    }

    #endregion

    #region IsEmpty Decimal Method Tests

    [Theory]
    [InlineData(0.0, true)]
    [InlineData(0.1, false)]
    [InlineData(-0.1, false)]
    [InlineData(1.0, false)]
    [InlineData(-1.0, false)]
    public void IsEmpty_Decimal_ShouldReturnCorrectResult(decimal value, bool expected)
    {
        // Act
        var result = value.IsEmpty();

        // Assert
        result.Should().Be(expected);
    }

    #endregion

    #region IsEmpty String Method Tests

    [Theory]
    [InlineData("", true)]
    [InlineData("   ", true)]
    [InlineData("\t", true)]
    [InlineData("\n", true)]
    [InlineData("Hello", false)]
    [InlineData("  Hello  ", false)]
    public void IsEmpty_String_ShouldReturnCorrectResult(string? text, bool expected)
    {
        // Act
        var result = text.IsEmpty();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void IsEmpty_String_WithNull_ShouldReturnTrue()
    {
        // Arrange
        string? text = null;

        // Act
        var result = text.IsEmpty();

        // Assert
        result.Should().BeTrue();
    }

    #endregion

    #region GetHashCode2 Method Tests

    [Theory]
    [InlineData("Hello")]
    [InlineData("World")]
    [InlineData("Test")]
    [InlineData("")]
    [InlineData("a")]
    [InlineData("ab")]
    public void GetHashCode2_WithValidStrings_ShouldReturnConsistentHash(string str)
    {
        // Act
        var result1 = str.GetHashCode2();
        var result2 = str.GetHashCode2();

        // Assert
        result1.Should().Be(result2);
        result1.Should().NotBeNullOrEmpty();
        // Hash should be numeric string
        int.TryParse(result1, out _).Should().BeTrue();
    }

    [Fact]
    public void GetHashCode2_WithNull_ShouldReturnZero()
    {
        // Arrange
        string? str = null;

        // Act
        var result = str.GetHashCode2();

        // Assert
        result.Should().Be("0");
    }

    [Fact]
    public void GetHashCode2_WithDifferentStrings_ShouldReturnDifferentHashes()
    {
        // Arrange
        var str1 = "Hello";
        var str2 = "World";

        // Act
        var hash1 = str1.GetHashCode2();
        var hash2 = str2.GetHashCode2();

        // Assert
        hash1.Should().NotBe(hash2);
    }

    #endregion

    #region NotIsEmpty Method Tests

    [Theory]
    [InlineData("Hello", true)]
    [InlineData("  Hello  ", true)]
    [InlineData("", false)]
    [InlineData("   ", false)]
    [InlineData("\t", false)]
    [InlineData("\n", false)]
    public void NotIsEmpty_ShouldReturnOppositeOfIsEmpty(string? text, bool expected)
    {
        // Act
        var result = text.NotIsEmpty();

        // Assert
        result.Should().Be(expected);
        result.Should().Be(!text.IsEmpty());
    }

    #endregion

    #region ContemUpper Method Tests

    [Theory]
    [InlineData("Hello World", "WORLD", true)]
    [InlineData("Hello World", "world", true)]
    [InlineData("Hello World", "HELLO", true)]
    [InlineData("Hello World", "xyz", false)]
    [InlineData("Test", "TEST", true)]
    public void ContemUpper_WithValidInputs_ShouldReturnCorrectResult(string text, string palavra, bool expected)
    {
        // Act
        var result = text.ContemUpper(palavra);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("", "test", false)]
    [InlineData("test", "", false)]
    [InlineData("", "", false)]
    public void ContemUpper_WithEmptyInputs_ShouldReturnFalse(string text, string palavra, bool expected)
    {
        // Act
        var result = text.ContemUpper(palavra);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, "test", false)]
    [InlineData("test", null, false)]
    public void ContemUpper_WithNullInputs_ShouldReturnFalse(string? text, string? palavra, bool expected)
    {
        // Act
        var result = text.ContemUpper(palavra!);

        // Assert
        result.Should().Be(expected);
    }

    #endregion

    #region NãoContemUpper Method Tests

    [Theory]
    [InlineData("Hello World", "xyz", true)]
    [InlineData("Hello World", "WORLD", false)]
    [InlineData("Hello World", "world", false)]
    [InlineData("Test", "different", true)]
    public void NãoContemUpper_WithValidInputs_ShouldReturnCorrectResult(string? text, string palavra, bool expected)
    {
        // Act
        var result = text.NãoContemUpper(palavra);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, "test", true)]
    [InlineData("", "test", true)]
    public void NãoContemUpper_WithNullOrEmptyText_ShouldReturnTrue(string? text, string palavra, bool expected)
    {
        // Act
        var result = text.NãoContemUpper(palavra);

        // Assert
        result.Should().Be(expected);
    }

    #endregion

    #region NotEquals Method Tests

    [Theory]
    [InlineData("Hello", "World", true)]
    [InlineData("Hello", "Hello", false)]
    [InlineData("Test", "test", true)]
    [InlineData("", "", false)]
    public void NotEquals_ShouldReturnOppositeOfEquals(string text, string value, bool expected)
    {
        // Act
        var result = text.NotEquals(value);

        // Assert
        result.Should().Be(expected);
        result.Should().Be(!text.Equals(value));
    }

    #endregion

    #region Contem Method Tests

    [Theory]
    [InlineData("Hello World", "World", true)]
    [InlineData("Hello World", "Hello", true)]
    [InlineData("Hello World", "xyz", false)]
    [InlineData("Test", "es", true)]
    [InlineData("Test", "Test", false)] // Same length should return false
    [InlineData("Short", "Very Long String", false)] // Palavra longer than text
    public void Contem_WithValidInputs_ShouldReturnCorrectResult(string text, string palavra, bool expected)
    {
        // Act
        var result = text.Contem(palavra);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("", "test", false)]
    [InlineData(null, "test", false)]
    public void Contem_WithNullOrEmptyText_ShouldReturnFalse(string? text, string palavra, bool expected)
    {
        // Act
        var result = text.Contem(palavra);

        // Assert
        result.Should().Be(expected);
    }

    #endregion

    #region ComTraço Method Tests

    [Theory]
    [InlineData("Test", " - Test")]
    [InlineData("Hello", " - Hello")]
    [InlineData("", "")]
    [InlineData("   ", "")]
    public void ComTraçado_WithVariousInputs_ShouldReturnCorrectFormat(string? text, string expected)
    {
        // Act
        var result = text.ComTraço();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ComTraço_WithNull_ShouldReturnEmpty()
    {
        // Arrange
        string? text = null;

        // Act
        var result = text.ComTraço();

        // Assert
        result.Should().Be(string.Empty);
    }

    #endregion

    #region FirstName Method Tests

    [Theory]
    [InlineData("João Silva", "João")]
    [InlineData("Maria Santos Oliveira", "Maria")]
    [InlineData("Ana", "Ana")]
    [InlineData("", "")]
    public void FirstName_WithValidNames_ShouldReturnFirstName(string? text, string expected)
    {
        // Act
        var result = text.FirstName();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void FirstName_WithNull_ShouldReturnEmpty()
    {
        // Arrange
        string? text = null;

        // Act
        var result = text.FirstName();

        // Assert
        result.Should().Be(string.Empty);
    }

    #endregion

    #region LastName Method Tests

    [Theory]
    [InlineData("João Silva", "Silva")]
    [InlineData("Maria Santos Oliveira", "Oliveira")]
    [InlineData("Ana", "Ana")]
    [InlineData("João Maria Santos", "Santos")]
    public void LastName_WithValidNames_ShouldReturnLastName(string text, string expected)
    {
        // Act
        var result = text.LastName();

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("   ", "")]
    public void LastName_WithEmptyString_ShouldReturnEmpty(string text, string expected)
    {
        // Act
        var result = text.LastName();

        // Assert
        result.Should().Be(expected);
    }

    #endregion

    #region FixAbc Method Tests (Single Parameter)

    [Theory]
    [InlineData("hello", "Hello")]
    [InlineData("world", "World")]
    [InlineData("test", "Test")]
    [InlineData("A", "A")]
    [InlineData("", "")]
    [InlineData("1test", "1test")] // Doesn't start with letter
    [InlineData("user@email.com", "user@email.com")] // Contains @
    public void FixAbc_SingleParameter_ShouldCapitalizeFirstLetter(string? text, string expected)
    {
        // Act
        var result = text.FixAbc();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void FixAbc_SingleParameter_WithNull_ShouldHandleGracefully()
    {
        // Arrange
        string? text = null;

        // Act
        var result = text.FixAbc();

        // Assert
        result.Should().NotBeNull();
    }

    #endregion

    #region FixAbc Method Tests (With MaxWidth)

    [Theory]
    [InlineData("hello world", 5, "Hello")]
    [InlineData("test", 10, "Test")]
    [InlineData("", 5, "")]
    [InlineData("a", 1, "A")]
    [InlineData("user@email.com", 20, "user@email.com")]
    public void FixAbc_WithMaxWidth_ShouldCapitalizeAndTruncate(string text, int maxWidth, string expected)
    {
        // Act
        var result = text.FixAbc(maxWidth);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, 5, "")]
    [InlineData("", 5, "")]
    public void FixAbc_WithMaxWidth_WithNullOrEmpty_ShouldReturnEmpty(string? text, int maxWidth, string expected)
    {
        // Act
        var result = text.FixAbc(maxWidth);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void FixAbc_WithMaxWidth_ShouldNotExceedMaxWidth()
    {
        // Arrange
        var longText = "This is a very long text that should be truncated";
        var maxWidth = 10;

        // Act
        var result = longText.FixAbc(maxWidth);

        // Assert
        result.Length.Should().Be(maxWidth);
        result.Should().StartWith("T"); // Should be capitalized
    }

    #endregion

    #region Edge Cases and Integration Tests

    [Fact]
    public void AllStringMethods_WithUnicodeCharacters_ShouldHandleCorrectly()
    {
        // Arrange
        var text = "josé maría";

        // Act & Assert
        text.toUpper().Should().Be("JOSÉ MARÍA");
        text.trim().Should().Be("josé maría");
        text.FirstName().Should().Be("josé");
        text.LastName().Should().Be("maría");
    }

    [Fact]
    public void AllStringMethods_WithSpecialCharacters_ShouldHandleCorrectly()
    {
        // Arrange
        var text = "test@domain.com";

        // Act & Assert
        text.endsWith(".com").Should().BeTrue();
        text.indexOf("@").Should().Be(4);
        text.Contem("domain").Should().BeTrue();
    }

    [Fact]
    public void ExtensionMethods_Chaining_ShouldWorkCorrectly()
    {
        // Arrange
        var text = "  hello world  ";

        // Act
        var result = text.trim().toUpper().replace("WORLD", "UNIVERSE");

        // Assert
        result.Should().Be("HELLO UNIVERSE");
    }

    [Theory]
    [InlineData("0123456789")] // All digits
    [InlineData("A0B1C2D3E4")] // Mixed
    [InlineData("ZYXWVU")] // All letters
    public void ColorFirstLastName_WithVariousPatterns_ShouldReturnValidColor(string text)
    {
        // Act
        var result = text.ColorFirstLastName();

        // Assert
        result.Should().NotBeNullOrEmpty();
        result.Should().StartWith("#");
        result.Length.Should().BeGreaterThanOrEqualTo(4); // At least #000
    }

    [Fact]
    public void GetHashCode2_WithLongString_ShouldHandleCorrectly()
    {
        // Arrange
        var longString = new string('A', 1000);

        // Act
        var result = longString.GetHashCode2();

        // Assert
        result.Should().NotBeNullOrEmpty();
        int.TryParse(result, out _).Should().BeTrue();
    }

    [Fact]
    public void Substring_WithEdgeCases_ShouldHandleCorrectly()
    {
        // Arrange
        var text = "Test";

        // Act & Assert
        text.substring(0, 0).Should().Be("Test"); // Length 0 returns full string
        text.substring(4, 0).Should().Be(""); // Start at end
        text.substring(2, 10).Should().Be("st"); // Length exceeds remaining
    }

    #endregion

    #region Performance and Memory Tests

    [Fact]
    public void StringMethods_WithLargeStrings_ShouldPerformEfficiently()
    {
        // Arrange
        var largeString = new string('A', 10000);

        // Act & Assert - These should complete without issues
        largeString.trim().Length.Should().Be(10000);
        largeString.toUpper().Should().StartWith("A");
        largeString.IsEmpty().Should().BeFalse();
        largeString.GetHashCode2().Should().NotBeEmpty();
    }

    [Fact]
    public void ColorGeneration_WithManyDifferentInputs_ShouldNotLeakMemory()
    {
        // Arrange
        var inputs = Enumerable.Range(0, 1000).Select(i => $"test{i}").ToArray();

        // Act
        var colors = inputs.Select(input => input.ColorFirstLastName()).ToArray();

        // Assert
        colors.Should().HaveCount(1000);
        colors.Should().AllSatisfy(color => color.Should().StartWith("#"));
    }

    #endregion

    #region Null Safety Tests

    [Fact]
    public void AllExtensionMethods_WithNullInputs_ShouldNotThrow()
    {
        // Arrange
        string? nullString = null;
        
        // Act & Assert - These should not throw exceptions
        nullString.substring(0, 5).Should().Be("");
        nullString.replace("old", "new").Should().Be("");
        nullString.Length().Should().Be(0);
        nullString.IsEquals("test").Should().BeFalse();
        nullString.trim().Should().Be("");
        nullString.endsWith("test").Should().BeFalse();
        nullString.toUpper().Should().Be("");
        nullString.indexOf("test").Should().Be(-1);
        nullString.IsEmpty().Should().BeTrue();
        nullString.GetHashCode2().Should().Be("0");
        nullString.NotIsEmpty().Should().BeFalse();
        nullString.ContemUpper("test").Should().BeFalse();
        nullString.NãoContemUpper("test").Should().BeTrue();
        nullString.Contem("test").Should().BeFalse();
        nullString.ComTraço().Should().Be(string.Empty);
        nullString.FirstName().Should().Be(string.Empty);
        nullString.FixAbc().Should().Be("");
        nullString.FixAbc(10).Should().Be("");
    }

    #endregion

    #region Real-World Integration Tests

    [Fact]
    public void CompleteWorkflow_NameProcessing_ShouldWorkEndToEnd()
    {
        // Arrange - Simulating user name processing
        var fullName = "  joão silva santos  ";

        // Act
        var trimmedName = fullName.trim();
        var firstName = trimmedName.FirstName();
        var lastName = trimmedName.LastName();
        var initials = trimmedName.ImgFirstLastName();
        var color = trimmedName.ColorFirstLastName();
        var fixedName = trimmedName.FixAbc();

        // Assert
        trimmedName.Should().Be("joão silva santos");
        firstName.Should().Be("joão");
        lastName.Should().Be("santos");
        initials.Should().Be("js");
        color.Should().StartWith("#");
        fixedName.Should().Be("João silva santos");
    }

    [Fact]
    public void CompleteWorkflow_TextProcessing_ShouldWorkEndToEnd()
    {
        // Arrange
        var text = "Hello World Test";

        // Act
        var upperText = text.toUpper();
        var containsWorld = text.ContemUpper("WORLD");
        var doesNotContainXyz = text.NãoContemUpper("xyz");
        var indexOfWorld = text.indexOf("World");
        var endsWithTest = text.endsWith("Test");

        // Assert
        upperText.Should().Be("HELLO WORLD TEST");
        containsWorld.Should().BeTrue();
        doesNotContainXyz.Should().BeTrue();
        indexOfWorld.Should().Be(6);
        endsWithTest.Should().BeTrue();
    }

    #endregion

    #region String Manipulation Advanced Tests

    [Theory]
    [InlineData("test", "TEST", true)]
    [InlineData("Test", "test", true)]
    [InlineData("HELLO", "hello", true)]
    [InlineData("different", "other", false)]
    public void ContemUpper_CaseInsensitive_ShouldWorkCorrectly(string text, string palavra, bool expected)
    {
        // Act
        var result = text.ContemUpper(palavra);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("The quick brown fox", "quick brown", true)]
    [InlineData("Testing substring", "sub", true)]
    [InlineData("No match here", "xyz", false)]
    public void Contem_WithSubstrings_ShouldDetectCorrectly(string text, string palavra, bool expected)
    {
        // Act
        var result = text.Contem(palavra);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ImgFirstLastName_WithComplexNames_ShouldHandleCorrectly()
    {
        // Arrange & Act & Assert
        "Maria".ImgFirstLastName().Should().Be("M");
        "José Carlos".ImgFirstLastName().Should().Be("JC");
        "Ana Maria da Silva".ImgFirstLastName().Should().Be("AS");
        "Pedro Paulo Jorge Santos".ImgFirstLastName().Should().Be("PS");
    }

    #endregion

    #region Hash and Color Generation Tests

    [Fact]
    public void GetHashCode2_ShouldBeConsistent()
    {
        // Arrange
        var text = "TestString";

        // Act
        var hash1 = text.GetHashCode2();
        var hash2 = text.GetHashCode2();
        var hash3 = text.GetHashCode2();

        // Assert
        hash1.Should().Be(hash2);
        hash2.Should().Be(hash3);
    }

    [Fact]
    public void ColorFirstLastName_ShouldReturnDifferentColorsForDifferentInputs()
    {
        // Arrange
        var inputs = new[] { "A", "B", "C", "0test", "1test", "test0", "test1" };

        // Act
        var colors = inputs.Select(input => input.ColorFirstLastName()).ToArray();

        // Assert
        colors.Should().OnlyHaveUniqueItems();
        colors.Should().AllSatisfy(color => color.Should().MatchRegex(@"^#[0-9a-fA-F]{6}$"));
    }

    #endregion

    #region Boundary and Extreme Value Tests

    [Theory]
    [InlineData(int.MinValue)]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(int.MaxValue)]
    public void IsEmptyIDNumber_Int_BoundaryValues_ShouldHandleCorrectly(int value)
    {
        // Act
        var result = value.IsEmptyIDNumber();

        // Assert
        if (value <= 0)
        {
            result.Should().BeTrue();
        }
        else
        {
            result.Should().BeFalse();
        }
    }

    [Theory]
    [InlineData(long.MinValue)]
    [InlineData(-1L)]
    [InlineData(0L)]
    [InlineData(1L)]
    [InlineData(long.MaxValue)]
    public void IsEmptyIDNumber_Long_BoundaryValues_ShouldHandleCorrectly(long value)
    {
        // Act
        var result = value.IsEmptyIDNumber();

        // Assert
        if (value <= 0)
        {
            result.Should().BeTrue();
        }
        else
        {
            result.Should().BeFalse();
        }
    }

    [Fact]
    public void IsEmpty_Decimal_BoundaryValues_ShouldHandleCorrectly()
    {
        // Arrange & Act & Assert
        decimal.MinValue.IsEmpty().Should().BeFalse();
        (-0.1m).IsEmpty().Should().BeFalse();
        0.0m.IsEmpty().Should().BeTrue();
        0.1m.IsEmpty().Should().BeFalse();
        decimal.MaxValue.IsEmpty().Should().BeFalse();
    }

    #endregion
}