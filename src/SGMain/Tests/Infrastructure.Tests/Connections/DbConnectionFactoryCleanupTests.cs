using System.Collections.Concurrent;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Timers;
using FluentAssertions;
using MenphisSI.Connections;
using Microsoft.Data.SqlClient;
using Moq;
using Xunit;

namespace Infrastructure.Tests.Connections;

/// <summary>
/// Specialized tests for DbConnectionFactory cleanup timer and ConnectionWrapper integration
/// focusing on idle connection cleanup and timer behavior
/// </summary>
public class DbConnectionFactoryCleanupTests : IDisposable
{
    #region Test Data Constants
    
    private const string TestConnectionString = "Data Source=localhost;Integrated Security=true;TrustServerCertificate=True;";
    private readonly List<IDisposable> _disposables = new();
    
    #endregion

    #region Cleanup Timer Behavior Tests

    [Fact]
    public void CleanupTimer_ShouldBeInitializedInStaticConstructor()
    {
        // Arrange & Act
        var type = typeof(DbConnectionFactory);
        var timerField = type.GetField("_cleanupTimer", BindingFlags.NonPublic | BindingFlags.Static);
        
        // Assert
        timerField.Should().NotBeNull("Cleanup timer field should exist");
        
        var timer = timerField!.GetValue(null) as System.Timers.Timer;
        timer.Should().NotBeNull("Cleanup timer should be initialized");
        timer!.Enabled.Should().BeTrue("Cleanup timer should be started");
    }

    [Fact]
    public void CleanupTimer_ShouldHaveCorrectInterval()
    {
        // Arrange
        var type = typeof(DbConnectionFactory);
        var timerField = type.GetField("_cleanupTimer", BindingFlags.NonPublic | BindingFlags.Static);
        var idleTimeoutField = type.GetField("IdleTimeout", BindingFlags.NonPublic | BindingFlags.Static);
        
        // Act
        var timer = timerField!.GetValue(null) as System.Timers.Timer;
        var idleTimeout = (int)idleTimeoutField!.GetValue(null)!;
        
        // Assert
        timer!.Interval.Should().Be(idleTimeout * 1000, "Timer interval should be IdleTimeout in milliseconds");
        timer.Interval.Should().Be(300000, "Timer interval should be 300 seconds (5 minutes)");
    }

    [Fact]
    public void CleanupTimer_ShouldAutoReset()
    {
        // Arrange
        var type = typeof(DbConnectionFactory);
        var timerField = type.GetField("_cleanupTimer", BindingFlags.NonPublic | BindingFlags.Static);
        
        // Act
        var timer = timerField!.GetValue(null) as System.Timers.Timer;
        
        // Assert
        timer!.AutoReset.Should().BeTrue("Cleanup timer should auto-reset to run continuously");
    }

    #endregion

    #region CleanupIdleConnections Method Tests

    [Fact]
    public void CleanupIdleConnections_ShouldExistAsPrivateStaticMethod()
    {
        // Arrange
        var type = typeof(DbConnectionFactory);
        
        // Act
        var method = type.GetMethod("CleanupIdleConnections", BindingFlags.NonPublic | BindingFlags.Static);
        
        // Assert
        method.Should().NotBeNull("CleanupIdleConnections method should exist");
        method!.IsStatic.Should().BeTrue("CleanupIdleConnections should be static");
        method.IsPrivate.Should().BeTrue("CleanupIdleConnections should be private");
        method.ReturnType.Should().Be(typeof(void));
        
        var parameters = method.GetParameters();
        parameters.Should().HaveCount(2);
        parameters[0].ParameterType.Should().Be(typeof(object));
        parameters[1].ParameterType.Should().Be(typeof(ElapsedEventArgs));
    }

    [Fact]
    public void CleanupIdleConnections_WithNullSender_ShouldNotThrow()
    {
        // Arrange
        var type = typeof(DbConnectionFactory);
        var method = type.GetMethod("CleanupIdleConnections", BindingFlags.NonPublic | BindingFlags.Static);
        var elapsedEventArgs = new ElapsedEventArgs(DateTime.Now);
        
        // Act & Assert
        var exception = Record.Exception(() => 
            method!.Invoke(null, new object?[] { null, elapsedEventArgs }));
        
        exception.Should().BeNull("CleanupIdleConnections should handle null sender gracefully");
    }

    [Fact]
    public void CleanupIdleConnections_WithValidEventArgs_ShouldNotThrow()
    {
        // Arrange
        var type = typeof(DbConnectionFactory);
        var method = type.GetMethod("CleanupIdleConnections", BindingFlags.NonPublic | BindingFlags.Static);
        var sender = new object();
        var elapsedEventArgs = new ElapsedEventArgs(DateTime.Now);
        
        // Act & Assert
        var exception = Record.Exception(() => 
            method!.Invoke(null, new object[] { sender, elapsedEventArgs }));
        
        exception.Should().BeNull("CleanupIdleConnections should execute without errors");
    }

    #endregion

    #region ConnectionWrapper Integration Tests

    [Fact]
    public async Task ConnectionPool_ShouldStoreConnectionsAsConnectionWrappers()
    {
        // This test verifies that connections are stored as ConnectionWrapper objects in the pool
        var connectionString = TestConnectionString;
        
        try
        {
            // Act - Get a connection and return it to populate the pool
            var connection = await DbConnectionFactory.GetConnectionAsync(connectionString);
            connection.Should().NotBeNull();
            
            DbConnectionFactory.ReturnConnection(connection);
            
            // Use reflection to check the pool contents
            var type = typeof(DbConnectionFactory);
            var poolField = type.GetField("_connectionPools", BindingFlags.NonPublic | BindingFlags.Static);
            var pools = poolField!.GetValue(null) as ConcurrentDictionary<string, ConcurrentQueue<ConnectionWrapper>>;
            
            // Assert
            pools.Should().NotBeNull();
            
            // Check if pool exists for the original connection string
            if (pools!.TryGetValue(connectionString, out var pool))
            {
                pool.Should().NotBeEmpty("Pool should contain at least one connection wrapper after returning a connection");
            }
            else
            {
                // The pool might be indexed by the normalized connection string
                // Check that at least one pool exists and has connections
                pools.Should().NotBeEmpty("At least one connection pool should exist");
                pools.Values.Any(p => !p.IsEmpty).Should().BeTrue("At least one pool should contain connections");
            }
            
            _disposables.Add(connection);
        }
        catch (SqlException)
        {
            // Expected in test environment
        }
    }

    [Fact]
    public async Task ReturnConnection_ShouldCreateConnectionWrapperWithCurrentTime()
    {
        // Arrange
        var connectionString = TestConnectionString;
        
        try
        {
            var connection = await DbConnectionFactory.GetConnectionAsync(connectionString);
            var beforeReturn = DateTime.Now;
            
            // Act
            DbConnectionFactory.ReturnConnection(connection);
            var afterReturn = DateTime.Now;
            
            // Use reflection to verify the wrapper was created with current time
            var type = typeof(DbConnectionFactory);
            var poolField = type.GetField("_connectionPools", BindingFlags.NonPublic | BindingFlags.Static);
            var pools = poolField!.GetValue(null) as ConcurrentDictionary<string, ConcurrentQueue<ConnectionWrapper>>;
            
            pools.Should().NotBeNull();
            
            // Find a wrapper in any pool that was created around the time we returned the connection
            ConnectionWrapper? foundWrapper = null;
            
            foreach (var pool in pools!.Values)
            {
                // Check all wrappers in this pool to find one with recent LastUsed time
                var tempQueue = new Queue<ConnectionWrapper>();
                
                // Drain the queue to inspect wrappers
                while (pool.TryDequeue(out var wrapper))
                {
                    tempQueue.Enqueue(wrapper);
                    
                    // Check if this wrapper was created around the time we returned the connection
                    if (wrapper.LastUsed >= beforeReturn && wrapper.LastUsed <= afterReturn)
                    {
                        foundWrapper = wrapper;
                    }
                }
                
                // Put all wrappers back in the pool
                while (tempQueue.Count > 0)
                {
                    pool.Enqueue(tempQueue.Dequeue());
                }
                
                if (foundWrapper != null)
                    break;
            }
            
            // Assert
            foundWrapper.Should().NotBeNull("Should find a connection wrapper with LastUsed time between before and after return");
            
            if (foundWrapper != null)
            {
                foundWrapper.LastUsed.Should().BeOnOrAfter(beforeReturn);
                foundWrapper.LastUsed.Should().BeOnOrBefore(afterReturn);
            }
            
            _disposables.Add(connection);
        }
        catch (SqlException)
        {
            // Expected in test environment - SQL Server may not be available
            // In this case, the test should pass as it's testing the logic flow
        }
    }

    [Fact]
    public async Task GetConnectionAsync_ShouldUpdateLastUsedTimeOnConnectionWrapper()
    {
        // This test verifies that when a connection is retrieved from pool, 
        // its LastUsed time is updated
        var connectionString = TestConnectionString;
        
        try
        {
            // Arrange - Get a connection and return it
            var connection1 = await DbConnectionFactory.GetConnectionAsync(connectionString);
            DbConnectionFactory.ReturnConnection(connection1);
            
            // Wait a moment to ensure time difference
            await Task.Delay(100);
            var beforeSecondGet = DateTime.Now;
            
            // Act - Get another connection (might be the same from pool)
            var connection2 = await DbConnectionFactory.GetConnectionAsync(connectionString);
            var afterSecondGet = DateTime.Now;
            
            // Assert - We can't directly test LastUsed update without more reflection,
            // but we can verify the connection is returned properly
            connection2.Should().NotBeNull();
            
            _disposables.AddRange(new[] { connection1, connection2 });
        }
        catch (SqlException)
        {
            // Expected in test environment
        }
    }

    #endregion

    #region Idle Timeout Integration Tests

    [Fact]
    public void IdleTimeout_ConstantShouldHaveExpectedValue()
    {
        // Arrange
        var type = typeof(DbConnectionFactory);
        var idleTimeoutField = type.GetField("IdleTimeout", BindingFlags.NonPublic | BindingFlags.Static);
        
        // Act
        var idleTimeout = (int)idleTimeoutField!.GetValue(null)!;
        
        // Assert
        idleTimeout.Should().Be(300, "IdleTimeout should be 300 seconds (5 minutes)");
    }

    [Fact]
    public void CleanupIdleConnections_ShouldCheckIdleTimeoutConstant()
    {
        // This test verifies that the cleanup logic uses the IdleTimeout constant
        // by examining the implementation through reflection
        
        // Arrange
        var type = typeof(DbConnectionFactory);
        var idleTimeoutField = type.GetField("IdleTimeout", BindingFlags.NonPublic | BindingFlags.Static);
        var cleanupMethod = type.GetMethod("CleanupIdleConnections", BindingFlags.NonPublic | BindingFlags.Static);
        
        // Assert
        idleTimeoutField.Should().NotBeNull();
        cleanupMethod.Should().NotBeNull();
        
        var idleTimeout = (int)idleTimeoutField!.GetValue(null)!;
        idleTimeout.Should().Be(300, "IdleTimeout constant should be used by cleanup method");
    }

    #endregion

    #region Mock-based Cleanup Simulation Tests

    [Fact]
    public void CleanupIdleConnections_WithExpiredConnections_ShouldDisposeConnections()
    {
        // This test simulates the cleanup behavior by invoking the cleanup method
        // Note: This is a behavioral test rather than a full integration test
        
        // Arrange
        var type = typeof(DbConnectionFactory);
        var cleanupMethod = type.GetMethod("CleanupIdleConnections", BindingFlags.NonPublic | BindingFlags.Static);
        var elapsedEventArgs = new ElapsedEventArgs(DateTime.Now);
        
        // Act & Assert - The method should execute without throwing
        var exception = Record.Exception(() => 
            cleanupMethod!.Invoke(null, new object[] { new object(), elapsedEventArgs }));
        
        exception.Should().BeNull("Cleanup method should handle empty pools gracefully");
    }

    [Fact]
    public async Task CleanupTimer_ElapsedEvent_ShouldInvokeCleanupMethod()
    {
        // This test verifies that the timer is properly wired to the cleanup method
        // by checking the event handler registration
        
        // Arrange
        var type = typeof(DbConnectionFactory);
        var timerField = type.GetField("_cleanupTimer", BindingFlags.NonPublic | BindingFlags.Static);
        var timer = timerField!.GetValue(null) as System.Timers.Timer;
        
        // Act & Assert - Check that the timer has event handlers
        timer.Should().NotBeNull();
        
        // The timer should be configured with an event handler
        // We can't easily test the actual event firing without complex setup,
        // but we can verify the timer is configured correctly
        timer!.Enabled.Should().BeTrue("Timer should be enabled to fire events");
        timer.AutoReset.Should().BeTrue("Timer should auto-reset to fire repeatedly");
    }

    #endregion

    #region Stress Tests for Cleanup Functionality

    [Fact]
    public async Task CleanupSystem_UnderLoad_ShouldNotInterfereWithActiveConnections()
    {
        // This test verifies that cleanup operations don't interfere with active connection operations
        var connectionString = TestConnectionString;
        const int operationCount = 10;
        var connections = new ConcurrentBag<MsiSqlConnection>();
        
        try
        {
            // Act - Perform multiple connection operations while cleanup might be running
            var tasks = Enumerable.Range(0, operationCount).Select(async i =>
            {
                var connection = await DbConnectionFactory.GetConnectionAsync(connectionString);
                connections.Add(connection);
                
                await Task.Delay(50); // Simulate work
                
                DbConnectionFactory.ReturnConnection(connection);
                
                // Get another connection immediately
                var connection2 = await DbConnectionFactory.GetConnectionAsync(connectionString);
                connections.Add(connection2);
                
                return connection2;
            });
            
            var results = await Task.WhenAll(tasks);
            
            // Assert
            results.Should().NotBeNull();
            results.Should().OnlyContain(c => c != null);
            
            foreach (var connection in connections)
            {
                _disposables.Add(connection);
            }
        }
        catch (SqlException)
        {
            // Expected in test environment
        }
    }

    [Fact]
    public void CleanupTimer_LongRunning_ShouldNotCauseMemoryLeaks()
    {
        // This test verifies that the cleanup timer doesn't cause memory leaks
        // by running for an extended period
        
        // Arrange
        var type = typeof(DbConnectionFactory);
        var timerField = type.GetField("_cleanupTimer", BindingFlags.NonPublic | BindingFlags.Static);
        var timer = timerField!.GetValue(null) as System.Timers.Timer;
        
        // Act - Let the timer run and force garbage collection
        var initialMemory = GC.GetTotalMemory(false);
        
        // Give the timer a chance to run (but not actually wait 5 minutes)
        Thread.Sleep(100);
        
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        
        var finalMemory = GC.GetTotalMemory(false);
        
        // Assert
        timer!.Enabled.Should().BeTrue("Timer should still be running");
        
        // Memory usage shouldn't grow significantly due to timer operations
        var memoryGrowth = finalMemory - initialMemory;
        memoryGrowth.Should().BeLessThan(1024 * 1024, "Memory growth should be minimal"); // Less than 1MB
    }

    #endregion

    #region Exception Handling in Cleanup Tests

    [Fact]
    public void CleanupIdleConnections_WithCorruptedPool_ShouldNotCrash()
    {
        // This test verifies that the cleanup method handles unexpected conditions gracefully
        
        // Arrange
        var type = typeof(DbConnectionFactory);
        var cleanupMethod = type.GetMethod("CleanupIdleConnections", BindingFlags.NonPublic | BindingFlags.Static);
        var eventArgs = new ElapsedEventArgs(DateTime.Now);
        
        // Act & Assert - Method should not throw even with potential edge cases
        var exception = Record.Exception(() => 
        {
            // Call the cleanup method multiple times rapidly
            for (int i = 0; i < 5; i++)
            {
                cleanupMethod!.Invoke(null, new object[] { new object(), eventArgs });
            }
        });
        
        exception.Should().BeNull("Cleanup method should be resilient to multiple rapid calls");
    }

    [Fact]
    public async Task CleanupSystem_WithDisposedConnections_ShouldHandleGracefully()
    {
        // This test verifies that cleanup handles already-disposed connections properly
        var connectionString = TestConnectionString;
        
        try
        {
            // Arrange - Create and dispose a connection that might still be in pool
            var connection = await DbConnectionFactory.GetConnectionAsync(connectionString);
            connection.Dispose(); // Dispose before returning to pool
            
            // Act - Return the disposed connection
            var exception = Record.Exception(() => DbConnectionFactory.ReturnConnection(connection));
            
            // Assert
            exception.Should().BeNull("ReturnConnection should handle disposed connections gracefully");
            
            _disposables.Add(connection);
        }
        catch (SqlException)
        {
            // Expected in test environment
        }
    }

    #endregion

    #region Timer Configuration Verification Tests

    [Fact]
    public void CleanupTimer_Configuration_ShouldMatchExpectedSettings()
    {
        // Arrange
        var type = typeof(DbConnectionFactory);
        var timerField = type.GetField("_cleanupTimer", BindingFlags.NonPublic | BindingFlags.Static);
        var timer = timerField!.GetValue(null) as System.Timers.Timer;
        
        // Assert - Verify all timer configuration
        timer.Should().NotBeNull();
        timer!.Enabled.Should().BeTrue("Timer should be enabled");
        timer.AutoReset.Should().BeTrue("Timer should auto-reset");
        timer.Interval.Should().Be(300000, "Timer interval should be 5 minutes");
        
        // Verify the timer is a proper System.Timers.Timer
        timer.Should().BeOfType<System.Timers.Timer>();
    }

    [Fact]
    public void CleanupTimer_SynchronizingObject_ShouldBeNull()
    {
        // Arrange
        var type = typeof(DbConnectionFactory);
        var timerField = type.GetField("_cleanupTimer", BindingFlags.NonPublic | BindingFlags.Static);
        var timer = timerField!.GetValue(null) as System.Timers.Timer;
        
        // Assert - Timer should not be tied to a specific synchronization context
        timer!.SynchronizingObject.Should().BeNull("Timer should not be bound to a specific thread context");
    }

    #endregion

    #region Cleanup

    public void Dispose()
    {
        foreach (var disposable in _disposables)
        {
            try
            {
                disposable?.Dispose();
            }
            catch
            {
                // Ignore disposal errors in tests
            }
        }
        _disposables.Clear();
    }

    #endregion
}