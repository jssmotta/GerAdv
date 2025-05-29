namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBFuncionarios
{
    public DBFuncionarios(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Ani]))
                m_FAni = (bool)dbRec[DBFuncionariosDicInfo.Ani];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBFuncionariosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cargo]))
                m_FCargo = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cargo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao]))
                m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtNasc]))
                m_FDtNasc = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtNasc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBFuncionariosDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Funcao]))
                m_FFuncao = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Funcao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.LiberaAgenda]))
                m_FLiberaAgenda = (bool)dbRec[DBFuncionariosDicInfo.LiberaAgenda];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Fim]))
                m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Fim]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Ini]))
                m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Ini]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Salario]))
                m_FSalario = Convert.ToDecimal(dbRec[DBFuncionariosDicInfo.Salario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBFuncionariosDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Tipo]))
                m_FTipo = (bool)dbRec[DBFuncionariosDicInfo.Tipo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBFuncionariosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FContato = dbRec[DBFuncionariosDicInfo.Contato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCTPSNumero = dbRec[DBFuncionariosDicInfo.CTPSNumero]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCTPSSerie = dbRec[DBFuncionariosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBFuncionariosDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMailPro = dbRec[DBFuncionariosDicInfo.EMailPro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBFuncionariosDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBFuncionariosDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBFuncionariosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBFuncionariosDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPasta = dbRec[DBFuncionariosDicInfo.Pasta]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPIS = dbRec[DBFuncionariosDicInfo.PIS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRegistro = dbRec[DBFuncionariosDicInfo.Registro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBFuncionariosDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBFuncionariosDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBFuncionariosDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FClass = dbRec[DBFuncionariosDicInfo.Class]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBFuncionariosDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBFuncionariosDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBFuncionariosDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBFuncionarios(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Ani]))
                m_FAni = (bool)dbRec[DBFuncionariosDicInfo.Ani];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBFuncionariosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cargo]))
                m_FCargo = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cargo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao]))
                m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtNasc]))
                m_FDtNasc = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtNasc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBFuncionariosDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Funcao]))
                m_FFuncao = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Funcao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.LiberaAgenda]))
                m_FLiberaAgenda = (bool)dbRec[DBFuncionariosDicInfo.LiberaAgenda];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Fim]))
                m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Fim]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Ini]))
                m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Ini]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Salario]))
                m_FSalario = Convert.ToDecimal(dbRec[DBFuncionariosDicInfo.Salario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBFuncionariosDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Tipo]))
                m_FTipo = (bool)dbRec[DBFuncionariosDicInfo.Tipo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBFuncionariosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FContato = dbRec[DBFuncionariosDicInfo.Contato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCTPSNumero = dbRec[DBFuncionariosDicInfo.CTPSNumero]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCTPSSerie = dbRec[DBFuncionariosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBFuncionariosDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMailPro = dbRec[DBFuncionariosDicInfo.EMailPro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBFuncionariosDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBFuncionariosDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBFuncionariosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBFuncionariosDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPasta = dbRec[DBFuncionariosDicInfo.Pasta]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPIS = dbRec[DBFuncionariosDicInfo.PIS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRegistro = dbRec[DBFuncionariosDicInfo.Registro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBFuncionariosDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBFuncionariosDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBFuncionariosDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FClass = dbRec[DBFuncionariosDicInfo.Class]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBFuncionariosDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBFuncionariosDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBFuncionariosDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Funcionarios
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [funCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FEMailPro = dbRec[DBFuncionariosDicInfo.EMailPro]?.ToString() ?? string.Empty; m_FEMailPro = dbRec[DBFuncionariosDicInfo.EMailPro]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMailPro = dbRec[DBFuncionariosDicInfo.EMailPro]?.ToString() ?? string.Empty; m_FEMailPro = dbRec[DBFuncionariosDicInfo.EMailPro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMailPro = dbRec[DBFuncionariosDicInfo.EMailPro]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMailPro = dbRec[DBFuncionariosDicInfo.EMailPro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cargo]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cargo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cargo]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cargo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cargo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cargo]))
            m_FCargo = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cargo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FNome = dbRec[DBFuncionariosDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBFuncionariosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBFuncionariosDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBFuncionariosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBFuncionariosDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBFuncionariosDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Funcao])) m_FFuncao = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Funcao]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Funcao])) m_FFuncao = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Funcao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Funcao])) m_FFuncao = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Funcao]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Funcao])) m_FFuncao = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Funcao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Funcao])) m_FFuncao = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Funcao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Funcao]))
            m_FFuncao = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Funcao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBFuncionariosDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBFuncionariosDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBFuncionariosDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBFuncionariosDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBFuncionariosDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBFuncionariosDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRegistro = dbRec[DBFuncionariosDicInfo.Registro]?.ToString() ?? string.Empty; m_FRegistro = dbRec[DBFuncionariosDicInfo.Registro]?.ToString() ?? string.Empty;  } catch {}  try { m_FRegistro = dbRec[DBFuncionariosDicInfo.Registro]?.ToString() ?? string.Empty; m_FRegistro = dbRec[DBFuncionariosDicInfo.Registro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRegistro = dbRec[DBFuncionariosDicInfo.Registro]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRegistro = dbRec[DBFuncionariosDicInfo.Registro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBFuncionariosDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBFuncionariosDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBFuncionariosDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBFuncionariosDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBFuncionariosDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBFuncionariosDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBFuncionariosDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBFuncionariosDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBFuncionariosDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBFuncionariosDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBFuncionariosDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBFuncionariosDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBFuncionariosDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBFuncionariosDicInfo.Tipo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBFuncionariosDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBFuncionariosDicInfo.Tipo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBFuncionariosDicInfo.Tipo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Tipo]))
            m_FTipo = (bool)dbRec[DBFuncionariosDicInfo.Tipo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBFuncionariosDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBFuncionariosDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBFuncionariosDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBFuncionariosDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBFuncionariosDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBFuncionariosDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBFuncionariosDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBFuncionariosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBFuncionariosDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBFuncionariosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBFuncionariosDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBFuncionariosDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBFuncionariosDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBFuncionariosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBFuncionariosDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBFuncionariosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBFuncionariosDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBFuncionariosDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBFuncionariosDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBFuncionariosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBFuncionariosDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBFuncionariosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBFuncionariosDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBFuncionariosDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FContato = dbRec[DBFuncionariosDicInfo.Contato]?.ToString() ?? string.Empty; m_FContato = dbRec[DBFuncionariosDicInfo.Contato]?.ToString() ?? string.Empty;  } catch {}  try { m_FContato = dbRec[DBFuncionariosDicInfo.Contato]?.ToString() ?? string.Empty; m_FContato = dbRec[DBFuncionariosDicInfo.Contato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FContato = dbRec[DBFuncionariosDicInfo.Contato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FContato = dbRec[DBFuncionariosDicInfo.Contato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBFuncionariosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBFuncionariosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBFuncionariosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBFuncionariosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBFuncionariosDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBFuncionariosDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBFuncionariosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBFuncionariosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBFuncionariosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBFuncionariosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBFuncionariosDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBFuncionariosDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBFuncionariosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBFuncionariosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBFuncionariosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBFuncionariosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBFuncionariosDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBFuncionariosDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Ini])) m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Ini]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Ini])) m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Ini]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Ini])) m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Ini]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Ini])) m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Ini]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Ini])) m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Ini]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Ini]))
            m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Ini]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Fim])) m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Fim]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Fim])) m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Fim]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Fim])) m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Fim]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Fim])) m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Fim]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Fim])) m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Fim]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Fim]))
            m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Fim]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCTPSNumero = dbRec[DBFuncionariosDicInfo.CTPSNumero]?.ToString() ?? string.Empty; m_FCTPSNumero = dbRec[DBFuncionariosDicInfo.CTPSNumero]?.ToString() ?? string.Empty;  } catch {}  try { m_FCTPSNumero = dbRec[DBFuncionariosDicInfo.CTPSNumero]?.ToString() ?? string.Empty; m_FCTPSNumero = dbRec[DBFuncionariosDicInfo.CTPSNumero]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCTPSNumero = dbRec[DBFuncionariosDicInfo.CTPSNumero]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCTPSNumero = dbRec[DBFuncionariosDicInfo.CTPSNumero]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCTPSSerie = dbRec[DBFuncionariosDicInfo.CTPSSerie]?.ToString() ?? string.Empty; m_FCTPSSerie = dbRec[DBFuncionariosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;  } catch {}  try { m_FCTPSSerie = dbRec[DBFuncionariosDicInfo.CTPSSerie]?.ToString() ?? string.Empty; m_FCTPSSerie = dbRec[DBFuncionariosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCTPSSerie = dbRec[DBFuncionariosDicInfo.CTPSSerie]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCTPSSerie = dbRec[DBFuncionariosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPIS = dbRec[DBFuncionariosDicInfo.PIS]?.ToString() ?? string.Empty; m_FPIS = dbRec[DBFuncionariosDicInfo.PIS]?.ToString() ?? string.Empty;  } catch {}  try { m_FPIS = dbRec[DBFuncionariosDicInfo.PIS]?.ToString() ?? string.Empty; m_FPIS = dbRec[DBFuncionariosDicInfo.PIS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPIS = dbRec[DBFuncionariosDicInfo.PIS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPIS = dbRec[DBFuncionariosDicInfo.PIS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBFuncionariosDicInfo.Salario]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBFuncionariosDicInfo.Salario]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBFuncionariosDicInfo.Salario]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBFuncionariosDicInfo.Salario]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBFuncionariosDicInfo.Salario]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Salario]))
            m_FSalario = Convert.ToDecimal(dbRec[DBFuncionariosDicInfo.Salario]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao])) m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao])) m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao])) m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao])) m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao])) m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao]))
            m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtNasc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtNasc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtNasc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtNasc]))
            m_FDtNasc = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtNasc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.LiberaAgenda])) m_FLiberaAgenda = (bool)dbRec[DBFuncionariosDicInfo.LiberaAgenda]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.LiberaAgenda])) m_FLiberaAgenda = (bool)dbRec[DBFuncionariosDicInfo.LiberaAgenda];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.LiberaAgenda])) m_FLiberaAgenda = (bool)dbRec[DBFuncionariosDicInfo.LiberaAgenda]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.LiberaAgenda])) m_FLiberaAgenda = (bool)dbRec[DBFuncionariosDicInfo.LiberaAgenda];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.LiberaAgenda])) m_FLiberaAgenda = (bool)dbRec[DBFuncionariosDicInfo.LiberaAgenda]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.LiberaAgenda]))
            m_FLiberaAgenda = (bool)dbRec[DBFuncionariosDicInfo.LiberaAgenda];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPasta = dbRec[DBFuncionariosDicInfo.Pasta]?.ToString() ?? string.Empty; m_FPasta = dbRec[DBFuncionariosDicInfo.Pasta]?.ToString() ?? string.Empty;  } catch {}  try { m_FPasta = dbRec[DBFuncionariosDicInfo.Pasta]?.ToString() ?? string.Empty; m_FPasta = dbRec[DBFuncionariosDicInfo.Pasta]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPasta = dbRec[DBFuncionariosDicInfo.Pasta]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPasta = dbRec[DBFuncionariosDicInfo.Pasta]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FClass = dbRec[DBFuncionariosDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBFuncionariosDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FClass = dbRec[DBFuncionariosDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBFuncionariosDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FClass = dbRec[DBFuncionariosDicInfo.Class]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FClass = dbRec[DBFuncionariosDicInfo.Class]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBFuncionariosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBFuncionariosDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBFuncionariosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBFuncionariosDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBFuncionariosDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBFuncionariosDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Ani])) m_FAni = (bool)dbRec[DBFuncionariosDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Ani])) m_FAni = (bool)dbRec[DBFuncionariosDicInfo.Ani];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Ani])) m_FAni = (bool)dbRec[DBFuncionariosDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Ani])) m_FAni = (bool)dbRec[DBFuncionariosDicInfo.Ani];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Ani])) m_FAni = (bool)dbRec[DBFuncionariosDicInfo.Ani]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Ani]))
            m_FAni = (bool)dbRec[DBFuncionariosDicInfo.Ani];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Bold])) m_FBold = (bool)dbRec[DBFuncionariosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Bold])) m_FBold = (bool)dbRec[DBFuncionariosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Bold])) m_FBold = (bool)dbRec[DBFuncionariosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Bold])) m_FBold = (bool)dbRec[DBFuncionariosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Bold])) m_FBold = (bool)dbRec[DBFuncionariosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBFuncionariosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBFuncionariosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBFuncionariosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBFuncionariosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBFuncionariosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBFuncionariosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBFuncionariosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFuncionariosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFuncionariosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFuncionariosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFuncionariosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFuncionariosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBFuncionariosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Funcionarios
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
m_FEMailPro = dbRec[DBFuncionariosDicInfo.EMailPro]?.ToString() ?? string.Empty; m_FEMailPro = dbRec[DBFuncionariosDicInfo.EMailPro]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMailPro = dbRec[DBFuncionariosDicInfo.EMailPro]?.ToString() ?? string.Empty; m_FEMailPro = dbRec[DBFuncionariosDicInfo.EMailPro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMailPro = dbRec[DBFuncionariosDicInfo.EMailPro]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMailPro = dbRec[DBFuncionariosDicInfo.EMailPro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cargo]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cargo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cargo]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cargo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cargo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cargo]))
            m_FCargo = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cargo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FNome = dbRec[DBFuncionariosDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBFuncionariosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBFuncionariosDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBFuncionariosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBFuncionariosDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBFuncionariosDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Funcao])) m_FFuncao = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Funcao]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Funcao])) m_FFuncao = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Funcao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Funcao])) m_FFuncao = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Funcao]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Funcao])) m_FFuncao = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Funcao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Funcao])) m_FFuncao = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Funcao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Funcao]))
            m_FFuncao = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Funcao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBFuncionariosDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBFuncionariosDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBFuncionariosDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBFuncionariosDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBFuncionariosDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBFuncionariosDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRegistro = dbRec[DBFuncionariosDicInfo.Registro]?.ToString() ?? string.Empty; m_FRegistro = dbRec[DBFuncionariosDicInfo.Registro]?.ToString() ?? string.Empty;  } catch {}  try { m_FRegistro = dbRec[DBFuncionariosDicInfo.Registro]?.ToString() ?? string.Empty; m_FRegistro = dbRec[DBFuncionariosDicInfo.Registro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRegistro = dbRec[DBFuncionariosDicInfo.Registro]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRegistro = dbRec[DBFuncionariosDicInfo.Registro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBFuncionariosDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBFuncionariosDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBFuncionariosDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBFuncionariosDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBFuncionariosDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBFuncionariosDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBFuncionariosDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBFuncionariosDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBFuncionariosDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBFuncionariosDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBFuncionariosDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBFuncionariosDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBFuncionariosDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBFuncionariosDicInfo.Tipo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBFuncionariosDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBFuncionariosDicInfo.Tipo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBFuncionariosDicInfo.Tipo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Tipo]))
            m_FTipo = (bool)dbRec[DBFuncionariosDicInfo.Tipo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBFuncionariosDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBFuncionariosDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBFuncionariosDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBFuncionariosDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBFuncionariosDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBFuncionariosDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBFuncionariosDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBFuncionariosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBFuncionariosDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBFuncionariosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBFuncionariosDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBFuncionariosDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBFuncionariosDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBFuncionariosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBFuncionariosDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBFuncionariosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBFuncionariosDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBFuncionariosDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBFuncionariosDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBFuncionariosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBFuncionariosDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBFuncionariosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBFuncionariosDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBFuncionariosDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FContato = dbRec[DBFuncionariosDicInfo.Contato]?.ToString() ?? string.Empty; m_FContato = dbRec[DBFuncionariosDicInfo.Contato]?.ToString() ?? string.Empty;  } catch {}  try { m_FContato = dbRec[DBFuncionariosDicInfo.Contato]?.ToString() ?? string.Empty; m_FContato = dbRec[DBFuncionariosDicInfo.Contato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FContato = dbRec[DBFuncionariosDicInfo.Contato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FContato = dbRec[DBFuncionariosDicInfo.Contato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBFuncionariosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBFuncionariosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBFuncionariosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBFuncionariosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBFuncionariosDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBFuncionariosDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBFuncionariosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBFuncionariosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBFuncionariosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBFuncionariosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBFuncionariosDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBFuncionariosDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBFuncionariosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBFuncionariosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBFuncionariosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBFuncionariosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBFuncionariosDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBFuncionariosDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Ini])) m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Ini]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Ini])) m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Ini]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Ini])) m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Ini]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Ini])) m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Ini]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Ini])) m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Ini]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Ini]))
            m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Ini]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Fim])) m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Fim]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Fim])) m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Fim]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Fim])) m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Fim]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Fim])) m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Fim]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Fim])) m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Fim]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Periodo_Fim]))
            m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Periodo_Fim]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCTPSNumero = dbRec[DBFuncionariosDicInfo.CTPSNumero]?.ToString() ?? string.Empty; m_FCTPSNumero = dbRec[DBFuncionariosDicInfo.CTPSNumero]?.ToString() ?? string.Empty;  } catch {}  try { m_FCTPSNumero = dbRec[DBFuncionariosDicInfo.CTPSNumero]?.ToString() ?? string.Empty; m_FCTPSNumero = dbRec[DBFuncionariosDicInfo.CTPSNumero]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCTPSNumero = dbRec[DBFuncionariosDicInfo.CTPSNumero]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCTPSNumero = dbRec[DBFuncionariosDicInfo.CTPSNumero]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCTPSSerie = dbRec[DBFuncionariosDicInfo.CTPSSerie]?.ToString() ?? string.Empty; m_FCTPSSerie = dbRec[DBFuncionariosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;  } catch {}  try { m_FCTPSSerie = dbRec[DBFuncionariosDicInfo.CTPSSerie]?.ToString() ?? string.Empty; m_FCTPSSerie = dbRec[DBFuncionariosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCTPSSerie = dbRec[DBFuncionariosDicInfo.CTPSSerie]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCTPSSerie = dbRec[DBFuncionariosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPIS = dbRec[DBFuncionariosDicInfo.PIS]?.ToString() ?? string.Empty; m_FPIS = dbRec[DBFuncionariosDicInfo.PIS]?.ToString() ?? string.Empty;  } catch {}  try { m_FPIS = dbRec[DBFuncionariosDicInfo.PIS]?.ToString() ?? string.Empty; m_FPIS = dbRec[DBFuncionariosDicInfo.PIS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPIS = dbRec[DBFuncionariosDicInfo.PIS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPIS = dbRec[DBFuncionariosDicInfo.PIS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBFuncionariosDicInfo.Salario]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBFuncionariosDicInfo.Salario]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBFuncionariosDicInfo.Salario]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBFuncionariosDicInfo.Salario]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBFuncionariosDicInfo.Salario]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Salario]))
            m_FSalario = Convert.ToDecimal(dbRec[DBFuncionariosDicInfo.Salario]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao])) m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao])) m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao])) m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao])) m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao])) m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao]))
            m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.CTPSDtEmissao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtNasc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtNasc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtNasc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtNasc]))
            m_FDtNasc = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtNasc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.LiberaAgenda])) m_FLiberaAgenda = (bool)dbRec[DBFuncionariosDicInfo.LiberaAgenda]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.LiberaAgenda])) m_FLiberaAgenda = (bool)dbRec[DBFuncionariosDicInfo.LiberaAgenda];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.LiberaAgenda])) m_FLiberaAgenda = (bool)dbRec[DBFuncionariosDicInfo.LiberaAgenda]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.LiberaAgenda])) m_FLiberaAgenda = (bool)dbRec[DBFuncionariosDicInfo.LiberaAgenda];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.LiberaAgenda])) m_FLiberaAgenda = (bool)dbRec[DBFuncionariosDicInfo.LiberaAgenda]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.LiberaAgenda]))
            m_FLiberaAgenda = (bool)dbRec[DBFuncionariosDicInfo.LiberaAgenda];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPasta = dbRec[DBFuncionariosDicInfo.Pasta]?.ToString() ?? string.Empty; m_FPasta = dbRec[DBFuncionariosDicInfo.Pasta]?.ToString() ?? string.Empty;  } catch {}  try { m_FPasta = dbRec[DBFuncionariosDicInfo.Pasta]?.ToString() ?? string.Empty; m_FPasta = dbRec[DBFuncionariosDicInfo.Pasta]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPasta = dbRec[DBFuncionariosDicInfo.Pasta]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPasta = dbRec[DBFuncionariosDicInfo.Pasta]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FClass = dbRec[DBFuncionariosDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBFuncionariosDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FClass = dbRec[DBFuncionariosDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBFuncionariosDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FClass = dbRec[DBFuncionariosDicInfo.Class]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FClass = dbRec[DBFuncionariosDicInfo.Class]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBFuncionariosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBFuncionariosDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBFuncionariosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBFuncionariosDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBFuncionariosDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBFuncionariosDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Ani])) m_FAni = (bool)dbRec[DBFuncionariosDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Ani])) m_FAni = (bool)dbRec[DBFuncionariosDicInfo.Ani];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Ani])) m_FAni = (bool)dbRec[DBFuncionariosDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Ani])) m_FAni = (bool)dbRec[DBFuncionariosDicInfo.Ani];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Ani])) m_FAni = (bool)dbRec[DBFuncionariosDicInfo.Ani]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Ani]))
            m_FAni = (bool)dbRec[DBFuncionariosDicInfo.Ani];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Bold])) m_FBold = (bool)dbRec[DBFuncionariosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Bold])) m_FBold = (bool)dbRec[DBFuncionariosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Bold])) m_FBold = (bool)dbRec[DBFuncionariosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Bold])) m_FBold = (bool)dbRec[DBFuncionariosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Bold])) m_FBold = (bool)dbRec[DBFuncionariosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBFuncionariosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBFuncionariosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBFuncionariosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBFuncionariosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBFuncionariosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBFuncionariosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBFuncionariosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBFuncionariosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBFuncionariosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFuncionariosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFuncionariosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFuncionariosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFuncionariosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFuncionariosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFuncionariosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBFuncionariosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}