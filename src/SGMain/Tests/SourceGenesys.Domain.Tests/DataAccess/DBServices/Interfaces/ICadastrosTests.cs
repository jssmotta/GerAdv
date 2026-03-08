using System.Data;
using System.Data.SqlClient;
using Xunit;
using Moq;
using MenphisSI;

namespace SourceGenesys.Domain.Tests.DataAccess.DBServices.Interfaces
{
    public class ICadastrosTests
    {
        private class TestCadastros : ICadastros
        {
            public bool CarregarDadosBdDataRowCalled = false;
            public bool CarregarDadosBdSqlDataReaderCalled = false;
            public string TabelaName = "TestTable";
            public string CampoCodigo = "Id";
            public string CampoNome = "Name";
            public string Prefixo = "T_";
            public int Id = 42;

            public void CarregarDadosBd(DataRow? dbRec) => CarregarDadosBdDataRowCalled = true;
            public void CarregarDadosBd(SqlDataReader dbRec) => CarregarDadosBdSqlDataReaderCalled = true;
            public string ITabelaName() => TabelaName;
            public string ICampoCodigo() => CampoCodigo;
            public string ICampoNome() => CampoNome;
            public string IPrefixo() => Prefixo;
            public int GetID() => Id;
        }

        [Fact]
        public void CarregarDadosBd_DataRow_ShouldSetFlag()
        {
            var test = new TestCadastros();
            test.CarregarDadosBd((DataRow?)null);
            Assert.True(test.CarregarDadosBdDataRowCalled);
        } 

        [Fact]
        public void ITabelaName_ShouldReturnExpected()
        {
            var test = new TestCadastros();
            Assert.Equal("TestTable", test.ITabelaName());
        }

        [Fact]
        public void ICampoCodigo_ShouldReturnExpected()
        {
            var test = new TestCadastros();
            Assert.Equal("Id", test.ICampoCodigo());
        }

        [Fact]
        public void ICampoNome_ShouldReturnExpected()
        {
            var test = new TestCadastros();
            Assert.Equal("Name", test.ICampoNome());
        }

        [Fact]
        public void IPrefixo_ShouldReturnExpected()
        {
            var test = new TestCadastros();
            Assert.Equal("T_", test.IPrefixo());
        }

        [Fact]
        public void GetID_ShouldReturnExpected()
        {
            var test = new TestCadastros();
            Assert.Equal(42, test.GetID());
        }
    }
}
