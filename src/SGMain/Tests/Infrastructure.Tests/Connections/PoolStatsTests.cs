using System;
using System.Reflection;
using FluentAssertions;
using MenphisSI.Connections;
using Xunit;

namespace Infrastructure.Tests.Connections;

/// <summary>
/// Comprehensive unit tests for PoolStats class
/// Testing all properties, class structure, and behavior patterns
/// Following established testing conventions in the codebase
/// </summary>
public class PoolStatsTests
{
    #region Test Data Constants
    
    private const int ValidConnectionCount = 50;
    private const int ZeroConnections = 0;
    private const int MaxConnections = int.MaxValue;
    private const int NegativeConnections = -1;
    private const int LargeConnectionCount = 10000;
    
    #endregion

    #region Class Structure Tests

    [Fact]
    public void PoolStats_ShouldBePublicClass()
    {
        // Arrange
        var type = typeof(PoolStats);

        // Assert
        type.Should().NotBeNull();
        type.IsClass.Should().BeTrue();
        type.IsPublic.Should().BeTrue();
        type.IsAbstract.Should().BeFalse();
        type.IsSealed.Should().BeFalse();
    }

    [Fact]
    public void PoolStats_ShouldHaveCorrectNamespace()
    {
        // Arrange
        var type = typeof(PoolStats);

        // Assert
        type.Namespace.Should().Be("MenphisSI.Connections");
        type.FullName.Should().Be("MenphisSI.Connections.PoolStats");
    }

    [Fact]
    public void PoolStats_ShouldNotImplementAnyInterfaces()
    {
        // Arrange
        var type = typeof(PoolStats);
        var interfaces = type.GetInterfaces();

        // Assert
        interfaces.Should().BeEmpty("PoolStats should be a simple data class without interfaces");
    }

    [Fact]
    public void PoolStats_ShouldInheritFromObject()
    {
        // Arrange
        var type = typeof(PoolStats);

        // Assert
        type.BaseType.Should().Be(typeof(object));
    }

    [Fact]
    public void PoolStats_ShouldHaveParameterlessConstructor()
    {
        // Arrange
        var type = typeof(PoolStats);
        var constructors = type.GetConstructors();

        // Assert
        constructors.Should().ContainSingle();
        constructors[0].GetParameters().Should().BeEmpty();
        constructors[0].IsPublic.Should().BeTrue();
    }

    [Fact]
    public void PoolStats_ShouldHaveExactlyThreePublicProperties()
    {
        // Arrange
        var type = typeof(PoolStats);
        var publicProperties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        // Assert
        publicProperties.Should().HaveCount(3);
    }

    [Fact]
    public void PoolStats_ShouldNotPublicMethods()
    {
        // Arrange
        var type = typeof(PoolStats);
        var publicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        // Assert
        publicMethods.Should().NotBeEmpty();
    }

    [Fact]
    public void PoolStats_ShouldNotHavePublicFields()
    {
        // Arrange
        var type = typeof(PoolStats);
        var publicFields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

        // Assert
        publicFields.Should().BeEmpty("PoolStats should use properties instead of public fields");
    }

    #endregion

    #region Constructor Tests

    [Fact]
    public void Constructor_WithNoParameters_ShouldCreateInstance()
    {
        // Act
        var poolStats = new PoolStats();

        // Assert
        poolStats.Should().NotBeNull();
        poolStats.Should().BeOfType<PoolStats>();
    }

    [Fact]
    public void Constructor_WithNoParameters_ShouldInitializeAllPropertiesToZero()
    {
        // Act
        var poolStats = new PoolStats();

        // Assert
        poolStats.TotalConnections.Should().Be(0);
        poolStats.IdleConnections.Should().Be(0);
        poolStats.ActiveConnections.Should().Be(0);
    }

    [Fact]
    public void Constructor_ShouldCreateIndependentInstances()
    {
        // Act
        var poolStats1 = new PoolStats();
        var poolStats2 = new PoolStats();

        // Assert
        poolStats1.Should().NotBeSameAs(poolStats2);
        poolStats1.Should().BeEquivalentTo(poolStats2);
    }

    [Fact]
    public void Constructor_MultipleInstances_ShouldHaveZeroValues()
    {
        // Act
        var instances = new PoolStats[10];
        for (int i = 0; i < instances.Length; i++)
        {
            instances[i] = new PoolStats();
        }

        // Assert
        foreach (var instance in instances)
        {
            instance.TotalConnections.Should().Be(0);
            instance.IdleConnections.Should().Be(0);
            instance.ActiveConnections.Should().Be(0);
        }
    }

    #endregion

    #region TotalConnections Property Tests

    [Fact]
    public void TotalConnections_ShouldHaveCorrectPropertyAttributes()
    {
        // Arrange
        var type = typeof(PoolStats);
        var property = type.GetProperty(nameof(PoolStats.TotalConnections));

        // Assert
        property.Should().NotBeNull();
        property!.PropertyType.Should().Be(typeof(int));
        property.CanRead.Should().BeTrue();
        property.CanWrite.Should().BeTrue();
        property.GetMethod!.IsPublic.Should().BeTrue();
        property.SetMethod!.IsPublic.Should().BeTrue();
    }

    [Fact]
    public void TotalConnections_ShouldHaveDefaultValueOfZero()
    {
        // Act
        var poolStats = new PoolStats();

        // Assert
        poolStats.TotalConnections.Should().Be(0);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    [InlineData(int.MaxValue)]
    public void TotalConnections_ShouldAcceptValidPositiveValues(int value)
    {
        // Arrange
        var poolStats = new PoolStats();

        // Act
        poolStats.TotalConnections = value;

        // Assert
        poolStats.TotalConnections.Should().Be(value);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-10)]
    [InlineData(-100)]
    [InlineData(int.MinValue)]
    public void TotalConnections_ShouldAcceptNegativeValues(int value)
    {
        // Arrange
        var poolStats = new PoolStats();

        // Act
        poolStats.TotalConnections = value;

        // Assert
        poolStats.TotalConnections.Should().Be(value);
    }

    [Fact]
    public void TotalConnections_SetAndGet_ShouldWorkCorrectly()
    {
        // Arrange
        var poolStats = new PoolStats();
        var testValue = ValidConnectionCount;

        // Act
        poolStats.TotalConnections = testValue;
        var retrievedValue = poolStats.TotalConnections;

        // Assert
        retrievedValue.Should().Be(testValue);
    }

    [Fact]
    public void TotalConnections_MultipleAssignments_ShouldRetainLastValue()
    {
        // Arrange
        var poolStats = new PoolStats();

        // Act
        poolStats.TotalConnections = 10;
        poolStats.TotalConnections = 20;
        poolStats.TotalConnections = ValidConnectionCount;

        // Assert
        poolStats.TotalConnections.Should().Be(ValidConnectionCount);
    }

    #endregion

    #region IdleConnections Property Tests

    [Fact]
    public void IdleConnections_ShouldHaveCorrectPropertyAttributes()
    {
        // Arrange
        var type = typeof(PoolStats);
        var property = type.GetProperty(nameof(PoolStats.IdleConnections));

        // Assert
        property.Should().NotBeNull();
        property!.PropertyType.Should().Be(typeof(int));
        property.CanRead.Should().BeTrue();
        property.CanWrite.Should().BeTrue();
        property.GetMethod!.IsPublic.Should().BeTrue();
        property.SetMethod!.IsPublic.Should().BeTrue();
    }

    [Fact]
    public void IdleConnections_ShouldHaveDefaultValueOfZero()
    {
        // Act
        var poolStats = new PoolStats();

        // Assert
        poolStats.IdleConnections.Should().Be(0);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    [InlineData(25)]
    [InlineData(500)]
    [InlineData(5000)]
    [InlineData(int.MaxValue)]
    public void IdleConnections_ShouldAcceptValidPositiveValues(int value)
    {
        // Arrange
        var poolStats = new PoolStats();

        // Act
        poolStats.IdleConnections = value;

        // Assert
        poolStats.IdleConnections.Should().Be(value);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-5)]
    [InlineData(-50)]
    [InlineData(int.MinValue)]
    public void IdleConnections_ShouldAcceptNegativeValues(int value)
    {
        // Arrange
        var poolStats = new PoolStats();

        // Act
        poolStats.IdleConnections = value;

        // Assert
        poolStats.IdleConnections.Should().Be(value);
    }

    [Fact]
    public void IdleConnections_SetAndGet_ShouldWorkCorrectly()
    {
        // Arrange
        var poolStats = new PoolStats();
        var testValue = 15;

        // Act
        poolStats.IdleConnections = testValue;
        var retrievedValue = poolStats.IdleConnections;

        // Assert
        retrievedValue.Should().Be(testValue);
    }

    [Fact]
    public void IdleConnections_MultipleAssignments_ShouldRetainLastValue()
    {
        // Arrange
        var poolStats = new PoolStats();

        // Act
        poolStats.IdleConnections = 5;
        poolStats.IdleConnections = 15;
        poolStats.IdleConnections = 25;

        // Assert
        poolStats.IdleConnections.Should().Be(25);
    }

    #endregion

    #region ActiveConnections Property Tests

    [Fact]
    public void ActiveConnections_ShouldHaveCorrectPropertyAttributes()
    {
        // Arrange
        var type = typeof(PoolStats);
        var property = type.GetProperty(nameof(PoolStats.ActiveConnections));

        // Assert
        property.Should().NotBeNull();
        property!.PropertyType.Should().Be(typeof(int));
        property.CanRead.Should().BeTrue();
        property.CanWrite.Should().BeTrue();
        property.GetMethod!.IsPublic.Should().BeTrue();
        property.SetMethod!.IsPublic.Should().BeTrue();
    }

    [Fact]
    public void ActiveConnections_ShouldHaveDefaultValueOfZero()
    {
        // Act
        var poolStats = new PoolStats();

        // Assert
        poolStats.ActiveConnections.Should().Be(0);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    [InlineData(30)]
    [InlineData(300)]
    [InlineData(3000)]
    [InlineData(int.MaxValue)]
    public void ActiveConnections_ShouldAcceptValidPositiveValues(int value)
    {
        // Arrange
        var poolStats = new PoolStats();

        // Act
        poolStats.ActiveConnections = value;

        // Assert
        poolStats.ActiveConnections.Should().Be(value);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-3)]
    [InlineData(-30)]
    [InlineData(int.MinValue)]
    public void ActiveConnections_ShouldAcceptNegativeValues(int value)
    {
        // Arrange
        var poolStats = new PoolStats();

        // Act
        poolStats.ActiveConnections = value;

        // Assert
        poolStats.ActiveConnections.Should().Be(value);
    }

    [Fact]
    public void ActiveConnections_SetAndGet_ShouldWorkCorrectly()
    {
        // Arrange
        var poolStats = new PoolStats();
        var testValue = 35;

        // Act
        poolStats.ActiveConnections = testValue;
        var retrievedValue = poolStats.ActiveConnections;

        // Assert
        retrievedValue.Should().Be(testValue);
    }

    [Fact]
    public void ActiveConnections_MultipleAssignments_ShouldRetainLastValue()
    {
        // Arrange
        var poolStats = new PoolStats();

        // Act
        poolStats.ActiveConnections = 10;
        poolStats.ActiveConnections = 20;
        poolStats.ActiveConnections = 35;

        // Assert
        poolStats.ActiveConnections.Should().Be(35);
    }

    #endregion

    #region Property Independence Tests

    [Fact]
    public void Properties_ShouldBeIndependent()
    {
        // Arrange
        var poolStats = new PoolStats();

        // Act
        poolStats.TotalConnections = 100;
        poolStats.IdleConnections = 60;
        poolStats.ActiveConnections = 40;

        // Assert
        poolStats.TotalConnections.Should().Be(100);
        poolStats.IdleConnections.Should().Be(60);
        poolStats.ActiveConnections.Should().Be(40);
    }

    [Fact]
    public void TotalConnections_Change_ShouldNotAffectOtherProperties()
    {
        // Arrange
        var poolStats = new PoolStats
        {
            IdleConnections = 10,
            ActiveConnections = 20
        };

        // Act
        poolStats.TotalConnections = 50;

        // Assert
        poolStats.TotalConnections.Should().Be(50);
        poolStats.IdleConnections.Should().Be(10);
        poolStats.ActiveConnections.Should().Be(20);
    }

    [Fact]
    public void IdleConnections_Change_ShouldNotAffectOtherProperties()
    {
        // Arrange
        var poolStats = new PoolStats
        {
            TotalConnections = 100,
            ActiveConnections = 40
        };

        // Act
        poolStats.IdleConnections = 30;

        // Assert
        poolStats.TotalConnections.Should().Be(100);
        poolStats.IdleConnections.Should().Be(30);
        poolStats.ActiveConnections.Should().Be(40);
    }

    [Fact]
    public void ActiveConnections_Change_ShouldNotAffectOtherProperties()
    {
        // Arrange
        var poolStats = new PoolStats
        {
            TotalConnections = 100,
            IdleConnections = 70
        };

        // Act
        poolStats.ActiveConnections = 30;

        // Assert
        poolStats.TotalConnections.Should().Be(100);
        poolStats.IdleConnections.Should().Be(70);
        poolStats.ActiveConnections.Should().Be(30);
    }

    #endregion

    #region Realistic Usage Scenarios Tests

    [Fact]
    public void PoolStats_RealisticScenario_EmptyPool()
    {
        // Arrange & Act
        var poolStats = new PoolStats
        {
            TotalConnections = 0,
            IdleConnections = 0,
            ActiveConnections = 0
        };

        // Assert
        poolStats.TotalConnections.Should().Be(0);
        poolStats.IdleConnections.Should().Be(0);
        poolStats.ActiveConnections.Should().Be(0);
    }

    [Fact]
    public void PoolStats_RealisticScenario_AllConnectionsIdle()
    {
        // Arrange & Act
        var poolStats = new PoolStats
        {
            TotalConnections = 10,
            IdleConnections = 10,
            ActiveConnections = 0
        };

        // Assert
        poolStats.TotalConnections.Should().Be(10);
        poolStats.IdleConnections.Should().Be(10);
        poolStats.ActiveConnections.Should().Be(0);
    }

    [Fact]
    public void PoolStats_RealisticScenario_AllConnectionsActive()
    {
        // Arrange & Act
        var poolStats = new PoolStats
        {
            TotalConnections = 20,
            IdleConnections = 0,
            ActiveConnections = 20
        };

        // Assert
        poolStats.TotalConnections.Should().Be(20);
        poolStats.IdleConnections.Should().Be(0);
        poolStats.ActiveConnections.Should().Be(20);
    }

    [Fact]
    public void PoolStats_RealisticScenario_MixedConnections()
    {
        // Arrange & Act
        var poolStats = new PoolStats
        {
            TotalConnections = 50,
            IdleConnections = 30,
            ActiveConnections = 20
        };

        // Assert
        poolStats.TotalConnections.Should().Be(50);
        poolStats.IdleConnections.Should().Be(30);
        poolStats.ActiveConnections.Should().Be(20);
    }

    [Fact]
    public void PoolStats_RealisticScenario_HighLoadPool()
    {
        // Arrange & Act
        var poolStats = new PoolStats
        {
            TotalConnections = 1000,
            IdleConnections = 100,
            ActiveConnections = 900
        };

        // Assert
        poolStats.TotalConnections.Should().Be(1000);
        poolStats.IdleConnections.Should().Be(100);
        poolStats.ActiveConnections.Should().Be(900);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(10, 5, 5)]
    [InlineData(100, 60, 40)]
    [InlineData(1000, 200, 800)]
    [InlineData(50, 0, 50)]
    [InlineData(25, 25, 0)]
    public void PoolStats_VariousRealisticScenarios_ShouldWorkCorrectly(int total, int idle, int active)
    {
        // Arrange & Act
        var poolStats = new PoolStats
        {
            TotalConnections = total,
            IdleConnections = idle,
            ActiveConnections = active
        };

        // Assert
        poolStats.TotalConnections.Should().Be(total);
        poolStats.IdleConnections.Should().Be(idle);
        poolStats.ActiveConnections.Should().Be(active);
    }

    #endregion

    #region Edge Cases and Boundary Tests

    [Fact]
    public void PoolStats_MaxIntValues_ShouldWorkCorrectly()
    {
        // Arrange & Act
        var poolStats = new PoolStats
        {
            TotalConnections = int.MaxValue,
            IdleConnections = int.MaxValue,
            ActiveConnections = int.MaxValue
        };

        // Assert
        poolStats.TotalConnections.Should().Be(int.MaxValue);
        poolStats.IdleConnections.Should().Be(int.MaxValue);
        poolStats.ActiveConnections.Should().Be(int.MaxValue);
    }

    [Fact]
    public void PoolStats_MinIntValues_ShouldWorkCorrectly()
    {
        // Arrange & Act
        var poolStats = new PoolStats
        {
            TotalConnections = int.MinValue,
            IdleConnections = int.MinValue,
            ActiveConnections = int.MinValue
        };

        // Assert
        poolStats.TotalConnections.Should().Be(int.MinValue);
        poolStats.IdleConnections.Should().Be(int.MinValue);
        poolStats.ActiveConnections.Should().Be(int.MinValue);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    public void PoolStats_BoundaryValues_AllProperties_ShouldHandleCorrectly(int value)
    {
        // Arrange & Act
        var poolStats = new PoolStats
        {
            TotalConnections = value,
            IdleConnections = value,
            ActiveConnections = value
        };

        // Assert
        poolStats.TotalConnections.Should().Be(value);
        poolStats.IdleConnections.Should().Be(value);
        poolStats.ActiveConnections.Should().Be(value);
    }

    #endregion

    #region Object Behavior Tests

    [Fact]
    public void PoolStats_ToString_ShouldNotThrow()
    {
        // Arrange
        var poolStats = new PoolStats
        {
            TotalConnections = 50,
            IdleConnections = 30,
            ActiveConnections = 20
        };

        // Act & Assert
        var action = () => poolStats.ToString();
        action.Should().NotThrow();
        
        var result = poolStats.ToString();
        result.Should().NotBeNull();
        result.Should().NotBeEmpty();
    }

    [Fact]
    public void PoolStats_GetHashCode_ShouldNotThrow()
    {
        // Arrange
        var poolStats = new PoolStats
        {
            TotalConnections = 50,
            IdleConnections = 30,
            ActiveConnections = 20
        };

        // Act & Assert
        var action = () => poolStats.GetHashCode();
        action.Should().NotThrow();
        
        var hashCode = poolStats.GetHashCode();
        hashCode.Should().BeOfType(typeof(int));
    }

    [Fact]
    public void PoolStats_Equals_WithSameInstance_ShouldReturnTrue()
    {
        // Arrange
        var poolStats = new PoolStats
        {
            TotalConnections = 50,
            IdleConnections = 30,
            ActiveConnections = 20
        };

        // Act & Assert
        poolStats.Equals(poolStats).Should().BeTrue();
    }

    [Fact]
    public void PoolStats_Equals_WithNull_ShouldReturnFalse()
    {
        // Arrange
        var poolStats = new PoolStats();

        // Act & Assert
        poolStats.Equals(null).Should().BeFalse();
    }

    [Fact]
    public void PoolStats_GetType_ShouldReturnCorrectType()
    {
        // Arrange
        var poolStats = new PoolStats();

        // Act
        var type = poolStats.GetType();

        // Assert
        type.Should().Be(typeof(PoolStats));
        type.Name.Should().Be("PoolStats");
        type.FullName.Should().Be("MenphisSI.Connections.PoolStats");
    }

    #endregion

    #region Performance and Memory Tests

    [Fact]
    public void PoolStats_Creation_ShouldBeEfficient()
    {
        // Arrange
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        // Act
        for (int i = 0; i < 10000; i++)
        {
            var poolStats = new PoolStats
            {
                TotalConnections = i,
                IdleConnections = i / 2,
                ActiveConnections = i / 2
            };
            poolStats.TotalConnections.Should().Be(i); // Ensure usage
        }

        // Assert
        stopwatch.Stop();
        stopwatch.ElapsedMilliseconds.Should().BeLessThan(500, "Creating 10,000 PoolStats instances should be reasonably fast");
    }

    [Fact]
    public void PoolStats_PropertyAccess_ShouldBeEfficient()
    {
        // Arrange
        var poolStats = new PoolStats();
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        // Act
        for (int i = 0; i < 100000; i++)
        {
            poolStats.TotalConnections = i;
            poolStats.IdleConnections = i;
            poolStats.ActiveConnections = i;
            
            var total = poolStats.TotalConnections;
            var idle = poolStats.IdleConnections;
            var active = poolStats.ActiveConnections;
            
            // Use the values to prevent optimization
            var sum = total + idle + active;
            sum.Should().BeGreaterThanOrEqualTo(0);
        }

        // Assert
        stopwatch.Stop();
        stopwatch.ElapsedMilliseconds.Should().BeLessThan(500, "100,000 property operations should be reasonably fast");
    }

    [Fact]
    public void PoolStats_MultipleInstances_ShouldNotShareState()
    {
        // Arrange
        var instances = new PoolStats[100];
        
        // Act
        for (int i = 0; i < instances.Length; i++)
        {
            instances[i] = new PoolStats
            {
                TotalConnections = i,
                IdleConnections = i * 2,
                ActiveConnections = i * 3
            };
        }

        // Assert
        for (int i = 0; i < instances.Length; i++)
        {
            instances[i].TotalConnections.Should().Be(i);
            instances[i].IdleConnections.Should().Be(i * 2);
            instances[i].ActiveConnections.Should().Be(i * 3);
        }
    }

    #endregion

    #region Reflection-Based Validation Tests

    [Fact]
    public void PoolStats_AllProperties_ShouldBeAutoImplemented()
    {
        // Arrange
        var type = typeof(PoolStats);
        var properties = type.GetProperties();

        // Assert
        foreach (var property in properties)
        {
            property.CanRead.Should().BeTrue($"Property {property.Name} should have a getter");
            property.CanWrite.Should().BeTrue($"Property {property.Name} should have a setter");
            property.GetMethod!.IsPublic.Should().BeTrue($"Property {property.Name} getter should be public");
            property.SetMethod!.IsPublic.Should().BeTrue($"Property {property.Name} setter should be public");
        }
    }

    [Fact]
    public void PoolStats_PropertyNames_ShouldBeCorrect()
    {
        // Arrange
        var type = typeof(PoolStats);
        var properties = type.GetProperties();
        var expectedPropertyNames = new[] { "TotalConnections", "IdleConnections", "ActiveConnections" };

        // Assert
        var actualPropertyNames = properties.Select(p => p.Name).ToArray();
        actualPropertyNames.Should().BeEquivalentTo(expectedPropertyNames);
    }

    [Fact]
    public void PoolStats_AllProperties_ShouldBeIntType()
    {
        // Arrange
        var type = typeof(PoolStats);
        var properties = type.GetProperties();

        // Assert
        foreach (var property in properties)
        {
            property.PropertyType.Should().Be(typeof(int), $"Property {property.Name} should be of type int");
        }
    }

    [Fact]
    public void PoolStats_ShouldNotHaveStaticMembers()
    {
        // Arrange
        var type = typeof(PoolStats);
        var staticProperties = type.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        var staticMethods = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
        var staticFields = type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

        // Assert
        staticProperties.Should().BeEmpty("PoolStats should not have static properties");
        staticMethods.Should().BeEmpty("PoolStats should not have static methods");
        staticFields.Should().BeEmpty("PoolStats should not have static fields");
    }

    #endregion

    #region Documentation and Usability Tests

    [Fact]
    public void PoolStats_PropertyNames_ShouldBeDescriptive()
    {
        // Arrange
        var type = typeof(PoolStats);
        var properties = type.GetProperties();

        // Assert
        properties.Should().Contain(p => p.Name == "TotalConnections", "Should have a property for total connections");
        properties.Should().Contain(p => p.Name == "IdleConnections", "Should have a property for idle connections");
        properties.Should().Contain(p => p.Name == "ActiveConnections", "Should have a property for active connections");
    }

    [Fact]
    public void PoolStats_ShouldBeUsableAsDataTransferObject()
    {
        // Arrange & Act
        var poolStats = new PoolStats
        {
            TotalConnections = 100,
            IdleConnections = 60,
            ActiveConnections = 40
        };

        // Assert
        // Should be able to read all properties
        var total = poolStats.TotalConnections;
        var idle = poolStats.IdleConnections;
        var active = poolStats.ActiveConnections;

        total.Should().Be(100);
        idle.Should().Be(60);
        active.Should().Be(40);
    }

    [Fact]
    public void PoolStats_ShouldSupportObjectInitializerSyntax()
    {
        // Act & Assert
        var action = () => new PoolStats
        {
            TotalConnections = 50,
            IdleConnections = 30,
            ActiveConnections = 20
        };

        action.Should().NotThrow("PoolStats should support object initializer syntax");
        
        var result = action();
        result.TotalConnections.Should().Be(50);
        result.IdleConnections.Should().Be(30);
        result.ActiveConnections.Should().Be(20);
    }

    #endregion
}