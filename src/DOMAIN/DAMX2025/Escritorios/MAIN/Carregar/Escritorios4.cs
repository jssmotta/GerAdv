namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBEscritorios
{
    public DBEscritorios(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBEscritoriosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Casa]))
                m_FCasa = (bool)dbRec[DBEscritoriosDicInfo.Casa];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Correspondente]))
                m_FCorrespondente = (bool)dbRec[DBEscritoriosDicInfo.Correspondente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBEscritoriosDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Parceria]))
                m_FParceria = (bool)dbRec[DBEscritoriosDicInfo.Parceria];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Top]))
                m_FTop = (bool)dbRec[DBEscritoriosDicInfo.Top];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBEscritoriosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FAdvResponsavel = dbRec[DBEscritoriosDicInfo.AdvResponsavel]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FBairro = dbRec[DBEscritoriosDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCEP = dbRec[DBEscritoriosDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCNPJ = dbRec[DBEscritoriosDicInfo.CNPJ]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBEscritoriosDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEndereco = dbRec[DBEscritoriosDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBEscritoriosDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBEscritoriosDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBEscritoriosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FInscEst = dbRec[DBEscritoriosDicInfo.InscEst]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBEscritoriosDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOAB = dbRec[DBEscritoriosDicInfo.OAB]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = dbRec[DBEscritoriosDicInfo.OBS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSecretaria = dbRec[DBEscritoriosDicInfo.Secretaria]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSite = dbRec[DBEscritoriosDicInfo.Site]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBEscritorios(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBEscritoriosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Casa]))
                m_FCasa = (bool)dbRec[DBEscritoriosDicInfo.Casa];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Correspondente]))
                m_FCorrespondente = (bool)dbRec[DBEscritoriosDicInfo.Correspondente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Etiqueta]))
                m_FEtiqueta = (bool)dbRec[DBEscritoriosDicInfo.Etiqueta];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Parceria]))
                m_FParceria = (bool)dbRec[DBEscritoriosDicInfo.Parceria];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Top]))
                m_FTop = (bool)dbRec[DBEscritoriosDicInfo.Top];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBEscritoriosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FAdvResponsavel = dbRec[DBEscritoriosDicInfo.AdvResponsavel]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FBairro = dbRec[DBEscritoriosDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCEP = dbRec[DBEscritoriosDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCNPJ = dbRec[DBEscritoriosDicInfo.CNPJ]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEMail = dbRec[DBEscritoriosDicInfo.EMail]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEndereco = dbRec[DBEscritoriosDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBEscritoriosDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBEscritoriosDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBEscritoriosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FInscEst = dbRec[DBEscritoriosDicInfo.InscEst]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBEscritoriosDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOAB = dbRec[DBEscritoriosDicInfo.OAB]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = dbRec[DBEscritoriosDicInfo.OBS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSecretaria = dbRec[DBEscritoriosDicInfo.Secretaria]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FSite = dbRec[DBEscritoriosDicInfo.Site]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Escritorios
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [escCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FCNPJ = dbRec[DBEscritoriosDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBEscritoriosDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNPJ = dbRec[DBEscritoriosDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBEscritoriosDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNPJ = dbRec[DBEscritoriosDicInfo.CNPJ]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNPJ = dbRec[DBEscritoriosDicInfo.CNPJ]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Casa])) m_FCasa = (bool)dbRec[DBEscritoriosDicInfo.Casa]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Casa])) m_FCasa = (bool)dbRec[DBEscritoriosDicInfo.Casa];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Casa])) m_FCasa = (bool)dbRec[DBEscritoriosDicInfo.Casa]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Casa])) m_FCasa = (bool)dbRec[DBEscritoriosDicInfo.Casa];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Casa])) m_FCasa = (bool)dbRec[DBEscritoriosDicInfo.Casa]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Casa]))
            m_FCasa = (bool)dbRec[DBEscritoriosDicInfo.Casa];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Parceria])) m_FParceria = (bool)dbRec[DBEscritoriosDicInfo.Parceria]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Parceria])) m_FParceria = (bool)dbRec[DBEscritoriosDicInfo.Parceria];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Parceria])) m_FParceria = (bool)dbRec[DBEscritoriosDicInfo.Parceria]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Parceria])) m_FParceria = (bool)dbRec[DBEscritoriosDicInfo.Parceria];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Parceria])) m_FParceria = (bool)dbRec[DBEscritoriosDicInfo.Parceria]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Parceria]))
            m_FParceria = (bool)dbRec[DBEscritoriosDicInfo.Parceria];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBEscritoriosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBEscritoriosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBEscritoriosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBEscritoriosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBEscritoriosDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBEscritoriosDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOAB = dbRec[DBEscritoriosDicInfo.OAB]?.ToString() ?? string.Empty; m_FOAB = dbRec[DBEscritoriosDicInfo.OAB]?.ToString() ?? string.Empty;  } catch {}  try { m_FOAB = dbRec[DBEscritoriosDicInfo.OAB]?.ToString() ?? string.Empty; m_FOAB = dbRec[DBEscritoriosDicInfo.OAB]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOAB = dbRec[DBEscritoriosDicInfo.OAB]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOAB = dbRec[DBEscritoriosDicInfo.OAB]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEndereco = dbRec[DBEscritoriosDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBEscritoriosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { m_FEndereco = dbRec[DBEscritoriosDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBEscritoriosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEndereco = dbRec[DBEscritoriosDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEndereco = dbRec[DBEscritoriosDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FBairro = dbRec[DBEscritoriosDicInfo.Bairro]?.ToString() ?? string.Empty; m_FBairro = dbRec[DBEscritoriosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { m_FBairro = dbRec[DBEscritoriosDicInfo.Bairro]?.ToString() ?? string.Empty; m_FBairro = dbRec[DBEscritoriosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FBairro = dbRec[DBEscritoriosDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        m_FBairro = dbRec[DBEscritoriosDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCEP = dbRec[DBEscritoriosDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBEscritoriosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { m_FCEP = dbRec[DBEscritoriosDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBEscritoriosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCEP = dbRec[DBEscritoriosDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCEP = dbRec[DBEscritoriosDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBEscritoriosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBEscritoriosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBEscritoriosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBEscritoriosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBEscritoriosDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBEscritoriosDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBEscritoriosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBEscritoriosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBEscritoriosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBEscritoriosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBEscritoriosDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBEscritoriosDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSite = dbRec[DBEscritoriosDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBEscritoriosDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { m_FSite = dbRec[DBEscritoriosDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBEscritoriosDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSite = dbRec[DBEscritoriosDicInfo.Site]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSite = dbRec[DBEscritoriosDicInfo.Site]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBEscritoriosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBEscritoriosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBEscritoriosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBEscritoriosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBEscritoriosDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBEscritoriosDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOBS = dbRec[DBEscritoriosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBEscritoriosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { m_FOBS = dbRec[DBEscritoriosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBEscritoriosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOBS = dbRec[DBEscritoriosDicInfo.OBS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOBS = dbRec[DBEscritoriosDicInfo.OBS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAdvResponsavel = dbRec[DBEscritoriosDicInfo.AdvResponsavel]?.ToString() ?? string.Empty; m_FAdvResponsavel = dbRec[DBEscritoriosDicInfo.AdvResponsavel]?.ToString() ?? string.Empty;  } catch {}  try { m_FAdvResponsavel = dbRec[DBEscritoriosDicInfo.AdvResponsavel]?.ToString() ?? string.Empty; m_FAdvResponsavel = dbRec[DBEscritoriosDicInfo.AdvResponsavel]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAdvResponsavel = dbRec[DBEscritoriosDicInfo.AdvResponsavel]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAdvResponsavel = dbRec[DBEscritoriosDicInfo.AdvResponsavel]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSecretaria = dbRec[DBEscritoriosDicInfo.Secretaria]?.ToString() ?? string.Empty; m_FSecretaria = dbRec[DBEscritoriosDicInfo.Secretaria]?.ToString() ?? string.Empty;  } catch {}  try { m_FSecretaria = dbRec[DBEscritoriosDicInfo.Secretaria]?.ToString() ?? string.Empty; m_FSecretaria = dbRec[DBEscritoriosDicInfo.Secretaria]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSecretaria = dbRec[DBEscritoriosDicInfo.Secretaria]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSecretaria = dbRec[DBEscritoriosDicInfo.Secretaria]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FInscEst = dbRec[DBEscritoriosDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBEscritoriosDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { m_FInscEst = dbRec[DBEscritoriosDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBEscritoriosDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FInscEst = dbRec[DBEscritoriosDicInfo.InscEst]?.ToString() ?? string.Empty; } catch { }

#else
        m_FInscEst = dbRec[DBEscritoriosDicInfo.InscEst]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Correspondente])) m_FCorrespondente = (bool)dbRec[DBEscritoriosDicInfo.Correspondente]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Correspondente])) m_FCorrespondente = (bool)dbRec[DBEscritoriosDicInfo.Correspondente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Correspondente])) m_FCorrespondente = (bool)dbRec[DBEscritoriosDicInfo.Correspondente]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Correspondente])) m_FCorrespondente = (bool)dbRec[DBEscritoriosDicInfo.Correspondente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Correspondente])) m_FCorrespondente = (bool)dbRec[DBEscritoriosDicInfo.Correspondente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Correspondente]))
            m_FCorrespondente = (bool)dbRec[DBEscritoriosDicInfo.Correspondente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Top])) m_FTop = (bool)dbRec[DBEscritoriosDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Top])) m_FTop = (bool)dbRec[DBEscritoriosDicInfo.Top];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Top])) m_FTop = (bool)dbRec[DBEscritoriosDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Top])) m_FTop = (bool)dbRec[DBEscritoriosDicInfo.Top];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Top])) m_FTop = (bool)dbRec[DBEscritoriosDicInfo.Top]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Top]))
            m_FTop = (bool)dbRec[DBEscritoriosDicInfo.Top];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBEscritoriosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBEscritoriosDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBEscritoriosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBEscritoriosDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBEscritoriosDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBEscritoriosDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEscritoriosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEscritoriosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEscritoriosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEscritoriosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEscritoriosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBEscritoriosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBEscritoriosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBEscritoriosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBEscritoriosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBEscritoriosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBEscritoriosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBEscritoriosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEscritoriosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEscritoriosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEscritoriosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEscritoriosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEscritoriosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBEscritoriosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Escritorios
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
m_FCNPJ = dbRec[DBEscritoriosDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBEscritoriosDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { m_FCNPJ = dbRec[DBEscritoriosDicInfo.CNPJ]?.ToString() ?? string.Empty; m_FCNPJ = dbRec[DBEscritoriosDicInfo.CNPJ]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCNPJ = dbRec[DBEscritoriosDicInfo.CNPJ]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCNPJ = dbRec[DBEscritoriosDicInfo.CNPJ]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Casa])) m_FCasa = (bool)dbRec[DBEscritoriosDicInfo.Casa]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Casa])) m_FCasa = (bool)dbRec[DBEscritoriosDicInfo.Casa];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Casa])) m_FCasa = (bool)dbRec[DBEscritoriosDicInfo.Casa]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Casa])) m_FCasa = (bool)dbRec[DBEscritoriosDicInfo.Casa];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Casa])) m_FCasa = (bool)dbRec[DBEscritoriosDicInfo.Casa]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Casa]))
            m_FCasa = (bool)dbRec[DBEscritoriosDicInfo.Casa];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Parceria])) m_FParceria = (bool)dbRec[DBEscritoriosDicInfo.Parceria]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Parceria])) m_FParceria = (bool)dbRec[DBEscritoriosDicInfo.Parceria];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Parceria])) m_FParceria = (bool)dbRec[DBEscritoriosDicInfo.Parceria]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Parceria])) m_FParceria = (bool)dbRec[DBEscritoriosDicInfo.Parceria];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Parceria])) m_FParceria = (bool)dbRec[DBEscritoriosDicInfo.Parceria]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Parceria]))
            m_FParceria = (bool)dbRec[DBEscritoriosDicInfo.Parceria];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBEscritoriosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBEscritoriosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBEscritoriosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBEscritoriosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBEscritoriosDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBEscritoriosDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOAB = dbRec[DBEscritoriosDicInfo.OAB]?.ToString() ?? string.Empty; m_FOAB = dbRec[DBEscritoriosDicInfo.OAB]?.ToString() ?? string.Empty;  } catch {}  try { m_FOAB = dbRec[DBEscritoriosDicInfo.OAB]?.ToString() ?? string.Empty; m_FOAB = dbRec[DBEscritoriosDicInfo.OAB]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOAB = dbRec[DBEscritoriosDicInfo.OAB]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOAB = dbRec[DBEscritoriosDicInfo.OAB]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEndereco = dbRec[DBEscritoriosDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBEscritoriosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { m_FEndereco = dbRec[DBEscritoriosDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBEscritoriosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEndereco = dbRec[DBEscritoriosDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEndereco = dbRec[DBEscritoriosDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FBairro = dbRec[DBEscritoriosDicInfo.Bairro]?.ToString() ?? string.Empty; m_FBairro = dbRec[DBEscritoriosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { m_FBairro = dbRec[DBEscritoriosDicInfo.Bairro]?.ToString() ?? string.Empty; m_FBairro = dbRec[DBEscritoriosDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FBairro = dbRec[DBEscritoriosDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        m_FBairro = dbRec[DBEscritoriosDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCEP = dbRec[DBEscritoriosDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBEscritoriosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { m_FCEP = dbRec[DBEscritoriosDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBEscritoriosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCEP = dbRec[DBEscritoriosDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCEP = dbRec[DBEscritoriosDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBEscritoriosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBEscritoriosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBEscritoriosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBEscritoriosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBEscritoriosDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBEscritoriosDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBEscritoriosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBEscritoriosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBEscritoriosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBEscritoriosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBEscritoriosDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBEscritoriosDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSite = dbRec[DBEscritoriosDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBEscritoriosDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { m_FSite = dbRec[DBEscritoriosDicInfo.Site]?.ToString() ?? string.Empty; m_FSite = dbRec[DBEscritoriosDicInfo.Site]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSite = dbRec[DBEscritoriosDicInfo.Site]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSite = dbRec[DBEscritoriosDicInfo.Site]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEMail = dbRec[DBEscritoriosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBEscritoriosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { m_FEMail = dbRec[DBEscritoriosDicInfo.EMail]?.ToString() ?? string.Empty; m_FEMail = dbRec[DBEscritoriosDicInfo.EMail]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEMail = dbRec[DBEscritoriosDicInfo.EMail]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEMail = dbRec[DBEscritoriosDicInfo.EMail]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOBS = dbRec[DBEscritoriosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBEscritoriosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { m_FOBS = dbRec[DBEscritoriosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBEscritoriosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOBS = dbRec[DBEscritoriosDicInfo.OBS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOBS = dbRec[DBEscritoriosDicInfo.OBS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FAdvResponsavel = dbRec[DBEscritoriosDicInfo.AdvResponsavel]?.ToString() ?? string.Empty; m_FAdvResponsavel = dbRec[DBEscritoriosDicInfo.AdvResponsavel]?.ToString() ?? string.Empty;  } catch {}  try { m_FAdvResponsavel = dbRec[DBEscritoriosDicInfo.AdvResponsavel]?.ToString() ?? string.Empty; m_FAdvResponsavel = dbRec[DBEscritoriosDicInfo.AdvResponsavel]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FAdvResponsavel = dbRec[DBEscritoriosDicInfo.AdvResponsavel]?.ToString() ?? string.Empty; } catch { }

#else
        m_FAdvResponsavel = dbRec[DBEscritoriosDicInfo.AdvResponsavel]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FSecretaria = dbRec[DBEscritoriosDicInfo.Secretaria]?.ToString() ?? string.Empty; m_FSecretaria = dbRec[DBEscritoriosDicInfo.Secretaria]?.ToString() ?? string.Empty;  } catch {}  try { m_FSecretaria = dbRec[DBEscritoriosDicInfo.Secretaria]?.ToString() ?? string.Empty; m_FSecretaria = dbRec[DBEscritoriosDicInfo.Secretaria]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FSecretaria = dbRec[DBEscritoriosDicInfo.Secretaria]?.ToString() ?? string.Empty; } catch { }

#else
        m_FSecretaria = dbRec[DBEscritoriosDicInfo.Secretaria]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FInscEst = dbRec[DBEscritoriosDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBEscritoriosDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { m_FInscEst = dbRec[DBEscritoriosDicInfo.InscEst]?.ToString() ?? string.Empty; m_FInscEst = dbRec[DBEscritoriosDicInfo.InscEst]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FInscEst = dbRec[DBEscritoriosDicInfo.InscEst]?.ToString() ?? string.Empty; } catch { }

#else
        m_FInscEst = dbRec[DBEscritoriosDicInfo.InscEst]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Correspondente])) m_FCorrespondente = (bool)dbRec[DBEscritoriosDicInfo.Correspondente]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Correspondente])) m_FCorrespondente = (bool)dbRec[DBEscritoriosDicInfo.Correspondente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Correspondente])) m_FCorrespondente = (bool)dbRec[DBEscritoriosDicInfo.Correspondente]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Correspondente])) m_FCorrespondente = (bool)dbRec[DBEscritoriosDicInfo.Correspondente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Correspondente])) m_FCorrespondente = (bool)dbRec[DBEscritoriosDicInfo.Correspondente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Correspondente]))
            m_FCorrespondente = (bool)dbRec[DBEscritoriosDicInfo.Correspondente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Top])) m_FTop = (bool)dbRec[DBEscritoriosDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Top])) m_FTop = (bool)dbRec[DBEscritoriosDicInfo.Top];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Top])) m_FTop = (bool)dbRec[DBEscritoriosDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Top])) m_FTop = (bool)dbRec[DBEscritoriosDicInfo.Top];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Top])) m_FTop = (bool)dbRec[DBEscritoriosDicInfo.Top]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Top]))
            m_FTop = (bool)dbRec[DBEscritoriosDicInfo.Top];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBEscritoriosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBEscritoriosDicInfo.Etiqueta];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBEscritoriosDicInfo.Etiqueta]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBEscritoriosDicInfo.Etiqueta];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Etiqueta])) m_FEtiqueta = (bool)dbRec[DBEscritoriosDicInfo.Etiqueta]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Etiqueta]))
            m_FEtiqueta = (bool)dbRec[DBEscritoriosDicInfo.Etiqueta];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEscritoriosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEscritoriosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEscritoriosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEscritoriosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEscritoriosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBEscritoriosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBEscritoriosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBEscritoriosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBEscritoriosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBEscritoriosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBEscritoriosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBEscritoriosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBEscritoriosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBEscritoriosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEscritoriosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEscritoriosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEscritoriosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEscritoriosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEscritoriosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEscritoriosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBEscritoriosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}