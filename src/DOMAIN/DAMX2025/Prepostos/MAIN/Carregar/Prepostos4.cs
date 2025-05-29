namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPrepostos
{
    public DBPrepostos(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Ani]))
                m_FAni = (bool)dbRec[DBPrepostosDicInfo.Ani];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBPrepostosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.CTPSDtEmissao]))
                m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.CTPSDtEmissao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtNasc]))
                m_FDtNasc = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtNasc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBPrepostosDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Funcao]))
                m_FFuncao = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Funcao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Idade]))
                m_FIdade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Idade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.LiberaAgenda]))
                m_FLiberaAgenda = (bool)dbRec[DBPrepostosDicInfo.LiberaAgenda];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Fim]))
                m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Fim]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Ini]))
                m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Ini]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Salario]))
                m_FSalario = Convert.ToDecimal(dbRec[DBPrepostosDicInfo.Salario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Setor]))
                m_FSetor = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Setor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBPrepostosDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBPrepostosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FCTPSNumero = dbRec[DBPrepostosDicInfo.CTPSNumero]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCTPSSerie = dbRec[DBPrepostosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBPrepostosDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBPrepostosDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBPrepostosDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBPrepostosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FMae = dbRec[DBPrepostosDicInfo.Mae]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBPrepostosDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPai = dbRec[DBPrepostosDicInfo.Pai]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPIS = dbRec[DBPrepostosDicInfo.PIS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FQualificacao = dbRec[DBPrepostosDicInfo.Qualificacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRegistro = dbRec[DBPrepostosDicInfo.Registro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBPrepostosDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBPrepostosDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBPrepostosDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FClass = dbRec[DBPrepostosDicInfo.Class]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBPrepostosDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBPrepostosDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBPrepostosDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBPrepostos(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Ani]))
                m_FAni = (bool)dbRec[DBPrepostosDicInfo.Ani];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBPrepostosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.CTPSDtEmissao]))
                m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.CTPSDtEmissao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtNasc]))
                m_FDtNasc = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtNasc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBPrepostosDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Funcao]))
                m_FFuncao = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Funcao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Idade]))
                m_FIdade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Idade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.LiberaAgenda]))
                m_FLiberaAgenda = (bool)dbRec[DBPrepostosDicInfo.LiberaAgenda];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Fim]))
                m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Fim]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Ini]))
                m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Ini]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Salario]))
                m_FSalario = Convert.ToDecimal(dbRec[DBPrepostosDicInfo.Salario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Setor]))
                m_FSetor = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Setor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBPrepostosDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBPrepostosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FCTPSNumero = dbRec[DBPrepostosDicInfo.CTPSNumero]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCTPSSerie = dbRec[DBPrepostosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBPrepostosDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBPrepostosDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBPrepostosDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBPrepostosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FMae = dbRec[DBPrepostosDicInfo.Mae]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBPrepostosDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPai = dbRec[DBPrepostosDicInfo.Pai]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPIS = dbRec[DBPrepostosDicInfo.PIS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FQualificacao = dbRec[DBPrepostosDicInfo.Qualificacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRegistro = dbRec[DBPrepostosDicInfo.Registro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBPrepostosDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBPrepostosDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBPrepostosDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FClass = dbRec[DBPrepostosDicInfo.Class]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBPrepostosDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBPrepostosDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBPrepostosDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Prepostos
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [preCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
sex.m_FNome = dbRec[DBPrepostosDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBPrepostosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBPrepostosDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBPrepostosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBPrepostosDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBPrepostosDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Funcao])) m_FFuncao = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Funcao]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Funcao])) m_FFuncao = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Funcao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Funcao])) m_FFuncao = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Funcao]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Funcao])) m_FFuncao = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Funcao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Funcao])) m_FFuncao = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Funcao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Funcao]))
            m_FFuncao = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Funcao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Setor])) m_FSetor = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Setor]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Setor])) m_FSetor = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Setor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Setor])) m_FSetor = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Setor]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Setor])) m_FSetor = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Setor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Setor])) m_FSetor = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Setor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Setor]))
            m_FSetor = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Setor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtNasc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtNasc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtNasc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtNasc]))
            m_FDtNasc = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtNasc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FQualificacao = dbRec[DBPrepostosDicInfo.Qualificacao]?.ToString() ?? string.Empty; m_FQualificacao = dbRec[DBPrepostosDicInfo.Qualificacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FQualificacao = dbRec[DBPrepostosDicInfo.Qualificacao]?.ToString() ?? string.Empty; m_FQualificacao = dbRec[DBPrepostosDicInfo.Qualificacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FQualificacao = dbRec[DBPrepostosDicInfo.Qualificacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FQualificacao = dbRec[DBPrepostosDicInfo.Qualificacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBPrepostosDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBPrepostosDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBPrepostosDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBPrepostosDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBPrepostosDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBPrepostosDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Idade]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Idade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Idade]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Idade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Idade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Idade]))
            m_FIdade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Idade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBPrepostosDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBPrepostosDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBPrepostosDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBPrepostosDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBPrepostosDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBPrepostosDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBPrepostosDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBPrepostosDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBPrepostosDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBPrepostosDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBPrepostosDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBPrepostosDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Ini])) m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Ini]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Ini])) m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Ini]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Ini])) m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Ini]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Ini])) m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Ini]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Ini])) m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Ini]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Ini]))
            m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Ini]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Fim])) m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Fim]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Fim])) m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Fim]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Fim])) m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Fim]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Fim])) m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Fim]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Fim])) m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Fim]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Fim]))
            m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Fim]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRegistro = dbRec[DBPrepostosDicInfo.Registro]?.ToString() ?? string.Empty; m_FRegistro = dbRec[DBPrepostosDicInfo.Registro]?.ToString() ?? string.Empty;  } catch {}  try { m_FRegistro = dbRec[DBPrepostosDicInfo.Registro]?.ToString() ?? string.Empty; m_FRegistro = dbRec[DBPrepostosDicInfo.Registro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRegistro = dbRec[DBPrepostosDicInfo.Registro]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRegistro = dbRec[DBPrepostosDicInfo.Registro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCTPSNumero = dbRec[DBPrepostosDicInfo.CTPSNumero]?.ToString() ?? string.Empty; m_FCTPSNumero = dbRec[DBPrepostosDicInfo.CTPSNumero]?.ToString() ?? string.Empty;  } catch {}  try { m_FCTPSNumero = dbRec[DBPrepostosDicInfo.CTPSNumero]?.ToString() ?? string.Empty; m_FCTPSNumero = dbRec[DBPrepostosDicInfo.CTPSNumero]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCTPSNumero = dbRec[DBPrepostosDicInfo.CTPSNumero]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCTPSNumero = dbRec[DBPrepostosDicInfo.CTPSNumero]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCTPSSerie = dbRec[DBPrepostosDicInfo.CTPSSerie]?.ToString() ?? string.Empty; m_FCTPSSerie = dbRec[DBPrepostosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;  } catch {}  try { m_FCTPSSerie = dbRec[DBPrepostosDicInfo.CTPSSerie]?.ToString() ?? string.Empty; m_FCTPSSerie = dbRec[DBPrepostosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCTPSSerie = dbRec[DBPrepostosDicInfo.CTPSSerie]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCTPSSerie = dbRec[DBPrepostosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.CTPSDtEmissao])) m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.CTPSDtEmissao]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.CTPSDtEmissao])) m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.CTPSDtEmissao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.CTPSDtEmissao])) m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.CTPSDtEmissao]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.CTPSDtEmissao])) m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.CTPSDtEmissao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.CTPSDtEmissao])) m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.CTPSDtEmissao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.CTPSDtEmissao]))
            m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.CTPSDtEmissao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPIS = dbRec[DBPrepostosDicInfo.PIS]?.ToString() ?? string.Empty; m_FPIS = dbRec[DBPrepostosDicInfo.PIS]?.ToString() ?? string.Empty;  } catch {}  try { m_FPIS = dbRec[DBPrepostosDicInfo.PIS]?.ToString() ?? string.Empty; m_FPIS = dbRec[DBPrepostosDicInfo.PIS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPIS = dbRec[DBPrepostosDicInfo.PIS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPIS = dbRec[DBPrepostosDicInfo.PIS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBPrepostosDicInfo.Salario]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBPrepostosDicInfo.Salario]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBPrepostosDicInfo.Salario]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBPrepostosDicInfo.Salario]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBPrepostosDicInfo.Salario]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Salario]))
            m_FSalario = Convert.ToDecimal(dbRec[DBPrepostosDicInfo.Salario]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.LiberaAgenda])) m_FLiberaAgenda = (bool)dbRec[DBPrepostosDicInfo.LiberaAgenda]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.LiberaAgenda])) m_FLiberaAgenda = (bool)dbRec[DBPrepostosDicInfo.LiberaAgenda];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.LiberaAgenda])) m_FLiberaAgenda = (bool)dbRec[DBPrepostosDicInfo.LiberaAgenda]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.LiberaAgenda])) m_FLiberaAgenda = (bool)dbRec[DBPrepostosDicInfo.LiberaAgenda];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.LiberaAgenda])) m_FLiberaAgenda = (bool)dbRec[DBPrepostosDicInfo.LiberaAgenda]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.LiberaAgenda]))
            m_FLiberaAgenda = (bool)dbRec[DBPrepostosDicInfo.LiberaAgenda];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBPrepostosDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBPrepostosDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBPrepostosDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBPrepostosDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBPrepostosDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBPrepostosDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBPrepostosDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBPrepostosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBPrepostosDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBPrepostosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBPrepostosDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBPrepostosDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBPrepostosDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBPrepostosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBPrepostosDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBPrepostosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBPrepostosDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBPrepostosDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBPrepostosDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBPrepostosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBPrepostosDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBPrepostosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBPrepostosDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBPrepostosDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBPrepostosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBPrepostosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBPrepostosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBPrepostosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBPrepostosDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBPrepostosDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBPrepostosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBPrepostosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBPrepostosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBPrepostosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBPrepostosDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBPrepostosDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBPrepostosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBPrepostosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBPrepostosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBPrepostosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBPrepostosDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBPrepostosDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPai = dbRec[DBPrepostosDicInfo.Pai]?.ToString() ?? string.Empty; m_FPai = dbRec[DBPrepostosDicInfo.Pai]?.ToString() ?? string.Empty;  } catch {}  try { m_FPai = dbRec[DBPrepostosDicInfo.Pai]?.ToString() ?? string.Empty; m_FPai = dbRec[DBPrepostosDicInfo.Pai]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPai = dbRec[DBPrepostosDicInfo.Pai]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPai = dbRec[DBPrepostosDicInfo.Pai]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FMae = dbRec[DBPrepostosDicInfo.Mae]?.ToString() ?? string.Empty; m_FMae = dbRec[DBPrepostosDicInfo.Mae]?.ToString() ?? string.Empty;  } catch {}  try { m_FMae = dbRec[DBPrepostosDicInfo.Mae]?.ToString() ?? string.Empty; m_FMae = dbRec[DBPrepostosDicInfo.Mae]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FMae = dbRec[DBPrepostosDicInfo.Mae]?.ToString() ?? string.Empty; } catch { }

#else
        m_FMae = dbRec[DBPrepostosDicInfo.Mae]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FClass = dbRec[DBPrepostosDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBPrepostosDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FClass = dbRec[DBPrepostosDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBPrepostosDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FClass = dbRec[DBPrepostosDicInfo.Class]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FClass = dbRec[DBPrepostosDicInfo.Class]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBPrepostosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBPrepostosDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBPrepostosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBPrepostosDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBPrepostosDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBPrepostosDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Ani])) m_FAni = (bool)dbRec[DBPrepostosDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Ani])) m_FAni = (bool)dbRec[DBPrepostosDicInfo.Ani];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Ani])) m_FAni = (bool)dbRec[DBPrepostosDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Ani])) m_FAni = (bool)dbRec[DBPrepostosDicInfo.Ani];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Ani])) m_FAni = (bool)dbRec[DBPrepostosDicInfo.Ani]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Ani]))
            m_FAni = (bool)dbRec[DBPrepostosDicInfo.Ani];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Bold])) m_FBold = (bool)dbRec[DBPrepostosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Bold])) m_FBold = (bool)dbRec[DBPrepostosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Bold])) m_FBold = (bool)dbRec[DBPrepostosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Bold])) m_FBold = (bool)dbRec[DBPrepostosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Bold])) m_FBold = (bool)dbRec[DBPrepostosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBPrepostosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBPrepostosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPrepostosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBPrepostosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPrepostosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBPrepostosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBPrepostosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPrepostosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPrepostosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPrepostosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPrepostosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPrepostosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBPrepostosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Prepostos
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
sex.m_FNome = dbRec[DBPrepostosDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBPrepostosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBPrepostosDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBPrepostosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBPrepostosDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBPrepostosDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Funcao])) m_FFuncao = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Funcao]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Funcao])) m_FFuncao = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Funcao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Funcao])) m_FFuncao = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Funcao]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Funcao])) m_FFuncao = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Funcao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Funcao])) m_FFuncao = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Funcao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Funcao]))
            m_FFuncao = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Funcao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Setor])) m_FSetor = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Setor]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Setor])) m_FSetor = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Setor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Setor])) m_FSetor = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Setor]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Setor])) m_FSetor = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Setor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Setor])) m_FSetor = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Setor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Setor]))
            m_FSetor = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Setor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtNasc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtNasc]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtNasc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtNasc])) m_FDtNasc = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtNasc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtNasc]))
            m_FDtNasc = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtNasc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FQualificacao = dbRec[DBPrepostosDicInfo.Qualificacao]?.ToString() ?? string.Empty; m_FQualificacao = dbRec[DBPrepostosDicInfo.Qualificacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FQualificacao = dbRec[DBPrepostosDicInfo.Qualificacao]?.ToString() ?? string.Empty; m_FQualificacao = dbRec[DBPrepostosDicInfo.Qualificacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FQualificacao = dbRec[DBPrepostosDicInfo.Qualificacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FQualificacao = dbRec[DBPrepostosDicInfo.Qualificacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBPrepostosDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBPrepostosDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBPrepostosDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBPrepostosDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBPrepostosDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBPrepostosDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Idade]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Idade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Idade]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Idade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Idade])) m_FIdade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Idade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Idade]))
            m_FIdade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Idade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBPrepostosDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBPrepostosDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBPrepostosDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBPrepostosDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBPrepostosDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBPrepostosDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBPrepostosDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBPrepostosDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBPrepostosDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBPrepostosDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBPrepostosDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBPrepostosDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Ini])) m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Ini]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Ini])) m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Ini]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Ini])) m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Ini]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Ini])) m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Ini]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Ini])) m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Ini]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Ini]))
            m_FPeriodo_Ini = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Ini]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Fim])) m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Fim]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Fim])) m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Fim]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Fim])) m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Fim]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Fim])) m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Fim]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Fim])) m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Fim]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Periodo_Fim]))
            m_FPeriodo_Fim = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.Periodo_Fim]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRegistro = dbRec[DBPrepostosDicInfo.Registro]?.ToString() ?? string.Empty; m_FRegistro = dbRec[DBPrepostosDicInfo.Registro]?.ToString() ?? string.Empty;  } catch {}  try { m_FRegistro = dbRec[DBPrepostosDicInfo.Registro]?.ToString() ?? string.Empty; m_FRegistro = dbRec[DBPrepostosDicInfo.Registro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRegistro = dbRec[DBPrepostosDicInfo.Registro]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRegistro = dbRec[DBPrepostosDicInfo.Registro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCTPSNumero = dbRec[DBPrepostosDicInfo.CTPSNumero]?.ToString() ?? string.Empty; m_FCTPSNumero = dbRec[DBPrepostosDicInfo.CTPSNumero]?.ToString() ?? string.Empty;  } catch {}  try { m_FCTPSNumero = dbRec[DBPrepostosDicInfo.CTPSNumero]?.ToString() ?? string.Empty; m_FCTPSNumero = dbRec[DBPrepostosDicInfo.CTPSNumero]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCTPSNumero = dbRec[DBPrepostosDicInfo.CTPSNumero]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCTPSNumero = dbRec[DBPrepostosDicInfo.CTPSNumero]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCTPSSerie = dbRec[DBPrepostosDicInfo.CTPSSerie]?.ToString() ?? string.Empty; m_FCTPSSerie = dbRec[DBPrepostosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;  } catch {}  try { m_FCTPSSerie = dbRec[DBPrepostosDicInfo.CTPSSerie]?.ToString() ?? string.Empty; m_FCTPSSerie = dbRec[DBPrepostosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCTPSSerie = dbRec[DBPrepostosDicInfo.CTPSSerie]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCTPSSerie = dbRec[DBPrepostosDicInfo.CTPSSerie]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.CTPSDtEmissao])) m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.CTPSDtEmissao]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.CTPSDtEmissao])) m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.CTPSDtEmissao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.CTPSDtEmissao])) m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.CTPSDtEmissao]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.CTPSDtEmissao])) m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.CTPSDtEmissao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.CTPSDtEmissao])) m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.CTPSDtEmissao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.CTPSDtEmissao]))
            m_FCTPSDtEmissao = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.CTPSDtEmissao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPIS = dbRec[DBPrepostosDicInfo.PIS]?.ToString() ?? string.Empty; m_FPIS = dbRec[DBPrepostosDicInfo.PIS]?.ToString() ?? string.Empty;  } catch {}  try { m_FPIS = dbRec[DBPrepostosDicInfo.PIS]?.ToString() ?? string.Empty; m_FPIS = dbRec[DBPrepostosDicInfo.PIS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPIS = dbRec[DBPrepostosDicInfo.PIS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPIS = dbRec[DBPrepostosDicInfo.PIS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBPrepostosDicInfo.Salario]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBPrepostosDicInfo.Salario]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBPrepostosDicInfo.Salario]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBPrepostosDicInfo.Salario]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Salario])) m_FSalario = Convert.ToDecimal(dbRec[DBPrepostosDicInfo.Salario]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Salario]))
            m_FSalario = Convert.ToDecimal(dbRec[DBPrepostosDicInfo.Salario]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.LiberaAgenda])) m_FLiberaAgenda = (bool)dbRec[DBPrepostosDicInfo.LiberaAgenda]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.LiberaAgenda])) m_FLiberaAgenda = (bool)dbRec[DBPrepostosDicInfo.LiberaAgenda];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.LiberaAgenda])) m_FLiberaAgenda = (bool)dbRec[DBPrepostosDicInfo.LiberaAgenda]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.LiberaAgenda])) m_FLiberaAgenda = (bool)dbRec[DBPrepostosDicInfo.LiberaAgenda];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.LiberaAgenda])) m_FLiberaAgenda = (bool)dbRec[DBPrepostosDicInfo.LiberaAgenda]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.LiberaAgenda]))
            m_FLiberaAgenda = (bool)dbRec[DBPrepostosDicInfo.LiberaAgenda];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBPrepostosDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBPrepostosDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBPrepostosDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBPrepostosDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBPrepostosDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBPrepostosDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBPrepostosDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBPrepostosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBPrepostosDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBPrepostosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBPrepostosDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBPrepostosDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBPrepostosDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBPrepostosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBPrepostosDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBPrepostosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBPrepostosDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBPrepostosDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBPrepostosDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBPrepostosDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBPrepostosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBPrepostosDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBPrepostosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBPrepostosDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBPrepostosDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBPrepostosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBPrepostosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBPrepostosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBPrepostosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBPrepostosDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBPrepostosDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBPrepostosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBPrepostosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBPrepostosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBPrepostosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBPrepostosDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBPrepostosDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBPrepostosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBPrepostosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBPrepostosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBPrepostosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBPrepostosDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBPrepostosDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPai = dbRec[DBPrepostosDicInfo.Pai]?.ToString() ?? string.Empty; m_FPai = dbRec[DBPrepostosDicInfo.Pai]?.ToString() ?? string.Empty;  } catch {}  try { m_FPai = dbRec[DBPrepostosDicInfo.Pai]?.ToString() ?? string.Empty; m_FPai = dbRec[DBPrepostosDicInfo.Pai]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPai = dbRec[DBPrepostosDicInfo.Pai]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPai = dbRec[DBPrepostosDicInfo.Pai]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FMae = dbRec[DBPrepostosDicInfo.Mae]?.ToString() ?? string.Empty; m_FMae = dbRec[DBPrepostosDicInfo.Mae]?.ToString() ?? string.Empty;  } catch {}  try { m_FMae = dbRec[DBPrepostosDicInfo.Mae]?.ToString() ?? string.Empty; m_FMae = dbRec[DBPrepostosDicInfo.Mae]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FMae = dbRec[DBPrepostosDicInfo.Mae]?.ToString() ?? string.Empty; } catch { }

#else
        m_FMae = dbRec[DBPrepostosDicInfo.Mae]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FClass = dbRec[DBPrepostosDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBPrepostosDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FClass = dbRec[DBPrepostosDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBPrepostosDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FClass = dbRec[DBPrepostosDicInfo.Class]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FClass = dbRec[DBPrepostosDicInfo.Class]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBPrepostosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBPrepostosDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBPrepostosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBPrepostosDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBPrepostosDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBPrepostosDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Ani])) m_FAni = (bool)dbRec[DBPrepostosDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Ani])) m_FAni = (bool)dbRec[DBPrepostosDicInfo.Ani];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Ani])) m_FAni = (bool)dbRec[DBPrepostosDicInfo.Ani]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Ani])) m_FAni = (bool)dbRec[DBPrepostosDicInfo.Ani];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Ani])) m_FAni = (bool)dbRec[DBPrepostosDicInfo.Ani]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Ani]))
            m_FAni = (bool)dbRec[DBPrepostosDicInfo.Ani];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Bold])) m_FBold = (bool)dbRec[DBPrepostosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Bold])) m_FBold = (bool)dbRec[DBPrepostosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Bold])) m_FBold = (bool)dbRec[DBPrepostosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Bold])) m_FBold = (bool)dbRec[DBPrepostosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Bold])) m_FBold = (bool)dbRec[DBPrepostosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBPrepostosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBPrepostosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPrepostosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBPrepostosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPrepostosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBPrepostosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBPrepostosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBPrepostosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBPrepostosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPrepostosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPrepostosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPrepostosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPrepostosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPrepostosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPrepostosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBPrepostosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}