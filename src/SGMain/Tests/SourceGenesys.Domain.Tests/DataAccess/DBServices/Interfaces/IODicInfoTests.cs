using Xunit;
using FluentAssertions;
using MenphisSI.DB; // Add this for DBInfoSystem
using System.Collections.Immutable;

namespace SourceGenesys.Domain.Tests.DataAccess.DBServices.Interfaces;

public class IODicInfoTests
{
    private class TestDicInfo : IODicInfo
    {
        public string TabelaNome { get; set; } = "TestTable";
        public string CampoCodigo { get; set; } = "Id";
        public string CampoNome { get; set; } = "Name";
        public string Prefixo { get; set; } = "T_";
        public string TypeFieldCode { get; set; } = "int";
        public bool Identity { get; set; } = true;
        public bool Auditor { get; set; } = true;
        public bool NameId { get; set; } = false;
        public bool StoredProcedureOrView { get; set; } = false;
        public ImmutableArray<DBInfoSystem> ListFields { get; set; } = ImmutableArray<DBInfoSystem>.Empty;
        public ImmutableArray<DBInfoSystem> FieldsRaw { get; set; } = ImmutableArray<DBInfoSystem>.Empty;
        public ImmutableArray<DBInfoSystem> PkFields { get; set; } = ImmutableArray<DBInfoSystem>.Empty;
        public ImmutableArray<DBInfoSystem> PkIndicesFields { get; set; } = ImmutableArray<DBInfoSystem>.Empty;
        public DBInfoSystem? InfoSystemByNameField { get; set; }

        public string ITabelaNome() => TabelaNome;
        public ImmutableArray<DBInfoSystem> IListFields() => ListFields;
        public ImmutableArray<DBInfoSystem> IFieldsRaw() => FieldsRaw;
        public ImmutableArray<DBInfoSystem> IPkFields() => PkFields;
        public ImmutableArray<DBInfoSystem> IPkIndicesFields() => PkIndicesFields;
        public bool HasAuditor() => Auditor;
        public bool HasNameId() => NameId;
        public string ICampoCodigo() => CampoCodigo;
        public string ITypeFieldCode() => TypeFieldCode;
        public bool IdIsIdentity() => Identity;
        public string ICampoNome() => CampoNome;
        public string IPrefixo() => Prefixo;
        public bool IIsStoredProcedureOrView() => StoredProcedureOrView;
        public DBInfoSystem? GetInfoSystemByNameField(string campo) => InfoSystemByNameField;
    }

    [Fact]
    public void ITabelaNome_ShouldReturnExpected()
    {
        var dic = new TestDicInfo { TabelaNome = "Table1" };
        dic.ITabelaNome().Should().Be("Table1");
    }

    [Fact]
    public void IListFields_ShouldReturnExpected()
    {
        var arr = ImmutableArray.Create<DBInfoSystem>();
        var dic = new TestDicInfo { ListFields = arr };
        dic.IListFields().Should().BeEquivalentTo(arr);
    }

    [Fact]
    public void IFieldsRaw_ShouldReturnExpected()
    {
        var arr = ImmutableArray.Create<DBInfoSystem>();
        var dic = new TestDicInfo { FieldsRaw = arr };
        dic.IFieldsRaw().Should().BeEquivalentTo(arr);
    }

    [Fact]
    public void IPkFields_ShouldReturnExpected()
    {
        var arr = ImmutableArray.Create<DBInfoSystem>();
        var dic = new TestDicInfo { PkFields = arr };
        dic.IPkFields().Should().BeEquivalentTo(arr);
    }

    [Fact]
    public void IPkIndicesFields_ShouldReturnExpected()
    {
        var arr = ImmutableArray.Create<DBInfoSystem>();
        var dic = new TestDicInfo { PkIndicesFields = arr };
        dic.IPkIndicesFields().Should().BeEquivalentTo(arr);
    }

    [Fact]
    public void HasAuditor_ShouldReturnExpected()
    {
        var dic = new TestDicInfo { Auditor = true };
        dic.HasAuditor().Should().BeTrue();
        dic = new TestDicInfo { Auditor = false };
        dic.HasAuditor().Should().BeFalse();
    }

    [Fact]
    public void HasNameId_ShouldReturnExpected()
    {
        var dic = new TestDicInfo { NameId = true };
        dic.HasNameId().Should().BeTrue();
        dic = new TestDicInfo { NameId = false };
        dic.HasNameId().Should().BeFalse();
    }

    [Fact]
    public void ICampoCodigo_ShouldReturnExpected()
    {
        var dic = new TestDicInfo { CampoCodigo = "Code" };
        dic.ICampoCodigo().Should().Be("Code");
    }

    [Fact]
    public void ITypeFieldCode_ShouldReturnExpected()
    {
        var dic = new TestDicInfo { TypeFieldCode = "string" };
        dic.ITypeFieldCode().Should().Be("string");
    }

    [Fact]
    public void IdIsIdentity_ShouldReturnExpected()
    {
        var dic = new TestDicInfo { Identity = true };
        dic.IdIsIdentity().Should().BeTrue();
        dic = new TestDicInfo { Identity = false };
        dic.IdIsIdentity().Should().BeFalse();
    }

    [Fact]
    public void ICampoNome_ShouldReturnExpected()
    {
        var dic = new TestDicInfo { CampoNome = "Nome" };
        dic.ICampoNome().Should().Be("Nome");
    }

    [Fact]
    public void IPrefixo_ShouldReturnExpected()
    {
        var dic = new TestDicInfo { Prefixo = "P_" };
        dic.IPrefixo().Should().Be("P_");
    }

    [Fact]
    public void IIsStoredProcedureOrView_ShouldReturnExpected()
    {
        var dic = new TestDicInfo { StoredProcedureOrView = true };
        dic.IIsStoredProcedureOrView().Should().BeTrue();
        dic = new TestDicInfo { StoredProcedureOrView = false };
        dic.IIsStoredProcedureOrView().Should().BeFalse();
    }

    [Fact]
    public void GetInfoSystemByNameField_ShouldReturnExpected()
    {
        var dbInfo = new DBInfoSystem(0, "T", "C", "N", 1, "Cap", "Tip", ETipoDadosSysteminfo.SysteminfoText, true, false, false);
        var dic = new TestDicInfo { InfoSystemByNameField = dbInfo };
        dic.GetInfoSystemByNameField("any").Should().BeSameAs(dbInfo);
    }

    [Fact]
    public void NomeSemPrefixo_ShouldReturnNameWithoutPrefix_WhenPrefixIsPresent()
    {
        IODicInfo dic = new TestDicInfo { Prefixo = "T_", CampoNome = "T_Field" };
        dic.NomeSemPrefixo().Should().Be("Field");
    }

    [Fact]
    public void NomeSemPrefixo_ShouldReturnCampoNome_WhenPrefixIsNotPresent()
    {
        IODicInfo dic = new TestDicInfo { Prefixo = "T_", CampoNome = "Field" };
        dic.NomeSemPrefixo().Should().Be("Field");
    }

    [Fact]
    public void NomeSemPrefixo_ShouldReturnCampoNome_WhenPrefixIsEmpty()
    {
        IODicInfo dic = new TestDicInfo { Prefixo = "", CampoNome = "Field" };
        dic.NomeSemPrefixo().Should().Be("Field");
    }
}
