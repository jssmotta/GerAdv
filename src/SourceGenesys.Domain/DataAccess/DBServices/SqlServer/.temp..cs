/////
///// Histórico:
///// 18-02-2014 3.0.0 Removidas funções que estavam em desuso
///// 16/07/2012 2.0.4 DevourerOne.WriteLogNT
///// 13/08/2015 - nTestUnit
///// 30-05-2015 - MsiSqlConnection Only
//using System;
//
//using Microsoft.Data.SqlClient; //INSERI!!!
//using System.Text;
//
namespace MenphisSI.DB;
//{
//    /// <summary>
//    /// Gravação de Dados e recuperação de registros
//    /// </summary>
//    [Serializable]
//    public abstract class MenphisOBD
//    {
//        private string mLastError;
//        public const string PNullString = " NULL ";
//        public const long PNullID = -1;
//        public const string PexSemUltimoInserido = "Não foi possível obter o último ID inserido";
//        public const string PexNaoCarregouRegistro = "Não foi possível obter registro com o ID indicado";
//        public const string PexBdblInvalido = "Não foi possível converter o campo string em bool: código inválido!";
//        protected string mTabelaNome;
//        protected string mFieldCodigo;
//        protected long mLastID;
//        public string LastError()
//        {
//            return mLastError;
//        }
//        /// <summary>
//        /// Criação do Objeto
//        /// </summary>
//        /// <param name="cTabela"></param>
//        /// <param name="cCampoCodigo"></param>
//        protected MenphisOBD(string cTabela, string cCampoCodigo)
//        {
//            //m_ID = pNULL_ID;
//            mTabelaNome = cTabela;
//            mFieldCodigo = cCampoCodigo;
//        }
//        ////////////////////////////////////////////////////////////////////////
//        // métodos abstratos
//        /// <summary>
//        /// Carregar DataRow
//        /// </summary>        
//        /// <param name="dr"></param>
//        /// <param name="conn"></param>
//        /// <param name="trans"></param>
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
//        //public bool Armazenar(long nCodigo, MsiSqlConnection conn, SqlTransaction trans)
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
//        //public bool Excluir(long CurrID, MsiSqlConnection conn, SqlTransaction trans)
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
//        //protected bool Atualizar(long nCodigo, MsiSqlConnection conn, SqlTransaction trans)
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
//        /// <summary>
//        /// Executar um SQL
//        /// </summary>
//        /// <param name="cSql"></param>
//        /// <param name="conn"></param>
//        /// <param name="trans"></param>
//        /// <returns></returns>
//        internal bool ExecuteSql(string cSql, MsiSqlConnection conn, SqlTransaction trans)
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
//                    mLastError = ex.Message;
//                    return false;
//                }
//            }
//        }
//        ////////////////////////////////////////////////////////////////////////
//        /// <summary>
//        /// Carga do objeto para preenchê-lo com os dados do banco de dados.
//        /// </summary>
//        /// <param name="id">Identificador único do registro na sua entidade no banco de dados.</param>
//        /// <param name="oCnn">Conexão a ser usada na carga.</param>
//        /// <param name="oTrans">Transação a ser usada na carga.</param>
//        protected virtual void Carregar(long id, MsiSqlConnection? oCnn, SqlTransaction? oTrans)
//        {
//            if (id == 0) { return; }
//            var sbSql = new StringBuilder();
//            sbSql.Append("SELECT TOP (1) ");
//            sbSql.Append(mTabelaNome);
//            sbSql.Append(".* ");
//            sbSql.Append(" FROM ");
//            sbSql.Append(mTabelaNome);
//            sbSql.Append(" WHERE ");
//            sbSql.Append(mFieldCodigo);
//            sbSql.Append("=");
//            sbSql.Append(id);
//            //if (m_TabelaNome.IndexOf( value: "SHADOWS") == 0)
//            //{
//            //    ///A Lixeira recolhe o último registro
//            //    sbSQL.Append(" ORDER BY shadowCodigo DESC");
//            //}
//            var cmd = oCnn.CreateCommand();
//            cmd.CommandText = $"{DevourerOne.SQLNoCount}{sbSql}";
//            if (oTrans != null)
//            {
//                cmd.Transaction = oTrans;
//            }
//            using (var ds = new DataSet())
//            {
//                var adap = ConfiguracoesDBT.GetDataAdapter(cmd.CommandText, oCnn, oTrans, ConfiguracoesDBT.E_TipoSQLCommandTransaction.TipoSelect);
//                try
//                {
//                    adap.Fill(ds);
//                    try
//                    {
//                        if (ds.Tables[0].Rows.Count == 1)
//                        {
//                            CarregarDadosBd(ds.Tables[0].Rows[0], oCnn, oTrans);
//                        }
//                        //else if (id == 0)
//                        //{
//                        //    DevourerOne.WriteLogNT(PexNaoCarregouRegistro + "-" + TabelaNome + "-id:" + id.ToString(), System.Diagnostics.EventLogEntryType.Error, iD: 4500);
//                        //}
//                    }
//                    catch //(Exception ex)
//                    {
//                        //if (id == 0)
//                        //{
//                        //    DevourerOne.WriteLogNT("Erro em na leitura -" + TabelaNome + "-id:" + id.ToString() + " - retornou:" + ex.Message + "-stack:" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error, iD: 4502);
//                        //}
//                    }
//                }
//                catch //(Exception ex)
//                {
//                    //if (id == 0)
//                    //{
//                    //    DevourerOne.WriteLogNT("Erro em MenphisODB 2.0 (DBx.DLL) - " + TabelaNome + "-id:" + id.ToString() + " - retornou:" + ex.Message, System.Diagnostics.EventLogEntryType.Error, iD: 4501);
//                    //}
//                    //throw new Exception(ex.Message);
//                }
//            }
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
//        protected static SqlDataReader GetDataReader(MsiSqlConnection conn, SqlTransaction trans, string tabelaSelect, string camposSelect, string filtroWhere, string clausulaOrdenacao)
//        {
//            var sbSQL = new StringBuilder();
//            sbSQL.Append("SELECT ");
//            if (camposSelect != null && camposSelect.Length > 0)
//            {
//                sbSQL.AppendLine(camposSelect.ToString());
//            }
//            else
//            {
//                sbSQL.AppendLine(value: " *");
//            }
//            sbSQL.Append(" FROM ");
//            sbSQL.AppendLine(tabelaSelect);
//            if (filtroWhere != null && filtroWhere.Length > 0)
//            {
//                sbSQL.Append(" WHERE ");
//                sbSQL.AppendLine(filtroWhere.ToString());
//            }
//            if (clausulaOrdenacao != null && clausulaOrdenacao.Length > 0)
//            {
//                sbSQL.Append(" ORDER BY ");
//                sbSQL.AppendLine(clausulaOrdenacao.ToString());
//            }
//            var cmd = conn.CreateCommand();
//            cmd.CommandText = sbSQL.ToString();
//            if (trans != null)
//            {
//                cmd.Transaction = trans;
//            }
//            var dr = cmd.ExecuteReader();
//            return dr;
//        }
//        /// <summary>
//        /// Retorna um DataSet
//        /// </summary>
//        /// <param name="conn"></param>
//        /// <param name="trans"></param>
//        /// <param name="tabelaSelect"></param>
//        /// <param name="camposSelect"></param>
//        /// <param name="filtroWhere"></param>
//        /// <param name="clausulaOrdenacao"></param>
//        /// <returns></returns>
//        protected static DataSet GetDataSet(MsiSqlConnection conn, SqlTransaction trans, string tabelaSelect, string camposSelect, string filtroWhere, string clausulaOrdenacao)
//        {
//            var sbSQL = new StringBuilder();
//            sbSQL.Append("SELECT ");
//            if (camposSelect != null && camposSelect.Length > 0)
//            {
//                sbSQL.AppendLine(camposSelect.ToString());
//            }
//            else
//            {
//                sbSQL.AppendLine(value: " *");
//            }
//            sbSQL.Append(" FROM ");
//            sbSQL.AppendLine(tabelaSelect);
//            if (filtroWhere != null && filtroWhere.Length > 0)
//            {
//                sbSQL.Append(" WHERE ");
//                sbSQL.AppendLine(filtroWhere.ToString());
//            }
//            if (clausulaOrdenacao != null && clausulaOrdenacao.Length > 0)
//            {
//                sbSQL.Append(" ORDER BY ");
//                sbSQL.AppendLine(clausulaOrdenacao.ToString());
//            }
//            var cmd = conn.CreateCommand();
//            cmd.CommandText = sbSQL.ToString();
//            if (trans != null)
//            {
//                cmd.Transaction = trans;
//            }
//            var ds = new DataSet();
//            var adap = ConfiguracoesDBT.GetDataAdapter($"{DevourerOne.SQLNoCount}{cmd.CommandText}", conn, trans, tipoTransSelect: 0);
//            adap.Fill(ds);
//            try
//            {
//                if (-2 != ds.Tables[0].Rows.Count) { return new(); }
//            }
//            catch //(Exception ex)
//            {
//                // DevourerOne.SendMess2MasterAnyWhere(mensagem: "ERRO GetDataSet (ODB3.1)", ex: ex);
//                throw new Exception(message: "ERRO GetDataSet");
//            }
//            return ds;
//        }
//        /// <summary>
//        /// Retorna um DataSet rápido
//        /// </summary>
//        /// <param name="nTops"></param>
//        /// <param name="conn"></param>
//        /// <param name="tabelaSelect"></param>
//        /// <param name="filtroWhere"></param>
//        /// <returns></returns>
//        protected static DataSet QuickGetDataSet(int nTops, MsiSqlConnection conn, string tabelaSelect, string filtroWhere)
//        {
//            var sbSQL = new StringBuilder();
//            sbSQL.Append("SELECT top ");
//            sbSQL.Append(nTops);
//            sbSQL.Append("  * ");
//            sbSQL.Append(" FROM ");
//            sbSQL.AppendLine(tabelaSelect);
//            sbSQL.Append(" WHERE ");
//            sbSQL.AppendLine(filtroWhere.ToString());
//            var cmd = conn.CreateCommand();
//            cmd.CommandText = sbSQL.ToString();
//            var ds = new DataSet();
//            var adap = ConfiguracoesDBT.GetDataAdapter(cmd.CommandText, conn, trans: null, tipoTransSelect: 0);
//            adap.Fill(ds);
//            try
//            {
//                if (-2 == ds.Tables[0].Rows.Count) { return new(); }
//            }
//            catch ///(Exception ex)
//            {
//                //DevourerOne.SendMess2MasterAnyWhere(mensagem: "ERRO GetDataSet (ODB3.2)", ex: ex);
//                throw new Exception(message: "ERRO GetDataSet");
//            }
//            return ds;
//        }

//        /// <summary>
//        /// Retorna um DataSet rápido
//        /// </summary>
//        /// <param name="conn"></param>
//        /// <param name="tabelaSelect"></param>
//        /// <param name="filtroWhere"></param>
//        /// <returns></returns>
//        protected static DataSet QuickGetDataSet(MsiSqlConnection conn, string tabelaSelect, string filtroWhere)
//        {
//            var sbSql = new StringBuilder();
//            sbSql.Append("SELECT  * ");
//            sbSql.Append(" FROM ");
//            sbSql.AppendLine(tabelaSelect);
//            sbSql.Append(" WHERE ");
//            sbSql.AppendLine(filtroWhere.ToString());
//            var cmd = conn.CreateCommand();
//            cmd.CommandText = sbSql.ToString();
//            var ds = new DataSet();
//            var adap = ConfiguracoesDBT.GetDataAdapter($"{DevourerOne.SQLNoCount}{cmd.CommandText}", conn, trans: null, tipoTransSelect: 0);
//            adap.Fill(ds);
//            try
//            {
//                if (-2 == ds.Tables[0].Rows.Count) { return new(); }
//            }
//            catch //(Exception ex)
//            {
//                //DevourerOne.SendMess2MasterAnyWhere(mensagem: "ERRO GetDataSet (ODB3.4)", ex: ex);
//                throw new Exception(message: "ERRO GetDataSet");
//            }
//            return ds;
//        }
//        public static DataSet ListarDs(string tabela, string cSqlMain, string cWhere, string cOrder, MsiSqlConnection? oCnn)
//        {
//            var cSql = new StringBuilder();
//            if (!cSqlMain.Equals(string.Empty))
//            {
//                cSql.Append(cSqlMain);
//            }
//            else
//            {
//                cSql.Append("SELECT * FROM " + tabela);
//                if (!cWhere.Equals(string.Empty))
//                {
//                    if (cWhere.ToUpper().IndexOf(" WHERE ", StringComparison.Ordinal) == -1) { cSql.Append(" WHERE "); }
//                    cSql.Append(cWhere);
//                }
//                if (!cOrder.Equals(string.Empty))
//                {
//                    if (cOrder.ToUpper().IndexOf(" ORDER BY ", StringComparison.Ordinal) == -1) { cSql.Append(" ORDER BY "); }
//                    cSql.Append(cOrder);
//                }
//                //else
//                //{
//                //    cSQL.Append(" ORDER BY acaDescricao");
//                //}
//            }
//            return GetDataSet(oCnn, cSQL: cSql.ToString(), nTipoCMD: 0);
//        }
//        /// <summary>
//        /// Retorna um DataSet
//        /// </summary>
//        /// <param name="conn"></param>
//        /// <param name="trans"></param>
//        /// <param name="cSQL"></param>
//        /// <param name="nTipoCMD"></param>
//        /// <returns></returns>
//        protected static DataSet GetDataSet(MsiSqlConnection conn, string cSQL, ConfiguracoesDBT.E_TipoSQLCommandTransaction nTipoCMD)
//        {
//            var ds = new DataSet();
//            var adap = ConfiguracoesDBT.GetDataAdapter($"{DevourerOne.SQLNoCount}{cSQL}", conn, null, nTipoCMD);
//            //try
//            {
//                adap.Fill(ds);
//            }
//            //catch (Exception ex)
//            //{
//            //    var m_LastError = ex.Message.ToString();
//            //    return new();
//            //}
//            try
//            {
//                if (-2 == ds.Tables[0].Rows.Count) { return new(); }
//            }
//            catch //(Exception ex)
//            {
//                //DevourerOne.SendMess2MasterAnyWhere(mensagem: "ERRO GetDataSet (ODB3.4)", ex: ex);
//                throw new Exception(message: "ERRO GetDataSet");
//            }
//            return ds;
//        }
//        /// <summary>
//        /// Retorna um DataSet
//        /// </summary>
//        /// <param name="conn"></param>
//        /// <param name="trans"></param>
//        /// <param name="cSql"></param>
//        /// <returns></returns>
//        protected static DataSet GetDataSet(MsiSqlConnection conn, string cSql)
//        {
//            var ds = new DataSet();
//            var adap = ConfiguracoesDBT.GetDataAdapter($"{DevourerOne.SQLNoCount}{cSql}", conn, null, tipoTransSelect: 0);
//            try
//            {
//                adap.Fill(ds);
//            }
//            catch //(Exception ex)
//            {
//                //string m_LastError = ex.Message.ToString();
//                return new();
//            }
//            try
//            {
//                if (-2 == ds.Tables[0].Rows.Count) { return new(); }
//            }
//            catch //(Exception ex) 
//            {
//                //DevourerOne.SendMess2MasterAnyWhere(mensagem: "ERRO GetDataSet (ODB3)", ex: ex);
//                throw new Exception(message: "ERRO GetDataSet");
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
//        //protected static string GetSQLBool(bool lIsOn)
//        //{
//        //    return lIsOn ? "1" : "0";
//        //}
//        //protected static string yesNoOnThisBD()
//        //{
//        //    return "False";
//        //}
//        protected static string GetSQLStringSearchLike(string cSearch)
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
//        /// <summary>
//        /// Retorna a string com ' para gravação
//        /// </summary>
//        /// <param name="str"></param>
//        /// <param name="tratarVaziaComoNull"></param>
//        /// <returns></returns>
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
//        //protected static string GetSQLDateTime(DateTime? dData)
//        //{
//        //    if (dData == null)
//        //    {
//        //        return pNULL_STRING;
//        //    }
//        //    else
//        //    {
//        //        var cRet = new StringBuilder();
//        //        cRet.Append("'");
//        //        cRet.Append(Convert.ToDateTime(dData).ToString("yyyy-MM-dd HH:mm:ss"));
//        //        cRet.Append("'");
//        //        return cRet.ToString();
//        //    }
//        //}
//        /// <summary>
//        /// Nunca foi usado
//        /// </summary>
//        /// <param name="conn"></param>
//        /// <param name="trans"></param>
//        /// <returns></returns>
//        protected long ObtemUltimoIDInserido(MsiSqlConnection conn, SqlTransaction trans)
//        {
//            long ret = -1;
//            var sbSQL = new StringBuilder();
//            sbSQL.Append("SELECT @@identity as ID");
//            var cmd = conn.CreateCommand();
//            cmd.CommandText = sbSQL.ToString();
//            if (trans != null)
//            {
//                cmd.Transaction = trans;
//            }
//            var obj = cmd.ExecuteScalar();
//            if (!DBNull.Value.Equals(obj))
//            {
//                ret = Convert.ToInt64(obj);
//            }
//            else
//            {
//                throw new Exception(PexSemUltimoInserido);
//            }
//            return ret;
//        }
//        //protected long GetNextID(string cNomeTable, string cNomeCampoCodigo, MsiSqlConnection conn, SqlTransaction trans)
//        //{
//        //    long ret = -1;
//        //    var cSQL = new StringBuilder();
//        //    cSQL.Append("SELECT TOP (1) ");
//        //    cSQL.Append(cNomeCampoCodigo);
//        //    cSQL.Append(" FROM ");
//        //    cSQL.Append(cNomeTable);
//        //    cSQL.Append(" ORDER BY ");
//        //    cSQL.Append(cNomeCampoCodigo);
//        //    cSQL.Append(" DESC ");
//        //    IDbCommand cmd = conn.CreateCommand();
//        //    cmd.CommandText = cSQL.ToString();
//        //    cmd.CommandType = CommandType.Text;
//        //    cmd.Transaction = trans;
//        //    IDataReader dr = cmd.ExecuteReader();
//        //    if (dr.Read())
//        //    {
//        //        if (dr[cNomeCampoCodigo].ToString().Equals(string.Empty))
//        //        {
//        //            ret = 1;
//        //        }
//        //        else
//        //        {
//        //            ret = Convert.ToInt64(dr[cNomeCampoCodigo]);
//        //        }
//        //    }
//        //    return ++ret;
//        //}
//        //protected void CarregaData(ref DateTime? dData, object oData)
//        //{
//        //    if (!DBNull.Value.Equals(oData)) { dData = Convert.ToDateTime(oData); }
//        //}
//        //public long IDAdded
//        //{
//        //    get { return m_LastID; }
//        //}
//        public string TabelaNome
//        {
//            get { return mTabelaNome; }
//        }
//        public string FieldCodigo
//        {
//            get { return mFieldCodigo; }
//        }
//        //public void WaitUpdate()
//        //{
//        //    System.Threading.Thread.Sleep(2000);
//        //}
//    }
//}

