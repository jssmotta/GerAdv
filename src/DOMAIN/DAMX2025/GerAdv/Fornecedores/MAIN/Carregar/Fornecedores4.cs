namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBFornecedores
{
    public DBFornecedores(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBFornecedoresDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBFornecedoresDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Grupo]))
                m_FGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Grupo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBFornecedoresDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.SubGrupo]))
                m_FSubGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.SubGrupo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Tipo]))
                m_FTipo = (bool)dbRec[DBFornecedoresDicInfo.Tipo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBFornecedoresDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FCNPJ = dbRec[DBFornecedoresDicInfo.CNPJ]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FContatos = dbRec[DBFornecedoresDicInfo.Contatos]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEmail = dbRec[DBFornecedoresDicInfo.Email]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBFornecedoresDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBFornecedoresDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBFornecedoresDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FInscEst = dbRec[DBFornecedoresDicInfo.InscEst]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObs = dbRec[DBFornecedoresDicInfo.Obs]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FProdutos = dbRec[DBFornecedoresDicInfo.Produtos]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBFornecedoresDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSite = dbRec[DBFornecedoresDicInfo.Site]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBFornecedoresDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBFornecedoresDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBFornecedoresDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBFornecedoresDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBFornecedoresDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBFornecedores(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBFornecedoresDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBFornecedoresDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Grupo]))
                m_FGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Grupo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBFornecedoresDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.SubGrupo]))
                m_FSubGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.SubGrupo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Tipo]))
                m_FTipo = (bool)dbRec[DBFornecedoresDicInfo.Tipo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBFornecedoresDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FCNPJ = dbRec[DBFornecedoresDicInfo.CNPJ]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FContatos = dbRec[DBFornecedoresDicInfo.Contatos]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEmail = dbRec[DBFornecedoresDicInfo.Email]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBFornecedoresDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBFornecedoresDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBFornecedoresDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FInscEst = dbRec[DBFornecedoresDicInfo.InscEst]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObs = dbRec[DBFornecedoresDicInfo.Obs]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FProdutos = dbRec[DBFornecedoresDicInfo.Produtos]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBFornecedoresDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSite = dbRec[DBFornecedoresDicInfo.Site]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBFornecedoresDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBFornecedoresDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBFornecedoresDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBFornecedoresDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBFornecedoresDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Fornecedores
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [forCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Grupo]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Grupo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Grupo]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Grupo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Grupo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Grupo]))
            m_FGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Grupo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FNome = dbRec[DBFornecedoresDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBFornecedoresDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBFornecedoresDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBFornecedoresDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBFornecedoresDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBFornecedoresDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.SubGrupo])) m_FSubGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.SubGrupo]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.SubGrupo])) m_FSubGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.SubGrupo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.SubGrupo])) m_FSubGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.SubGrupo]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.SubGrupo])) m_FSubGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.SubGrupo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.SubGrupo])) m_FSubGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.SubGrupo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.SubGrupo]))
            m_FSubGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.SubGrupo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBFornecedoresDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBFornecedoresDicInfo.Tipo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBFornecedoresDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBFornecedoresDicInfo.Tipo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBFornecedoresDicInfo.Tipo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Tipo]))
            m_FTipo = (bool)dbRec[DBFornecedoresDicInfo.Tipo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBFornecedoresDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBFornecedoresDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBFornecedoresDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBFornecedoresDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBFornecedoresDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBFornecedoresDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCNPJ = dbRec[DBFornecedoresDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBFornecedoresDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNPJ = dbRec[DBFornecedoresDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBFornecedoresDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNPJ = dbRec[DBFornecedoresDicInfo.CNPJ]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNPJ = dbRec[DBFornecedoresDicInfo.CNPJ]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FInscEst = dbRec[DBFornecedoresDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBFornecedoresDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { m_FInscEst = dbRec[DBFornecedoresDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBFornecedoresDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FInscEst = dbRec[DBFornecedoresDicInfo.InscEst]?.ToString() ?? string.Empty; } catch { }

#else
        m_FInscEst = dbRec[DBFornecedoresDicInfo.InscEst]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBFornecedoresDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBFornecedoresDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBFornecedoresDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBFornecedoresDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBFornecedoresDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBFornecedoresDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBFornecedoresDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBFornecedoresDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBFornecedoresDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBFornecedoresDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBFornecedoresDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBFornecedoresDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBFornecedoresDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBFornecedoresDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBFornecedoresDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBFornecedoresDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBFornecedoresDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBFornecedoresDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBFornecedoresDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBFornecedoresDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBFornecedoresDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBFornecedoresDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBFornecedoresDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBFornecedoresDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBFornecedoresDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBFornecedoresDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBFornecedoresDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBFornecedoresDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBFornecedoresDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBFornecedoresDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBFornecedoresDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBFornecedoresDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBFornecedoresDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBFornecedoresDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBFornecedoresDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBFornecedoresDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBFornecedoresDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBFornecedoresDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBFornecedoresDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBFornecedoresDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBFornecedoresDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBFornecedoresDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEmail = dbRec[DBFornecedoresDicInfo.Email]?.ToString() ?? string.Empty; m_FEmail = dbRec[DBFornecedoresDicInfo.Email]?.ToString() ?? string.Empty;  } catch {}  try { m_FEmail = dbRec[DBFornecedoresDicInfo.Email]?.ToString() ?? string.Empty; m_FEmail = dbRec[DBFornecedoresDicInfo.Email]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEmail = dbRec[DBFornecedoresDicInfo.Email]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEmail = dbRec[DBFornecedoresDicInfo.Email]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSite = dbRec[DBFornecedoresDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBFornecedoresDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { m_FSite = dbRec[DBFornecedoresDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBFornecedoresDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSite = dbRec[DBFornecedoresDicInfo.Site]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSite = dbRec[DBFornecedoresDicInfo.Site]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObs = dbRec[DBFornecedoresDicInfo.Obs]?.ToString() ?? string.Empty; m_FObs = dbRec[DBFornecedoresDicInfo.Obs]?.ToString() ?? string.Empty;  } catch {}  try { m_FObs = dbRec[DBFornecedoresDicInfo.Obs]?.ToString() ?? string.Empty; m_FObs = dbRec[DBFornecedoresDicInfo.Obs]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObs = dbRec[DBFornecedoresDicInfo.Obs]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObs = dbRec[DBFornecedoresDicInfo.Obs]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FProdutos = dbRec[DBFornecedoresDicInfo.Produtos]?.ToString() ?? string.Empty; m_FProdutos = dbRec[DBFornecedoresDicInfo.Produtos]?.ToString() ?? string.Empty;  } catch {}  try { m_FProdutos = dbRec[DBFornecedoresDicInfo.Produtos]?.ToString() ?? string.Empty; m_FProdutos = dbRec[DBFornecedoresDicInfo.Produtos]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FProdutos = dbRec[DBFornecedoresDicInfo.Produtos]?.ToString() ?? string.Empty; } catch { }

#else
        m_FProdutos = dbRec[DBFornecedoresDicInfo.Produtos]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FContatos = dbRec[DBFornecedoresDicInfo.Contatos]?.ToString() ?? string.Empty; m_FContatos = dbRec[DBFornecedoresDicInfo.Contatos]?.ToString() ?? string.Empty;  } catch {}  try { m_FContatos = dbRec[DBFornecedoresDicInfo.Contatos]?.ToString() ?? string.Empty; m_FContatos = dbRec[DBFornecedoresDicInfo.Contatos]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FContatos = dbRec[DBFornecedoresDicInfo.Contatos]?.ToString() ?? string.Empty; } catch { }

#else
        m_FContatos = dbRec[DBFornecedoresDicInfo.Contatos]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBFornecedoresDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBFornecedoresDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBFornecedoresDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBFornecedoresDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBFornecedoresDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBFornecedoresDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBFornecedoresDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBFornecedoresDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBFornecedoresDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBFornecedoresDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBFornecedoresDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBFornecedoresDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBFornecedoresDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBFornecedoresDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBFornecedoresDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBFornecedoresDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBFornecedoresDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBFornecedoresDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFornecedoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFornecedoresDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFornecedoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFornecedoresDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFornecedoresDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBFornecedoresDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Fornecedores
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
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Grupo]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Grupo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Grupo]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Grupo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Grupo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Grupo]))
            m_FGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Grupo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FNome = dbRec[DBFornecedoresDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBFornecedoresDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBFornecedoresDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBFornecedoresDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBFornecedoresDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBFornecedoresDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.SubGrupo])) m_FSubGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.SubGrupo]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.SubGrupo])) m_FSubGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.SubGrupo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.SubGrupo])) m_FSubGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.SubGrupo]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.SubGrupo])) m_FSubGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.SubGrupo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.SubGrupo])) m_FSubGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.SubGrupo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.SubGrupo]))
            m_FSubGrupo = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.SubGrupo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBFornecedoresDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBFornecedoresDicInfo.Tipo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBFornecedoresDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBFornecedoresDicInfo.Tipo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBFornecedoresDicInfo.Tipo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Tipo]))
            m_FTipo = (bool)dbRec[DBFornecedoresDicInfo.Tipo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBFornecedoresDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBFornecedoresDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBFornecedoresDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBFornecedoresDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBFornecedoresDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBFornecedoresDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCNPJ = dbRec[DBFornecedoresDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBFornecedoresDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNPJ = dbRec[DBFornecedoresDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBFornecedoresDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNPJ = dbRec[DBFornecedoresDicInfo.CNPJ]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNPJ = dbRec[DBFornecedoresDicInfo.CNPJ]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FInscEst = dbRec[DBFornecedoresDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBFornecedoresDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { m_FInscEst = dbRec[DBFornecedoresDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBFornecedoresDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FInscEst = dbRec[DBFornecedoresDicInfo.InscEst]?.ToString() ?? string.Empty; } catch { }

#else
        m_FInscEst = dbRec[DBFornecedoresDicInfo.InscEst]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBFornecedoresDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBFornecedoresDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBFornecedoresDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBFornecedoresDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBFornecedoresDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBFornecedoresDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBFornecedoresDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBFornecedoresDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBFornecedoresDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBFornecedoresDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBFornecedoresDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBFornecedoresDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBFornecedoresDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBFornecedoresDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBFornecedoresDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBFornecedoresDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBFornecedoresDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBFornecedoresDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBFornecedoresDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBFornecedoresDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBFornecedoresDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBFornecedoresDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBFornecedoresDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBFornecedoresDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBFornecedoresDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBFornecedoresDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBFornecedoresDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBFornecedoresDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBFornecedoresDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBFornecedoresDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBFornecedoresDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBFornecedoresDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBFornecedoresDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBFornecedoresDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBFornecedoresDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBFornecedoresDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBFornecedoresDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBFornecedoresDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBFornecedoresDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBFornecedoresDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBFornecedoresDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBFornecedoresDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEmail = dbRec[DBFornecedoresDicInfo.Email]?.ToString() ?? string.Empty; m_FEmail = dbRec[DBFornecedoresDicInfo.Email]?.ToString() ?? string.Empty;  } catch {}  try { m_FEmail = dbRec[DBFornecedoresDicInfo.Email]?.ToString() ?? string.Empty; m_FEmail = dbRec[DBFornecedoresDicInfo.Email]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEmail = dbRec[DBFornecedoresDicInfo.Email]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEmail = dbRec[DBFornecedoresDicInfo.Email]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSite = dbRec[DBFornecedoresDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBFornecedoresDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { m_FSite = dbRec[DBFornecedoresDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBFornecedoresDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSite = dbRec[DBFornecedoresDicInfo.Site]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSite = dbRec[DBFornecedoresDicInfo.Site]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObs = dbRec[DBFornecedoresDicInfo.Obs]?.ToString() ?? string.Empty; m_FObs = dbRec[DBFornecedoresDicInfo.Obs]?.ToString() ?? string.Empty;  } catch {}  try { m_FObs = dbRec[DBFornecedoresDicInfo.Obs]?.ToString() ?? string.Empty; m_FObs = dbRec[DBFornecedoresDicInfo.Obs]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObs = dbRec[DBFornecedoresDicInfo.Obs]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObs = dbRec[DBFornecedoresDicInfo.Obs]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FProdutos = dbRec[DBFornecedoresDicInfo.Produtos]?.ToString() ?? string.Empty; m_FProdutos = dbRec[DBFornecedoresDicInfo.Produtos]?.ToString() ?? string.Empty;  } catch {}  try { m_FProdutos = dbRec[DBFornecedoresDicInfo.Produtos]?.ToString() ?? string.Empty; m_FProdutos = dbRec[DBFornecedoresDicInfo.Produtos]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FProdutos = dbRec[DBFornecedoresDicInfo.Produtos]?.ToString() ?? string.Empty; } catch { }

#else
        m_FProdutos = dbRec[DBFornecedoresDicInfo.Produtos]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FContatos = dbRec[DBFornecedoresDicInfo.Contatos]?.ToString() ?? string.Empty; m_FContatos = dbRec[DBFornecedoresDicInfo.Contatos]?.ToString() ?? string.Empty;  } catch {}  try { m_FContatos = dbRec[DBFornecedoresDicInfo.Contatos]?.ToString() ?? string.Empty; m_FContatos = dbRec[DBFornecedoresDicInfo.Contatos]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FContatos = dbRec[DBFornecedoresDicInfo.Contatos]?.ToString() ?? string.Empty; } catch { }

#else
        m_FContatos = dbRec[DBFornecedoresDicInfo.Contatos]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBFornecedoresDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBFornecedoresDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBFornecedoresDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBFornecedoresDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBFornecedoresDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBFornecedoresDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBFornecedoresDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBFornecedoresDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBFornecedoresDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBFornecedoresDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Bold])) m_FBold = (bool)dbRec[DBFornecedoresDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBFornecedoresDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBFornecedoresDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBFornecedoresDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBFornecedoresDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBFornecedoresDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBFornecedoresDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBFornecedoresDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBFornecedoresDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBFornecedoresDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFornecedoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFornecedoresDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFornecedoresDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFornecedoresDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Visto])) m_FVisto = (bool)dbRec[DBFornecedoresDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBFornecedoresDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBFornecedoresDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}