namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOponentes
{
    public DBOponentes(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Adv]))
                m_FAdv = Convert.ToInt32(dbRec[DBOponentesDicInfo.Adv]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBOponentesDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBOponentesDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPCliente]))
                m_FEMPCliente = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPCliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPFuncao]))
                m_FEMPFuncao = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPFuncao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBOponentesDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.IDRep]))
                m_FIDRep = Convert.ToInt32(dbRec[DBOponentesDicInfo.IDRep]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Juridica]))
                m_FJuridica = (bool)dbRec[DBOponentesDicInfo.Juridica];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBOponentesDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Tipo]))
                m_FTipo = (bool)dbRec[DBOponentesDicInfo.Tipo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Top]))
                m_FTop = (bool)dbRec[DBOponentesDicInfo.Top];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOponentesDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FCNPJ = dbRec[DBOponentesDicInfo.CNPJ]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FContato = dbRec[DBOponentesDicInfo.Contato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCTPSNumero = dbRec[DBOponentesDicInfo.CTPSNumero]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCTPSSerie = dbRec[DBOponentesDicInfo.CTPSSerie]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBOponentesDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBOponentesDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBOponentesDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBOponentesDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FInscEst = dbRec[DBOponentesDicInfo.InscEst]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBOponentesDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPIS = dbRec[DBOponentesDicInfo.PIS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBOponentesDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSite = dbRec[DBOponentesDicInfo.Site]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBOponentesDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBOponentesDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FClass = dbRec[DBOponentesDicInfo.Class]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBOponentesDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBOponentesDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBOponentesDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBOponentes(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Adv]))
                m_FAdv = Convert.ToInt32(dbRec[DBOponentesDicInfo.Adv]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBOponentesDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBOponentesDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPCliente]))
                m_FEMPCliente = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPCliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPFuncao]))
                m_FEMPFuncao = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPFuncao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBOponentesDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.IDRep]))
                m_FIDRep = Convert.ToInt32(dbRec[DBOponentesDicInfo.IDRep]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Juridica]))
                m_FJuridica = (bool)dbRec[DBOponentesDicInfo.Juridica];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Sexo]))
                m_FSexo = (bool)dbRec[DBOponentesDicInfo.Sexo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Tipo]))
                m_FTipo = (bool)dbRec[DBOponentesDicInfo.Tipo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Top]))
                m_FTop = (bool)dbRec[DBOponentesDicInfo.Top];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBOponentesDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FCNPJ = dbRec[DBOponentesDicInfo.CNPJ]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FContato = dbRec[DBOponentesDicInfo.Contato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCTPSNumero = dbRec[DBOponentesDicInfo.CTPSNumero]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCTPSSerie = dbRec[DBOponentesDicInfo.CTPSSerie]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBOponentesDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBOponentesDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBOponentesDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBOponentesDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FInscEst = dbRec[DBOponentesDicInfo.InscEst]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBOponentesDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPIS = dbRec[DBOponentesDicInfo.PIS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FRG = dbRec[DBOponentesDicInfo.RG]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSite = dbRec[DBOponentesDicInfo.Site]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FBairro = dbRec[DBOponentesDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCEP = dbRec[DBOponentesDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FClass = dbRec[DBOponentesDicInfo.Class]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FCPF = dbRec[DBOponentesDicInfo.CPF]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FEndereco = dbRec[DBOponentesDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            sex.m_FNome = dbRec[DBOponentesDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Oponentes
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [opoCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPFuncao])) m_FEMPFuncao = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPFuncao]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPFuncao])) m_FEMPFuncao = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPFuncao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPFuncao])) m_FEMPFuncao = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPFuncao]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPFuncao])) m_FEMPFuncao = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPFuncao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPFuncao])) m_FEMPFuncao = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPFuncao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPFuncao]))
            m_FEMPFuncao = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPFuncao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCTPSNumero = dbRec[DBOponentesDicInfo.CTPSNumero]?.ToString() ?? string.Empty; m_FCTPSNumero = dbRec[DBOponentesDicInfo.CTPSNumero]?.ToString() ?? string.Empty;  } catch {}  try { m_FCTPSNumero = dbRec[DBOponentesDicInfo.CTPSNumero]?.ToString() ?? string.Empty; m_FCTPSNumero = dbRec[DBOponentesDicInfo.CTPSNumero]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCTPSNumero = dbRec[DBOponentesDicInfo.CTPSNumero]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCTPSNumero = dbRec[DBOponentesDicInfo.CTPSNumero]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSite = dbRec[DBOponentesDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBOponentesDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { m_FSite = dbRec[DBOponentesDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBOponentesDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSite = dbRec[DBOponentesDicInfo.Site]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSite = dbRec[DBOponentesDicInfo.Site]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCTPSSerie = dbRec[DBOponentesDicInfo.CTPSSerie]?.ToString() ?? string.Empty; m_FCTPSSerie = dbRec[DBOponentesDicInfo.CTPSSerie]?.ToString() ?? string.Empty;  } catch {}  try { m_FCTPSSerie = dbRec[DBOponentesDicInfo.CTPSSerie]?.ToString() ?? string.Empty; m_FCTPSSerie = dbRec[DBOponentesDicInfo.CTPSSerie]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCTPSSerie = dbRec[DBOponentesDicInfo.CTPSSerie]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCTPSSerie = dbRec[DBOponentesDicInfo.CTPSSerie]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FNome = dbRec[DBOponentesDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBOponentesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBOponentesDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBOponentesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBOponentesDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBOponentesDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBOponentesDicInfo.Adv]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBOponentesDicInfo.Adv]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBOponentesDicInfo.Adv]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBOponentesDicInfo.Adv]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBOponentesDicInfo.Adv]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Adv]))
            m_FAdv = Convert.ToInt32(dbRec[DBOponentesDicInfo.Adv]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPCliente])) m_FEMPCliente = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPCliente]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPCliente])) m_FEMPCliente = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPCliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPCliente])) m_FEMPCliente = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPCliente]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPCliente])) m_FEMPCliente = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPCliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPCliente])) m_FEMPCliente = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPCliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPCliente]))
            m_FEMPCliente = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPCliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBOponentesDicInfo.IDRep]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBOponentesDicInfo.IDRep]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBOponentesDicInfo.IDRep]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBOponentesDicInfo.IDRep]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBOponentesDicInfo.IDRep]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.IDRep]))
            m_FIDRep = Convert.ToInt32(dbRec[DBOponentesDicInfo.IDRep]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPIS = dbRec[DBOponentesDicInfo.PIS]?.ToString() ?? string.Empty; m_FPIS = dbRec[DBOponentesDicInfo.PIS]?.ToString() ?? string.Empty;  } catch {}  try { m_FPIS = dbRec[DBOponentesDicInfo.PIS]?.ToString() ?? string.Empty; m_FPIS = dbRec[DBOponentesDicInfo.PIS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPIS = dbRec[DBOponentesDicInfo.PIS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPIS = dbRec[DBOponentesDicInfo.PIS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FContato = dbRec[DBOponentesDicInfo.Contato]?.ToString() ?? string.Empty; m_FContato = dbRec[DBOponentesDicInfo.Contato]?.ToString() ?? string.Empty;  } catch {}  try { m_FContato = dbRec[DBOponentesDicInfo.Contato]?.ToString() ?? string.Empty; m_FContato = dbRec[DBOponentesDicInfo.Contato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FContato = dbRec[DBOponentesDicInfo.Contato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FContato = dbRec[DBOponentesDicInfo.Contato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCNPJ = dbRec[DBOponentesDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBOponentesDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNPJ = dbRec[DBOponentesDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBOponentesDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNPJ = dbRec[DBOponentesDicInfo.CNPJ]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNPJ = dbRec[DBOponentesDicInfo.CNPJ]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBOponentesDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBOponentesDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBOponentesDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBOponentesDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBOponentesDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBOponentesDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBOponentesDicInfo.Juridica]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBOponentesDicInfo.Juridica];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBOponentesDicInfo.Juridica]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBOponentesDicInfo.Juridica];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBOponentesDicInfo.Juridica]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Juridica]))
            m_FJuridica = (bool)dbRec[DBOponentesDicInfo.Juridica];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBOponentesDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBOponentesDicInfo.Tipo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBOponentesDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBOponentesDicInfo.Tipo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBOponentesDicInfo.Tipo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Tipo]))
            m_FTipo = (bool)dbRec[DBOponentesDicInfo.Tipo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOponentesDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOponentesDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOponentesDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOponentesDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOponentesDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBOponentesDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBOponentesDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBOponentesDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBOponentesDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBOponentesDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBOponentesDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBOponentesDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBOponentesDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBOponentesDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBOponentesDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBOponentesDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBOponentesDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBOponentesDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBOponentesDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBOponentesDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBOponentesDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBOponentesDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBOponentesDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBOponentesDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBOponentesDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBOponentesDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBOponentesDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBOponentesDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBOponentesDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBOponentesDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOponentesDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOponentesDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOponentesDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOponentesDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOponentesDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBOponentesDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBOponentesDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBOponentesDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBOponentesDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBOponentesDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBOponentesDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBOponentesDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBOponentesDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBOponentesDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBOponentesDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBOponentesDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBOponentesDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBOponentesDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FInscEst = dbRec[DBOponentesDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBOponentesDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { m_FInscEst = dbRec[DBOponentesDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBOponentesDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FInscEst = dbRec[DBOponentesDicInfo.InscEst]?.ToString() ?? string.Empty; } catch { }

#else
        m_FInscEst = dbRec[DBOponentesDicInfo.InscEst]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBOponentesDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBOponentesDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBOponentesDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBOponentesDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBOponentesDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBOponentesDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBOponentesDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBOponentesDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBOponentesDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBOponentesDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBOponentesDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBOponentesDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FClass = dbRec[DBOponentesDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBOponentesDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FClass = dbRec[DBOponentesDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBOponentesDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FClass = dbRec[DBOponentesDicInfo.Class]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FClass = dbRec[DBOponentesDicInfo.Class]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Top])) m_FTop = (bool)dbRec[DBOponentesDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Top])) m_FTop = (bool)dbRec[DBOponentesDicInfo.Top];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Top])) m_FTop = (bool)dbRec[DBOponentesDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Top])) m_FTop = (bool)dbRec[DBOponentesDicInfo.Top];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Top])) m_FTop = (bool)dbRec[DBOponentesDicInfo.Top]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Top]))
            m_FTop = (bool)dbRec[DBOponentesDicInfo.Top];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBOponentesDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBOponentesDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBOponentesDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBOponentesDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBOponentesDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBOponentesDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Bold])) m_FBold = (bool)dbRec[DBOponentesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Bold])) m_FBold = (bool)dbRec[DBOponentesDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Bold])) m_FBold = (bool)dbRec[DBOponentesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Bold])) m_FBold = (bool)dbRec[DBOponentesDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Bold])) m_FBold = (bool)dbRec[DBOponentesDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBOponentesDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBOponentesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOponentesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBOponentesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOponentesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBOponentesDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBOponentesDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOponentesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOponentesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOponentesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOponentesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOponentesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBOponentesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Oponentes
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
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPFuncao])) m_FEMPFuncao = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPFuncao]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPFuncao])) m_FEMPFuncao = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPFuncao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPFuncao])) m_FEMPFuncao = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPFuncao]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPFuncao])) m_FEMPFuncao = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPFuncao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPFuncao])) m_FEMPFuncao = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPFuncao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPFuncao]))
            m_FEMPFuncao = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPFuncao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCTPSNumero = dbRec[DBOponentesDicInfo.CTPSNumero]?.ToString() ?? string.Empty; m_FCTPSNumero = dbRec[DBOponentesDicInfo.CTPSNumero]?.ToString() ?? string.Empty;  } catch {}  try { m_FCTPSNumero = dbRec[DBOponentesDicInfo.CTPSNumero]?.ToString() ?? string.Empty; m_FCTPSNumero = dbRec[DBOponentesDicInfo.CTPSNumero]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCTPSNumero = dbRec[DBOponentesDicInfo.CTPSNumero]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCTPSNumero = dbRec[DBOponentesDicInfo.CTPSNumero]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSite = dbRec[DBOponentesDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBOponentesDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { m_FSite = dbRec[DBOponentesDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBOponentesDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSite = dbRec[DBOponentesDicInfo.Site]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSite = dbRec[DBOponentesDicInfo.Site]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCTPSSerie = dbRec[DBOponentesDicInfo.CTPSSerie]?.ToString() ?? string.Empty; m_FCTPSSerie = dbRec[DBOponentesDicInfo.CTPSSerie]?.ToString() ?? string.Empty;  } catch {}  try { m_FCTPSSerie = dbRec[DBOponentesDicInfo.CTPSSerie]?.ToString() ?? string.Empty; m_FCTPSSerie = dbRec[DBOponentesDicInfo.CTPSSerie]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCTPSSerie = dbRec[DBOponentesDicInfo.CTPSSerie]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCTPSSerie = dbRec[DBOponentesDicInfo.CTPSSerie]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FNome = dbRec[DBOponentesDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBOponentesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FNome = dbRec[DBOponentesDicInfo.Nome]?.ToString() ?? string.Empty; sex.m_FNome = dbRec[DBOponentesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FNome = dbRec[DBOponentesDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FNome = dbRec[DBOponentesDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBOponentesDicInfo.Adv]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBOponentesDicInfo.Adv]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBOponentesDicInfo.Adv]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBOponentesDicInfo.Adv]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Adv])) m_FAdv = Convert.ToInt32(dbRec[DBOponentesDicInfo.Adv]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Adv]))
            m_FAdv = Convert.ToInt32(dbRec[DBOponentesDicInfo.Adv]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPCliente])) m_FEMPCliente = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPCliente]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPCliente])) m_FEMPCliente = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPCliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPCliente])) m_FEMPCliente = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPCliente]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPCliente])) m_FEMPCliente = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPCliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPCliente])) m_FEMPCliente = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPCliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.EMPCliente]))
            m_FEMPCliente = Convert.ToInt32(dbRec[DBOponentesDicInfo.EMPCliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBOponentesDicInfo.IDRep]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBOponentesDicInfo.IDRep]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBOponentesDicInfo.IDRep]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBOponentesDicInfo.IDRep]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.IDRep])) m_FIDRep = Convert.ToInt32(dbRec[DBOponentesDicInfo.IDRep]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.IDRep]))
            m_FIDRep = Convert.ToInt32(dbRec[DBOponentesDicInfo.IDRep]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPIS = dbRec[DBOponentesDicInfo.PIS]?.ToString() ?? string.Empty; m_FPIS = dbRec[DBOponentesDicInfo.PIS]?.ToString() ?? string.Empty;  } catch {}  try { m_FPIS = dbRec[DBOponentesDicInfo.PIS]?.ToString() ?? string.Empty; m_FPIS = dbRec[DBOponentesDicInfo.PIS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPIS = dbRec[DBOponentesDicInfo.PIS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPIS = dbRec[DBOponentesDicInfo.PIS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FContato = dbRec[DBOponentesDicInfo.Contato]?.ToString() ?? string.Empty; m_FContato = dbRec[DBOponentesDicInfo.Contato]?.ToString() ?? string.Empty;  } catch {}  try { m_FContato = dbRec[DBOponentesDicInfo.Contato]?.ToString() ?? string.Empty; m_FContato = dbRec[DBOponentesDicInfo.Contato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FContato = dbRec[DBOponentesDicInfo.Contato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FContato = dbRec[DBOponentesDicInfo.Contato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCNPJ = dbRec[DBOponentesDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBOponentesDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNPJ = dbRec[DBOponentesDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBOponentesDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNPJ = dbRec[DBOponentesDicInfo.CNPJ]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNPJ = dbRec[DBOponentesDicInfo.CNPJ]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FRG = dbRec[DBOponentesDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBOponentesDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { m_FRG = dbRec[DBOponentesDicInfo.RG]?.ToString() ?? string.Empty; m_FRG = dbRec[DBOponentesDicInfo.RG]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FRG = dbRec[DBOponentesDicInfo.RG]?.ToString() ?? string.Empty; } catch { }

#else
        m_FRG = dbRec[DBOponentesDicInfo.RG]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBOponentesDicInfo.Juridica]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBOponentesDicInfo.Juridica];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBOponentesDicInfo.Juridica]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBOponentesDicInfo.Juridica];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Juridica])) m_FJuridica = (bool)dbRec[DBOponentesDicInfo.Juridica]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Juridica]))
            m_FJuridica = (bool)dbRec[DBOponentesDicInfo.Juridica];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBOponentesDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBOponentesDicInfo.Tipo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBOponentesDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBOponentesDicInfo.Tipo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBOponentesDicInfo.Tipo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Tipo]))
            m_FTipo = (bool)dbRec[DBOponentesDicInfo.Tipo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOponentesDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOponentesDicInfo.Sexo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOponentesDicInfo.Sexo]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOponentesDicInfo.Sexo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Sexo])) m_FSexo = (bool)dbRec[DBOponentesDicInfo.Sexo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Sexo]))
            m_FSexo = (bool)dbRec[DBOponentesDicInfo.Sexo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCPF = dbRec[DBOponentesDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBOponentesDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCPF = dbRec[DBOponentesDicInfo.CPF]?.ToString() ?? string.Empty; sex.m_FCPF = dbRec[DBOponentesDicInfo.CPF]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCPF = dbRec[DBOponentesDicInfo.CPF]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCPF = dbRec[DBOponentesDicInfo.CPF]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FEndereco = dbRec[DBOponentesDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBOponentesDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FEndereco = dbRec[DBOponentesDicInfo.Endereco]?.ToString() ?? string.Empty; sex.m_FEndereco = dbRec[DBOponentesDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FEndereco = dbRec[DBOponentesDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FEndereco = dbRec[DBOponentesDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBOponentesDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBOponentesDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBOponentesDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBOponentesDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBOponentesDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBOponentesDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBOponentesDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBOponentesDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBOponentesDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBOponentesDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBOponentesDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBOponentesDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOponentesDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOponentesDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOponentesDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOponentesDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBOponentesDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBOponentesDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FBairro = dbRec[DBOponentesDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBOponentesDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FBairro = dbRec[DBOponentesDicInfo.Bairro]?.ToString() ?? string.Empty; sex.m_FBairro = dbRec[DBOponentesDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FBairro = dbRec[DBOponentesDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FBairro = dbRec[DBOponentesDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FCEP = dbRec[DBOponentesDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBOponentesDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FCEP = dbRec[DBOponentesDicInfo.CEP]?.ToString() ?? string.Empty; sex.m_FCEP = dbRec[DBOponentesDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FCEP = dbRec[DBOponentesDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FCEP = dbRec[DBOponentesDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FInscEst = dbRec[DBOponentesDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBOponentesDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { m_FInscEst = dbRec[DBOponentesDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBOponentesDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FInscEst = dbRec[DBOponentesDicInfo.InscEst]?.ToString() ?? string.Empty; } catch { }

#else
        m_FInscEst = dbRec[DBOponentesDicInfo.InscEst]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBOponentesDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBOponentesDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBOponentesDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBOponentesDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBOponentesDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBOponentesDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBOponentesDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBOponentesDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBOponentesDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBOponentesDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBOponentesDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBOponentesDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
sex.m_FClass = dbRec[DBOponentesDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBOponentesDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { sex.m_FClass = dbRec[DBOponentesDicInfo.Class]?.ToString() ?? string.Empty; sex.m_FClass = dbRec[DBOponentesDicInfo.Class]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {sex.m_FClass = dbRec[DBOponentesDicInfo.Class]?.ToString() ?? string.Empty; } catch { }

#else
        sex.m_FClass = dbRec[DBOponentesDicInfo.Class]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Top])) m_FTop = (bool)dbRec[DBOponentesDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Top])) m_FTop = (bool)dbRec[DBOponentesDicInfo.Top];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Top])) m_FTop = (bool)dbRec[DBOponentesDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Top])) m_FTop = (bool)dbRec[DBOponentesDicInfo.Top];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Top])) m_FTop = (bool)dbRec[DBOponentesDicInfo.Top]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Top]))
            m_FTop = (bool)dbRec[DBOponentesDicInfo.Top];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBOponentesDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBOponentesDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBOponentesDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBOponentesDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBOponentesDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBOponentesDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Bold])) m_FBold = (bool)dbRec[DBOponentesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Bold])) m_FBold = (bool)dbRec[DBOponentesDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Bold])) m_FBold = (bool)dbRec[DBOponentesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Bold])) m_FBold = (bool)dbRec[DBOponentesDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Bold])) m_FBold = (bool)dbRec[DBOponentesDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBOponentesDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBOponentesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOponentesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBOponentesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBOponentesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBOponentesDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBOponentesDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBOponentesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBOponentesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOponentesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOponentesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOponentesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOponentesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBOponentesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBOponentesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBOponentesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}