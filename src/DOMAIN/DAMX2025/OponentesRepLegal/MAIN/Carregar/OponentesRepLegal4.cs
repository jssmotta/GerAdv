namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOponentesRepLegal
{
    public DBOponentesRepLegal(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBOponentesRepLegalDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Oponente]))
                m_FOponente = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Oponente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBOponentesRepLegalDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOponentesRepLegalDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBOponentesRepLegalDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBOponentesRepLegalDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBOponentesRepLegalDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBOponentesRepLegalDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBOponentesRepLegalDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSite = dbRec[DBOponentesRepLegalDicInfo.Site]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBOponentesRepLegalDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBOponentesRepLegalDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBOponentesRepLegalDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBOponentesRepLegalDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBOponentesRepLegalDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBOponentesRepLegal(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBOponentesRepLegalDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Oponente]))
                m_FOponente = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Oponente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBOponentesRepLegalDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOponentesRepLegalDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBOponentesRepLegalDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBOponentesRepLegalDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBOponentesRepLegalDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBOponentesRepLegalDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBOponentesRepLegalDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSite = dbRec[DBOponentesRepLegalDicInfo.Site]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBOponentesRepLegalDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBOponentesRepLegalDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBOponentesRepLegalDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBOponentesRepLegalDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBOponentesRepLegalDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_OponentesRepLegal
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[OponentesRepLegal] (NOLOCK) WHERE [oprCodigo] = @ThisIDToLoad", oCnn);
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
// region JMen - nType = 203
sex.m_FNome = dbRec[DBOponentesRepLegalDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBOponentesRepLegalDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBOponentesRepLegalDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBOponentesRepLegalDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBOponentesRepLegalDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBOponentesRepLegalDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBOponentesRepLegalDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBOponentesRepLegalDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBOponentesRepLegalDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBOponentesRepLegalDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBOponentesRepLegalDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBOponentesRepLegalDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Oponente]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Oponente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Oponente]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Oponente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Oponente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Oponente]))
            m_FOponente = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Oponente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOponentesRepLegalDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOponentesRepLegalDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOponentesRepLegalDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOponentesRepLegalDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOponentesRepLegalDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBOponentesRepLegalDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBOponentesRepLegalDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBOponentesRepLegalDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBOponentesRepLegalDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBOponentesRepLegalDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBOponentesRepLegalDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBOponentesRepLegalDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBOponentesRepLegalDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBOponentesRepLegalDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBOponentesRepLegalDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBOponentesRepLegalDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBOponentesRepLegalDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBOponentesRepLegalDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBOponentesRepLegalDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBOponentesRepLegalDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBOponentesRepLegalDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBOponentesRepLegalDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBOponentesRepLegalDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBOponentesRepLegalDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBOponentesRepLegalDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBOponentesRepLegalDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBOponentesRepLegalDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBOponentesRepLegalDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBOponentesRepLegalDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBOponentesRepLegalDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBOponentesRepLegalDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBOponentesRepLegalDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBOponentesRepLegalDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBOponentesRepLegalDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBOponentesRepLegalDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBOponentesRepLegalDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBOponentesRepLegalDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBOponentesRepLegalDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBOponentesRepLegalDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBOponentesRepLegalDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBOponentesRepLegalDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBOponentesRepLegalDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBOponentesRepLegalDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBOponentesRepLegalDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBOponentesRepLegalDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBOponentesRepLegalDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBOponentesRepLegalDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBOponentesRepLegalDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSite = dbRec[DBOponentesRepLegalDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBOponentesRepLegalDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { m_FSite = dbRec[DBOponentesRepLegalDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBOponentesRepLegalDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSite = dbRec[DBOponentesRepLegalDicInfo.Site]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSite = dbRec[DBOponentesRepLegalDicInfo.Site]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBOponentesRepLegalDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBOponentesRepLegalDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBOponentesRepLegalDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBOponentesRepLegalDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBOponentesRepLegalDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBOponentesRepLegalDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Bold])) m_FBold = (bool)dbRec[DBOponentesRepLegalDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Bold])) m_FBold = (bool)dbRec[DBOponentesRepLegalDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Bold])) m_FBold = (bool)dbRec[DBOponentesRepLegalDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Bold])) m_FBold = (bool)dbRec[DBOponentesRepLegalDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Bold])) m_FBold = (bool)dbRec[DBOponentesRepLegalDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBOponentesRepLegalDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOponentesRepLegalDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOponentesRepLegalDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOponentesRepLegalDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOponentesRepLegalDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOponentesRepLegalDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBOponentesRepLegalDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_OponentesRepLegal
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
// region JMen - nType = 203
sex.m_FNome = dbRec[DBOponentesRepLegalDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBOponentesRepLegalDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBOponentesRepLegalDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBOponentesRepLegalDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBOponentesRepLegalDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBOponentesRepLegalDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBOponentesRepLegalDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBOponentesRepLegalDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBOponentesRepLegalDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBOponentesRepLegalDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBOponentesRepLegalDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBOponentesRepLegalDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Oponente]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Oponente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Oponente]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Oponente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Oponente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Oponente]))
            m_FOponente = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Oponente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOponentesRepLegalDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOponentesRepLegalDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOponentesRepLegalDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOponentesRepLegalDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOponentesRepLegalDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBOponentesRepLegalDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBOponentesRepLegalDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBOponentesRepLegalDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBOponentesRepLegalDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBOponentesRepLegalDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBOponentesRepLegalDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBOponentesRepLegalDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBOponentesRepLegalDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBOponentesRepLegalDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBOponentesRepLegalDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBOponentesRepLegalDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBOponentesRepLegalDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBOponentesRepLegalDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBOponentesRepLegalDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBOponentesRepLegalDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBOponentesRepLegalDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBOponentesRepLegalDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBOponentesRepLegalDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBOponentesRepLegalDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBOponentesRepLegalDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBOponentesRepLegalDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBOponentesRepLegalDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBOponentesRepLegalDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBOponentesRepLegalDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBOponentesRepLegalDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBOponentesRepLegalDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBOponentesRepLegalDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBOponentesRepLegalDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBOponentesRepLegalDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBOponentesRepLegalDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBOponentesRepLegalDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBOponentesRepLegalDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBOponentesRepLegalDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBOponentesRepLegalDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBOponentesRepLegalDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBOponentesRepLegalDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBOponentesRepLegalDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBOponentesRepLegalDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBOponentesRepLegalDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBOponentesRepLegalDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBOponentesRepLegalDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBOponentesRepLegalDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBOponentesRepLegalDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSite = dbRec[DBOponentesRepLegalDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBOponentesRepLegalDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { m_FSite = dbRec[DBOponentesRepLegalDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBOponentesRepLegalDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSite = dbRec[DBOponentesRepLegalDicInfo.Site]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSite = dbRec[DBOponentesRepLegalDicInfo.Site]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBOponentesRepLegalDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBOponentesRepLegalDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBOponentesRepLegalDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBOponentesRepLegalDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBOponentesRepLegalDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBOponentesRepLegalDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Bold])) m_FBold = (bool)dbRec[DBOponentesRepLegalDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Bold])) m_FBold = (bool)dbRec[DBOponentesRepLegalDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Bold])) m_FBold = (bool)dbRec[DBOponentesRepLegalDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Bold])) m_FBold = (bool)dbRec[DBOponentesRepLegalDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Bold])) m_FBold = (bool)dbRec[DBOponentesRepLegalDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBOponentesRepLegalDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesRepLegalDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesRepLegalDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOponentesRepLegalDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOponentesRepLegalDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOponentesRepLegalDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOponentesRepLegalDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOponentesRepLegalDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesRepLegalDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBOponentesRepLegalDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}