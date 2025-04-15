namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBContatoCRMOperador
{
    public DBContatoCRMOperador(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc]))
                m_FCargoEsc = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM]))
                m_FContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBContatoCRMOperadorDicInfo.Visto];
        }
        catch
        {
        }
    }

    public DBContatoCRMOperador(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc]))
                m_FCargoEsc = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM]))
                m_FContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBContatoCRMOperadorDicInfo.Visto];
        }
        catch
        {
        }
    }

#region CarregarDados_ContatoCRMOperador
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[ContatoCRMOperador] (NOLOCK) WHERE [ccoCodigo] = @ThisIDToLoad", oCnn);
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
if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM]))
            m_FContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc])) m_FCargoEsc = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc])) m_FCargoEsc = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc])) m_FCargoEsc = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc])) m_FCargoEsc = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc])) m_FCargoEsc = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc]))
            m_FCargoEsc = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContatoCRMOperadorDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContatoCRMOperadorDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContatoCRMOperadorDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContatoCRMOperadorDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContatoCRMOperadorDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBContatoCRMOperadorDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ContatoCRMOperador
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
if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM])) m_FContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM]))
            m_FContatoCRM = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.ContatoCRM]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc])) m_FCargoEsc = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc])) m_FCargoEsc = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc])) m_FCargoEsc = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc])) m_FCargoEsc = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc])) m_FCargoEsc = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc]))
            m_FCargoEsc = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.CargoEsc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBContatoCRMOperadorDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBContatoCRMOperadorDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContatoCRMOperadorDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContatoCRMOperadorDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContatoCRMOperadorDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContatoCRMOperadorDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Visto])) m_FVisto = (bool)dbRec[DBContatoCRMOperadorDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBContatoCRMOperadorDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBContatoCRMOperadorDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}