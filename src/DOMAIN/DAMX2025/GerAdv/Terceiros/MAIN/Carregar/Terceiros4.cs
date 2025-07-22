namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTerceiros
{
    public DBTerceiros(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBTerceirosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBTerceirosDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Situacao]))
                m_FSituacao = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Situacao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBTerceirosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FBairro = dbRec[DBTerceirosDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCEP = dbRec[DBTerceirosDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FClass = dbRec[DBTerceirosDicInfo.Class]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBTerceirosDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEndereco = dbRec[DBTerceirosDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBTerceirosDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBTerceirosDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBTerceirosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBTerceirosDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = dbRec[DBTerceirosDicInfo.OBS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FVaraForoComarca = dbRec[DBTerceirosDicInfo.VaraForoComarca]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBTerceiros(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBTerceirosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBTerceirosDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Situacao]))
                m_FSituacao = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Situacao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBTerceirosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FBairro = dbRec[DBTerceirosDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCEP = dbRec[DBTerceirosDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FClass = dbRec[DBTerceirosDicInfo.Class]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBTerceirosDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEndereco = dbRec[DBTerceirosDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBTerceirosDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBTerceirosDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBTerceirosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBTerceirosDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = dbRec[DBTerceirosDicInfo.OBS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FVaraForoComarca = dbRec[DBTerceirosDicInfo.VaraForoComarca]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Terceiros
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [terCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBTerceirosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBTerceirosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBTerceirosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBTerceirosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBTerceirosDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBTerceirosDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Situacao])) m_FSituacao = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Situacao]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Situacao])) m_FSituacao = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Situacao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Situacao])) m_FSituacao = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Situacao]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Situacao])) m_FSituacao = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Situacao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Situacao])) m_FSituacao = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Situacao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Situacao]))
            m_FSituacao = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Situacao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEndereco = dbRec[DBTerceirosDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBTerceirosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { m_FEndereco = dbRec[DBTerceirosDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBTerceirosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEndereco = dbRec[DBTerceirosDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEndereco = dbRec[DBTerceirosDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FBairro = dbRec[DBTerceirosDicInfo.Bairro]?.ToString() ?? string.Empty; m_FBairro = dbRec[DBTerceirosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { m_FBairro = dbRec[DBTerceirosDicInfo.Bairro]?.ToString() ?? string.Empty; m_FBairro = dbRec[DBTerceirosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FBairro = dbRec[DBTerceirosDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        m_FBairro = dbRec[DBTerceirosDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCEP = dbRec[DBTerceirosDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBTerceirosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { m_FCEP = dbRec[DBTerceirosDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBTerceirosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCEP = dbRec[DBTerceirosDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCEP = dbRec[DBTerceirosDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBTerceirosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBTerceirosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBTerceirosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBTerceirosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBTerceirosDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBTerceirosDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBTerceirosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBTerceirosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBTerceirosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBTerceirosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBTerceirosDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBTerceirosDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOBS = dbRec[DBTerceirosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBTerceirosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { m_FOBS = dbRec[DBTerceirosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBTerceirosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOBS = dbRec[DBTerceirosDicInfo.OBS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOBS = dbRec[DBTerceirosDicInfo.OBS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBTerceirosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBTerceirosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBTerceirosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBTerceirosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBTerceirosDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBTerceirosDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FClass = dbRec[DBTerceirosDicInfo.Class]?.ToString() ?? string.Empty; m_FClass = dbRec[DBTerceirosDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { m_FClass = dbRec[DBTerceirosDicInfo.Class]?.ToString() ?? string.Empty; m_FClass = dbRec[DBTerceirosDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FClass = dbRec[DBTerceirosDicInfo.Class]?.ToString() ?? string.Empty; } catch { }

#else
        m_FClass = dbRec[DBTerceirosDicInfo.Class]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FVaraForoComarca = dbRec[DBTerceirosDicInfo.VaraForoComarca]?.ToString() ?? string.Empty; m_FVaraForoComarca = dbRec[DBTerceirosDicInfo.VaraForoComarca]?.ToString() ?? string.Empty;  } catch {}  try { m_FVaraForoComarca = dbRec[DBTerceirosDicInfo.VaraForoComarca]?.ToString() ?? string.Empty; m_FVaraForoComarca = dbRec[DBTerceirosDicInfo.VaraForoComarca]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FVaraForoComarca = dbRec[DBTerceirosDicInfo.VaraForoComarca]?.ToString() ?? string.Empty; } catch { }

#else
        m_FVaraForoComarca = dbRec[DBTerceirosDicInfo.VaraForoComarca]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBTerceirosDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBTerceirosDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBTerceirosDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBTerceirosDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBTerceirosDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBTerceirosDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Bold])) m_FBold = (bool)dbRec[DBTerceirosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Bold])) m_FBold = (bool)dbRec[DBTerceirosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Bold])) m_FBold = (bool)dbRec[DBTerceirosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Bold])) m_FBold = (bool)dbRec[DBTerceirosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Bold])) m_FBold = (bool)dbRec[DBTerceirosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBTerceirosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBTerceirosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTerceirosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBTerceirosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTerceirosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBTerceirosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBTerceirosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTerceirosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTerceirosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTerceirosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTerceirosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTerceirosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBTerceirosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Terceiros
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
if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBTerceirosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBTerceirosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBTerceirosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBTerceirosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBTerceirosDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBTerceirosDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Situacao])) m_FSituacao = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Situacao]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Situacao])) m_FSituacao = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Situacao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Situacao])) m_FSituacao = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Situacao]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Situacao])) m_FSituacao = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Situacao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Situacao])) m_FSituacao = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Situacao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Situacao]))
            m_FSituacao = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Situacao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBTerceirosDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEndereco = dbRec[DBTerceirosDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBTerceirosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { m_FEndereco = dbRec[DBTerceirosDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBTerceirosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEndereco = dbRec[DBTerceirosDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEndereco = dbRec[DBTerceirosDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FBairro = dbRec[DBTerceirosDicInfo.Bairro]?.ToString() ?? string.Empty; m_FBairro = dbRec[DBTerceirosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { m_FBairro = dbRec[DBTerceirosDicInfo.Bairro]?.ToString() ?? string.Empty; m_FBairro = dbRec[DBTerceirosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FBairro = dbRec[DBTerceirosDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        m_FBairro = dbRec[DBTerceirosDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCEP = dbRec[DBTerceirosDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBTerceirosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { m_FCEP = dbRec[DBTerceirosDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBTerceirosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCEP = dbRec[DBTerceirosDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCEP = dbRec[DBTerceirosDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBTerceirosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBTerceirosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBTerceirosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBTerceirosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBTerceirosDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBTerceirosDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBTerceirosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBTerceirosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBTerceirosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBTerceirosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBTerceirosDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBTerceirosDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOBS = dbRec[DBTerceirosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBTerceirosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { m_FOBS = dbRec[DBTerceirosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBTerceirosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOBS = dbRec[DBTerceirosDicInfo.OBS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOBS = dbRec[DBTerceirosDicInfo.OBS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBTerceirosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBTerceirosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBTerceirosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBTerceirosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBTerceirosDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBTerceirosDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FClass = dbRec[DBTerceirosDicInfo.Class]?.ToString() ?? string.Empty; m_FClass = dbRec[DBTerceirosDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { m_FClass = dbRec[DBTerceirosDicInfo.Class]?.ToString() ?? string.Empty; m_FClass = dbRec[DBTerceirosDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FClass = dbRec[DBTerceirosDicInfo.Class]?.ToString() ?? string.Empty; } catch { }

#else
        m_FClass = dbRec[DBTerceirosDicInfo.Class]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FVaraForoComarca = dbRec[DBTerceirosDicInfo.VaraForoComarca]?.ToString() ?? string.Empty; m_FVaraForoComarca = dbRec[DBTerceirosDicInfo.VaraForoComarca]?.ToString() ?? string.Empty;  } catch {}  try { m_FVaraForoComarca = dbRec[DBTerceirosDicInfo.VaraForoComarca]?.ToString() ?? string.Empty; m_FVaraForoComarca = dbRec[DBTerceirosDicInfo.VaraForoComarca]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FVaraForoComarca = dbRec[DBTerceirosDicInfo.VaraForoComarca]?.ToString() ?? string.Empty; } catch { }

#else
        m_FVaraForoComarca = dbRec[DBTerceirosDicInfo.VaraForoComarca]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBTerceirosDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBTerceirosDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBTerceirosDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBTerceirosDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBTerceirosDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBTerceirosDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Bold])) m_FBold = (bool)dbRec[DBTerceirosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Bold])) m_FBold = (bool)dbRec[DBTerceirosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Bold])) m_FBold = (bool)dbRec[DBTerceirosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Bold])) m_FBold = (bool)dbRec[DBTerceirosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Bold])) m_FBold = (bool)dbRec[DBTerceirosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBTerceirosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBTerceirosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTerceirosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBTerceirosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTerceirosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBTerceirosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBTerceirosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBTerceirosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBTerceirosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTerceirosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTerceirosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTerceirosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTerceirosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTerceirosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTerceirosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBTerceirosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}