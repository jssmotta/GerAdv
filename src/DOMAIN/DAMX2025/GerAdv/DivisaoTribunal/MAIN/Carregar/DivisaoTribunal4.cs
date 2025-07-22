namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBDivisaoTribunal
{
    public DBDivisaoTribunal(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBDivisaoTribunalDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBDivisaoTribunalDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Foro]))
                m_FForo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Foro]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Justica]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.NumCodigo]))
                m_FNumCodigo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.NumCodigo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Tribunal]))
                m_FTribunal = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Tribunal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBDivisaoTribunalDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FAndar = dbRec[DBDivisaoTribunalDicInfo.Andar]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCEP = dbRec[DBDivisaoTribunalDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCodigoDiv = dbRec[DBDivisaoTribunalDicInfo.CodigoDiv]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBDivisaoTribunalDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEndereco = dbRec[DBDivisaoTribunalDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBDivisaoTribunalDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBDivisaoTribunalDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBDivisaoTribunalDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeEspecial = dbRec[DBDivisaoTribunalDicInfo.NomeEspecial]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObs = dbRec[DBDivisaoTribunalDicInfo.Obs]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBDivisaoTribunal(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBDivisaoTribunalDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBDivisaoTribunalDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Foro]))
                m_FForo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Foro]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Justica]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.NumCodigo]))
                m_FNumCodigo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.NumCodigo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Tribunal]))
                m_FTribunal = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Tribunal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBDivisaoTribunalDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FAndar = dbRec[DBDivisaoTribunalDicInfo.Andar]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCEP = dbRec[DBDivisaoTribunalDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCodigoDiv = dbRec[DBDivisaoTribunalDicInfo.CodigoDiv]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBDivisaoTribunalDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEndereco = dbRec[DBDivisaoTribunalDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBDivisaoTribunalDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBDivisaoTribunalDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBDivisaoTribunalDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeEspecial = dbRec[DBDivisaoTribunalDicInfo.NomeEspecial]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObs = dbRec[DBDivisaoTribunalDicInfo.Obs]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_DivisaoTribunal
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [divCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.NumCodigo])) m_FNumCodigo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.NumCodigo]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.NumCodigo])) m_FNumCodigo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.NumCodigo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.NumCodigo])) m_FNumCodigo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.NumCodigo]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.NumCodigo])) m_FNumCodigo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.NumCodigo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.NumCodigo])) m_FNumCodigo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.NumCodigo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.NumCodigo]))
            m_FNumCodigo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.NumCodigo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Justica]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeEspecial = dbRec[DBDivisaoTribunalDicInfo.NomeEspecial]?.ToString() ?? string.Empty; m_FNomeEspecial = dbRec[DBDivisaoTribunalDicInfo.NomeEspecial]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeEspecial = dbRec[DBDivisaoTribunalDicInfo.NomeEspecial]?.ToString() ?? string.Empty; m_FNomeEspecial = dbRec[DBDivisaoTribunalDicInfo.NomeEspecial]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeEspecial = dbRec[DBDivisaoTribunalDicInfo.NomeEspecial]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeEspecial = dbRec[DBDivisaoTribunalDicInfo.NomeEspecial]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Foro]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Foro]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Foro]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Foro]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Foro]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Foro]))
            m_FForo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Foro]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Tribunal]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Tribunal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Tribunal]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Tribunal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Tribunal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Tribunal]))
            m_FTribunal = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Tribunal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCodigoDiv = dbRec[DBDivisaoTribunalDicInfo.CodigoDiv]?.ToString() ?? string.Empty; m_FCodigoDiv = dbRec[DBDivisaoTribunalDicInfo.CodigoDiv]?.ToString() ?? string.Empty;  } catch {}  try { m_FCodigoDiv = dbRec[DBDivisaoTribunalDicInfo.CodigoDiv]?.ToString() ?? string.Empty; m_FCodigoDiv = dbRec[DBDivisaoTribunalDicInfo.CodigoDiv]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCodigoDiv = dbRec[DBDivisaoTribunalDicInfo.CodigoDiv]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCodigoDiv = dbRec[DBDivisaoTribunalDicInfo.CodigoDiv]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEndereco = dbRec[DBDivisaoTribunalDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBDivisaoTribunalDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { m_FEndereco = dbRec[DBDivisaoTribunalDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBDivisaoTribunalDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEndereco = dbRec[DBDivisaoTribunalDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEndereco = dbRec[DBDivisaoTribunalDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBDivisaoTribunalDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBDivisaoTribunalDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBDivisaoTribunalDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBDivisaoTribunalDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBDivisaoTribunalDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBDivisaoTribunalDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBDivisaoTribunalDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBDivisaoTribunalDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBDivisaoTribunalDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBDivisaoTribunalDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBDivisaoTribunalDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBDivisaoTribunalDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCEP = dbRec[DBDivisaoTribunalDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBDivisaoTribunalDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { m_FCEP = dbRec[DBDivisaoTribunalDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBDivisaoTribunalDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCEP = dbRec[DBDivisaoTribunalDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCEP = dbRec[DBDivisaoTribunalDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObs = dbRec[DBDivisaoTribunalDicInfo.Obs]?.ToString() ?? string.Empty; m_FObs = dbRec[DBDivisaoTribunalDicInfo.Obs]?.ToString() ?? string.Empty;  } catch {}  try { m_FObs = dbRec[DBDivisaoTribunalDicInfo.Obs]?.ToString() ?? string.Empty; m_FObs = dbRec[DBDivisaoTribunalDicInfo.Obs]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObs = dbRec[DBDivisaoTribunalDicInfo.Obs]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObs = dbRec[DBDivisaoTribunalDicInfo.Obs]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBDivisaoTribunalDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBDivisaoTribunalDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBDivisaoTribunalDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBDivisaoTribunalDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBDivisaoTribunalDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBDivisaoTribunalDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAndar = dbRec[DBDivisaoTribunalDicInfo.Andar]?.ToString() ?? string.Empty; m_FAndar = dbRec[DBDivisaoTribunalDicInfo.Andar]?.ToString() ?? string.Empty;  } catch {}  try { m_FAndar = dbRec[DBDivisaoTribunalDicInfo.Andar]?.ToString() ?? string.Empty; m_FAndar = dbRec[DBDivisaoTribunalDicInfo.Andar]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAndar = dbRec[DBDivisaoTribunalDicInfo.Andar]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAndar = dbRec[DBDivisaoTribunalDicInfo.Andar]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBDivisaoTribunalDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBDivisaoTribunalDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBDivisaoTribunalDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBDivisaoTribunalDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBDivisaoTribunalDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBDivisaoTribunalDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Bold])) m_FBold = (bool)dbRec[DBDivisaoTribunalDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Bold])) m_FBold = (bool)dbRec[DBDivisaoTribunalDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Bold])) m_FBold = (bool)dbRec[DBDivisaoTribunalDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Bold])) m_FBold = (bool)dbRec[DBDivisaoTribunalDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Bold])) m_FBold = (bool)dbRec[DBDivisaoTribunalDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBDivisaoTribunalDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBDivisaoTribunalDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBDivisaoTribunalDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBDivisaoTribunalDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBDivisaoTribunalDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBDivisaoTribunalDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBDivisaoTribunalDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDivisaoTribunalDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDivisaoTribunalDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDivisaoTribunalDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDivisaoTribunalDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDivisaoTribunalDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBDivisaoTribunalDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_DivisaoTribunal
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
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.NumCodigo])) m_FNumCodigo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.NumCodigo]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.NumCodigo])) m_FNumCodigo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.NumCodigo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.NumCodigo])) m_FNumCodigo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.NumCodigo]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.NumCodigo])) m_FNumCodigo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.NumCodigo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.NumCodigo])) m_FNumCodigo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.NumCodigo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.NumCodigo]))
            m_FNumCodigo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.NumCodigo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Justica]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeEspecial = dbRec[DBDivisaoTribunalDicInfo.NomeEspecial]?.ToString() ?? string.Empty; m_FNomeEspecial = dbRec[DBDivisaoTribunalDicInfo.NomeEspecial]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeEspecial = dbRec[DBDivisaoTribunalDicInfo.NomeEspecial]?.ToString() ?? string.Empty; m_FNomeEspecial = dbRec[DBDivisaoTribunalDicInfo.NomeEspecial]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeEspecial = dbRec[DBDivisaoTribunalDicInfo.NomeEspecial]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeEspecial = dbRec[DBDivisaoTribunalDicInfo.NomeEspecial]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Foro]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Foro]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Foro]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Foro]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Foro])) m_FForo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Foro]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Foro]))
            m_FForo = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Foro]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Tribunal]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Tribunal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Tribunal]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Tribunal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Tribunal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Tribunal]))
            m_FTribunal = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.Tribunal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCodigoDiv = dbRec[DBDivisaoTribunalDicInfo.CodigoDiv]?.ToString() ?? string.Empty; m_FCodigoDiv = dbRec[DBDivisaoTribunalDicInfo.CodigoDiv]?.ToString() ?? string.Empty;  } catch {}  try { m_FCodigoDiv = dbRec[DBDivisaoTribunalDicInfo.CodigoDiv]?.ToString() ?? string.Empty; m_FCodigoDiv = dbRec[DBDivisaoTribunalDicInfo.CodigoDiv]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCodigoDiv = dbRec[DBDivisaoTribunalDicInfo.CodigoDiv]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCodigoDiv = dbRec[DBDivisaoTribunalDicInfo.CodigoDiv]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEndereco = dbRec[DBDivisaoTribunalDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBDivisaoTribunalDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { m_FEndereco = dbRec[DBDivisaoTribunalDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBDivisaoTribunalDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEndereco = dbRec[DBDivisaoTribunalDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEndereco = dbRec[DBDivisaoTribunalDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBDivisaoTribunalDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBDivisaoTribunalDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBDivisaoTribunalDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBDivisaoTribunalDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBDivisaoTribunalDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBDivisaoTribunalDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBDivisaoTribunalDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBDivisaoTribunalDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBDivisaoTribunalDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBDivisaoTribunalDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBDivisaoTribunalDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBDivisaoTribunalDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCEP = dbRec[DBDivisaoTribunalDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBDivisaoTribunalDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { m_FCEP = dbRec[DBDivisaoTribunalDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBDivisaoTribunalDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCEP = dbRec[DBDivisaoTribunalDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCEP = dbRec[DBDivisaoTribunalDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObs = dbRec[DBDivisaoTribunalDicInfo.Obs]?.ToString() ?? string.Empty; m_FObs = dbRec[DBDivisaoTribunalDicInfo.Obs]?.ToString() ?? string.Empty;  } catch {}  try { m_FObs = dbRec[DBDivisaoTribunalDicInfo.Obs]?.ToString() ?? string.Empty; m_FObs = dbRec[DBDivisaoTribunalDicInfo.Obs]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObs = dbRec[DBDivisaoTribunalDicInfo.Obs]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObs = dbRec[DBDivisaoTribunalDicInfo.Obs]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBDivisaoTribunalDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBDivisaoTribunalDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBDivisaoTribunalDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBDivisaoTribunalDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBDivisaoTribunalDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBDivisaoTribunalDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAndar = dbRec[DBDivisaoTribunalDicInfo.Andar]?.ToString() ?? string.Empty; m_FAndar = dbRec[DBDivisaoTribunalDicInfo.Andar]?.ToString() ?? string.Empty;  } catch {}  try { m_FAndar = dbRec[DBDivisaoTribunalDicInfo.Andar]?.ToString() ?? string.Empty; m_FAndar = dbRec[DBDivisaoTribunalDicInfo.Andar]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAndar = dbRec[DBDivisaoTribunalDicInfo.Andar]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAndar = dbRec[DBDivisaoTribunalDicInfo.Andar]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBDivisaoTribunalDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBDivisaoTribunalDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBDivisaoTribunalDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBDivisaoTribunalDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBDivisaoTribunalDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBDivisaoTribunalDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Bold])) m_FBold = (bool)dbRec[DBDivisaoTribunalDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Bold])) m_FBold = (bool)dbRec[DBDivisaoTribunalDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Bold])) m_FBold = (bool)dbRec[DBDivisaoTribunalDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Bold])) m_FBold = (bool)dbRec[DBDivisaoTribunalDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Bold])) m_FBold = (bool)dbRec[DBDivisaoTribunalDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBDivisaoTribunalDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBDivisaoTribunalDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBDivisaoTribunalDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBDivisaoTribunalDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBDivisaoTribunalDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBDivisaoTribunalDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBDivisaoTribunalDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBDivisaoTribunalDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBDivisaoTribunalDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDivisaoTribunalDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDivisaoTribunalDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDivisaoTribunalDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDivisaoTribunalDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBDivisaoTribunalDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBDivisaoTribunalDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBDivisaoTribunalDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}