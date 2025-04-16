namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTribEnderecos
{
    public DBTribEnderecos(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Tribunal]))
                m_FTribunal = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Tribunal]);
        }
        catch
        {
        }

        try
        {
            m_FCEP = dbRec[DBTribEnderecosDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEndereco = dbRec[DBTribEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBTribEnderecosDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBTribEnderecosDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = dbRec[DBTribEnderecosDicInfo.OBS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBTribEnderecos(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Tribunal]))
                m_FTribunal = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Tribunal]);
        }
        catch
        {
        }

        try
        {
            m_FCEP = dbRec[DBTribEnderecosDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEndereco = dbRec[DBTribEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBTribEnderecosDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBTribEnderecosDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = dbRec[DBTribEnderecosDicInfo.OBS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_TribEnderecos
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[TribEnderecos] (NOLOCK) WHERE [treCodigo] = @ThisIDToLoad", oCnn);
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
if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Tribunal]); if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Tribunal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Tribunal]); if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Tribunal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Tribunal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Tribunal]))
            m_FTribunal = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Tribunal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEndereco = dbRec[DBTribEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBTribEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { m_FEndereco = dbRec[DBTribEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBTribEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEndereco = dbRec[DBTribEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEndereco = dbRec[DBTribEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCEP = dbRec[DBTribEnderecosDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBTribEnderecosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { m_FCEP = dbRec[DBTribEnderecosDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBTribEnderecosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCEP = dbRec[DBTribEnderecosDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCEP = dbRec[DBTribEnderecosDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBTribEnderecosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBTribEnderecosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBTribEnderecosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBTribEnderecosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBTribEnderecosDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBTribEnderecosDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBTribEnderecosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBTribEnderecosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBTribEnderecosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBTribEnderecosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBTribEnderecosDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBTribEnderecosDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOBS = dbRec[DBTribEnderecosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBTribEnderecosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { m_FOBS = dbRec[DBTribEnderecosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBTribEnderecosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOBS = dbRec[DBTribEnderecosDicInfo.OBS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOBS = dbRec[DBTribEnderecosDicInfo.OBS]?.ToString() ?? string.Empty;
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_TribEnderecos
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
if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Tribunal]); if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Tribunal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Tribunal]); if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Tribunal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Tribunal])) m_FTribunal = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Tribunal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Tribunal]))
            m_FTribunal = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Tribunal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTribEnderecosDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBTribEnderecosDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEndereco = dbRec[DBTribEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBTribEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { m_FEndereco = dbRec[DBTribEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBTribEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEndereco = dbRec[DBTribEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEndereco = dbRec[DBTribEnderecosDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCEP = dbRec[DBTribEnderecosDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBTribEnderecosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { m_FCEP = dbRec[DBTribEnderecosDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBTribEnderecosDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCEP = dbRec[DBTribEnderecosDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCEP = dbRec[DBTribEnderecosDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBTribEnderecosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBTribEnderecosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBTribEnderecosDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBTribEnderecosDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBTribEnderecosDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBTribEnderecosDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBTribEnderecosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBTribEnderecosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBTribEnderecosDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBTribEnderecosDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBTribEnderecosDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBTribEnderecosDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOBS = dbRec[DBTribEnderecosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBTribEnderecosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { m_FOBS = dbRec[DBTribEnderecosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBTribEnderecosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOBS = dbRec[DBTribEnderecosDicInfo.OBS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOBS = dbRec[DBTribEnderecosDicInfo.OBS]?.ToString() ?? string.Empty;
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}