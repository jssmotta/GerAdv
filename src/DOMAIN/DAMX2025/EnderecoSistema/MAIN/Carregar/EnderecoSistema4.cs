namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBEnderecoSistema
{
    public DBEnderecoSistema(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cadastro]))
                m_FCadastro = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cadastro]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod]))
                m_FCadastroExCod = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema]))
                m_FTipoEnderecoSistema = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBEnderecoSistemaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FBairro = dbRec[DBEnderecoSistemaDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCEP = dbRec[DBEnderecoSistemaDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FContatoNoLocal = dbRec[DBEnderecoSistemaDicInfo.ContatoNoLocal]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEndereco = dbRec[DBEnderecoSistemaDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBEnderecoSistemaDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBEnderecoSistemaDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FMotivo = dbRec[DBEnderecoSistemaDicInfo.Motivo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBEnderecoSistemaDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBEnderecoSistema(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cadastro]))
                m_FCadastro = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cadastro]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod]))
                m_FCadastroExCod = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema]))
                m_FTipoEnderecoSistema = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBEnderecoSistemaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FBairro = dbRec[DBEnderecoSistemaDicInfo.Bairro]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCEP = dbRec[DBEnderecoSistemaDicInfo.CEP]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FContatoNoLocal = dbRec[DBEnderecoSistemaDicInfo.ContatoNoLocal]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FEndereco = dbRec[DBEnderecoSistemaDicInfo.Endereco]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFax = dbRec[DBEnderecoSistemaDicInfo.Fax]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFone = dbRec[DBEnderecoSistemaDicInfo.Fone]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FMotivo = dbRec[DBEnderecoSistemaDicInfo.Motivo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObservacao = dbRec[DBEnderecoSistemaDicInfo.Observacao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_EnderecoSistema
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[EnderecoSistema] (NOLOCK) WHERE [estCodigo] = @ThisIDToLoad", oCnn);
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
if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cadastro])) m_FCadastro = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cadastro]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cadastro])) m_FCadastro = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cadastro]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cadastro])) m_FCadastro = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cadastro]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cadastro])) m_FCadastro = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cadastro]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cadastro])) m_FCadastro = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cadastro]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cadastro]))
            m_FCadastro = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cadastro]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod])) m_FCadastroExCod = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod])) m_FCadastroExCod = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod])) m_FCadastroExCod = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod])) m_FCadastroExCod = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod])) m_FCadastroExCod = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod]))
            m_FCadastroExCod = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema])) m_FTipoEnderecoSistema = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema])) m_FTipoEnderecoSistema = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema])) m_FTipoEnderecoSistema = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema])) m_FTipoEnderecoSistema = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema])) m_FTipoEnderecoSistema = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema]))
            m_FTipoEnderecoSistema = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FMotivo = dbRec[DBEnderecoSistemaDicInfo.Motivo]?.ToString() ?? string.Empty; m_FMotivo = dbRec[DBEnderecoSistemaDicInfo.Motivo]?.ToString() ?? string.Empty;  } catch {}  try { m_FMotivo = dbRec[DBEnderecoSistemaDicInfo.Motivo]?.ToString() ?? string.Empty; m_FMotivo = dbRec[DBEnderecoSistemaDicInfo.Motivo]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FMotivo = dbRec[DBEnderecoSistemaDicInfo.Motivo]?.ToString() ?? string.Empty; } catch { }

#else
        m_FMotivo = dbRec[DBEnderecoSistemaDicInfo.Motivo]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FContatoNoLocal = dbRec[DBEnderecoSistemaDicInfo.ContatoNoLocal]?.ToString() ?? string.Empty; m_FContatoNoLocal = dbRec[DBEnderecoSistemaDicInfo.ContatoNoLocal]?.ToString() ?? string.Empty;  } catch {}  try { m_FContatoNoLocal = dbRec[DBEnderecoSistemaDicInfo.ContatoNoLocal]?.ToString() ?? string.Empty; m_FContatoNoLocal = dbRec[DBEnderecoSistemaDicInfo.ContatoNoLocal]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FContatoNoLocal = dbRec[DBEnderecoSistemaDicInfo.ContatoNoLocal]?.ToString() ?? string.Empty; } catch { }

#else
        m_FContatoNoLocal = dbRec[DBEnderecoSistemaDicInfo.ContatoNoLocal]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEndereco = dbRec[DBEnderecoSistemaDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBEnderecoSistemaDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { m_FEndereco = dbRec[DBEnderecoSistemaDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBEnderecoSistemaDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEndereco = dbRec[DBEnderecoSistemaDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEndereco = dbRec[DBEnderecoSistemaDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FBairro = dbRec[DBEnderecoSistemaDicInfo.Bairro]?.ToString() ?? string.Empty; m_FBairro = dbRec[DBEnderecoSistemaDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { m_FBairro = dbRec[DBEnderecoSistemaDicInfo.Bairro]?.ToString() ?? string.Empty; m_FBairro = dbRec[DBEnderecoSistemaDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FBairro = dbRec[DBEnderecoSistemaDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        m_FBairro = dbRec[DBEnderecoSistemaDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCEP = dbRec[DBEnderecoSistemaDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBEnderecoSistemaDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { m_FCEP = dbRec[DBEnderecoSistemaDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBEnderecoSistemaDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCEP = dbRec[DBEnderecoSistemaDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCEP = dbRec[DBEnderecoSistemaDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBEnderecoSistemaDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBEnderecoSistemaDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBEnderecoSistemaDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBEnderecoSistemaDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBEnderecoSistemaDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBEnderecoSistemaDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBEnderecoSistemaDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBEnderecoSistemaDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBEnderecoSistemaDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBEnderecoSistemaDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBEnderecoSistemaDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBEnderecoSistemaDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBEnderecoSistemaDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBEnderecoSistemaDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBEnderecoSistemaDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBEnderecoSistemaDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBEnderecoSistemaDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBEnderecoSistemaDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEnderecoSistemaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEnderecoSistemaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEnderecoSistemaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEnderecoSistemaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEnderecoSistemaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBEnderecoSistemaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_EnderecoSistema
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
if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cadastro])) m_FCadastro = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cadastro]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cadastro])) m_FCadastro = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cadastro]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cadastro])) m_FCadastro = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cadastro]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cadastro])) m_FCadastro = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cadastro]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cadastro])) m_FCadastro = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cadastro]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cadastro]))
            m_FCadastro = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cadastro]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod])) m_FCadastroExCod = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod])) m_FCadastroExCod = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod])) m_FCadastroExCod = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod])) m_FCadastroExCod = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod])) m_FCadastroExCod = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod]))
            m_FCadastroExCod = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.CadastroExCod]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema])) m_FTipoEnderecoSistema = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema])) m_FTipoEnderecoSistema = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema])) m_FTipoEnderecoSistema = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema])) m_FTipoEnderecoSistema = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema])) m_FTipoEnderecoSistema = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema]))
            m_FTipoEnderecoSistema = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.TipoEnderecoSistema]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FMotivo = dbRec[DBEnderecoSistemaDicInfo.Motivo]?.ToString() ?? string.Empty; m_FMotivo = dbRec[DBEnderecoSistemaDicInfo.Motivo]?.ToString() ?? string.Empty;  } catch {}  try { m_FMotivo = dbRec[DBEnderecoSistemaDicInfo.Motivo]?.ToString() ?? string.Empty; m_FMotivo = dbRec[DBEnderecoSistemaDicInfo.Motivo]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FMotivo = dbRec[DBEnderecoSistemaDicInfo.Motivo]?.ToString() ?? string.Empty; } catch { }

#else
        m_FMotivo = dbRec[DBEnderecoSistemaDicInfo.Motivo]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FContatoNoLocal = dbRec[DBEnderecoSistemaDicInfo.ContatoNoLocal]?.ToString() ?? string.Empty; m_FContatoNoLocal = dbRec[DBEnderecoSistemaDicInfo.ContatoNoLocal]?.ToString() ?? string.Empty;  } catch {}  try { m_FContatoNoLocal = dbRec[DBEnderecoSistemaDicInfo.ContatoNoLocal]?.ToString() ?? string.Empty; m_FContatoNoLocal = dbRec[DBEnderecoSistemaDicInfo.ContatoNoLocal]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FContatoNoLocal = dbRec[DBEnderecoSistemaDicInfo.ContatoNoLocal]?.ToString() ?? string.Empty; } catch { }

#else
        m_FContatoNoLocal = dbRec[DBEnderecoSistemaDicInfo.ContatoNoLocal]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FEndereco = dbRec[DBEnderecoSistemaDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBEnderecoSistemaDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { m_FEndereco = dbRec[DBEnderecoSistemaDicInfo.Endereco]?.ToString() ?? string.Empty; m_FEndereco = dbRec[DBEnderecoSistemaDicInfo.Endereco]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FEndereco = dbRec[DBEnderecoSistemaDicInfo.Endereco]?.ToString() ?? string.Empty; } catch { }

#else
        m_FEndereco = dbRec[DBEnderecoSistemaDicInfo.Endereco]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FBairro = dbRec[DBEnderecoSistemaDicInfo.Bairro]?.ToString() ?? string.Empty; m_FBairro = dbRec[DBEnderecoSistemaDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { m_FBairro = dbRec[DBEnderecoSistemaDicInfo.Bairro]?.ToString() ?? string.Empty; m_FBairro = dbRec[DBEnderecoSistemaDicInfo.Bairro]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FBairro = dbRec[DBEnderecoSistemaDicInfo.Bairro]?.ToString() ?? string.Empty; } catch { }

#else
        m_FBairro = dbRec[DBEnderecoSistemaDicInfo.Bairro]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCEP = dbRec[DBEnderecoSistemaDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBEnderecoSistemaDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { m_FCEP = dbRec[DBEnderecoSistemaDicInfo.CEP]?.ToString() ?? string.Empty; m_FCEP = dbRec[DBEnderecoSistemaDicInfo.CEP]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCEP = dbRec[DBEnderecoSistemaDicInfo.CEP]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCEP = dbRec[DBEnderecoSistemaDicInfo.CEP]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFone = dbRec[DBEnderecoSistemaDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBEnderecoSistemaDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { m_FFone = dbRec[DBEnderecoSistemaDicInfo.Fone]?.ToString() ?? string.Empty; m_FFone = dbRec[DBEnderecoSistemaDicInfo.Fone]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFone = dbRec[DBEnderecoSistemaDicInfo.Fone]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFone = dbRec[DBEnderecoSistemaDicInfo.Fone]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFax = dbRec[DBEnderecoSistemaDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBEnderecoSistemaDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { m_FFax = dbRec[DBEnderecoSistemaDicInfo.Fax]?.ToString() ?? string.Empty; m_FFax = dbRec[DBEnderecoSistemaDicInfo.Fax]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFax = dbRec[DBEnderecoSistemaDicInfo.Fax]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFax = dbRec[DBEnderecoSistemaDicInfo.Fax]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObservacao = dbRec[DBEnderecoSistemaDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBEnderecoSistemaDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { m_FObservacao = dbRec[DBEnderecoSistemaDicInfo.Observacao]?.ToString() ?? string.Empty; m_FObservacao = dbRec[DBEnderecoSistemaDicInfo.Observacao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObservacao = dbRec[DBEnderecoSistemaDicInfo.Observacao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObservacao = dbRec[DBEnderecoSistemaDicInfo.Observacao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBEnderecoSistemaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBEnderecoSistemaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBEnderecoSistemaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEnderecoSistemaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEnderecoSistemaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEnderecoSistemaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEnderecoSistemaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEnderecoSistemaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEnderecoSistemaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBEnderecoSistemaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}