namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOperadorGrupo
{
    public DBOperadorGrupo(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Grupo]))
                m_FGrupo = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Grupo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Inativo]))
                m_FInativo = (bool)dbRec[DBOperadorGrupoDicInfo.Inativo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOperadorGrupoDicInfo.Visto];
        }
        catch
        {
        }
    }

    public DBOperadorGrupo(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Grupo]))
                m_FGrupo = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Grupo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Inativo]))
                m_FInativo = (bool)dbRec[DBOperadorGrupoDicInfo.Inativo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOperadorGrupoDicInfo.Visto];
        }
        catch
        {
        }
    }

#region CarregarDados_OperadorGrupo
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[OperadorGrupo] (NOLOCK) WHERE [ogrCodigo] = @ThisIDToLoad", oCnn);
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
if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Grupo]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Grupo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Grupo]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Grupo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Grupo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Grupo]))
            m_FGrupo = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Grupo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBOperadorGrupoDicInfo.Inativo]; if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBOperadorGrupoDicInfo.Inativo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBOperadorGrupoDicInfo.Inativo]; if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBOperadorGrupoDicInfo.Inativo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBOperadorGrupoDicInfo.Inativo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Inativo]))
            m_FInativo = (bool)dbRec[DBOperadorGrupoDicInfo.Inativo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGrupoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGrupoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGrupoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGrupoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGrupoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBOperadorGrupoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_OperadorGrupo
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
if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Grupo]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Grupo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Grupo]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Grupo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Grupo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Grupo]))
            m_FGrupo = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.Grupo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBOperadorGrupoDicInfo.Inativo]; if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBOperadorGrupoDicInfo.Inativo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBOperadorGrupoDicInfo.Inativo]; if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBOperadorGrupoDicInfo.Inativo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBOperadorGrupoDicInfo.Inativo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Inativo]))
            m_FInativo = (bool)dbRec[DBOperadorGrupoDicInfo.Inativo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBOperadorGrupoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBOperadorGrupoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGrupoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGrupoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGrupoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGrupoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOperadorGrupoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOperadorGrupoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBOperadorGrupoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}