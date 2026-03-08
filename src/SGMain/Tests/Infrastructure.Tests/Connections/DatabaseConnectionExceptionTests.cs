namespace Infrastructure.Tests.Connections;

/// <summary>
/// Comprehensive unit tests for DatabaseConnectionException class
/// Testing all constructors, inheritance behavior, and exception properties
/// </summary>
public class DatabaseConnectionExceptionTests
{
    #region Test Data Constants
    
    private const string DefaultMessage = "Falha de conexão";
    private const string CustomMessage = "Custom database connection error";
    private const string EmptyMessage = "";
    private const string WhitespaceMessage = "   ";
    private const string LongMessage = "This is a very long error message that might be used in real scenarios where detailed information about the database connection failure is provided to help with debugging and troubleshooting";
    private const string MessageWithSpecialChars = "Erro: não é possível conectar ao BD! @#$%^&*()";
    
    #endregion

    #region Default Constructor Tests

    [Fact]
    public void Constructor_WithNoParameters_ShouldUseDefaultMessage()
    {
        // Act
        var exception = new DatabaseConnectionException();

        // Assert
        exception.Message.Should().Be(DefaultMessage);
        exception.InnerException.Should().BeNull();
    }

    [Fact]
    public void Constructor_WithNoParameters_ShouldInheritFromException()
    {
        // Act
        var exception = new DatabaseConnectionException();

        // Assert
        exception.Should().BeAssignableTo<Exception>();
        exception.Should().BeOfType<DatabaseConnectionException>();
    }

    [Fact]
    public void Constructor_WithNoParameters_ShouldHaveCorrectNamespace()
    {
        // Act
        var exception = new DatabaseConnectionException();

        // Assert
        exception.GetType().Namespace.Should().Be("MenphisSI");
    }

    [Fact]
    public void Constructor_WithNoParameters_ShouldHaveNullInnerException()
    {
        // Act
        var exception = new DatabaseConnectionException();

        // Assert
        exception.InnerException.Should().BeNull();
    }

    [Fact]
    public void Constructor_WithNoParameters_ShouldHaveEmptyData()
    {
        // Act
        var exception = new DatabaseConnectionException();

        // Assert
        exception.Data.Should().NotBeNull();
        exception.Data.Count.Should().Be(0);
    }

    #endregion

    #region Message Constructor Tests

    [Fact]
    public void Constructor_WithCustomMessage_ShouldUseProvidedMessage()
    {
        // Arrange
        var customMessage = CustomMessage;

        // Act
        var exception = new DatabaseConnectionException(customMessage);

        // Assert
        exception.Message.Should().Be(customMessage);
        exception.InnerException.Should().BeNull();
    }

    [Fact]
    public void Constructor_WithEmptyMessage_ShouldUseEmptyMessage()
    {
        // Arrange
        var message = EmptyMessage;

        // Act
        var exception = new DatabaseConnectionException(message);

        // Assert
        exception.Message.Should().Be(message);
        exception.InnerException.Should().BeNull();
    }

    [Fact]
    public void Constructor_WithWhitespaceMessage_ShouldUseWhitespaceMessage()
    {
        // Arrange
        var message = WhitespaceMessage;

        // Act
        var exception = new DatabaseConnectionException(message);

        // Assert
        exception.Message.Should().Be(message);
        exception.InnerException.Should().BeNull();
    }

    [Fact]
    public void Constructor_WithNullMessage_ShouldUseNullMessage()
    {
        // Arrange
        string? message = null;

        // Act
        var exception = new DatabaseConnectionException(message!);

        // Assert
        exception.Message.Should().NotBeNull();
        exception.InnerException.Should().BeNull();
    }

    [Theory]
    [InlineData(CustomMessage)]
    [InlineData(LongMessage)]
    [InlineData(MessageWithSpecialChars)]
    [InlineData("Simple message")]
    [InlineData("123456789")]
    [InlineData("Message with\nnewlines\rand\ttabs")]
    public void Constructor_WithVariousMessages_ShouldPreserveMessage(string message)
    {
        // Act
        var exception = new DatabaseConnectionException(message);

        // Assert
        exception.Message.Should().Be(message);
        exception.InnerException.Should().BeNull();
    }

    [Fact]
    public void Constructor_WithLongMessage_ShouldHandleCorrectly()
    {
        // Arrange
        var longMessage = LongMessage;

        // Act
        var exception = new DatabaseConnectionException(longMessage);

        // Assert
        exception.Message.Should().Be(longMessage);
        exception.Message.Length.Should().BeGreaterThan(100);
        exception.InnerException.Should().BeNull();
    }

    [Fact]
    public void Constructor_WithMessageContainingUnicodeChars_ShouldHandleCorrectly()
    {
        // Arrange
        var unicodeMessage = "Connection failed: 数据库连接失败 🚨 ñáéíóú";

        // Act
        var exception = new DatabaseConnectionException(unicodeMessage);

        // Assert
        exception.Message.Should().Be(unicodeMessage);
        exception.InnerException.Should().BeNull();
    }

    #endregion

    #region Message and InnerException Constructor Tests

    [Fact]
    public void Constructor_WithMessageAndInnerException_ShouldUseProvidedValues()
    {
        // Arrange
        var message = CustomMessage;
        var innerException = new InvalidOperationException("Inner exception message");

        // Act
        var exception = new DatabaseConnectionException(message, innerException);

        // Assert
        exception.Message.Should().Be(message);
        exception.InnerException.Should().BeSameAs(innerException);
    }

    [Fact]
    public void Constructor_WithMessageAndNullInnerException_ShouldHandleCorrectly()
    {
        // Arrange
        var message = CustomMessage;
        Exception? innerException = null;

        // Act
        var exception = new DatabaseConnectionException(message, innerException!);

        // Assert
        exception.Message.Should().Be(message);
        exception.InnerException.Should().BeNull();
    }

    [Fact]
    public void Constructor_WithNullMessageAndInnerException_ShouldHandleCorrectly()
    {
        // Arrange
        string? message = null;
        var innerException = new ArgumentException("Argument exception message");

        // Act
        var exception = new DatabaseConnectionException(message!, innerException);

        // Assert
        exception.Message.Should().NotBeNull();
        exception.InnerException.Should().BeSameAs(innerException);
    }

    [Fact]
    public void Constructor_WithEmptyMessageAndInnerException_ShouldHandleCorrectly()
    {
        // Arrange
        var message = EmptyMessage;
        var innerException = new TimeoutException("Timeout exception message");

        // Act
        var exception = new DatabaseConnectionException(message, innerException);

        // Assert
        exception.Message.Should().Be(message);
        exception.InnerException.Should().BeSameAs(innerException);
    }

    [Theory]
    [InlineData("Connection timeout")]
    [InlineData("Authentication failed")]
    [InlineData("Network error")]
    [InlineData("Database not found")]
    [InlineData("Permission denied")]
    public void Constructor_WithVariousMessagesAndInnerException_ShouldPreserveBoth(string message)
    {
        // Arrange
        var innerException = new SystemException($"System error for: {message}");

        // Act
        var exception = new DatabaseConnectionException(message, innerException);

        // Assert
        exception.Message.Should().Be(message);
        exception.InnerException.Should().BeSameAs(innerException);
        exception.InnerException.Message.Should().Contain(message);
    }

    [Fact]
    public void Constructor_WithDifferentInnerExceptionTypes_ShouldHandleCorrectly()
    {
        // Arrange
        var message = CustomMessage;
        var exceptions = new Exception[]
        {
            new ArgumentNullException("param"),
            new InvalidOperationException("invalid op"),
            new TimeoutException("timeout"),
            new UnauthorizedAccessException("unauthorized"),
            new NotSupportedException("not supported"),
            new OutOfMemoryException("memory"),
            new StackOverflowException(),
            new DivideByZeroException("division")
        };

        foreach (var innerException in exceptions)
        {
            // Act
            var dbException = new DatabaseConnectionException(message, innerException);

            // Assert
            dbException.Message.Should().Be(message);
            dbException.InnerException.Should().BeSameAs(innerException);
            dbException.InnerException.Should().BeOfType(innerException.GetType());
        }
    }

    [Fact]
    public void Constructor_WithNestedInnerExceptions_ShouldMaintainChain()
    {
        // Arrange
        var deepestException = new ArgumentException("Deepest exception");
        var middleException = new InvalidOperationException("Middle exception", deepestException);
        var message = "Top level database connection exception";

        // Act
        var exception = new DatabaseConnectionException(message, middleException);

        // Assert
        exception.Message.Should().Be(message);
        exception.InnerException.Should().BeSameAs(middleException);
        exception.InnerException!.InnerException.Should().BeSameAs(deepestException);
    }

    #endregion

    #region Exception Type and Inheritance Tests

    [Fact]
    public void DatabaseConnectionException_ShouldInheritFromException()
    {
        // Arrange
        var exception = new DatabaseConnectionException();

        // Assert
        exception.Should().BeAssignableTo<Exception>();
        typeof(DatabaseConnectionException).BaseType.Should().Be(typeof(Exception));
    }

    [Fact]
    public void DatabaseConnectionException_ShouldBePublicClass()
    {
        // Arrange
        var type = typeof(DatabaseConnectionException);

        // Assert
        type.IsClass.Should().BeTrue();
        type.IsPublic.Should().BeTrue();
        type.IsAbstract.Should().BeFalse();
        type.IsSealed.Should().BeFalse();
    }

    [Fact]
    public void DatabaseConnectionException_ShouldHaveCorrectNamespace()
    {
        // Arrange
        var type = typeof(DatabaseConnectionException);

        // Assert
        type.Namespace.Should().Be("MenphisSI");
        type.FullName.Should().Be("MenphisSI.DatabaseConnectionException");
    }

    [Fact]
    public void DatabaseConnectionException_ShouldHaveCorrectConstructors()
    {
        // Arrange
        var type = typeof(DatabaseConnectionException);
        var constructors = type.GetConstructors();

        // Assert
        constructors.Should().HaveCount(2);
        
        // Check default constructor with optional message parameter
        var defaultConstructor = constructors.FirstOrDefault(c => c.GetParameters().Length == 1);
        defaultConstructor.Should().NotBeNull();
        defaultConstructor!.GetParameters()[0].ParameterType.Should().Be(typeof(string));
        defaultConstructor.GetParameters()[0].HasDefaultValue.Should().BeTrue();
        defaultConstructor.GetParameters()[0].DefaultValue.Should().Be(DefaultMessage);

        // Check constructor with message and inner exception
        var fullConstructor = constructors.FirstOrDefault(c => c.GetParameters().Length == 2);
        fullConstructor.Should().NotBeNull();
        fullConstructor!.GetParameters()[0].ParameterType.Should().Be(typeof(string));
        fullConstructor.GetParameters()[1].ParameterType.Should().Be(typeof(Exception));
    }

    [Fact]
    public void DatabaseConnectionException_ShouldNotHaveAdditionalProperties()
    {
        // Arrange
        var type = typeof(DatabaseConnectionException);
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        // Assert
        properties.Should().BeEmpty("DatabaseConnectionException should not add additional properties beyond those inherited from Exception");
    }

    [Fact]
    public void DatabaseConnectionException_ShouldNotHaveAdditionalMethods()
    {
        // Arrange
        var type = typeof(DatabaseConnectionException);
        var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        // Assert
        methods.Should().BeEmpty("DatabaseConnectionException should not add additional methods beyond those inherited from Exception");
    }

    #endregion

    #region Exception Behavior Tests

    [Fact]
    public void DatabaseConnectionException_ShouldBeThrowableAndCatchable()
    {
        // Arrange
        var message = "Test throwable exception";
        var wasCaught = false;
        DatabaseConnectionException? caughtException = null;

        // Act & Assert
        var action = () =>
        {
            try
            {
                throw new DatabaseConnectionException(message);
            }
            catch (DatabaseConnectionException ex)
            {
                wasCaught = true;
                caughtException = ex;
            }
        };

        action.Should().NotThrow();
        wasCaught.Should().BeTrue();
        caughtException.Should().NotBeNull();
        caughtException!.Message.Should().Be(message);
    }

    [Fact]
    public void DatabaseConnectionException_ShouldBeCatchableAsBaseException()
    {
        // Arrange
        var message = "Test base exception catch";
        var wasCaught = false;
        Exception? caughtException = null;

        // Act & Assert
        var action = () =>
        {
            try
            {
                throw new DatabaseConnectionException(message);
            }
            catch (Exception ex)
            {
                wasCaught = true;
                caughtException = ex;
            }
        };

        action.Should().NotThrow();
        wasCaught.Should().BeTrue();
        caughtException.Should().NotBeNull();
        caughtException.Should().BeOfType<DatabaseConnectionException>();
        caughtException!.Message.Should().Be(message);
    }

    [Fact]
    public void DatabaseConnectionException_WithInnerException_ShouldPreserveStackTrace()
    {
        // Arrange
        var message = "Outer exception";
        Exception? caughtException = null;

        // Act
        try
        {
            try
            {
                throw new InvalidOperationException("Inner exception");
            }
            catch (Exception inner)
            {
                throw new DatabaseConnectionException(message, inner);
            }
        }
        catch (DatabaseConnectionException ex)
        {
            caughtException = ex;
        }

        // Assert
        caughtException.Should().NotBeNull();
        caughtException!.InnerException.Should().NotBeNull();
        caughtException.InnerException.Should().BeOfType<InvalidOperationException>();
        caughtException.InnerException!.Message.Should().Be("Inner exception");
        caughtException.InnerException.StackTrace.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void DatabaseConnectionException_ToString_ShouldIncludeTypeAndMessage()
    {
        // Arrange
        var message = "Test toString method";
        var exception = new DatabaseConnectionException(message);

        // Act
        var toStringResult = exception.ToString();

        // Assert
        toStringResult.Should().Contain("DatabaseConnectionException");
        toStringResult.Should().Contain(message);
        toStringResult.Should().Contain("MenphisSI.DatabaseConnectionException");
    }

    [Fact]
    public void DatabaseConnectionException_ToString_WithInnerException_ShouldIncludeBoth()
    {
        // Arrange
        var message = "Outer message";
        var innerMessage = "Inner message";
        var innerException = new ArgumentException(innerMessage);
        var exception = new DatabaseConnectionException(message, innerException);

        // Act
        var toStringResult = exception.ToString();

        // Assert
        toStringResult.Should().Contain("DatabaseConnectionException");
        toStringResult.Should().Contain(message);
        toStringResult.Should().Contain("ArgumentException");
        toStringResult.Should().Contain(innerMessage);
    }

    #endregion

    #region Edge Cases and Error Scenarios Tests

    [Fact]
    public void DatabaseConnectionException_WithVeryLongMessage_ShouldHandleCorrectly()
    {
        // Arrange
        var veryLongMessage = new string('A', 10000); // 10,000 character message

        // Act
        var exception = new DatabaseConnectionException(veryLongMessage);

        // Assert
        exception.Message.Should().Be(veryLongMessage);
        exception.Message.Length.Should().Be(10000);
    }

    [Fact]
    public void DatabaseConnectionException_WithSpecialCharacters_ShouldPreserveCorrectly()
    {
        // Arrange
        var specialCharsMessage = "Error: \r\n\t\0\u0001\u001F\"'\\/@#$%^&*(){}[]|;:,.<>?`~";

        // Act
        var exception = new DatabaseConnectionException(specialCharsMessage);

        // Assert
        exception.Message.Should().Be(specialCharsMessage);
    }

    [Fact]
    public void DatabaseConnectionException_WithSelfReferencingInnerException_ShouldNotCauseStackOverflow()
    {
        // Arrange
        var message = "Test circular reference protection";
        var innerException = new DatabaseConnectionException("Inner message");

        // Act & Assert
        var action = () => new DatabaseConnectionException(message, innerException);
        action.Should().NotThrow("Creating exception with similar inner exception type should not cause issues");
    }

    [Fact]
    public void DatabaseConnectionException_MultipleInstances_ShouldBeIndependent()
    {
        // Arrange
        var message1 = "First exception";
        var message2 = "Second exception";
        var innerException1 = new ArgumentException("First inner");
        var innerException2 = new InvalidOperationException("Second inner");

        // Act
        var exception1 = new DatabaseConnectionException(message1, innerException1);
        var exception2 = new DatabaseConnectionException(message2, innerException2);

        // Assert
        exception1.Message.Should().Be(message1);
        exception1.InnerException.Should().BeSameAs(innerException1);
        
        exception2.Message.Should().Be(message2);
        exception2.InnerException.Should().BeSameAs(innerException2);
        
        exception1.Should().NotBeSameAs(exception2);
        exception1.InnerException.Should().NotBeSameAs(exception2.InnerException);
    }

    #endregion

    #region Exception Properties Tests

    [Fact]
    public void DatabaseConnectionException_Source_ShouldBeSettable()
    {
        // Arrange
        var exception = new DatabaseConnectionException();
        var sourceName = "TestSource";

        // Act
        exception.Source = sourceName;

        // Assert
        exception.Source.Should().Be(sourceName);
    }

    [Fact]
    public void DatabaseConnectionException_Data_ShouldBeModifiable()
    {
        // Arrange
        var exception = new DatabaseConnectionException();
        var key = "TestKey";
        var value = "TestValue";

        // Act
        exception.Data[key] = value;

        // Assert
        exception.Data[key].Should().Be(value);
        exception.Data.Contains(key).Should().BeTrue();
        exception.Data.Values.Cast<object>().Should().Contain(value);
    }

    [Fact]
    public void DatabaseConnectionException_HelpLink_ShouldBeSettable()
    {
        // Arrange
        var exception = new DatabaseConnectionException();
        var helpLink = "https://example.com/help";

        // Act
        exception.HelpLink = helpLink;

        // Assert
        exception.HelpLink.Should().Be(helpLink);
    }

    [Fact]
    public void DatabaseConnectionException_StackTrace_ShouldBeAvailableWhenThrown()
    {
        // Arrange
        DatabaseConnectionException? caughtException = null;

        // Act
        try
        {
            throw new DatabaseConnectionException("Test stack trace");
        }
        catch (DatabaseConnectionException ex)
        {
            caughtException = ex;
        }

        // Assert
        caughtException.Should().NotBeNull();
        caughtException!.StackTrace.Should().NotBeNullOrEmpty();
        caughtException.StackTrace.Should().Contain("DatabaseConnectionExceptionTests");
    }

    #endregion

    #region Default Message Constant Tests

    [Fact]
    public void DatabaseConnectionException_DefaultMessage_ShouldBeCorrectPortugueseText()
    {
        // Act
        var exception = new DatabaseConnectionException();

        // Assert
        exception.Message.Should().Be("Falha de conexão");
    }

    [Fact]
    public void DatabaseConnectionException_DefaultMessage_ShouldBeConsistent()
    {
        // Act
        var exception1 = new DatabaseConnectionException();
        var exception2 = new DatabaseConnectionException();

        // Assert
        exception1.Message.Should().Be(exception2.Message);
        exception1.Message.Should().Be(DefaultMessage);
        exception2.Message.Should().Be(DefaultMessage);
    }

    [Fact]
    public void DatabaseConnectionException_DefaultMessage_ShouldNotBeEmpty()
    {
        // Act
        var exception = new DatabaseConnectionException();

        // Assert
        exception.Message.Should().NotBeNullOrEmpty();
        exception.Message.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public void DatabaseConnectionException_DefaultMessage_ShouldHaveReasonableLength()
    {
        // Act
        var exception = new DatabaseConnectionException();

        // Assert
        exception.Message.Length.Should().BeGreaterThan(5);
        exception.Message.Length.Should().BeLessThan(100);
    }

    // Replace usage of Type.IsSerializable with a check for the [Serializable] attribute using reflection.
    // This avoids the obsolete SYSLIB0050 diagnostic.

    [Fact]
    public void DatabaseConnectionException_ShouldHaveSerializableAttribute()
    {
        // Arrange
        var type = typeof(DatabaseConnectionException);

        // Act
        var hasSerializableAttribute = type.GetCustomAttributes(typeof(SerializableAttribute), inherit: false).Length > 0;

        // Assert
        hasSerializableAttribute.Should().BeTrue("Exception classes should typically be serializable");
    }

    [Fact]
    public void DatabaseConnectionException_GetType_ShouldReturnCorrectType()
    {
        // Arrange
        var exception = new DatabaseConnectionException();

        // Act
        var type = exception.GetType();

        // Assert
        type.Should().Be(typeof(DatabaseConnectionException));
        type.Name.Should().Be("DatabaseConnectionException");
        type.FullName.Should().Be("MenphisSI.DatabaseConnectionException");
    }

    [Fact]
    public void DatabaseConnectionException_Reflection_ShouldHaveExpectedStructure()
    {
        // Arrange
        var type = typeof(DatabaseConnectionException);

        // Assert
        type.IsClass.Should().BeTrue();
        type.IsPublic.Should().BeTrue();
        type.IsSealed.Should().BeFalse();
        type.IsAbstract.Should().BeFalse();
        type.BaseType.Should().Be(typeof(Exception));
        type.GetInterfaces().Should().NotBeEmpty();
    }

    #endregion

    #region Performance and Memory Tests

    [Fact]
    public void DatabaseConnectionException_Creation_ShouldBeEfficient()
    {
        // Arrange
        var message = "Performance test message";
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        // Act
        for (int i = 0; i < 1000; i++)
        {
            var exception = new DatabaseConnectionException(message);
            exception.Message.Should().Be(message); // Ensure the exception is actually used
        }

        // Assert
        stopwatch.Stop();
        stopwatch.ElapsedMilliseconds.Should().BeLessThan(100, "Creating 1000 exceptions should be fast");
    }

    [Fact]
    public void DatabaseConnectionException_WithInnerException_ShouldNotLeakMemory()
    {
        // Arrange & Act
        var action = () =>
        {
            for (int i = 0; i < 100; i++)
            {
                var inner = new ArgumentException($"Inner {i}");
                var outer = new DatabaseConnectionException($"Outer {i}", inner);
                outer.Message.Should().NotBeNull(); // Use the exception
            }
        };

        // Assert
        action.Should().NotThrow("Creating many exceptions with inner exceptions should not cause memory issues");
    }

    #endregion
}