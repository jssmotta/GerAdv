namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBClientes
{
    public DBClientes(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Adv]))
                m_FAdv = Convert.ToInt32(dbRec[DBClientesDicInfo.Adv]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Ani]))
                m_FAni = (bool)dbRec[DBClientesDicInfo.Ani];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBClientesDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBClientesDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBClientesDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtNasc]))
                m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtNasc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Empresa]))
                m_FEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.Empresa]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.EnquadramentoEmpresa]))
                m_FEnquadramentoEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.EnquadramentoEmpresa]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBClientesDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Idade]))
                m_FIdade = Convert.ToInt32(dbRec[DBClientesDicInfo.Idade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.IDRep]))
                m_FIDRep = Convert.ToInt32(dbRec[DBClientesDicInfo.IDRep]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Inativo]))
                m_FInativo = (bool)dbRec[DBClientesDicInfo.Inativo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Juridica]))
                m_FJuridica = (bool)dbRec[DBClientesDicInfo.Juridica];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Obito]))
                m_FObito = (bool)dbRec[DBClientesDicInfo.Obito];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ProBono]))
                m_FProBono = (bool)dbRec[DBClientesDicInfo.ProBono];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RegimeTributacao]))
                m_FRegimeTributacao = Convert.ToInt32(dbRec[DBClientesDicInfo.RegimeTributacao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ReportECBOnly]))
                m_FReportECBOnly = (bool)dbRec[DBClientesDicInfo.ReportECBOnly];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RGDataExp]))
                m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesDicInfo.RGDataExp]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.SendEMail]))
                m_FSendEMail = (bool)dbRec[DBClientesDicInfo.SendEMail];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBClientesDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Tipo]))
                m_FTipo = (bool)dbRec[DBClientesDicInfo.Tipo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.TipoCaptacao]))
                m_FTipoCaptacao = (bool)dbRec[DBClientesDicInfo.TipoCaptacao];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBClientesDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FCNH = dbRec[DBClientesDicInfo.CNH]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCNPJ = dbRec[DBClientesDicInfo.CNPJ]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBClientesDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBClientesDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBClientesDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBClientesDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FHomePage = dbRec[DBClientesDicInfo.HomePage]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FIcone = dbRec[DBClientesDicInfo.Icone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FInscEst = dbRec[DBClientesDicInfo.InscEst]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeFantasia = dbRec[DBClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeMae = dbRec[DBClientesDicInfo.NomeMae]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomePai = dbRec[DBClientesDicInfo.NomePai]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBClientesDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPessoaContato = dbRec[DBClientesDicInfo.PessoaContato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FQualificacao = dbRec[DBClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FQuemIndicou = dbRec[DBClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBClientesDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRGOExpeditor = dbRec[DBClientesDicInfo.RGOExpeditor]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBClientesDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBClientesDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FClass = dbRec[DBClientesDicInfo.Class]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBClientesDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBClientesDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBClientesDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBClientes(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Adv]))
                m_FAdv = Convert.ToInt32(dbRec[DBClientesDicInfo.Adv]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Ani]))
                m_FAni = (bool)dbRec[DBClientesDicInfo.Ani];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBClientesDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBClientesDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBClientesDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtNasc]))
                m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtNasc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Empresa]))
                m_FEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.Empresa]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.EnquadramentoEmpresa]))
                m_FEnquadramentoEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.EnquadramentoEmpresa]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBClientesDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Idade]))
                m_FIdade = Convert.ToInt32(dbRec[DBClientesDicInfo.Idade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.IDRep]))
                m_FIDRep = Convert.ToInt32(dbRec[DBClientesDicInfo.IDRep]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Inativo]))
                m_FInativo = (bool)dbRec[DBClientesDicInfo.Inativo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Juridica]))
                m_FJuridica = (bool)dbRec[DBClientesDicInfo.Juridica];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Obito]))
                m_FObito = (bool)dbRec[DBClientesDicInfo.Obito];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ProBono]))
                m_FProBono = (bool)dbRec[DBClientesDicInfo.ProBono];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RegimeTributacao]))
                m_FRegimeTributacao = Convert.ToInt32(dbRec[DBClientesDicInfo.RegimeTributacao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ReportECBOnly]))
                m_FReportECBOnly = (bool)dbRec[DBClientesDicInfo.ReportECBOnly];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RGDataExp]))
                m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesDicInfo.RGDataExp]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.SendEMail]))
                m_FSendEMail = (bool)dbRec[DBClientesDicInfo.SendEMail];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBClientesDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Tipo]))
                m_FTipo = (bool)dbRec[DBClientesDicInfo.Tipo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.TipoCaptacao]))
                m_FTipoCaptacao = (bool)dbRec[DBClientesDicInfo.TipoCaptacao];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBClientesDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FCNH = dbRec[DBClientesDicInfo.CNH]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCNPJ = dbRec[DBClientesDicInfo.CNPJ]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBClientesDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBClientesDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBClientesDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBClientesDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FHomePage = dbRec[DBClientesDicInfo.HomePage]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FIcone = dbRec[DBClientesDicInfo.Icone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FInscEst = dbRec[DBClientesDicInfo.InscEst]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeFantasia = dbRec[DBClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeMae = dbRec[DBClientesDicInfo.NomeMae]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomePai = dbRec[DBClientesDicInfo.NomePai]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBClientesDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPessoaContato = dbRec[DBClientesDicInfo.PessoaContato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FQualificacao = dbRec[DBClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FQuemIndicou = dbRec[DBClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBClientesDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRGOExpeditor = dbRec[DBClientesDicInfo.RGOExpeditor]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBClientesDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBClientesDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FClass = dbRec[DBClientesDicInfo.Class]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBClientesDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBClientesDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBClientesDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Clientes
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [cliCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Empresa])) m_FEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.Empresa]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Empresa])) m_FEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.Empresa]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Empresa])) m_FEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.Empresa]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Empresa])) m_FEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.Empresa]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Empresa])) m_FEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.Empresa]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Empresa]))
            m_FEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.Empresa]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FIcone = dbRec[DBClientesDicInfo.Icone]?.ToString() ?? string.Empty; m_FIcone = dbRec[DBClientesDicInfo.Icone]?.ToString() ?? string.Empty;  } catch {}  try { m_FIcone = dbRec[DBClientesDicInfo.Icone]?.ToString() ?? string.Empty; m_FIcone = dbRec[DBClientesDicInfo.Icone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FIcone = dbRec[DBClientesDicInfo.Icone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FIcone = dbRec[DBClientesDicInfo.Icone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeMae = dbRec[DBClientesDicInfo.NomeMae]?.ToString() ?? string.Empty; m_FNomeMae = dbRec[DBClientesDicInfo.NomeMae]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeMae = dbRec[DBClientesDicInfo.NomeMae]?.ToString() ?? string.Empty; m_FNomeMae = dbRec[DBClientesDicInfo.NomeMae]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeMae = dbRec[DBClientesDicInfo.NomeMae]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeMae = dbRec[DBClientesDicInfo.NomeMae]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RGDataExp])) m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesDicInfo.RGDataExp]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RGDataExp])) m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesDicInfo.RGDataExp]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RGDataExp])) m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesDicInfo.RGDataExp]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RGDataExp])) m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesDicInfo.RGDataExp]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RGDataExp])) m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesDicInfo.RGDataExp]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RGDataExp]))
            m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesDicInfo.RGDataExp]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBClientesDicInfo.Inativo]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBClientesDicInfo.Inativo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBClientesDicInfo.Inativo]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBClientesDicInfo.Inativo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBClientesDicInfo.Inativo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Inativo]))
            m_FInativo = (bool)dbRec[DBClientesDicInfo.Inativo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FQuemIndicou = dbRec[DBClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty; m_FQuemIndicou = dbRec[DBClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty;  } catch {}  try { m_FQuemIndicou = dbRec[DBClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty; m_FQuemIndicou = dbRec[DBClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FQuemIndicou = dbRec[DBClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty; } catch { }

#else
        m_FQuemIndicou = dbRec[DBClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.SendEMail])) m_FSendEMail = (bool)dbRec[DBClientesDicInfo.SendEMail]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.SendEMail])) m_FSendEMail = (bool)dbRec[DBClientesDicInfo.SendEMail];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.SendEMail])) m_FSendEMail = (bool)dbRec[DBClientesDicInfo.SendEMail]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.SendEMail])) m_FSendEMail = (bool)dbRec[DBClientesDicInfo.SendEMail];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.SendEMail])) m_FSendEMail = (bool)dbRec[DBClientesDicInfo.SendEMail]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.SendEMail]))
            m_FSendEMail = (bool)dbRec[DBClientesDicInfo.SendEMail];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FNome = dbRec[DBClientesDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBClientesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBClientesDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBClientesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBClientesDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBClientesDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBClientesDicInfo.Adv]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBClientesDicInfo.Adv]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBClientesDicInfo.Adv]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBClientesDicInfo.Adv]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBClientesDicInfo.Adv]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Adv]))
            m_FAdv = Convert.ToInt32(dbRec[DBClientesDicInfo.Adv]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBClientesDicInfo.IDRep]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBClientesDicInfo.IDRep]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBClientesDicInfo.IDRep]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBClientesDicInfo.IDRep]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBClientesDicInfo.IDRep]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.IDRep]))
            m_FIDRep = Convert.ToInt32(dbRec[DBClientesDicInfo.IDRep]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBClientesDicInfo.Juridica]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBClientesDicInfo.Juridica];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBClientesDicInfo.Juridica]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBClientesDicInfo.Juridica];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBClientesDicInfo.Juridica]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Juridica]))
            m_FJuridica = (bool)dbRec[DBClientesDicInfo.Juridica];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeFantasia = dbRec[DBClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty; m_FNomeFantasia = dbRec[DBClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeFantasia = dbRec[DBClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty; m_FNomeFantasia = dbRec[DBClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeFantasia = dbRec[DBClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeFantasia = dbRec[DBClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FClass = dbRec[DBClientesDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBClientesDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FClass = dbRec[DBClientesDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBClientesDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FClass = dbRec[DBClientesDicInfo.Class]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FClass = dbRec[DBClientesDicInfo.Class]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBClientesDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBClientesDicInfo.Tipo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBClientesDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBClientesDicInfo.Tipo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBClientesDicInfo.Tipo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Tipo]))
            m_FTipo = (bool)dbRec[DBClientesDicInfo.Tipo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtNasc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtNasc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtNasc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtNasc]))
            m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtNasc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FInscEst = dbRec[DBClientesDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBClientesDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { m_FInscEst = dbRec[DBClientesDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBClientesDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FInscEst = dbRec[DBClientesDicInfo.InscEst]?.ToString() ?? string.Empty; } catch { }

#else
        m_FInscEst = dbRec[DBClientesDicInfo.InscEst]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FQualificacao = dbRec[DBClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty; m_FQualificacao = dbRec[DBClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FQualificacao = dbRec[DBClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty; m_FQualificacao = dbRec[DBClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FQualificacao = dbRec[DBClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FQualificacao = dbRec[DBClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBClientesDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBClientesDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBClientesDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBClientesDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBClientesDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBClientesDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBClientesDicInfo.Idade]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBClientesDicInfo.Idade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBClientesDicInfo.Idade]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBClientesDicInfo.Idade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBClientesDicInfo.Idade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Idade]))
            m_FIdade = Convert.ToInt32(dbRec[DBClientesDicInfo.Idade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCNPJ = dbRec[DBClientesDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBClientesDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNPJ = dbRec[DBClientesDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBClientesDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNPJ = dbRec[DBClientesDicInfo.CNPJ]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNPJ = dbRec[DBClientesDicInfo.CNPJ]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBClientesDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBClientesDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBClientesDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBClientesDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBClientesDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBClientesDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBClientesDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBClientesDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBClientesDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBClientesDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBClientesDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBClientesDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.TipoCaptacao])) m_FTipoCaptacao = (bool)dbRec[DBClientesDicInfo.TipoCaptacao]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.TipoCaptacao])) m_FTipoCaptacao = (bool)dbRec[DBClientesDicInfo.TipoCaptacao];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.TipoCaptacao])) m_FTipoCaptacao = (bool)dbRec[DBClientesDicInfo.TipoCaptacao]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.TipoCaptacao])) m_FTipoCaptacao = (bool)dbRec[DBClientesDicInfo.TipoCaptacao];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.TipoCaptacao])) m_FTipoCaptacao = (bool)dbRec[DBClientesDicInfo.TipoCaptacao]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.TipoCaptacao]))
            m_FTipoCaptacao = (bool)dbRec[DBClientesDicInfo.TipoCaptacao];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBClientesDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBClientesDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBClientesDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBClientesDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBClientesDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBClientesDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBClientesDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBClientesDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBClientesDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBClientesDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBClientesDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBClientesDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBClientesDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBClientesDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBClientesDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBClientesDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBClientesDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBClientesDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBClientesDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBClientesDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBClientesDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBClientesDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBClientesDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBClientesDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBClientesDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBClientesDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBClientesDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBClientesDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBClientesDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBClientesDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBClientesDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBClientesDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBClientesDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBClientesDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBClientesDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBClientesDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBClientesDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBClientesDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBClientesDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBClientesDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBClientesDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBClientesDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBClientesDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBClientesDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBClientesDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBClientesDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBClientesDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBClientesDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FHomePage = dbRec[DBClientesDicInfo.HomePage]?.ToString() ?? string.Empty; m_FHomePage = dbRec[DBClientesDicInfo.HomePage]?.ToString() ?? string.Empty;  } catch {}  try { m_FHomePage = dbRec[DBClientesDicInfo.HomePage]?.ToString() ?? string.Empty; m_FHomePage = dbRec[DBClientesDicInfo.HomePage]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FHomePage = dbRec[DBClientesDicInfo.HomePage]?.ToString() ?? string.Empty; } catch { }

#else
        m_FHomePage = dbRec[DBClientesDicInfo.HomePage]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBClientesDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBClientesDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBClientesDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBClientesDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBClientesDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBClientesDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Obito])) m_FObito = (bool)dbRec[DBClientesDicInfo.Obito]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Obito])) m_FObito = (bool)dbRec[DBClientesDicInfo.Obito];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Obito])) m_FObito = (bool)dbRec[DBClientesDicInfo.Obito]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Obito])) m_FObito = (bool)dbRec[DBClientesDicInfo.Obito];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Obito])) m_FObito = (bool)dbRec[DBClientesDicInfo.Obito]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Obito]))
            m_FObito = (bool)dbRec[DBClientesDicInfo.Obito];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomePai = dbRec[DBClientesDicInfo.NomePai]?.ToString() ?? string.Empty; m_FNomePai = dbRec[DBClientesDicInfo.NomePai]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomePai = dbRec[DBClientesDicInfo.NomePai]?.ToString() ?? string.Empty; m_FNomePai = dbRec[DBClientesDicInfo.NomePai]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomePai = dbRec[DBClientesDicInfo.NomePai]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomePai = dbRec[DBClientesDicInfo.NomePai]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRGOExpeditor = dbRec[DBClientesDicInfo.RGOExpeditor]?.ToString() ?? string.Empty; m_FRGOExpeditor = dbRec[DBClientesDicInfo.RGOExpeditor]?.ToString() ?? string.Empty;  } catch {}  try { m_FRGOExpeditor = dbRec[DBClientesDicInfo.RGOExpeditor]?.ToString() ?? string.Empty; m_FRGOExpeditor = dbRec[DBClientesDicInfo.RGOExpeditor]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRGOExpeditor = dbRec[DBClientesDicInfo.RGOExpeditor]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRGOExpeditor = dbRec[DBClientesDicInfo.RGOExpeditor]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RegimeTributacao])) m_FRegimeTributacao = Convert.ToInt32(dbRec[DBClientesDicInfo.RegimeTributacao]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RegimeTributacao])) m_FRegimeTributacao = Convert.ToInt32(dbRec[DBClientesDicInfo.RegimeTributacao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RegimeTributacao])) m_FRegimeTributacao = Convert.ToInt32(dbRec[DBClientesDicInfo.RegimeTributacao]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RegimeTributacao])) m_FRegimeTributacao = Convert.ToInt32(dbRec[DBClientesDicInfo.RegimeTributacao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RegimeTributacao])) m_FRegimeTributacao = Convert.ToInt32(dbRec[DBClientesDicInfo.RegimeTributacao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RegimeTributacao]))
            m_FRegimeTributacao = Convert.ToInt32(dbRec[DBClientesDicInfo.RegimeTributacao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.EnquadramentoEmpresa])) m_FEnquadramentoEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.EnquadramentoEmpresa]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.EnquadramentoEmpresa])) m_FEnquadramentoEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.EnquadramentoEmpresa]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.EnquadramentoEmpresa])) m_FEnquadramentoEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.EnquadramentoEmpresa]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.EnquadramentoEmpresa])) m_FEnquadramentoEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.EnquadramentoEmpresa]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.EnquadramentoEmpresa])) m_FEnquadramentoEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.EnquadramentoEmpresa]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.EnquadramentoEmpresa]))
            m_FEnquadramentoEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.EnquadramentoEmpresa]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ReportECBOnly])) m_FReportECBOnly = (bool)dbRec[DBClientesDicInfo.ReportECBOnly]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ReportECBOnly])) m_FReportECBOnly = (bool)dbRec[DBClientesDicInfo.ReportECBOnly];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ReportECBOnly])) m_FReportECBOnly = (bool)dbRec[DBClientesDicInfo.ReportECBOnly]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ReportECBOnly])) m_FReportECBOnly = (bool)dbRec[DBClientesDicInfo.ReportECBOnly];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ReportECBOnly])) m_FReportECBOnly = (bool)dbRec[DBClientesDicInfo.ReportECBOnly]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ReportECBOnly]))
            m_FReportECBOnly = (bool)dbRec[DBClientesDicInfo.ReportECBOnly];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ProBono])) m_FProBono = (bool)dbRec[DBClientesDicInfo.ProBono]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ProBono])) m_FProBono = (bool)dbRec[DBClientesDicInfo.ProBono];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ProBono])) m_FProBono = (bool)dbRec[DBClientesDicInfo.ProBono]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ProBono])) m_FProBono = (bool)dbRec[DBClientesDicInfo.ProBono];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ProBono])) m_FProBono = (bool)dbRec[DBClientesDicInfo.ProBono]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ProBono]))
            m_FProBono = (bool)dbRec[DBClientesDicInfo.ProBono];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCNH = dbRec[DBClientesDicInfo.CNH]?.ToString() ?? string.Empty; m_FCNH = dbRec[DBClientesDicInfo.CNH]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNH = dbRec[DBClientesDicInfo.CNH]?.ToString() ?? string.Empty; m_FCNH = dbRec[DBClientesDicInfo.CNH]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNH = dbRec[DBClientesDicInfo.CNH]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNH = dbRec[DBClientesDicInfo.CNH]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPessoaContato = dbRec[DBClientesDicInfo.PessoaContato]?.ToString() ?? string.Empty; m_FPessoaContato = dbRec[DBClientesDicInfo.PessoaContato]?.ToString() ?? string.Empty;  } catch {}  try { m_FPessoaContato = dbRec[DBClientesDicInfo.PessoaContato]?.ToString() ?? string.Empty; m_FPessoaContato = dbRec[DBClientesDicInfo.PessoaContato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPessoaContato = dbRec[DBClientesDicInfo.PessoaContato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPessoaContato = dbRec[DBClientesDicInfo.PessoaContato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBClientesDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBClientesDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBClientesDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBClientesDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBClientesDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBClientesDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Ani])) m_FAni = (bool)dbRec[DBClientesDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Ani])) m_FAni = (bool)dbRec[DBClientesDicInfo.Ani];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Ani])) m_FAni = (bool)dbRec[DBClientesDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Ani])) m_FAni = (bool)dbRec[DBClientesDicInfo.Ani];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Ani])) m_FAni = (bool)dbRec[DBClientesDicInfo.Ani]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Ani]))
            m_FAni = (bool)dbRec[DBClientesDicInfo.Ani];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Bold])) m_FBold = (bool)dbRec[DBClientesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Bold])) m_FBold = (bool)dbRec[DBClientesDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Bold])) m_FBold = (bool)dbRec[DBClientesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Bold])) m_FBold = (bool)dbRec[DBClientesDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Bold])) m_FBold = (bool)dbRec[DBClientesDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBClientesDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBClientesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBClientesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBClientesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBClientesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBClientesDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBClientesDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBClientesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBClientesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBClientesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBClientesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBClientesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBClientesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Clientes
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
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Empresa])) m_FEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.Empresa]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Empresa])) m_FEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.Empresa]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Empresa])) m_FEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.Empresa]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Empresa])) m_FEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.Empresa]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Empresa])) m_FEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.Empresa]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Empresa]))
            m_FEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.Empresa]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FIcone = dbRec[DBClientesDicInfo.Icone]?.ToString() ?? string.Empty; m_FIcone = dbRec[DBClientesDicInfo.Icone]?.ToString() ?? string.Empty;  } catch {}  try { m_FIcone = dbRec[DBClientesDicInfo.Icone]?.ToString() ?? string.Empty; m_FIcone = dbRec[DBClientesDicInfo.Icone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FIcone = dbRec[DBClientesDicInfo.Icone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FIcone = dbRec[DBClientesDicInfo.Icone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeMae = dbRec[DBClientesDicInfo.NomeMae]?.ToString() ?? string.Empty; m_FNomeMae = dbRec[DBClientesDicInfo.NomeMae]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeMae = dbRec[DBClientesDicInfo.NomeMae]?.ToString() ?? string.Empty; m_FNomeMae = dbRec[DBClientesDicInfo.NomeMae]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeMae = dbRec[DBClientesDicInfo.NomeMae]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeMae = dbRec[DBClientesDicInfo.NomeMae]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RGDataExp])) m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesDicInfo.RGDataExp]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RGDataExp])) m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesDicInfo.RGDataExp]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RGDataExp])) m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesDicInfo.RGDataExp]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RGDataExp])) m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesDicInfo.RGDataExp]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RGDataExp])) m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesDicInfo.RGDataExp]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RGDataExp]))
            m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesDicInfo.RGDataExp]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBClientesDicInfo.Inativo]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBClientesDicInfo.Inativo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBClientesDicInfo.Inativo]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBClientesDicInfo.Inativo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Inativo])) m_FInativo = (bool)dbRec[DBClientesDicInfo.Inativo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Inativo]))
            m_FInativo = (bool)dbRec[DBClientesDicInfo.Inativo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FQuemIndicou = dbRec[DBClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty; m_FQuemIndicou = dbRec[DBClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty;  } catch {}  try { m_FQuemIndicou = dbRec[DBClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty; m_FQuemIndicou = dbRec[DBClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FQuemIndicou = dbRec[DBClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty; } catch { }

#else
        m_FQuemIndicou = dbRec[DBClientesDicInfo.QuemIndicou]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.SendEMail])) m_FSendEMail = (bool)dbRec[DBClientesDicInfo.SendEMail]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.SendEMail])) m_FSendEMail = (bool)dbRec[DBClientesDicInfo.SendEMail];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.SendEMail])) m_FSendEMail = (bool)dbRec[DBClientesDicInfo.SendEMail]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.SendEMail])) m_FSendEMail = (bool)dbRec[DBClientesDicInfo.SendEMail];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.SendEMail])) m_FSendEMail = (bool)dbRec[DBClientesDicInfo.SendEMail]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.SendEMail]))
            m_FSendEMail = (bool)dbRec[DBClientesDicInfo.SendEMail];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FNome = dbRec[DBClientesDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBClientesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBClientesDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBClientesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBClientesDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBClientesDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBClientesDicInfo.Adv]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBClientesDicInfo.Adv]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBClientesDicInfo.Adv]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBClientesDicInfo.Adv]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBClientesDicInfo.Adv]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Adv]))
            m_FAdv = Convert.ToInt32(dbRec[DBClientesDicInfo.Adv]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBClientesDicInfo.IDRep]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBClientesDicInfo.IDRep]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBClientesDicInfo.IDRep]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBClientesDicInfo.IDRep]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBClientesDicInfo.IDRep]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.IDRep]))
            m_FIDRep = Convert.ToInt32(dbRec[DBClientesDicInfo.IDRep]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBClientesDicInfo.Juridica]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBClientesDicInfo.Juridica];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBClientesDicInfo.Juridica]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBClientesDicInfo.Juridica];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBClientesDicInfo.Juridica]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Juridica]))
            m_FJuridica = (bool)dbRec[DBClientesDicInfo.Juridica];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeFantasia = dbRec[DBClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty; m_FNomeFantasia = dbRec[DBClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeFantasia = dbRec[DBClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty; m_FNomeFantasia = dbRec[DBClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeFantasia = dbRec[DBClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeFantasia = dbRec[DBClientesDicInfo.NomeFantasia]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FClass = dbRec[DBClientesDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBClientesDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FClass = dbRec[DBClientesDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBClientesDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FClass = dbRec[DBClientesDicInfo.Class]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FClass = dbRec[DBClientesDicInfo.Class]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBClientesDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBClientesDicInfo.Tipo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBClientesDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBClientesDicInfo.Tipo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBClientesDicInfo.Tipo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Tipo]))
            m_FTipo = (bool)dbRec[DBClientesDicInfo.Tipo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtNasc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtNasc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtNasc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtNasc]))
            m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtNasc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FInscEst = dbRec[DBClientesDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBClientesDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { m_FInscEst = dbRec[DBClientesDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBClientesDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FInscEst = dbRec[DBClientesDicInfo.InscEst]?.ToString() ?? string.Empty; } catch { }

#else
        m_FInscEst = dbRec[DBClientesDicInfo.InscEst]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FQualificacao = dbRec[DBClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty; m_FQualificacao = dbRec[DBClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FQualificacao = dbRec[DBClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty; m_FQualificacao = dbRec[DBClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FQualificacao = dbRec[DBClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FQualificacao = dbRec[DBClientesDicInfo.Qualificacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBClientesDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBClientesDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBClientesDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBClientesDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBClientesDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBClientesDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBClientesDicInfo.Idade]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBClientesDicInfo.Idade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBClientesDicInfo.Idade]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBClientesDicInfo.Idade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBClientesDicInfo.Idade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Idade]))
            m_FIdade = Convert.ToInt32(dbRec[DBClientesDicInfo.Idade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCNPJ = dbRec[DBClientesDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBClientesDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNPJ = dbRec[DBClientesDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBClientesDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNPJ = dbRec[DBClientesDicInfo.CNPJ]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNPJ = dbRec[DBClientesDicInfo.CNPJ]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBClientesDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBClientesDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBClientesDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBClientesDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBClientesDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBClientesDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBClientesDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBClientesDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBClientesDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBClientesDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBClientesDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBClientesDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.TipoCaptacao])) m_FTipoCaptacao = (bool)dbRec[DBClientesDicInfo.TipoCaptacao]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.TipoCaptacao])) m_FTipoCaptacao = (bool)dbRec[DBClientesDicInfo.TipoCaptacao];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.TipoCaptacao])) m_FTipoCaptacao = (bool)dbRec[DBClientesDicInfo.TipoCaptacao]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.TipoCaptacao])) m_FTipoCaptacao = (bool)dbRec[DBClientesDicInfo.TipoCaptacao];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.TipoCaptacao])) m_FTipoCaptacao = (bool)dbRec[DBClientesDicInfo.TipoCaptacao]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.TipoCaptacao]))
            m_FTipoCaptacao = (bool)dbRec[DBClientesDicInfo.TipoCaptacao];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBClientesDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBClientesDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBClientesDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBClientesDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBClientesDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBClientesDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBClientesDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBClientesDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBClientesDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBClientesDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBClientesDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBClientesDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBClientesDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBClientesDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBClientesDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBClientesDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBClientesDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBClientesDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBClientesDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBClientesDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBClientesDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBClientesDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBClientesDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBClientesDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBClientesDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBClientesDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBClientesDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBClientesDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBClientesDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBClientesDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBClientesDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBClientesDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBClientesDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBClientesDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBClientesDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBClientesDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBClientesDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBClientesDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBClientesDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBClientesDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBClientesDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBClientesDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBClientesDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBClientesDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBClientesDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBClientesDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBClientesDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBClientesDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FHomePage = dbRec[DBClientesDicInfo.HomePage]?.ToString() ?? string.Empty; m_FHomePage = dbRec[DBClientesDicInfo.HomePage]?.ToString() ?? string.Empty;  } catch {}  try { m_FHomePage = dbRec[DBClientesDicInfo.HomePage]?.ToString() ?? string.Empty; m_FHomePage = dbRec[DBClientesDicInfo.HomePage]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FHomePage = dbRec[DBClientesDicInfo.HomePage]?.ToString() ?? string.Empty; } catch { }

#else
        m_FHomePage = dbRec[DBClientesDicInfo.HomePage]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBClientesDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBClientesDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBClientesDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBClientesDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBClientesDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBClientesDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Obito])) m_FObito = (bool)dbRec[DBClientesDicInfo.Obito]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Obito])) m_FObito = (bool)dbRec[DBClientesDicInfo.Obito];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Obito])) m_FObito = (bool)dbRec[DBClientesDicInfo.Obito]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Obito])) m_FObito = (bool)dbRec[DBClientesDicInfo.Obito];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Obito])) m_FObito = (bool)dbRec[DBClientesDicInfo.Obito]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Obito]))
            m_FObito = (bool)dbRec[DBClientesDicInfo.Obito];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomePai = dbRec[DBClientesDicInfo.NomePai]?.ToString() ?? string.Empty; m_FNomePai = dbRec[DBClientesDicInfo.NomePai]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomePai = dbRec[DBClientesDicInfo.NomePai]?.ToString() ?? string.Empty; m_FNomePai = dbRec[DBClientesDicInfo.NomePai]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomePai = dbRec[DBClientesDicInfo.NomePai]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomePai = dbRec[DBClientesDicInfo.NomePai]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRGOExpeditor = dbRec[DBClientesDicInfo.RGOExpeditor]?.ToString() ?? string.Empty; m_FRGOExpeditor = dbRec[DBClientesDicInfo.RGOExpeditor]?.ToString() ?? string.Empty;  } catch {}  try { m_FRGOExpeditor = dbRec[DBClientesDicInfo.RGOExpeditor]?.ToString() ?? string.Empty; m_FRGOExpeditor = dbRec[DBClientesDicInfo.RGOExpeditor]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRGOExpeditor = dbRec[DBClientesDicInfo.RGOExpeditor]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRGOExpeditor = dbRec[DBClientesDicInfo.RGOExpeditor]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RegimeTributacao])) m_FRegimeTributacao = Convert.ToInt32(dbRec[DBClientesDicInfo.RegimeTributacao]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RegimeTributacao])) m_FRegimeTributacao = Convert.ToInt32(dbRec[DBClientesDicInfo.RegimeTributacao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RegimeTributacao])) m_FRegimeTributacao = Convert.ToInt32(dbRec[DBClientesDicInfo.RegimeTributacao]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RegimeTributacao])) m_FRegimeTributacao = Convert.ToInt32(dbRec[DBClientesDicInfo.RegimeTributacao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RegimeTributacao])) m_FRegimeTributacao = Convert.ToInt32(dbRec[DBClientesDicInfo.RegimeTributacao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.RegimeTributacao]))
            m_FRegimeTributacao = Convert.ToInt32(dbRec[DBClientesDicInfo.RegimeTributacao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.EnquadramentoEmpresa])) m_FEnquadramentoEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.EnquadramentoEmpresa]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.EnquadramentoEmpresa])) m_FEnquadramentoEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.EnquadramentoEmpresa]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.EnquadramentoEmpresa])) m_FEnquadramentoEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.EnquadramentoEmpresa]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.EnquadramentoEmpresa])) m_FEnquadramentoEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.EnquadramentoEmpresa]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.EnquadramentoEmpresa])) m_FEnquadramentoEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.EnquadramentoEmpresa]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.EnquadramentoEmpresa]))
            m_FEnquadramentoEmpresa = Convert.ToInt32(dbRec[DBClientesDicInfo.EnquadramentoEmpresa]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ReportECBOnly])) m_FReportECBOnly = (bool)dbRec[DBClientesDicInfo.ReportECBOnly]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ReportECBOnly])) m_FReportECBOnly = (bool)dbRec[DBClientesDicInfo.ReportECBOnly];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ReportECBOnly])) m_FReportECBOnly = (bool)dbRec[DBClientesDicInfo.ReportECBOnly]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ReportECBOnly])) m_FReportECBOnly = (bool)dbRec[DBClientesDicInfo.ReportECBOnly];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ReportECBOnly])) m_FReportECBOnly = (bool)dbRec[DBClientesDicInfo.ReportECBOnly]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ReportECBOnly]))
            m_FReportECBOnly = (bool)dbRec[DBClientesDicInfo.ReportECBOnly];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ProBono])) m_FProBono = (bool)dbRec[DBClientesDicInfo.ProBono]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ProBono])) m_FProBono = (bool)dbRec[DBClientesDicInfo.ProBono];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ProBono])) m_FProBono = (bool)dbRec[DBClientesDicInfo.ProBono]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ProBono])) m_FProBono = (bool)dbRec[DBClientesDicInfo.ProBono];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ProBono])) m_FProBono = (bool)dbRec[DBClientesDicInfo.ProBono]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.ProBono]))
            m_FProBono = (bool)dbRec[DBClientesDicInfo.ProBono];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCNH = dbRec[DBClientesDicInfo.CNH]?.ToString() ?? string.Empty; m_FCNH = dbRec[DBClientesDicInfo.CNH]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNH = dbRec[DBClientesDicInfo.CNH]?.ToString() ?? string.Empty; m_FCNH = dbRec[DBClientesDicInfo.CNH]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNH = dbRec[DBClientesDicInfo.CNH]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNH = dbRec[DBClientesDicInfo.CNH]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPessoaContato = dbRec[DBClientesDicInfo.PessoaContato]?.ToString() ?? string.Empty; m_FPessoaContato = dbRec[DBClientesDicInfo.PessoaContato]?.ToString() ?? string.Empty;  } catch {}  try { m_FPessoaContato = dbRec[DBClientesDicInfo.PessoaContato]?.ToString() ?? string.Empty; m_FPessoaContato = dbRec[DBClientesDicInfo.PessoaContato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPessoaContato = dbRec[DBClientesDicInfo.PessoaContato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPessoaContato = dbRec[DBClientesDicInfo.PessoaContato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBClientesDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBClientesDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBClientesDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBClientesDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBClientesDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBClientesDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Ani])) m_FAni = (bool)dbRec[DBClientesDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Ani])) m_FAni = (bool)dbRec[DBClientesDicInfo.Ani];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Ani])) m_FAni = (bool)dbRec[DBClientesDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Ani])) m_FAni = (bool)dbRec[DBClientesDicInfo.Ani];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Ani])) m_FAni = (bool)dbRec[DBClientesDicInfo.Ani]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Ani]))
            m_FAni = (bool)dbRec[DBClientesDicInfo.Ani];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Bold])) m_FBold = (bool)dbRec[DBClientesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Bold])) m_FBold = (bool)dbRec[DBClientesDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Bold])) m_FBold = (bool)dbRec[DBClientesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Bold])) m_FBold = (bool)dbRec[DBClientesDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Bold])) m_FBold = (bool)dbRec[DBClientesDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBClientesDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBClientesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBClientesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBClientesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBClientesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBClientesDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBClientesDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBClientesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBClientesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBClientesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBClientesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBClientesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBClientesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}