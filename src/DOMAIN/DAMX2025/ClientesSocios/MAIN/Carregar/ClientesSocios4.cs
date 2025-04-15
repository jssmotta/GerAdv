namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBClientesSocios
{
    public DBClientesSocios(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Ani]))
                m_FAni = (bool)dbRec[DBClientesSociosDicInfo.Ani];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBClientesSociosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.CidadeSocio]))
                m_FCidadeSocio = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.CidadeSocio]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DataContrato]))
                m_FDataContrato = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DataContrato]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtNasc]))
                m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtNasc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBClientesSociosDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Idade]))
                m_FIdade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Idade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal]))
                m_FIsRepresentanteLegal = (bool)dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.RGDataExp]))
                m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.RGDataExp]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBClientesSociosDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente]))
                m_FSocioEmpresaAdminSomente = (bool)dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SomenteRepresentante]))
                m_FSomenteRepresentante = (bool)dbRec[DBClientesSociosDicInfo.SomenteRepresentante];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Tipo]))
                m_FTipo = (bool)dbRec[DBClientesSociosDicInfo.Tipo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBClientesSociosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FBairroSocio = dbRec[DBClientesSociosDicInfo.BairroSocio]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCargo = dbRec[DBClientesSociosDicInfo.Cargo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCEPSocio = dbRec[DBClientesSociosDicInfo.CEPSocio]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCNH = dbRec[DBClientesSociosDicInfo.CNH]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCNPJ = dbRec[DBClientesSociosDicInfo.CNPJ]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBClientesSociosDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEnderecoSocio = dbRec[DBClientesSociosDicInfo.EnderecoSocio]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBClientesSociosDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBClientesSociosDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBClientesSociosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FInscEst = dbRec[DBClientesSociosDicInfo.InscEst]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObs = dbRec[DBClientesSociosDicInfo.Obs]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FParticipacao = dbRec[DBClientesSociosDicInfo.Participacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FQualificacao = dbRec[DBClientesSociosDicInfo.Qualificacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRepresentanteLegal = dbRec[DBClientesSociosDicInfo.RepresentanteLegal]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBClientesSociosDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSite = dbRec[DBClientesSociosDicInfo.Site]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSocioEmpresaAdminNome = dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminNome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBClientesSociosDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBClientesSociosDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FClass = dbRec[DBClientesSociosDicInfo.Class]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBClientesSociosDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBClientesSociosDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBClientesSociosDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBClientesSocios(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Ani]))
                m_FAni = (bool)dbRec[DBClientesSociosDicInfo.Ani];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBClientesSociosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.CidadeSocio]))
                m_FCidadeSocio = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.CidadeSocio]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DataContrato]))
                m_FDataContrato = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DataContrato]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtNasc]))
                m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtNasc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBClientesSociosDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Idade]))
                m_FIdade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Idade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal]))
                m_FIsRepresentanteLegal = (bool)dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.RGDataExp]))
                m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.RGDataExp]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBClientesSociosDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente]))
                m_FSocioEmpresaAdminSomente = (bool)dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SomenteRepresentante]))
                m_FSomenteRepresentante = (bool)dbRec[DBClientesSociosDicInfo.SomenteRepresentante];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Tipo]))
                m_FTipo = (bool)dbRec[DBClientesSociosDicInfo.Tipo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBClientesSociosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FBairroSocio = dbRec[DBClientesSociosDicInfo.BairroSocio]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCargo = dbRec[DBClientesSociosDicInfo.Cargo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCEPSocio = dbRec[DBClientesSociosDicInfo.CEPSocio]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCNH = dbRec[DBClientesSociosDicInfo.CNH]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCNPJ = dbRec[DBClientesSociosDicInfo.CNPJ]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBClientesSociosDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEnderecoSocio = dbRec[DBClientesSociosDicInfo.EnderecoSocio]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBClientesSociosDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBClientesSociosDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBClientesSociosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FInscEst = dbRec[DBClientesSociosDicInfo.InscEst]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObs = dbRec[DBClientesSociosDicInfo.Obs]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FParticipacao = dbRec[DBClientesSociosDicInfo.Participacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FQualificacao = dbRec[DBClientesSociosDicInfo.Qualificacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRepresentanteLegal = dbRec[DBClientesSociosDicInfo.RepresentanteLegal]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBClientesSociosDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSite = dbRec[DBClientesSociosDicInfo.Site]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSocioEmpresaAdminNome = dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminNome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBClientesSociosDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBClientesSociosDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FClass = dbRec[DBClientesSociosDicInfo.Class]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBClientesSociosDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBClientesSociosDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBClientesSociosDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_ClientesSocios
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[ClientesSocios] (NOLOCK) WHERE [cscCodigo] = @ThisIDToLoad", oCnn);
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
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SomenteRepresentante])) m_FSomenteRepresentante = (bool)dbRec[DBClientesSociosDicInfo.SomenteRepresentante]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SomenteRepresentante])) m_FSomenteRepresentante = (bool)dbRec[DBClientesSociosDicInfo.SomenteRepresentante];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SomenteRepresentante])) m_FSomenteRepresentante = (bool)dbRec[DBClientesSociosDicInfo.SomenteRepresentante]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SomenteRepresentante])) m_FSomenteRepresentante = (bool)dbRec[DBClientesSociosDicInfo.SomenteRepresentante];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SomenteRepresentante])) m_FSomenteRepresentante = (bool)dbRec[DBClientesSociosDicInfo.SomenteRepresentante]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SomenteRepresentante]))
            m_FSomenteRepresentante = (bool)dbRec[DBClientesSociosDicInfo.SomenteRepresentante];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Idade]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Idade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Idade]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Idade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Idade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Idade]))
            m_FIdade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Idade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal])) m_FIsRepresentanteLegal = (bool)dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal])) m_FIsRepresentanteLegal = (bool)dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal])) m_FIsRepresentanteLegal = (bool)dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal])) m_FIsRepresentanteLegal = (bool)dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal])) m_FIsRepresentanteLegal = (bool)dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal]))
            m_FIsRepresentanteLegal = (bool)dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FQualificacao = dbRec[DBClientesSociosDicInfo.Qualificacao]?.ToString() ?? string.Empty; m_FQualificacao = dbRec[DBClientesSociosDicInfo.Qualificacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FQualificacao = dbRec[DBClientesSociosDicInfo.Qualificacao]?.ToString() ?? string.Empty; m_FQualificacao = dbRec[DBClientesSociosDicInfo.Qualificacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FQualificacao = dbRec[DBClientesSociosDicInfo.Qualificacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FQualificacao = dbRec[DBClientesSociosDicInfo.Qualificacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBClientesSociosDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBClientesSociosDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBClientesSociosDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBClientesSociosDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBClientesSociosDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBClientesSociosDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtNasc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtNasc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtNasc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtNasc]))
            m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtNasc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FNome = dbRec[DBClientesSociosDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBClientesSociosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBClientesSociosDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBClientesSociosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBClientesSociosDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBClientesSociosDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSite = dbRec[DBClientesSociosDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBClientesSociosDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { m_FSite = dbRec[DBClientesSociosDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBClientesSociosDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSite = dbRec[DBClientesSociosDicInfo.Site]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSite = dbRec[DBClientesSociosDicInfo.Site]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRepresentanteLegal = dbRec[DBClientesSociosDicInfo.RepresentanteLegal]?.ToString() ?? string.Empty; m_FRepresentanteLegal = dbRec[DBClientesSociosDicInfo.RepresentanteLegal]?.ToString() ?? string.Empty;  } catch {}  try { m_FRepresentanteLegal = dbRec[DBClientesSociosDicInfo.RepresentanteLegal]?.ToString() ?? string.Empty; m_FRepresentanteLegal = dbRec[DBClientesSociosDicInfo.RepresentanteLegal]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRepresentanteLegal = dbRec[DBClientesSociosDicInfo.RepresentanteLegal]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRepresentanteLegal = dbRec[DBClientesSociosDicInfo.RepresentanteLegal]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBClientesSociosDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBClientesSociosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBClientesSociosDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBClientesSociosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBClientesSociosDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBClientesSociosDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBClientesSociosDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBClientesSociosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBClientesSociosDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBClientesSociosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBClientesSociosDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBClientesSociosDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBClientesSociosDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBClientesSociosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBClientesSociosDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBClientesSociosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBClientesSociosDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBClientesSociosDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBClientesSociosDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBClientesSociosDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBClientesSociosDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBClientesSociosDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBClientesSociosDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBClientesSociosDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBClientesSociosDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBClientesSociosDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBClientesSociosDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBClientesSociosDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBClientesSociosDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBClientesSociosDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBClientesSociosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBClientesSociosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBClientesSociosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBClientesSociosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBClientesSociosDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBClientesSociosDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FParticipacao = dbRec[DBClientesSociosDicInfo.Participacao]?.ToString() ?? string.Empty; m_FParticipacao = dbRec[DBClientesSociosDicInfo.Participacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FParticipacao = dbRec[DBClientesSociosDicInfo.Participacao]?.ToString() ?? string.Empty; m_FParticipacao = dbRec[DBClientesSociosDicInfo.Participacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FParticipacao = dbRec[DBClientesSociosDicInfo.Participacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FParticipacao = dbRec[DBClientesSociosDicInfo.Participacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCargo = dbRec[DBClientesSociosDicInfo.Cargo]?.ToString() ?? string.Empty; m_FCargo = dbRec[DBClientesSociosDicInfo.Cargo]?.ToString() ?? string.Empty;  } catch {}  try { m_FCargo = dbRec[DBClientesSociosDicInfo.Cargo]?.ToString() ?? string.Empty; m_FCargo = dbRec[DBClientesSociosDicInfo.Cargo]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCargo = dbRec[DBClientesSociosDicInfo.Cargo]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCargo = dbRec[DBClientesSociosDicInfo.Cargo]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBClientesSociosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBClientesSociosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBClientesSociosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBClientesSociosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBClientesSociosDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBClientesSociosDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObs = dbRec[DBClientesSociosDicInfo.Obs]?.ToString() ?? string.Empty; m_FObs = dbRec[DBClientesSociosDicInfo.Obs]?.ToString() ?? string.Empty;  } catch {}  try { m_FObs = dbRec[DBClientesSociosDicInfo.Obs]?.ToString() ?? string.Empty; m_FObs = dbRec[DBClientesSociosDicInfo.Obs]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObs = dbRec[DBClientesSociosDicInfo.Obs]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObs = dbRec[DBClientesSociosDicInfo.Obs]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCNH = dbRec[DBClientesSociosDicInfo.CNH]?.ToString() ?? string.Empty; m_FCNH = dbRec[DBClientesSociosDicInfo.CNH]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNH = dbRec[DBClientesSociosDicInfo.CNH]?.ToString() ?? string.Empty; m_FCNH = dbRec[DBClientesSociosDicInfo.CNH]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNH = dbRec[DBClientesSociosDicInfo.CNH]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNH = dbRec[DBClientesSociosDicInfo.CNH]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DataContrato])) m_FDataContrato = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DataContrato]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DataContrato])) m_FDataContrato = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DataContrato]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DataContrato])) m_FDataContrato = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DataContrato]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DataContrato])) m_FDataContrato = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DataContrato]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DataContrato])) m_FDataContrato = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DataContrato]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DataContrato]))
            m_FDataContrato = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DataContrato]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCNPJ = dbRec[DBClientesSociosDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBClientesSociosDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNPJ = dbRec[DBClientesSociosDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBClientesSociosDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNPJ = dbRec[DBClientesSociosDicInfo.CNPJ]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNPJ = dbRec[DBClientesSociosDicInfo.CNPJ]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FInscEst = dbRec[DBClientesSociosDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBClientesSociosDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { m_FInscEst = dbRec[DBClientesSociosDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBClientesSociosDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FInscEst = dbRec[DBClientesSociosDicInfo.InscEst]?.ToString() ?? string.Empty; } catch { }

#else
        m_FInscEst = dbRec[DBClientesSociosDicInfo.InscEst]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSocioEmpresaAdminNome = dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminNome]?.ToString() ?? string.Empty; m_FSocioEmpresaAdminNome = dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminNome]?.ToString() ?? string.Empty;  } catch {}  try { m_FSocioEmpresaAdminNome = dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminNome]?.ToString() ?? string.Empty; m_FSocioEmpresaAdminNome = dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminNome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSocioEmpresaAdminNome = dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminNome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSocioEmpresaAdminNome = dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminNome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEnderecoSocio = dbRec[DBClientesSociosDicInfo.EnderecoSocio]?.ToString() ?? string.Empty; m_FEnderecoSocio = dbRec[DBClientesSociosDicInfo.EnderecoSocio]?.ToString() ?? string.Empty;  } catch {}  try { m_FEnderecoSocio = dbRec[DBClientesSociosDicInfo.EnderecoSocio]?.ToString() ?? string.Empty; m_FEnderecoSocio = dbRec[DBClientesSociosDicInfo.EnderecoSocio]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEnderecoSocio = dbRec[DBClientesSociosDicInfo.EnderecoSocio]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEnderecoSocio = dbRec[DBClientesSociosDicInfo.EnderecoSocio]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FBairroSocio = dbRec[DBClientesSociosDicInfo.BairroSocio]?.ToString() ?? string.Empty; m_FBairroSocio = dbRec[DBClientesSociosDicInfo.BairroSocio]?.ToString() ?? string.Empty;  } catch {}  try { m_FBairroSocio = dbRec[DBClientesSociosDicInfo.BairroSocio]?.ToString() ?? string.Empty; m_FBairroSocio = dbRec[DBClientesSociosDicInfo.BairroSocio]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FBairroSocio = dbRec[DBClientesSociosDicInfo.BairroSocio]?.ToString() ?? string.Empty; } catch { }

#else
        m_FBairroSocio = dbRec[DBClientesSociosDicInfo.BairroSocio]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCEPSocio = dbRec[DBClientesSociosDicInfo.CEPSocio]?.ToString() ?? string.Empty; m_FCEPSocio = dbRec[DBClientesSociosDicInfo.CEPSocio]?.ToString() ?? string.Empty;  } catch {}  try { m_FCEPSocio = dbRec[DBClientesSociosDicInfo.CEPSocio]?.ToString() ?? string.Empty; m_FCEPSocio = dbRec[DBClientesSociosDicInfo.CEPSocio]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCEPSocio = dbRec[DBClientesSociosDicInfo.CEPSocio]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCEPSocio = dbRec[DBClientesSociosDicInfo.CEPSocio]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.CidadeSocio])) m_FCidadeSocio = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.CidadeSocio]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.CidadeSocio])) m_FCidadeSocio = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.CidadeSocio]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.CidadeSocio])) m_FCidadeSocio = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.CidadeSocio]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.CidadeSocio])) m_FCidadeSocio = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.CidadeSocio]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.CidadeSocio])) m_FCidadeSocio = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.CidadeSocio]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.CidadeSocio]))
            m_FCidadeSocio = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.CidadeSocio]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.RGDataExp])) m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.RGDataExp]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.RGDataExp])) m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.RGDataExp]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.RGDataExp])) m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.RGDataExp]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.RGDataExp])) m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.RGDataExp]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.RGDataExp])) m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.RGDataExp]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.RGDataExp]))
            m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.RGDataExp]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente])) m_FSocioEmpresaAdminSomente = (bool)dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente])) m_FSocioEmpresaAdminSomente = (bool)dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente])) m_FSocioEmpresaAdminSomente = (bool)dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente])) m_FSocioEmpresaAdminSomente = (bool)dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente])) m_FSocioEmpresaAdminSomente = (bool)dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente]))
            m_FSocioEmpresaAdminSomente = (bool)dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBClientesSociosDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBClientesSociosDicInfo.Tipo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBClientesSociosDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBClientesSociosDicInfo.Tipo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBClientesSociosDicInfo.Tipo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Tipo]))
            m_FTipo = (bool)dbRec[DBClientesSociosDicInfo.Tipo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBClientesSociosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBClientesSociosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBClientesSociosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBClientesSociosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBClientesSociosDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBClientesSociosDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FClass = dbRec[DBClientesSociosDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBClientesSociosDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FClass = dbRec[DBClientesSociosDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBClientesSociosDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FClass = dbRec[DBClientesSociosDicInfo.Class]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FClass = dbRec[DBClientesSociosDicInfo.Class]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBClientesSociosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBClientesSociosDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBClientesSociosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBClientesSociosDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBClientesSociosDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBClientesSociosDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Ani])) m_FAni = (bool)dbRec[DBClientesSociosDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Ani])) m_FAni = (bool)dbRec[DBClientesSociosDicInfo.Ani];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Ani])) m_FAni = (bool)dbRec[DBClientesSociosDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Ani])) m_FAni = (bool)dbRec[DBClientesSociosDicInfo.Ani];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Ani])) m_FAni = (bool)dbRec[DBClientesSociosDicInfo.Ani]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Ani]))
            m_FAni = (bool)dbRec[DBClientesSociosDicInfo.Ani];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Bold])) m_FBold = (bool)dbRec[DBClientesSociosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Bold])) m_FBold = (bool)dbRec[DBClientesSociosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Bold])) m_FBold = (bool)dbRec[DBClientesSociosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Bold])) m_FBold = (bool)dbRec[DBClientesSociosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Bold])) m_FBold = (bool)dbRec[DBClientesSociosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBClientesSociosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBClientesSociosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBClientesSociosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBClientesSociosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBClientesSociosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBClientesSociosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBClientesSociosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBClientesSociosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBClientesSociosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBClientesSociosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBClientesSociosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBClientesSociosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBClientesSociosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ClientesSocios
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
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SomenteRepresentante])) m_FSomenteRepresentante = (bool)dbRec[DBClientesSociosDicInfo.SomenteRepresentante]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SomenteRepresentante])) m_FSomenteRepresentante = (bool)dbRec[DBClientesSociosDicInfo.SomenteRepresentante];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SomenteRepresentante])) m_FSomenteRepresentante = (bool)dbRec[DBClientesSociosDicInfo.SomenteRepresentante]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SomenteRepresentante])) m_FSomenteRepresentante = (bool)dbRec[DBClientesSociosDicInfo.SomenteRepresentante];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SomenteRepresentante])) m_FSomenteRepresentante = (bool)dbRec[DBClientesSociosDicInfo.SomenteRepresentante]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SomenteRepresentante]))
            m_FSomenteRepresentante = (bool)dbRec[DBClientesSociosDicInfo.SomenteRepresentante];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Idade]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Idade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Idade]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Idade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Idade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Idade]))
            m_FIdade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Idade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal])) m_FIsRepresentanteLegal = (bool)dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal])) m_FIsRepresentanteLegal = (bool)dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal])) m_FIsRepresentanteLegal = (bool)dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal])) m_FIsRepresentanteLegal = (bool)dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal])) m_FIsRepresentanteLegal = (bool)dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal]))
            m_FIsRepresentanteLegal = (bool)dbRec[DBClientesSociosDicInfo.IsRepresentanteLegal];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FQualificacao = dbRec[DBClientesSociosDicInfo.Qualificacao]?.ToString() ?? string.Empty; m_FQualificacao = dbRec[DBClientesSociosDicInfo.Qualificacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FQualificacao = dbRec[DBClientesSociosDicInfo.Qualificacao]?.ToString() ?? string.Empty; m_FQualificacao = dbRec[DBClientesSociosDicInfo.Qualificacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FQualificacao = dbRec[DBClientesSociosDicInfo.Qualificacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FQualificacao = dbRec[DBClientesSociosDicInfo.Qualificacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBClientesSociosDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBClientesSociosDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBClientesSociosDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBClientesSociosDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBClientesSociosDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBClientesSociosDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtNasc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtNasc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtNasc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtNasc]))
            m_FDtNasc = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtNasc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FNome = dbRec[DBClientesSociosDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBClientesSociosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBClientesSociosDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBClientesSociosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBClientesSociosDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBClientesSociosDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSite = dbRec[DBClientesSociosDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBClientesSociosDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { m_FSite = dbRec[DBClientesSociosDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBClientesSociosDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSite = dbRec[DBClientesSociosDicInfo.Site]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSite = dbRec[DBClientesSociosDicInfo.Site]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRepresentanteLegal = dbRec[DBClientesSociosDicInfo.RepresentanteLegal]?.ToString() ?? string.Empty; m_FRepresentanteLegal = dbRec[DBClientesSociosDicInfo.RepresentanteLegal]?.ToString() ?? string.Empty;  } catch {}  try { m_FRepresentanteLegal = dbRec[DBClientesSociosDicInfo.RepresentanteLegal]?.ToString() ?? string.Empty; m_FRepresentanteLegal = dbRec[DBClientesSociosDicInfo.RepresentanteLegal]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRepresentanteLegal = dbRec[DBClientesSociosDicInfo.RepresentanteLegal]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRepresentanteLegal = dbRec[DBClientesSociosDicInfo.RepresentanteLegal]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBClientesSociosDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBClientesSociosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBClientesSociosDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBClientesSociosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBClientesSociosDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBClientesSociosDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBClientesSociosDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBClientesSociosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBClientesSociosDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBClientesSociosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBClientesSociosDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBClientesSociosDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBClientesSociosDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBClientesSociosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBClientesSociosDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBClientesSociosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBClientesSociosDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBClientesSociosDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBClientesSociosDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBClientesSociosDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBClientesSociosDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBClientesSociosDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBClientesSociosDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBClientesSociosDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBClientesSociosDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBClientesSociosDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBClientesSociosDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBClientesSociosDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBClientesSociosDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBClientesSociosDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBClientesSociosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBClientesSociosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBClientesSociosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBClientesSociosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBClientesSociosDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBClientesSociosDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FParticipacao = dbRec[DBClientesSociosDicInfo.Participacao]?.ToString() ?? string.Empty; m_FParticipacao = dbRec[DBClientesSociosDicInfo.Participacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FParticipacao = dbRec[DBClientesSociosDicInfo.Participacao]?.ToString() ?? string.Empty; m_FParticipacao = dbRec[DBClientesSociosDicInfo.Participacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FParticipacao = dbRec[DBClientesSociosDicInfo.Participacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FParticipacao = dbRec[DBClientesSociosDicInfo.Participacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCargo = dbRec[DBClientesSociosDicInfo.Cargo]?.ToString() ?? string.Empty; m_FCargo = dbRec[DBClientesSociosDicInfo.Cargo]?.ToString() ?? string.Empty;  } catch {}  try { m_FCargo = dbRec[DBClientesSociosDicInfo.Cargo]?.ToString() ?? string.Empty; m_FCargo = dbRec[DBClientesSociosDicInfo.Cargo]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCargo = dbRec[DBClientesSociosDicInfo.Cargo]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCargo = dbRec[DBClientesSociosDicInfo.Cargo]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBClientesSociosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBClientesSociosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBClientesSociosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBClientesSociosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBClientesSociosDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBClientesSociosDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObs = dbRec[DBClientesSociosDicInfo.Obs]?.ToString() ?? string.Empty; m_FObs = dbRec[DBClientesSociosDicInfo.Obs]?.ToString() ?? string.Empty;  } catch {}  try { m_FObs = dbRec[DBClientesSociosDicInfo.Obs]?.ToString() ?? string.Empty; m_FObs = dbRec[DBClientesSociosDicInfo.Obs]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObs = dbRec[DBClientesSociosDicInfo.Obs]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObs = dbRec[DBClientesSociosDicInfo.Obs]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCNH = dbRec[DBClientesSociosDicInfo.CNH]?.ToString() ?? string.Empty; m_FCNH = dbRec[DBClientesSociosDicInfo.CNH]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNH = dbRec[DBClientesSociosDicInfo.CNH]?.ToString() ?? string.Empty; m_FCNH = dbRec[DBClientesSociosDicInfo.CNH]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNH = dbRec[DBClientesSociosDicInfo.CNH]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNH = dbRec[DBClientesSociosDicInfo.CNH]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DataContrato])) m_FDataContrato = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DataContrato]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DataContrato])) m_FDataContrato = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DataContrato]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DataContrato])) m_FDataContrato = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DataContrato]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DataContrato])) m_FDataContrato = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DataContrato]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DataContrato])) m_FDataContrato = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DataContrato]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DataContrato]))
            m_FDataContrato = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DataContrato]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCNPJ = dbRec[DBClientesSociosDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBClientesSociosDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNPJ = dbRec[DBClientesSociosDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBClientesSociosDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNPJ = dbRec[DBClientesSociosDicInfo.CNPJ]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNPJ = dbRec[DBClientesSociosDicInfo.CNPJ]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FInscEst = dbRec[DBClientesSociosDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBClientesSociosDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { m_FInscEst = dbRec[DBClientesSociosDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBClientesSociosDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FInscEst = dbRec[DBClientesSociosDicInfo.InscEst]?.ToString() ?? string.Empty; } catch { }

#else
        m_FInscEst = dbRec[DBClientesSociosDicInfo.InscEst]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSocioEmpresaAdminNome = dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminNome]?.ToString() ?? string.Empty; m_FSocioEmpresaAdminNome = dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminNome]?.ToString() ?? string.Empty;  } catch {}  try { m_FSocioEmpresaAdminNome = dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminNome]?.ToString() ?? string.Empty; m_FSocioEmpresaAdminNome = dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminNome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSocioEmpresaAdminNome = dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminNome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSocioEmpresaAdminNome = dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminNome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEnderecoSocio = dbRec[DBClientesSociosDicInfo.EnderecoSocio]?.ToString() ?? string.Empty; m_FEnderecoSocio = dbRec[DBClientesSociosDicInfo.EnderecoSocio]?.ToString() ?? string.Empty;  } catch {}  try { m_FEnderecoSocio = dbRec[DBClientesSociosDicInfo.EnderecoSocio]?.ToString() ?? string.Empty; m_FEnderecoSocio = dbRec[DBClientesSociosDicInfo.EnderecoSocio]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEnderecoSocio = dbRec[DBClientesSociosDicInfo.EnderecoSocio]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEnderecoSocio = dbRec[DBClientesSociosDicInfo.EnderecoSocio]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FBairroSocio = dbRec[DBClientesSociosDicInfo.BairroSocio]?.ToString() ?? string.Empty; m_FBairroSocio = dbRec[DBClientesSociosDicInfo.BairroSocio]?.ToString() ?? string.Empty;  } catch {}  try { m_FBairroSocio = dbRec[DBClientesSociosDicInfo.BairroSocio]?.ToString() ?? string.Empty; m_FBairroSocio = dbRec[DBClientesSociosDicInfo.BairroSocio]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FBairroSocio = dbRec[DBClientesSociosDicInfo.BairroSocio]?.ToString() ?? string.Empty; } catch { }

#else
        m_FBairroSocio = dbRec[DBClientesSociosDicInfo.BairroSocio]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCEPSocio = dbRec[DBClientesSociosDicInfo.CEPSocio]?.ToString() ?? string.Empty; m_FCEPSocio = dbRec[DBClientesSociosDicInfo.CEPSocio]?.ToString() ?? string.Empty;  } catch {}  try { m_FCEPSocio = dbRec[DBClientesSociosDicInfo.CEPSocio]?.ToString() ?? string.Empty; m_FCEPSocio = dbRec[DBClientesSociosDicInfo.CEPSocio]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCEPSocio = dbRec[DBClientesSociosDicInfo.CEPSocio]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCEPSocio = dbRec[DBClientesSociosDicInfo.CEPSocio]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.CidadeSocio])) m_FCidadeSocio = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.CidadeSocio]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.CidadeSocio])) m_FCidadeSocio = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.CidadeSocio]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.CidadeSocio])) m_FCidadeSocio = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.CidadeSocio]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.CidadeSocio])) m_FCidadeSocio = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.CidadeSocio]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.CidadeSocio])) m_FCidadeSocio = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.CidadeSocio]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.CidadeSocio]))
            m_FCidadeSocio = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.CidadeSocio]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.RGDataExp])) m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.RGDataExp]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.RGDataExp])) m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.RGDataExp]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.RGDataExp])) m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.RGDataExp]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.RGDataExp])) m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.RGDataExp]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.RGDataExp])) m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.RGDataExp]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.RGDataExp]))
            m_FRGDataExp = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.RGDataExp]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente])) m_FSocioEmpresaAdminSomente = (bool)dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente])) m_FSocioEmpresaAdminSomente = (bool)dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente])) m_FSocioEmpresaAdminSomente = (bool)dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente])) m_FSocioEmpresaAdminSomente = (bool)dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente])) m_FSocioEmpresaAdminSomente = (bool)dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente]))
            m_FSocioEmpresaAdminSomente = (bool)dbRec[DBClientesSociosDicInfo.SocioEmpresaAdminSomente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBClientesSociosDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBClientesSociosDicInfo.Tipo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBClientesSociosDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBClientesSociosDicInfo.Tipo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBClientesSociosDicInfo.Tipo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Tipo]))
            m_FTipo = (bool)dbRec[DBClientesSociosDicInfo.Tipo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBClientesSociosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBClientesSociosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBClientesSociosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBClientesSociosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBClientesSociosDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBClientesSociosDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FClass = dbRec[DBClientesSociosDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBClientesSociosDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FClass = dbRec[DBClientesSociosDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBClientesSociosDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FClass = dbRec[DBClientesSociosDicInfo.Class]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FClass = dbRec[DBClientesSociosDicInfo.Class]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBClientesSociosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBClientesSociosDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBClientesSociosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBClientesSociosDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBClientesSociosDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBClientesSociosDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Ani])) m_FAni = (bool)dbRec[DBClientesSociosDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Ani])) m_FAni = (bool)dbRec[DBClientesSociosDicInfo.Ani];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Ani])) m_FAni = (bool)dbRec[DBClientesSociosDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Ani])) m_FAni = (bool)dbRec[DBClientesSociosDicInfo.Ani];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Ani])) m_FAni = (bool)dbRec[DBClientesSociosDicInfo.Ani]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Ani]))
            m_FAni = (bool)dbRec[DBClientesSociosDicInfo.Ani];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Bold])) m_FBold = (bool)dbRec[DBClientesSociosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Bold])) m_FBold = (bool)dbRec[DBClientesSociosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Bold])) m_FBold = (bool)dbRec[DBClientesSociosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Bold])) m_FBold = (bool)dbRec[DBClientesSociosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Bold])) m_FBold = (bool)dbRec[DBClientesSociosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBClientesSociosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBClientesSociosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBClientesSociosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBClientesSociosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBClientesSociosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBClientesSociosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBClientesSociosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBClientesSociosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBClientesSociosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBClientesSociosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBClientesSociosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBClientesSociosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBClientesSociosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBClientesSociosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBClientesSociosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBClientesSociosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}