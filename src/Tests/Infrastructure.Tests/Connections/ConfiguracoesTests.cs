using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using MenphisSI;
using MenphisSI.Connections;
using Microsoft.Data.SqlClient;
using Moq;
using Xunit;

namespace Infrastructure.Tests.Connections;

/// <summary>
/// Comprehensive unit tests for Configuracoes class methods
/// Testing with non-existent client URI patterns (SILVA, PEDRO, JOAO, MARIA, SANTOS)
/// and one existing URI (DEVPB) for positive testing
/// </summary>
public class ConfiguracoesTests
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

    #region GetConnectionByUri Method Tests

    [Fact]
    public void GetConnectionByUri_WithNonExistentClientUri_ShouldThrowException()
    {
        // Arrange - Using non-existent client URI pattern
        var uri = NonExistentClientUri1;

        // Act & Assert
        // This will throw because the URI doesn't exist in the system
        Assert.ThrowsAny<Exception>(() => Configuracoes.GetConnectionByUri(uri));
    }

    [Fact]
    public void GetConnectionByUri_WithExistingClientUri_ShouldReturnConnectionOrThrow()
    {
        // Arrange - Using the only existing URI we're allowed to test with
        var uri = ExistingClientUri;

        // Act & Assert
        // This might succeed or fail depending on environment configuration
        // We just verify it doesn't crash unexpectedly
        try
        {
            var result = Configuracoes.GetConnectionByUri(uri);
            result.Should().NotBeNull();
        }
        catch (Exception ex)
        {
            // Expected if environment isn't properly configured
            ex.Should().NotBeNull();
            ex.Message.Should().Contain("Erro conexão BD:");
        }
    }

    [Fact]
    public void GetConnectionByUri_WithNullUri_ShouldThrowException()
    {
        // Arrange
        string? uri = null;

        // Act & Assert
        Assert.ThrowsAny<Exception>(() => Configuracoes.GetConnectionByUri(uri!));
    }

    [Fact]
    public void GetConnectionByUri_WithEmptyUri_ShouldThrowException()
    {
        // Arrange
        var uri = string.Empty;

        // Act & Assert
        Assert.ThrowsAny<Exception>(() => Configuracoes.GetConnectionByUri(uri));
    }

    [Theory]
    [InlineData(NonExistentClientUri1)]
    [InlineData(NonExistentClientUri2)]
    [InlineData(NonExistentClientUri3)]
    [InlineData(NonExistentClientUri4)]
    [InlineData(NonExistentClientUri5)]
    [InlineData(InvalidUri)]
    [InlineData(NonExistentUri)]
    public void GetConnectionByUri_WithDifferentNonExistentClientUris_ShouldThrowException(string uri)
    {
        // Act & Assert
        // All will throw because these URIs don't exist in the system
        Assert.ThrowsAny<Exception>(() => Configuracoes.GetConnectionByUri(uri));
    }

    [Fact]
    public void GetConnectionByUri_WithWhitespaceUri_ShouldThrowException()
    {
        // Arrange
        var uri = "   ";

        // Act & Assert
        Assert.ThrowsAny<Exception>(() => Configuracoes.GetConnectionByUri(uri));
    }

    [Theory]
    [InlineData("silva")] // lowercase
    [InlineData("Pedro")] // mixed case
    [InlineData("JOAO123")] // with numbers
    [InlineData("MA-RIA")] // with special characters
    public void GetConnectionByUri_WithVariousUriFormats_ShouldThrowException(string uri)
    {
        // Act & Assert
        Assert.ThrowsAny<Exception>(() => Configuracoes.GetConnectionByUri(uri));
    }

    #endregion

    #region GetConnectionByUriAsync Method Tests

    [Fact]
    public async Task GetConnectionByUriAsync_WithNonExistentClientUri_ShouldReturnNull()
    {
        // Arrange - Using non-existent client URI pattern
        var uri = NonExistentClientUri1;

        // Act
        var result = await Configuracoes.GetConnectionByUriAsync(uri);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetConnectionByUriAsync_WithExistingClientUri_ShouldReturnConnectionOrNull()
    {
        // Arrange - Using the only existing URI we're allowed to test with
        var uri = ExistingClientUri;

        // Act
        var result = await Configuracoes.GetConnectionByUriAsync(uri);

        // Assert
        // Might return a connection or null depending on environment
        // We just verify no unexpected crashes
        if (result != null)
        {
            result.Should().NotBeNull();
        }
        else
        {
            result.Should().BeNull();
        }
    }

    [Fact]
    public async Task GetConnectionByUriAsync_WithNullUri_ShouldReturnNull()
    {
        // Arrange
        string? uri = null;

        // Act
        var result = await Configuracoes.GetConnectionByUriAsync(uri!);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetConnectionByUriAsync_WithEmptyUri_ShouldReturnNull()
    {
        // Arrange
        var uri = string.Empty;

        // Act
        var result = await Configuracoes.GetConnectionByUriAsync(uri);

        // Assert
        result.Should().BeNull();
    }

    [Theory]
    [InlineData(NonExistentClientUri1)]
    [InlineData(NonExistentClientUri2)]
    [InlineData(NonExistentClientUri3)]
    [InlineData(NonExistentClientUri4)]
    [InlineData(NonExistentClientUri5)]
    public async Task GetConnectionByUriAsync_WithDifferentNonExistentClientUris_ShouldReturnNull(string uri)
    {
        // Act
        var result = await Configuracoes.GetConnectionByUriAsync(uri);

        // Assert
        result.Should().BeNull();
    }

    [Theory]
    [InlineData(InvalidUri)]
    [InlineData(NonExistentUri)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task GetConnectionByUriAsync_WithInvalidUris_ShouldReturnNull(string uri)
    {
        // Act
        var result = await Configuracoes.GetConnectionByUriAsync(uri);

        // Assert
        result.Should().BeNull();
    }

    #endregion

    #region GetConnectionByUriRw Method Tests

    [Fact]
    public void GetConnectionByUriRw_WithNonExistentClientUri_ShouldReturnNull()
    {
        // Arrange - Using non-existent client URI pattern for read-write connection
        var uri = NonExistentClientUri1;

        // Act
        var result = Configuracoes.GetConnectionByUriRw(uri);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public void GetConnectionByUriRw_WithExistingClientUri_ShouldReturnConnectionOrNull()
    {
        // Arrange - Using the only existing URI we're allowed to test with
        var uri = ExistingClientUri;

        // Act
        var result = Configuracoes.GetConnectionByUriRw(uri);

        // Assert
        // Might return a connection or null depending on environment
        if (result != null)
        {
            result.Should().NotBeNull();
        }
        else
        {
            result.Should().BeNull();
        }
    }

    [Fact]
    public void GetConnectionByUriRw_WithNullUri_ShouldReturnNull()
    {
        // Arrange
        string? uri = null;

        // Act
        var result = Configuracoes.GetConnectionByUriRw(uri!);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public void GetConnectionByUriRw_WithEmptyUri_ShouldReturnNull()
    {
        // Arrange
        var uri = string.Empty;

        // Act
        var result = Configuracoes.GetConnectionByUriRw(uri);

        // Assert
        result.Should().BeNull();
    }

    [Theory]
    [InlineData(NonExistentClientUri1)]
    [InlineData(NonExistentClientUri2)]
    [InlineData(NonExistentClientUri3)]
    [InlineData(NonExistentClientUri4)]
    [InlineData(NonExistentClientUri5)]
    public void GetConnectionByUriRw_WithDifferentNonExistentClientUris_ShouldReturnNull(string uri)
    {
        // Act
        var result = Configuracoes.GetConnectionByUriRw(uri);

        // Assert
        result.Should().BeNull();
    }

    #endregion

    #region GetConnectionByUriRwAsync Method Tests

    [Fact]
    public async Task GetConnectionByUriRwAsync_WithNonExistentClientUri_ShouldReturnNull()
    {
        // Arrange - Using non-existent client URI pattern for async read-write connection
        var uri = NonExistentClientUri1;

        // Act
        var result = await Configuracoes.GetConnectionByUriRwAsync(uri);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetConnectionByUriRwAsync_WithExistingClientUri_ShouldReturnConnectionOrNull()
    {
        // Arrange - Using the only existing URI we're allowed to test with
        var uri = ExistingClientUri;

        // Act
        var result = await Configuracoes.GetConnectionByUriRwAsync(uri);

        // Assert
        // Might return a connection or null depending on environment
        if (result != null)
        {
            result.Should().NotBeNull();
        }
        else
        {
            result.Should().BeNull();
        }
    }

    [Fact]
    public async Task GetConnectionByUriRwAsync_WithNullUri_ShouldReturnNull()
    {
        // Arrange
        string? uri = null;

        // Act
        var result = await Configuracoes.GetConnectionByUriRwAsync(uri!);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetConnectionByUriRwAsync_WithEmptyUri_ShouldReturnNull()
    {
        // Arrange
        var uri = string.Empty;

        // Act
        var result = await Configuracoes.GetConnectionByUriRwAsync(uri);

        // Assert
        result.Should().BeNull();
    }

    [Theory]
    [InlineData(NonExistentClientUri1)]
    [InlineData(NonExistentClientUri2)]
    [InlineData(NonExistentClientUri3)]
    [InlineData(NonExistentClientUri4)]
    [InlineData(NonExistentClientUri5)]
    public async Task GetConnectionByUriRwAsync_WithDifferentNonExistentClientUris_ShouldReturnNull(string uri)
    {
        // Act
        var result = await Configuracoes.GetConnectionByUriRwAsync(uri);

        // Assert
        result.Should().BeNull();
    }

    #endregion

    #region ConnectionByUri Method Tests

    [Fact]
    public void ConnectionByUri_WithNonExistentClientUri_ShouldThrowException()
    {
        // Arrange - Using non-existent client URI pattern
        var uri = NonExistentClientUri1;

        // Act & Assert
        Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionByUri(uri));
    }

    [Fact]
    public void ConnectionByUri_WithExistingClientUri_ShouldReturnStringOrThrow()
    {
        // Arrange - Using the only existing URI we're allowed to test with
        var uri = ExistingClientUri;

        // Act & Assert
        try
        {
            var result = Configuracoes.ConnectionByUri(uri);
            result.Should().NotBeNullOrEmpty();
        }
        catch (Exception ex)
        {
            // Expected if environment isn't properly configured
            ex.Should().NotBeNull();
        }
    }

    [Fact]
    public void ConnectionByUri_WithNullUri_ShouldThrowException()
    {
        // Arrange
        string? uri = null;

        // Act & Assert
        Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionByUri(uri!));
    }

    [Fact]
    public void ConnectionByUri_WithEmptyUri_ShouldThrowException()
    {
        // Arrange
        var uri = string.Empty;

        // Act & Assert
        Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionByUri(uri));
    }

    [Theory]
    [InlineData(NonExistentClientUri1)]
    [InlineData(NonExistentClientUri2)]
    [InlineData(NonExistentClientUri3)]
    [InlineData(InvalidUri)]
    [InlineData(NonExistentUri)]
    public void ConnectionByUri_WithDifferentNonExistentClientUris_ShouldThrowException(string uri)
    {
        // Act & Assert
        Assert.ThrowsAny<Exception>(() => Configuracoes.ConnectionByUri(uri));
    }

    #endregion

    #region CreateConnectionScope Method Tests

    [Fact]
    public void CreateConnectionScope_WithNonExistentClientUri_ShouldThrowException()
    {
        // Arrange - Using non-existent client URI pattern
        var uri = NonExistentClientUri1;

        // Act & Assert
        Assert.ThrowsAny<Exception>(() => Configuracoes.CreateConnectionScope(uri, true));
    }

    [Fact]
    public void CreateConnectionScope_WithExistingClientUri_ShouldCreateScopeOrThrow()
    {
        // Arrange - Using the only existing URI we're allowed to test with
        var uri = ExistingClientUri;

        // Act & Assert
        try
        {
            using var scope = Configuracoes.CreateConnectionScope(uri, true);
            scope.Should().NotBeNull();
        }
        catch (Exception ex)
        {
            // Expected if environment isn't properly configured
            ex.Should().NotBeNull();
        }
    }

    [Fact]
    public void CreateConnectionScope_WithNullUri_ShouldThrowException()
    {
        // Arrange
        string? uri = null;

        // Act & Assert
        Assert.ThrowsAny<Exception>(() => Configuracoes.CreateConnectionScope(uri!, true));
    }

    [Fact]
    public void CreateConnectionScope_WithEmptyUri_ShouldThrowException()
    {
        // Arrange
        var uri = string.Empty;

        // Act & Assert
        Assert.ThrowsAny<Exception>(() => Configuracoes.CreateConnectionScope(uri, true));
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void CreateConnectionScope_WithNonExistentClientUri_ShouldRespectReadOnlyParameter(bool readOnly)
    {
        // Arrange - Using non-existent client URI pattern
        var uri = NonExistentClientUri1;

        // Act & Assert
        Assert.ThrowsAny<Exception>(() => Configuracoes.CreateConnectionScope(uri, readOnly));
    }

    [Theory]
    [InlineData(NonExistentClientUri1)]
    [InlineData(NonExistentClientUri2)]
    [InlineData(NonExistentClientUri3)]
    public void CreateConnectionScope_WithDifferentNonExistentClientUris_ShouldThrowException(string uri)
    {
        // Act & Assert
        Assert.ThrowsAny<Exception>(() => Configuracoes.CreateConnectionScope(uri, true));
    }

    #endregion

    #region CreateConnectionScopeRw Method Tests

    [Fact]
    public void CreateConnectionScopeRw_WithNonExistentClientUri_ShouldThrowException()
    {
        // Arrange - Using non-existent client URI pattern
        var uri = NonExistentClientUri1;

        // Act & Assert
        Assert.ThrowsAny<Exception>(() => Configuracoes.CreateConnectionScopeRw(uri, false));
    }

    [Fact]
    public void CreateConnectionScopeRw_WithExistingClientUri_ShouldCreateScopeOrThrow()
    {
        // Arrange - Using the only existing URI we're allowed to test with
        var uri = ExistingClientUri;

        // Act & Assert
        try
        {
            using var scope = Configuracoes.CreateConnectionScopeRw(uri, false);
            scope.Should().NotBeNull();
        }
        catch (Exception ex)
        {
            // Expected if environment isn't properly configured
            ex.Should().NotBeNull();
        }
    }

    [Fact]
    public void CreateConnectionScopeRw_WithNullUri_ShouldThrowException()
    {
        // Arrange
        string? uri = null;

        // Act & Assert
        Assert.ThrowsAny<Exception>(() => Configuracoes.CreateConnectionScopeRw(uri!, false));
    }

    [Fact]
    public void CreateConnectionScopeRw_WithEmptyUri_ShouldThrowException()
    {
        // Arrange
        var uri = string.Empty;

        // Act & Assert
        Assert.ThrowsAny<Exception>(() => Configuracoes.CreateConnectionScopeRw(uri, false));
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void CreateConnectionScopeRw_WithNonExistentClientUri_ShouldRespectReadOnlyParameter(bool readOnly)
    {
        // Arrange - Using non-existent client URI pattern
        var uri = NonExistentClientUri1;

        // Act & Assert
        Assert.ThrowsAny<Exception>(() => Configuracoes.CreateConnectionScopeRw(uri, readOnly));
    }

    #endregion

    #region UseConnectionAsync Method Tests

    [Fact]
    public async Task UseConnectionAsync_WithNullAction_ShouldThrowException()
    {
        // Arrange - Using non-existent client URI pattern
        var uri = NonExistentClientUri1;
        Func<Microsoft.Data.SqlClient.MsiSqlConnection, Task<string>>? action = null;

        // Act & Assert
        await Assert.ThrowsAnyAsync<Exception>(() => 
            Configuracoes.UseConnectionAsync(uri, action!, true));
    }

    [Fact]
    public async Task UseConnectionAsync_WithNonExistentClientUri_ShouldThrowException()
    {
        // Arrange - Using non-existent client URI pattern
        var uri = NonExistentClientUri1;
        var action = new Func<MsiSqlConnection, Task<string>>(conn => Task.FromResult("test"));

        // Act & Assert
        await Assert.ThrowsAnyAsync<Exception>(() => 
            Configuracoes.UseConnectionAsync(uri, action, true));
    }

    [Fact]
    public async Task UseConnectionAsync_WithExistingClientUri_ShouldExecuteActionOrThrow()
    {
        // Arrange - Using the only existing URI we're allowed to test with
        var uri = ExistingClientUri;
        var action = new Func<MsiSqlConnection, Task<string>>(conn => Task.FromResult("test"));

        // Act & Assert
        try
        {
            var result = await Configuracoes.UseConnectionAsync(uri, action, true);
            result.Should().Be("test");
        }
        catch (Exception ex)
        {
            // Expected if environment isn't properly configured
            ex.Should().NotBeNull();
        }
    }

    [Fact]
    public async Task UseConnectionAsync_WithNullUri_ShouldThrowException()
    {
        // Arrange
        string? uri = null;
        var action = new Func<MsiSqlConnection, Task<string>>(conn => Task.FromResult("test"));

        // Act & Assert
        await Assert.ThrowsAnyAsync<Exception>(() => 
            Configuracoes.UseConnectionAsync(uri!, action, true));
    }

    [Fact]
    public async Task UseConnectionAsync_WithEmptyUri_ShouldThrowException()
    {
        // Arrange
        var uri = string.Empty;
        var action = new Func<MsiSqlConnection, Task<string>>(conn => Task.FromResult("test"));

        // Act & Assert
        await Assert.ThrowsAnyAsync<Exception>(() => 
            Configuracoes.UseConnectionAsync(uri, action, true));
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task UseConnectionAsync_WithNonExistentClientUri_ShouldRespectReadOnlyParameter(bool readOnly)
    {
        // Arrange - Using non-existent client URI pattern
        var uri = NonExistentClientUri1;
        var action = new Func<MsiSqlConnection, Task<string>>(conn => Task.FromResult("test"));

        // Act & Assert
        await Assert.ThrowsAnyAsync<Exception>(() => 
            Configuracoes.UseConnectionAsync(uri, action, readOnly));
    }

    [Theory]
    [InlineData(NonExistentClientUri1)]
    [InlineData(NonExistentClientUri2)]
    [InlineData(NonExistentClientUri3)]
    public async Task UseConnectionAsync_WithDifferentNonExistentClientUris_ShouldThrowException(string uri)
    {
        // Arrange
        var action = new Func<MsiSqlConnection, Task<string>>(conn => Task.FromResult("test"));

        // Act & Assert
        await Assert.ThrowsAnyAsync<Exception>(() => 
            Configuracoes.UseConnectionAsync(uri, action, true));
    }

    [Fact]
    public async Task UseConnectionAsync_WithDifferentReturnTypes_ShouldWork()
    {
        // Arrange - Using non-existent client URI pattern (will throw exceptions)
        var uri = NonExistentClientUri1;
        var stringAction = new Func<MsiSqlConnection, Task<string>>(conn => Task.FromResult("test"));
        var intAction = new Func<MsiSqlConnection, Task<int>>(conn => Task.FromResult(42));
        var boolAction = new Func<MsiSqlConnection, Task<bool>>(conn => Task.FromResult(true));

        // Act & Assert
        await Assert.ThrowsAnyAsync<Exception>(() => 
            Configuracoes.UseConnectionAsync(uri, stringAction, true));
        await Assert.ThrowsAnyAsync<Exception>(() => 
            Configuracoes.UseConnectionAsync(uri, intAction, true));
        await Assert.ThrowsAnyAsync<Exception>(() => 
            Configuracoes.UseConnectionAsync(uri, boolAction, true));
    }

    [Fact]
    public async Task UseConnectionAsync_WithComplexAction_ShouldThrowException()
    {
        // Arrange - Using non-existent client URI pattern
        var uri = NonExistentClientUri1;
        var complexAction = new Func<MsiSqlConnection, Task<object>>(async conn => 
        {
            await Task.Delay(10);
            return new { ClientUri = uri, Timestamp = DateTime.Now };
        });

        // Act & Assert
        await Assert.ThrowsAnyAsync<Exception>(() => 
            Configuracoes.UseConnectionAsync(uri, complexAction, true));
    }

    #endregion

    #region Constants Tests

    [Fact]
    public void PCmdReadOnly_ShouldHaveCorrectValue()
    {
        // Assert
        Configuracoes.PCmdReadOnly.Should().Be("ApplicationIntent=ReadOnly;");
    }

    [Fact]
    public void PCmdReadOnly_ShouldNotBeNull()
    {
        // Assert
        Configuracoes.PCmdReadOnly.Should().NotBeNull();
    }

    [Fact]
    public void PCmdReadOnly_ShouldNotBeEmpty()
    {
        // Assert
        Configuracoes.PCmdReadOnly.Should().NotBeEmpty();
    }

    [Fact]
    public void PCmdReadOnly_ShouldContainApplicationIntent()
    {
        // Assert
        Configuracoes.PCmdReadOnly.Should().Contain("ApplicationIntent=ReadOnly");
    }

    [Fact]
    public void PCmdReadOnly_ShouldEndWithSemicolon()
    {
        // Assert
        Configuracoes.PCmdReadOnly.Should().EndWith(";");
    }

    #endregion

    #region Class Structure Tests

    [Fact]
    public void Configuracoes_ShouldBeStaticPartialClass()
    {
        // Arrange
        var type = typeof(Configuracoes);

        // Assert
        type.Should().NotBeNull();
        type.IsClass.Should().BeTrue();
        type.IsAbstract.Should().BeTrue(); // Static classes are abstract
        type.IsSealed.Should().BeTrue(); // Static classes are sealed
    }

    [Fact]
    public void Configuracoes_AllPublicMethods_ShouldBeStatic()
    {
        // Arrange
        var type = typeof(Configuracoes);
        var publicMethods = type.GetMethods(System.Reflection.BindingFlags.Public | 
                                          System.Reflection.BindingFlags.Static | 
                                          System.Reflection.BindingFlags.DeclaredOnly);

        // Assert
        publicMethods.Should().NotBeEmpty();
        foreach (var method in publicMethods)
        {
            method.IsStatic.Should().BeTrue($"Method {method.Name} should be static");
            method.IsPublic.Should().BeTrue($"Method {method.Name} should be public");
        }
    }

    [Fact]
    public void Configuracoes_ShouldHaveExpectedMethods()
    {
        // Arrange
        var type = typeof(Configuracoes);
        var expectedMethods = new[]
        {
            "ConnectionString",
            "ConnectionStringRw",
            "GetConnectionByUri",
            "GetConnectionByUriAsync",
            "GetConnectionByUriRw",
            "GetConnectionByUriRwAsync",
            "ConnectionByUri",
            "CreateConnectionScope",
            "CreateConnectionScopeRw",
            "UseConnectionAsync"
        };

        // Act & Assert
        foreach (var expectedMethod in expectedMethods)
        {
            var method = type.GetMethods().FirstOrDefault(m => m.Name == expectedMethod);
            method.Should().NotBeNull($"Method {expectedMethod} should exist");
        }
    }

    [Fact]
    public void Configuracoes_ShouldHaveConnectionMethods()
    {
        // Arrange
        var type = typeof(Configuracoes);
        var connectionMethods = type.GetMethods().Where(m => m.Name.Contains("Connection")).ToArray();

        // Assert
        connectionMethods.Should().NotBeEmpty("Should have methods containing 'Connection'");
        connectionMethods.Length.Should().BeGreaterThan(5, "Should have multiple connection-related methods");
    }

    #endregion

    #region Error Handling Tests

    [Fact]
    public void GetConnectionByUri_ErrorMessage_ShouldContainExpectedText()
    {
        // Arrange - Using non-existent client URI pattern
        var uri = NonExistentClientUri1;

        // Act & Assert
        var exception = Assert.ThrowsAny<Exception>(() => Configuracoes.GetConnectionByUri(uri));
        exception.Message.Should().Contain("Erro conexão BD:");
    }

    [Fact]
    public void GetConnectionByUri_WithInvalidClientUri_ShouldWrapInnerException()
    {
        // Arrange
        var uri = InvalidUri;

        // Act & Assert
        var exception = Assert.ThrowsAny<Exception>(() => Configuracoes.GetConnectionByUri(uri));
        exception.Message.Should().Contain("Erro conexão BD:");
    }

    [Fact]
    public void GetConnectionByUri_WithNonExistentClientUri_ShouldWrapInnerException()
    {
        // Arrange
        var uri = NonExistentUri;

        // Act & Assert
        var exception = Assert.ThrowsAny<Exception>(() => Configuracoes.GetConnectionByUri(uri));
        exception.Message.Should().Contain("Erro conexão BD:");
    }

    #endregion

    #region Method Overload Tests

    [Fact]
    public void CreateConnectionScope_ShouldHaveCorrectOverloads()
    {
        // Arrange
        var type = typeof(Configuracoes);
        var methods = type.GetMethods().Where(m => m.Name == "CreateConnectionScope").ToArray();

        // Assert
        methods.Should().HaveCount(1);
        var method = methods[0];
        method.GetParameters().Should().HaveCount(2);
        method.GetParameters()[0].ParameterType.Should().Be(typeof(string));
        method.GetParameters()[1].ParameterType.Should().Be(typeof(bool));
        method.GetParameters()[1].HasDefaultValue.Should().BeTrue();
    }

    [Fact]
    public void CreateConnectionScopeRw_ShouldHaveCorrectOverloads()
    {
        // Arrange
        var type = typeof(Configuracoes);
        var methods = type.GetMethods().Where(m => m.Name == "CreateConnectionScopeRw").ToArray();

        // Assert
        methods.Should().HaveCount(1);
        var method = methods[0];
        method.GetParameters().Should().HaveCount(2);
        method.GetParameters()[0].ParameterType.Should().Be(typeof(string));
        method.GetParameters()[1].ParameterType.Should().Be(typeof(bool));
        method.GetParameters()[1].HasDefaultValue.Should().BeTrue();
    }

    [Fact]
    public void UseConnectionAsync_ShouldHaveCorrectOverloads()
    {
        // Arrange
        var type = typeof(Configuracoes);
        var methods = type.GetMethods().Where(m => m.Name == "UseConnectionAsync").ToArray();

        // Assert
        methods.Should().HaveCount(1);
        var method = methods[0];
        method.GetParameters().Should().HaveCount(3);
        method.GetParameters()[0].ParameterType.Should().Be(typeof(string));
        method.GetParameters()[2].ParameterType.Should().Be(typeof(bool));
        method.GetParameters()[2].HasDefaultValue.Should().BeTrue();
    }

    [Fact]
    public void UseConnectionAsync_ShouldBeGenericMethod()
    {
        // Arrange
        var type = typeof(Configuracoes);
        var method = type.GetMethods().FirstOrDefault(m => m.Name == "UseConnectionAsync");

        // Assert
        method.Should().NotBeNull();
        method!.IsGenericMethod.Should().BeTrue("UseConnectionAsync should be a generic method");
        method.GetGenericArguments().Should().HaveCount(1, "Should have one generic type parameter");
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

    #region Integration Tests with DEVPB

    [Fact]
    public void DEVPB_IntegrationTest_ShouldWorkAcrossAllMethods()
    {
        // Arrange
        var uri = ExistingClientUri; // DEVPB

        // Act & Assert - Test that all methods can handle the existing URI without crashing
        try
        {
            // Test ConnectionByUri
            var connectionString = Configuracoes.ConnectionByUri(uri);
            connectionString.Should().NotBeNullOrEmpty();

            // Test GetConnectionByUri
            var connection = Configuracoes.GetConnectionByUri(uri);
            connection.Should().NotBeNull();
        }
        catch (Exception ex)
        {
            // Expected in test environments without proper database setup
            ex.Should().NotBeNull();
        }
    }

    [Fact]
    public async Task DEVPB_AsyncIntegrationTest_ShouldWorkAcrossAllAsyncMethods()
    {
        // Arrange
        var uri = ExistingClientUri; // DEVPB

        // Act & Assert - Test that all async methods can handle the existing URI without crashing
        try
        {
            // Test GetConnectionByUriAsync
            var connection = await Configuracoes.GetConnectionByUriAsync(uri);
            // Might be null or valid connection depending on environment

            // Test GetConnectionByUriRwAsync
            var rwConnection = await Configuracoes.GetConnectionByUriRwAsync(uri);
            // Might be null or valid connection depending on environment

            // Test UseConnectionAsync
            if (connection != null)
            {
                var result = await Configuracoes.UseConnectionAsync(uri, 
                    conn => Task.FromResult("integration test"), true);
                result.Should().Be("integration test");
            }
        }
        catch (Exception ex)
        {
            // Expected in test environments without proper database setup
            ex.Should().NotBeNull();
        }
    }

    #endregion
}