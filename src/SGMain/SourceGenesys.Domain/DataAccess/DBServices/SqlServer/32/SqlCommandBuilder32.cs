namespace MenphisSI;

public partial class DBToolWTable32
{
    #region Inner Classes

    private class SqlCommandBuilder32
    {
        private readonly DBToolWTable32 _parent;
        private readonly MsiSqlConnection? _connection;

        public SqlCommandBuilder32(DBToolWTable32 parent, MsiSqlConnection? connection)
        {
            _parent = parent;
            _connection = connection;
        }

        public StringBuilder BuildInsertCommand()
        {
            var cPreSql = string.Join(",", _parent._mSqlPre);
            var cPosSql = string.Join(",", _parent._mSqlPos);

            return new StringBuilder($"set dateformat ymd; INSERT INTO {_parent.Table.dbo(_connection)} ({cPreSql}) VALUES ({cPosSql});");
        }

        public StringBuilder BuildUpdateCommand()
        {
            var cPreSql = string.Join(",", _parent._mSqlPre);
            var cSql = new StringBuilder("UPDATE ");

            if (_parent.Where.NãoContemUpper(" IN "))
                cSql.Append(" TOP (1) ");

            cSql.Append($"{_parent.Table.dbo(_connection)} SET {cPreSql} WHERE {_parent.Where};");
            cSql.Insert(0, "set dateformat ymd;");

            return cSql;
        }
    }
    #endregion
}
