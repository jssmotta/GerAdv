using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using MenphisSI.Connections;
using Microsoft.Data.SqlClient;
using Moq;
using Xunit;

namespace Infrastructure.Tests.Connections;

/// <summary>
/// Comprehensive unit tests for ConnectionWrapper class
/// Testing with non-existent client URI patterns (SILVA, PEDRO, JOAO, MARIA, SANTOS)
/// and one existing URI (DEVPB) for positive testing
/// </summary>
public class ConnectionWrapperTests
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

    #endregion

    #region Constructor Tests

    [Fact]
    public void Constructor_WithValidConnection_ShouldInitializeCorrectly()
    {
        // Arrange
        var mockConnection = CreateMockConnection();
        var beforeConstruction = DateTime.Now;

        // Act
        var wrapper = new ConnectionWrapper(mockConnection);
        var afterConstruction = DateTime.Now;

        // Assert
        wrapper.Connection.Should().BeSameAs(mockConnection);
        wrapper.LastUsed.Should().BeAfter(beforeConstruction.AddMilliseconds(-10));
        wrapper.LastUsed.Should().BeBefore(afterConstruction.AddMilliseconds(10));
    }

    [Fact]
    public void Constructor_WithNullConnection_ShouldThrowArgumentNullException()
    {
        // Arrange
        MsiSqlConnection? nullConnection = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new ConnectionWrapper(nullConnection!));
        exception.ParamName.Should().Contain("connection");
    }

    [Fact]
    public void Constructor_ShouldSetLastUsedToCurrentTime()
    {
        // Arrange
        var mockConnection = CreateMockConnection();
        var timeBefore = DateTime.Now;

        // Act
        var wrapper = new ConnectionWrapper(mockConnection);

        // Assert
        var timeAfter = DateTime.Now;
        wrapper.LastUsed.Should().BeOnOrAfter(timeBefore);
        wrapper.LastUsed.Should().BeOnOrBefore(timeAfter);
    }

    [Theory]
    [InlineData(NonExistentClientUri1)] // SILVA
    [InlineData(NonExistentClientUri2)] // PEDRO
    [InlineData(NonExistentClientUri3)] // JOAO
    [InlineData(NonExistentClientUri4)] // MARIA
    [InlineData(NonExistentClientUri5)] // SANTOS
    public void Constructor_WithConnectionsFromNonExistentUris_ShouldWork(string uri)
    {
        // Arrange - Create mock connection that would represent connection from non-existent URI
        var mockConnection = CreateMockConnection(connectionString: $"Data Source=fake;Initial Catalog={uri}DB;");

        // Act
        var wrapper = new ConnectionWrapper(mockConnection);

        // Assert
        wrapper.Connection.Should().NotBeNull();
        wrapper.LastUsed.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void Constructor_WithExistingUriConnection_ShouldWork()
    {
        // Arrange - Create mock connection for DEVPB (the only allowed existing URI)
        var mockConnection = CreateMockConnection(connectionString: $"Data Source=devpb.server;Initial Catalog={ExistingClientUri}DB;");

        // Act
        var wrapper = new ConnectionWrapper(mockConnection);

        // Assert
        wrapper.Connection.Should().NotBeNull();
        wrapper.LastUsed.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
    }

    #endregion

    #region Connection Property Tests

    [Fact]
    public void Connection_ShouldBeReadOnly()
    {
        // Arrange
        var mockConnection = CreateMockConnection();
        var wrapper = new ConnectionWrapper(mockConnection);

        // Act & Assert
        wrapper.Connection.Should().BeSameAs(mockConnection);

        // Verify property is read-only by checking it doesn't have a setter
        var connectionProperty = typeof(ConnectionWrapper).GetProperty(nameof(ConnectionWrapper.Connection));
        connectionProperty.Should().NotBeNull();
        connectionProperty!.CanRead.Should().BeTrue();
        connectionProperty.CanWrite.Should().BeFalse();
    }

    [Fact]
    public void Connection_ShouldReturnSameInstanceAlways()
    {
        // Arrange
        var mockConnection = CreateMockConnection();
        var wrapper = new ConnectionWrapper(mockConnection);

        // Act
        var connection1 = wrapper.Connection;
        var connection2 = wrapper.Connection;

        // Assert
        connection1.Should().BeSameAs(connection2);
        connection1.Should().BeSameAs(mockConnection);
    }

  

    [Theory]
    [InlineData(ConnectionState.Closed)]
    [InlineData(ConnectionState.Open)]
    [InlineData(ConnectionState.Connecting)]
    [InlineData(ConnectionState.Executing)]
    [InlineData(ConnectionState.Fetching)]
    [InlineData(ConnectionState.Broken)]
    public void Connection_ShouldPreserveConnectionState(ConnectionState state)
    {
        // Arrange
        var mockConnection = CreateMockConnection();
        Mock.Get(mockConnection).SetupGet(c => c.State).Returns(state);

        // Act
        var wrapper = new ConnectionWrapper(mockConnection);

        // Assert
        wrapper.Connection.State.Should().Be(state);
    }

    #endregion

    #region LastUsed Property Tests

    [Fact]
    public void LastUsed_ShouldBeSettable()
    {
        // Arrange
        var mockConnection = CreateMockConnection();
        var wrapper = new ConnectionWrapper(mockConnection);
        var newTime = new DateTime(2023, 1, 1, 12, 0, 0);

        // Act
        wrapper.LastUsed = newTime;

        // Assert
        wrapper.LastUsed.Should().Be(newTime);
    }

    [Fact]
    public void LastUsed_ShouldBeGettable()
    {
        // Arrange
        var mockConnection = CreateMockConnection();
        var wrapper = new ConnectionWrapper(mockConnection);
        var originalTime = wrapper.LastUsed;

        // Act
        var retrievedTime = wrapper.LastUsed;

        // Assert
        retrievedTime.Should().Be(originalTime);
    }

    [Fact]
    public void LastUsed_ShouldAllowMultipleUpdates()
    {
        // Arrange
        var mockConnection = CreateMockConnection();
        var wrapper = new ConnectionWrapper(mockConnection);
        var time1 = new DateTime(2023, 1, 1, 10, 0, 0);
        var time2 = new DateTime(2023, 1, 1, 11, 0, 0);
        var time3 = new DateTime(2023, 1, 1, 12, 0, 0);

        // Act & Assert
        wrapper.LastUsed = time1;
        wrapper.LastUsed.Should().Be(time1);

        wrapper.LastUsed = time2;
        wrapper.LastUsed.Should().Be(time2);

        wrapper.LastUsed = time3;
        wrapper.LastUsed.Should().Be(time3);
    }

    [Fact]
    public void LastUsed_ShouldAllowMinAndMaxDateValues()
    {
        // Arrange
        var mockConnection = CreateMockConnection();
        var wrapper = new ConnectionWrapper(mockConnection);

        // Act & Assert
        wrapper.LastUsed = DateTime.MinValue;
        wrapper.LastUsed.Should().Be(DateTime.MinValue);

        wrapper.LastUsed = DateTime.MaxValue;
        wrapper.LastUsed.Should().Be(DateTime.MaxValue);
    }

    [Theory]
    [InlineData("2023-01-01")]
    [InlineData("2023-12-31")]
    [InlineData("2024-02-29")] // Leap year
    [InlineData("1900-01-01")]
    [InlineData("2099-12-31")]
    public void LastUsed_ShouldAcceptValidDateStrings(string dateString)
    {
        // Arrange
        var mockConnection = CreateMockConnection();
        var wrapper = new ConnectionWrapper(mockConnection);
        var targetDate = DateTime.Parse(dateString);

        // Act
        wrapper.LastUsed = targetDate;

        // Assert
        wrapper.LastUsed.Should().Be(targetDate);
    }

    #endregion

    #region Multiple Wrapper Tests

    [Fact]
    public void MultipleWrappers_WithSameConnection_ShouldBeIndependent()
    {
        // Arrange
        var mockConnection = CreateMockConnection();
        var time1 = new DateTime(2023, 1, 1, 10, 0, 0);
        var time2 = new DateTime(2023, 1, 1, 11, 0, 0);

        // Act
        var wrapper1 = new ConnectionWrapper(mockConnection);
        var wrapper2 = new ConnectionWrapper(mockConnection);

        wrapper1.LastUsed = time1;
        wrapper2.LastUsed = time2;

        // Assert
        wrapper1.Connection.Should().BeSameAs(wrapper2.Connection);
        wrapper1.LastUsed.Should().Be(time1);
        wrapper2.LastUsed.Should().Be(time2);
        wrapper1.LastUsed.Should().NotBe(wrapper2.LastUsed);
    }

    [Fact]
    public void MultipleWrappers_WithDifferentConnections_ShouldBeIndependent()
    {
        // Arrange
        var mockConnection1 = CreateMockConnection("Data Source=server1;");
        var mockConnection2 = CreateMockConnection("Data Source=server2;");
        var time1 = new DateTime(2023, 1, 1, 10, 0, 0);
        var time2 = new DateTime(2023, 1, 1, 11, 0, 0);

        // Act
        var wrapper1 = new ConnectionWrapper(mockConnection1);
        var wrapper2 = new ConnectionWrapper(mockConnection2);

        wrapper1.LastUsed = time1;
        wrapper2.LastUsed = time2;

        // Assert
        wrapper1.Connection.Should().NotBeSameAs(wrapper2.Connection);
        wrapper1.LastUsed.Should().Be(time1);
        wrapper2.LastUsed.Should().Be(time2);
    }

   

    #endregion

    #region Threading Tests

    [Fact]
    public void LastUsed_ConcurrentAccess_ShouldBeThreadSafe()
    {
        // Arrange
        var mockConnection = CreateMockConnection();
        var wrapper = new ConnectionWrapper(mockConnection);
        const int threadCount = 10;
        const int iterationsPerThread = 100;
        var tasks = new Task[threadCount];
        var random = new Random();

        // Act
        for (int i = 0; i < threadCount; i++)
        {
            var threadIndex = i;
            tasks[threadIndex] = Task.Run(() =>
            {
                for (int j = 0; j < iterationsPerThread; j++)
                {
                    // Random operations on LastUsed
                    if (j % 2 == 0)
                    {
                        wrapper.LastUsed = DateTime.Now.AddMinutes(random.Next(-1000, 1000));
                    }
                    else
                    {
                        var _ = wrapper.LastUsed;
                    }
                }
            });
        }

        // Assert
        var aggregateException = Record.Exception(() => Task.WaitAll(tasks));
        aggregateException.Should().BeNull("Concurrent access should not cause exceptions");
        wrapper.LastUsed.Should().NotBe(default(DateTime));
    }

    [Fact]
    public async Task LastUsed_AsyncConcurrentAccess_ShouldBeThreadSafe()
    {
        // Arrange
        var mockConnection = CreateMockConnection();
        var wrapper = new ConnectionWrapper(mockConnection);
        const int taskCount = 10;
        var tasks = new Task[taskCount];

        // Act
        for (int i = 0; i < taskCount; i++)
        {
            var taskIndex = i;
            tasks[taskIndex] = Task.Run(async () =>
            {
                await Task.Delay(taskIndex * 10); // Stagger the tasks
                wrapper.LastUsed = DateTime.Now.AddMinutes(taskIndex);
                await Task.Delay(10);
                var _ = wrapper.LastUsed;
            });
        }

        // Assert
        var aggregateException = await Record.ExceptionAsync(async () => await Task.WhenAll(tasks));
        aggregateException.Should().BeNull("Async concurrent access should not cause exceptions");
        wrapper.LastUsed.Should().NotBe(default(DateTime));
    }

    #endregion

    #region Connection Wrapper Lifecycle Tests

    [Fact]
    public void Wrapper_ShouldNotDisposeConnection_WhenWrapperGoesOutOfScope()
    {
        // Arrange
        var mockConnection = CreateMockConnection();
        var disposedCalled = false;

        // Mock the Dispose method to track if it's called
        var mock = Mock.Get(mockConnection);
        mock.Setup(c => c.Dispose()).Callback(() => disposedCalled = true);

        // Act
        {
            var wrapper = new ConnectionWrapper(mockConnection);
            // wrapper goes out of scope here
        }

        // Force garbage collection
        GC.Collect();
        GC.WaitForPendingFinalizers();

        // Assert
        disposedCalled.Should().BeFalse("ConnectionWrapper should not dispose the wrapped connection");
    }

    [Fact]
    public void Wrapper_ShouldMaintainConnectionReference_AfterGarbageCollection()
    {
        // Arrange
        var mockConnection = CreateMockConnection();
        var wrapper = new ConnectionWrapper(mockConnection);
        var originalConnectionString = wrapper.Connection.ConnectionString;

        // Act
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        // Assert
        wrapper.Connection.Should().NotBeNull();
        wrapper.Connection.ConnectionString.Should().Be(originalConnectionString);
    }

    #endregion

    #region Connection Operations Tests

   

    [Fact]
    public void Wrapper_ShouldPreserveConnectionBehavior()
    {
        // Arrange
        var connectionString = "Data Source=test;Initial Catalog=TestDB;";
        var mockConnection = CreateMockConnection(connectionString);
        var wrapper = new ConnectionWrapper(mockConnection);

        // Setup mock behavior for state tracking
        var mock = Mock.Get(mockConnection);
        var currentState = ConnectionState.Closed;
        
        mock.SetupGet(c => c.State).Returns(() => currentState);
        mock.Setup(c => c.Open()).Callback(() => currentState = ConnectionState.Open);
        mock.Setup(c => c.Close()).Callback(() => currentState = ConnectionState.Closed);

        // Act & Assert
        wrapper.Connection.State.Should().Be(ConnectionState.Closed);

        wrapper.Connection.Open();
        wrapper.Connection.State.Should().Be(ConnectionState.Open);

        wrapper.Connection.Close();
        wrapper.Connection.State.Should().Be(ConnectionState.Closed);
    }

    [Fact]
    public async Task Wrapper_ShouldSupportAsyncOperations()
    {
        // Arrange
        var mockConnection = CreateMockConnection();
        var wrapper = new ConnectionWrapper(mockConnection);

        // Setup async mock behavior
        var mock = Mock.Get(mockConnection);
        var currentState = ConnectionState.Closed;
        
        mock.SetupGet(c => c.State).Returns(() => currentState);
        mock.Setup(c => c.OpenAsync(It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask)
            .Callback(() => currentState = ConnectionState.Open);

        // Act & Assert
        await wrapper.Connection.OpenAsync();
        wrapper.Connection.State.Should().Be(ConnectionState.Open);
    }

    #endregion

    #region Class Structure Tests

    [Fact]
    public void ConnectionWrapper_ShouldBePublicClass()
    {
        // Arrange
        var type = typeof(ConnectionWrapper);

        // Assert
        type.Should().NotBeNull();
        type.IsClass.Should().BeTrue();
        type.IsPublic.Should().BeTrue();
        type.IsAbstract.Should().BeFalse();
        type.IsSealed.Should().BeFalse();
    }

    [Fact]
    public void ConnectionWrapper_ShouldHaveCorrectProperties()
    {
        // Arrange
        var type = typeof(ConnectionWrapper);

        // Assert
        var connectionProperty = type.GetProperty(nameof(ConnectionWrapper.Connection));
        connectionProperty.Should().NotBeNull();
        connectionProperty!.PropertyType.Should().Be(typeof(MsiSqlConnection));
        connectionProperty.CanRead.Should().BeTrue();
        connectionProperty.CanWrite.Should().BeFalse();

        var lastUsedProperty = type.GetProperty(nameof(ConnectionWrapper.LastUsed));
        lastUsedProperty.Should().NotBeNull();
        lastUsedProperty!.PropertyType.Should().Be(typeof(DateTime));
        lastUsedProperty.CanRead.Should().BeTrue();
        lastUsedProperty.CanWrite.Should().BeTrue();
    }

    [Fact]
    public void ConnectionWrapper_ShouldHaveCorrectConstructor()
    {
        // Arrange
        var type = typeof(ConnectionWrapper);

        // Assert
        var constructors = type.GetConstructors();
        constructors.Should().HaveCount(1);

        var constructor = constructors[0];
        constructor.IsPublic.Should().BeTrue();
        constructor.GetParameters().Should().HaveCount(1);
        constructor.GetParameters()[0].ParameterType.Should().Be(typeof(MsiSqlConnection));
    }

    [Fact]
    public void ConnectionWrapper_ShouldNotHaveOtherMethods()
    {
        // Arrange
        var type = typeof(ConnectionWrapper);

        // Assert
        var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        
        // Should only have property getters/setters and inherited methods
        var expectedMethods = new[] { "get_Connection", "get_LastUsed", "set_LastUsed" };
        var actualMethods = methods.Select(m => m.Name).ToArray();

        foreach (var expectedMethod in expectedMethods)
        {
            actualMethods.Should().Contain(expectedMethod);
        }

        // No custom methods beyond property accessors
        methods.Where(m => !m.Name.StartsWith("get_") && !m.Name.StartsWith("set_")).Should().BeEmpty();
    }

    #endregion

    #region Real-World Scenario Tests

    [Fact]
    public void Wrapper_ConnectionPoolScenario_ShouldTrackUsage()
    {
        // Arrange - Simulate connection pool scenario
        var connections = new[]
        {
            CreateMockConnection("Data Source=server1;"),
            CreateMockConnection("Data Source=server2;"),
            CreateMockConnection("Data Source=server3;")
        };

        var wrappers = connections.Select(c => new ConnectionWrapper(c)).ToArray();
        var baseTime = DateTime.Now;

        // Act - Simulate usage at different times
        wrappers[0].LastUsed = baseTime.AddMinutes(-10); // Oldest
        wrappers[1].LastUsed = baseTime.AddMinutes(-5);  // Middle
        wrappers[2].LastUsed = baseTime.AddMinutes(-1);  // Newest

        // Assert
        var orderedByUsage = wrappers.OrderBy(w => w.LastUsed).ToArray();
        orderedByUsage[0].Should().BeSameAs(wrappers[0]); // Oldest first
        orderedByUsage[1].Should().BeSameAs(wrappers[1]); // Middle second
        orderedByUsage[2].Should().BeSameAs(wrappers[2]); // Newest last
    }

    [Fact]
    public void Wrapper_ConnectionTimeoutScenario_ShouldIdentifyStaleConnections()
    {
        // Arrange
        var mockConnection = CreateMockConnection();
        var wrapper = new ConnectionWrapper(mockConnection);
        var timeoutThreshold = TimeSpan.FromMinutes(30);
        var staleTime = DateTime.Now.Subtract(timeoutThreshold.Add(TimeSpan.FromMinutes(5)));

        // Act
        wrapper.LastUsed = staleTime;

        // Assert
        var isStale = DateTime.Now.Subtract(wrapper.LastUsed) > timeoutThreshold;
        isStale.Should().BeTrue("Connection should be considered stale");
    }
 

    #endregion

    #region Edge Cases Tests

   

    [Fact]
    public void CreateMockConnection_WithNullConnectionString_ShouldThrowException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => CreateMockConnection(null));
        exception.ParamName.Should().Contain("connection");
    }

    [Fact]
    public void Wrapper_WithConnectionHavingNullConnectionString_ShouldWork()
    {
        // Arrange - Create a mock connection that can have null connection string
        // We need to use the parameterless constructor and mock the ConnectionString property
        var mock = new Mock<MsiSqlConnection>();
        mock.SetupGet(c => c.ConnectionString).Returns((string)null!);
        mock.SetupGet(c => c.State).Returns(ConnectionState.Closed);
        
        // Setup basic methods        
        mock.Setup(c => c.Open());
        mock.Setup(c => c.Close());
        mock.Setup(c => c.Dispose());
        
        // Setup async methods
        mock.Setup(c => c.OpenAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
        mock.Setup(c => c.CloseAsync()).Returns(Task.CompletedTask);
        mock.Setup(c => c.DisposeAsync()).Returns(Task.CompletedTask);

        var mockConnection = mock.Object;

        // Act
        var wrapper = new ConnectionWrapper(mockConnection);

        // Assert
        wrapper.Connection.Should().NotBeNull();
        wrapper.Connection.ConnectionString.Should().BeNull();
        wrapper.LastUsed.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void Wrapper_LastUsedPrecision_ShouldPreserveDateTimePrecision()
    {
        // Arrange
        var mockConnection = CreateMockConnection();
        var wrapper = new ConnectionWrapper(mockConnection);
        var preciseTime = new DateTime(2023, 1, 1, 12, 30, 45, 123);

        // Act
        wrapper.LastUsed = preciseTime;

        // Assert
        wrapper.LastUsed.Should().Be(preciseTime);
        wrapper.LastUsed.Millisecond.Should().Be(123);
    }

    #endregion

    #region Helper Methods

    /// <summary>
    /// Creates a mock MsiSqlConnection for testing purposes
    /// </summary>
    /// <param name="connectionString">Optional connection string</param>
    /// <returns>Mocked MsiSqlConnection</returns>
    private static MsiSqlConnection CreateMockConnection(string? connectionString = "Data Source=localhost;Integrated Security=True;")
    {
        try
        {
            var mock = new Mock<MsiSqlConnection>(connectionString);

            // Setup basic methods        
            mock.Setup(c => c.Open());
            mock.Setup(c => c.Close());
            mock.Setup(c => c.Dispose());

            // Setup async methods
            mock.Setup(c => c.OpenAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            mock.Setup(c => c.CloseAsync()).Returns(Task.CompletedTask);
            mock.Setup(c => c.DisposeAsync()).Returns(Task.CompletedTask);

            return mock.Object;
        }
        catch (TargetInvocationException ex) when (ex.InnerException is ArgumentNullException)
        {
            // Handle the case where the connection string is null
            throw new ArgumentNullException(connectionString == null ? "connectionString" : "MsiSqlConnection", ex.InnerException.Message);
        }
        catch (ArgumentNullException ex)
        {
            throw new ArgumentNullException(connectionString == null ? "connectionString" : "MsiSqlConnection", ex.Message);
        }
    }

    #endregion
}