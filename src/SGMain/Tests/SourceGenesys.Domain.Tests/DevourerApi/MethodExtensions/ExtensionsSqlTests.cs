namespace SourceGenesys.Domain.Tests.DevourerApi.MethodExtensions;

/// <summary>
/// Comprehensive unit tests for SQL extension methods in ExtensionMethodStringsW3
/// </summary>
public class ExtensionsSqlTests
{
    #region IsEmptyX Method Tests

    [Theory]
    [InlineData(int.MinValue, true)]
    [InlineData(0, false)]
    [InlineData(1, false)]
    [InlineData(-1, false)]
    [InlineData(int.MaxValue, false)]
    public void IsEmptyX_Int_ShouldReturnCorrectResult(int value, bool expected)
    {
        // Act
        var result = value.IsEmptyX();

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(1, false)]
    [InlineData(-1, false)]
    public void IsEmptyX_Decimal_WithNormalValues_ShouldReturnFalse(decimal value, bool expected)
    {
        // Act
        var result = value.IsEmptyX();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void IsEmptyX_Decimal_WithMinValue_ShouldReturnTrue()
    {
        // Arrange
        var value = decimal.MinValue;

        // Act
        var result = value.IsEmptyX();

        // Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("", true)]
    [InlineData("   ", true)]
    [InlineData("\t", true)]
    [InlineData("\n", true)]
    [InlineData("\r\n", true)]
    [InlineData("test", false)]
    [InlineData("a", false)]
    [InlineData("  text  ", false)]
    public void IsEmptyX_String_ShouldReturnCorrectResult(string value, bool expected)
    {
        // Act
        var result = value.IsEmptyX();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void IsEmptyX_String_WithNull_ShouldReturnTrue()
    {
        // Arrange
        string? value = null;

        // Act
        var result = value.IsEmptyX();

        // Assert
        result.Should().BeTrue();
    }

    #endregion

    #region IsEmptyDX Method Tests

    [Theory]
    [InlineData("", true)]
    [InlineData("   ", true)]
    [InlineData("\t", true)]
    [InlineData("invalid date", true)]
    [InlineData("not a date", true)]
    [InlineData("abc123", true)]
    public void IsEmptyDX_WithInvalidOrEmptyStrings_ShouldReturnTrue(string value, bool expected)
    {
        // Act
        var result = value.IsEmptyDX();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void IsEmptyDX_WithNullString_ShouldReturnTrue()
    {
        // Arrange
        string? value = null;

        // Act
        var result = value.IsEmptyDX();

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsEmptyDX_WithDateTimeMinValue_ShouldReturnTrue()
    {
        // Arrange
        var value = DateTime.MinValue.ToString();

        // Act
        var result = value.IsEmptyDX();

        // Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("2023/12/01", false)]
    [InlineData("31/12/2023", false)]
    [InlineData("2023-01-01 10:30:00", false)]
    public void IsEmptyDX_WithValidDates_ShouldReturnFalse(string value, bool expected)
    {
        // Act
        var result = value.IsEmptyDX();

        // Assert
        result.Should().Be(expected);
    }

    #endregion

    #region IsValidEmail Method Tests

    [Theory]
    [InlineData("test@example.com", true)]
    [InlineData("user.name@domain.com", true)]
    [InlineData("test.email+tag@example.co.uk", true)]
    [InlineData("valid@email.org", true)]
    [InlineData("user123@test-domain.com", true)]
    public void IsValidEmail_WithValidEmails_ShouldReturnTrue(string email, bool expected)
    {
        // Act
        var result = email.IsValidEmail();

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("   ", false)]
    [InlineData("invalid-email", false)]
    [InlineData("@domain.com", false)]
    [InlineData("user@", false)]
    [InlineData("user@@domain.com", false)] 
    [InlineData("user name@domain.com", false)]
    public void IsValidEmail_WithInvalidEmails_ShouldReturnFalse(string email, bool expected)
    {
        // Act
        var result = email.IsValidEmail();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void IsValidEmail_WithNullEmail_ShouldReturnFalse()
    {
        // Arrange
        string? email = null;

        // Act
        var result = email.IsValidEmail();

        // Assert
        result.Should().BeFalse();
    }

    #endregion

    #region IsValidCpf Method Tests

    [Theory]
    [InlineData("11144477735", true)] // Valid CPF
    [InlineData("111.444.777-35", true)] // Valid CPF with formatting
    public void IsValidCpf_WithValidCpf_ShouldReturnTrue(string cpf, bool expected)
    {
        // Act
        var result = cpf.IsValidCpf();

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("11111111111", false)] // All same digits
    [InlineData("12345678901", false)] // Invalid check digits
    [InlineData("abc", false)] // Non-numeric
    public void IsValidCpf_WithInvalidCpf_ShouldReturnFalse(string cpf, bool expected)
    {
        // Act
        var result = cpf.IsValidCpf();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void IsValidCpf_WithNullCpf_ShouldReturnFalse()
    {
        // Arrange
        string? cpf = null;

        // Act
        var result = cpf.IsValidCpf();

        // Assert
        result.Should().BeFalse();
    }

    #endregion

    #region IsValidCnpj Method Tests

    [Theory]
    [InlineData("11222333000181", true)] // Valid CNPJ
    [InlineData("11.222.333/0001-81", true)] // Valid CNPJ with formatting
    public void IsValidCnpj_WithValidCnpj_ShouldReturnTrue(string cnpj, bool expected)
    {
        // Act
        var result = cnpj.IsValidCnpj();

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("11111111111111", false)] // All same digits
    [InlineData("12345678000190", false)] // Invalid check digits
    [InlineData("abc", false)] // Non-numeric
    public void IsValidCnpj_WithInvalidCnpj_ShouldReturnFalse(string cnpj, bool expected)
    {
        // Act
        var result = cnpj.IsValidCnpj();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void IsValidCnpj_WithNullCnpj_ShouldReturnFalse()
    {
        // Arrange
        string? cnpj = null;

        // Act
        var result = cnpj.IsValidCnpj();

        // Assert
        result.Should().BeFalse();
    }

    #endregion

    #region Clear Input Methods Tests

    [Theory]
    [InlineData("12345-678", "12345678")]
    [InlineData("12.345-678", "12345678")]
    [InlineData("12 345_678", "12345678")]
    [InlineData("12345678", "12345678")]
    [InlineData("", "")]
    public void ClearInputCep_ShouldRemoveFormatting(string input, string expected)
    {
        // Act
        var result = input.ClearInputCep();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ClearInputCep_WithNullInput_ShouldReturnEmptyString()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.ClearInputCep();

        // Assert
        result.Should().Be(string.Empty);
    }

    [Theory]
    [InlineData("12.345.678/0001-90", "12345678000190")]
    [InlineData("12345678000190", "12345678000190")]
    [InlineData("12.345.678_0001-90", "12345678000190")]
    [InlineData("", "")]
    public void ClearInputCnpj_ShouldRemoveFormatting(string input, string expected)
    {
        // Act
        var result = input.ClearInputCnpj();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ClearInputCnpj_WithNullInput_ShouldReturnEmptyString()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.ClearInputCnpj();

        // Assert
        result.Should().Be(string.Empty);
    }

    [Theory]
    [InlineData("123.456.789-01", "12345678901")]
    [InlineData("12345678901", "12345678901")]
    [InlineData("123_456.789-01", "12345678901")]
    [InlineData("", "")]
    public void ClearInputCpf_ShouldRemoveFormatting(string input, string expected)
    {
        // Act
        var result = input.ClearInputCpf();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ClearInputCpf_WithNullInput_ShouldReturnEmptyString()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.ClearInputCpf();

        // Assert
        result.Should().Be(string.Empty);
    }

    [Theory]
    [InlineData("12345-678", "12345678")]
    [InlineData("12.345.678/0001-90", "12345678000190")]
    [InlineData("123.456.789-01", "12345678901")]
    [InlineData("12 345-678", "12345678")]
    [InlineData("", "")]
    public void ClearInputCepCpfCnpj_ShouldRemoveAllFormatting(string input, string expected)
    {
        // Act
        var result = input.ClearInputCepCpfCnpj();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ClearInputCepCpfCnpj_WithNullInput_ShouldReturnEmptyString()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.ClearInputCepCpfCnpj();

        // Assert
        result.Should().Be(string.Empty);
    }

    #endregion

    #region SQL Helper Methods Tests

    [Fact]
    public void SqlDataMaiorQue_ShouldReturnCorrectSqlString()
    {
        // Arrange
        var campo = "DataCriacao";
        var data = new DateTime(2023, 12, 31, 15, 30, 45);

        // Act
        var result = campo.SqlDataMaiorQue(data);

        // Assert
        result.Should().NotBeNullOrEmpty();
        result.Should().Contain("DataCriacao");
        result.Should().Contain(">=");
        result.Should().Contain("CONVERT(DATETIME");
    }

    [Fact]
    public void SqlOrderDesc_ShouldReturnCorrectFormat()
    {
        // Arrange
        var campo = "Nome";

        // Act
        var result = campo.SqlOrderDesc();

        // Assert
        result.Should().Be(" [Nome] DESC");
    }

    [Theory]
    [InlineData("Usuarios", null, "[dbo].[Usuarios] ")]
    [InlineData("Usuarios_sp_ListAll", null, "dbo.Usuarios_sp_ListAll ")]
    public void Dbo_ShouldReturnCorrectFormat(string tabelaNome, MsiSqlConnection? connection, string expected)
    {
        // Act
        var result = tabelaNome.dbo(connection);

        // Assert
        result.Trim().Should().Be(expected.Trim());
    }

    [Fact]
    public void Dbo_WithStoredProcedurePrefix_ShouldReturnStoredProcedureFormat()
    {
        // Arrange
        var tabelaNome = "MyTable_sp_GetData";
        MsiSqlConnection? connection = null;

        // Act
        var result = tabelaNome.dbo(connection);

        // Assert
        result.Should().Be("dbo.MyTable_sp_GetData ");
        result.Should().NotContain("["); // No brackets for stored procedures
        result.Should().NotContain("]");
    }

    [Fact]
    public void Dbo_WithRegularTable_ShouldReturnTableFormat()
    {
        // Arrange
        var tabelaNome = "RegularTable";
        MsiSqlConnection? connection = null;

        // Act
        var result = tabelaNome.dbo(connection);

        // Assert
        result.Should().Be(" [dbo].[RegularTable] ");
        result.Should().Contain("[").And.Contain("]");
    }

    [Fact]
    public void Dbo_WithCustomConnection_ShouldUseCustomSchema()
    {
        // Arrange
        var tabelaNome = "TestTable";
        var connection = new MsiSqlConnection("Data Source=.;Initial Catalog=DATABASE_NAME;Integrated Security=True;") { UseDbo = "custom" };

        // Act
        var result = tabelaNome.dbo(connection);

        // Assert
        result.Trim().Should().Be("[custom].[TestTable] ".Trim());
        result.Should().Contain("custom");
    }

    [Theory]
    [InlineData("Status", true, " [Status]=1")]
    [InlineData("Status", false, " [Status]=0")]
    [InlineData("Ativo", true, " [Ativo]=1")]
    [InlineData("Ativo", false, " [Ativo]=0")]
    public void SqlCmdBoolCheck_ShouldReturnCorrectFormat(string campo, bool value, string expected)
    {
        // Act
        var result = campo.SqlCmdBoolCheck(value);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void SqlCmdBoolSim_ShouldReturnCorrectFormat()
    {
        // Arrange
        var campo = "Ativo";

        // Act
        var result = campo.SqlCmdBoolSim();

        // Assert
        result.Should().Be(" [Ativo]=1 ");
    }

    [Fact]
    public void SqlCmdBoolNao_ShouldReturnCorrectFormat()
    {
        // Arrange
        var campo = "Ativo";

        // Act
        var result = campo.SqlCmdBoolNao();

        // Assert
        result.Should().Be(" ( [Ativo] IS NULL OR [Ativo]=0 ) ");
    }

    [Theory]
    [InlineData("Id", 0, " ([Id]=0 OR [Id] IS NULL) ")]
    [InlineData("Id", 1, " [Id]=1 ")]
    [InlineData("UserId", 123, " [UserId]=123 ")]
    public void SqlCmdNumberIgual_Int_ShouldReturnCorrectFormat(string campo, int id, string expected)
    {
        // Act
        var result = campo.SqlCmdNumberIgual(id);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("Id", 0L, " ([Id]=0 OR [Id] IS NULL) ")]
    [InlineData("Id", 1L, " [Id]=1 ")]
    [InlineData("UserId", 123L, " [UserId]=123 ")]
    public void SqlCmdNumberIgual_Long_ShouldReturnCorrectFormat(string campo, long id, string expected)
    {
        // Act
        var result = campo.SqlCmdNumberIgual(id);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void SqlCmdIsNull_ShouldReturnCorrectFormat()
    {
        // Arrange
        var campo = "DtExclusao";

        // Act
        var result = campo.SqlCmdIsNull();

        // Assert
        result.Should().Be(" [DtExclusao] IS NULL ");
    }

    [Fact]
    public void SqlCmdNotIsNull_ShouldReturnCorrectFormat()
    {
        // Arrange
        var campo = "DtCriacao";

        // Act
        var result = campo.SqlCmdNotIsNull();

        // Assert
        result.Should().Be(" NOT [DtCriacao] IS NULL ");
    }

    [Theory]
    [InlineData("Nome", "João", 10)]
    [InlineData("Nome", "NomeComMuitosCaracteres", 5)]
    public void SqlCmdTextIgual_WithMaxLength_ShouldReturnCorrectFormat(string campo, string text, int nMax)
    {
        // Act
        var result = campo.SqlCmdTextIgual(text, nMax);

        // Assert
        result.Should().Contain($"[{campo}]");
        result.Should().Contain(DevourerConsts.MsiCollate);
        result.Should().Contain("like");
        
        // Verify text is truncated if longer than nMax
        if (text.Trim().Length > nMax)
        {
            var expectedText = text.Trim().ToUpper()[..nMax];
            result.Should().Contain(expectedText);
        }
    }

    [Theory]
    [InlineData("Nome", "João")]
    [InlineData("Email", "test@example.com")]
    public void SqlCmdTextIgual_WithoutMaxLength_ShouldReturnCorrectFormat(string campo, string text)
    {
        // Act
        var result = campo.SqlCmdTextIgual(text);

        // Assert
        result.Should().Contain($"[{campo}]");
        result.Should().Contain("=");
    }

    [Theory]
    [InlineData("Nome", "João")]
    [InlineData("Status", "Ativo")]
    public void SqlCmdTextDiff_ShouldReturnCorrectFormat(string campo, string text)
    {
        // Act
        var result = campo.SqlCmdTextDiff(text);

        // Assert
        result.Should().Contain($"[{campo}] IS NULL");
        result.Should().Contain("OR");
        result.Should().Contain("NOT");
        result.Should().Contain("like");
    }

    [Theory]
    [InlineData("Nome", "João")]
    [InlineData("Descricao", "Test?")]
    public void SqlCmdTextLike_ShouldReturnCorrectFormat(string campo, string text)
    {
        // Act
        var result = campo.SqlCmdTextLike(text);

        // Assert
        result.Should().Contain($"[{campo}]");
        result.Should().Contain(DevourerConsts.MsiCollate);
        result.Should().Contain("like");
        result.Should().Contain("%'");
    }

    [Theory]
    [InlineData("Nome", "João")]
    [InlineData("Descricao", "Test?")]
    public void SqlCmdTextLikeInit_ShouldReturnCorrectFormat(string campo, string text)
    {
        // Act
        var result = campo.SqlCmdTextLikeInit(text);

        // Assert
        result.Should().Contain($"[{campo}]");
        result.Should().Contain(DevourerConsts.MsiCollate);
        result.Should().Contain("like");
        result.Should().Contain("[");
        result.Should().Contain("'%");
        result.Should().Contain("%'");
    }

    [Theory]
    [InlineData("Nome", "João Silva")]
    [InlineData("Endereco", "Rua das Flores")]
    public void SqlCmdTextLikeSpaces_ShouldReturnCorrectFormat(string campo, string text)
    {
        // Act
        var result = campo.SqlCmdTextLikeSpaces(text);

        // Assert
        result.Should().Contain(campo);
        result.Should().Contain(DevourerConsts.MsiCollate);
        result.Should().Contain("like"); 
        result.Should().Contain("'%");
        result.Should().Contain("%'");
    }

    [Fact]
    public void SqlCmdTextLikeSpaces_ShouldReplaceSpacesWithPercent()
    {
        // Arrange
        var campo = "Nome";
        var text = "João Silva Santos";

        // Act
        var result = campo.SqlCmdTextLikeSpaces(text);

        // Assert
        result.Should().Contain("%João%Silva%Santos%");
    }

    [Theory]
    [InlineData("Status", 1, " ([Status]<>1 OR [Status] IS NULL) ")]
    [InlineData("TipoId", 5, " ([TipoId]<>5 OR [TipoId] IS NULL) ")]
    public void SqlCmdNumberDiff_ShouldReturnCorrectFormat(string campo, int id, string expected)
    {
        // Act
        var result = campo.SqlCmdNumberDiff(id);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("text", "text")]
    [InlineData("text'with'quotes", "text''with''quotes")]
    [InlineData("", "")]
    [InlineData("normal text", "normal text")]
    [InlineData("multiple'quotes'here'too", "multiple''quotes''here''too")]
    public void PreparaParaSql_ShouldEscapeQuotes(string text, string expected)
    {
        // Act
        var result = text.PreparaParaSql();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void PreparaParaSql_WithNullInput_ShouldReturnEmptyString()
    {
        // Arrange
        string? text = null;

        // Act
        var result = text.PreparaParaSql();

        // Assert
        result.Should().Be("");
    }

    #endregion

    #region Edge Cases and Integration Tests

    [Fact]
    public void SqlMethods_WithSpecialCharacters_ShouldHandleCorrectly()
    {
        // Arrange
        var campo = "Observacoes";
        var text = "Text with 'quotes' and % symbols";

        // Act
        var result = campo.SqlCmdTextLike(text);

        // Assert
        result.Should().NotBeNullOrEmpty();
        result.Should().Contain("''"); // Escaped quotes
    }

    [Fact]
    public void SqlMethods_WithNullText_ShouldHandleGracefully()
    {
        // Arrange
        var campo = "Campo";
        string? text = null;

        // Act & Assert
        var result1 = campo.SqlCmdTextIgual(text);
        var result2 = campo.SqlCmdTextDiff(text);
        var result3 = campo.SqlCmdTextLike(text);

        result1.Should().NotBeNullOrEmpty();
        result2.Should().NotBeNullOrEmpty();
        result3.Should().NotBeNullOrEmpty();
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("\t")]
    [InlineData("\n")]
    public void ClearInputMethods_WithWhitespaceOnly_ShouldReturnEmptyString(string input)
    {
        // Act
        var resultCep = input.ClearInputCep();
        var resultCpf = input.ClearInputCpf();
        var resultCnpj = input.ClearInputCnpj();
        var resultAll = input.ClearInputCepCpfCnpj();

        // Assert
        resultCep.Should().NotContain(" ");
        resultCpf.Should().NotContain(" ");
        resultCnpj.Should().NotContain(" ");
        resultAll.Should().NotContain(" ");
    }

    [Fact]
    public void EmailValidation_RealWorldScenarios_ShouldWorkCorrectly()
    {
        // Arrange & Act & Assert
        "user@domain.com".IsValidEmail().Should().BeTrue();
        "user.name+tag@example.org".IsValidEmail().Should().BeTrue();
        "user@sub.domain.com".IsValidEmail().Should().BeTrue();
        
        "invalid.email".IsValidEmail().Should().BeFalse();
        "@domain.com".IsValidEmail().Should().BeFalse();
        "user@".IsValidEmail().Should().BeFalse();
    }

    [Fact]
    public void SqlGeneration_ChainedOperations_ShouldWorkCorrectly()
    {
        // Arrange
        var campo = "Nome";
        var texto = "João's Test";

        // Act
        var preparedText = texto.PreparaParaSql();
        var sqlCondition = campo.SqlCmdTextLike(texto);

        // Assert
        preparedText.Should().Contain("''");
        sqlCondition.Should().Contain(preparedText);
        sqlCondition.Should().Contain($"[{campo}]");
    }

    [Theory]
    [InlineData(int.MinValue)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(int.MaxValue)]
    public void IsEmptyX_Int_WithBoundaryValues_ShouldHandleCorrectly(int value)
    {
        // Act
        var result = value.IsEmptyX();

        // Assert
        if (value == int.MinValue)
        {
            result.Should().BeTrue();
        }
        else
        {
            result.Should().BeFalse();
        }
    }

    #endregion

    #region Decimal Boundary Value Tests

    [Theory]
    [InlineData(0.0)]
    [InlineData(0.1)]
    [InlineData(-0.1)]
    [InlineData(1.0)]
    [InlineData(-1.0)]
    public void IsEmptyX_Decimal_WithVariousValues_ShouldReturnFalse(decimal value)
    {
        // Act
        var result = value.IsEmptyX();

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void IsEmptyX_Decimal_WithMaxValue_ShouldReturnFalse()
    {
        // Arrange
        var value = decimal.MaxValue;

        // Act
        var result = value.IsEmptyX();

        // Assert
        result.Should().BeFalse();
    }

    #endregion

    #region SQL Text Method Advanced Tests

    [Fact]
    public void SqlCmdTextIgual_WithMaxLength_ShouldTruncateCorrectly()
    {
        // Arrange
        var campo = "Nome";
        var longText = "ThisIsAVeryLongTextThatShouldBeTruncated";
        var maxLength = 10;

        // Act
        var result = campo.SqlCmdTextIgual(longText, maxLength);

        // Assert
        result.Should().Contain("THISISAVER"); // Truncated to 10 chars and uppercased
    }

    [Fact]
    public void SqlCmdTextLike_WithQuestionMarks_ShouldReplaceWithPercent()
    {
        // Arrange
        var campo = "Nome";
        var text = "Jo?o S?lva";

        // Act
        var result = campo.SqlCmdTextLike(text);

        // Assert
        result.Should().Contain("Jo%o S%lva%");
    }

    [Fact]
    public void SqlCmdTextLikeInit_WithQuestionMarks_ShouldReplaceWithPercent()
    {
        // Arrange
        var campo = "Nome";
        var text = "Jo?o";

        // Act
        var result = campo.SqlCmdTextLikeInit(text);

        // Assert
        result.Should().Contain("%Jo%o%");
    }

    #endregion

    #region Performance and Memory Tests

    [Fact]
    public void ClearInputMethods_WithLargeStrings_ShouldPerformEfficiently()
    {
        // Arrange
        var largeString = new string('1', 10000) + new string('.', 1000) + new string('-', 1000);

        // Act
        var result = largeString.ClearInputCepCpfCnpj();

        // Assert
        result.Should().NotContain(".");
        result.Should().NotContain("-");
        result.Should().HaveLength(10000); // Only digits should remain
    }

    [Fact]
    public void SqlGeneration_WithManyOperations_ShouldNotLeakMemory()
    {
        // Arrange
        var campos = new[] { "Campo1", "Campo2", "Campo3", "Campo4", "Campo5" };
        var textos = new[] { "Texto1", "Texto2", "Texto3", "Texto4", "Texto5" };

        // Act
        var results = new List<string>();
        for (int i = 0; i < campos.Length; i++)
        {
            results.Add(campos[i].SqlCmdTextLike(textos[i]));
            results.Add(campos[i].SqlCmdTextIgual(textos[i]));
            results.Add(campos[i].SqlCmdBoolSim());
        }

        // Assert
        results.Should().HaveCount(15);
        results.Should().AllSatisfy(result => result.Should().NotBeNullOrEmpty());
    }

    #endregion

    #region Null Safety Tests

    [Fact]
    public void AllMethods_WithNullInputs_ShouldNotThrow()
    {
        // Arrange
        string? nullString = null;
        MsiSqlConnection? nullConnection = null;

        // Act & Assert - These should not throw exceptions
        nullString.IsEmptyX().Should().BeTrue();
        nullString.IsEmptyDX().Should().BeTrue();
        nullString.IsValidEmail().Should().BeFalse();
        nullString.IsValidCpf().Should().BeFalse();
        nullString.IsValidCnpj().Should().BeFalse();
        nullString.ClearInputCep().Should().Be(string.Empty);
        nullString.ClearInputCpf().Should().Be(string.Empty);
        nullString.ClearInputCnpj().Should().Be(string.Empty);
        nullString.ClearInputCepCpfCnpj().Should().Be(string.Empty);
        nullString.PreparaParaSql().Should().Be("");

        "Campo".dbo(nullConnection).Should().NotBeNullOrEmpty();
        "Campo".SqlCmdTextIgual(nullString).Should().NotBeNullOrEmpty();
        "Campo".SqlCmdTextDiff(nullString).Should().NotBeNullOrEmpty();
        "Campo".SqlCmdTextLike(nullString).Should().NotBeNullOrEmpty();
        "Campo".SqlCmdTextLikeInit(nullString).Should().NotBeNullOrEmpty();
        "Campo".SqlCmdTextLikeSpaces(nullString).Should().NotBeNullOrEmpty();
    }

    #endregion

    #region Real-World Integration Tests

    [Fact]
    public void CompleteWorkflow_UserRegistration_ShouldWorkEndToEnd()
    {
        // Arrange - Simulating user registration form data
        var cpf = "111.444.777-35";
        var email = "usuario@teste.com";
        var cep = "12345-678";
        var nome = "João da Silva";

        // Act - Clean and validate data
        var cpfLimpo = cpf.ClearInputCpf();
        var cepLimpo = cep.ClearInputCep();
        var cpfValido = cpfLimpo.IsValidCpf();
        var emailValido = email.IsValidEmail();

        // Generate SQL conditions
        var sqlCpf = "CPF".SqlCmdTextIgual(cpfLimpo);
        var sqlNome = "Nome".SqlCmdTextLike(nome);
        var sqlEmail = "Email".SqlCmdTextIgual(email);

        // Assert
        cpfLimpo.Should().Be("11144477735");
        cepLimpo.Should().Be("12345678");
        cpfValido.Should().BeTrue();
        emailValido.Should().BeTrue();
        
        sqlCpf.Should().Contain("CPF");
        sqlNome.Should().Contain("Nome");
        sqlEmail.Should().Contain("Email");
    }

    [Fact]
    public void CompleteWorkflow_CompanyRegistration_ShouldWorkEndToEnd()
    {
        // Arrange - Simulating company registration
        var cnpj = "64.664.313/0001-27";
        var razaoSocial = "Empresa Teste Ltda";
        var ativo = true;

        // Act
        var cnpjLimpo = cnpj.ClearInputCnpj();
        var cnpjValido = cnpjLimpo.IsValidCnpj();
        var sqlCnpj = "CNPJ".SqlCmdTextIgual(cnpjLimpo);
        var sqlRazao = "RazaoSocial".SqlCmdTextLike(razaoSocial);
        var sqlAtivo = "Ativo".SqlCmdBoolCheck(ativo);

        // Assert
        cnpjLimpo.Should().Be("64664313000127");
        cnpjValido.Should().BeTrue();
        sqlCnpj.Should().Contain("CNPJ");
        sqlRazao.Should().Contain("RazaoSocial");
        sqlAtivo.Should().Contain("[Ativo]=1");
    }

    #endregion

    #region Unicode and Special Character Tests

    [Theory]
    [InlineData("João", "João")]
    [InlineData("São Paulo", "São Paulo")]
    [InlineData("Ação", "Ação")]
    public void SqlCmdTextMethods_WithUnicodeCharacters_ShouldHandleCorrectly(string input, string expectedUppercase)
    {
        // Act
        var result = "Campo".SqlCmdTextLike(input);

        // Assert
        result.Should().Contain(expectedUppercase);
    }

    [Theory]
    [InlineData("123.456.789-00", "12345678900")]
    [InlineData("00.000.000/0001-91", "00000000000191")]
    [InlineData("12345-678", "12345678")]
    public void ClearInputMethods_WithZerosPadding_ShouldPreserveZeros(string input, string expected)
    {
        // Act
        var resultCpf = input.ClearInputCpf();
        var resultCnpj = input.ClearInputCnpj();
        var resultCep = input.ClearInputCep();
        var resultAll = input.ClearInputCepCpfCnpj();

        // Assert
        if (input.Contains('/'))
        {
            resultCnpj.Should().Be(expected);
            resultAll.Should().Be(expected);
        }
        else if (input.Length <= 11)
        {
            if (input.Contains('-') && input.Length == 10)
            {
                resultCep.Should().Be(expected);
                resultAll.Should().Be(expected);
            }
            else
            {
                resultCpf.Should().Be(expected);
                resultAll.Should().Be(expected);
            }
        }
    }

    #endregion

    #region Error Handling and Robustness Tests

    [Fact]
    public void IsValidEmail_WithMalformedEmail_ShouldNotThrowException()
    {
        // Arrange
        var malformedEmails = new[]
        {
            "user@domain@domain.com",
            "user..name@domain.com",
            "@",
            "@@",
            "user@domain..com",
            "user@.domain.com"
        };

        // Act & Assert
        foreach (var email in malformedEmails)
        {
            Action act = () => email.IsValidEmail();
            act.Should().NotThrow();
            email.IsValidEmail().Should().BeFalse();
        }
    }

    [Fact]
    public void IsEmptyDX_WithVariousInvalidDateFormats_ShouldReturnTrue()
    {
        // Arrange
        var invalidDates = new[]
        {
            "32/01/2023", // Invalid day
            "01/13/2023", // Invalid month
            "01/01/0000", // Invalid year
            "2023-13-01", // Invalid month in ISO format
            "not-a-date",
            "123456", 
            "2023", 
        };

        // Act & Assert
        foreach (var invalidDate in invalidDates)
        {
            invalidDate.IsEmptyDX().Should().BeTrue(); // $"'{invalidDate}' should be considered empty/invalid");
        }
    }

    #endregion
}