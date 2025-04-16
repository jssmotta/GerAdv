namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPreClientes
{
    public DBPreClientes(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Adv]))
                m_FAdv = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Adv]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Ani]))
                m_FAni = (bool)dbRec[DBPreClientesDicInfo.Ani];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBPreClientesDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtNasc]))
                m_FDtNasc = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtNasc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBPreClientesDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Idade]))
                m_FIdade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Idade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.IDRep]))
                m_FIDRep = Convert.ToInt32(dbRec[DBPreClientesDicInfo.IDRep]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Inativo]))
                m_FInativo = (bool)dbRec[DBPreClientesDicInfo.Inativo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Juridica]))
                m_FJuridica = (bool)dbRec[DBPreClientesDicInfo.Juridica];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBPreClientesDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Tipo]))
                m_FTipo = (bool)dbRec[DBPreClientesDicInfo.Tipo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.TipoCaptacao]))
                m_FTipoCaptacao = (bool)dbRec[DBPreClientesDicInfo.TipoCaptacao];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBPreClientesDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FAssCPF = dbRec[DBPreClientesDicInfo.AssCPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FAssEndereco = dbRec[DBPreClientesDicInfo.AssEndereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FAssistido = dbRec[DBPreClientesDicInfo.Assistido]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FAssRG = dbRec[DBPreClientesDicInfo.AssRG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCNH = dbRec[DBPreClientesDicInfo.CNH]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCNPJ = dbRec[DBPreClientesDicInfo.CNPJ]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBPreClientesDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBPreClientesDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBPreClientesDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FHomePage = dbRec[DBPreClientesDicInfo.HomePage]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FInscEst = dbRec[DBPreClientesDicInfo.InscEst]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeFantasia = dbRec[DBPreClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBPreClientesDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FQualificacao = dbRec[DBPreClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FQuemIndicou = dbRec[DBPreClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBPreClientesDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBPreClientesDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBPreClientesDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FClass = dbRec[DBPreClientesDicInfo.Class]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBPreClientesDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBPreClientesDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBPreClientesDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBPreClientes(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Adv]))
                m_FAdv = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Adv]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Ani]))
                m_FAni = (bool)dbRec[DBPreClientesDicInfo.Ani];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBPreClientesDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtNasc]))
                m_FDtNasc = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtNasc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBPreClientesDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Idade]))
                m_FIdade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Idade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.IDRep]))
                m_FIDRep = Convert.ToInt32(dbRec[DBPreClientesDicInfo.IDRep]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Inativo]))
                m_FInativo = (bool)dbRec[DBPreClientesDicInfo.Inativo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Juridica]))
                m_FJuridica = (bool)dbRec[DBPreClientesDicInfo.Juridica];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBPreClientesDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Tipo]))
                m_FTipo = (bool)dbRec[DBPreClientesDicInfo.Tipo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.TipoCaptacao]))
                m_FTipoCaptacao = (bool)dbRec[DBPreClientesDicInfo.TipoCaptacao];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBPreClientesDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FAssCPF = dbRec[DBPreClientesDicInfo.AssCPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FAssEndereco = dbRec[DBPreClientesDicInfo.AssEndereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FAssistido = dbRec[DBPreClientesDicInfo.Assistido]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FAssRG = dbRec[DBPreClientesDicInfo.AssRG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCNH = dbRec[DBPreClientesDicInfo.CNH]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCNPJ = dbRec[DBPreClientesDicInfo.CNPJ]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBPreClientesDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBPreClientesDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBPreClientesDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FHomePage = dbRec[DBPreClientesDicInfo.HomePage]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FInscEst = dbRec[DBPreClientesDicInfo.InscEst]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeFantasia = dbRec[DBPreClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBPreClientesDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FQualificacao = dbRec[DBPreClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FQuemIndicou = dbRec[DBPreClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBPreClientesDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBPreClientesDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBPreClientesDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FClass = dbRec[DBPreClientesDicInfo.Class]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBPreClientesDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBPreClientesDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBPreClientesDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_PreClientes
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[PreClientes] (NOLOCK) WHERE [cliCodigo] = @ThisIDToLoad", oCnn);
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
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBPreClientesDicInfo.Inativo]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBPreClientesDicInfo.Inativo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBPreClientesDicInfo.Inativo]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBPreClientesDicInfo.Inativo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBPreClientesDicInfo.Inativo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Inativo]))
            m_FInativo = (bool)dbRec[DBPreClientesDicInfo.Inativo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FQuemIndicou = dbRec[DBPreClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty; m_FQuemIndicou = dbRec[DBPreClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty;  } catch {}  try { m_FQuemIndicou = dbRec[DBPreClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty; m_FQuemIndicou = dbRec[DBPreClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FQuemIndicou = dbRec[DBPreClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty; } catch { }

#else
        m_FQuemIndicou = dbRec[DBPreClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FNome = dbRec[DBPreClientesDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBPreClientesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBPreClientesDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBPreClientesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBPreClientesDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBPreClientesDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Adv]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Adv]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Adv]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Adv]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Adv]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Adv]))
            m_FAdv = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Adv]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBPreClientesDicInfo.IDRep]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBPreClientesDicInfo.IDRep]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBPreClientesDicInfo.IDRep]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBPreClientesDicInfo.IDRep]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBPreClientesDicInfo.IDRep]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.IDRep]))
            m_FIDRep = Convert.ToInt32(dbRec[DBPreClientesDicInfo.IDRep]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBPreClientesDicInfo.Juridica]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBPreClientesDicInfo.Juridica];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBPreClientesDicInfo.Juridica]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBPreClientesDicInfo.Juridica];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBPreClientesDicInfo.Juridica]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Juridica]))
            m_FJuridica = (bool)dbRec[DBPreClientesDicInfo.Juridica];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeFantasia = dbRec[DBPreClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty; m_FNomeFantasia = dbRec[DBPreClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeFantasia = dbRec[DBPreClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty; m_FNomeFantasia = dbRec[DBPreClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeFantasia = dbRec[DBPreClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeFantasia = dbRec[DBPreClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FClass = dbRec[DBPreClientesDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBPreClientesDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FClass = dbRec[DBPreClientesDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBPreClientesDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FClass = dbRec[DBPreClientesDicInfo.Class]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FClass = dbRec[DBPreClientesDicInfo.Class]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBPreClientesDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBPreClientesDicInfo.Tipo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBPreClientesDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBPreClientesDicInfo.Tipo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBPreClientesDicInfo.Tipo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Tipo]))
            m_FTipo = (bool)dbRec[DBPreClientesDicInfo.Tipo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtNasc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtNasc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtNasc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtNasc]))
            m_FDtNasc = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtNasc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FInscEst = dbRec[DBPreClientesDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBPreClientesDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { m_FInscEst = dbRec[DBPreClientesDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBPreClientesDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FInscEst = dbRec[DBPreClientesDicInfo.InscEst]?.ToString() ?? string.Empty; } catch { }

#else
        m_FInscEst = dbRec[DBPreClientesDicInfo.InscEst]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FQualificacao = dbRec[DBPreClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty; m_FQualificacao = dbRec[DBPreClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FQualificacao = dbRec[DBPreClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty; m_FQualificacao = dbRec[DBPreClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FQualificacao = dbRec[DBPreClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FQualificacao = dbRec[DBPreClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBPreClientesDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBPreClientesDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBPreClientesDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBPreClientesDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBPreClientesDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBPreClientesDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Idade]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Idade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Idade]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Idade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Idade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Idade]))
            m_FIdade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Idade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCNPJ = dbRec[DBPreClientesDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBPreClientesDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNPJ = dbRec[DBPreClientesDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBPreClientesDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNPJ = dbRec[DBPreClientesDicInfo.CNPJ]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNPJ = dbRec[DBPreClientesDicInfo.CNPJ]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBPreClientesDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBPreClientesDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBPreClientesDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBPreClientesDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBPreClientesDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBPreClientesDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBPreClientesDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBPreClientesDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBPreClientesDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBPreClientesDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBPreClientesDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBPreClientesDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.TipoCaptacao])) m_FTipoCaptacao = (bool)dbRec[DBPreClientesDicInfo.TipoCaptacao]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.TipoCaptacao])) m_FTipoCaptacao = (bool)dbRec[DBPreClientesDicInfo.TipoCaptacao];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.TipoCaptacao])) m_FTipoCaptacao = (bool)dbRec[DBPreClientesDicInfo.TipoCaptacao]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.TipoCaptacao])) m_FTipoCaptacao = (bool)dbRec[DBPreClientesDicInfo.TipoCaptacao];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.TipoCaptacao])) m_FTipoCaptacao = (bool)dbRec[DBPreClientesDicInfo.TipoCaptacao]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.TipoCaptacao]))
            m_FTipoCaptacao = (bool)dbRec[DBPreClientesDicInfo.TipoCaptacao];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBPreClientesDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBPreClientesDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBPreClientesDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBPreClientesDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBPreClientesDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBPreClientesDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBPreClientesDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBPreClientesDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBPreClientesDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBPreClientesDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBPreClientesDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBPreClientesDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBPreClientesDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBPreClientesDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBPreClientesDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBPreClientesDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBPreClientesDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBPreClientesDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBPreClientesDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBPreClientesDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBPreClientesDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBPreClientesDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBPreClientesDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBPreClientesDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBPreClientesDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBPreClientesDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBPreClientesDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBPreClientesDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBPreClientesDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBPreClientesDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBPreClientesDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBPreClientesDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBPreClientesDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBPreClientesDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBPreClientesDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBPreClientesDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FHomePage = dbRec[DBPreClientesDicInfo.HomePage]?.ToString() ?? string.Empty; m_FHomePage = dbRec[DBPreClientesDicInfo.HomePage]?.ToString() ?? string.Empty;  } catch {}  try { m_FHomePage = dbRec[DBPreClientesDicInfo.HomePage]?.ToString() ?? string.Empty; m_FHomePage = dbRec[DBPreClientesDicInfo.HomePage]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FHomePage = dbRec[DBPreClientesDicInfo.HomePage]?.ToString() ?? string.Empty; } catch { }

#else
        m_FHomePage = dbRec[DBPreClientesDicInfo.HomePage]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBPreClientesDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBPreClientesDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBPreClientesDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBPreClientesDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBPreClientesDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBPreClientesDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAssistido = dbRec[DBPreClientesDicInfo.Assistido]?.ToString() ?? string.Empty; m_FAssistido = dbRec[DBPreClientesDicInfo.Assistido]?.ToString() ?? string.Empty;  } catch {}  try { m_FAssistido = dbRec[DBPreClientesDicInfo.Assistido]?.ToString() ?? string.Empty; m_FAssistido = dbRec[DBPreClientesDicInfo.Assistido]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAssistido = dbRec[DBPreClientesDicInfo.Assistido]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAssistido = dbRec[DBPreClientesDicInfo.Assistido]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAssRG = dbRec[DBPreClientesDicInfo.AssRG]?.ToString() ?? string.Empty; m_FAssRG = dbRec[DBPreClientesDicInfo.AssRG]?.ToString() ?? string.Empty;  } catch {}  try { m_FAssRG = dbRec[DBPreClientesDicInfo.AssRG]?.ToString() ?? string.Empty; m_FAssRG = dbRec[DBPreClientesDicInfo.AssRG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAssRG = dbRec[DBPreClientesDicInfo.AssRG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAssRG = dbRec[DBPreClientesDicInfo.AssRG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAssCPF = dbRec[DBPreClientesDicInfo.AssCPF]?.ToString() ?? string.Empty; m_FAssCPF = dbRec[DBPreClientesDicInfo.AssCPF]?.ToString() ?? string.Empty;  } catch {}  try { m_FAssCPF = dbRec[DBPreClientesDicInfo.AssCPF]?.ToString() ?? string.Empty; m_FAssCPF = dbRec[DBPreClientesDicInfo.AssCPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAssCPF = dbRec[DBPreClientesDicInfo.AssCPF]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAssCPF = dbRec[DBPreClientesDicInfo.AssCPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAssEndereco = dbRec[DBPreClientesDicInfo.AssEndereco]?.ToString() ?? string.Empty; m_FAssEndereco = dbRec[DBPreClientesDicInfo.AssEndereco]?.ToString() ?? string.Empty;  } catch {}  try { m_FAssEndereco = dbRec[DBPreClientesDicInfo.AssEndereco]?.ToString() ?? string.Empty; m_FAssEndereco = dbRec[DBPreClientesDicInfo.AssEndereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAssEndereco = dbRec[DBPreClientesDicInfo.AssEndereco]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAssEndereco = dbRec[DBPreClientesDicInfo.AssEndereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCNH = dbRec[DBPreClientesDicInfo.CNH]?.ToString() ?? string.Empty; m_FCNH = dbRec[DBPreClientesDicInfo.CNH]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNH = dbRec[DBPreClientesDicInfo.CNH]?.ToString() ?? string.Empty; m_FCNH = dbRec[DBPreClientesDicInfo.CNH]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNH = dbRec[DBPreClientesDicInfo.CNH]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNH = dbRec[DBPreClientesDicInfo.CNH]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBPreClientesDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBPreClientesDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBPreClientesDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBPreClientesDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBPreClientesDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBPreClientesDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Ani])) m_FAni = (bool)dbRec[DBPreClientesDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Ani])) m_FAni = (bool)dbRec[DBPreClientesDicInfo.Ani];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Ani])) m_FAni = (bool)dbRec[DBPreClientesDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Ani])) m_FAni = (bool)dbRec[DBPreClientesDicInfo.Ani];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Ani])) m_FAni = (bool)dbRec[DBPreClientesDicInfo.Ani]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Ani]))
            m_FAni = (bool)dbRec[DBPreClientesDicInfo.Ani];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Bold])) m_FBold = (bool)dbRec[DBPreClientesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Bold])) m_FBold = (bool)dbRec[DBPreClientesDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Bold])) m_FBold = (bool)dbRec[DBPreClientesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Bold])) m_FBold = (bool)dbRec[DBPreClientesDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Bold])) m_FBold = (bool)dbRec[DBPreClientesDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBPreClientesDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPreClientesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPreClientesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPreClientesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPreClientesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPreClientesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBPreClientesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_PreClientes
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
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBPreClientesDicInfo.Inativo]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBPreClientesDicInfo.Inativo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBPreClientesDicInfo.Inativo]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBPreClientesDicInfo.Inativo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBPreClientesDicInfo.Inativo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Inativo]))
            m_FInativo = (bool)dbRec[DBPreClientesDicInfo.Inativo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FQuemIndicou = dbRec[DBPreClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty; m_FQuemIndicou = dbRec[DBPreClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty;  } catch {}  try { m_FQuemIndicou = dbRec[DBPreClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty; m_FQuemIndicou = dbRec[DBPreClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FQuemIndicou = dbRec[DBPreClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty; } catch { }

#else
        m_FQuemIndicou = dbRec[DBPreClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FNome = dbRec[DBPreClientesDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBPreClientesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBPreClientesDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBPreClientesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBPreClientesDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBPreClientesDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Adv]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Adv]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Adv]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Adv]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Adv]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Adv]))
            m_FAdv = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Adv]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBPreClientesDicInfo.IDRep]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBPreClientesDicInfo.IDRep]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBPreClientesDicInfo.IDRep]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBPreClientesDicInfo.IDRep]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBPreClientesDicInfo.IDRep]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.IDRep]))
            m_FIDRep = Convert.ToInt32(dbRec[DBPreClientesDicInfo.IDRep]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBPreClientesDicInfo.Juridica]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBPreClientesDicInfo.Juridica];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBPreClientesDicInfo.Juridica]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBPreClientesDicInfo.Juridica];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBPreClientesDicInfo.Juridica]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Juridica]))
            m_FJuridica = (bool)dbRec[DBPreClientesDicInfo.Juridica];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeFantasia = dbRec[DBPreClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty; m_FNomeFantasia = dbRec[DBPreClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeFantasia = dbRec[DBPreClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty; m_FNomeFantasia = dbRec[DBPreClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeFantasia = dbRec[DBPreClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeFantasia = dbRec[DBPreClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FClass = dbRec[DBPreClientesDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBPreClientesDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FClass = dbRec[DBPreClientesDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBPreClientesDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FClass = dbRec[DBPreClientesDicInfo.Class]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FClass = dbRec[DBPreClientesDicInfo.Class]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBPreClientesDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBPreClientesDicInfo.Tipo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBPreClientesDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBPreClientesDicInfo.Tipo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBPreClientesDicInfo.Tipo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Tipo]))
            m_FTipo = (bool)dbRec[DBPreClientesDicInfo.Tipo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtNasc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtNasc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtNasc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtNasc]))
            m_FDtNasc = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtNasc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FInscEst = dbRec[DBPreClientesDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBPreClientesDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { m_FInscEst = dbRec[DBPreClientesDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBPreClientesDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FInscEst = dbRec[DBPreClientesDicInfo.InscEst]?.ToString() ?? string.Empty; } catch { }

#else
        m_FInscEst = dbRec[DBPreClientesDicInfo.InscEst]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FQualificacao = dbRec[DBPreClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty; m_FQualificacao = dbRec[DBPreClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FQualificacao = dbRec[DBPreClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty; m_FQualificacao = dbRec[DBPreClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FQualificacao = dbRec[DBPreClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FQualificacao = dbRec[DBPreClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBPreClientesDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBPreClientesDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBPreClientesDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBPreClientesDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBPreClientesDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBPreClientesDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Idade]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Idade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Idade]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Idade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Idade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Idade]))
            m_FIdade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Idade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCNPJ = dbRec[DBPreClientesDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBPreClientesDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNPJ = dbRec[DBPreClientesDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBPreClientesDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNPJ = dbRec[DBPreClientesDicInfo.CNPJ]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNPJ = dbRec[DBPreClientesDicInfo.CNPJ]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBPreClientesDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBPreClientesDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBPreClientesDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBPreClientesDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBPreClientesDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBPreClientesDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBPreClientesDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBPreClientesDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBPreClientesDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBPreClientesDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBPreClientesDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBPreClientesDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.TipoCaptacao])) m_FTipoCaptacao = (bool)dbRec[DBPreClientesDicInfo.TipoCaptacao]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.TipoCaptacao])) m_FTipoCaptacao = (bool)dbRec[DBPreClientesDicInfo.TipoCaptacao];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.TipoCaptacao])) m_FTipoCaptacao = (bool)dbRec[DBPreClientesDicInfo.TipoCaptacao]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.TipoCaptacao])) m_FTipoCaptacao = (bool)dbRec[DBPreClientesDicInfo.TipoCaptacao];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.TipoCaptacao])) m_FTipoCaptacao = (bool)dbRec[DBPreClientesDicInfo.TipoCaptacao]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.TipoCaptacao]))
            m_FTipoCaptacao = (bool)dbRec[DBPreClientesDicInfo.TipoCaptacao];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBPreClientesDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBPreClientesDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBPreClientesDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBPreClientesDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBPreClientesDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBPreClientesDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBPreClientesDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBPreClientesDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBPreClientesDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBPreClientesDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBPreClientesDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBPreClientesDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBPreClientesDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBPreClientesDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBPreClientesDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBPreClientesDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBPreClientesDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBPreClientesDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBPreClientesDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBPreClientesDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBPreClientesDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBPreClientesDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBPreClientesDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBPreClientesDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBPreClientesDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBPreClientesDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBPreClientesDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBPreClientesDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBPreClientesDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBPreClientesDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBPreClientesDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBPreClientesDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBPreClientesDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBPreClientesDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBPreClientesDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBPreClientesDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBPreClientesDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FHomePage = dbRec[DBPreClientesDicInfo.HomePage]?.ToString() ?? string.Empty; m_FHomePage = dbRec[DBPreClientesDicInfo.HomePage]?.ToString() ?? string.Empty;  } catch {}  try { m_FHomePage = dbRec[DBPreClientesDicInfo.HomePage]?.ToString() ?? string.Empty; m_FHomePage = dbRec[DBPreClientesDicInfo.HomePage]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FHomePage = dbRec[DBPreClientesDicInfo.HomePage]?.ToString() ?? string.Empty; } catch { }

#else
        m_FHomePage = dbRec[DBPreClientesDicInfo.HomePage]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBPreClientesDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBPreClientesDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBPreClientesDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBPreClientesDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBPreClientesDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBPreClientesDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAssistido = dbRec[DBPreClientesDicInfo.Assistido]?.ToString() ?? string.Empty; m_FAssistido = dbRec[DBPreClientesDicInfo.Assistido]?.ToString() ?? string.Empty;  } catch {}  try { m_FAssistido = dbRec[DBPreClientesDicInfo.Assistido]?.ToString() ?? string.Empty; m_FAssistido = dbRec[DBPreClientesDicInfo.Assistido]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAssistido = dbRec[DBPreClientesDicInfo.Assistido]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAssistido = dbRec[DBPreClientesDicInfo.Assistido]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAssRG = dbRec[DBPreClientesDicInfo.AssRG]?.ToString() ?? string.Empty; m_FAssRG = dbRec[DBPreClientesDicInfo.AssRG]?.ToString() ?? string.Empty;  } catch {}  try { m_FAssRG = dbRec[DBPreClientesDicInfo.AssRG]?.ToString() ?? string.Empty; m_FAssRG = dbRec[DBPreClientesDicInfo.AssRG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAssRG = dbRec[DBPreClientesDicInfo.AssRG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAssRG = dbRec[DBPreClientesDicInfo.AssRG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAssCPF = dbRec[DBPreClientesDicInfo.AssCPF]?.ToString() ?? string.Empty; m_FAssCPF = dbRec[DBPreClientesDicInfo.AssCPF]?.ToString() ?? string.Empty;  } catch {}  try { m_FAssCPF = dbRec[DBPreClientesDicInfo.AssCPF]?.ToString() ?? string.Empty; m_FAssCPF = dbRec[DBPreClientesDicInfo.AssCPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAssCPF = dbRec[DBPreClientesDicInfo.AssCPF]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAssCPF = dbRec[DBPreClientesDicInfo.AssCPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAssEndereco = dbRec[DBPreClientesDicInfo.AssEndereco]?.ToString() ?? string.Empty; m_FAssEndereco = dbRec[DBPreClientesDicInfo.AssEndereco]?.ToString() ?? string.Empty;  } catch {}  try { m_FAssEndereco = dbRec[DBPreClientesDicInfo.AssEndereco]?.ToString() ?? string.Empty; m_FAssEndereco = dbRec[DBPreClientesDicInfo.AssEndereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAssEndereco = dbRec[DBPreClientesDicInfo.AssEndereco]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAssEndereco = dbRec[DBPreClientesDicInfo.AssEndereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCNH = dbRec[DBPreClientesDicInfo.CNH]?.ToString() ?? string.Empty; m_FCNH = dbRec[DBPreClientesDicInfo.CNH]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNH = dbRec[DBPreClientesDicInfo.CNH]?.ToString() ?? string.Empty; m_FCNH = dbRec[DBPreClientesDicInfo.CNH]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNH = dbRec[DBPreClientesDicInfo.CNH]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNH = dbRec[DBPreClientesDicInfo.CNH]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBPreClientesDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBPreClientesDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBPreClientesDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBPreClientesDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBPreClientesDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBPreClientesDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Ani])) m_FAni = (bool)dbRec[DBPreClientesDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Ani])) m_FAni = (bool)dbRec[DBPreClientesDicInfo.Ani];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Ani])) m_FAni = (bool)dbRec[DBPreClientesDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Ani])) m_FAni = (bool)dbRec[DBPreClientesDicInfo.Ani];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Ani])) m_FAni = (bool)dbRec[DBPreClientesDicInfo.Ani]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Ani]))
            m_FAni = (bool)dbRec[DBPreClientesDicInfo.Ani];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Bold])) m_FBold = (bool)dbRec[DBPreClientesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Bold])) m_FBold = (bool)dbRec[DBPreClientesDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Bold])) m_FBold = (bool)dbRec[DBPreClientesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Bold])) m_FBold = (bool)dbRec[DBPreClientesDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Bold])) m_FBold = (bool)dbRec[DBPreClientesDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBPreClientesDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBPreClientesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBPreClientesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPreClientesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPreClientesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPreClientesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPreClientesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPreClientesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPreClientesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBPreClientesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}