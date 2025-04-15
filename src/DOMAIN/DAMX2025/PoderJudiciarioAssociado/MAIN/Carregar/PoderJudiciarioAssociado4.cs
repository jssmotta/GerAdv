namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPoderJudiciarioAssociado
{
    public DBPoderJudiciarioAssociado(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro]))
                m_FForo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao]))
                m_FSubDivisao = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo]))
                m_FTipo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal]))
                m_FTribunal = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FAreaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.AreaNome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCidadeNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.CidadeNome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FForoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.ForoNome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBPoderJudiciarioAssociadoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FJusticaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.JusticaNome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSubDivisaoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FTribunalNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.TribunalNome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBPoderJudiciarioAssociado(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro]))
                m_FForo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao]))
                m_FSubDivisao = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo]))
                m_FTipo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal]))
                m_FTribunal = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FAreaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.AreaNome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCidadeNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.CidadeNome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FForoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.ForoNome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBPoderJudiciarioAssociadoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FJusticaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.JusticaNome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSubDivisaoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FTribunalNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.TribunalNome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_PoderJudiciarioAssociado
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[PoderJudiciarioAssociado] (NOLOCK) WHERE [pjaCodigo] = @ThisIDToLoad", oCnn);
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
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FJusticaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.JusticaNome]?.ToString() ?? string.Empty; m_FJusticaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.JusticaNome]?.ToString() ?? string.Empty;  } catch {}  try { m_FJusticaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.JusticaNome]?.ToString() ?? string.Empty; m_FJusticaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.JusticaNome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FJusticaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.JusticaNome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FJusticaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.JusticaNome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAreaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.AreaNome]?.ToString() ?? string.Empty; m_FAreaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.AreaNome]?.ToString() ?? string.Empty;  } catch {}  try { m_FAreaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.AreaNome]?.ToString() ?? string.Empty; m_FAreaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.AreaNome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAreaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.AreaNome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAreaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.AreaNome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal]))
            m_FTribunal = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FTribunalNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.TribunalNome]?.ToString() ?? string.Empty; m_FTribunalNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.TribunalNome]?.ToString() ?? string.Empty;  } catch {}  try { m_FTribunalNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.TribunalNome]?.ToString() ?? string.Empty; m_FTribunalNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.TribunalNome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FTribunalNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.TribunalNome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FTribunalNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.TribunalNome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro]))
            m_FForo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FForoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.ForoNome]?.ToString() ?? string.Empty; m_FForoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.ForoNome]?.ToString() ?? string.Empty;  } catch {}  try { m_FForoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.ForoNome]?.ToString() ?? string.Empty; m_FForoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.ForoNome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FForoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.ForoNome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FForoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.ForoNome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSubDivisaoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome]?.ToString() ?? string.Empty; m_FSubDivisaoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome]?.ToString() ?? string.Empty;  } catch {}  try { m_FSubDivisaoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome]?.ToString() ?? string.Empty; m_FSubDivisaoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSubDivisaoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSubDivisaoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCidadeNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.CidadeNome]?.ToString() ?? string.Empty; m_FCidadeNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.CidadeNome]?.ToString() ?? string.Empty;  } catch {}  try { m_FCidadeNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.CidadeNome]?.ToString() ?? string.Empty; m_FCidadeNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.CidadeNome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCidadeNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.CidadeNome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCidadeNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.CidadeNome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao])) m_FSubDivisao = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao])) m_FSubDivisao = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao])) m_FSubDivisao = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao])) m_FSubDivisao = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao])) m_FSubDivisao = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao]))
            m_FSubDivisao = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo])) m_FTipo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo])) m_FTipo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo])) m_FTipo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo])) m_FTipo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo])) m_FTipo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo]))
            m_FTipo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBPoderJudiciarioAssociadoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPoderJudiciarioAssociadoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBPoderJudiciarioAssociadoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPoderJudiciarioAssociadoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBPoderJudiciarioAssociadoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBPoderJudiciarioAssociadoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_PoderJudiciarioAssociado
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
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Justica]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FJusticaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.JusticaNome]?.ToString() ?? string.Empty; m_FJusticaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.JusticaNome]?.ToString() ?? string.Empty;  } catch {}  try { m_FJusticaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.JusticaNome]?.ToString() ?? string.Empty; m_FJusticaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.JusticaNome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FJusticaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.JusticaNome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FJusticaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.JusticaNome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAreaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.AreaNome]?.ToString() ?? string.Empty; m_FAreaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.AreaNome]?.ToString() ?? string.Empty;  } catch {}  try { m_FAreaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.AreaNome]?.ToString() ?? string.Empty; m_FAreaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.AreaNome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAreaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.AreaNome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAreaNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.AreaNome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal]))
            m_FTribunal = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tribunal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FTribunalNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.TribunalNome]?.ToString() ?? string.Empty; m_FTribunalNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.TribunalNome]?.ToString() ?? string.Empty;  } catch {}  try { m_FTribunalNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.TribunalNome]?.ToString() ?? string.Empty; m_FTribunalNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.TribunalNome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FTribunalNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.TribunalNome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FTribunalNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.TribunalNome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro]))
            m_FForo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Foro]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FForoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.ForoNome]?.ToString() ?? string.Empty; m_FForoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.ForoNome]?.ToString() ?? string.Empty;  } catch {}  try { m_FForoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.ForoNome]?.ToString() ?? string.Empty; m_FForoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.ForoNome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FForoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.ForoNome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FForoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.ForoNome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSubDivisaoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome]?.ToString() ?? string.Empty; m_FSubDivisaoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome]?.ToString() ?? string.Empty;  } catch {}  try { m_FSubDivisaoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome]?.ToString() ?? string.Empty; m_FSubDivisaoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSubDivisaoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSubDivisaoNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCidadeNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.CidadeNome]?.ToString() ?? string.Empty; m_FCidadeNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.CidadeNome]?.ToString() ?? string.Empty;  } catch {}  try { m_FCidadeNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.CidadeNome]?.ToString() ?? string.Empty; m_FCidadeNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.CidadeNome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCidadeNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.CidadeNome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCidadeNome = dbRec[DBPoderJudiciarioAssociadoDicInfo.CidadeNome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao])) m_FSubDivisao = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao])) m_FSubDivisao = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao])) m_FSubDivisao = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao])) m_FSubDivisao = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao])) m_FSubDivisao = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao]))
            m_FSubDivisao = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.SubDivisao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo])) m_FTipo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo])) m_FTipo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo])) m_FTipo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo])) m_FTipo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo])) m_FTipo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo]))
            m_FTipo = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.Tipo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBPoderJudiciarioAssociadoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPoderJudiciarioAssociadoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBPoderJudiciarioAssociadoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPoderJudiciarioAssociadoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBPoderJudiciarioAssociadoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBPoderJudiciarioAssociadoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBPoderJudiciarioAssociadoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBPoderJudiciarioAssociadoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBPoderJudiciarioAssociadoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}