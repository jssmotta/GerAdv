namespace SourceGenesys.Domain.Tests.DevourerApi.TSqlTests;

/// <summary>
/// Comprehensive unit tests for TSqlCmd class
/// </summary>
public class TSqlCmdTests
{
    #region Constructor Tests

    [Fact]
    public void Constructor_Default_ShouldInitializeWithEmptyValues()
    {
        // Act
        var cmd = new TSqlCmd();

        // Assert
        cmd.Nome.Should().Be("");
        cmd.Value.Should().Be("");
        cmd.Type.Should().Be(default(SqlDbType));
    }

    [Fact]
    public void Constructor_Default_ShouldCreateValidInstance()
    {
        // Act
        var cmd = new TSqlCmd();

        // Assert
        cmd.Should().NotBeNull();
        cmd.Should().BeOfType<TSqlCmd>();
    }

    #endregion

    #region Property Assignment Tests

    [Theory]
    [InlineData("@UserId")]
    [InlineData("@UserName")]
    [InlineData("@Email")]
    [InlineData("@param1")]
    [InlineData("")]
    public void Nome_SetValue_ShouldStoreCorrectly(string parameterName)
    {
        // Arrange
        var cmd = new TSqlCmd();

        // Act
        cmd.Nome = parameterName;

        // Assert
        cmd.Nome.Should().Be(parameterName);
    }

    [Theory]
    [InlineData("John Doe")]
    [InlineData("")]
    [InlineData("test@example.com")]
    [InlineData("12345")]
    public void Value_SetStringValue_ShouldStoreCorrectly(string value)
    {
        // Arrange
        var cmd = new TSqlCmd();

        // Act
        cmd.Value = value;

        // Assert
        cmd.Value.Should().Be(value);
        cmd.Value.Should().BeOfType<string>();
    }

    [Theory]
    [InlineData(123)]
    [InlineData(0)]
    [InlineData(-456)]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    public void Value_SetIntValue_ShouldStoreCorrectly(int value)
    {
        // Arrange
        var cmd = new TSqlCmd();

        // Act
        cmd.Value = value;

        // Assert
        cmd.Value.Should().Be(value);
        cmd.Value.Should().BeOfType<int>();
    }

    [Theory]
    [InlineData(123.45)]
    [InlineData(0.0)]
    [InlineData(-456.78)]
    [InlineData(double.MaxValue)]
    [InlineData(double.MinValue)]
    public void Value_SetDoubleValue_ShouldStoreCorrectly(double value)
    {
        // Arrange
        var cmd = new TSqlCmd();

        // Act
        cmd.Value = value;

        // Assert
        cmd.Value.Should().Be(value);
        cmd.Value.Should().BeOfType<double>();
    }

    [Fact]
    public void Value_SetDateTimeValue_ShouldStoreCorrectly()
    {
        // Arrange
        var cmd = new TSqlCmd();
        var dateTime = new DateTime(2023, 12, 25, 10, 30, 45);

        // Act
        cmd.Value = dateTime;

        // Assert
        cmd.Value.Should().Be(dateTime);
        cmd.Value.Should().BeOfType<DateTime>();
    }

    [Fact]
    public void Value_SetBooleanValue_ShouldStoreCorrectly()
    {
        // Arrange
        var cmd = new TSqlCmd();

        // Act
        cmd.Value = true;

        // Assert
        cmd.Value.Should().Be(true);
        cmd.Value.Should().BeOfType<bool>();
    }

    [Fact]
    public void Value_SetNullValue_ShouldStoreCorrectly()
    {
        // Arrange
        var cmd = new TSqlCmd
        {
            // Act
            Value = null
        };

        // Assert
        cmd.Value.Should().BeNull();
    }

    [Theory]
    [InlineData(SqlDbType.VarChar)]
    [InlineData(SqlDbType.Int)]
    [InlineData(SqlDbType.DateTime)]
    [InlineData(SqlDbType.Bit)]
    [InlineData(SqlDbType.Decimal)]
    [InlineData(SqlDbType.UniqueIdentifier)]
    [InlineData(SqlDbType.Text)]
    [InlineData(SqlDbType.BigInt)]
    public void Type_SetSqlDbType_ShouldStoreCorrectly(SqlDbType sqlType)
    {
        // Arrange
        var cmd = new TSqlCmd();

        // Act
        cmd.Type = sqlType;

        // Assert
        cmd.Type.Should().Be(sqlType);
    }

    #endregion

    #region Complex Object Assignment Tests

    [Fact]
    public void Value_SetGuidValue_ShouldStoreCorrectly()
    {
        // Arrange
        var cmd = new TSqlCmd();
        var guidValue = Guid.NewGuid();

        // Act
        cmd.Value = guidValue;

        // Assert
        cmd.Value.Should().Be(guidValue);
        cmd.Value.Should().BeOfType<Guid>();
    }

    [Fact]
    public void Value_SetDecimalValue_ShouldStoreCorrectly()
    {
        // Arrange
        var cmd = new TSqlCmd();
        var decimalValue = 123.456m;

        // Act
        cmd.Value = decimalValue;

        // Assert
        cmd.Value.Should().Be(decimalValue);
        cmd.Value.Should().BeOfType<decimal>();
    }

    [Fact]
    public void Value_SetByteArrayValue_ShouldStoreCorrectly()
    {
        // Arrange
        var cmd = new TSqlCmd();
        var byteArray = new byte[] { 1, 2, 3, 4, 5 };

        // Act
        cmd.Value = byteArray;

        // Assert
        cmd.Value.Should().Be(byteArray);
        cmd.Value.Should().BeOfType<byte[]>();
    }

    #endregion

    #region Realistic SQL Parameter Scenarios

    [Fact]
    public void TSqlCmd_ConfigureForUserIdParameter_ShouldSetupCorrectly()
    {
        // Arrange
        var cmd = new TSqlCmd();

        // Act
        cmd.Nome = "@UserId";
        cmd.Type = SqlDbType.Int;
        cmd.Value = 12345;

        // Assert
        cmd.Nome.Should().Be("@UserId");
        cmd.Type.Should().Be(SqlDbType.Int);
        cmd.Value.Should().Be(12345);
    }

    [Fact]
    public void TSqlCmd_ConfigureForUserNameParameter_ShouldSetupCorrectly()
    {
        // Arrange
        var cmd = new TSqlCmd();

        // Act
        cmd.Nome = "@UserName";
        cmd.Type = SqlDbType.VarChar;
        cmd.Value = "John Doe";

        // Assert
        cmd.Nome.Should().Be("@UserName");
        cmd.Type.Should().Be(SqlDbType.VarChar);
        cmd.Value.Should().Be("John Doe");
    }

    [Fact]
    public void TSqlCmd_ConfigureForDateParameter_ShouldSetupCorrectly()
    {
        // Arrange
        var cmd = new TSqlCmd();
        var testDate = new DateTime(2023, 12, 25);

        // Act
        cmd.Nome = "@CreatedDate";
        cmd.Type = SqlDbType.DateTime;
        cmd.Value = testDate;

        // Assert
        cmd.Nome.Should().Be("@CreatedDate");
        cmd.Type.Should().Be(SqlDbType.DateTime);
        cmd.Value.Should().Be(testDate);
    }

    [Fact]
    public void TSqlCmd_ConfigureForBooleanParameter_ShouldSetupCorrectly()
    {
        // Arrange
        var cmd = new TSqlCmd();

        // Act
        cmd.Nome = "@IsActive";
        cmd.Type = SqlDbType.Bit;
        cmd.Value = true;

        // Assert
        cmd.Nome.Should().Be("@IsActive");
        cmd.Type.Should().Be(SqlDbType.Bit);
        cmd.Value.Should().Be(true);
    }

    [Fact]
    public void TSqlCmd_ConfigureForDecimalParameter_ShouldSetupCorrectly()
    {
        // Arrange
        var cmd = new TSqlCmd();

        // Act
        cmd.Nome = "@Price";
        cmd.Type = SqlDbType.Decimal;
        cmd.Value = 99.99m;

        // Assert
        cmd.Nome.Should().Be("@Price");
        cmd.Type.Should().Be(SqlDbType.Decimal);
        cmd.Value.Should().Be(99.99m);
    }

    [Fact]
    public void TSqlCmd_ConfigureForGuidParameter_ShouldSetupCorrectly()
    {
        // Arrange
        var cmd = new TSqlCmd();
        var testGuid = Guid.NewGuid();

        // Act
        cmd.Nome = "@UniqueId";
        cmd.Type = SqlDbType.UniqueIdentifier;
        cmd.Value = testGuid;

        // Assert
        cmd.Nome.Should().Be("@UniqueId");
        cmd.Type.Should().Be(SqlDbType.UniqueIdentifier);
        cmd.Value.Should().Be(testGuid);
    }

    #endregion

    #region Class Structure Tests

    [Fact]
    public void TSqlCmd_ShouldBeSerializable()
    {
        // Arrange & Act
        var type = typeof(TSqlCmd);

        // Assert
        type.Should().BeDecoratedWith<System.SerializableAttribute>();
    }

    [Fact]
    public void TSqlCmd_ShouldBePublicClass()
    {
        // Arrange & Act
        var type = typeof(TSqlCmd);

        // Assert
        type.Should().NotBeNull();
        type.IsClass.Should().BeTrue();
        type.IsPublic.Should().BeTrue();
        type.IsSealed.Should().BeFalse(); // Should be inheritable if needed
        type.IsAbstract.Should().BeFalse();
    }

    [Fact]
    public void TSqlCmd_ShouldHaveParameterlessConstructor()
    {
        // Arrange & Act
        var constructors = typeof(TSqlCmd).GetConstructors();
        var parameterlessConstructor = constructors.FirstOrDefault(c => c.GetParameters().Length == 0);

        // Assert
        parameterlessConstructor.Should().NotBeNull();
        parameterlessConstructor!.IsPublic.Should().BeTrue();
    }

    [Fact]
    public void TSqlCmd_ShouldHaveExpectedPublicFields()
    {
        // Arrange
        var type = typeof(TSqlCmd);

        // Act
        var fields = type.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

        // Assert
        fields.Should().HaveCount(3);
        fields.Should().Contain(f => f.Name == "Nome" && f.FieldType == typeof(string));
        fields.Should().Contain(f => f.Name == "Type" && f.FieldType == typeof(SqlDbType));
        fields.Should().Contain(f => f.Name == "Value" && f.FieldType == typeof(object));
    }

    [Fact]
    public void TSqlCmd_Fields_ShouldBePublicAndNotReadonly()
    {
        // Arrange
        var type = typeof(TSqlCmd);

        // Act
        var nomeField = type.GetField("Nome");
        var typeField = type.GetField("Type");
        var valueField = type.GetField("Value");

        // Assert
        nomeField.Should().NotBeNull();
        nomeField!.IsPublic.Should().BeTrue();
        nomeField.IsInitOnly.Should().BeFalse();

        typeField.Should().NotBeNull();
        typeField!.IsPublic.Should().BeTrue();
        typeField.IsInitOnly.Should().BeFalse();

        valueField.Should().NotBeNull();
        valueField!.IsPublic.Should().BeTrue();
        valueField.IsInitOnly.Should().BeFalse();
    }

    #endregion

    #region Edge Cases and Error Scenarios

    [Theory]
    [InlineData(null)]
    public void Nome_SetNullValue_ShouldAllowNull(string? value)
    {
        // Arrange
        var cmd = new TSqlCmd();

        // Act
        cmd.Nome = value!;

        // Assert
        cmd.Nome.Should().BeNull();
    }

    [Fact]
    public void TSqlCmd_MultipleInstances_ShouldBeIndependent()
    {
        // Arrange
        var cmd1 = new TSqlCmd();
        var cmd2 = new TSqlCmd();

        // Act
        cmd1.Nome = "@Param1";
        cmd1.Value = "Value1";
        cmd1.Type = SqlDbType.VarChar;

        cmd2.Nome = "@Param2";
        cmd2.Value = 123;
        cmd2.Type = SqlDbType.Int;

        // Assert
        cmd1.Nome.Should().Be("@Param1");
        cmd1.Value.Should().Be("Value1");
        cmd1.Type.Should().Be(SqlDbType.VarChar);

        cmd2.Nome.Should().Be("@Param2");
        cmd2.Value.Should().Be(123);
        cmd2.Type.Should().Be(SqlDbType.Int);

        // Verify they are independent
        cmd1.Nome.Should().NotBe(cmd2.Nome);
        cmd1.Value.Should().NotBe(cmd2.Value);
        cmd1.Type.Should().NotBe(cmd2.Type);
    }

    #endregion

    #region Type Compatibility Tests

    [Fact]
    public void TSqlCmd_WithVarCharType_ShouldAcceptStringValue()
    {
        // Arrange
        var cmd = new TSqlCmd();

        // Act
        cmd.Type = SqlDbType.VarChar;
        cmd.Value = "Test String";

        // Assert
        cmd.Type.Should().Be(SqlDbType.VarChar);
        cmd.Value.Should().BeOfType<string>();
    }

    [Fact]
    public void TSqlCmd_WithIntType_ShouldAcceptIntValue()
    {
        // Arrange
        var cmd = new TSqlCmd();

        // Act
        cmd.Type = SqlDbType.Int;
        cmd.Value = 42;

        // Assert
        cmd.Type.Should().Be(SqlDbType.Int);
        cmd.Value.Should().BeOfType<int>();
    }

    [Fact]
    public void TSqlCmd_WithBitType_ShouldAcceptBoolValue()
    {
        // Arrange
        var cmd = new TSqlCmd();

        // Act
        cmd.Type = SqlDbType.Bit;
        cmd.Value = false;

        // Assert
        cmd.Type.Should().Be(SqlDbType.Bit);
        cmd.Value.Should().BeOfType<bool>();
    }

    [Fact]
    public void TSqlCmd_WithDateTimeType_ShouldAcceptDateTimeValue()
    {
        // Arrange
        var cmd = new TSqlCmd();
        var testDateTime = DateTime.Now;

        // Act
        cmd.Type = SqlDbType.DateTime;
        cmd.Value = testDateTime;

        // Assert
        cmd.Type.Should().Be(SqlDbType.DateTime);
        cmd.Value.Should().BeOfType<DateTime>();
        cmd.Value.Should().Be(testDateTime);
    }

    #endregion

    #region Real-world Usage Scenarios

    [Fact]
    public void TSqlCmd_CreateParameterForStoredProcedure_ShouldConfigureCorrectly()
    {
        // Simulate creating a parameter for a stored procedure call
        // Arrange
        var userIdParam = new TSqlCmd();

        // Act
        userIdParam.Nome = "@UserID";
        userIdParam.Type = SqlDbType.Int;
        userIdParam.Value = 1001;

        // Assert
        userIdParam.Nome.Should().Be("@UserID");
        userIdParam.Type.Should().Be(SqlDbType.Int);
        userIdParam.Value.Should().Be(1001);
    }

    [Fact]
    public void TSqlCmd_CreateParameterForSearch_ShouldConfigureCorrectly()
    {
        // Simulate creating a parameter for a search query
        // Arrange
        var searchParam = new TSqlCmd();

        // Act
        searchParam.Nome = "@SearchTerm";
        searchParam.Type = SqlDbType.NVarChar;
        searchParam.Value = "%john%";

        // Assert
        searchParam.Nome.Should().Be("@SearchTerm");
        searchParam.Type.Should().Be(SqlDbType.NVarChar);
        searchParam.Value.Should().Be("%john%");
    }

    [Fact]
    public void TSqlCmd_CreateParameterForDateRange_ShouldConfigureCorrectly()
    {
        // Simulate creating parameters for a date range query
        // Arrange
        var startDateParam = new TSqlCmd();
        var endDateParam = new TSqlCmd();
        var startDate = new DateTime(2023, 1, 1);
        var endDate = new DateTime(2023, 12, 31);

        // Act
        startDateParam.Nome = "@StartDate";
        startDateParam.Type = SqlDbType.DateTime;
        startDateParam.Value = startDate;

        endDateParam.Nome = "@EndDate";
        endDateParam.Type = SqlDbType.DateTime;
        endDateParam.Value = endDate;

        // Assert
        startDateParam.Nome.Should().Be("@StartDate");
        startDateParam.Type.Should().Be(SqlDbType.DateTime);
        startDateParam.Value.Should().Be(startDate);

        endDateParam.Nome.Should().Be("@EndDate");
        endDateParam.Type.Should().Be(SqlDbType.DateTime);
        endDateParam.Value.Should().Be(endDate);
    }

    #endregion

    #region Collection Usage Tests

    [Fact]
    public void TSqlCmd_InCollection_ShouldWorkCorrectly()
    {
        // Arrange
        var parameters = new List<TSqlCmd>();

        // Act
        parameters.Add(new TSqlCmd { Nome = "@Param1", Type = SqlDbType.Int, Value = 1 });
        parameters.Add(new TSqlCmd { Nome = "@Param2", Type = SqlDbType.VarChar, Value = "Test" });
        parameters.Add(new TSqlCmd { Nome = "@Param3", Type = SqlDbType.Bit, Value = true });

        // Assert
        parameters.Should().HaveCount(3);
        
        parameters[0].Nome.Should().Be("@Param1");
        parameters[0].Type.Should().Be(SqlDbType.Int);
        parameters[0].Value.Should().Be(1);

        parameters[1].Nome.Should().Be("@Param2");
        parameters[1].Type.Should().Be(SqlDbType.VarChar);
        parameters[1].Value.Should().Be("Test");

        parameters[2].Nome.Should().Be("@Param3");
        parameters[2].Type.Should().Be(SqlDbType.Bit);
        parameters[2].Value.Should().Be(true);
    }

    [Fact]
    public void TSqlCmd_InArray_ShouldWorkCorrectly()
    {
        // Arrange & Act
        var parameters = new TSqlCmd[]
        {
            new() { Nome = "@ID", Type = SqlDbType.Int, Value = 123 },
            new() { Nome = "@Name", Type = SqlDbType.VarChar, Value = "Test Name" }
        };

        // Assert
        parameters.Should().HaveCount(2);
        parameters[0].Nome.Should().Be("@ID");
        parameters[1].Nome.Should().Be("@Name");
    }

    #endregion
}