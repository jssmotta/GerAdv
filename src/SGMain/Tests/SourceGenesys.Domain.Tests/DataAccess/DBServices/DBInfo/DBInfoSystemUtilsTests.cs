using MenphisSI.DB;

namespace SourceGenesys.Domain.Tests.DataAccess.DBServices.DBInfo;

public class DBInfoSystemUtilsTests
{
    [Theory]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoTextCpf, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoTextCnpj, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoText, false)]
    public void IsDocumento_ShouldReturnExpected(int tipo, bool expected)
    {
        DBInfoSystem.IsDocumento(tipo).Should().Be(expected);
    }

    [Theory]
    [InlineData(ETipoDadosSysteminfo.SysteminfoDataInicio, true)]
    [InlineData(ETipoDadosSysteminfo.SysteminfoDataTermino, true)]
    [InlineData(ETipoDadosSysteminfo.SysteminfoDatetime, true)]
    [InlineData(ETipoDadosSysteminfo.SysteminfoDataNascimento, true)]
    [InlineData(ETipoDadosSysteminfo.SysteminfoText, false)]
    public void IsDataFixedSize_ShouldReturnExpected(ETipoDadosSysteminfo tipo, bool expected)
    {
        DBInfoSystem.IsDataFixedSize(tipo).Should().Be(expected);
    }

    [Theory]
    [InlineData(EGroupSepDados.GroupSepBasico, "Básico")]
    [InlineData(EGroupSepDados.GroupSepInformacao, "Informações")]
    [InlineData(EGroupSepDados.GroupSepDadosPF, "Dados de Pessoa física")]
    [InlineData(EGroupSepDados.GroupSepDadosPJ, "Dados de Pessoa jurídica")]
    [InlineData(EGroupSepDados.GroupSepRepresentante, "Representante")]
    [InlineData(EGroupSepDados.GroupSepPeriodo, "Período")]
    [InlineData(EGroupSepDados.GroupSepContato, "Contato")]
    [InlineData(EGroupSepDados.GroupSepCarteiraTrabalho, "Carteira de trabalho")]
    [InlineData(EGroupSepDados.GroupSepEndereco, "Endereço")]
    [InlineData(EGroupSepDados.GroupSepDadosGerais, "Dados gerais")]
    [InlineData(EGroupSepDados.GroupSepConfig, "Configuração do registro")]
    [InlineData(EGroupSepDados.GroupSepAuditor, "Auditor do Sistema")]
    [InlineData((EGroupSepDados)999, "")]
    public void GetGroupSepDescription_ShouldReturnExpected(EGroupSepDados grupo, string expected)
    {
        DBInfoSystem.GetGroupSepDescription(grupo).Should().Be(expected);
    }

    [Theory]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoTextGuid, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoTextClassificacaoStar, true)]    
    [InlineData(39, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoTextCnh, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoMemo, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoText, true)]
    [InlineData(100, false)]
    public void IsText_ShouldReturnExpected(int tipo, bool expected)
    {
        DBInfoSystem.IsText(tipo).Should().Be(expected);
    }

    [Theory]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoMemo, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoMemoObservacao, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoTextFax, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoTextFone, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoText, false)]
    public void IsMemo_ShouldReturnExpected(int tipo, bool expected)
    {
        DBInfoSystem.IsMemo(tipo).Should().Be(expected);
    }

    [Theory]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoForeingkey, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoForeingkeyCidade, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoText, false)]
    public void IsForeingKey_ShouldReturnExpected(int tipo, bool expected)
    {
        DBInfoSystem.IsForeingKey(tipo).Should().Be(expected);
    }

    [Theory]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoNumber, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoForeingkey, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoText, false)]
    public void IsNumber_ShouldReturnExpected(int tipo, bool expected)
    {
        DBInfoSystem.IsNumber(tipo).Should().Be(expected);
    }

    [Theory]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoDouble, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoDoubleSalario, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoText, false)]
    public void IsDoubleOrDecimal_ShouldReturnExpected(int tipo, bool expected)
    {
        DBInfoSystem.IsDoubleOrDecimal(tipo).Should().Be(expected);
    }

    [Theory]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoBoolean, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoBooleanBold, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoBooleanSexo, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoBooleanTipoPessoa, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoBooleanVisto, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoBooleanLembrarAniversario, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoText, false)]
    public void IsBoolean_ShouldReturnExpected(int tipo, bool expected)
    {
        DBInfoSystem.IsBoolean(tipo).Should().Be(expected);
    }

    [Theory]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoTextEmail, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoTextEmailCob, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoTextEmailPro, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoText, false)]
    public void IsEMail_ShouldReturnExpected(int tipo, bool expected)
    {
        DBInfoSystem.IsEMail(tipo).Should().Be(expected);
    }

    [Theory]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoDataCadastramento, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoDataInicio, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoDataTermino, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoDataModificacao, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoDataNascimento, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoDatetime, true)]
    [InlineData((int)ETipoDadosSysteminfo.SysteminfoText, false)]
    public void IsData_ShouldReturnExpected(int tipo, bool expected)
    {
        DBInfoSystem.IsData(tipo).Should().Be(expected);
    }

    [Fact]
    public void SqlType_ShouldReturnExpectedTypes()
    {
        var data = new DBInfoSystem(0, "T", "C", "N", 10, "Caption", "Tooltip", ETipoDadosSysteminfo.SysteminfoDataInicio, true, false, false);
        DBInfoSystem.SqlType(data).Should().Be("datetime");
        var boolean = new DBInfoSystem(0, "T", "C", "N", 10, "Caption", "Tooltip", ETipoDadosSysteminfo.SysteminfoBoolean, true, false, false);
        DBInfoSystem.SqlType(boolean).Should().Be("bit");
        var dbl = new DBInfoSystem(0, "T", "C", "N", 10, "Caption", "Tooltip", ETipoDadosSysteminfo.SysteminfoDouble, true, false, false);
        DBInfoSystem.SqlType(dbl).Should().Be("float");
        var integer = new DBInfoSystem(0, "T", "C", "N", 10, "Caption", "Tooltip", ETipoDadosSysteminfo.SysteminfoNumber, true, false, false);
        DBInfoSystem.SqlType(integer).Should().Be("int");
        var text = new DBInfoSystem(0, "T", "C", "N", 10, "Caption", "Tooltip", ETipoDadosSysteminfo.SysteminfoText, true, false, false);
        DBInfoSystem.SqlType(text).Should().Be("nvarchar");
    }

    [Fact]
    public void SqlType_ShouldThrowOnUnknownType()
    {
        var unknown = new DBInfoSystem(0, "T", "C", "N", 0, "Caption", "Tooltip", (ETipoDadosSysteminfo)9999, true, false, false);
        Action act = () => DBInfoSystem.SqlType(unknown);
        act.Should().Throw<Exception>().WithMessage("Tipo desconhecido, shadow 0x900x9999x192391");
    }

    [Fact]
    public void SqlSizeByType_ShouldReturnExpected()
    {
        var data = new DBInfoSystem(0, "T", "C", "N", 10, "Caption", "Tooltip", ETipoDadosSysteminfo.SysteminfoDataInicio, true, false, false);
        DBInfoSystem.SqlSizeByType(data).Should().Be("");
        var text = new DBInfoSystem(0, "T", "C", "N", 10, "Caption", "Tooltip", ETipoDadosSysteminfo.SysteminfoText, true, false, false);
        DBInfoSystem.SqlSizeByType(text).Should().Be("(10)");
        var textMax = new DBInfoSystem(0, "T", "C", "N", 3000, "Caption", "Tooltip", ETipoDadosSysteminfo.SysteminfoText, true, false, false);
        DBInfoSystem.SqlSizeByType(textMax).Should().Be("(max)");
        var notText = new DBInfoSystem(0, "T", "C", "N", 10, "Caption", "Tooltip", (ETipoDadosSysteminfo)999, true, false, false);
        DBInfoSystem.SqlSizeByType(notText).Should().Be("");
    }

    [Fact]
    public void GetNomeCampoByInfoSystem_ShouldReturnExpected()
    {
        var list = new List<DBInfoSystem>
        {
            new(0, "T", "C", "Field1", 10, "Caption", "Tooltip", ETipoDadosSysteminfo.SysteminfoText, true, false, false),
            new(0, "T", "C", "Field2", 10, "Caption", "Tooltip", ETipoDadosSysteminfo.SysteminfoNumber, true, false, false)
        };
        var result = typeof(DBInfoSystem)
            .GetMethod("GetNomeCampoByInfoSystem", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static, null, new[] { typeof(ETipoDadosSysteminfo), typeof(List<DBInfoSystem>) }, null)
            !.Invoke(null, new object[] { ETipoDadosSysteminfo.SysteminfoNumber, list });
        result.Should().Be("Field2");
    }

    [Fact]
    public void GetNomeCampoByInfoSystem_WithInclude_ShouldReturnExpected()
    {
        var list = new List<DBInfoSystem>
        {
            new(0, "T", "C", "Field1_Include", 10, "Caption", "Tooltip", ETipoDadosSysteminfo.SysteminfoText, true, false, false),
            new(0, "T", "C", "Field2", 10, "Caption", "Tooltip", ETipoDadosSysteminfo.SysteminfoNumber, true, false, false)
        };
        var result = typeof(DBInfoSystem)
            .GetMethod("GetNomeCampoByInfoSystem", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static, null, new[] { typeof(ETipoDadosSysteminfo), typeof(List<DBInfoSystem>), typeof(string) }, null)
            !.Invoke(null, new object[] { ETipoDadosSysteminfo.SysteminfoText, list, "Include" });
        result.Should().Be("Field1_Include");
    }
}
