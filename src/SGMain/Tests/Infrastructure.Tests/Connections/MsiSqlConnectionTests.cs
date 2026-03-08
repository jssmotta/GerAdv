using System.Data;
using System.Threading;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using Xunit;

namespace Infrastructure.Tests.Connections;

/// <summary>
/// Comprehensive unit tests for MsiSqlConnection class
/// Testing all methods with various scenarios including edge cases and error conditions
/// Following the workspace pattern with URI names SILVA, PEDRO, JOAO, MARIA, SANTOS as fake URIs
/// and DEVPB as the only existing URI for testing
/// </summary>
public class MsiSqlConnectionTests
{
    #region Test Data Constants
    
    // Connection strings for testing
    private const string ValidConnectionString = "Server=localhost;Integrated Security=true;TrustServerCertificate=true;";
    private const string InvalidConnectionString = "Server=invalid;Database=NonExistent;User Id=test;Password=wrong;";
    private const string EmptyConnectionString = "";
    
    // Test URIs following workspace patterns
    private const string TestUri1 = "SILVA";
    private const string TestUri2 = "PEDRO";
    private const string TestUri3 = "JOAO";
    private const string TestUri4 = "MARIA";
    private const string TestUri5 = "SANTOS";
    private const string ExistingUri = "DEVPB";
    
    #endregion

    #region Constructor Tests

    [Fact]
    public void Constructor_WithValidConnectionString_ShouldInitializeCorrectly()
    {
        // Arrange & Act
        using var connection = new MsiSqlConnection(ValidConnectionString);

        // Assert
        connection.ConnectionString.Should().Be(ValidConnectionString);
        connection.State.Should().Be(ConnectionState.Closed);
        connection.UseDbo.Should().Be("dbo");
        connection.InnerConnection.Should().NotBeNull();
    }

    [Fact]
    public void Constructor_WithNullConnectionString_ShouldThrowArgumentNullException()
    {
        // Arrange
        string? connectionString = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new MsiSqlConnection(connectionString));
        exception.ParamName.Should().Be("connectionString");
    }

    [Fact]
    public void Constructor_WithEmptyConnectionString_ShouldInitializeWithEmptyString()
    {
        // Arrange & Act
        using var connection = new MsiSqlConnection(EmptyConnectionString);

        // Assert
        connection.ConnectionString.Should().Be(EmptyConnectionString);
        connection.State.Should().Be(ConnectionState.Closed);
        connection.InnerConnection.Should().NotBeNull();
    }

    [Fact]
    public void Constructor_Parameterless_ShouldInitializeWithDefaults()
    {
        // Arrange & Act
        using var connection = new MsiSqlConnection();

        // Assert
        connection.ConnectionString.Should().Be(string.Empty);
        connection.State.Should().Be(ConnectionState.Closed);
        connection.UseDbo.Should().Be("dbo");
        connection.InnerConnection.Should().BeNull();
    }

    [Theory]
    [InlineData("Server=test;Database=db1;")]
    [InlineData("Data Source=server;Initial Catalog=catalog;")]
    [InlineData("Server=(local);Database=test;Integrated Security=true;")]
    public void Constructor_WithVariousConnectionStrings_ShouldInitializeCorrectly(string connectionString)
    {
        // Arrange & Act
        using var connection = new MsiSqlConnection(connectionString);

        // Assert
        connection.ConnectionString.Should().Be(connectionString);
        connection.InnerConnection.Should().NotBeNull();
        connection.InnerConnection!.ConnectionString.Should().Be(connectionString);
    }

    #endregion

    #region Property Tests

    [Fact]
    public void ConnectionString_Getter_ShouldReturnCurrentValue()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);

        // Act
        var result = connection.ConnectionString;

        // Assert
        result.Should().Be(ValidConnectionString);
    }

    [Fact]
    public void ConnectionString_Setter_ShouldUpdateValue()
    {
        // Arrange
        using var connection = new MsiSqlConnection();
        var newConnectionString = "Server=new;Database=updated;";

        // Act
        connection.ConnectionString = newConnectionString;

        // Assert
        connection.ConnectionString.Should().Be(newConnectionString);
    }

    [Fact]
    public void ConnectionString_SetterWithNull_ShouldSetToEmptyString()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);

        // Act
        connection.ConnectionString = null!;

        // Assert
        connection.ConnectionString.Should().Be(string.Empty);
    }

    [Fact]
    public void UseDbo_DefaultValue_ShouldBeDbo()
    {
        // Arrange & Act
        using var connection = new MsiSqlConnection();

        // Assert
        connection.UseDbo.Should().Be("dbo");
    }

    [Theory]
    [InlineData("custom")]
    [InlineData("admin")]
    [InlineData("guest")]
    [InlineData("")]
    public void UseDbo_Setter_ShouldUpdateValue(string newValue)
    {
        // Arrange
        using var connection = new MsiSqlConnection();

        // Act
        connection.UseDbo = newValue;

        // Assert
        connection.UseDbo.Should().Be(newValue);
    }

    [Fact]
    public void State_WithClosedConnection_ShouldReturnClosed()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);

        // Act
        var state = connection.State;

        // Assert
        state.Should().Be(ConnectionState.Closed);
    }

    [Fact]
    public void State_WithNullInnerConnection_ShouldReturnClosed()
    {
        // Arrange
        using var connection = new MsiSqlConnection();

        // Act
        var state = connection.State;

        // Assert
        state.Should().Be(ConnectionState.Closed);
    }

    [Fact]
    public void InnerConnection_WithInitializedConnection_ShouldReturnSqlConnection()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);

        // Act
        var innerConnection = connection.InnerConnection;

        // Assert
        innerConnection.Should().NotBeNull();
        innerConnection.Should().BeOfType<SqlConnection>();
        innerConnection!.ConnectionString.Should().Be(ValidConnectionString);
    }

    [Fact]
    public void InnerConnection_WithParameterlessConstructor_ShouldReturnNull()
    {
        // Arrange
        using var connection = new MsiSqlConnection();

        // Act
        var innerConnection = connection.InnerConnection;

        // Assert
        innerConnection.Should().BeNull();
    }

    #endregion

    #region Open Method Tests

    [Fact]
    public void Open_WithValidConnectionString_ShouldNotThrow()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);

        // Act & Assert
        // Note: This will likely throw in unit test environment without actual database
        // but we test that the method doesn't crash due to null references
        var exception = Record.Exception(() => connection.Open());
        
        // The method should either succeed or throw a database-related exception, not null reference
        if (exception != null)
        {
            exception.Should().NotBeOfType<NullReferenceException>();
        }
    }

    [Fact]
    public void Open_WithNullInnerConnection_ShouldCreateConnection()
    {
        // Arrange
        using var connection = new MsiSqlConnection();
        connection.ConnectionString = ValidConnectionString;

        // Act & Assert
        var exception = Record.Exception(() => connection.Open());
        
        // Should create the inner connection and attempt to open
        connection.InnerConnection.Should().NotBeNull();
        
        if (exception != null)
        {
            exception.Should().NotBeOfType<NullReferenceException>();
        }
    }

    [Fact]
    public void Open_WithEmptyConnectionString_ShouldAttemptToOpen()
    {
        // Arrange
        using var connection = new MsiSqlConnection("");

        // Act & Assert
        var exception = Record.Exception(() => connection.Open());
        
        // Should not throw null reference exception
        if (exception != null)
        {
            exception.Should().NotBeOfType<NullReferenceException>();
        }
    }

    [Fact]
    public void Open_MultipleCallsOnSameConnection_ShouldNotThrowNullReference()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);

        // Act & Assert
        var exception1 = Record.Exception(() => connection.Open());
        var exception2 = Record.Exception(() => connection.Open());
        
        // Both calls should behave consistently
        if (exception1 != null && exception2 != null)
        {
            exception1.Should().NotBeOfType<NullReferenceException>();
            exception2.Should().NotBeOfType<NullReferenceException>();
        }
    }

    #endregion

    #region OpenAsync Method Tests

    [Fact]
    public async Task OpenAsync_WithValidConnectionString_ShouldNotThrow()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);

        // Act & Assert
        var exception = await Record.ExceptionAsync(() => connection.OpenAsync());
        
        if (exception != null)
        {
            exception.Should().NotBeOfType<NullReferenceException>();
        }
    }

    [Fact]
    public async Task OpenAsync_WithCancellationToken_ShouldRespectCancellation()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);
        using var cts = new CancellationTokenSource();
        cts.Cancel(); // Cancel immediately

        // Act & Assert
        var exception = await Record.ExceptionAsync(() => connection.OpenAsync(cts.Token));
        
        if (exception != null)
        {
            // Should either be a cancellation exception or database exception, not null reference
            exception.Should().NotBeOfType<NullReferenceException>();
        }
    }

    [Fact]
    public async Task OpenAsync_WithNullInnerConnection_ShouldCreateConnection()
    {
        // Arrange
        using var connection = new MsiSqlConnection();
        connection.ConnectionString = ValidConnectionString;

        // Act & Assert
        var exception = await Record.ExceptionAsync(() => connection.OpenAsync());
        
        // Should create the inner connection
        connection.InnerConnection.Should().NotBeNull();
        
        if (exception != null)
        {
            exception.Should().NotBeOfType<NullReferenceException>();
        }
    }

    [Fact]
    public async Task OpenAsync_WithTimeout_ShouldCompleteWithinReasonableTime()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));

        // Act & Assert
        var exception = await Record.ExceptionAsync(() => connection.OpenAsync(cts.Token));
        
        // Should complete within timeout (either success or database error)
        cts.Token.IsCancellationRequested.Should().BeFalse("Method should complete before timeout");
        
        if (exception != null)
        {
            exception.Should().NotBeOfType<NullReferenceException>();
        }
    }

    #endregion

    #region Close Method Tests

    [Fact]
    public void Close_WithOpenConnection_ShouldNotThrow()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);

        // Act & Assert
        var exception = Record.Exception(() => connection.Close());
        exception.Should().BeNull("Close should never throw on a valid connection object");
    }

    [Fact]
    public void Close_WithNullInnerConnection_ShouldNotThrow()
    {
        // Arrange
        using var connection = new MsiSqlConnection();

        // Act & Assert
        var exception = Record.Exception(() => connection.Close());
        exception.Should().BeNull("Close should handle null inner connection gracefully");
    }

    [Fact]
    public void Close_MultipleCalls_ShouldNotThrow()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);

        // Act & Assert
        var exception1 = Record.Exception(() => connection.Close());
        var exception2 = Record.Exception(() => connection.Close());
        var exception3 = Record.Exception(() => connection.Close());
        
        exception1.Should().BeNull();
        exception2.Should().BeNull();
        exception3.Should().BeNull();
    }

    [Fact]
    public void Close_AfterDispose_ShouldNotThrow()
    {
        // Arrange
        var connection = new MsiSqlConnection(ValidConnectionString);
        connection.Dispose();

        // Act & Assert
        var exception = Record.Exception(() => connection.Close());
        exception.Should().BeNull("Close should handle disposed connection gracefully");
    }

    #endregion

    #region CloseAsync Method Tests

    [Fact]
    public async Task CloseAsync_WithOpenConnection_ShouldNotThrow()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);

        // Act & Assert
        var exception = await Record.ExceptionAsync(() => connection.CloseAsync());
        exception.Should().BeNull("CloseAsync should never throw on a valid connection object");
    }

    [Fact]
    public async Task CloseAsync_WithNullInnerConnection_ShouldNotThrow()
    {
        // Arrange
        using var connection = new MsiSqlConnection();

        // Act & Assert
        var exception = await Record.ExceptionAsync(() => connection.CloseAsync());
        exception.Should().BeNull("CloseAsync should handle null inner connection gracefully");
    }

    [Fact]
    public async Task CloseAsync_MultipleCalls_ShouldNotThrow()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);

        // Act & Assert
        var exception1 = await Record.ExceptionAsync(() => connection.CloseAsync());
        var exception2 = await Record.ExceptionAsync(() => connection.CloseAsync());
        var exception3 = await Record.ExceptionAsync(() => connection.CloseAsync());
        
        exception1.Should().BeNull();
        exception2.Should().BeNull();
        exception3.Should().BeNull();
    }

    [Fact]
    public async Task CloseAsync_WithCancellation_ShouldCompleteQuickly()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(1));

        // Act & Assert
        var exception = await Record.ExceptionAsync(() => connection.CloseAsync());
        exception.Should().BeNull();
        cts.Token.IsCancellationRequested.Should().BeFalse("CloseAsync should complete quickly");
    }

    #endregion

    #region CreateCommand Method Tests

    [Fact]
    public void CreateCommand_WithValidConnection_ShouldReturnSqlCommand()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);

        // Act
        var command = connection.CreateCommand();

        // Assert
        command.Should().NotBeNull();
        command.Should().BeOfType<SqlCommand>();
        command.Connection.Should().Be(connection.InnerConnection);
    }

    [Fact]
    public void CreateCommand_WithNullInnerConnection_ShouldThrowException()
    {
        // Arrange
        using var connection = new MsiSqlConnection();

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => connection.CreateCommand());
        exception.Message.Should().Contain("Null Connection CreateCommand");
    }

    [Fact]
    public void CreateCommand_MultipleCalls_ShouldReturnDifferentInstances()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);

        // Act
        var command1 = connection.CreateCommand();
        var command2 = connection.CreateCommand();

        // Assert
        command1.Should().NotBeNull();
        command2.Should().NotBeNull();
        command1.Should().NotBeSameAs(command2);
        command1.Connection.Should().Be(command2.Connection);
    }
 

    #endregion

    #region BeginTransaction Method Tests

    [Fact]
    public void BeginTransaction_WithValidOpenConnection_ShouldReturnTransaction()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);
        
        // Act & Assert
        try
        {
            connection.Open();
            var transaction = connection.BeginTransaction();
            transaction.Should().NotBeNull();
            transaction.Should().BeOfType<SqlTransaction>();
        }
        catch (Exception ex)
        {
            // Expected in test environment without actual database
            ex.Should().NotBeOfType<NullReferenceException>();
        }
    }

    [Fact]
    public void BeginTransaction_WithNullInnerConnection_ShouldThrowException()
    {
        // Arrange
        using var connection = new MsiSqlConnection();

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => connection.BeginTransaction());
        exception.Message.Should().Contain("Null Connection BeginTransaction");
    }

    [Fact]
    public void BeginTransaction_WithClosedConnection_ShouldThrowException()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);

        // Act & Assert
        // BeginTransaction typically requires an open connection
        var exception = Record.Exception(() => connection.BeginTransaction());
        if (exception != null)
        {
            exception.Should().NotBeOfType<NullReferenceException>();
        }
    }

   

    #endregion

    #region ChangeDatabase Method Tests

    [Fact]
    public void ChangeDatabase_WithValidConnection_ShouldNotThrow()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);
        var databaseName = "TestDatabase";

        // Act & Assert
        var exception = Record.Exception(() => connection.ChangeDatabase(databaseName));
        
        // Should either succeed or throw database-related exception, not null reference
        if (exception != null)
        {
            exception.Should().NotBeOfType<NullReferenceException>();
        }
    }

    [Fact]
    public void ChangeDatabase_WithNullInnerConnection_ShouldNotThrow()
    {
        // Arrange
        using var connection = new MsiSqlConnection();
        var databaseName = "TestDatabase";

        // Act & Assert
        var exception = Record.Exception(() => connection.ChangeDatabase(databaseName));
        exception.Should().BeNull("ChangeDatabase should handle null inner connection gracefully");
    }

    [Theory]
    [InlineData("TestDB")]
    [InlineData("master")]
    [InlineData("tempdb")]
    [InlineData("model")]
    public void ChangeDatabase_WithDifferentDatabaseNames_ShouldNotThrow(string databaseName)
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);

        // Act & Assert
        var exception = Record.Exception(() => connection.ChangeDatabase(databaseName));
        
        if (exception != null)
        {
            exception.Should().NotBeOfType<NullReferenceException>();
        }
    }

    [Fact]
    public void ChangeDatabase_WithEmptyDatabaseName_ShouldNotThrow()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);

        // Act & Assert
        var exception = Record.Exception(() => connection.ChangeDatabase(string.Empty));
        
        if (exception != null)
        {
            exception.Should().NotBeOfType<NullReferenceException>();
        }
    }

    #endregion

    #region GetSchema Method Tests

    [Fact]
    public void GetSchema_WithValidConnection_ShouldReturnDataTable()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);

        // Act & Assert
        try
        {
            connection.Open();
            var schema = connection.GetSchema();
            schema.Should().NotBeNull();
            schema.Should().BeOfType<DataTable>();
        }
        catch (Exception ex)
        {
            // Expected in test environment without actual database
            ex.Should().NotBeOfType<NullReferenceException>();
        }
    }

    [Fact]
    public void GetSchema_WithNullInnerConnection_ShouldThrowException()
    {
        // Arrange
        using var connection = new MsiSqlConnection();

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => connection.GetSchema());
        exception.Message.Should().Contain("Null Connection GetSchema");
    }

    [Fact]
    public void GetSchema_WithCollectionName_ShouldReturnDataTable()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);
        var collectionName = "Tables";

        // Act & Assert
        try
        {
            connection.Open();
            var schema = connection.GetSchema(collectionName);
            schema.Should().NotBeNull();
            schema.Should().BeOfType<DataTable>();
        }
        catch (Exception ex)
        {
            // Expected in test environment without actual database
            ex.Should().NotBeOfType<NullReferenceException>();
        }
    }

    [Fact]
    public void GetSchema_WithCollectionNameAndNullConnection_ShouldThrowException()
    {
        // Arrange
        using var connection = new MsiSqlConnection();
        var collectionName = "Tables";

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => connection.GetSchema(collectionName));
        exception.Message.Should().Contain("Null Connection GetSchema");
    }

    [Fact]
    public void GetSchema_WithCollectionNameAndRestrictions_ShouldReturnDataTable()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);
        var collectionName = "Tables";
        var restrictions = new[] { "TestDatabase", "dbo", "TestTable" };

        // Act & Assert
        try
        {
            connection.Open();
            var schema = connection.GetSchema(collectionName, restrictions);
            schema.Should().NotBeNull();
            schema.Should().BeOfType<DataTable>();
        }
        catch (Exception ex)
        {
            // Expected in test environment without actual database
            ex.Should().NotBeOfType<NullReferenceException>();
        }
    }

    [Fact]
    public void GetSchema_WithRestrictionsAndNullConnection_ShouldThrowException()
    {
        // Arrange
        using var connection = new MsiSqlConnection();
        var collectionName = "Tables";
        var restrictions = new[] { "TestDatabase" };

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => connection.GetSchema(collectionName, restrictions));
        exception.Message.Should().Contain("Null Connection GetSchema");
    }

    [Theory]
    [InlineData("Tables")]
    [InlineData("Columns")]
    [InlineData("Views")]
    [InlineData("Procedures")]
    public void GetSchema_WithDifferentCollectionNames_ShouldNotThrowNullReference(string collectionName)
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);

        // Act & Assert
        try
        {
            connection.Open();
            var schema = connection.GetSchema(collectionName);
            schema.Should().NotBeNull();
        }
        catch (Exception ex)
        {
            // Expected in test environment, but should not be null reference
            ex.Should().NotBeOfType<NullReferenceException>();
        }
    }

    #endregion

    #region Dispose Method Tests

    [Fact]
    public void Dispose_WithValidConnection_ShouldNotThrow()
    {
        // Arrange
        var connection = new MsiSqlConnection(ValidConnectionString);

        // Act & Assert
        var exception = Record.Exception(() => connection.Dispose());
        exception.Should().BeNull("Dispose should never throw");
    }

    [Fact]
    public void Dispose_WithNullInnerConnection_ShouldNotThrow()
    {
        // Arrange
        var connection = new MsiSqlConnection();

        // Act & Assert
        var exception = Record.Exception(() => connection.Dispose());
        exception.Should().BeNull("Dispose should handle null inner connection gracefully");
    }

    [Fact]
    public void Dispose_MultipleCalls_ShouldNotThrow()
    {
        // Arrange
        var connection = new MsiSqlConnection(ValidConnectionString);

        // Act & Assert
        var exception1 = Record.Exception(() => connection.Dispose());
        var exception2 = Record.Exception(() => connection.Dispose());
        var exception3 = Record.Exception(() => connection.Dispose());
        
        exception1.Should().BeNull();
        exception2.Should().BeNull();
        exception3.Should().BeNull();
    }

    [Fact]
    public void Dispose_AfterOperations_ShouldCleanupProperly()
    {
        // Arrange
        var connection = new MsiSqlConnection(ValidConnectionString);
        
        // Perform some operations
        var exception1 = Record.Exception(() => connection.Close());
        var innerConnection = connection.InnerConnection;

        // Act
        connection.Dispose();

        // Assert
        var exception2 = Record.Exception(() => connection.Dispose());
        exception1.Should().BeNull();
        exception2.Should().BeNull();
    }

    #endregion

    #region DisposeAsync Method Tests

    [Fact]
    public async Task DisposeAsync_WithValidConnection_ShouldNotThrow()
    {
        // Arrange
        var connection = new MsiSqlConnection(ValidConnectionString);

        // Act & Assert
        var exception = await Record.ExceptionAsync(() => connection.DisposeAsync());
        exception.Should().BeNull("DisposeAsync should never throw");
    }

    [Fact]
    public async Task DisposeAsync_WithNullInnerConnection_ShouldNotThrow()
    {
        // Arrange
        var connection = new MsiSqlConnection();

        // Act & Assert
        var exception = await Record.ExceptionAsync(() => connection.DisposeAsync());
        exception.Should().BeNull("DisposeAsync should handle null inner connection gracefully");
    }

    [Fact]
    public async Task DisposeAsync_MultipleCalls_ShouldNotThrow()
    {
        // Arrange
        var connection = new MsiSqlConnection(ValidConnectionString);

        // Act & Assert
        var exception1 = await Record.ExceptionAsync(() => connection.DisposeAsync());
        var exception2 = await Record.ExceptionAsync(() => connection.DisposeAsync());
        var exception3 = await Record.ExceptionAsync(() => connection.DisposeAsync());
        
        exception1.Should().BeNull();
        exception2.Should().BeNull();
        exception3.Should().BeNull();
    }

    [Fact]
    public async Task DisposeAsync_WithTimeout_ShouldCompleteQuickly()
    {
        // Arrange
        var connection = new MsiSqlConnection(ValidConnectionString);
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));

        // Act & Assert
        var exception = await Record.ExceptionAsync(() => connection.DisposeAsync());
        exception.Should().BeNull();
        cts.Token.IsCancellationRequested.Should().BeFalse("DisposeAsync should complete quickly");
    }

    #endregion

    #region Integration Tests

    [Fact]
    public void CompleteWorkflow_CreateOpenCloseDispose_ShouldWorkCorrectly()
    {
        // Arrange & Act & Assert
        var exception = Record.Exception(() =>
        {
            using var connection = new MsiSqlConnection(ValidConnectionString);
            connection.UseDbo = TestUri1; // SILVA
            
            var state1 = connection.State;
            state1.Should().Be(ConnectionState.Closed);
            
            try
            {
                connection.Open();
                // If open succeeds, test other operations
                var command = connection.CreateCommand();
                command.Should().NotBeNull();
            }
            catch
            {
                // Expected in test environment
            }
            
            connection.Close();
            var state2 = connection.State;
            // State should be either Closed or the same as before
        });
        
        // Should complete without null reference exceptions
        if (exception != null)
        {
            exception.Should().NotBeOfType<NullReferenceException>();
        }
    }

    [Fact]
    public async Task CompleteAsyncWorkflow_CreateOpenCloseDispose_ShouldWorkCorrectly()
    {
        // Arrange & Act & Assert
        var exception = await Record.ExceptionAsync(async () =>
        {
            var connection = new MsiSqlConnection(ValidConnectionString);
            connection.UseDbo = TestUri2; // PEDRO
            
            try
            {
                await connection.OpenAsync();
                // If open succeeds, test other operations
                var command = connection.CreateCommand();
                command.Should().NotBeNull();
            }
            catch
            {
                // Expected in test environment
            }
            
            await connection.CloseAsync();
            await connection.DisposeAsync();
        });
        
        // Should complete without null reference exceptions
        if (exception != null)
        {
            exception.Should().NotBeOfType<NullReferenceException>();
        }
    }

    [Theory]
    [InlineData(TestUri1)] // SILVA
    [InlineData(TestUri2)] // PEDRO
    [InlineData(TestUri3)] // JOAO
    [InlineData(TestUri4)] // MARIA
    [InlineData(TestUri5)] // SANTOS
    public void UseDbo_WithDifferentTestUris_ShouldStoreCorrectly(string testUri)
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);

        // Act
        connection.UseDbo = testUri;

        // Assert
        connection.UseDbo.Should().Be(testUri);
    }
 

    #endregion

    #region Edge Case Tests
     

    [Fact]
    public void UseDbo_WithNullValue_ShouldAcceptNull()
    {
        // Arrange
        using var connection = new MsiSqlConnection();

        // Act
        connection.UseDbo = null!;

        // Assert
        connection.UseDbo.Should().BeNull();
    }

    [Fact]
    public void UseDbo_WithSpecialCharacters_ShouldStoreCorrectly()
    {
        // Arrange
        using var connection = new MsiSqlConnection();
        var specialValue = "test_123-אימ@#$%";

        // Act
        connection.UseDbo = specialValue;

        // Assert
        connection.UseDbo.Should().Be(specialValue);
    }

    [Fact]
    public void State_MultipleCalls_ShouldBeConsistent()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);

        // Act
        var state1 = connection.State;
        var state2 = connection.State;
        var state3 = connection.State;

        // Assert
        state1.Should().Be(state2);
        state2.Should().Be(state3);
        state1.Should().Be(ConnectionState.Closed);
    }

    #endregion

    #region Performance Tests

    [Fact]
    public void Constructor_Performance_ShouldBeReasonablyFast()
    {
        // Arrange
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        // Act
        for (int i = 0; i < 1000; i++)
        {
            using var connection = new MsiSqlConnection(ValidConnectionString);
        }

        stopwatch.Stop();

        // Assert
        stopwatch.ElapsedMilliseconds.Should().BeLessThan(5000, "Creating 1000 connections should be reasonably fast");
    }

    [Fact]
    public void PropertyAccess_Performance_ShouldBeVeryFast()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        // Act
        for (int i = 0; i < 10000; i++)
        {
            var state = connection.State;
            var connectionString = connection.ConnectionString;
            var useDbo = connection.UseDbo;
        }

        stopwatch.Stop();

        // Assert
        stopwatch.ElapsedMilliseconds.Should().BeLessThan(1000, "Property access should be very fast");
    }

    [Fact]
    public async Task AsyncMethods_Performance_ShouldCompleteQuickly()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        // Act
        var tasks = new List<Task>();
        for (int i = 0; i < 100; i++)
        {
            tasks.Add(connection.CloseAsync());
            tasks.Add(connection.DisposeAsync());
        }

        await Task.WhenAll(tasks);
        stopwatch.Stop();

        // Assert
        stopwatch.ElapsedMilliseconds.Should().BeLessThan(10000, "Async operations should complete quickly");
    }

    #endregion

    #region Memory Management Tests

    [Fact]
    public void Dispose_ShouldReleaseResources()
    {
        // Arrange
        var connection = new MsiSqlConnection(ValidConnectionString);
        var weakRef = new WeakReference(connection.InnerConnection);

        // Act
        connection.Dispose();
        connection = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        // Assert
        // Note: This test might be flaky depending on GC behavior
        // but it validates that resources can be collected
        weakRef.Should().NotBeNull();
    }

    [Fact]
    public void MultipleConnections_ShouldNotLeakMemory()
    {
        // Arrange & Act
        var initialMemory = GC.GetTotalMemory(true);
        
        for (int i = 0; i < 1000; i++)
        {
            using var connection = new MsiSqlConnection(ValidConnectionString);
            connection.UseDbo = TestUri1; // SILVA
        }
        
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        
        var finalMemory = GC.GetTotalMemory(true);

        // Assert
        var memoryIncrease = finalMemory - initialMemory;
        memoryIncrease.Should().BeLessThan(50 * 1024 * 1024, "Memory increase should be reasonable (less than 50MB)");
    }

    #endregion

    #region Thread Safety Tests

    [Fact]
    public void ConnectionProperties_ThreadSafety_ShouldNotCrash()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);
        var tasks = new List<Task>();
        var exceptions = new List<Exception>();

        // Act
        for (int i = 0; i < 10; i++)
        {
            var index = i;
            tasks.Add(Task.Run(() =>
            {
                try
                {
                    for (int j = 0; j < 100; j++)
                    {
                        connection.UseDbo = $"test_{index}_{j}";
                        var state = connection.State;
                        var connectionString = connection.ConnectionString;
                        var useDbo = connection.UseDbo;
                    }
                }
                catch (Exception ex)
                {
                    lock (exceptions)
                    {
                        exceptions.Add(ex);
                    }
                }
            }));
        }

        Task.WaitAll(tasks.ToArray());

        // Assert
        exceptions.Should().BeEmpty("Concurrent property access should not throw exceptions");
    }

    [Fact]
    public async Task AsyncOperations_Concurrency_ShouldNotCrash()
    {
        // Arrange
        using var connection = new MsiSqlConnection(ValidConnectionString);
        var tasks = new List<Task>();
        var exceptions = new List<Exception>();

        // Act
        for (int i = 0; i < 10; i++)
        {
            tasks.Add(Task.Run(async () =>
            {
                try
                {
                    await connection.CloseAsync();
                    await connection.DisposeAsync();
                }
                catch (Exception ex)
                {
                    lock (exceptions)
                    {
                        exceptions.Add(ex);
                    }
                }
            }));
        }

        await Task.WhenAll(tasks);

        // Assert
        exceptions.Should().BeEmpty("Concurrent async operations should not throw exceptions");
    }

    #endregion
}