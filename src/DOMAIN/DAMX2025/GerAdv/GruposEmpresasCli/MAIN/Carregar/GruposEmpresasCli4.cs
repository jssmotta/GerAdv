namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGruposEmpresasCli
{
    public DBGruposEmpresasCli(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Grupo]))
                m_FGrupo = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Grupo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Oculto]))
                m_FOculto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Oculto];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Visto];
        }
        catch
        {
        }
    }

    public DBGruposEmpresasCli(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Grupo]))
                m_FGrupo = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Grupo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Oculto]))
                m_FOculto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Oculto];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Visto];
        }
        catch
        {
        }
    }

#region CarregarDados_GruposEmpresasCli
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [gecCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Grupo]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Grupo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Grupo]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Grupo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Grupo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Grupo]))
            m_FGrupo = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Grupo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Oculto])) m_FOculto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Oculto]; if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Oculto])) m_FOculto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Oculto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Oculto])) m_FOculto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Oculto]; if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Oculto])) m_FOculto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Oculto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Oculto])) m_FOculto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Oculto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Oculto]))
            m_FOculto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Oculto];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_GruposEmpresasCli
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
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Grupo]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Grupo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Grupo]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Grupo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Grupo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Grupo]))
            m_FGrupo = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Grupo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Oculto])) m_FOculto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Oculto]; if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Oculto])) m_FOculto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Oculto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Oculto])) m_FOculto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Oculto]; if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Oculto])) m_FOculto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Oculto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Oculto])) m_FOculto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Oculto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Oculto]))
            m_FOculto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Oculto];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBGruposEmpresasCliDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBGruposEmpresasCliDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Visto])) m_FVisto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBGruposEmpresasCliDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBGruposEmpresasCliDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}