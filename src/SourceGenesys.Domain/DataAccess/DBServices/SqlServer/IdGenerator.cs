namespace MenphisSI;

public partial class DBToolWTable32
{
    private class IdGenerator
    {
        private readonly DBToolWTable32 _parent;
        private readonly MsiSqlConnection _connection;

        public IdGenerator(DBToolWTable32 parent, MsiSqlConnection connection)
        {
            _parent = parent;
            _connection = connection;
        }

        public void GenerateNewId(SqlTransaction? oTrans, bool addCampoCodigo = false)
        {
            const int maxRetries = 10;
            var retryCount = 0;

            while (true)
            {
                if (retryCount++ >= maxRetries)
                    throw new Exception("Não foi possível gerar um ID único após várias tentativas");

                GenerateNewIdValue(oTrans);

                if (IsIdUnique(oTrans))
                    break;
            }

            if (addCampoCodigo)
            {
                _parent.Fields(_parent.CampoCodigo, _parent._mID, ETiposCampos.FNumber);
            }
        }

        private void GenerateNewIdValue(SqlTransaction? oTrans)
        {
            var cSqlC = $"SELECT MAX({_parent.CampoCodigo}) FROM {_parent.Table.dbo(_connection)} WITH (UPDLOCK, HOLDLOCK);";

            using var cmd = new SqlCommand(cSqlC, _connection?.InnerConnection);
            if (oTrans != null)
                cmd.Transaction = oTrans;

            var result = cmd.ExecuteScalar();
            _parent._mID = result != DBNull.Value ? Convert.ToInt32(result) : 0;
            _parent._mID += SRandom();
        }

        private bool IsIdUnique(SqlTransaction? oTrans)
        {
            try
            {
                using var cmd = new SqlCommand(
                    $"IF NOT EXISTS (SELECT 1 FROM {_parent.Table.dbo(_connection)} WITH (UPDLOCK, HOLDLOCK) WHERE {_parent.CampoCodigo} = @id) " +
                    $"BEGIN /* Sucesso - ID está livre */ SELECT 0; END " +
                    $"ELSE BEGIN /* Falha - ID já existe */ SELECT 1; END",
                    _connection?.InnerConnection
                );

                cmd.Parameters.AddWithValue("@id", _parent._mID);
                if (oTrans != null)
                    cmd.Transaction = oTrans;

                return (int)cmd.ExecuteScalar() == 0;
            }
            catch
            {
                return false;
            }
        }

        public int GetLastInsertedId(SqlTransaction? trans)
        {
            if (_parent.Identity)
                return _parent.ObtemUltimoIDInserido(_connection, trans);

            if (_parent.CampoCodigo.NotIsEmpty())
            {
                using var cmdX = new SqlCommand($"SELECT TOP (1) {_parent.CampoCodigo} FROM {_parent.Table.dbo(_connection)} ORDER BY {_parent.CampoCodigo.SqlOrderDesc()};", _connection?.InnerConnection)
                {
                    Transaction = trans
                };
                var ret = cmdX.ExecuteScalar();
                return ret != null && !DBNull.Value.Equals(ret) ? Convert.ToInt32(ret.ToString()) : 0;
            }

            return 0;
        }
    }
  
}
