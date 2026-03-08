using FluentAssertions;
using Xunit;

namespace SourceGenesys.Domain.Tests.DevourerApi.DevourerOne;

/// <summary>
/// Comprehensive unit tests for SQL data methods in DevourerOneSqlData
/// </summary>
public class DevourerOneSqlDataTests
{
    #region Idade Method Tests

    [Theory]
    [InlineData("1990-01-01", 34)] // Assuming current year is 2024
    [InlineData("2000-06-15", 23)]
    [InlineData("1985-12-31", 38)]
    public void Idade_WithValidBirthDate_ShouldReturnCorrectAge(string birthDateStr, int expectedAge)
    {
        // Arrange
        var birthDate = DateTime.Parse(birthDateStr);
        var today = "01/01/2024";

        // Act
        var result = MenphisSI.DevourerOne.Idade(birthDate, today);

        // Assert
        result.Should().Be(expectedAge);
    }

    [Fact]
    public void Idade_WithBirthDateInFuture_ShouldReturnNegativeAge()
    {
        // Arrange
        var futureDate = DateTime.Today.AddYears(1);

        // Act
        var result = MenphisSI.DevourerOne.Idade(futureDate);

        // Assert
        result.Should().BeNegative();
    }

    [Fact]
    public void Idade_WithBirthDateToday_ShouldReturnZero()
    {
        // Arrange
        var today = DateTime.Today;

        // Act
        var result = MenphisSI.DevourerOne.Idade(today);

        // Assert
        result.Should().Be(0);
    }

    #endregion

    #region DateUp12 Method Tests

    [Fact]
    public void DateUp12_WithNowValue_ShouldReturnSetUpNowTrue()
    {
        // Arrange
        var hasChange = false;
        DateTime? currDate = null;
        var value = "now";

        // Act
        var result = MenphisSI.DevourerOne.DateUp12(hasChange, currDate, value);

        // Assert
        result.setUpNow.Should().BeTrue();
        result.changed.Should().BeTrue();
        result.data.Should().NotBeNull();
    }

    [Fact]
    public void DateUp12_WithNOWValue_ShouldReturnSetUpNowTrue()
    {
        // Arrange
        var hasChange = false;
        DateTime? currDate = null;
        var value = "NOW";

        // Act
        var result = MenphisSI.DevourerOne.DateUp12(hasChange, currDate, value);

        // Assert
        result.setUpNow.Should().BeTrue();
        result.changed.Should().BeTrue();
        result.data.Should().NotBeNull();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void DateUp12_WithNullOrEmptyValue_AndCurrentDateExists_ShouldReturnCurrentDateState(string? value)
    {
        // Arrange
        var hasChange = false;
        var currDate = DateTime.Now;

        // Act
        var result = MenphisSI.DevourerOne.DateUp12(hasChange, currDate, value);

        // Assert
        result.setUpNow.Should().BeTrue();
        result.changed.Should().BeTrue();
        result.data.Should().BeNull();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void DateUp12_WithNullOrEmptyValue_AndNoCurrentDate_ShouldReturnFalse(string? value)
    {
        // Arrange
        var hasChange = false;
        DateTime? currDate = null;

        // Act
        var result = MenphisSI.DevourerOne.DateUp12(hasChange, currDate, value);

        // Assert
        result.setUpNow.Should().BeFalse();
        result.changed.Should().BeFalse();
        result.data.Should().BeNull();
    }

    [Fact]
    public void DateUp12_WithValidDateString_ShouldReturnParsedDate()
    {
        // Arrange
        var hasChange = false;
        DateTime? currDate = null;
        var value = "2024-01-15";

        // Act
        var result = MenphisSI.DevourerOne.DateUp12(hasChange, currDate, value);

        // Assert
        result.setUpNow.Should().BeTrue();
        result.changed.Should().BeTrue();
        result.data.Should().Be(DateTime.Parse(value));
    }

    [Fact]
    public void DateUp12_WithDateTimeMinValue_ShouldReturnFalse()
    {
        // Arrange
        var hasChange = false;
        DateTime? currDate = null;
        var value = DateTime.MinValue.ToString();

        // Act
        var result = MenphisSI.DevourerOne.DateUp12(hasChange, currDate, value);

        // Assert
        result.setUpNow.Should().BeFalse();
        result.changed.Should().BeFalse();
        result.data.Should().BeNull();
    }

    [Fact]
    public void DateUp12_WithSameDateAsCurrent_ShouldReturnFalse()
    {
        // Arrange
        var hasChange = false;
        var currDate = new DateTime(2024, 1, 15);
        var value = "2024-01-15";

        // Act
        var result = MenphisSI.DevourerOne.DateUp12(hasChange, currDate, value);

        // Assert
        result.setUpNow.Should().BeFalse();
        result.changed.Should().BeFalse();
        result.data.Should().BeNull();
    }

    [Fact]
    public void DateUp12_WithInvalidDateString_ShouldReturnFalse()
    {
        // Arrange
        var hasChange = false;
        DateTime? currDate = null;
        var value = "invalid-date";

        // Act
        var result = MenphisSI.DevourerOne.DateUp12(hasChange, currDate, value);

        // Assert
        result.setUpNow.Should().BeFalse();
        result.changed.Should().BeFalse();
        result.data.Should().BeNull();
    }

    #endregion

    #region AppendDataSQLDay3 Method Tests

    [Fact]
    public void AppendDataSQLDay3_WithValidDateTime_ShouldReturnFormattedSqlCondition()
    {
        // Arrange
        var dateTime = new DateTime(2024, 4, 15);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSQLDay3(dateTime, fieldName);

        // Assert
        result.Should().Be(" CONVERT(nvarchar(10), DataCadastro, 103)='15/04/2024'");
    }

    [Fact]
    public void AppendDataSQLDay3_WithMinDateTime_ShouldUseCurrentDate()
    {
        // Arrange
        var dateTime = new DateTime(1, 1, 1);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSQLDay3(dateTime, fieldName);

        // Assert
        var today = MenphisSI.DevourerOne.DateTimeUtc.Date;
        var expectedDate = $"{today:dd/MM/yyyy}";
        result.Should().Be($" CONVERT(nvarchar(10), DataCadastro, 103)='{expectedDate}'");
    }

    #endregion

    #region AppendDataSqlMenorOuIgual Method Tests

    [Fact]
    public void AppendDataSqlMenorOuIgual_WithDateTime_ShouldReturnCorrectCondition()
    {
        // Arrange
        var dateTime = new DateTime(2024, 4, 15);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMenorOuIgual(dateTime, fieldName);

        // Assert
        result.Should().Be("DataCadastro<=CONVERT(DATETIME,'15-4-2024 23:59:59.999',103)");
    }

    [Fact]
    public void AppendDataSqlMenorOuIgual_WithMinDateTime_ShouldUseCurrentDate()
    {
        // Arrange
        var dateTime = new DateTime(1, 1, 1);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMenorOuIgual(dateTime, fieldName);

        // Assert
        var today = MenphisSI.DevourerOne.DateTimeUtc.Date;
        result.Should().Be($"DataCadastro<=CONVERT(DATETIME,'{today.Day}-{today.Month}-{today.Year} 23:59:59.999',103)");
    }

    [Fact]
    public void AppendDataSqlMenorOuIgual20_WithNullableDateTime_ShouldUseCurrentDate()
    {
        // Arrange
        DateTime? dateTime = null;
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMenorOuIgual20(dateTime, fieldName);

        // Assert
        var today = MenphisSI.DevourerOne.DateTimeUtc.Date;
        result.Should().Be($"DataCadastro<=CONVERT(DATETIME,'{today.Day}-{today.Month}-{today.Year} 23:59:59.999',103)");
    }

    [Fact]
    public void AppendDataSqlMenorOuIgual_WithStringDateTime_ShouldReturnCorrectCondition()
    {
        // Arrange
        var dateTime = "15/04/2024";
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMenorOuIgual(dateTime, fieldName);

        // Assert
        result.Should().Be("DataCadastro<=CONVERT(DATETIME,'15-4-2024 23:59:59.999',103)");
    }

    [Fact]
    public void AppendDataSqlMenorOuIgual_WithNowString_ShouldUseCurrentDateTime()
    {
        // Arrange
        var dateTime = "now";
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMenorOuIgual(dateTime, fieldName);

        // Assert
        var today = MenphisSI.DevourerOne.DateTimeUtc.Date;
        result.Should().Be($"DataCadastro<=CONVERT(DATETIME,'{today.Day}-{today.Month}-{today.Year} 23:59:59.999',103)");
    }

    #endregion

    #region AppendDataSqlMaiorOuIgual Method Tests

    [Fact]
    public void AppendDataSqlMaiorOuIgual_WithDateTime_ShouldReturnCorrectCondition()
    {
        // Arrange
        var dateTime = new DateTime(2024, 4, 15);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMaiorOuIgual(dateTime, fieldName);

        // Assert
        result.Should().Be("DataCadastro>=CONVERT(DATETIME,'15-4-2024 00:00:00.000',103)");
    }

    [Fact]
    public void AppendDataSqlMaiorOuIgual_WithMinDateTime_ShouldUseCurrentDate()
    {
        // Arrange
        var dateTime = new DateTime(1, 1, 1);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMaiorOuIgual(dateTime, fieldName);

        // Assert
        var today = MenphisSI.DevourerOne.DateTimeUtc.Date;
        result.Should().Be($"DataCadastro>=CONVERT(DATETIME,'{today.Day}-{today.Month}-{today.Year} 00:00:00.000',103)");
    }

    [Fact]
    public void AppendDataSqlMaiorOuIgual20_WithDateTime_ShouldReturnCorrectCondition()
    {
        // Arrange
        var dateTime = new DateTime(2024, 4, 15);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMaiorOuIgual20(dateTime, fieldName);

        // Assert
        result.Should().Be("DataCadastro>=CONVERT(DATETIME,'15-4-2024 00:00:00.000',103)");
    }

    [Fact]
    public void AppendDataSqlMaiorOuIgual_WithStringDateTime_ShouldReturnCorrectCondition()
    {
        // Arrange
        var dateTime = "15/04/2024";
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMaiorOuIgual(dateTime, fieldName);

        // Assert
        // Fixed bug: The method now correctly parses the input string instead of always using current date
        result.Should().Be("DataCadastro>=CONVERT(DATETIME,'15-4-2024 00:00:00.000',103)");
    }

    [Fact]
    public void AppendDataSqlMaiorOuIgual_WithStringDateTime_WhatItShouldDo()
    {
        // This test documented what the method SHOULD do if the bug were fixed
        // Now the bug is fixed, so this test should pass with correct behavior
        
        // Arrange
        var dateTime = "15/04/2024";
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMaiorOuIgual(dateTime, fieldName);

        // Assert - This is what now happens after the bug was fixed
        result.Should().Be("DataCadastro>=CONVERT(DATETIME,'15-4-2024 00:00:00.000',103)");
    }

    [Fact]
    public void AppendDataSqlMaiorOuIgual_WithInvalidStringDateTime_ShouldUseCurrentDate()
    {
        // Arrange
        var dateTime = "invalid-date";
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMaiorOuIgual(dateTime, fieldName);

        // Assert
        // Due to the bug, this behaves the same as valid dates - always uses current date
        var today = MenphisSI.DevourerOne.DateTimeUtc.Date;
        result.Should().Be($"DataCadastro>=CONVERT(DATETIME,'{today.Day}-{today.Month}-{today.Year} 00:00:00.000',103)");
    }

    [Fact]
    public void AppendDataSqlMaiorOuIgual_WithNowString_ShouldUseCurrentDateTime()
    {
        // Arrange
        var dateTime = "now";
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMaiorOuIgual(dateTime, fieldName);

        // Assert
        var today = MenphisSI.DevourerOne.DateTimeUtc.Date;
        result.Should().Be($"DataCadastro>=CONVERT(DATETIME,'{today.Day}-{today.Month}-{today.Year} 00:00:00.000',103)");
    }

    #endregion

    #region AppendDataSqlDataIgual Method Tests

    [Fact]
    public void AppendDataSqlDataIgual_WithDateTime_ShouldReturnCorrectCondition()
    {
        // Arrange
        var dateTime = new DateTime(2024, 4, 15);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlDataIgual(dateTime, fieldName);

        // Assert
        result.Should().Be(" DataCadastro = CONVERT(DATE, '2024-04-15', 120)");
    }

    [Fact]
    public void AppendDataSqlDataIgual_WithDateOnly_ShouldReturnCorrectCondition()
    {
        // Arrange
        var dateOnly = new DateOnly(2024, 4, 15);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlDataIgual(dateOnly, fieldName);

        // Assert
        result.Should().Be(" DataCadastro = CONVERT(DATE, '2024-04-15', 120)");
    }

    [Fact]
    public void AppendDataSqlDataIgual20_WithDateTime_ShouldReturnCorrectCondition()
    {
        // Arrange
        var dateTime = new DateTime(2024, 4, 15);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlDataIgual20(dateTime, fieldName);

        // Assert
        result.Should().Be(" DataCadastro > '2024-04-14 00:00:00.000' AND CONVERT(CHAR(10),DataCadastro,103)='15/04/2024' ");
    }

    [Fact]
    public void AppendDataSqlDataIgual_WithStringDateTime_ShouldReturnCorrectCondition()
    {
        // Arrange
        var dateTime = "15/04/2024";
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlDataIgual(dateTime, fieldName);

        // Assert
        result.Should().Be(" DataCadastro = CONVERT(DATE, '2024-04-15', 120)");
    }

    [Fact]
    public void AppendDataSqlDataIgual_WithNullableDateTime_ShouldUseCurrentDate()
    {
        // Arrange
        DateTime? dateTime = null;
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlDataIgual(dateTime, fieldName);

        // Assert
        var today = MenphisSI.DevourerOne.DateTimeUtc.Date;
        result.Should().Be($" DataCadastro = CONVERT(DATE, '{today:yyyy-MM-dd}', 120)");
    }

    #endregion

    #region AppendDataSqlMaiorQue Method Tests

    [Fact]
    public void AppendDataSqlMaiorQue_WithDateTime_ShouldReturnCorrectCondition()
    {
        // Arrange
        var dateTime = new DateTime(2024, 4, 15);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMaiorQue(dateTime, fieldName);

        // Assert
        result.Should().Be("DataCadastro>CONVERT(DATETIME,'15-4-2024 23:59:59.999',103)");
    }

    [Fact]
    public void AppendDataSqlMaiorQue_WithMinDateTime_ShouldReturnTrueCondition()
    {
        // Arrange
        var dateTime = new DateTime(1, 1, 1);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMaiorQue(dateTime, fieldName);

        // Assert
        result.Should().Be("0=0");
    }

    [Fact]
    public void AppendDataSqlMaiorQue20_WithDateTime_ShouldReturnCorrectCondition()
    {
        // Arrange
        var dateTime = new DateTime(2024, 4, 15);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMaiorQue20(dateTime, fieldName);

        // Assert
        result.Should().Be("DataCadastro>CONVERT(DATETIME,'15-4-2024 23:59:59.999',103)");
    }

    [Fact]
    public void AppendDataSqlMaiorQue20_WithMinDateTime_ShouldReturnTrueCondition()
    {
        // Arrange
        var dateTime = new DateTime(1, 1, 1);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMaiorQue20(dateTime, fieldName);

        // Assert
        result.Should().Be("0=0");
    }

    [Fact]
    public void AppendDataSqlMaiorQue_WithStringDateTime_ShouldReturnCorrectCondition()
    {
        // Arrange
        var dateTime = "15/04/2024";
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMaiorQue(dateTime, fieldName);

        // Assert
        result.Should().Be("DataCadastro>CONVERT(DATETIME,'15-4-2024 23:59:59.999',103)");
    }

    #endregion

    #region AppendDataSqlMenorQue Method Tests

    [Fact]
    public void AppendDataSqlMenorQue_WithDateTime_ShouldReturnCorrectCondition()
    {
        // Arrange
        var dateTime = new DateTime(2024, 4, 15);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMenorQue(dateTime, fieldName);

        // Assert
        result.Should().Be("DataCadastro<CONVERT(DATETIME,'15-4-2024 00:00:00.000',103)");
    }

    [Fact]
    public void AppendDataSqlMenorQue_WithMinDateTime_ShouldReturnTrueCondition()
    {
        // Arrange
        var dateTime = new DateTime(1, 1, 1);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMenorQue(dateTime, fieldName);

        // Assert
        result.Should().Be("0=0");
    }

    [Fact]
    public void AppendDataSqlMenorQue20_WithDateTime_ShouldReturnCorrectCondition()
    {
        // Arrange
        var dateTime = new DateTime(2024, 4, 15);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMenorQue20(dateTime, fieldName);

        // Assert
        result.Should().Be("DataCadastro<CONVERT(DATETIME,'15-4-2024 23:59:59.999',103)");
    }

    [Fact]
    public void AppendDataSqlMenorQue20_WithMinDateTime_ShouldReturnTrueCondition()
    {
        // Arrange
        var dateTime = new DateTime(1, 1, 1);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMenorQue20(dateTime, fieldName);

        // Assert
        result.Should().Be("0=0");
    }

    [Fact]
    public void AppendDataSqlMenorQue_WithStringDateTime_ShouldReturnCorrectCondition()
    {
        // Arrange
        var dateTime = "15/04/2024";
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMenorQue(dateTime, fieldName);

        // Assert
        result.Should().Be("DataCadastro<CONVERT(DATETIME,'15-4-2024 00:00:00.000',103)");
    }

    [Fact]
    public void AppendDataSqlMenorQue20_WithStringDateTime_ShouldReturnCorrectCondition()
    {
        // Arrange
        var dateTime = "15/04/2024";
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlMenorQue20(dateTime, fieldName);

        // Assert
        result.Should().Be("DataCadastro<CONVERT(DATETIME,'15-4-2024 23:59:59.999',103)");
    }

    #endregion

    #region AppendDataSqlBetween Method Tests

    [Fact]
    public void AppendDataSqlBetween_WithDateTime_ShouldReturnCorrectCondition()
    {
        // Arrange
        var startDate = new DateTime(2024, 4, 10);
        var endDate = new DateTime(2024, 4, 20);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlBetween(startDate, endDate, fieldName);

        // Assert
        result.Should().Be(" (DataCadastro >= '2024-04-09 23:59:59.999' AND DataCadastro <= '2024-04-20 23:59:59.999' ) ");
    }

    [Fact]
    public void AppendDataSqlBetween_WithDateOnly_ShouldReturnCorrectCondition()
    {
        // Arrange
        var startDate = new DateOnly(2024, 4, 10);
        var endDate = new DateOnly(2024, 4, 20);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlBetween(startDate, endDate, fieldName);

        // Assert
        result.Should().Be(" (DataCadastro >= '2024-04-09 23:59:59.999' AND DataCadastro <= '2024-04-20 23:59:59.999' ) ");
    }

    [Fact]
    public void AppendDataSqlBetween20_WithDateTime_ShouldReturnCorrectCondition()
    {
        // Arrange
        var startDate = new DateTime(2024, 4, 10);
        var endDate = new DateTime(2024, 4, 20);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlBetween20(startDate, endDate, fieldName);

        // Assert
        result.Should().Be(" (DataCadastro >= '2024-04-09 23:59:59.999' AND DataCadastro <= '2024-04-20 23:59:59.999' ) ");
    }

    [Fact]
    public void AppendDataSqlBetween_WithStringDates_ShouldReturnCorrectCondition()
    {
        // Arrange
        var startDate = "10/04/2024";
        var endDate = "20/04/2024";
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlBetween(startDate, endDate, fieldName);

        // Assert
        result.Should().Be(" (DataCadastro >= '2024-04-09 23:59:59.999' AND DataCadastro <= '2024-04-20 23:59:59.999' ) ");
    }

    [Fact]
    public void AppendDataSqlBetween20_WithStringDates_ShouldReturnCorrectCondition()
    {
        // Arrange
        var startDate = "10/04/2024";
        var endDate = "20/04/2024";
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlBetween20(startDate, endDate, fieldName);

        // Assert
        result.Should().Be(" (DataCadastro >= '2024-04-09 23:59:59.999' AND DataCadastro <= '2024-04-20 23:59:59.999' ) ");
    }

    [Fact]
    public void AppendDataSqlBetween_WithNullableDates_ShouldUseCurrentDateForNulls()
    {
        // Arrange
        DateTime? startDate = new DateTime(2024, 4, 10);
        DateTime? endDate = null;
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlBetween(startDate, endDate, fieldName);

        // Assert
        var today = MenphisSI.DevourerOne.DateTimeUtc.Date;
        result.Should().Be($" (DataCadastro >= '2024-04-09 23:59:59.999' AND DataCadastro <= '{today:yyyy-MM-dd} 23:59:59.999' ) ");
    }

    [Fact]
    public void AppendDataSqlBetween_WithInvalidStringDates_ShouldUseCurrentDate()
    {
        // Arrange
        var startDate = "invalid-date";
        var endDate = "another-invalid";
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlBetween(startDate, endDate, fieldName);

        // Assert
        var today = MenphisSI.DevourerOne.DateTimeUtc.Date;
        result.Should().Be($" (DataCadastro >= '{today.AddDays(-1):yyyy-MM-dd} 23:59:59.999' AND DataCadastro <= '{today:yyyy-MM-dd} 23:59:59.999' ) ");
    }

    #endregion

    #region Edge Cases and Integration Tests

    [Fact]
    public void SqlDataMethods_WithSpecialFieldNames_ShouldHandleCorrectly()
    {
        // Arrange
        var dateTime = new DateTime(2024, 4, 15);
        var specialFieldName = "[DataCadastro com espaços]";

        // Act
        var result1 = MenphisSI.DevourerOne.AppendDataSqlDataIgual(dateTime, specialFieldName);
        var result2 = MenphisSI.DevourerOne.AppendDataSqlMaiorOuIgual(dateTime, specialFieldName);

        // Assert
        result1.Should().Contain(specialFieldName);
        result2.Should().Contain(specialFieldName);
    }

    [Fact]
    public void SqlDataMethods_WithLeapYearDate_ShouldHandleCorrectly()
    {
        // Arrange
        var leapYearDate = new DateTime(2024, 2, 29); // 2024 is a leap year
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSQLDay3(leapYearDate, fieldName);

        // Assert
        result.Should().Be(" CONVERT(nvarchar(10), DataCadastro, 103)='29/02/2024'");
    }

    [Fact]
    public void SqlDataMethods_WithYearEndDate_ShouldHandleCorrectly()
    {
        // Arrange
        var yearEndDate = new DateTime(2023, 12, 31);
        var fieldName = "DataCadastro";

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlBetween(yearEndDate, yearEndDate.AddDays(1), fieldName);

        // Assert
        result.Should().Be(" (DataCadastro >= '2023-12-30 23:59:59.999' AND DataCadastro <= '2024-01-01 23:59:59.999' ) ");
    }

    [Theory]
    [InlineData("DataCadastro")]
    [InlineData("dt_cadastro")]
    [InlineData("DataModificacao")]
    [InlineData("[Data de Criação]")]
    public void SqlDataMethods_WithDifferentFieldNames_ShouldMaintainFieldName(string fieldName)
    {
        // Arrange
        var dateTime = new DateTime(2024, 4, 15);

        // Act
        var result = MenphisSI.DevourerOne.AppendDataSqlDataIgual(dateTime, fieldName);

        // Assert
        result.Should().Contain(fieldName);
    }

    #endregion

    #region Constants and Dependencies Tests

    [Fact]
    public void SqlDataMethods_ShouldUsePNowConstant()
    {
        // Arrange
        var fieldName = "DataCadastro";

        // Act
        var result1 = MenphisSI.DevourerOne.AppendDataSqlMaiorOuIgual(MenphisSI.DevourerOne.PNow, fieldName);
        var result2 = MenphisSI.DevourerOne.AppendDataSqlMenorOuIgual(MenphisSI.DevourerOne.PNow, fieldName);

        // Assert
        result1.Should().NotBeNullOrEmpty();
        result2.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void SqlDataMethods_ShouldUseDateTimeUtcProperty()
    {
        // Act
        var dateTimeUtc = MenphisSI.DevourerOne.DateTimeUtc;

        // Assert
        dateTimeUtc.Should().BeAfter(DateTime.MinValue);
        dateTimeUtc.Should().BeBefore(DateTime.Now.AddMinutes(1)); // Allow for some time variance
    }

    #endregion
}