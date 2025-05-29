namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBEndTit
{
    public DBEndTit(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Endereco]))
                m_FEndereco = Convert.ToInt32(dbRec[DBEndTitDicInfo.Endereco]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Titulo]))
                m_FTitulo = Convert.ToInt32(dbRec[DBEndTitDicInfo.Titulo]);
        }
        catch
        {
        }
    }

    public DBEndTit(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Endereco]))
                m_FEndereco = Convert.ToInt32(dbRec[DBEndTitDicInfo.Endereco]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Titulo]))
                m_FTitulo = Convert.ToInt32(dbRec[DBEndTitDicInfo.Titulo]);
        }
        catch
        {
        }
    }

#region CarregarDados_EndTit
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [ettCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
        cmd.Parameters.AddWithValue("@ThisIDToLoad", id);
        using var ds = ConfiguracoesDBT.GetDataTable(cmd, CommandBehavior.SingleRow, oCnn);
        if (ds != null)
            CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
    }

    public void CarregarDadosBd(DataRow? dbRec)
    {
        if (dbRec == null)
            return;
#if (fastAndSecureCode)
try
{
#endif
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
#if (DEBUG)
if (ID == 0)
{
throw new Exception($"ID==0: {TabelaNome}");
}
#endif
#if (fastAndSecureCode)
} 
catch
{
try { ID = Convert.ToInt32(dbRec[CampoCodigo]); } catch { } 
}

#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Endereco])) m_FEndereco = Convert.ToInt32(dbRec[DBEndTitDicInfo.Endereco]); if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Endereco])) m_FEndereco = Convert.ToInt32(dbRec[DBEndTitDicInfo.Endereco]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Endereco])) m_FEndereco = Convert.ToInt32(dbRec[DBEndTitDicInfo.Endereco]); if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Endereco])) m_FEndereco = Convert.ToInt32(dbRec[DBEndTitDicInfo.Endereco]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Endereco])) m_FEndereco = Convert.ToInt32(dbRec[DBEndTitDicInfo.Endereco]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Endereco]))
            m_FEndereco = Convert.ToInt32(dbRec[DBEndTitDicInfo.Endereco]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Titulo])) m_FTitulo = Convert.ToInt32(dbRec[DBEndTitDicInfo.Titulo]); if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Titulo])) m_FTitulo = Convert.ToInt32(dbRec[DBEndTitDicInfo.Titulo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Titulo])) m_FTitulo = Convert.ToInt32(dbRec[DBEndTitDicInfo.Titulo]); if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Titulo])) m_FTitulo = Convert.ToInt32(dbRec[DBEndTitDicInfo.Titulo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Titulo])) m_FTitulo = Convert.ToInt32(dbRec[DBEndTitDicInfo.Titulo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Titulo]))
            m_FTitulo = Convert.ToInt32(dbRec[DBEndTitDicInfo.Titulo]);
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_EndTit
    public void CarregarDadosBd(SqlDataReader? dbRec)
    {
        if (dbRec == null)
            return;
#if (fastAndSecureCode)
try
{
#endif
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
#if (DEBUG)
if (ID == 0)
{
throw new Exception($"ID==0: {TabelaNome}");
}
#endif
#if (fastAndSecureCode)
} 
catch
{
try { ID = Convert.ToInt32(dbRec[CampoCodigo]); } catch { } 
}

#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Endereco])) m_FEndereco = Convert.ToInt32(dbRec[DBEndTitDicInfo.Endereco]); if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Endereco])) m_FEndereco = Convert.ToInt32(dbRec[DBEndTitDicInfo.Endereco]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Endereco])) m_FEndereco = Convert.ToInt32(dbRec[DBEndTitDicInfo.Endereco]); if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Endereco])) m_FEndereco = Convert.ToInt32(dbRec[DBEndTitDicInfo.Endereco]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Endereco])) m_FEndereco = Convert.ToInt32(dbRec[DBEndTitDicInfo.Endereco]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Endereco]))
            m_FEndereco = Convert.ToInt32(dbRec[DBEndTitDicInfo.Endereco]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Titulo])) m_FTitulo = Convert.ToInt32(dbRec[DBEndTitDicInfo.Titulo]); if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Titulo])) m_FTitulo = Convert.ToInt32(dbRec[DBEndTitDicInfo.Titulo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Titulo])) m_FTitulo = Convert.ToInt32(dbRec[DBEndTitDicInfo.Titulo]); if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Titulo])) m_FTitulo = Convert.ToInt32(dbRec[DBEndTitDicInfo.Titulo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Titulo])) m_FTitulo = Convert.ToInt32(dbRec[DBEndTitDicInfo.Titulo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEndTitDicInfo.Titulo]))
            m_FTitulo = Convert.ToInt32(dbRec[DBEndTitDicInfo.Titulo]);
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}