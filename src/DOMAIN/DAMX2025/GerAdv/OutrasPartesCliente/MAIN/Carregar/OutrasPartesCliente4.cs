namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOutrasPartesCliente
{
    public DBOutrasPartesCliente(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Ani]))
                m_FAni = (bool)dbRec[DBOutrasPartesClienteDicInfo.Ani];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBOutrasPartesClienteDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal]))
                m_FClientePrincipal = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtNasc]))
                m_FDtNasc = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtNasc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBOutrasPartesClienteDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Terceirizado]))
                m_FTerceirizado = (bool)dbRec[DBOutrasPartesClienteDicInfo.Terceirizado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Tipo]))
                m_FTipo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Tipo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOutrasPartesClienteDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FCNPJ = dbRec[DBOutrasPartesClienteDicInfo.CNPJ]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBOutrasPartesClienteDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBOutrasPartesClienteDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBOutrasPartesClienteDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBOutrasPartesClienteDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FInscEst = dbRec[DBOutrasPartesClienteDicInfo.InscEst]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeFantasia = dbRec[DBOutrasPartesClienteDicInfo.NomeFantasia]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBOutrasPartesClienteDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSite = dbRec[DBOutrasPartesClienteDicInfo.Site]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBOutrasPartesClienteDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBOutrasPartesClienteDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FClass = dbRec[DBOutrasPartesClienteDicInfo.Class]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBOutrasPartesClienteDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBOutrasPartesClienteDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBOutrasPartesClienteDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBOutrasPartesCliente(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Ani]))
                m_FAni = (bool)dbRec[DBOutrasPartesClienteDicInfo.Ani];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBOutrasPartesClienteDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal]))
                m_FClientePrincipal = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtNasc]))
                m_FDtNasc = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtNasc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBOutrasPartesClienteDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Terceirizado]))
                m_FTerceirizado = (bool)dbRec[DBOutrasPartesClienteDicInfo.Terceirizado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Tipo]))
                m_FTipo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Tipo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOutrasPartesClienteDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FCNPJ = dbRec[DBOutrasPartesClienteDicInfo.CNPJ]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBOutrasPartesClienteDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBOutrasPartesClienteDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBOutrasPartesClienteDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBOutrasPartesClienteDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FInscEst = dbRec[DBOutrasPartesClienteDicInfo.InscEst]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNomeFantasia = dbRec[DBOutrasPartesClienteDicInfo.NomeFantasia]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBOutrasPartesClienteDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSite = dbRec[DBOutrasPartesClienteDicInfo.Site]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBOutrasPartesClienteDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBOutrasPartesClienteDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FClass = dbRec[DBOutrasPartesClienteDicInfo.Class]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBOutrasPartesClienteDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBOutrasPartesClienteDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBOutrasPartesClienteDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_OutrasPartesCliente
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [opcCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
sex.m_FNome = dbRec[DBOutrasPartesClienteDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBOutrasPartesClienteDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBOutrasPartesClienteDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBOutrasPartesClienteDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBOutrasPartesClienteDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBOutrasPartesClienteDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Terceirizado])) m_FTerceirizado = (bool)dbRec[DBOutrasPartesClienteDicInfo.Terceirizado]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Terceirizado])) m_FTerceirizado = (bool)dbRec[DBOutrasPartesClienteDicInfo.Terceirizado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Terceirizado])) m_FTerceirizado = (bool)dbRec[DBOutrasPartesClienteDicInfo.Terceirizado]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Terceirizado])) m_FTerceirizado = (bool)dbRec[DBOutrasPartesClienteDicInfo.Terceirizado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Terceirizado])) m_FTerceirizado = (bool)dbRec[DBOutrasPartesClienteDicInfo.Terceirizado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Terceirizado]))
            m_FTerceirizado = (bool)dbRec[DBOutrasPartesClienteDicInfo.Terceirizado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal])) m_FClientePrincipal = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal])) m_FClientePrincipal = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal])) m_FClientePrincipal = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal])) m_FClientePrincipal = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal])) m_FClientePrincipal = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal]))
            m_FClientePrincipal = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Tipo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Tipo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Tipo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Tipo]))
            m_FTipo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Tipo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtNasc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtNasc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtNasc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtNasc]))
            m_FDtNasc = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtNasc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBOutrasPartesClienteDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBOutrasPartesClienteDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBOutrasPartesClienteDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBOutrasPartesClienteDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBOutrasPartesClienteDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBOutrasPartesClienteDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBOutrasPartesClienteDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBOutrasPartesClienteDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBOutrasPartesClienteDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBOutrasPartesClienteDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBOutrasPartesClienteDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBOutrasPartesClienteDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCNPJ = dbRec[DBOutrasPartesClienteDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBOutrasPartesClienteDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNPJ = dbRec[DBOutrasPartesClienteDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBOutrasPartesClienteDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNPJ = dbRec[DBOutrasPartesClienteDicInfo.CNPJ]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNPJ = dbRec[DBOutrasPartesClienteDicInfo.CNPJ]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FInscEst = dbRec[DBOutrasPartesClienteDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBOutrasPartesClienteDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { m_FInscEst = dbRec[DBOutrasPartesClienteDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBOutrasPartesClienteDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FInscEst = dbRec[DBOutrasPartesClienteDicInfo.InscEst]?.ToString() ?? string.Empty; } catch { }

#else
        m_FInscEst = dbRec[DBOutrasPartesClienteDicInfo.InscEst]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeFantasia = dbRec[DBOutrasPartesClienteDicInfo.NomeFantasia]?.ToString() ?? string.Empty; m_FNomeFantasia = dbRec[DBOutrasPartesClienteDicInfo.NomeFantasia]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeFantasia = dbRec[DBOutrasPartesClienteDicInfo.NomeFantasia]?.ToString() ?? string.Empty; m_FNomeFantasia = dbRec[DBOutrasPartesClienteDicInfo.NomeFantasia]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeFantasia = dbRec[DBOutrasPartesClienteDicInfo.NomeFantasia]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeFantasia = dbRec[DBOutrasPartesClienteDicInfo.NomeFantasia]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBOutrasPartesClienteDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBOutrasPartesClienteDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBOutrasPartesClienteDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBOutrasPartesClienteDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBOutrasPartesClienteDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBOutrasPartesClienteDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBOutrasPartesClienteDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBOutrasPartesClienteDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBOutrasPartesClienteDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBOutrasPartesClienteDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBOutrasPartesClienteDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBOutrasPartesClienteDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBOutrasPartesClienteDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBOutrasPartesClienteDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBOutrasPartesClienteDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBOutrasPartesClienteDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBOutrasPartesClienteDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBOutrasPartesClienteDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBOutrasPartesClienteDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBOutrasPartesClienteDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBOutrasPartesClienteDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBOutrasPartesClienteDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBOutrasPartesClienteDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBOutrasPartesClienteDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBOutrasPartesClienteDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBOutrasPartesClienteDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBOutrasPartesClienteDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBOutrasPartesClienteDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBOutrasPartesClienteDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBOutrasPartesClienteDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBOutrasPartesClienteDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBOutrasPartesClienteDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBOutrasPartesClienteDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBOutrasPartesClienteDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBOutrasPartesClienteDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBOutrasPartesClienteDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSite = dbRec[DBOutrasPartesClienteDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBOutrasPartesClienteDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { m_FSite = dbRec[DBOutrasPartesClienteDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBOutrasPartesClienteDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSite = dbRec[DBOutrasPartesClienteDicInfo.Site]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSite = dbRec[DBOutrasPartesClienteDicInfo.Site]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FClass = dbRec[DBOutrasPartesClienteDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBOutrasPartesClienteDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FClass = dbRec[DBOutrasPartesClienteDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBOutrasPartesClienteDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FClass = dbRec[DBOutrasPartesClienteDicInfo.Class]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FClass = dbRec[DBOutrasPartesClienteDicInfo.Class]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBOutrasPartesClienteDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBOutrasPartesClienteDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBOutrasPartesClienteDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBOutrasPartesClienteDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBOutrasPartesClienteDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBOutrasPartesClienteDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Ani])) m_FAni = (bool)dbRec[DBOutrasPartesClienteDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Ani])) m_FAni = (bool)dbRec[DBOutrasPartesClienteDicInfo.Ani];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Ani])) m_FAni = (bool)dbRec[DBOutrasPartesClienteDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Ani])) m_FAni = (bool)dbRec[DBOutrasPartesClienteDicInfo.Ani];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Ani])) m_FAni = (bool)dbRec[DBOutrasPartesClienteDicInfo.Ani]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Ani]))
            m_FAni = (bool)dbRec[DBOutrasPartesClienteDicInfo.Ani];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Bold])) m_FBold = (bool)dbRec[DBOutrasPartesClienteDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Bold])) m_FBold = (bool)dbRec[DBOutrasPartesClienteDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Bold])) m_FBold = (bool)dbRec[DBOutrasPartesClienteDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Bold])) m_FBold = (bool)dbRec[DBOutrasPartesClienteDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Bold])) m_FBold = (bool)dbRec[DBOutrasPartesClienteDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBOutrasPartesClienteDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBOutrasPartesClienteDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOutrasPartesClienteDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBOutrasPartesClienteDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOutrasPartesClienteDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBOutrasPartesClienteDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBOutrasPartesClienteDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOutrasPartesClienteDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOutrasPartesClienteDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOutrasPartesClienteDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOutrasPartesClienteDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOutrasPartesClienteDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBOutrasPartesClienteDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_OutrasPartesCliente
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
sex.m_FNome = dbRec[DBOutrasPartesClienteDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBOutrasPartesClienteDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBOutrasPartesClienteDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBOutrasPartesClienteDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBOutrasPartesClienteDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBOutrasPartesClienteDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Terceirizado])) m_FTerceirizado = (bool)dbRec[DBOutrasPartesClienteDicInfo.Terceirizado]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Terceirizado])) m_FTerceirizado = (bool)dbRec[DBOutrasPartesClienteDicInfo.Terceirizado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Terceirizado])) m_FTerceirizado = (bool)dbRec[DBOutrasPartesClienteDicInfo.Terceirizado]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Terceirizado])) m_FTerceirizado = (bool)dbRec[DBOutrasPartesClienteDicInfo.Terceirizado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Terceirizado])) m_FTerceirizado = (bool)dbRec[DBOutrasPartesClienteDicInfo.Terceirizado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Terceirizado]))
            m_FTerceirizado = (bool)dbRec[DBOutrasPartesClienteDicInfo.Terceirizado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal])) m_FClientePrincipal = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal])) m_FClientePrincipal = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal])) m_FClientePrincipal = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal])) m_FClientePrincipal = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal])) m_FClientePrincipal = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal]))
            m_FClientePrincipal = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.ClientePrincipal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Tipo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Tipo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Tipo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Tipo]))
            m_FTipo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Tipo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBOutrasPartesClienteDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtNasc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtNasc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtNasc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtNasc]))
            m_FDtNasc = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtNasc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBOutrasPartesClienteDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBOutrasPartesClienteDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBOutrasPartesClienteDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBOutrasPartesClienteDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBOutrasPartesClienteDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBOutrasPartesClienteDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBOutrasPartesClienteDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBOutrasPartesClienteDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBOutrasPartesClienteDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBOutrasPartesClienteDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBOutrasPartesClienteDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBOutrasPartesClienteDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCNPJ = dbRec[DBOutrasPartesClienteDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBOutrasPartesClienteDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNPJ = dbRec[DBOutrasPartesClienteDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBOutrasPartesClienteDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNPJ = dbRec[DBOutrasPartesClienteDicInfo.CNPJ]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNPJ = dbRec[DBOutrasPartesClienteDicInfo.CNPJ]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FInscEst = dbRec[DBOutrasPartesClienteDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBOutrasPartesClienteDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { m_FInscEst = dbRec[DBOutrasPartesClienteDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBOutrasPartesClienteDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FInscEst = dbRec[DBOutrasPartesClienteDicInfo.InscEst]?.ToString() ?? string.Empty; } catch { }

#else
        m_FInscEst = dbRec[DBOutrasPartesClienteDicInfo.InscEst]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNomeFantasia = dbRec[DBOutrasPartesClienteDicInfo.NomeFantasia]?.ToString() ?? string.Empty; m_FNomeFantasia = dbRec[DBOutrasPartesClienteDicInfo.NomeFantasia]?.ToString() ?? string.Empty;  } catch {}  try { m_FNomeFantasia = dbRec[DBOutrasPartesClienteDicInfo.NomeFantasia]?.ToString() ?? string.Empty; m_FNomeFantasia = dbRec[DBOutrasPartesClienteDicInfo.NomeFantasia]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNomeFantasia = dbRec[DBOutrasPartesClienteDicInfo.NomeFantasia]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNomeFantasia = dbRec[DBOutrasPartesClienteDicInfo.NomeFantasia]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBOutrasPartesClienteDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBOutrasPartesClienteDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBOutrasPartesClienteDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBOutrasPartesClienteDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBOutrasPartesClienteDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBOutrasPartesClienteDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBOutrasPartesClienteDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBOutrasPartesClienteDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBOutrasPartesClienteDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBOutrasPartesClienteDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBOutrasPartesClienteDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBOutrasPartesClienteDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBOutrasPartesClienteDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBOutrasPartesClienteDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBOutrasPartesClienteDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBOutrasPartesClienteDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBOutrasPartesClienteDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBOutrasPartesClienteDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBOutrasPartesClienteDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBOutrasPartesClienteDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBOutrasPartesClienteDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBOutrasPartesClienteDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBOutrasPartesClienteDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBOutrasPartesClienteDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBOutrasPartesClienteDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBOutrasPartesClienteDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBOutrasPartesClienteDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBOutrasPartesClienteDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBOutrasPartesClienteDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBOutrasPartesClienteDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBOutrasPartesClienteDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBOutrasPartesClienteDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBOutrasPartesClienteDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBOutrasPartesClienteDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBOutrasPartesClienteDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBOutrasPartesClienteDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSite = dbRec[DBOutrasPartesClienteDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBOutrasPartesClienteDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { m_FSite = dbRec[DBOutrasPartesClienteDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBOutrasPartesClienteDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSite = dbRec[DBOutrasPartesClienteDicInfo.Site]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSite = dbRec[DBOutrasPartesClienteDicInfo.Site]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FClass = dbRec[DBOutrasPartesClienteDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBOutrasPartesClienteDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FClass = dbRec[DBOutrasPartesClienteDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBOutrasPartesClienteDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FClass = dbRec[DBOutrasPartesClienteDicInfo.Class]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FClass = dbRec[DBOutrasPartesClienteDicInfo.Class]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBOutrasPartesClienteDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBOutrasPartesClienteDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBOutrasPartesClienteDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBOutrasPartesClienteDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBOutrasPartesClienteDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBOutrasPartesClienteDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Ani])) m_FAni = (bool)dbRec[DBOutrasPartesClienteDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Ani])) m_FAni = (bool)dbRec[DBOutrasPartesClienteDicInfo.Ani];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Ani])) m_FAni = (bool)dbRec[DBOutrasPartesClienteDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Ani])) m_FAni = (bool)dbRec[DBOutrasPartesClienteDicInfo.Ani];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Ani])) m_FAni = (bool)dbRec[DBOutrasPartesClienteDicInfo.Ani]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Ani]))
            m_FAni = (bool)dbRec[DBOutrasPartesClienteDicInfo.Ani];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Bold])) m_FBold = (bool)dbRec[DBOutrasPartesClienteDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Bold])) m_FBold = (bool)dbRec[DBOutrasPartesClienteDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Bold])) m_FBold = (bool)dbRec[DBOutrasPartesClienteDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Bold])) m_FBold = (bool)dbRec[DBOutrasPartesClienteDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Bold])) m_FBold = (bool)dbRec[DBOutrasPartesClienteDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBOutrasPartesClienteDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBOutrasPartesClienteDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOutrasPartesClienteDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBOutrasPartesClienteDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOutrasPartesClienteDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBOutrasPartesClienteDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBOutrasPartesClienteDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBOutrasPartesClienteDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBOutrasPartesClienteDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOutrasPartesClienteDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOutrasPartesClienteDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOutrasPartesClienteDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOutrasPartesClienteDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOutrasPartesClienteDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOutrasPartesClienteDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBOutrasPartesClienteDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}