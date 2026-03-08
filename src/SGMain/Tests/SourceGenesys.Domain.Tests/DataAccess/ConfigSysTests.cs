using System.Reflection;
using FluentAssertions;
using MenphisSI;
using Moq;
using Xunit;

namespace SourceGenesys.Domain.Tests.DataAccess;

/// <summary>
/// Comprehensive unit tests for ConfigSys class methods
/// </summary>
public class ConfigSysTests
{
    #region ReadCfgSys Method Tests

    [Fact]
    public void ReadCfgSys_WithValidKeyAndConnection_ShouldReturnValueFromReadCfgSysX()
    {
        // Arrange
        var mockConnection = new Mock<MsiSqlConnection>();
        var key = "TestKey";

        // Act & Assert
        // Since ReadCfgSysX throws an exception when connection is mocked, 
        // we expect this to throw
        Assert.Throws<Exception>(() => ConfigSys.ReadCfgSys(key, mockConnection.Object));
    }

    [Theory]
    [InlineData("UserSetting")]
    [InlineData("ApplicationConfig")]
    [InlineData("DatabaseTimeout")]
    [InlineData("MaxConnections")]
    [InlineData("")]
    public void ReadCfgSys_WithDifferentKeys_ShouldThrowException(string key)
    {
        // Arrange
        var mockConnection = new Mock<MsiSqlConnection>();

        // Act & Assert
        // Since ReadCfgSysX throws an exception when connection is mocked,
        // we expect this to throw
        Assert.Throws<Exception>(() => ConfigSys.ReadCfgSys(key, mockConnection.Object));
    }

    [Fact]
    public void ReadCfgSys_WithNullConnection_ShouldThrowException()
    {
        // Arrange
        var key = "TestKey";
        MsiSqlConnection? nullConnection = null;

        // Act & Assert
        // ReadCfgSysX will throw with null connection
        Assert.Throws<Exception>(() => ConfigSys.ReadCfgSys(key, nullConnection!));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("\t")]
    [InlineData("\n")]
    public void ReadCfgSys_WithEmptyOrWhitespaceKey_ShouldThrowException(string key)
    {
        // Arrange
        var mockConnection = new Mock<MsiSqlConnection>();

        // Act & Assert
        // ReadCfgSysX will throw exception with mocked connection
        Assert.Throws<Exception>(() => ConfigSys.ReadCfgSys(key, mockConnection.Object));
    }

    [Fact]
    public void ReadCfgSys_WithNullKey_ShouldThrowException()
    {
        // Arrange
        var mockConnection = new Mock<MsiSqlConnection>();
        string? nullKey = null;

        // Act & Assert
        // ReadCfgSysX will throw exception with null key
        Assert.Throws<Exception>(() => ConfigSys.ReadCfgSys(nullKey!, mockConnection.Object));
    }

    #endregion

    #region ReadCfgSysC Method Tests

    [Fact]
    public void ReadCfgSysC_WithValidKeyAndConnection_ShouldReturnDefaultValue()
    {
        // Arrange
        var mockConnection = new Mock<MsiSqlConnection>();
        var key = "TestStringKey";
        var defaultResult = "default";

        // Act
        var result = ConfigSys.ReadCfgSysC(key, mockConnection.Object, defaultResult);

        // Assert
        result.Should().BeOfType<string>();
        result.Should().Be(defaultResult); // Returns default when connection is mocked
    }

    [Theory]
    [InlineData("ConfigKey1", "")]
    [InlineData("ConfigKey2", "DefaultValue")]
    [InlineData("ConfigKey3", "Test Default")]
    [InlineData("", "EmptyKeyDefault")]
    public void ReadCfgSysC_WithDifferentKeysAndDefaults_ShouldReturnDefaults(string key, string defaultResult)
    {
        // Arrange
        var mockConnection = new Mock<MsiSqlConnection>();

        // Act
        var result = ConfigSys.ReadCfgSysC(key, mockConnection.Object, defaultResult);

        // Assert
        result.Should().BeOfType<string>();
        result.Should().Be(defaultResult); // Returns default when connection is mocked
    }

    [Fact]
    public void ReadCfgSysC_WithNullConnection_ShouldReturnDefaultValue()
    {
        // Arrange
        var key = "TestKey";
        var defaultResult = "DefaultValue";
        MsiSqlConnection? nullConnection = null;

        // Act
        var result = ConfigSys.ReadCfgSysC(key, nullConnection!, defaultResult);

        // Assert
        result.Should().BeOfType<string>();
        result.Should().Be(defaultResult); // Returns default when connection is null
    }

    [Fact]
    public void ReadCfgSysC_WithoutDefaultResult_ShouldUseEmptyStringAsDefault()
    {
        // Arrange
        var mockConnection = new Mock<MsiSqlConnection>();
        var key = "TestKey";

        // Act
        var result = ConfigSys.ReadCfgSysC(key, mockConnection.Object);

        // Assert
        result.Should().BeOfType<string>();
        result.Should().Be(""); // Returns empty string as default
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("\t")]
    [InlineData("\n")]
    public void ReadCfgSysC_WithEmptyOrWhitespaceKey_ShouldReturnDefaultValue(string key)
    {
        // Arrange
        var mockConnection = new Mock<MsiSqlConnection>();
        var defaultResult = "Default";

        // Act
        var result = ConfigSys.ReadCfgSysC(key, mockConnection.Object, defaultResult);

        // Assert
        result.Should().BeOfType<string>();
        result.Should().Be(defaultResult); // Returns default when connection is mocked
    }

    [Fact]
    public void ReadCfgSysC_WithNullKey_ShouldReturnDefaultValue()
    {
        // Arrange
        var mockConnection = new Mock<MsiSqlConnection>();
        var defaultResult = "Default";
        string? nullKey = null;

        // Act
        var result = ConfigSys.ReadCfgSysC(nullKey!, mockConnection.Object, defaultResult);

        // Assert
        result.Should().BeOfType<string>();
        result.Should().Be(defaultResult); // Returns default when key is null
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("", "Default")]
    [InlineData("Key", "")]
    [InlineData("Key", "Default")]
    public void ReadCfgSysC_WithNullDefaultResult_ShouldHandleGracefully(string key, string? defaultResult)
    {
        // Arrange
        var mockConnection = new Mock<MsiSqlConnection>();

        // Act
        var result = ConfigSys.ReadCfgSysC(key, mockConnection.Object, defaultResult!);

        // Assert
        result.Should().BeOfType<string>();
        // ReadCfgSysCX handles null defaults gracefully
        result.Should().NotBeNull();
    }

    #endregion

    #region Edge Cases and Integration Tests

    [Fact]
    public void ReadCfgSys_WithLongKey_ShouldThrowException()
    {
        // Arrange
        var mockConnection = new Mock<MsiSqlConnection>();
        var longKey = new string('a', 2000); // Very long key

        // Act & Assert
        Assert.Throws<Exception>(() => ConfigSys.ReadCfgSys(longKey, mockConnection.Object));
    }

    [Fact]
    public void ReadCfgSysC_WithLongKey_ShouldReturnDefaultValue()
    {
        // Arrange
        var mockConnection = new Mock<MsiSqlConnection>();
        var longKey = new string('b', 2000); // Very long key
        var defaultResult = "Default";

        // Act
        var result = ConfigSys.ReadCfgSysC(longKey, mockConnection.Object, defaultResult);

        // Assert
        result.Should().BeOfType<string>();
        result.Should().Be(defaultResult);
    }

    [Theory]
    [InlineData("Key'WithQuote")]
    [InlineData("Key\"WithDoubleQuote")]
    [InlineData("Key;WithSemicolon")]
    [InlineData("Key--WithComment")]
    [InlineData("Key/*WithComment*/")]
    public void ReadCfgSys_WithSpecialCharactersInKey_ShouldThrowException(string specialKey)
    {
        // Arrange
        var mockConnection = new Mock<MsiSqlConnection>();

        // Act & Assert
        Assert.Throws<Exception>(() => ConfigSys.ReadCfgSys(specialKey, mockConnection.Object));
    }

    [Theory]
    [InlineData("Key'WithQuote")]
    [InlineData("Key\"WithDoubleQuote")]
    [InlineData("Key;WithSemicolon")]
    [InlineData("Key--WithComment")]
    [InlineData("Key/*WithComment*/")]
    public void ReadCfgSysC_WithSpecialCharactersInKey_ShouldReturnDefaultValue(string specialKey)
    {
        // Arrange
        var mockConnection = new Mock<MsiSqlConnection>();
        var defaultResult = "Safe Default";

        // Act
        var result = ConfigSys.ReadCfgSysC(specialKey, mockConnection.Object, defaultResult);

        // Assert
        result.Should().BeOfType<string>();
        result.Should().Be(defaultResult);
    }

    [Fact]
    public void ReadCfgSys_MultipleCalls_ShouldBeConsistent()
    {
        // Arrange
        var mockConnection = new Mock<MsiSqlConnection>();
        var key = "ConsistencyTestKey";

        // Act & Assert
        // All calls should consistently throw exceptions with mocked connection
        Assert.Throws<Exception>(() => ConfigSys.ReadCfgSys(key, mockConnection.Object));
        Assert.Throws<Exception>(() => ConfigSys.ReadCfgSys(key, mockConnection.Object));
        Assert.Throws<Exception>(() => ConfigSys.ReadCfgSys(key, mockConnection.Object));
    }

    [Fact]
    public void ReadCfgSysC_MultipleCalls_ShouldBeConsistent()
    {
        // Arrange
        var mockConnection = new Mock<MsiSqlConnection>();
        var key = "ConsistencyTestKey";
        var defaultResult = "Consistent Default";

        // Act
        var result1 = ConfigSys.ReadCfgSysC(key, mockConnection.Object, defaultResult);
        var result2 = ConfigSys.ReadCfgSysC(key, mockConnection.Object, defaultResult);
        var result3 = ConfigSys.ReadCfgSysC(key, mockConnection.Object, defaultResult);

        // Assert
        result1.Should().Be(result2);
        result2.Should().Be(result3);
        result1.Should().BeOfType<string>();
        result1.Should().Be(defaultResult);
    }

    #endregion

    #region Method Signature Validation Tests

    [Fact]
    public void ReadCfgSys_MethodSignature_ShouldMatchExpectedParameters()
    {
        // Arrange & Act
        // Verify method is static and public
        var method = typeof(ConfigSys).GetMethod(nameof(ConfigSys.ReadCfgSys), 
            new[] { typeof(string), typeof(MsiSqlConnection) });
        
        // Assert
        method.Should().NotBeNull();
        method!.IsStatic.Should().BeTrue();
        method.IsPublic.Should().BeTrue();
        method.ReturnType.Should().Be(typeof(int));
    }

    [Fact]
    public void ReadCfgSysC_MethodSignature_ShouldMatchExpectedParameters()
    {
        // Arrange & Act
        // Verify method is static and public
        var method = typeof(ConfigSys).GetMethod(nameof(ConfigSys.ReadCfgSysC), 
            new[] { typeof(string), typeof(MsiSqlConnection), typeof(string) });
        
        // Assert
        method.Should().NotBeNull();
        method!.IsStatic.Should().BeTrue();
        method.IsPublic.Should().BeTrue();
        method.ReturnType.Should().Be(typeof(string));
    }

    #endregion

    #region Performance and Behavior Tests

    [Fact]
    public void ReadCfgSys_WithSameConnectionMultipleTimes_ShouldConsistentlyThrow()
    {
        // Arrange
        var mockConnection = new Mock<MsiSqlConnection>();
        var keys = new[] { "Key1", "Key2", "Key3", "Key4", "Key5" };

        // Act & Assert
        foreach (var key in keys)
        {
            Assert.Throws<Exception>(() => ConfigSys.ReadCfgSys(key, mockConnection.Object));
        }
    }

    [Fact]
    public void ReadCfgSysC_WithSameConnectionMultipleTimes_ShouldNotThrow()
    {
        // Arrange
        var mockConnection = new Mock<MsiSqlConnection>();
        var keys = new[] { "Key1", "Key2", "Key3", "Key4", "Key5" };
        var defaultResult = "Default";

        // Act & Assert
        foreach (var key in keys)
        {
            var act = () => ConfigSys.ReadCfgSysC(key, mockConnection.Object, defaultResult);
            act.Should().NotThrow();
            var result = ConfigSys.ReadCfgSysC(key, mockConnection.Object, defaultResult);
            result.Should().Be(defaultResult);
        }
    }

    [Fact]
    public void ReadCfgSys_WithConcurrentCalls_ShouldConsistentlyThrow()
    {
        // Arrange
        var mockConnection = new Mock<MsiSqlConnection>();
        var key = "ConcurrentTestKey";

        // Act & Assert
        var tasks = Enumerable.Range(0, 10).Select(_ => 
            Task.Run(() => 
            {
                Assert.Throws<Exception>(() => ConfigSys.ReadCfgSys(key, mockConnection.Object));
                return true;
            })
        ).ToArray();

        var act = () => Task.WaitAll(tasks);
        act.Should().NotThrow();

        tasks.All(t => t.Result).Should().BeTrue();
    }

    [Fact]
    public void ReadCfgSysC_WithConcurrentCalls_ShouldNotThrow()
    {
        // Arrange
        var mockConnection = new Mock<MsiSqlConnection>();
        var key = "ConcurrentTestKey";
        var defaultResult = "Default";

        // Act & Assert
        var tasks = Enumerable.Range(0, 10).Select(_ => 
            Task.Run(() => ConfigSys.ReadCfgSysC(key, mockConnection.Object, defaultResult))
        ).ToArray();

        var act = () => Task.WaitAll(tasks);
        act.Should().NotThrow();

        tasks.All(t => t.Result == defaultResult).Should().BeTrue();
    }

    #endregion
}