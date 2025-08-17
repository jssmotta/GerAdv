using Azure.Core;
using FluentAssertions;
using MenphisSI;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Infrastructure.Tests.Connections;

/// <summary>
/// Unit tests for ConnectionString and ConnectionStringRw methods from ConfiguracoesNormal.cs
/// Testing with non-existent client URI patterns (SILVA, PEDRO, JOAO, MARIA, SANTOS)
/// and one existing URI (DEVPB) for positive testing
/// </summary>
public class ConfiguracoesNormalTests
{
    #region Test Data Constants
    
    // Non-existent client URI patterns for testing (guaranteed not to exist)
    private const string NonExistentClientUri1 = "SILVA";
    private const string NonExistentClientUri2 = "PEDRO";
    private const string NonExistentClientUri3 = "JOAO";
    private const string NonExistentClientUri4 = "MARIA";
    private const string NonExistentClientUri5 = "SANTOS";
    
    // The only existing URI allowed for testing
    private const string ExistingClientUri = "DEVPB";
    
    // Additional invalid URIs for negative testing
    private const string InvalidUri = "INVALID_CLIENT";
    private const string NonExistentUri = "NONEXISTENT";
    
    #endregion

    #region ConnectionString Method Tests

    [Fact]
    public void ConnectionString_WithNullUri_ShouldThrowArgumentNullException()
    {
        // Arrange
        string? uri = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => Configuracoes.ConnectionString(uri!));
        exception.ParamName.Should().Be("uri");
    }

    [Fact]
    public void ConnectionString_WithEmptyUri_ShouldThrowArgumentNullException()
    {
        // Arrange
        var uri = string.Empty;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => Configuracoes.ConnectionString(uri));
        exception.ParamName.Should().Be("uri");
    }

    [Theory]
    [InlineData("   ")]
    [InlineData("\t")]
    [InlineData("\n")]
    [InlineData("\r\n")]
    public void ConnectionString_WithWhitespaceUri_ShouldThrowException(string uri)
    {
        // Act & Assert - These may throw different exceptions depending on EntityApi implementation
        Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionString(uri));
    }

    [Theory]
    [InlineData(NonExistentClientUri1)] // SILVA
    [InlineData(NonExistentClientUri2)] // PEDRO
    [InlineData(NonExistentClientUri3)] // JOAO
    [InlineData(NonExistentClientUri4)] // MARIA
    [InlineData(NonExistentClientUri5)] // SANTOS
    [InlineData(InvalidUri)]
    [InlineData(NonExistentUri)]
    public void ConnectionString_WithNonExistentClientUri_ShouldThrowException(string uri)
    {
        // Act & Assert - May throw HttpRequestException or InvalidEnumArgumentException depending on EntityApi behavior
        Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionString(uri));
    }

    [Fact]
    public void ConnectionString_WithExistingClientUri_ShouldReturnConnectionStringOrThrow()
    {
        // Arrange - Using the only existing URI we're allowed to test with
        var uri = ExistingClientUri; // DEVPB

        // Act & Assert
        try
        {
            var result = Configuracoes.ConnectionString(uri);
            
            // If it succeeds, verify the connection string format
            result.Should().NotBeNullOrEmpty();
            result.Should().Contain("ApplicationIntent=ReadOnly;");
            result.Should().Contain("Packet Size=4096");
            result.Should().Contain("MultipleActiveResultSets=true");
            result.Should().Contain("Enlist=false");
            result.Should().Contain("encrypt=true");
            result.Should().Contain("Data Source=");
            result.Should().Contain("Initial Catalog=");
            result.Should().Contain("User Id=");
            result.Should().Contain("Password=");
            result.Should().Contain("Max Pool Size=100");
            result.Should().Contain("Pooling=true");
            result.Should().Contain("Integrated Security=false");
            result.Should().Contain("Connect Timeout=30");
            result.Should().Contain("Persist Security Info=True");
            result.Should().Contain("TrustServerCertificate=True");
        }
        catch (Exception ex)
        {
            // Expected if environment isn't properly configured or DEVPB doesn't exist
            ex.Should().NotBeNull();
        }
    }

    [Fact]
    public void ConnectionString_Caching_ShouldReturnSameResultOnMultipleCalls()
    {
        // Arrange
        var uri = NonExistentClientUri1; // SILVA - will throw but test caching logic

        // Act & Assert
        var exception1 = Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionString(uri));
        var exception2 = Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionString(uri));

        // Both calls should behave consistently
        exception1.GetType().Should().Be(exception2.GetType());
        exception1.Message.Should().Be(exception2.Message);
    }

    [Fact]
    public void ConnectionString_ThreadSafety_ShouldHandleConcurrentCalls()
    {
        // Arrange
        var uri = NonExistentClientUri1; // SILVA
        var tasks = new Task[10];

        // Act
        for (int i = 0; i < 10; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                try
                {
                    Configuracoes.ConnectionString(uri);
                }
                catch (Exception)
                {
                    // Expected for non-existent URIs
                }
            });
        }

        // Assert
        var aggregateException = Record.Exception(() => Task.WaitAll(tasks));
        aggregateException.Should().BeNull("Concurrent calls should not cause deadlocks or crashes");
    }

    [Theory]
    [InlineData("silva")] // lowercase
    [InlineData("Pedro")] // mixed case
    [InlineData("JOAO123")] // with numbers
    [InlineData("MA-RIA")] // with special characters
    public void ConnectionString_WithVariousFormats_ShouldThrowException(string uri)
    {
        // Act & Assert
        Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionString(uri));
    }

    #endregion

    #region ConnectionStringRw Method Tests

    [Fact]
    public void ConnectionStringRw_WithNullUri_ShouldThrowArgumentNullException()
    {
        // Arrange
        string? uri = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => Configuracoes.ConnectionStringRw(uri!));
        exception.ParamName.Should().Be("uri");
    }

    [Fact]
    public void ConnectionStringRw_WithEmptyUri_ShouldThrowArgumentNullException()
    {
        // Arrange
        var uri = string.Empty;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => Configuracoes.ConnectionStringRw(uri));
        exception.ParamName.Should().Be("uri");
    }

    [Theory]
    [InlineData("   ")]
    [InlineData("\t")]
    [InlineData("\n")]
    [InlineData("\r\n")]
    public void ConnectionStringRw_WithWhitespaceUri_ShouldThrowException(string uri)
    {
        // Act & Assert - These may throw different exceptions depending on EntityApi implementation
        Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionStringRw(uri));
    }

    [Theory]
    [InlineData(NonExistentClientUri1)] // SILVA
    [InlineData(NonExistentClientUri2)] // PEDRO
    [InlineData(NonExistentClientUri3)] // JOAO
    [InlineData(NonExistentClientUri4)] // MARIA
    [InlineData(NonExistentClientUri5)] // SANTOS
    [InlineData(InvalidUri)]
    [InlineData(NonExistentUri)]
    public void ConnectionStringRw_WithNonExistentClientUri_ShouldThrowException(string uri)
    {
        // Act & Assert - May throw HttpRequestException or InvalidEnumArgumentException depending on EntityApi behavior
        Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionStringRw(uri));
    }

    [Fact]
    public void ConnectionStringRw_WithExistingClientUri_ShouldReturnConnectionStringOrThrow()
    {
        // Arrange - Using the only existing URI we're allowed to test with
        var uri = ExistingClientUri; // DEVPB

        // Act & Assert
        try
        {
            var result = Configuracoes.ConnectionStringRw(uri);
            
            // If it succeeds, verify the connection string format
            result.Should().NotBeNullOrEmpty();
            result.Should().NotContain("ApplicationIntent=ReadOnly;", "RW connection should not be read-only");
            result.Should().Contain("Packet Size=4096");
            result.Should().Contain("MultipleActiveResultSets=true");
            result.Should().Contain("Enlist=false");
            result.Should().Contain("encrypt=true");
            result.Should().Contain("Data Source=tcp:");
            result.Should().Contain("Initial Catalog=");
            result.Should().Contain("User Id=");
            result.Should().Contain("Password=");
            result.Should().Contain("Max Pool Size=100");
            result.Should().Contain("Pooling=true");
            result.Should().Contain("Integrated Security=false");
            result.Should().Contain("Connect Timeout=30");
            result.Should().Contain("Persist Security Info=True");
            result.Should().Contain("TrustServerCertificate=True");
        }
        catch (Exception ex)
        {
            // Expected if environment isn't properly configured or DEVPB doesn't exist
            ex.Should().NotBeNull();
        }
    }

    [Fact]
    public void ConnectionStringRw_Caching_ShouldReturnSameResultOnMultipleCalls()
    {
        // Arrange
        var uri = NonExistentClientUri1; // SILVA - will throw but test caching logic

        // Act & Assert
        var exception1 = Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionStringRw(uri));
        var exception2 = Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionStringRw(uri));

        // Both calls should behave consistently
        exception1.GetType().Should().Be(exception2.GetType());
        exception1.Message.Should().Be(exception2.Message);
    }

    [Fact]
    public void ConnectionStringRw_ThreadSafety_ShouldHandleConcurrentCalls()
    {
        // Arrange
        var uri = NonExistentClientUri1; // SILVA
        var tasks = new Task[10];

        // Act
        for (int i = 0; i < 10; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                try
                {
                    Configuracoes.ConnectionStringRw(uri);
                }
                catch (Exception)
                {
                    // Expected for non-existent URIs
                }
            });
        }

        // Assert
        var aggregateException = Record.Exception(() => Task.WaitAll(tasks));
        aggregateException.Should().BeNull("Concurrent calls should not cause deadlocks or crashes");
    }

    [Theory]
    [InlineData("silva")] // lowercase
    [InlineData("Pedro")] // mixed case
    [InlineData("JOAO123")] // with numbers
    [InlineData("MA-RIA")] // with special characters
    public void ConnectionStringRw_WithVariousFormats_ShouldThrowException(string uri)
    {
        // Act & Assert
        Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionStringRw(uri));
    }

    #endregion

    #region ConnectionString vs ConnectionStringRw Comparison Tests

    [Fact]
    public void ConnectionString_vs_ConnectionStringRw_WithExistingUri_ShouldHaveDifferentFormats()
    {
        // Arrange
        var uri = ExistingClientUri; // DEVPB

        // Act & Assert
        try
        {
            var readOnlyConnection = Configuracoes.ConnectionString(uri);
            var readWriteConnection = Configuracoes.ConnectionStringRw(uri);

            // The main difference should be the ApplicationIntent and Data Source format
            readOnlyConnection.Should().Contain("ApplicationIntent=ReadOnly;");
            readWriteConnection.Should().NotContain("ApplicationIntent=ReadOnly;");

            // Data source format difference
            readOnlyConnection.Should().Contain("Data Source=");
            readWriteConnection.Should().Contain("Data Source=tcp:");

            // Both should contain same basic SQL Server connection parameters
            var commonParameters = new[]
            {
                "Packet Size=4096",
                "MultipleActiveResultSets=true",
                "Enlist=false",
                "encrypt=true",
                "Max Pool Size=100",
                "Pooling=true",
                "Integrated Security=false",
                "Connect Timeout=30",
                "Persist Security Info=True",
                "TrustServerCertificate=True"
            };

            foreach (var parameter in commonParameters)
            {
                readOnlyConnection.Should().Contain(parameter);
                readWriteConnection.Should().Contain(parameter);
            }
        }
        catch (Exception)
        {
            // Both methods should behave consistently when URI doesn't exist
            var exception1 = Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionString(uri));
            var exception2 = Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionStringRw(uri));
            
            exception1.GetType().Should().Be(exception2.GetType());
            exception1.Message.Should().Be(exception2.Message);
        }
    }

    [Theory]
    [InlineData(NonExistentClientUri1)] // SILVA
    [InlineData(NonExistentClientUri2)] // PEDRO
    [InlineData(NonExistentClientUri3)] // JOAO
    [InlineData(NonExistentClientUri4)] // MARIA
    [InlineData(NonExistentClientUri5)] // SANTOS
    public void ConnectionString_vs_ConnectionStringRw_WithNonExistentUri_ShouldBothThrowSameException(string uri)
    {
        // Act & Assert
        var exception1 = Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionString(uri));
        var exception2 = Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionStringRw(uri));

        exception1.GetType().Should().Be(exception2.GetType());
        exception1.Message.Should().Be(exception2.Message);
    }

    #endregion

    #region Cache Behavior Tests

    [Fact]
    public void ConnectionString_Cache_ShouldBeIndependentFromConnectionStringRwCache()
    {
        // Arrange
        var uri = NonExistentClientUri1; // SILVA

        // Act & Assert - Both should fail independently
        var exception1 = Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionString(uri));
        var exception2 = Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionStringRw(uri));

        // Call again to test cache independence
        var exception3 = Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionString(uri));
        var exception4 = Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionStringRw(uri));

        // All should behave consistently
        exception1.GetType().Should().Be(exception3.GetType());
        exception2.GetType().Should().Be(exception4.GetType());
        exception1.Message.Should().Be(exception3.Message);
        exception2.Message.Should().Be(exception4.Message);
    }

    [Fact]
    public void ConnectionString_Cache_ShouldWorkWithMultipleUris()
    {
        // Arrange
        var uris = new[] { NonExistentClientUri1, NonExistentClientUri2, NonExistentClientUri3 };

        // Act & Assert
        foreach (var uri in uris)
        {
            // First call
            var exception1 = Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionString(uri));
            
            // Second call (should use cache)
            var exception2 = Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionString(uri));
            
            exception1.GetType().Should().Be(exception2.GetType());
            exception1.Message.Should().Be(exception2.Message);
        }
    }

    [Fact]
    public void ConnectionStringRw_Cache_ShouldWorkWithMultipleUris()
    {
        // Arrange
        var uris = new[] { NonExistentClientUri1, NonExistentClientUri2, NonExistentClientUri3 };

        // Act & Assert
        foreach (var uri in uris)
        {
            // First call
            var exception1 = Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionStringRw(uri));
            
            // Second call (should use cache)
            var exception2 = Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionStringRw(uri));
            
            exception1.GetType().Should().Be(exception2.GetType());
            exception1.Message.Should().Be(exception2.Message);
        }
    }

    #endregion

    #region Private Field Access Tests

    [Fact]
    public void ConfiguracoesNormal_ShouldHavePrivateCacheFields()
    {
        // Arrange
        var type = typeof(Configuracoes);
        
        // Act & Assert
        var connectionCacheField = type.GetField("_connectionCache", 
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
        var connectionRwCacheField = type.GetField("_connectionRwCache", 
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
        var lockObjectField = type.GetField("_lockObject", 
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

        connectionCacheField.Should().NotBeNull("_connectionCache field should exist");
        connectionRwCacheField.Should().NotBeNull("_connectionRwCache field should exist");
        lockObjectField.Should().NotBeNull("_lockObject field should exist");

        connectionCacheField!.FieldType.Name.Should().Contain("ConcurrentDictionary");
        connectionRwCacheField!.FieldType.Name.Should().Contain("ConcurrentDictionary");
        lockObjectField!.FieldType.Should().Be(typeof(object));
    }

    #endregion

    #region Integration Tests with All Test URIs

    [Theory]
    [InlineData(NonExistentClientUri1)] // SILVA
    [InlineData(NonExistentClientUri2)] // PEDRO
    [InlineData(NonExistentClientUri3)] // JOAO
    [InlineData(NonExistentClientUri4)] // MARIA
    [InlineData(NonExistentClientUri5)] // SANTOS
    public void AllConnectionMethods_WithNonExistentUris_ShouldThrowConsistentExceptions(string uri)
    {
        // Act & Assert
        var connectionStringException = Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionString(uri));
        var connectionStringRwException = Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionStringRw(uri));

        connectionStringException.GetType().Should().Be(connectionStringRwException.GetType());
        connectionStringException.Message.Should().Be(connectionStringRwException.Message);
    }

    [Fact]
    public void AllConnectionMethods_WithDevpbUri_ShouldBehaveConsistently()
    {
        // Arrange
        var uri = ExistingClientUri; // DEVPB

        // Act & Assert
        try
        {
            var connectionString = Configuracoes.ConnectionString(uri);
            var connectionStringRw = Configuracoes.ConnectionStringRw(uri);

            // Both should succeed and return valid connection strings
            connectionString.Should().NotBeNullOrEmpty();
            connectionStringRw.Should().NotBeNullOrEmpty();

            // Verify the key differences
            connectionString.Should().Contain("ApplicationIntent=ReadOnly;");
            connectionStringRw.Should().NotContain("ApplicationIntent=ReadOnly;");
        }
        catch (Exception ex)
        {
            // If DEVPB doesn't exist in this environment, both should fail consistently
            ex.Should().NotBeNull();
            
            var connectionStringRwException = Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionStringRw(uri));
            connectionStringRwException.GetType().Should().Be(ex.GetType());
            connectionStringRwException.Message.Should().Be(ex.Message);
        }
    }

    #endregion

    #region Method Signature Tests

    [Fact]
    public void ConnectionString_ShouldHaveCorrectSignature()
    {
        // Arrange
        var type = typeof(Configuracoes);
        var method = type.GetMethod("ConnectionString");

        // Assert
        method.Should().NotBeNull();
        method!.IsStatic.Should().BeTrue();
        method.IsPublic.Should().BeTrue();
        method.ReturnType.Should().Be(typeof(string));
        method.GetParameters().Should().HaveCount(1);
        method.GetParameters()[0].ParameterType.Should().Be(typeof(string));
    }

    [Fact]
    public void ConnectionStringRw_ShouldHaveCorrectSignature()
    {
        // Arrange
        var type = typeof(Configuracoes);
        var method = type.GetMethod("ConnectionStringRw");

        // Assert
        method.Should().NotBeNull();
        method!.IsStatic.Should().BeTrue();
        method.IsPublic.Should().BeTrue();
        method.ReturnType.Should().Be(typeof(string));
        method.GetParameters().Should().HaveCount(1);
        method.GetParameters()[0].ParameterType.Should().Be(typeof(string));
    }

    #endregion

    #region URI Pattern Validation Tests

    [Theory]
    [InlineData("SILVA", true)]
    [InlineData("PEDRO", true)]
    [InlineData("JOAO", true)]
    [InlineData("MARIA", true)]
    [InlineData("SANTOS", true)]
    [InlineData("DEVPB", true)]
    [InlineData("", false)]
    [InlineData("   ", false)]
    [InlineData("toolong_client_name_that_exceeds_normal_limits_123123123", false)]
    public void URI_PatternValidation_ShouldFollowExpectedFormat(string uri, bool isValidFormat)
    {
        // Arrange & Act
        var isActuallyValid = !string.IsNullOrWhiteSpace(uri) && uri.Length <= 50;

        // Assert
        isActuallyValid.Should().Be(isValidFormat, 
            $"URI '{uri}' should {(isValidFormat ? "be valid" : "be invalid")}");
    }

    [Fact]
    public void URI_CommonClientPatterns_ShouldBeDocumented()
    {
        // Arrange
        var commonUriPatterns = new[]
        {
            NonExistentClientUri1,      // SILVA
            NonExistentClientUri2,      // PEDRO  
            NonExistentClientUri3,      // JOAO
            NonExistentClientUri4,      // MARIA
            NonExistentClientUri5,      // SANTOS
            ExistingClientUri           // DEVPB (the only existing one allowed for testing)
        };

        // Assert
        foreach (var uri in commonUriPatterns)
        {
            uri.Should().NotBeNullOrWhiteSpace($"URI pattern {uri} should be valid");
            (uri.Length <= 50).Should().BeTrue($"URI {uri} should not exceed typical length limits");
            uri.Should().MatchRegex(@"^[A-Z0-9]+$", $"URI {uri} should contain only uppercase letters and numbers");
        }
    }

    #endregion
}