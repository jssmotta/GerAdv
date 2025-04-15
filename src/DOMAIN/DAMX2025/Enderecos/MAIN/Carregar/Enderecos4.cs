namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBEnderecos
{
    public DBEnderecos(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.AddContato]))
                m_FAddContato = (bool)dbRec[DBEnderecosDicInfo.AddContato];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Ani]))
                m_FAni = (bool)dbRec[DBEnderecosDicInfo.Ani];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBEnderecosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtNasc]))
                m_FDtNasc = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtNasc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBEnderecosDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Privativo]))
                m_FPrivativo = (bool)dbRec[DBEnderecosDicInfo.Privativo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Quem]))
                m_FQuem = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Quem]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.ReportECBOnly]))
                m_FReportECBOnly = (bool)dbRec[DBEnderecosDicInfo.ReportECBOnly];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.TopIndex]))
                m_FTopIndex = (bool)dbRec[DBEnderecosDicInfo.TopIndex];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBEnderecosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FBairro = dbRec[DBEnderecosDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCEP = dbRec[DBEnderecosDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FContato = dbRec[DBEnderecosDicInfo.Contato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBEnderecosDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBEnderecosDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEndereco = dbRec[DBEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBEnderecosDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBEnderecosDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBEnderecosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOAB = dbRec[DBEnderecosDicInfo.OAB]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = dbRec[DBEnderecosDicInfo.OBS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FQuemIndicou = dbRec[DBEnderecosDicInfo.QuemIndicou]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSite = dbRec[DBEnderecosDicInfo.Site]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FTratamento = dbRec[DBEnderecosDicInfo.Tratamento]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBEnderecos(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.AddContato]))
                m_FAddContato = (bool)dbRec[DBEnderecosDicInfo.AddContato];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Ani]))
                m_FAni = (bool)dbRec[DBEnderecosDicInfo.Ani];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBEnderecosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtNasc]))
                m_FDtNasc = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtNasc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBEnderecosDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Privativo]))
                m_FPrivativo = (bool)dbRec[DBEnderecosDicInfo.Privativo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Quem]))
                m_FQuem = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Quem]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.ReportECBOnly]))
                m_FReportECBOnly = (bool)dbRec[DBEnderecosDicInfo.ReportECBOnly];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.TopIndex]))
                m_FTopIndex = (bool)dbRec[DBEnderecosDicInfo.TopIndex];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBEnderecosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FBairro = dbRec[DBEnderecosDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCEP = dbRec[DBEnderecosDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FContato = dbRec[DBEnderecosDicInfo.Contato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBEnderecosDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBEnderecosDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEndereco = dbRec[DBEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBEnderecosDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBEnderecosDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBEnderecosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOAB = dbRec[DBEnderecosDicInfo.OAB]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = dbRec[DBEnderecosDicInfo.OBS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FQuemIndicou = dbRec[DBEnderecosDicInfo.QuemIndicou]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSite = dbRec[DBEnderecosDicInfo.Site]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FTratamento = dbRec[DBEnderecosDicInfo.Tratamento]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Enderecos
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[Enderecos] (NOLOCK) WHERE [endCodigo] = @ThisIDToLoad", oCnn);
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
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.TopIndex])) m_FTopIndex = (bool)dbRec[DBEnderecosDicInfo.TopIndex]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.TopIndex])) m_FTopIndex = (bool)dbRec[DBEnderecosDicInfo.TopIndex];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.TopIndex])) m_FTopIndex = (bool)dbRec[DBEnderecosDicInfo.TopIndex]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.TopIndex])) m_FTopIndex = (bool)dbRec[DBEnderecosDicInfo.TopIndex];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.TopIndex])) m_FTopIndex = (bool)dbRec[DBEnderecosDicInfo.TopIndex]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.TopIndex]))
            m_FTopIndex = (bool)dbRec[DBEnderecosDicInfo.TopIndex];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDescricao = dbRec[DBEnderecosDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBEnderecosDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBEnderecosDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBEnderecosDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBEnderecosDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBEnderecosDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FContato = dbRec[DBEnderecosDicInfo.Contato]?.ToString() ?? string.Empty; m_FContato = dbRec[DBEnderecosDicInfo.Contato]?.ToString() ?? string.Empty;  } catch {}  try { m_FContato = dbRec[DBEnderecosDicInfo.Contato]?.ToString() ?? string.Empty; m_FContato = dbRec[DBEnderecosDicInfo.Contato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FContato = dbRec[DBEnderecosDicInfo.Contato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FContato = dbRec[DBEnderecosDicInfo.Contato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtNasc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtNasc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtNasc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtNasc]))
            m_FDtNasc = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtNasc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEndereco = dbRec[DBEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { m_FEndereco = dbRec[DBEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEndereco = dbRec[DBEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEndereco = dbRec[DBEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FBairro = dbRec[DBEnderecosDicInfo.Bairro]?.ToString() ?? string.Empty; m_FBairro = dbRec[DBEnderecosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { m_FBairro = dbRec[DBEnderecosDicInfo.Bairro]?.ToString() ?? string.Empty; m_FBairro = dbRec[DBEnderecosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FBairro = dbRec[DBEnderecosDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        m_FBairro = dbRec[DBEnderecosDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Privativo])) m_FPrivativo = (bool)dbRec[DBEnderecosDicInfo.Privativo]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Privativo])) m_FPrivativo = (bool)dbRec[DBEnderecosDicInfo.Privativo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Privativo])) m_FPrivativo = (bool)dbRec[DBEnderecosDicInfo.Privativo]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Privativo])) m_FPrivativo = (bool)dbRec[DBEnderecosDicInfo.Privativo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Privativo])) m_FPrivativo = (bool)dbRec[DBEnderecosDicInfo.Privativo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Privativo]))
            m_FPrivativo = (bool)dbRec[DBEnderecosDicInfo.Privativo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.AddContato])) m_FAddContato = (bool)dbRec[DBEnderecosDicInfo.AddContato]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.AddContato])) m_FAddContato = (bool)dbRec[DBEnderecosDicInfo.AddContato];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.AddContato])) m_FAddContato = (bool)dbRec[DBEnderecosDicInfo.AddContato]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.AddContato])) m_FAddContato = (bool)dbRec[DBEnderecosDicInfo.AddContato];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.AddContato])) m_FAddContato = (bool)dbRec[DBEnderecosDicInfo.AddContato]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.AddContato]))
            m_FAddContato = (bool)dbRec[DBEnderecosDicInfo.AddContato];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCEP = dbRec[DBEnderecosDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBEnderecosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { m_FCEP = dbRec[DBEnderecosDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBEnderecosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCEP = dbRec[DBEnderecosDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCEP = dbRec[DBEnderecosDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOAB = dbRec[DBEnderecosDicInfo.OAB]?.ToString() ?? string.Empty; m_FOAB = dbRec[DBEnderecosDicInfo.OAB]?.ToString() ?? string.Empty;  } catch {}  try { m_FOAB = dbRec[DBEnderecosDicInfo.OAB]?.ToString() ?? string.Empty; m_FOAB = dbRec[DBEnderecosDicInfo.OAB]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOAB = dbRec[DBEnderecosDicInfo.OAB]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOAB = dbRec[DBEnderecosDicInfo.OAB]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOBS = dbRec[DBEnderecosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBEnderecosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { m_FOBS = dbRec[DBEnderecosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBEnderecosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOBS = dbRec[DBEnderecosDicInfo.OBS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOBS = dbRec[DBEnderecosDicInfo.OBS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBEnderecosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBEnderecosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBEnderecosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBEnderecosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBEnderecosDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBEnderecosDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBEnderecosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBEnderecosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBEnderecosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBEnderecosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBEnderecosDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBEnderecosDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FTratamento = dbRec[DBEnderecosDicInfo.Tratamento]?.ToString() ?? string.Empty; m_FTratamento = dbRec[DBEnderecosDicInfo.Tratamento]?.ToString() ?? string.Empty;  } catch {}  try { m_FTratamento = dbRec[DBEnderecosDicInfo.Tratamento]?.ToString() ?? string.Empty; m_FTratamento = dbRec[DBEnderecosDicInfo.Tratamento]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FTratamento = dbRec[DBEnderecosDicInfo.Tratamento]?.ToString() ?? string.Empty; } catch { }

#else
        m_FTratamento = dbRec[DBEnderecosDicInfo.Tratamento]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSite = dbRec[DBEnderecosDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBEnderecosDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { m_FSite = dbRec[DBEnderecosDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBEnderecosDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSite = dbRec[DBEnderecosDicInfo.Site]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSite = dbRec[DBEnderecosDicInfo.Site]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBEnderecosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBEnderecosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBEnderecosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBEnderecosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBEnderecosDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBEnderecosDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Quem])) m_FQuem = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Quem]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Quem])) m_FQuem = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Quem]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Quem])) m_FQuem = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Quem]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Quem])) m_FQuem = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Quem]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Quem])) m_FQuem = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Quem]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Quem]))
            m_FQuem = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Quem]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FQuemIndicou = dbRec[DBEnderecosDicInfo.QuemIndicou]?.ToString() ?? string.Empty; m_FQuemIndicou = dbRec[DBEnderecosDicInfo.QuemIndicou]?.ToString() ?? string.Empty;  } catch {}  try { m_FQuemIndicou = dbRec[DBEnderecosDicInfo.QuemIndicou]?.ToString() ?? string.Empty; m_FQuemIndicou = dbRec[DBEnderecosDicInfo.QuemIndicou]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FQuemIndicou = dbRec[DBEnderecosDicInfo.QuemIndicou]?.ToString() ?? string.Empty; } catch { }

#else
        m_FQuemIndicou = dbRec[DBEnderecosDicInfo.QuemIndicou]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.ReportECBOnly])) m_FReportECBOnly = (bool)dbRec[DBEnderecosDicInfo.ReportECBOnly]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.ReportECBOnly])) m_FReportECBOnly = (bool)dbRec[DBEnderecosDicInfo.ReportECBOnly];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.ReportECBOnly])) m_FReportECBOnly = (bool)dbRec[DBEnderecosDicInfo.ReportECBOnly]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.ReportECBOnly])) m_FReportECBOnly = (bool)dbRec[DBEnderecosDicInfo.ReportECBOnly];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.ReportECBOnly])) m_FReportECBOnly = (bool)dbRec[DBEnderecosDicInfo.ReportECBOnly]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.ReportECBOnly]))
            m_FReportECBOnly = (bool)dbRec[DBEnderecosDicInfo.ReportECBOnly];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBEnderecosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBEnderecosDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBEnderecosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBEnderecosDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBEnderecosDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBEnderecosDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Ani])) m_FAni = (bool)dbRec[DBEnderecosDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Ani])) m_FAni = (bool)dbRec[DBEnderecosDicInfo.Ani];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Ani])) m_FAni = (bool)dbRec[DBEnderecosDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Ani])) m_FAni = (bool)dbRec[DBEnderecosDicInfo.Ani];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Ani])) m_FAni = (bool)dbRec[DBEnderecosDicInfo.Ani]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Ani]))
            m_FAni = (bool)dbRec[DBEnderecosDicInfo.Ani];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEnderecosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEnderecosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEnderecosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEnderecosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEnderecosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBEnderecosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBEnderecosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBEnderecosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBEnderecosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBEnderecosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBEnderecosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBEnderecosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEnderecosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEnderecosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEnderecosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEnderecosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEnderecosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBEnderecosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Enderecos
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
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.TopIndex])) m_FTopIndex = (bool)dbRec[DBEnderecosDicInfo.TopIndex]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.TopIndex])) m_FTopIndex = (bool)dbRec[DBEnderecosDicInfo.TopIndex];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.TopIndex])) m_FTopIndex = (bool)dbRec[DBEnderecosDicInfo.TopIndex]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.TopIndex])) m_FTopIndex = (bool)dbRec[DBEnderecosDicInfo.TopIndex];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.TopIndex])) m_FTopIndex = (bool)dbRec[DBEnderecosDicInfo.TopIndex]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.TopIndex]))
            m_FTopIndex = (bool)dbRec[DBEnderecosDicInfo.TopIndex];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDescricao = dbRec[DBEnderecosDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBEnderecosDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBEnderecosDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBEnderecosDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBEnderecosDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBEnderecosDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FContato = dbRec[DBEnderecosDicInfo.Contato]?.ToString() ?? string.Empty; m_FContato = dbRec[DBEnderecosDicInfo.Contato]?.ToString() ?? string.Empty;  } catch {}  try { m_FContato = dbRec[DBEnderecosDicInfo.Contato]?.ToString() ?? string.Empty; m_FContato = dbRec[DBEnderecosDicInfo.Contato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FContato = dbRec[DBEnderecosDicInfo.Contato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FContato = dbRec[DBEnderecosDicInfo.Contato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtNasc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtNasc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtNasc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtNasc]))
            m_FDtNasc = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtNasc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEndereco = dbRec[DBEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { m_FEndereco = dbRec[DBEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEndereco = dbRec[DBEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEndereco = dbRec[DBEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FBairro = dbRec[DBEnderecosDicInfo.Bairro]?.ToString() ?? string.Empty; m_FBairro = dbRec[DBEnderecosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { m_FBairro = dbRec[DBEnderecosDicInfo.Bairro]?.ToString() ?? string.Empty; m_FBairro = dbRec[DBEnderecosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FBairro = dbRec[DBEnderecosDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        m_FBairro = dbRec[DBEnderecosDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Privativo])) m_FPrivativo = (bool)dbRec[DBEnderecosDicInfo.Privativo]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Privativo])) m_FPrivativo = (bool)dbRec[DBEnderecosDicInfo.Privativo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Privativo])) m_FPrivativo = (bool)dbRec[DBEnderecosDicInfo.Privativo]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Privativo])) m_FPrivativo = (bool)dbRec[DBEnderecosDicInfo.Privativo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Privativo])) m_FPrivativo = (bool)dbRec[DBEnderecosDicInfo.Privativo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Privativo]))
            m_FPrivativo = (bool)dbRec[DBEnderecosDicInfo.Privativo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.AddContato])) m_FAddContato = (bool)dbRec[DBEnderecosDicInfo.AddContato]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.AddContato])) m_FAddContato = (bool)dbRec[DBEnderecosDicInfo.AddContato];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.AddContato])) m_FAddContato = (bool)dbRec[DBEnderecosDicInfo.AddContato]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.AddContato])) m_FAddContato = (bool)dbRec[DBEnderecosDicInfo.AddContato];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.AddContato])) m_FAddContato = (bool)dbRec[DBEnderecosDicInfo.AddContato]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.AddContato]))
            m_FAddContato = (bool)dbRec[DBEnderecosDicInfo.AddContato];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCEP = dbRec[DBEnderecosDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBEnderecosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { m_FCEP = dbRec[DBEnderecosDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBEnderecosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCEP = dbRec[DBEnderecosDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCEP = dbRec[DBEnderecosDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOAB = dbRec[DBEnderecosDicInfo.OAB]?.ToString() ?? string.Empty; m_FOAB = dbRec[DBEnderecosDicInfo.OAB]?.ToString() ?? string.Empty;  } catch {}  try { m_FOAB = dbRec[DBEnderecosDicInfo.OAB]?.ToString() ?? string.Empty; m_FOAB = dbRec[DBEnderecosDicInfo.OAB]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOAB = dbRec[DBEnderecosDicInfo.OAB]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOAB = dbRec[DBEnderecosDicInfo.OAB]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOBS = dbRec[DBEnderecosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBEnderecosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { m_FOBS = dbRec[DBEnderecosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBEnderecosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOBS = dbRec[DBEnderecosDicInfo.OBS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOBS = dbRec[DBEnderecosDicInfo.OBS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBEnderecosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBEnderecosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBEnderecosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBEnderecosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBEnderecosDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBEnderecosDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBEnderecosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBEnderecosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBEnderecosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBEnderecosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBEnderecosDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBEnderecosDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FTratamento = dbRec[DBEnderecosDicInfo.Tratamento]?.ToString() ?? string.Empty; m_FTratamento = dbRec[DBEnderecosDicInfo.Tratamento]?.ToString() ?? string.Empty;  } catch {}  try { m_FTratamento = dbRec[DBEnderecosDicInfo.Tratamento]?.ToString() ?? string.Empty; m_FTratamento = dbRec[DBEnderecosDicInfo.Tratamento]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FTratamento = dbRec[DBEnderecosDicInfo.Tratamento]?.ToString() ?? string.Empty; } catch { }

#else
        m_FTratamento = dbRec[DBEnderecosDicInfo.Tratamento]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSite = dbRec[DBEnderecosDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBEnderecosDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { m_FSite = dbRec[DBEnderecosDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBEnderecosDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSite = dbRec[DBEnderecosDicInfo.Site]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSite = dbRec[DBEnderecosDicInfo.Site]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBEnderecosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBEnderecosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBEnderecosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBEnderecosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBEnderecosDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBEnderecosDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Quem])) m_FQuem = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Quem]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Quem])) m_FQuem = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Quem]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Quem])) m_FQuem = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Quem]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Quem])) m_FQuem = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Quem]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Quem])) m_FQuem = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Quem]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Quem]))
            m_FQuem = Convert.ToInt32(dbRec[DBEnderecosDicInfo.Quem]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FQuemIndicou = dbRec[DBEnderecosDicInfo.QuemIndicou]?.ToString() ?? string.Empty; m_FQuemIndicou = dbRec[DBEnderecosDicInfo.QuemIndicou]?.ToString() ?? string.Empty;  } catch {}  try { m_FQuemIndicou = dbRec[DBEnderecosDicInfo.QuemIndicou]?.ToString() ?? string.Empty; m_FQuemIndicou = dbRec[DBEnderecosDicInfo.QuemIndicou]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FQuemIndicou = dbRec[DBEnderecosDicInfo.QuemIndicou]?.ToString() ?? string.Empty; } catch { }

#else
        m_FQuemIndicou = dbRec[DBEnderecosDicInfo.QuemIndicou]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.ReportECBOnly])) m_FReportECBOnly = (bool)dbRec[DBEnderecosDicInfo.ReportECBOnly]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.ReportECBOnly])) m_FReportECBOnly = (bool)dbRec[DBEnderecosDicInfo.ReportECBOnly];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.ReportECBOnly])) m_FReportECBOnly = (bool)dbRec[DBEnderecosDicInfo.ReportECBOnly]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.ReportECBOnly])) m_FReportECBOnly = (bool)dbRec[DBEnderecosDicInfo.ReportECBOnly];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.ReportECBOnly])) m_FReportECBOnly = (bool)dbRec[DBEnderecosDicInfo.ReportECBOnly]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.ReportECBOnly]))
            m_FReportECBOnly = (bool)dbRec[DBEnderecosDicInfo.ReportECBOnly];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBEnderecosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBEnderecosDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBEnderecosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBEnderecosDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBEnderecosDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBEnderecosDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Ani])) m_FAni = (bool)dbRec[DBEnderecosDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Ani])) m_FAni = (bool)dbRec[DBEnderecosDicInfo.Ani];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Ani])) m_FAni = (bool)dbRec[DBEnderecosDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Ani])) m_FAni = (bool)dbRec[DBEnderecosDicInfo.Ani];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Ani])) m_FAni = (bool)dbRec[DBEnderecosDicInfo.Ani]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Ani]))
            m_FAni = (bool)dbRec[DBEnderecosDicInfo.Ani];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEnderecosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEnderecosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEnderecosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEnderecosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEnderecosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBEnderecosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBEnderecosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBEnderecosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBEnderecosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBEnderecosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBEnderecosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBEnderecosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEnderecosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEnderecosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEnderecosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEnderecosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEnderecosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBEnderecosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}