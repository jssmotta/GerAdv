using MenphisSI.DB;

namespace SourceGenesys.Domain.Tests.DataAccess.DBServices.DBInfo;

public class DBInfoSystemTests
{
    [Fact]
    public void NomeSemPrefixo_ShouldReturnNameWithoutPrefix_WhenPrefixIsPresent()
    {
        var sut = new DBInfoSystem(0, "T", "C", "PRE_FieldName", 10, "Caption", "Tooltip", ETipoDadosSysteminfo.SysteminfoText, true, false, false)
        {
            Prefixo = "PRE_"
        };
        sut.NomeSemPrefixo().Should().Be("FieldName");
    }

    [Fact]
    public void NomeSemPrefixo_ShouldReturnCampoCodigo_WhenResultIsEmpty()
    {
        var sut = new DBInfoSystem(0, "T", "C", "PRE_", 10, "Caption", "Tooltip", ETipoDadosSysteminfo.SysteminfoText, true, false, false)
        {
            Prefixo = "PRE_"
        };
        sut.NomeSemPrefixo().Should().Be("CampoCodigo");
    }

    [Fact]
    public void NomeSemPrefixo_ShouldReturnName_WhenPrefixIsNotPresent()
    {
        var sut = new DBInfoSystem(0, "T", "C", "FieldName", 10, "Caption", "Tooltip", ETipoDadosSysteminfo.SysteminfoText, true, false, false)
        {
            Prefixo = "PRE_"
        };
        sut.NomeSemPrefixo().Should().Be("FieldName");
    }

    [Fact]
    public void GetForeingTabela_ShouldReturnForeignKeyTable_WhenSet()
    {
        var sut = new DBInfoSystem(0, "T", "C", "N", 10, "Caption", "Tooltip", ETipoDadosSysteminfo.SysteminfoText, true, false, false)
        {
            FForeingKeyTable = "ForeignTable"
        };
        sut.GetForeingTabela().Should().Be("ForeignTable");
    }

    [Fact]
    public void GetForeingTabela_ShouldReturnEmpty_WhenForeignKeyTableIsNull()
    {
        var sut = new DBInfoSystem(0, "T", "C", "N", 10, "Caption", "Tooltip", ETipoDadosSysteminfo.SysteminfoText, true, false, false)
        {
            FForeingKeyTable = null
        };
        sut.GetForeingTabela().Should().Be("");
    }

    [Fact]
    public void GetTabelaNome_ShouldReturnTTabela()
    {
        var sut = new DBInfoSystem(0, "TableName", "C", "N", 10, "Caption", "Tooltip", ETipoDadosSysteminfo.SysteminfoText, true, false, false);
        sut.GetTabelaNome().Should().Be("TableName");
    }

    [Fact]
    public void GetCampoNome_ShouldReturnFNome()
    {
        var sut = new DBInfoSystem(0, "T", "C", "FieldName", 10, "Caption", "Tooltip", ETipoDadosSysteminfo.SysteminfoText, true, false, false);
        sut.GetCampoNome().Should().Be("FieldName");
    }
}
