namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBColaboradores
{
    public DBColaboradores(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Ani]))
                m_FAni = (bool)dbRec[DBColaboradoresDicInfo.Ani];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBColaboradoresDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cargo]))
                m_FCargo = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cargo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtNasc]))
                m_FDtNasc = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtNasc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBColaboradoresDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Idade]))
                m_FIdade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Idade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBColaboradoresDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBColaboradoresDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FCNH = dbRec[DBColaboradoresDicInfo.CNH]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBColaboradoresDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBColaboradoresDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBColaboradoresDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBColaboradoresDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBColaboradoresDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBColaboradoresDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FClass = dbRec[DBColaboradoresDicInfo.Class]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBColaboradoresDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBColaboradoresDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBColaboradoresDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBColaboradores(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Ani]))
                m_FAni = (bool)dbRec[DBColaboradoresDicInfo.Ani];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBColaboradoresDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cargo]))
                m_FCargo = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cargo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtNasc]))
                m_FDtNasc = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtNasc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBColaboradoresDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Idade]))
                m_FIdade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Idade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBColaboradoresDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBColaboradoresDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FCNH = dbRec[DBColaboradoresDicInfo.CNH]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBColaboradoresDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBColaboradoresDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBColaboradoresDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBColaboradoresDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBColaboradoresDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBColaboradoresDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FClass = dbRec[DBColaboradoresDicInfo.Class]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBColaboradoresDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBColaboradoresDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBColaboradoresDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Colaboradores
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[Colaboradores] (NOLOCK) WHERE [colCodigo] = @ThisIDToLoad", oCnn);
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
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cargo]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cargo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cargo]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cargo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cargo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cargo]))
            m_FCargo = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cargo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBColaboradoresDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBColaboradoresDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBColaboradoresDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBColaboradoresDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBColaboradoresDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBColaboradoresDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FNome = dbRec[DBColaboradoresDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBColaboradoresDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBColaboradoresDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBColaboradoresDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBColaboradoresDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBColaboradoresDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBColaboradoresDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBColaboradoresDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBColaboradoresDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBColaboradoresDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBColaboradoresDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBColaboradoresDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBColaboradoresDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBColaboradoresDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBColaboradoresDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBColaboradoresDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBColaboradoresDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBColaboradoresDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtNasc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtNasc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtNasc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtNasc]))
            m_FDtNasc = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtNasc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Idade]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Idade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Idade]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Idade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Idade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Idade]))
            m_FIdade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Idade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBColaboradoresDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBColaboradoresDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBColaboradoresDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBColaboradoresDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBColaboradoresDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBColaboradoresDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBColaboradoresDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBColaboradoresDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBColaboradoresDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBColaboradoresDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBColaboradoresDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBColaboradoresDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBColaboradoresDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBColaboradoresDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBColaboradoresDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBColaboradoresDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBColaboradoresDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBColaboradoresDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBColaboradoresDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBColaboradoresDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBColaboradoresDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBColaboradoresDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBColaboradoresDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBColaboradoresDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBColaboradoresDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBColaboradoresDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBColaboradoresDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBColaboradoresDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBColaboradoresDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBColaboradoresDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBColaboradoresDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBColaboradoresDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBColaboradoresDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBColaboradoresDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBColaboradoresDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBColaboradoresDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCNH = dbRec[DBColaboradoresDicInfo.CNH]?.ToString() ?? string.Empty; m_FCNH = dbRec[DBColaboradoresDicInfo.CNH]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNH = dbRec[DBColaboradoresDicInfo.CNH]?.ToString() ?? string.Empty; m_FCNH = dbRec[DBColaboradoresDicInfo.CNH]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNH = dbRec[DBColaboradoresDicInfo.CNH]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNH = dbRec[DBColaboradoresDicInfo.CNH]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FClass = dbRec[DBColaboradoresDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBColaboradoresDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FClass = dbRec[DBColaboradoresDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBColaboradoresDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FClass = dbRec[DBColaboradoresDicInfo.Class]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FClass = dbRec[DBColaboradoresDicInfo.Class]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBColaboradoresDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBColaboradoresDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBColaboradoresDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBColaboradoresDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBColaboradoresDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBColaboradoresDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Ani])) m_FAni = (bool)dbRec[DBColaboradoresDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Ani])) m_FAni = (bool)dbRec[DBColaboradoresDicInfo.Ani];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Ani])) m_FAni = (bool)dbRec[DBColaboradoresDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Ani])) m_FAni = (bool)dbRec[DBColaboradoresDicInfo.Ani];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Ani])) m_FAni = (bool)dbRec[DBColaboradoresDicInfo.Ani]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Ani]))
            m_FAni = (bool)dbRec[DBColaboradoresDicInfo.Ani];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBColaboradoresDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBColaboradoresDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBColaboradoresDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBColaboradoresDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBColaboradoresDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBColaboradoresDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBColaboradoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBColaboradoresDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBColaboradoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBColaboradoresDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBColaboradoresDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBColaboradoresDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Colaboradores
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
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cargo]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cargo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cargo]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cargo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cargo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cargo]))
            m_FCargo = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cargo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBColaboradoresDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBColaboradoresDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBColaboradoresDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBColaboradoresDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBColaboradoresDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBColaboradoresDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FNome = dbRec[DBColaboradoresDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBColaboradoresDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBColaboradoresDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBColaboradoresDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBColaboradoresDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBColaboradoresDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBColaboradoresDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBColaboradoresDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBColaboradoresDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBColaboradoresDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBColaboradoresDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBColaboradoresDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBColaboradoresDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBColaboradoresDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBColaboradoresDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBColaboradoresDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBColaboradoresDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBColaboradoresDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtNasc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtNasc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtNasc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtNasc]))
            m_FDtNasc = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtNasc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Idade]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Idade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Idade]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Idade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Idade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Idade]))
            m_FIdade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Idade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBColaboradoresDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBColaboradoresDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBColaboradoresDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBColaboradoresDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBColaboradoresDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBColaboradoresDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBColaboradoresDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBColaboradoresDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBColaboradoresDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBColaboradoresDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBColaboradoresDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBColaboradoresDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBColaboradoresDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBColaboradoresDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBColaboradoresDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBColaboradoresDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBColaboradoresDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBColaboradoresDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBColaboradoresDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBColaboradoresDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBColaboradoresDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBColaboradoresDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBColaboradoresDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBColaboradoresDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBColaboradoresDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBColaboradoresDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBColaboradoresDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBColaboradoresDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBColaboradoresDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBColaboradoresDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBColaboradoresDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBColaboradoresDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBColaboradoresDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBColaboradoresDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBColaboradoresDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBColaboradoresDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCNH = dbRec[DBColaboradoresDicInfo.CNH]?.ToString() ?? string.Empty; m_FCNH = dbRec[DBColaboradoresDicInfo.CNH]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNH = dbRec[DBColaboradoresDicInfo.CNH]?.ToString() ?? string.Empty; m_FCNH = dbRec[DBColaboradoresDicInfo.CNH]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNH = dbRec[DBColaboradoresDicInfo.CNH]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNH = dbRec[DBColaboradoresDicInfo.CNH]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FClass = dbRec[DBColaboradoresDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBColaboradoresDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FClass = dbRec[DBColaboradoresDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBColaboradoresDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FClass = dbRec[DBColaboradoresDicInfo.Class]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FClass = dbRec[DBColaboradoresDicInfo.Class]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBColaboradoresDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBColaboradoresDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBColaboradoresDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBColaboradoresDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBColaboradoresDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBColaboradoresDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Ani])) m_FAni = (bool)dbRec[DBColaboradoresDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Ani])) m_FAni = (bool)dbRec[DBColaboradoresDicInfo.Ani];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Ani])) m_FAni = (bool)dbRec[DBColaboradoresDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Ani])) m_FAni = (bool)dbRec[DBColaboradoresDicInfo.Ani];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Ani])) m_FAni = (bool)dbRec[DBColaboradoresDicInfo.Ani]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Ani]))
            m_FAni = (bool)dbRec[DBColaboradoresDicInfo.Ani];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBColaboradoresDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBColaboradoresDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBColaboradoresDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBColaboradoresDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBColaboradoresDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBColaboradoresDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBColaboradoresDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBColaboradoresDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBColaboradoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBColaboradoresDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBColaboradoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBColaboradoresDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBColaboradoresDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBColaboradoresDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBColaboradoresDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}