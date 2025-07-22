namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBReuniaoPessoas
{
    public DBReuniaoPessoas(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Reuniao]))
                m_FReuniao = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Reuniao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBReuniaoPessoasDicInfo.Visto];
        }
        catch
        {
        }
    }

    public DBReuniaoPessoas(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Reuniao]))
                m_FReuniao = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Reuniao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBReuniaoPessoasDicInfo.Visto];
        }
        catch
        {
        }
    }

#region CarregarDados_ReuniaoPessoas
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [rnpCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Reuniao])) m_FReuniao = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Reuniao]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Reuniao])) m_FReuniao = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Reuniao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Reuniao])) m_FReuniao = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Reuniao]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Reuniao])) m_FReuniao = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Reuniao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Reuniao])) m_FReuniao = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Reuniao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Reuniao]))
            m_FReuniao = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Reuniao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBReuniaoPessoasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBReuniaoPessoasDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBReuniaoPessoasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBReuniaoPessoasDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBReuniaoPessoasDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBReuniaoPessoasDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ReuniaoPessoas
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
if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Reuniao])) m_FReuniao = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Reuniao]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Reuniao])) m_FReuniao = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Reuniao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Reuniao])) m_FReuniao = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Reuniao]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Reuniao])) m_FReuniao = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Reuniao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Reuniao])) m_FReuniao = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Reuniao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Reuniao]))
            m_FReuniao = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Reuniao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBReuniaoPessoasDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBReuniaoPessoasDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBReuniaoPessoasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBReuniaoPessoasDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBReuniaoPessoasDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBReuniaoPessoasDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Visto])) m_FVisto = (bool)dbRec[DBReuniaoPessoasDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBReuniaoPessoasDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBReuniaoPessoasDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}