namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAdvogados
{
    public DBAdvogados(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Ani]))
                m_FAni = (bool)dbRec[DBAdvogadosDicInfo.Ani];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBAdvogadosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cargo]))
                m_FCargo = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cargo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Casa]))
                m_FCasa = (bool)dbRec[DBAdvogadosDicInfo.Casa];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Comissao]))
                m_FComissao = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Comissao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtFim]))
                m_FDtFim = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtFim]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtInicio]))
                m_FDtInicio = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtInicio]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtNasc]))
                m_FDtNasc = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtNasc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Escritorio]))
                m_FEscritorio = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Escritorio]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Estagiario]))
                m_FEstagiario = (bool)dbRec[DBAdvogadosDicInfo.Estagiario];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBAdvogadosDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.ParcTop]))
                m_FParcTop = (bool)dbRec[DBAdvogadosDicInfo.ParcTop];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Salario]))
                m_FSalario = Convert.ToDecimal(dbRec[DBAdvogadosDicInfo.Salario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBAdvogadosDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Top]))
                m_FTop = (bool)dbRec[DBAdvogadosDicInfo.Top];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAdvogadosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FContaBancaria = dbRec[DBAdvogadosDicInfo.ContaBancaria]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCTPS = dbRec[DBAdvogadosDicInfo.CTPS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCTPSSerie = dbRec[DBAdvogadosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBAdvogadosDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMailPro = dbRec[DBAdvogadosDicInfo.EMailPro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEspecializacao = dbRec[DBAdvogadosDicInfo.Especializacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBAdvogadosDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBAdvogadosDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBAdvogadosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeCompleto = dbRec[DBAdvogadosDicInfo.NomeCompleto]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeMae = dbRec[DBAdvogadosDicInfo.NomeMae]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOAB = dbRec[DBAdvogadosDicInfo.OAB]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBAdvogadosDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPasta = dbRec[DBAdvogadosDicInfo.Pasta]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBAdvogadosDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSecretaria = dbRec[DBAdvogadosDicInfo.Secretaria]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FTextoProcuracao = dbRec[DBAdvogadosDicInfo.TextoProcuracao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBAdvogadosDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBAdvogadosDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FClass = dbRec[DBAdvogadosDicInfo.Class]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBAdvogadosDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBAdvogadosDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBAdvogadosDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBAdvogados(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Ani]))
                m_FAni = (bool)dbRec[DBAdvogadosDicInfo.Ani];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBAdvogadosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cargo]))
                m_FCargo = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cargo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Casa]))
                m_FCasa = (bool)dbRec[DBAdvogadosDicInfo.Casa];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Comissao]))
                m_FComissao = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Comissao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtFim]))
                m_FDtFim = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtFim]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtInicio]))
                m_FDtInicio = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtInicio]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtNasc]))
                m_FDtNasc = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtNasc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Escritorio]))
                m_FEscritorio = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Escritorio]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Estagiario]))
                m_FEstagiario = (bool)dbRec[DBAdvogadosDicInfo.Estagiario];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBAdvogadosDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.ParcTop]))
                m_FParcTop = (bool)dbRec[DBAdvogadosDicInfo.ParcTop];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Salario]))
                m_FSalario = Convert.ToDecimal(dbRec[DBAdvogadosDicInfo.Salario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBAdvogadosDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Top]))
                m_FTop = (bool)dbRec[DBAdvogadosDicInfo.Top];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAdvogadosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FContaBancaria = dbRec[DBAdvogadosDicInfo.ContaBancaria]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCTPS = dbRec[DBAdvogadosDicInfo.CTPS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCTPSSerie = dbRec[DBAdvogadosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBAdvogadosDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMailPro = dbRec[DBAdvogadosDicInfo.EMailPro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEspecializacao = dbRec[DBAdvogadosDicInfo.Especializacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBAdvogadosDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBAdvogadosDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBAdvogadosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeCompleto = dbRec[DBAdvogadosDicInfo.NomeCompleto]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeMae = dbRec[DBAdvogadosDicInfo.NomeMae]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOAB = dbRec[DBAdvogadosDicInfo.OAB]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBAdvogadosDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPasta = dbRec[DBAdvogadosDicInfo.Pasta]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBAdvogadosDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSecretaria = dbRec[DBAdvogadosDicInfo.Secretaria]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FTextoProcuracao = dbRec[DBAdvogadosDicInfo.TextoProcuracao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBAdvogadosDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBAdvogadosDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FClass = dbRec[DBAdvogadosDicInfo.Class]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBAdvogadosDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBAdvogadosDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBAdvogadosDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Advogados
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[Advogados] (NOLOCK) WHERE [advCodigo] = @ThisIDToLoad", oCnn);
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
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cargo]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cargo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cargo]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cargo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cargo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cargo]))
            m_FCargo = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cargo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMailPro = dbRec[DBAdvogadosDicInfo.EMailPro]?.ToString() ?? string.Empty; m_FEMailPro = dbRec[DBAdvogadosDicInfo.EMailPro]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMailPro = dbRec[DBAdvogadosDicInfo.EMailPro]?.ToString() ?? string.Empty; m_FEMailPro = dbRec[DBAdvogadosDicInfo.EMailPro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMailPro = dbRec[DBAdvogadosDicInfo.EMailPro]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMailPro = dbRec[DBAdvogadosDicInfo.EMailPro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBAdvogadosDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBAdvogadosDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBAdvogadosDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBAdvogadosDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBAdvogadosDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBAdvogadosDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FNome = dbRec[DBAdvogadosDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBAdvogadosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBAdvogadosDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBAdvogadosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBAdvogadosDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBAdvogadosDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBAdvogadosDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBAdvogadosDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBAdvogadosDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBAdvogadosDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBAdvogadosDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBAdvogadosDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Casa])) m_FCasa = (bool)dbRec[DBAdvogadosDicInfo.Casa]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Casa])) m_FCasa = (bool)dbRec[DBAdvogadosDicInfo.Casa];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Casa])) m_FCasa = (bool)dbRec[DBAdvogadosDicInfo.Casa]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Casa])) m_FCasa = (bool)dbRec[DBAdvogadosDicInfo.Casa];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Casa])) m_FCasa = (bool)dbRec[DBAdvogadosDicInfo.Casa]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Casa]))
            m_FCasa = (bool)dbRec[DBAdvogadosDicInfo.Casa];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeMae = dbRec[DBAdvogadosDicInfo.NomeMae]?.ToString() ?? string.Empty; m_FNomeMae = dbRec[DBAdvogadosDicInfo.NomeMae]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeMae = dbRec[DBAdvogadosDicInfo.NomeMae]?.ToString() ?? string.Empty; m_FNomeMae = dbRec[DBAdvogadosDicInfo.NomeMae]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeMae = dbRec[DBAdvogadosDicInfo.NomeMae]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeMae = dbRec[DBAdvogadosDicInfo.NomeMae]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Escritorio])) m_FEscritorio = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Escritorio]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Escritorio])) m_FEscritorio = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Escritorio]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Escritorio])) m_FEscritorio = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Escritorio]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Escritorio])) m_FEscritorio = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Escritorio]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Escritorio])) m_FEscritorio = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Escritorio]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Escritorio]))
            m_FEscritorio = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Escritorio]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Estagiario])) m_FEstagiario = (bool)dbRec[DBAdvogadosDicInfo.Estagiario]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Estagiario])) m_FEstagiario = (bool)dbRec[DBAdvogadosDicInfo.Estagiario];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Estagiario])) m_FEstagiario = (bool)dbRec[DBAdvogadosDicInfo.Estagiario]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Estagiario])) m_FEstagiario = (bool)dbRec[DBAdvogadosDicInfo.Estagiario];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Estagiario])) m_FEstagiario = (bool)dbRec[DBAdvogadosDicInfo.Estagiario]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Estagiario]))
            m_FEstagiario = (bool)dbRec[DBAdvogadosDicInfo.Estagiario];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOAB = dbRec[DBAdvogadosDicInfo.OAB]?.ToString() ?? string.Empty; m_FOAB = dbRec[DBAdvogadosDicInfo.OAB]?.ToString() ?? string.Empty;  } catch {}  try { m_FOAB = dbRec[DBAdvogadosDicInfo.OAB]?.ToString() ?? string.Empty; m_FOAB = dbRec[DBAdvogadosDicInfo.OAB]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOAB = dbRec[DBAdvogadosDicInfo.OAB]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOAB = dbRec[DBAdvogadosDicInfo.OAB]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeCompleto = dbRec[DBAdvogadosDicInfo.NomeCompleto]?.ToString() ?? string.Empty; m_FNomeCompleto = dbRec[DBAdvogadosDicInfo.NomeCompleto]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeCompleto = dbRec[DBAdvogadosDicInfo.NomeCompleto]?.ToString() ?? string.Empty; m_FNomeCompleto = dbRec[DBAdvogadosDicInfo.NomeCompleto]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeCompleto = dbRec[DBAdvogadosDicInfo.NomeCompleto]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeCompleto = dbRec[DBAdvogadosDicInfo.NomeCompleto]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBAdvogadosDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBAdvogadosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBAdvogadosDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBAdvogadosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBAdvogadosDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBAdvogadosDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBAdvogadosDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBAdvogadosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBAdvogadosDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBAdvogadosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBAdvogadosDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBAdvogadosDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBAdvogadosDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBAdvogadosDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBAdvogadosDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBAdvogadosDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBAdvogadosDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBAdvogadosDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBAdvogadosDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBAdvogadosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBAdvogadosDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBAdvogadosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBAdvogadosDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBAdvogadosDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCTPSSerie = dbRec[DBAdvogadosDicInfo.CTPSSerie]?.ToString() ?? string.Empty; m_FCTPSSerie = dbRec[DBAdvogadosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;  } catch {}  try { m_FCTPSSerie = dbRec[DBAdvogadosDicInfo.CTPSSerie]?.ToString() ?? string.Empty; m_FCTPSSerie = dbRec[DBAdvogadosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCTPSSerie = dbRec[DBAdvogadosDicInfo.CTPSSerie]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCTPSSerie = dbRec[DBAdvogadosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCTPS = dbRec[DBAdvogadosDicInfo.CTPS]?.ToString() ?? string.Empty; m_FCTPS = dbRec[DBAdvogadosDicInfo.CTPS]?.ToString() ?? string.Empty;  } catch {}  try { m_FCTPS = dbRec[DBAdvogadosDicInfo.CTPS]?.ToString() ?? string.Empty; m_FCTPS = dbRec[DBAdvogadosDicInfo.CTPS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCTPS = dbRec[DBAdvogadosDicInfo.CTPS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCTPS = dbRec[DBAdvogadosDicInfo.CTPS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBAdvogadosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBAdvogadosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBAdvogadosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBAdvogadosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBAdvogadosDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBAdvogadosDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBAdvogadosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBAdvogadosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBAdvogadosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBAdvogadosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBAdvogadosDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBAdvogadosDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Comissao])) m_FComissao = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Comissao]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Comissao])) m_FComissao = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Comissao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Comissao])) m_FComissao = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Comissao]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Comissao])) m_FComissao = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Comissao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Comissao])) m_FComissao = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Comissao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Comissao]))
            m_FComissao = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Comissao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtInicio])) m_FDtInicio = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtInicio]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtInicio])) m_FDtInicio = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtInicio]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtInicio])) m_FDtInicio = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtInicio]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtInicio])) m_FDtInicio = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtInicio]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtInicio])) m_FDtInicio = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtInicio]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtInicio]))
            m_FDtInicio = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtInicio]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtFim])) m_FDtFim = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtFim]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtFim])) m_FDtFim = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtFim]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtFim])) m_FDtFim = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtFim]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtFim])) m_FDtFim = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtFim]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtFim])) m_FDtFim = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtFim]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtFim]))
            m_FDtFim = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtFim]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtNasc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtNasc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtNasc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtNasc]))
            m_FDtNasc = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtNasc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBAdvogadosDicInfo.Salario]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBAdvogadosDicInfo.Salario]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBAdvogadosDicInfo.Salario]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBAdvogadosDicInfo.Salario]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBAdvogadosDicInfo.Salario]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Salario]))
            m_FSalario = Convert.ToDecimal(dbRec[DBAdvogadosDicInfo.Salario]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSecretaria = dbRec[DBAdvogadosDicInfo.Secretaria]?.ToString() ?? string.Empty; m_FSecretaria = dbRec[DBAdvogadosDicInfo.Secretaria]?.ToString() ?? string.Empty;  } catch {}  try { m_FSecretaria = dbRec[DBAdvogadosDicInfo.Secretaria]?.ToString() ?? string.Empty; m_FSecretaria = dbRec[DBAdvogadosDicInfo.Secretaria]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSecretaria = dbRec[DBAdvogadosDicInfo.Secretaria]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSecretaria = dbRec[DBAdvogadosDicInfo.Secretaria]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FTextoProcuracao = dbRec[DBAdvogadosDicInfo.TextoProcuracao]?.ToString() ?? string.Empty; m_FTextoProcuracao = dbRec[DBAdvogadosDicInfo.TextoProcuracao]?.ToString() ?? string.Empty;  } catch {}  try { m_FTextoProcuracao = dbRec[DBAdvogadosDicInfo.TextoProcuracao]?.ToString() ?? string.Empty; m_FTextoProcuracao = dbRec[DBAdvogadosDicInfo.TextoProcuracao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FTextoProcuracao = dbRec[DBAdvogadosDicInfo.TextoProcuracao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FTextoProcuracao = dbRec[DBAdvogadosDicInfo.TextoProcuracao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBAdvogadosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBAdvogadosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBAdvogadosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBAdvogadosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBAdvogadosDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBAdvogadosDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEspecializacao = dbRec[DBAdvogadosDicInfo.Especializacao]?.ToString() ?? string.Empty; m_FEspecializacao = dbRec[DBAdvogadosDicInfo.Especializacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FEspecializacao = dbRec[DBAdvogadosDicInfo.Especializacao]?.ToString() ?? string.Empty; m_FEspecializacao = dbRec[DBAdvogadosDicInfo.Especializacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEspecializacao = dbRec[DBAdvogadosDicInfo.Especializacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEspecializacao = dbRec[DBAdvogadosDicInfo.Especializacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPasta = dbRec[DBAdvogadosDicInfo.Pasta]?.ToString() ?? string.Empty; m_FPasta = dbRec[DBAdvogadosDicInfo.Pasta]?.ToString() ?? string.Empty;  } catch {}  try { m_FPasta = dbRec[DBAdvogadosDicInfo.Pasta]?.ToString() ?? string.Empty; m_FPasta = dbRec[DBAdvogadosDicInfo.Pasta]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPasta = dbRec[DBAdvogadosDicInfo.Pasta]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPasta = dbRec[DBAdvogadosDicInfo.Pasta]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBAdvogadosDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBAdvogadosDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBAdvogadosDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBAdvogadosDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBAdvogadosDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBAdvogadosDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FContaBancaria = dbRec[DBAdvogadosDicInfo.ContaBancaria]?.ToString() ?? string.Empty; m_FContaBancaria = dbRec[DBAdvogadosDicInfo.ContaBancaria]?.ToString() ?? string.Empty;  } catch {}  try { m_FContaBancaria = dbRec[DBAdvogadosDicInfo.ContaBancaria]?.ToString() ?? string.Empty; m_FContaBancaria = dbRec[DBAdvogadosDicInfo.ContaBancaria]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FContaBancaria = dbRec[DBAdvogadosDicInfo.ContaBancaria]?.ToString() ?? string.Empty; } catch { }

#else
        m_FContaBancaria = dbRec[DBAdvogadosDicInfo.ContaBancaria]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.ParcTop])) m_FParcTop = (bool)dbRec[DBAdvogadosDicInfo.ParcTop]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.ParcTop])) m_FParcTop = (bool)dbRec[DBAdvogadosDicInfo.ParcTop];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.ParcTop])) m_FParcTop = (bool)dbRec[DBAdvogadosDicInfo.ParcTop]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.ParcTop])) m_FParcTop = (bool)dbRec[DBAdvogadosDicInfo.ParcTop];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.ParcTop])) m_FParcTop = (bool)dbRec[DBAdvogadosDicInfo.ParcTop]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.ParcTop]))
            m_FParcTop = (bool)dbRec[DBAdvogadosDicInfo.ParcTop];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FClass = dbRec[DBAdvogadosDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBAdvogadosDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FClass = dbRec[DBAdvogadosDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBAdvogadosDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FClass = dbRec[DBAdvogadosDicInfo.Class]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FClass = dbRec[DBAdvogadosDicInfo.Class]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Top])) m_FTop = (bool)dbRec[DBAdvogadosDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Top])) m_FTop = (bool)dbRec[DBAdvogadosDicInfo.Top];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Top])) m_FTop = (bool)dbRec[DBAdvogadosDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Top])) m_FTop = (bool)dbRec[DBAdvogadosDicInfo.Top];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Top])) m_FTop = (bool)dbRec[DBAdvogadosDicInfo.Top]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Top]))
            m_FTop = (bool)dbRec[DBAdvogadosDicInfo.Top];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBAdvogadosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBAdvogadosDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBAdvogadosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBAdvogadosDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBAdvogadosDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBAdvogadosDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Ani])) m_FAni = (bool)dbRec[DBAdvogadosDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Ani])) m_FAni = (bool)dbRec[DBAdvogadosDicInfo.Ani];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Ani])) m_FAni = (bool)dbRec[DBAdvogadosDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Ani])) m_FAni = (bool)dbRec[DBAdvogadosDicInfo.Ani];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Ani])) m_FAni = (bool)dbRec[DBAdvogadosDicInfo.Ani]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Ani]))
            m_FAni = (bool)dbRec[DBAdvogadosDicInfo.Ani];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Bold])) m_FBold = (bool)dbRec[DBAdvogadosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Bold])) m_FBold = (bool)dbRec[DBAdvogadosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Bold])) m_FBold = (bool)dbRec[DBAdvogadosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Bold])) m_FBold = (bool)dbRec[DBAdvogadosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Bold])) m_FBold = (bool)dbRec[DBAdvogadosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBAdvogadosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBAdvogadosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAdvogadosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBAdvogadosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAdvogadosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBAdvogadosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBAdvogadosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAdvogadosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAdvogadosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAdvogadosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAdvogadosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAdvogadosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAdvogadosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Advogados
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
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cargo]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cargo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cargo]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cargo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cargo])) m_FCargo = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cargo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cargo]))
            m_FCargo = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cargo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMailPro = dbRec[DBAdvogadosDicInfo.EMailPro]?.ToString() ?? string.Empty; m_FEMailPro = dbRec[DBAdvogadosDicInfo.EMailPro]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMailPro = dbRec[DBAdvogadosDicInfo.EMailPro]?.ToString() ?? string.Empty; m_FEMailPro = dbRec[DBAdvogadosDicInfo.EMailPro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMailPro = dbRec[DBAdvogadosDicInfo.EMailPro]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMailPro = dbRec[DBAdvogadosDicInfo.EMailPro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBAdvogadosDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBAdvogadosDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBAdvogadosDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBAdvogadosDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBAdvogadosDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBAdvogadosDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FNome = dbRec[DBAdvogadosDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBAdvogadosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBAdvogadosDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBAdvogadosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBAdvogadosDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBAdvogadosDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBAdvogadosDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBAdvogadosDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBAdvogadosDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBAdvogadosDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBAdvogadosDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBAdvogadosDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Casa])) m_FCasa = (bool)dbRec[DBAdvogadosDicInfo.Casa]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Casa])) m_FCasa = (bool)dbRec[DBAdvogadosDicInfo.Casa];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Casa])) m_FCasa = (bool)dbRec[DBAdvogadosDicInfo.Casa]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Casa])) m_FCasa = (bool)dbRec[DBAdvogadosDicInfo.Casa];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Casa])) m_FCasa = (bool)dbRec[DBAdvogadosDicInfo.Casa]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Casa]))
            m_FCasa = (bool)dbRec[DBAdvogadosDicInfo.Casa];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeMae = dbRec[DBAdvogadosDicInfo.NomeMae]?.ToString() ?? string.Empty; m_FNomeMae = dbRec[DBAdvogadosDicInfo.NomeMae]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeMae = dbRec[DBAdvogadosDicInfo.NomeMae]?.ToString() ?? string.Empty; m_FNomeMae = dbRec[DBAdvogadosDicInfo.NomeMae]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeMae = dbRec[DBAdvogadosDicInfo.NomeMae]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeMae = dbRec[DBAdvogadosDicInfo.NomeMae]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Escritorio])) m_FEscritorio = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Escritorio]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Escritorio])) m_FEscritorio = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Escritorio]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Escritorio])) m_FEscritorio = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Escritorio]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Escritorio])) m_FEscritorio = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Escritorio]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Escritorio])) m_FEscritorio = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Escritorio]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Escritorio]))
            m_FEscritorio = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Escritorio]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Estagiario])) m_FEstagiario = (bool)dbRec[DBAdvogadosDicInfo.Estagiario]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Estagiario])) m_FEstagiario = (bool)dbRec[DBAdvogadosDicInfo.Estagiario];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Estagiario])) m_FEstagiario = (bool)dbRec[DBAdvogadosDicInfo.Estagiario]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Estagiario])) m_FEstagiario = (bool)dbRec[DBAdvogadosDicInfo.Estagiario];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Estagiario])) m_FEstagiario = (bool)dbRec[DBAdvogadosDicInfo.Estagiario]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Estagiario]))
            m_FEstagiario = (bool)dbRec[DBAdvogadosDicInfo.Estagiario];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOAB = dbRec[DBAdvogadosDicInfo.OAB]?.ToString() ?? string.Empty; m_FOAB = dbRec[DBAdvogadosDicInfo.OAB]?.ToString() ?? string.Empty;  } catch {}  try { m_FOAB = dbRec[DBAdvogadosDicInfo.OAB]?.ToString() ?? string.Empty; m_FOAB = dbRec[DBAdvogadosDicInfo.OAB]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOAB = dbRec[DBAdvogadosDicInfo.OAB]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOAB = dbRec[DBAdvogadosDicInfo.OAB]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeCompleto = dbRec[DBAdvogadosDicInfo.NomeCompleto]?.ToString() ?? string.Empty; m_FNomeCompleto = dbRec[DBAdvogadosDicInfo.NomeCompleto]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeCompleto = dbRec[DBAdvogadosDicInfo.NomeCompleto]?.ToString() ?? string.Empty; m_FNomeCompleto = dbRec[DBAdvogadosDicInfo.NomeCompleto]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeCompleto = dbRec[DBAdvogadosDicInfo.NomeCompleto]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeCompleto = dbRec[DBAdvogadosDicInfo.NomeCompleto]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBAdvogadosDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBAdvogadosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBAdvogadosDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBAdvogadosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBAdvogadosDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBAdvogadosDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBAdvogadosDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBAdvogadosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBAdvogadosDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBAdvogadosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBAdvogadosDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBAdvogadosDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBAdvogadosDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBAdvogadosDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBAdvogadosDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBAdvogadosDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBAdvogadosDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBAdvogadosDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBAdvogadosDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBAdvogadosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBAdvogadosDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBAdvogadosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBAdvogadosDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBAdvogadosDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCTPSSerie = dbRec[DBAdvogadosDicInfo.CTPSSerie]?.ToString() ?? string.Empty; m_FCTPSSerie = dbRec[DBAdvogadosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;  } catch {}  try { m_FCTPSSerie = dbRec[DBAdvogadosDicInfo.CTPSSerie]?.ToString() ?? string.Empty; m_FCTPSSerie = dbRec[DBAdvogadosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCTPSSerie = dbRec[DBAdvogadosDicInfo.CTPSSerie]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCTPSSerie = dbRec[DBAdvogadosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCTPS = dbRec[DBAdvogadosDicInfo.CTPS]?.ToString() ?? string.Empty; m_FCTPS = dbRec[DBAdvogadosDicInfo.CTPS]?.ToString() ?? string.Empty;  } catch {}  try { m_FCTPS = dbRec[DBAdvogadosDicInfo.CTPS]?.ToString() ?? string.Empty; m_FCTPS = dbRec[DBAdvogadosDicInfo.CTPS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCTPS = dbRec[DBAdvogadosDicInfo.CTPS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCTPS = dbRec[DBAdvogadosDicInfo.CTPS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBAdvogadosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBAdvogadosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBAdvogadosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBAdvogadosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBAdvogadosDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBAdvogadosDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBAdvogadosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBAdvogadosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBAdvogadosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBAdvogadosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBAdvogadosDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBAdvogadosDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Comissao])) m_FComissao = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Comissao]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Comissao])) m_FComissao = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Comissao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Comissao])) m_FComissao = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Comissao]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Comissao])) m_FComissao = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Comissao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Comissao])) m_FComissao = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Comissao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Comissao]))
            m_FComissao = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.Comissao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtInicio])) m_FDtInicio = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtInicio]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtInicio])) m_FDtInicio = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtInicio]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtInicio])) m_FDtInicio = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtInicio]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtInicio])) m_FDtInicio = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtInicio]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtInicio])) m_FDtInicio = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtInicio]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtInicio]))
            m_FDtInicio = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtInicio]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtFim])) m_FDtFim = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtFim]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtFim])) m_FDtFim = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtFim]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtFim])) m_FDtFim = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtFim]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtFim])) m_FDtFim = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtFim]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtFim])) m_FDtFim = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtFim]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtFim]))
            m_FDtFim = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtFim]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtNasc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtNasc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtNasc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtNasc]))
            m_FDtNasc = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtNasc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBAdvogadosDicInfo.Salario]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBAdvogadosDicInfo.Salario]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBAdvogadosDicInfo.Salario]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBAdvogadosDicInfo.Salario]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBAdvogadosDicInfo.Salario]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Salario]))
            m_FSalario = Convert.ToDecimal(dbRec[DBAdvogadosDicInfo.Salario]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSecretaria = dbRec[DBAdvogadosDicInfo.Secretaria]?.ToString() ?? string.Empty; m_FSecretaria = dbRec[DBAdvogadosDicInfo.Secretaria]?.ToString() ?? string.Empty;  } catch {}  try { m_FSecretaria = dbRec[DBAdvogadosDicInfo.Secretaria]?.ToString() ?? string.Empty; m_FSecretaria = dbRec[DBAdvogadosDicInfo.Secretaria]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSecretaria = dbRec[DBAdvogadosDicInfo.Secretaria]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSecretaria = dbRec[DBAdvogadosDicInfo.Secretaria]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FTextoProcuracao = dbRec[DBAdvogadosDicInfo.TextoProcuracao]?.ToString() ?? string.Empty; m_FTextoProcuracao = dbRec[DBAdvogadosDicInfo.TextoProcuracao]?.ToString() ?? string.Empty;  } catch {}  try { m_FTextoProcuracao = dbRec[DBAdvogadosDicInfo.TextoProcuracao]?.ToString() ?? string.Empty; m_FTextoProcuracao = dbRec[DBAdvogadosDicInfo.TextoProcuracao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FTextoProcuracao = dbRec[DBAdvogadosDicInfo.TextoProcuracao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FTextoProcuracao = dbRec[DBAdvogadosDicInfo.TextoProcuracao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBAdvogadosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBAdvogadosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBAdvogadosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBAdvogadosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBAdvogadosDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBAdvogadosDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEspecializacao = dbRec[DBAdvogadosDicInfo.Especializacao]?.ToString() ?? string.Empty; m_FEspecializacao = dbRec[DBAdvogadosDicInfo.Especializacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FEspecializacao = dbRec[DBAdvogadosDicInfo.Especializacao]?.ToString() ?? string.Empty; m_FEspecializacao = dbRec[DBAdvogadosDicInfo.Especializacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEspecializacao = dbRec[DBAdvogadosDicInfo.Especializacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEspecializacao = dbRec[DBAdvogadosDicInfo.Especializacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPasta = dbRec[DBAdvogadosDicInfo.Pasta]?.ToString() ?? string.Empty; m_FPasta = dbRec[DBAdvogadosDicInfo.Pasta]?.ToString() ?? string.Empty;  } catch {}  try { m_FPasta = dbRec[DBAdvogadosDicInfo.Pasta]?.ToString() ?? string.Empty; m_FPasta = dbRec[DBAdvogadosDicInfo.Pasta]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPasta = dbRec[DBAdvogadosDicInfo.Pasta]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPasta = dbRec[DBAdvogadosDicInfo.Pasta]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBAdvogadosDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBAdvogadosDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBAdvogadosDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBAdvogadosDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBAdvogadosDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBAdvogadosDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FContaBancaria = dbRec[DBAdvogadosDicInfo.ContaBancaria]?.ToString() ?? string.Empty; m_FContaBancaria = dbRec[DBAdvogadosDicInfo.ContaBancaria]?.ToString() ?? string.Empty;  } catch {}  try { m_FContaBancaria = dbRec[DBAdvogadosDicInfo.ContaBancaria]?.ToString() ?? string.Empty; m_FContaBancaria = dbRec[DBAdvogadosDicInfo.ContaBancaria]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FContaBancaria = dbRec[DBAdvogadosDicInfo.ContaBancaria]?.ToString() ?? string.Empty; } catch { }

#else
        m_FContaBancaria = dbRec[DBAdvogadosDicInfo.ContaBancaria]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.ParcTop])) m_FParcTop = (bool)dbRec[DBAdvogadosDicInfo.ParcTop]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.ParcTop])) m_FParcTop = (bool)dbRec[DBAdvogadosDicInfo.ParcTop];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.ParcTop])) m_FParcTop = (bool)dbRec[DBAdvogadosDicInfo.ParcTop]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.ParcTop])) m_FParcTop = (bool)dbRec[DBAdvogadosDicInfo.ParcTop];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.ParcTop])) m_FParcTop = (bool)dbRec[DBAdvogadosDicInfo.ParcTop]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.ParcTop]))
            m_FParcTop = (bool)dbRec[DBAdvogadosDicInfo.ParcTop];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FClass = dbRec[DBAdvogadosDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBAdvogadosDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FClass = dbRec[DBAdvogadosDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBAdvogadosDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FClass = dbRec[DBAdvogadosDicInfo.Class]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FClass = dbRec[DBAdvogadosDicInfo.Class]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Top])) m_FTop = (bool)dbRec[DBAdvogadosDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Top])) m_FTop = (bool)dbRec[DBAdvogadosDicInfo.Top];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Top])) m_FTop = (bool)dbRec[DBAdvogadosDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Top])) m_FTop = (bool)dbRec[DBAdvogadosDicInfo.Top];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Top])) m_FTop = (bool)dbRec[DBAdvogadosDicInfo.Top]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Top]))
            m_FTop = (bool)dbRec[DBAdvogadosDicInfo.Top];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBAdvogadosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBAdvogadosDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBAdvogadosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBAdvogadosDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBAdvogadosDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBAdvogadosDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Ani])) m_FAni = (bool)dbRec[DBAdvogadosDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Ani])) m_FAni = (bool)dbRec[DBAdvogadosDicInfo.Ani];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Ani])) m_FAni = (bool)dbRec[DBAdvogadosDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Ani])) m_FAni = (bool)dbRec[DBAdvogadosDicInfo.Ani];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Ani])) m_FAni = (bool)dbRec[DBAdvogadosDicInfo.Ani]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Ani]))
            m_FAni = (bool)dbRec[DBAdvogadosDicInfo.Ani];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Bold])) m_FBold = (bool)dbRec[DBAdvogadosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Bold])) m_FBold = (bool)dbRec[DBAdvogadosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Bold])) m_FBold = (bool)dbRec[DBAdvogadosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Bold])) m_FBold = (bool)dbRec[DBAdvogadosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Bold])) m_FBold = (bool)dbRec[DBAdvogadosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBAdvogadosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBAdvogadosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAdvogadosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBAdvogadosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAdvogadosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBAdvogadosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBAdvogadosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAdvogadosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAdvogadosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAdvogadosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAdvogadosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAdvogadosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAdvogadosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAdvogadosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAdvogadosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAdvogadosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}