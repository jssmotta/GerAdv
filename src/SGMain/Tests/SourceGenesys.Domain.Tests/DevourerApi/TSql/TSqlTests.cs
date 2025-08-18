using Xunit;
using FluentAssertions;
using MenphisSI;

namespace SourceGenesys.Domain.Tests.DevourerApi.TSqlTests;

/// <summary>
/// Comprehensive unit tests for TSql static class methods
/// </summary>
public class TSqlTests
{
    #region Embrace Method Tests

    [Theory]
    [InlineData("Name = 'John'", " ( Name = 'John' ) ")]
    [InlineData("Id > 100", " ( Id > 100 ) ")]
    [InlineData("Status = 1 AND IsActive = 1", " ( Status = 1 AND IsActive = 1 ) ")]
    [InlineData("Email LIKE '%@domain.com'", " ( Email LIKE '%@domain.com' ) ")]
    [InlineData("CreatedDate BETWEEN '2023-01-01' AND '2023-12-31'", " ( CreatedDate BETWEEN '2023-01-01' AND '2023-12-31' ) ")]
    public void Embrace_WithValidWhereClause_ShouldWrapInParentheses(string whereClause, string expected)
    {
        // Act
        var result = TSql.Embrace(whereClause);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("   ", "")]
    [InlineData("\t", "")]
    [InlineData("\n", "")]
    [InlineData("\r\n", "")]
    public void Embrace_WithEmptyOrWhitespaceString_ShouldReturnEmptyString(string whereClause, string expected)
    {
        // Act
        var result = TSql.Embrace(whereClause);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Embrace_WithNullString_ShouldReturnEmptyString()
    {
        // Act
        var result = TSql.Embrace(null!);

        // Assert
        result.Should().Be(string.Empty);
    }

    [Theory]
    [InlineData("a", " ( a ) ")]
    [InlineData("1", " ( 1 ) ")]
    [InlineData("x", " ( x ) ")]
    public void Embrace_WithSingleCharacter_ShouldWrapInParentheses(string whereClause, string expected)
    {
        // Act
        var result = TSql.Embrace(whereClause);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Embrace_WithComplexWhereClause_ShouldWrapCorrectly()
    {
        // Arrange
        var complexWhere = "((Name = 'John' OR Name = 'Jane') AND (Age > 18 AND Age < 65)) OR Status = 'ACTIVE'";
        var expected = " ( ((Name = 'John' OR Name = 'Jane') AND (Age > 18 AND Age < 65)) OR Status = 'ACTIVE' ) ";

        // Act
        var result = TSql.Embrace(complexWhere);

        // Assert
        result.Should().Be(expected);
    }

    #endregion

    #region SQL Keyword Constants Tests

    [Fact]
    public void And_ShouldReturnCorrectValue()
    {
        // Act & Assert
        TSql.And.Should().Be(" AND ");
    }

    [Fact]
    public void OR_ShouldReturnCorrectValue()
    {
        // Act & Assert
        TSql.OR.Should().Be(" OR ");
    }

    [Fact]
    public void Where_ShouldReturnCorrectValue()
    {
        // Act & Assert
        TSql.Where.Should().Be(" WHERE ");
    }

    [Fact]
    public void Select_ShouldReturnCorrectValue()
    {
        // Act & Assert
        TSql.Select.Should().Be(" SELECT ");
    }

    [Fact]
    public void From_ShouldReturnCorrectValue()
    {
        // Act & Assert
        TSql.From.Should().Be(" FROM ");
    }

    [Fact]
    public void OrderBy_ShouldReturnCorrectValue()
    {
        // Act & Assert
        TSql.OrderBy.Should().Be(" ORDER BY ");
    }

    [Fact]
    public void Virgula_ShouldReturnCorrectValue()
    {
        // Act & Assert
        TSql.Virgula.Should().Be(", ");
    }

    #endregion

    #region Constants Space Padding Tests

    [Fact]
    public void And_ShouldHaveProperSpacePadding()
    {
        // Arrange & Act
        var andValue = TSql.And;

        // Assert
        andValue.Should().StartWith(" ");
        andValue.Should().EndWith(" ");
        andValue.Trim().Should().Be("AND");
    }

    [Fact]
    public void OR_ShouldHaveProperSpacePadding()
    {
        // Arrange & Act
        var orValue = TSql.OR;

        // Assert
        orValue.Should().StartWith(" ");
        orValue.Should().EndWith(" ");
        orValue.Trim().Should().Be("OR");
    }

    [Fact]
    public void Where_ShouldHaveProperSpacePadding()
    {
        // Arrange & Act
        var whereValue = TSql.Where;

        // Assert
        whereValue.Should().StartWith(" ");
        whereValue.Should().EndWith(" ");
        whereValue.Trim().Should().Be("WHERE");
    }

    [Fact]
    public void Select_ShouldHaveProperSpacePadding()
    {
        // Arrange & Act
        var selectValue = TSql.Select;

        // Assert
        selectValue.Should().StartWith(" ");
        selectValue.Should().EndWith(" ");
        selectValue.Trim().Should().Be("SELECT");
    }

    [Fact]
    public void From_ShouldHaveProperSpacePadding()
    {
        // Arrange & Act
        var fromValue = TSql.From;

        // Assert
        fromValue.Should().StartWith(" ");
        fromValue.Should().EndWith(" ");
        fromValue.Trim().Should().Be("FROM");
    }

    [Fact]
    public void OrderBy_ShouldHaveProperSpacePadding()
    {
        // Arrange & Act
        var orderByValue = TSql.OrderBy;

        // Assert
        orderByValue.Should().StartWith(" ");
        orderByValue.Should().EndWith(" ");
        orderByValue.Trim().Should().Be("ORDER BY");
    }

    [Fact]
    public void Virgula_ShouldHaveProperSpacePadding()
    {
        // Arrange & Act
        var virgulaValue = TSql.Virgula;

        // Assert
        virgulaValue.Should().Be(", ");
        virgulaValue.Should().EndWith(" ");
        virgulaValue.Trim().Should().Be(",");
    }

    #endregion

    #region SQL Query Building Integration Tests

    [Fact]
    public void BuildingSelectQuery_WithAllConstants_ShouldCreateValidSql()
    {
        // Arrange
        var expectedSql = " SELECT Name, Age FROM Users WHERE  ( Status = 'ACTIVE' )  ORDER BY Name";

        // Act
        var result = TSql.Select + "Name" + TSql.Virgula + "Age" + TSql.From + "Users" + TSql.Where + TSql.Embrace("Status = 'ACTIVE'") + TSql.OrderBy + "Name";

        // Assert
        result.Should().Be(expectedSql);
    }

    [Fact]
    public void BuildingWhereClause_WithAndOperator_ShouldCreateValidCondition()
    {
        // Arrange
        var condition1 = "Name = 'John'";
        var condition2 = "Age > 18";
        var expected = " ( Name = 'John' )  AND  ( Age > 18 ) ";

        // Act
        var result = TSql.Embrace(condition1) + TSql.And + TSql.Embrace(condition2);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void BuildingWhereClause_WithOrOperator_ShouldCreateValidCondition()
    {
        // Arrange
        var condition1 = "Status = 'ACTIVE'";
        var condition2 = "Status = 'PENDING'";
        var expected = " ( Status = 'ACTIVE' )  OR  ( Status = 'PENDING' ) ";

        // Act
        var result = TSql.Embrace(condition1) + TSql.OR + TSql.Embrace(condition2);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void BuildingComplexQuery_WithMultipleOperators_ShouldCreateValidSql()
    {
        // Arrange
        var fields = "Id" + TSql.Virgula + "Name" + TSql.Virgula + "Email";
        var table = "Users";
        var whereCondition = TSql.Embrace("IsActive = 1") + TSql.And + TSql.Embrace("Age >= 18");
        var orderBy = "Name" + TSql.Virgula + "Email";

        var expectedSql = " SELECT Id, Name, Email FROM Users WHERE  ( IsActive = 1 )  AND  ( Age >= 18 )  ORDER BY Name, Email";

        // Act
        var result = TSql.Select + fields + TSql.From + table + TSql.Where + whereCondition + TSql.OrderBy + orderBy;

        // Assert
        result.Should().Be(expectedSql);
    }

    #endregion

    #region Edge Cases and Special Characters Tests

    [Theory]
    [InlineData("Name = 'O'Brien'", " ( Name = 'O'Brien' ) ")]
    [InlineData("Description LIKE '%test & demo%'", " ( Description LIKE '%test & demo%' ) ")]
    [InlineData("Amount > 100.50", " ( Amount > 100.50 ) ")]
    [InlineData("Date >= '2023-01-01 12:30:45'", " ( Date >= '2023-01-01 12:30:45' ) ")]
    public void Embrace_WithSpecialCharacters_ShouldHandleCorrectly(string whereClause, string expected)
    {
        // Act
        var result = TSql.Embrace(whereClause);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("Column1 = @param1", " ( Column1 = @param1 ) ")]
    [InlineData("Column2 IN (@param1, @param2, @param3)", " ( Column2 IN (@param1, @param2, @param3) ) ")]
    [InlineData("UPPER(Name) = UPPER(@searchTerm)", " ( UPPER(Name) = UPPER(@searchTerm) ) ")]
    public void Embrace_WithParameterizedQueries_ShouldHandleCorrectly(string whereClause, string expected)
    {
        // Act
        var result = TSql.Embrace(whereClause);

        // Assert
        result.Should().Be(expected);
    }

    #endregion

    #region Class Structure Tests

    [Fact]
    public void TSql_ShouldBeStaticClass()
    {
        // Arrange & Act
        var type = typeof(TSql);

        // Assert
        type.Should().NotBeNull();
        type.IsClass.Should().BeTrue();
        type.IsAbstract.Should().BeTrue(); // Static classes are abstract
        type.IsSealed.Should().BeTrue(); // Static classes are sealed
    }

    [Fact]
    public void TSql_ShouldHaveAllExpectedMembers()
    {
        // Arrange
        var type = typeof(TSql);

        // Act
        var methods = type.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
        var properties = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

        // Assert
        // Should have the Embrace method
        methods.Should().Contain(m => m.Name == "Embrace");

        // Should have all the SQL keyword properties
        properties.Should().Contain(p => p.Name == "And");
        properties.Should().Contain(p => p.Name == "OR");
        properties.Should().Contain(p => p.Name == "Where");
        properties.Should().Contain(p => p.Name == "Select");
        properties.Should().Contain(p => p.Name == "From");
        properties.Should().Contain(p => p.Name == "OrderBy");
        properties.Should().Contain(p => p.Name == "Virgula");
    }

    [Fact]
    public void TSql_AllProperties_ShouldReturnStringType()
    {
        // Arrange
        var type = typeof(TSql);
        var properties = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

        // Act & Assert
        foreach (var property in properties)
        {
            property.PropertyType.Should().Be(typeof(string), $"Property {property.Name} should return string");
        }
    }

    [Fact]
    public void Embrace_Method_ShouldHaveCorrectSignature()
    {
        // Arrange
        var type = typeof(TSql);

        // Act - Search for the method with the correct signature for 'in' parameter
        // 'in' parameters are treated as by-reference in reflection
        var method = type.GetMethod("Embrace", new[] { typeof(string).MakeByRefType() }) 
                     ?? type.GetMethod("Embrace", new[] { typeof(string) });

        // Assert
        method.Should().NotBeNull("The Embrace method should exist with either 'in string' or 'string' parameter");
        method!.ReturnType.Should().Be(typeof(string));
        method.IsStatic.Should().BeTrue();
        method.IsPublic.Should().BeTrue();

        // Check parameter details
        var parameters = method.GetParameters();
        parameters.Should().HaveCount(1);
        parameters[0].Name.Should().Be("cWhere");
        
        // The parameter type should be string (base type)
        var parameterType = parameters[0].ParameterType;
        if (parameterType.IsByRef)
        {
            parameterType.GetElementType().Should().Be(typeof(string), "The base type should be string");
        }
        else
        {
            parameterType.Should().Be(typeof(string), "The parameter type should be string");
        }
        
        // Check that it's not an 'out' parameter
        parameters[0].IsOut.Should().BeFalse("'in' parameters are not 'out' parameters");
    }

    #endregion

    #region Performance and Memory Tests

    [Fact]
    public void TSql_Constants_ShouldBeCachedAndNotRecreated()
    {
        // Act
        var and1 = TSql.And;
        var and2 = TSql.And;

        // Assert
        ReferenceEquals(and1, and2).Should().BeTrue("Constants should return the same string instance");
    }

    [Fact]
    public void Embrace_MultipleCallsWithSameInput_ShouldReturnEqualResults()
    {
        // Arrange
        var input = "Name = 'Test'";

        // Act
        var result1 = TSql.Embrace(input);
        var result2 = TSql.Embrace(input);

        // Assert
        result1.Should().Be(result2);
    }

    #endregion

    #region Unicode and Encoding Tests

    [Theory]
    [InlineData("Nome = 'João'", " ( Nome = 'João' ) ")]
    [InlineData("Descrição LIKE '%Ação%'", " ( Descrição LIKE '%Ação%' ) ")]
    [InlineData("Price = '€100'", " ( Price = '€100' ) ")]
    [InlineData("Comment = '测试'", " ( Comment = '测试' ) ")]
    public void Embrace_WithUnicodeCharacters_ShouldHandleCorrectly(string whereClause, string expected)
    {
        // Act
        var result = TSql.Embrace(whereClause);

        // Assert
        result.Should().Be(expected);
    }

    #endregion

    #region SQL Injection Prevention Tests (for documentation purposes)

    [Theory]
    [InlineData("Name = 'Robert'; DROP TABLE Users; --", " ( Name = 'Robert'; DROP TABLE Users; -- ) ")]
    [InlineData("1=1 OR 'a'='a'", " ( 1=1 OR 'a'='a' ) ")]
    [InlineData("' OR '1'='1", " ( ' OR '1'='1 ) ")]
    public void Embrace_WithPotentialSqlInjectionStrings_ShouldWrapWithoutValidation(string whereClause, string expected)
    {
        // NOTE: The Embrace method is a simple wrapper and does not provide SQL injection protection
        // This test documents the behavior - actual SQL injection protection should be handled
        // at the parameter level using parameterized queries

        // Act
        var result = TSql.Embrace(whereClause);

        // Assert
        result.Should().Be(expected);
    }

    #endregion

    #region Real-world Usage Pattern Tests

    [Fact]
    public void TSql_TypicalUsagePattern_BuildingDynamicWhereClause()
    {
        // Arrange
        var conditions = new List<string>();
        
        // Simulate building dynamic conditions
        conditions.Add("IsActive = 1");
        conditions.Add("CreatedDate >= '2023-01-01'");
        conditions.Add("Status IN ('PENDING', 'APPROVED')");

        // Act
        var whereClause = string.Join(TSql.And, conditions.Select(c => TSql.Embrace(c)));
        var fullQuery = TSql.Select + "*" + TSql.From + "Documents" + TSql.Where + whereClause;

        // Assert
        whereClause.Should().Be(" ( IsActive = 1 )  AND  ( CreatedDate >= '2023-01-01' )  AND  ( Status IN ('PENDING', 'APPROVED') ) ");
        fullQuery.Should().Contain("SELECT");
        fullQuery.Should().Contain("FROM Documents");
        fullQuery.Should().Contain("WHERE");
    }

    [Fact]
    public void TSql_BuildingSelectWithMultipleColumns()
    {
        // Arrange
        var columns = new[] { "Id", "Name", "Email", "CreatedDate" };

        // Act
        var columnList = string.Join(TSql.Virgula, columns);
        var query = TSql.Select + columnList + TSql.From + "Users";

        // Assert
        columnList.Should().Be("Id, Name, Email, CreatedDate");
        query.Should().Be(" SELECT Id, Name, Email, CreatedDate FROM Users");
    }

    [Fact]
    public void TSql_BuildingOrderByWithMultipleColumns()
    {
        // Arrange
        var orderColumns = new[] { "Name ASC", "CreatedDate DESC", "Id" };

        // Act
        var orderByClause = string.Join(TSql.Virgula, orderColumns);
        var query = TSql.Select + "*" + TSql.From + "Users" + TSql.OrderBy + orderByClause;

        // Assert
        orderByClause.Should().Be("Name ASC, CreatedDate DESC, Id");
        query.Should().EndWith(" ORDER BY Name ASC, CreatedDate DESC, Id");
    }

    #endregion
}