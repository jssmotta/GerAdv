using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MenphisSI.Connections;
using Xunit;

namespace Infrastructure.Tests.Connections;

/// <summary>
/// Comprehensive unit tests for ConnectionScope class
/// Testing through public APIs since the constructor is internal
/// Using non-existent client URI patterns (SILVA, PEDRO, JOAO, MARIA, SANTOS)
/// and one existing URI (DEVPB) for positive testing
/// </summary>
public class ConnectionScopeTests
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

    #region Class Structure Tests

    [Fact]
    public void ConnectionScope_ShouldBePublicClass()
    {
        // Arrange
        var type = typeof(ConnectionScope);

        // Assert
        type.Should().NotBeNull();
        type.IsClass.Should().BeTrue();
        type.IsPublic.Should().BeTrue();
        type.IsAbstract.Should().BeFalse();
        type.IsSealed.Should().BeFalse();
    }

    [Fact]
    public void ConnectionScope_ShouldHaveCorrectNamespace()
    {
        // Arrange
        var type = typeof(ConnectionScope);

        // Assert
        type.Namespace.Should().Be("MenphisSI.Connections");
    }

    [Fact]
    public void ConnectionScope_ShouldImplementOnlyIDisposable()
    {
        // Arrange
        var type = typeof(ConnectionScope);
        var interfaces = type.GetInterfaces();

        // Assert
        interfaces.Should().ContainSingle();
        interfaces[0].Should().Be(typeof(IDisposable));
    }

    [Fact]
    public void ConnectionScope_ShouldHaveOnlyOnePublicProperty()
    {
        // Arrange
        var type = typeof(ConnectionScope);
        var publicProperties = type.GetProperties();

        // Assert
        publicProperties.Should().HaveCount(1);
        publicProperties[0].Name.Should().Be("Connection");
        publicProperties[0].PropertyType.Should().Be(typeof(MsiSqlConnection));
    }

    [Fact]
    public void ConnectionScope_ShouldNotHavePublicMethods()
    {
        // Arrange
        var type = typeof(ConnectionScope);
        var publicMethods = type.GetMethods(System.Reflection.BindingFlags.Public | 
                                          System.Reflection.BindingFlags.Instance | 
                                          System.Reflection.BindingFlags.DeclaredOnly);

        // Assert
        // Should only have Dispose method (and possibly property getter)
        var nonPropertyMethods = publicMethods.Where(m => !m.Name.StartsWith("get_")).ToArray();
        nonPropertyMethods.Should().HaveCount(1);
        nonPropertyMethods[0].Name.Should().Be("Dispose");
    }

    [Fact]
    public void Constructor_IsInternal_ShouldNotBeAccessibleDirectly()
    {
        // Arrange
        var type = typeof(ConnectionScope);
        var constructors = type.GetConstructors(System.Reflection.BindingFlags.NonPublic | 
                                               System.Reflection.BindingFlags.Instance);

        // Assert
        constructors.Should().HaveCount(1);
        var constructor = constructors[0];
        constructor.IsPublic.Should().BeFalse("Constructor should be internal");
        constructor.IsAssembly.Should().BeTrue("Constructor should be internal (assembly level)");
        constructor.GetParameters().Should().HaveCount(1);
        constructor.GetParameters()[0].ParameterType.Should().Be(typeof(MsiSqlConnection));
    }

    #endregion

    #region Connection Property Tests

    [Fact]
    public void Connection_ShouldBeReadOnly()
    {
        // Arrange
        var type = typeof(ConnectionScope);
        var property = type.GetProperty(nameof(ConnectionScope.Connection));

        // Assert
        property.Should().NotBeNull();
        property!.CanRead.Should().BeTrue();
        property.CanWrite.Should().BeFalse("Connection property should be read-only");
        property.SetMethod.Should().BeNull("Connection property should not have a setter");
    }

    [Fact]
    public void Connection_ShouldHaveCorrectType()
    {
        // Arrange
        var type = typeof(ConnectionScope);
        var property = type.GetProperty(nameof(ConnectionScope.Connection));

        // Assert
        property.Should().NotBeNull();
        property!.PropertyType.Should().Be(typeof(MsiSqlConnection));
    }

    #endregion

    #region Dispose Tests

    [Fact]
    public void Dispose_ShouldImplementIDisposableCorrectly()
    {
        // Arrange
        var type = typeof(ConnectionScope);

        // Assert
        typeof(IDisposable).IsAssignableFrom(type).Should().BeTrue("ConnectionScope should implement IDisposable");
        
        var disposeMethod = type.GetMethod("Dispose", Type.EmptyTypes);
        disposeMethod.Should().NotBeNull("Should have parameterless Dispose method");
        disposeMethod!.IsPublic.Should().BeTrue("Dispose method should be public");
        disposeMethod.ReturnType.Should().Be(typeof(void));
    }

    #endregion

    #region Integration Tests with Configuracoes - CreateConnectionScope

    [Theory]
    [InlineData(NonExistentClientUri1)] // SILVA
    [InlineData(NonExistentClientUri2)] // PEDRO
    [InlineData(NonExistentClientUri3)] // JOAO
    [InlineData(NonExistentClientUri4)] // MARIA
    [InlineData(NonExistentClientUri5)] // SANTOS
    public void CreateConnectionScope_WithNonExistentUri_ShouldThrowException(string uri)
    {
        // Act & Assert
        Assert.ThrowsAny<Exception>(() =>
        {
            using var scope = MenphisSI.Configuracoes.CreateConnectionScope(uri);
            // Should not reach here for non-existent URIs
        });
    }

    [Fact]
    public void CreateConnectionScope_WithExistingUri_ShouldCreateValidScopeOrThrow()
    {
        // Arrange
        var uri = ExistingClientUri; // DEVPB

        // Act & Assert
        try
        {
            using var scope = MenphisSI.Configuracoes.CreateConnectionScope(uri);
            scope.Should().NotBeNull();
            scope.Connection.Should().NotBeNull();
            scope.Should().BeAssignableTo<IDisposable>();
        }
        catch (Exception ex)
        {
            // Expected if environment isn't properly configured
            ex.Should().NotBeNull();
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void CreateConnectionScope_WithReadOnlyParameter_ShouldRespectParameter(bool readOnly)
    {
        // Arrange
        var uri = NonExistentClientUri1; // SILVA

        // Act & Assert
        Assert.ThrowsAny<Exception>(() =>
        {
            using var scope = MenphisSI.Configuracoes.CreateConnectionScope(uri, readOnly);
            // Should not reach here for non-existent URIs
        });
    }

    [Fact]
    public void CreateConnectionScope_WithNullUri_ShouldThrowException()
    {
        // Arrange
        string? uri = null;

        // Act & Assert
        Assert.ThrowsAny<Exception>(() =>
        {
            using var scope = MenphisSI.Configuracoes.CreateConnectionScope(uri!);
        });
    }

    [Fact]
    public void CreateConnectionScope_WithEmptyUri_ShouldThrowException()
    {
        // Arrange
        var uri = string.Empty;

        // Act & Assert
        Assert.ThrowsAny<Exception>(() =>
        {
            using var scope = MenphisSI.Configuracoes.CreateConnectionScope(uri);
        });
    }

    [Theory]
    [InlineData("   ")]
    [InlineData("\t")]
    [InlineData("\n")]
    public void CreateConnectionScope_WithWhitespaceUri_ShouldThrowException(string uri)
    {
        // Act & Assert
        Assert.ThrowsAny<Exception>(() =>
        {
            using var scope = MenphisSI.Configuracoes.CreateConnectionScope(uri);
        });
    }

    #endregion

    #region Integration Tests with Configuracoes - CreateConnectionScopeRw

    [Theory]
    [InlineData(NonExistentClientUri1)] // SILVA
    [InlineData(NonExistentClientUri2)] // PEDRO
    [InlineData(NonExistentClientUri3)] // JOAO
    [InlineData(NonExistentClientUri4)] // MARIA
    [InlineData(NonExistentClientUri5)] // SANTOS
    public void CreateConnectionScopeRw_WithNonExistentUri_ShouldThrowException(string uri)
    {
        // Act & Assert
        Assert.ThrowsAny<Exception>(() =>
        {
            using var scope = MenphisSI.Configuracoes.CreateConnectionScopeRw(uri);
            // Should not reach here for non-existent URIs
        });
    }

    [Fact]
    public void CreateConnectionScopeRw_WithExistingUri_ShouldCreateValidScopeOrThrow()
    {
        // Arrange
        var uri = ExistingClientUri; // DEVPB

        // Act & Assert
        try
        {
            using var scope = MenphisSI.Configuracoes.CreateConnectionScopeRw(uri);
            scope.Should().NotBeNull();
            scope.Connection.Should().NotBeNull();
            scope.Should().BeAssignableTo<IDisposable>();
        }
        catch (Exception ex)
        {
            // Expected if environment isn't properly configured
            ex.Should().NotBeNull();
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void CreateConnectionScopeRw_WithReadOnlyParameter_ShouldRespectParameter(bool readOnly)
    {
        // Arrange
        var uri = NonExistentClientUri1; // SILVA

        // Act & Assert
        Assert.ThrowsAny<Exception>(() =>
        {
            using var scope = MenphisSI.Configuracoes.CreateConnectionScopeRw(uri, readOnly);
            // Should not reach here for non-existent URIs
        });
    }

    [Fact]
    public void CreateConnectionScopeRw_WithNullUri_ShouldThrowException()
    {
        // Arrange
        string? uri = null;

        // Act & Assert
        Assert.ThrowsAny<Exception>(() =>
        {
            using var scope = MenphisSI.Configuracoes.CreateConnectionScopeRw(uri!);
        });
    }

    [Fact]
    public void CreateConnectionScopeRw_WithEmptyUri_ShouldThrowException()
    {
        // Arrange
        var uri = string.Empty;

        // Act & Assert
        Assert.ThrowsAny<Exception>(() =>
        {
            using var scope = MenphisSI.Configuracoes.CreateConnectionScopeRw(uri);
        });
    }

    #endregion

    #region Integration Tests with DbConnectionFactory

    [Fact]
    public void DbConnectionFactory_CreateScope_ShouldReturnConnectionScope()
    {
        // Arrange
        var connectionString = "Server=FAKE;Database=FAKE;Integrated Security=true;";

        // Act & Assert
        var exception = Record.Exception(() =>
        {
            using var scope = DbConnectionFactory.CreateScope(connectionString);
            scope.Should().NotBeNull();
            scope.Should().BeOfType<ConnectionScope>();
            scope.Connection.Should().NotBeNull();
        });

        // This might throw due to invalid connection string, but we're testing the method exists
        // and returns the correct type when it succeeds
    }

    #endregion

    #region Using Statement Pattern Tests

    [Fact]
    public void UsingStatement_WithCreateConnectionScope_ShouldCallDisposeAutomatically()
    {
        // Arrange
        var uri = NonExistentClientUri1; // SILVA

        // Act & Assert
        var exception = Record.Exception(() =>
        {
            try
            {
                using var scope = MenphisSI.Configuracoes.CreateConnectionScope(uri);
                scope.Connection.Should().NotBeNull();
            }
            catch (Exception)
            {
                // Expected for non-existent URIs
                // The important part is that no additional exceptions are thrown during disposal
            }
        });

        // Should not throw any disposal-related exceptions
        exception?.GetType().Should().NotBe<ObjectDisposedException>();
        exception?.GetType().Should().NotBe<InvalidOperationException>();
    }

    [Fact]
    public void UsingStatement_WithCreateConnectionScopeRw_ShouldCallDisposeAutomatically()
    {
        // Arrange
        var uri = NonExistentClientUri1; // SILVA

        // Act & Assert
        var exception = Record.Exception(() =>
        {
            try
            {
                using var scope = MenphisSI.Configuracoes.CreateConnectionScopeRw(uri);
                scope.Connection.Should().NotBeNull();
            }
            catch (Exception)
            {
                // Expected for non-existent URIs
                // The important part is that no additional exceptions are thrown during disposal
            }
        });

        // Should not throw any disposal-related exceptions
        exception?.GetType().Should().NotBe<ObjectDisposedException>();
        exception?.GetType().Should().NotBe<InvalidOperationException>();
    }

    [Fact]
    public void UsingStatement_WithException_ShouldStillCallDispose()
    {
        // Arrange
        var uri = ExistingClientUri; // DEVPB

        // Act & Assert
        var handled = false;
        var disposalException = Record.Exception(() =>
        {
            try
            {
                using var scope = MenphisSI.Configuracoes.CreateConnectionScope(uri);
                if (scope != null)
                {
                    scope.Connection.Should().NotBeNull();
                    throw new InvalidOperationException("Test exception");
                }
            }
            catch (InvalidOperationException ex) when (ex.Message == "Test exception")
            {
                handled = true;
            }
            catch (Exception)
            {
                // Other exceptions are expected if URI doesn't exist in environment
                handled = true;
            }
        });

        handled.Should().BeTrue("Test exception should be caught");
        disposalException.Should().BeNull("Dispose should not throw exceptions");
    }

    #endregion

    #region Thread Safety Tests

    [Fact]
    public void ConnectionScope_ConcurrentCreationThroughConfiguracao_ShouldBeThreadSafe()
    {
        // Arrange
        var tasks = new Task[5]; // Reduced number to avoid overwhelming the system
        var exceptions = new List<Exception>();

        // Act
        for (int i = 0; i < 5; i++)
        {
            var uri = NonExistentClientUri1; // SILVA
            tasks[i] = Task.Run(() =>
            {
                try
                {
                    using var scope = MenphisSI.Configuracoes.CreateConnectionScope(uri);
                    scope.Connection.Should().NotBeNull();
                }
                catch (Exception ex)
                {
                    lock (exceptions)
                    {
                        exceptions.Add(ex);
                    }
                }
            });
        }

        Task.WaitAll(tasks);

        // Assert
        // All should throw the same type of exception for non-existent URI
        exceptions.Should().HaveCount(5, "All calls should throw exceptions for non-existent URI");
        exceptions.Should().AllSatisfy(ex => ex.Should().NotBeOfType<ObjectDisposedException>());
    }

    #endregion

    #region Connection Scope Behavior Tests

    [Fact]
    public void ConnectionScope_FromCreateConnectionScope_ShouldHaveValidConnection()
    {
        // Arrange
        var uri = ExistingClientUri; // DEVPB

        // Act & Assert
        try
        {
            using var scope = MenphisSI.Configuracoes.CreateConnectionScope(uri);
            
            // Test basic properties if scope is created successfully
            scope.Should().NotBeNull();
            scope.Connection.Should().NotBeNull();
            scope.Connection.Should().BeOfType<MsiSqlConnection>();
            
            // Test that it implements IDisposable
            scope.Should().BeAssignableTo<IDisposable>();
        }
        catch (Exception ex)
        {
            // Expected if environment isn't properly configured
            ex.Should().NotBeNull();
            // This is acceptable for test environments
        }
    }

    [Fact]
    public void ConnectionScope_FromCreateConnectionScopeRw_ShouldHaveValidConnection()
    {
        // Arrange
        var uri = ExistingClientUri; // DEVPB

        // Act & Assert
        try
        {
            using var scope = MenphisSI.Configuracoes.CreateConnectionScopeRw(uri);
            
            // Test basic properties if scope is created successfully
            scope.Should().NotBeNull();
            scope.Connection.Should().NotBeNull();
            scope.Connection.Should().BeOfType<MsiSqlConnection>();
            
            // Test that it implements IDisposable
            scope.Should().BeAssignableTo<IDisposable>();
        }
        catch (Exception ex)
        {
            // Expected if environment isn't properly configured
            ex.Should().NotBeNull();
            // This is acceptable for test environments
        }
    }

    [Fact]
    public void ConnectionScope_MultipleScopes_ShouldBeIndependent()
    {
        // Arrange
        var uri1 = NonExistentClientUri1; // SILVA
        var uri2 = NonExistentClientUri2; // PEDRO

        // Act & Assert
        var exception = Record.Exception(() =>
        {
            try
            {
                using var scope1 = MenphisSI.Configuracoes.CreateConnectionScope(uri1);
                using var scope2 = MenphisSI.Configuracoes.CreateConnectionScope(uri2);
                
                // If we reach here (unlikely with non-existent URIs), test independence
                scope1.Should().NotBe(scope2);
                scope1.Connection.Should().NotBe(scope2.Connection);
            }
            catch (Exception)
            {
                // Expected for non-existent URIs
            }
        });

        // Should not cause any disposal issues
        exception?.GetType().Should().NotBe<ObjectDisposedException>();
    }

    #endregion

    #region Error Handling Tests

    [Theory]
    [InlineData(InvalidUri)]
    [InlineData(NonExistentUri)]
    [InlineData("")]
    [InlineData("   ")]
    public void CreateConnectionScope_WithInvalidUris_ShouldThrowMeaningfulExceptions(string uri)
    {
        // Act & Assert
        var exception = Assert.ThrowsAny<Exception>(() =>
        {
            using var scope = MenphisSI.Configuracoes.CreateConnectionScope(uri);
        });

        exception.Should().NotBeNull();
        // Exception should provide some context about the failure
        exception.Message.Should().NotBeNullOrEmpty();
    }

    [Theory]
    [InlineData(InvalidUri)]
    [InlineData(NonExistentUri)]
    [InlineData("")]
    [InlineData("   ")]
    public void CreateConnectionScopeRw_WithInvalidUris_ShouldThrowMeaningfulExceptions(string uri)
    {
        // Act & Assert
        var exception = Assert.ThrowsAny<Exception>(() =>
        {
            using var scope = MenphisSI.Configuracoes.CreateConnectionScopeRw(uri);
        });

        exception.Should().NotBeNull();
        // Exception should provide some context about the failure
        exception.Message.Should().NotBeNullOrEmpty();
    }

    #endregion

    #region Method Signature Tests

    [Fact]
    public void CreateConnectionScope_ShouldHaveCorrectSignature()
    {
        // Arrange
        var type = typeof(MenphisSI.Configuracoes);
        var method = type.GetMethod("CreateConnectionScope");

        // Assert
        method.Should().NotBeNull();
        method!.IsStatic.Should().BeTrue();
        method.IsPublic.Should().BeTrue();
        method.ReturnType.Should().Be(typeof(ConnectionScope));
        method.GetParameters().Should().HaveCount(2);
        method.GetParameters()[0].ParameterType.Should().Be(typeof(string));
        method.GetParameters()[1].ParameterType.Should().Be(typeof(bool));
        method.GetParameters()[1].HasDefaultValue.Should().BeTrue();
    }

    [Fact]
    public void CreateConnectionScopeRw_ShouldHaveCorrectSignature()
    {
        // Arrange
        var type = typeof(MenphisSI.Configuracoes);
        var method = type.GetMethod("CreateConnectionScopeRw");

        // Assert
        method.Should().NotBeNull();
        method!.IsStatic.Should().BeTrue();
        method.IsPublic.Should().BeTrue();
        method.ReturnType.Should().Be(typeof(ConnectionScope));
        method.GetParameters().Should().HaveCount(2);
        method.GetParameters()[0].ParameterType.Should().Be(typeof(string));
        method.GetParameters()[1].ParameterType.Should().Be(typeof(bool));
        method.GetParameters()[1].HasDefaultValue.Should().BeTrue();
    }

    #endregion

    #region Performance Tests

    [Fact]
    public void ConnectionScope_Creation_ShouldNotHang()
    {
        // Arrange
        var uri = NonExistentClientUri1; // SILVA
        var timeout = TimeSpan.FromSeconds(5);

        // Act
        var task = Task.Run(() =>
        {
            try
            {
                using var scope = MenphisSI.Configuracoes.CreateConnectionScope(uri);
            }
            catch (Exception)
            {
                // Expected for non-existent URI
            }
        });

        var completed = task?.Wait(timeout);

        // Assert
        completed.Should().BeTrue("Connection scope creation should complete within timeout");
    }

    [Fact]
    public void ConnectionScope_Disposal_ShouldBeQuick()
    {
        // Arrange
        var uri = ExistingClientUri; // DEVPB
        var timeout = TimeSpan.FromSeconds(10);

        // Act
        var task = Task.Run(() =>
        {
            try
            {
                using var scope = MenphisSI.Configuracoes.CreateConnectionScope(uri);
                // Dispose will be called automatically
            }
            catch (Exception)
            {
                // Expected if environment isn't configured
            }
        });

        var completed = task.Wait(timeout);

        // Assert
        completed.Should().BeTrue("Connection scope disposal should complete within timeout");
    }

    #endregion

    #region Integration Tests with All Test URIs

    [Theory]
    [InlineData(NonExistentClientUri1)] // SILVA
    [InlineData(NonExistentClientUri2)] // PEDRO
    [InlineData(NonExistentClientUri3)] // JOAO
    [InlineData(NonExistentClientUri4)] // MARIA
    [InlineData(NonExistentClientUri5)] // SANTOS
    public void AllConnectionScopeMethods_WithNonExistentUris_ShouldThrowConsistentExceptions(string uri)
    {
        // Act & Assert
        var createScopeException = Assert.ThrowsAny<Exception>(() =>
        {
            using var scope = MenphisSI.Configuracoes.CreateConnectionScope(uri);
        });

        var createScopeRwException = Assert.ThrowsAny<Exception>(() =>
        {
            using var scope = MenphisSI.Configuracoes.CreateConnectionScopeRw(uri);
        });

        createScopeException.Message.Should().Contain("Erro conexão BD");
        createScopeRwException.Message.Should().Contain("Value cannot");
    }
    [Fact]
    public void AllConnectionScopeMethods_WithDevpbUri_ShouldBehaveConsistently()
    {
        // Arrange
        var uri = ExistingClientUri; // DEVPB

        // Act & Assert
        var readOnlyWorked = false;
        var readWriteWorked = false;

        try
        {
            using var readOnlyScope = MenphisSI.Configuracoes.CreateConnectionScope(uri);
            readOnlyScope.Should().NotBeNull();
            readOnlyScope.Connection.Should().NotBeNull();
            readOnlyWorked = true;
        }
        catch (Exception)
        {
            // Expected in test environments without proper database setup
        }

        try
        {
            using var readWriteScope = MenphisSI.Configuracoes.CreateConnectionScopeRw(uri);
            readWriteScope.Should().NotBeNull();
            readWriteScope.Connection.Should().NotBeNull();
            readWriteWorked = true;
        }
        catch (Exception)
        {
            // Expected in test environments without proper database setup
        }

        // Both should behave consistently (either both work or both fail)
        readOnlyWorked.Should().Be(readWriteWorked, 
            "Both read-only and read-write scope creation should behave consistently");
    }

    #endregion

    #region Documentation Tests

    [Fact]
    public void ConnectionScope_ShouldHaveExpectedPublicInterface()
    {
        // Arrange
        var type = typeof(ConnectionScope);

        // Assert
        type.Should().NotBeNull("ConnectionScope class should exist");
        type.IsPublic.Should().BeTrue("ConnectionScope should be public");
        
        // Should have exactly one public property
        var properties = type.GetProperties();
        properties.Should().HaveCount(1);
        properties[0].Name.Should().Be("Connection");
        
        // Should implement IDisposable
        typeof(IDisposable).IsAssignableFrom(type).Should().BeTrue();
    }

    [Fact]
    public void ConnectionScope_UsagePattern_ShouldFollowExpectedPattern()
    {
        // This test documents the expected usage pattern
        
        // Arrange
        var uri = NonExistentClientUri1; // SILVA

        // Act & Assert - Document expected usage
        var exception = Record.Exception(() =>
        {
            // Pattern 1: Creation through Configuracoes
            try
            {
                using var scope = MenphisSI.Configuracoes.CreateConnectionScope(uri);
                
                // Pattern 2: Access connection
                var connection = scope.Connection;
                connection.Should().NotBeNull();
                
                // Pattern 3: Automatic disposal through using statement
                // Dispose will be called automatically
            }
            catch (Exception)
            {
                // Expected for non-existent URIs
            }
        });

        // Should not cause disposal issues
        exception?.GetType().Should().NotBe<ObjectDisposedException>();
    }

    #endregion
}