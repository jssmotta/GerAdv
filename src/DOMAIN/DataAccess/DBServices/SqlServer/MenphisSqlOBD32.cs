//using System;
//using System.Data;
//using System.Text; //INSERI!!!

//using Microsoft.Data.SqlClient;

//
namespace MenphisSI.DB;
//{
//    [Serializable]
//    public abstract class MenphisSqlOBD
//    {
//        private string _mLastError;
//        public const string PNullString = " NULL ";
//        public const int PNullID = -1;
//        public const string PexSemUltimoInserido = "N\u00E3o foi poss\u00EDvel obter o \u00FAltimo ID inserido";
//        public const string PexNaoCarregouRegistro = "N\u00E3o foi poss\u00EDvel obter registro com o ID indicado";
//        public const string PexBdblInvalido = "N\u00E3o foi poss\u00EDvel converter o campo string em bool: c\u00F3digo inv\u00E1lido!";
//        protected string mSql;
//        protected string mFieldCodigo;
//        protected int mLastID;
//        public string LastError()
//        {
//            return _mLastError;
//        }
//        protected MenphisSqlOBD(string cSql, string cCampoCodigo)
//        {
//            //m_ID = pNULL_ID;
//            mSql = cSql;
//            mFieldCodigo = cCampoCodigo;
//        }
//        ////////////////////////////////////////////////////////////////////////
//        // métodos abstratos
//        protected abstract void CarregarDadosBd(DataRow dr, MsiSqlConnection conn, SqlTransaction trans);
//        //protected abstract void MontarSQLAtualizacao(StringBuilder sbSQL);
//        //protected abstract void MontarSQLInsercaoCampos(StringBuilder sbSQL);
//        //protected abstract void MontarSQLInsercaoValores(StringBuilder sbSQL);
//        ////////////////////////////////////////////////////////////////////////
//        /// <summary>
//        /// Armazernamento do objeto no banco de dados.
//        /// </summary>
//        /// <param name="conn">Conexão para ser usada no armazenamento.</param>
//        /// <param name="trans">Transação para ser usada no armazenamento.</param>
//        //public bool Armazenar(int nCodigo, MsiSqlConnection conn, SqlTransaction trans)
//        //{
//        //    // verifica se o objeto não existe ainda no banco de dados
//        //    if (nCodigo <= 0) // pNULL_ID)
//        //    {
//        //        // cria objeto no banco de dados => não existe ainda!
//        //        //return Inserir(conn, trans);
//        //    }
//        //    else
//        //    {
//        //        // atualiza objeto no banco de dados => já existe!
//        //       // return Atualizar(nCodigo, conn, trans);
//        //    }
//        //}
//        ////////////////////////////////////////////////////////////////////////
//        /// <summary>
//        /// Inserção do objeto no banco de dados
//        /// </summary>
//        /// <param name="conn">Conexão a ser usada na inserção.</param>
//        /// <param name="trans">Transação a ser usada na inserção.</param>
//        //public bool Excluir(int CurrID, MsiSqlConnection conn, SqlTransaction trans)
//        //{
//        //    StringBuilder sbSQL = new StringBuilder();
//        //    if (CurrID <= 0)
//        //    {
//        //        m_LastError = "Identificador (ID) inválido!";
//        //        return false;
//        //    }
//        //    sbSQL.Append("DELETE FROM ");
//        //    sbSQL.Append(m_Tabela);
//        //    sbSQL.AppendLine(" ");
//        //    sbSQL.Append(" WHERE ");
//        //    sbSQL.Append(m_CampoCodigo);
//        //    sbSQL.Append(" = ");
//        //    sbSQL.Append(CurrID.ToString());
//        //    IDbCommand cmd = conn.CreateCommand();
//        //    cmd.CommandText = sbSQL.ToString();
//        //    if (trans != null)
//        //    {
//        //        cmd.Transaction = trans;
//        //    }
//        //    try
//        //    {
//        //        cmd.Execute NonQuery();
//        //        // sugestão do cássio apesar de eu não usar Id = pNULL_ID;
//        //        return true;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        m_LastError = sbSQL.ToString() + ";" + ex.Message;
//        //        return false;
//        //    }
//        //}
//        ////////////////////////////////////////////////////////////////////////
//        /// <summary>
//        /// Atualização do objeto no banco de dados
//        /// </summary>
//        /// <param name="conn">Conexão a ser usada na atualização.</param>
//        /// <param name="trans">Transação a ser usada na atualização.</param>
//        //protected bool Atualizar(int nCodigo, MsiSqlConnection conn, SqlTransaction trans)
//        //{
//        //    StringBuilder sbSQL = new StringBuilder();
//        //    sbSQL.Append("UPDATE ");
//        //    sbSQL.Append(m_Tabela);
//        //    sbSQL.Append(" SET ");
//        //    MontarSQLAtualizacao(sbSQL);
//        //    sbSQL.AppendLine(string.Empty);
//        //    sbSQL.Append(" WHERE ");
//        //    sbSQL.Append(m_CampoCodigo);
//        //    sbSQL.Append(" = ");
//        //    sbSQL.Append(nCodigo.ToString());
//        //    IDbCommand cmd = conn.CreateCommand();
//        //    cmd.CommandText = sbSQL.ToString();
//        //    if (trans != null)
//        //    {
//        //        cmd.Transaction = trans;
//        //    }
//        //    try
//        //    {
//        //        cmd.Execute NonQuery();
//        //        return true;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        m_LastError = ex.Message;
//        //        return false;
//        //    }
//        //}
//        protected bool ExecuteSql(string cSql, MsiSqlConnection conn, SqlTransaction trans)
//        {
//            using (var cmd = conn.CreateCommand())
//            {
//                cmd.CommandText = cSql;
//                if (trans != null)
//                {
//                    cmd.Transaction = trans;
//                }
//                try
//                {
//                    cmd.ExecuteNonQuery();
//                    //cmd. Dispose(); // 12-03-2014
//                    return true;
//                }
//                catch (Exception ex)
//                {
//                    _mLastError = ex.Message;
//                    return false;
//                }
//            }
//        }
//        ////////////////////////////////////////////////////////////////////////
//        /// <summary>
//        /// Carga do objeto para preenchê-lo com os dados do banco de dados.
//        /// </summary>
//        /// <param name="id">Identificador único do registro na sua entidade no banco de dados.</param>
//        /// <param name="conn">Conexão a ser usada na carga.</param>
//        /// <param name="trans">Transação a ser usada na carga.</param>
//        protected virtual void Carregar(int id, MsiSqlConnection conn, SqlTransaction trans)
//        {
//            var sbSql = new StringBuilder();
//            sbSql.AppendLine(mSql);
//            sbSql.Append(TSql.Where);
//            sbSql.Append(mFieldCodigo);
//            sbSql.Append(value: " = ");
//            sbSql.Append(id);
//            var cmd = conn.CreateCommand();
//            cmd.CommandText = sbSql.ToString();
//            if (trans != null)
//            {
//                cmd.Transaction = trans;
//            }
//            var ds = new DataSet();
//            var adap = ConfiguracoesDBT.GetDataAdapter($"{DevourerOne.SQLNoCount}{cmd.CommandText}", conn, trans, ConfiguracoesDBT.E_TipoSQLCommandTransaction.TipoSelect);

//            adap.Fill(ds);

//            try
//            {
//                if (ds.Tables[0].Rows.Count == 0) return;
//                var dr = ds.Tables[0].Rows[0];
//                CarregarDadosBd(dr, conn, trans);
//            }
//            catch
//            {
//                //falta trapeadores
//                // throw new Exception(pEX_NAO_CARREGOU_REGISTRO);
//            }
//            //dr.Dispose();
//        }
//        ////////////////////////////////////////////////////////////////////////
//        /// <summary>
//        /// Método auxiliar para apoio na criação de listagens para objetos que
//        /// herdaderem de ObjetoBD.
//        /// </summary>
//        /// <param name="conn">Conexão a ser usada na listagem.</param>
//        /// <param name="trans">Transação a ser usada na listagem.</param>
//        /// <param name="filtroWhere">string com o filtro SQL a ser aplicado no WHERE. 
//        /// Caso seja NULL, o método irá trazer todos registros da entidade. Não é necessário
//        /// colocar a palavra "WHERE" pois o próprio metodo já coloca: basta colocar as cláusulas
//        /// com seus devidos operadores lógicos. (e.g. " id_usuario >= 10 AND ds_usuario like '%tete%' ")</param>
//        /// <param name="clausulaOrdenacao">string com a cláusula de ordenação do SQL (ORDER BY).
//        /// Não é necessário colocar a palavra "ORDER BY" pois o próprio método já coloca:
//        /// basta colocar a lista de campos com suas respectivas direções de ordenaçao.
//        /// (e.g. "Usuario.ds_nome ASC, Usuario.ds_sobrenome DESC")</param>
//        /// <returns></returns>
//        //static protected IDataReader GetDataReader(MsiSqlConnection conn, SqlTransaction trans, string tabelaSelect, string camposSelect, string filtroWhere, string clausulaOrdenacao)
//        //{
//        //    StringBuilder sbSQL = new StringBuilder();
//        //    sbSQL.Append(m_SQL);
//        //    sbSQL.AppendLine(tabelaSelect);
//        //    if (filtroWhere != null && filtroWhere.Length > 0)
//        //    {
//        //        sbSQL.Append("WHERE ");
//        //        sbSQL.AppendLine(filtroWhere.ToString());
//        //    }
//        //    if (clausulaOrdenacao != null && clausulaOrdenacao.Length > 0)
//        //    {
//        //        sbSQL.Append("ORDER BY ");
//        //        sbSQL.AppendLine(clausulaOrdenacao.ToString());
//        //    }
//        //    IDbCommand cmd = conn.CreateCommand();
//        //    cmd.CommandText = sbSQL.ToString();
//        //    if (trans != null)
//        //    {
//        //        cmd.Transaction = trans;
//        //    }
//        //    IDataReader dr = cmd.ExecuteReader();
//        //    return dr;
//        //}
//        ////////////////////////////////////////////////////////////////////////
//        //static protected DataSet GetDataSet(MsiSqlConnection conn, SqlTransaction trans, string tabelaSelect, string camposSelect, string filtroWhere, string clausulaOrdenacao)
//        //{
//        //    StringBuilder sbSQL = new StringBuilder();
//        //    sbSQL.Append("SELECT ");
//        //    if (camposSelect != null && camposSelect.Length > 0)
//        //    {
//        //        sbSQL.AppendLine(camposSelect.ToString());
//        //    }
//        //    else
//        //    {
//        //        sbSQL.AppendLine(" *");
//        //    }
//        //    sbSQL.Append("FROM ");
//        //    sbSQL.AppendLine(tabelaSelect);
//        //    if (filtroWhere != null && filtroWhere.Length > 0)
//        //    {
//        //        sbSQL.Append("WHERE ");
//        //        sbSQL.AppendLine(filtroWhere.ToString());
//        //    }
//        //    if (clausulaOrdenacao != null && clausulaOrdenacao.Length > 0)
//        //    {
//        //        sbSQL.Append("ORDER BY ");
//        //        sbSQL.AppendLine(clausulaOrdenacao.ToString());
//        //    }
//        //    IDbCommand cmd = conn.CreateCommand();
//        //    cmd.CommandText = sbSQL.ToString();
//        //    if (trans != null)
//        //    {
//        //        cmd.Transaction = trans;
//        //    }
//        //    DataSet ds = new DataSet();
//        //    IDataAdapter adap = ConfiguracoesDBT.GetDataAdapter(cmd.CommandText, conn, trans, 0);
//        //    adap.Fill(ds);
//        //    return ds;
//        //}
//        protected static DataSet GetDataSet(MsiSqlConnection conn, string cSql, ConfiguracoesDBT.E_TipoSQLCommandTransaction nTipoCmd)
//        {
//            var ds = new DataSet();
//            var adap = ConfiguracoesDBT.GetDataAdapter($"{DevourerOne.SQLNoCount}{cSql}", conn, null, nTipoCmd);
//            try
//            {
//                adap.Fill(ds);
//            }
//            catch (Exception ex)
//            {
//                //string m_LastError = ex.Message.ToString();
//                GeneralSystemErrorTraper.GetError(ex);
//            }
//            return ds;
//        }
//        protected static DataSet GetDataSet(MsiSqlConnection conn, string cSql)
//        {
//            var ds = new DataSet();
//            var adap = ConfiguracoesDBT.GetDataAdapter($"{DevourerOne.SQLNoCount}{cSql}", conn, null, tipoTransSelect: 0);
//            try
//            {
//                adap.Fill(ds);
//            }
//            catch (Exception ex)
//            {                
//                GeneralSystemErrorTraper.GetError(ex);
//            }
//            return ds;
//        }
//        ////////////////////////////////////////////////////////////////////////
//        /// <summary>
//        /// Método de apoio para auxílio na montagem de SQLs
//        /// </summary>
//        /// <param name="str">string a ser formatada no padrão SQL</param>
//        /// <param name="tratarVaziaComoNull">Indica se a string deve ser tratada como se
//        /// o parâmetro fosse NULL caso ele seja uma string vazia (string.Empty).</param>
//        /// <returns>string formatada no padrão SQL, com as aspas literais de acordo
//        /// com o padrão SQL e as aspas delimitadoras de string adicionadas automaticamente
//        /// no início e fim. A string "NULL" será retornada se: o parâmetro str for NULL;
//        /// se o parâmetro str for uma string vazia e tratarVaziaComoNull for true; 
//        /// </returns>
//        /// 
//        protected static string GetSqlBool(bool lIsOn) => lIsOn ? "1" : "0";
//        protected static string YesNoOnThisBD() =>
//#if pFOR_ACCESS
//            return "False"; //Configuracoes.ConnectionString.ToString().IndexOf( value: "SQL") == -1 && Configuracoes.ConnectionString.ToString().ToUpper().IndexOf( value: "GerXAdv".ToUpper()) == -1 ? "False" : "0";            
//#else
//            "False";
//#endif

//        protected static string GetSqlStringSearchLike(string cSearch)
//        {
//            if (cSearch == null)
//            {
//                return "''";
//            }
//            else if (cSearch.Equals(string.Empty))
//            {
//                return "''";
//            }
//            return "'%" + cSearch.Replace("'", "''") + "%'";
//        }
//        protected static string GetSqlString(string str, bool tratarVaziaComoNull)
//        {
//            if (str == null)
//            {
//                return PNullString;
//            }
//            else if (str.Equals(string.Empty) && tratarVaziaComoNull)
//            {
//                return PNullString;
//            }
//            var sbString = new StringBuilder();
//            sbString.Append(str);
//            sbString.Replace("'", "''");
//            sbString.Insert(0, "'");
//            sbString.Append("'");
//            return sbString.ToString();
//        }
//        protected static string GetSqlDateTime(DateTime? dData)
//        {
//            if (dData == null)
//            {
//                return PNullString;
//            }
//            else
//            {
//                var cRet = new StringBuilder();
//                cRet.Append("'");
//                cRet.Append(Convert.ToDateTime(dData).ToString(format: "yyyy-MM-dd HH:mm:ss"));
//                cRet.Append("'");
//                return cRet.ToString();
//            }
//        }
//        protected int ObtemUltimoIDInserido(MsiSqlConnection conn, SqlTransaction trans)
//        {
//            var ret = -1;
//            var sbSql = new StringBuilder();
//            sbSql.Append("SELECT @@identity as ID");
//            var cmd = conn.CreateCommand();
//            cmd.CommandText = sbSql.ToString();
//            if (trans != null)
//            {
//                cmd.Transaction = trans;
//            }
//            var obj = cmd.ExecuteScalar();
//            if (!DBNull.Value.Equals(obj))
//            {
//                ret = Convert.ToInt32(obj);
//            }
//            else
//            {
//                throw new Exception(PexSemUltimoInserido);
//            }
//            return ret;
//        }
//        protected int GetNextID(string cNomeTable, string cNomeCampoCodigo, MsiSqlConnection conn, SqlTransaction trans)
//        {
//            var ret = -1;
//            var cSql = new StringBuilder();
//            cSql.Append("SELECT TOP (1) ");
//            cSql.Append(cNomeCampoCodigo);
//            cSql.Append(" FROM ");
//            cSql.Append(cNomeTable);
//            cSql.Append(" ORDER BY ");
//            cSql.Append(cNomeCampoCodigo.SqlOrderDesc());
//            var cmd = conn.CreateCommand();
//            cmd.CommandText = cSql.ToString();
//            cmd.CommandType = CommandType.Text;
//            cmd.Transaction = trans;
//            var dr = cmd.ExecuteReader();
//            if (dr.Read())
//            {
//                if (dr[cNomeCampoCodigo]?.ToString()?.IsEqual(string.Empty) ?? false)
//                {
//                    ret = 1;
//                }
//                else
//                {
//                    ret = Convert.ToInt32(dr[cNomeCampoCodigo]);
//                }
//            }
//            return ++ret;
//        }
//        protected void CarregaData(ref DateTime? dData, object oData)
//        {
//            if (!DBNull.Value.Equals(oData)) { dData = Convert.ToDateTime(oData); }
//        }
//        public int IDAdded => mLastID;
//        public string SqlQuery => mSql;
//        public string FieldCodigo
//        {
//            get => mFieldCodigo;
//            set => mFieldCodigo = value;
//        }
//        public void WaitUpdate() => System.Threading.Thread.Sleep(millisecondsTimeout: 2000);
//    }
//}
