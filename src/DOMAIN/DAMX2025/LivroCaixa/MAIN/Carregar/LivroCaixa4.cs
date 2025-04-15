namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBLivroCaixa
{
    public DBLivroCaixa(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Ajuste]))
                m_FAjuste = (bool)dbRec[DBLivroCaixaDicInfo.Ajuste];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Grupo]))
                m_FGrupo = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Grupo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDDes]))
                m_FIDDes = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDDes]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHon]))
                m_FIDHon = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHon]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonParc]))
                m_FIDHonParc = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHonParc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonSuc]))
                m_FIDHonSuc = (bool)dbRec[DBLivroCaixaDicInfo.IDHonSuc];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Pessoal]))
                m_FPessoal = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Pessoal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Previsto]))
                m_FPrevisto = (bool)dbRec[DBLivroCaixaDicInfo.Previsto];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Tipo]))
                m_FTipo = (bool)dbRec[DBLivroCaixaDicInfo.Tipo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Valor]))
                m_FValor = Convert.ToDecimal(dbRec[DBLivroCaixaDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBLivroCaixaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FHistorico = dbRec[DBLivroCaixaDicInfo.Historico]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBLivroCaixa(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Ajuste]))
                m_FAjuste = (bool)dbRec[DBLivroCaixaDicInfo.Ajuste];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Grupo]))
                m_FGrupo = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Grupo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDDes]))
                m_FIDDes = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDDes]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHon]))
                m_FIDHon = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHon]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonParc]))
                m_FIDHonParc = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHonParc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonSuc]))
                m_FIDHonSuc = (bool)dbRec[DBLivroCaixaDicInfo.IDHonSuc];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Pessoal]))
                m_FPessoal = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Pessoal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Previsto]))
                m_FPrevisto = (bool)dbRec[DBLivroCaixaDicInfo.Previsto];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Tipo]))
                m_FTipo = (bool)dbRec[DBLivroCaixaDicInfo.Tipo];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Valor]))
                m_FValor = Convert.ToDecimal(dbRec[DBLivroCaixaDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBLivroCaixaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FHistorico = dbRec[DBLivroCaixaDicInfo.Historico]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_LivroCaixa
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[LivroCaixa] (NOLOCK) WHERE [livCodigo] = @ThisIDToLoad", oCnn);
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
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDDes])) m_FIDDes = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDDes]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDDes])) m_FIDDes = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDDes]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDDes])) m_FIDDes = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDDes]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDDes])) m_FIDDes = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDDes]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDDes])) m_FIDDes = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDDes]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDDes]))
            m_FIDDes = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDDes]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Pessoal])) m_FPessoal = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Pessoal]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Pessoal])) m_FPessoal = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Pessoal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Pessoal])) m_FPessoal = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Pessoal]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Pessoal])) m_FPessoal = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Pessoal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Pessoal])) m_FPessoal = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Pessoal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Pessoal]))
            m_FPessoal = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Pessoal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Ajuste])) m_FAjuste = (bool)dbRec[DBLivroCaixaDicInfo.Ajuste]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Ajuste])) m_FAjuste = (bool)dbRec[DBLivroCaixaDicInfo.Ajuste];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Ajuste])) m_FAjuste = (bool)dbRec[DBLivroCaixaDicInfo.Ajuste]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Ajuste])) m_FAjuste = (bool)dbRec[DBLivroCaixaDicInfo.Ajuste];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Ajuste])) m_FAjuste = (bool)dbRec[DBLivroCaixaDicInfo.Ajuste]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Ajuste]))
            m_FAjuste = (bool)dbRec[DBLivroCaixaDicInfo.Ajuste];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHon])) m_FIDHon = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHon]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHon])) m_FIDHon = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHon]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHon])) m_FIDHon = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHon]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHon])) m_FIDHon = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHon]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHon])) m_FIDHon = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHon]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHon]))
            m_FIDHon = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHon]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonParc])) m_FIDHonParc = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHonParc]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonParc])) m_FIDHonParc = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHonParc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonParc])) m_FIDHonParc = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHonParc]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonParc])) m_FIDHonParc = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHonParc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonParc])) m_FIDHonParc = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHonParc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonParc]))
            m_FIDHonParc = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHonParc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonSuc])) m_FIDHonSuc = (bool)dbRec[DBLivroCaixaDicInfo.IDHonSuc]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonSuc])) m_FIDHonSuc = (bool)dbRec[DBLivroCaixaDicInfo.IDHonSuc];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonSuc])) m_FIDHonSuc = (bool)dbRec[DBLivroCaixaDicInfo.IDHonSuc]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonSuc])) m_FIDHonSuc = (bool)dbRec[DBLivroCaixaDicInfo.IDHonSuc];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonSuc])) m_FIDHonSuc = (bool)dbRec[DBLivroCaixaDicInfo.IDHonSuc]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonSuc]))
            m_FIDHonSuc = (bool)dbRec[DBLivroCaixaDicInfo.IDHonSuc];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBLivroCaixaDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBLivroCaixaDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBLivroCaixaDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBLivroCaixaDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBLivroCaixaDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Valor]))
            m_FValor = Convert.ToDecimal(dbRec[DBLivroCaixaDicInfo.Valor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBLivroCaixaDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBLivroCaixaDicInfo.Tipo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBLivroCaixaDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBLivroCaixaDicInfo.Tipo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBLivroCaixaDicInfo.Tipo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Tipo]))
            m_FTipo = (bool)dbRec[DBLivroCaixaDicInfo.Tipo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FHistorico = dbRec[DBLivroCaixaDicInfo.Historico]?.ToString() ?? string.Empty; m_FHistorico = dbRec[DBLivroCaixaDicInfo.Historico]?.ToString() ?? string.Empty;  } catch {}  try { m_FHistorico = dbRec[DBLivroCaixaDicInfo.Historico]?.ToString() ?? string.Empty; m_FHistorico = dbRec[DBLivroCaixaDicInfo.Historico]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FHistorico = dbRec[DBLivroCaixaDicInfo.Historico]?.ToString() ?? string.Empty; } catch { }

#else
        m_FHistorico = dbRec[DBLivroCaixaDicInfo.Historico]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Previsto])) m_FPrevisto = (bool)dbRec[DBLivroCaixaDicInfo.Previsto]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Previsto])) m_FPrevisto = (bool)dbRec[DBLivroCaixaDicInfo.Previsto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Previsto])) m_FPrevisto = (bool)dbRec[DBLivroCaixaDicInfo.Previsto]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Previsto])) m_FPrevisto = (bool)dbRec[DBLivroCaixaDicInfo.Previsto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Previsto])) m_FPrevisto = (bool)dbRec[DBLivroCaixaDicInfo.Previsto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Previsto]))
            m_FPrevisto = (bool)dbRec[DBLivroCaixaDicInfo.Previsto];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Grupo]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Grupo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Grupo]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Grupo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Grupo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Grupo]))
            m_FGrupo = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Grupo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLivroCaixaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLivroCaixaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLivroCaixaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLivroCaixaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLivroCaixaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBLivroCaixaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_LivroCaixa
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
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDDes])) m_FIDDes = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDDes]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDDes])) m_FIDDes = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDDes]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDDes])) m_FIDDes = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDDes]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDDes])) m_FIDDes = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDDes]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDDes])) m_FIDDes = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDDes]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDDes]))
            m_FIDDes = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDDes]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Pessoal])) m_FPessoal = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Pessoal]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Pessoal])) m_FPessoal = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Pessoal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Pessoal])) m_FPessoal = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Pessoal]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Pessoal])) m_FPessoal = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Pessoal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Pessoal])) m_FPessoal = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Pessoal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Pessoal]))
            m_FPessoal = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Pessoal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Ajuste])) m_FAjuste = (bool)dbRec[DBLivroCaixaDicInfo.Ajuste]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Ajuste])) m_FAjuste = (bool)dbRec[DBLivroCaixaDicInfo.Ajuste];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Ajuste])) m_FAjuste = (bool)dbRec[DBLivroCaixaDicInfo.Ajuste]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Ajuste])) m_FAjuste = (bool)dbRec[DBLivroCaixaDicInfo.Ajuste];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Ajuste])) m_FAjuste = (bool)dbRec[DBLivroCaixaDicInfo.Ajuste]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Ajuste]))
            m_FAjuste = (bool)dbRec[DBLivroCaixaDicInfo.Ajuste];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHon])) m_FIDHon = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHon]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHon])) m_FIDHon = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHon]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHon])) m_FIDHon = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHon]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHon])) m_FIDHon = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHon]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHon])) m_FIDHon = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHon]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHon]))
            m_FIDHon = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHon]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonParc])) m_FIDHonParc = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHonParc]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonParc])) m_FIDHonParc = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHonParc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonParc])) m_FIDHonParc = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHonParc]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonParc])) m_FIDHonParc = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHonParc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonParc])) m_FIDHonParc = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHonParc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonParc]))
            m_FIDHonParc = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.IDHonParc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonSuc])) m_FIDHonSuc = (bool)dbRec[DBLivroCaixaDicInfo.IDHonSuc]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonSuc])) m_FIDHonSuc = (bool)dbRec[DBLivroCaixaDicInfo.IDHonSuc];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonSuc])) m_FIDHonSuc = (bool)dbRec[DBLivroCaixaDicInfo.IDHonSuc]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonSuc])) m_FIDHonSuc = (bool)dbRec[DBLivroCaixaDicInfo.IDHonSuc];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonSuc])) m_FIDHonSuc = (bool)dbRec[DBLivroCaixaDicInfo.IDHonSuc]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.IDHonSuc]))
            m_FIDHonSuc = (bool)dbRec[DBLivroCaixaDicInfo.IDHonSuc];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBLivroCaixaDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBLivroCaixaDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBLivroCaixaDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBLivroCaixaDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBLivroCaixaDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Valor]))
            m_FValor = Convert.ToDecimal(dbRec[DBLivroCaixaDicInfo.Valor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBLivroCaixaDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBLivroCaixaDicInfo.Tipo];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBLivroCaixaDicInfo.Tipo]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBLivroCaixaDicInfo.Tipo];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Tipo])) m_FTipo = (bool)dbRec[DBLivroCaixaDicInfo.Tipo]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Tipo]))
            m_FTipo = (bool)dbRec[DBLivroCaixaDicInfo.Tipo];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FHistorico = dbRec[DBLivroCaixaDicInfo.Historico]?.ToString() ?? string.Empty; m_FHistorico = dbRec[DBLivroCaixaDicInfo.Historico]?.ToString() ?? string.Empty;  } catch {}  try { m_FHistorico = dbRec[DBLivroCaixaDicInfo.Historico]?.ToString() ?? string.Empty; m_FHistorico = dbRec[DBLivroCaixaDicInfo.Historico]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FHistorico = dbRec[DBLivroCaixaDicInfo.Historico]?.ToString() ?? string.Empty; } catch { }

#else
        m_FHistorico = dbRec[DBLivroCaixaDicInfo.Historico]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Previsto])) m_FPrevisto = (bool)dbRec[DBLivroCaixaDicInfo.Previsto]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Previsto])) m_FPrevisto = (bool)dbRec[DBLivroCaixaDicInfo.Previsto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Previsto])) m_FPrevisto = (bool)dbRec[DBLivroCaixaDicInfo.Previsto]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Previsto])) m_FPrevisto = (bool)dbRec[DBLivroCaixaDicInfo.Previsto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Previsto])) m_FPrevisto = (bool)dbRec[DBLivroCaixaDicInfo.Previsto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Previsto]))
            m_FPrevisto = (bool)dbRec[DBLivroCaixaDicInfo.Previsto];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Grupo]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Grupo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Grupo]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Grupo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Grupo])) m_FGrupo = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Grupo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Grupo]))
            m_FGrupo = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.Grupo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBLivroCaixaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBLivroCaixaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLivroCaixaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLivroCaixaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLivroCaixaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLivroCaixaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBLivroCaixaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBLivroCaixaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBLivroCaixaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}