// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBEnderecoSistema : VAuditor, ICadastros, IAuditor
{
#region TableDefinition_EnderecoSistema
    [XmlIgnore]
    public string TabelaNome => "EnderecoSistema";

    public DBEnderecoSistema()
    {
    }

#endregion
    // REF. 250325
    public DBEnderecoSistema(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
    {
        // Tracking: 250605-3
        if (oCnn is null)
            return;
        if (string.IsNullOrEmpty(fullSql))
        {
            if (sqlWhere.NotIsEmpty() || fullSql.NotIsEmpty())
            {
                using var ds = ConfiguracoesDBT.GetDataTable(parameters, fullSql.IsEmpty() ? $"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) {join}  WHERE {sqlWhere};" : fullSql, CommandBehavior.SingleRow, oCnn);
                if (ds != null)
                    CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
            }
            else
            {
                throw new Exception("Erro de parâmetros sqlWhere: EnderecoSistema");
            }
        }
        else
        {
            using var ds = ConfiguracoesDBT.GetDataTable(fullSql, CommandBehavior.SingleRow, oCnn);
            if (ds != null)
                CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
        }
    }

#region GravarDados_EnderecoSistema
    internal int Update(MsiSqlConnection? oCnn, int insertId = 0)
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFCadastro || pFldFCadastroExCod || pFldFTipoEnderecoSistema || pFldFProcesso || pFldFMotivo || pFldFContatoNoLocal || pFldFCidade || pFldFEndereco || pFldFBairro || pFldFCEP || pFldFFone || pFldFFax || pFldFObservacao))
                return 0;
        if (oCnn is null)
#if (DEBUG)
			        {
				        PTabelaNome.PopupBox("oCnn is null - Update()");
#else
            return 0;
#endif
#if (DEBUG)
			         }
#endif
        var clsW = new DBToolWTable32(PTabelaNome, CampoCodigo, ID == 0)
        {
            IsMachineCode = true
        };
        if (clsW.Insert)
        {
        }
        else
        {
            clsW.Where = $"{CampoCodigo}={ID}";
        }

        if (string.IsNullOrEmpty(m_FGUID))
            FGUID = Guid.NewGuid().ToString();
        if (pFldFCadastro)
            clsW.Fields(DBEnderecoSistemaDicInfo.Cadastro, m_FCadastro, ETiposCampos.FNumberNull);
        if (pFldFCadastroExCod)
            clsW.Fields(DBEnderecoSistemaDicInfo.CadastroExCod, m_FCadastroExCod, ETiposCampos.FNumberNull);
        if (pFldFTipoEnderecoSistema)
            clsW.Fields(DBEnderecoSistemaDicInfo.TipoEnderecoSistema, m_FTipoEnderecoSistema, ETiposCampos.FNumberNull);
        if (pFldFProcesso)
            clsW.Fields(DBEnderecoSistemaDicInfo.Processo, m_FProcesso, ETiposCampos.FNumberNull);
        if (pFldFMotivo)
            clsW.Fields(DBEnderecoSistemaDicInfo.Motivo, m_FMotivo, ETiposCampos.FString);
        if (pFldFContatoNoLocal)
            clsW.Fields(DBEnderecoSistemaDicInfo.ContatoNoLocal, m_FContatoNoLocal, ETiposCampos.FString);
        if (pFldFCidade)
            clsW.Fields(DBEnderecoSistemaDicInfo.Cidade, m_FCidade, ETiposCampos.FNumberNull);
        if (pFldFEndereco)
            clsW.Fields(DBEnderecoSistemaDicInfo.Endereco, m_FEndereco, ETiposCampos.FString);
        if (pFldFBairro)
            clsW.Fields(DBEnderecoSistemaDicInfo.Bairro, m_FBairro, ETiposCampos.FString);
        if (pFldFCEP)
            clsW.Fields(DBEnderecoSistemaDicInfo.CEP, m_FCEP, ETiposCampos.FString);
        if (pFldFFone)
            clsW.Fields(DBEnderecoSistemaDicInfo.Fone, m_FFone, ETiposCampos.FString);
        if (pFldFFax)
            clsW.Fields(DBEnderecoSistemaDicInfo.Fax, m_FFax, ETiposCampos.FString);
        if (pFldFObservacao)
            clsW.Fields(DBEnderecoSistemaDicInfo.Observacao, m_FObservacao, ETiposCampos.FString);
        if (pFldFGUID)
            clsW.Fields(DBEnderecoSistemaDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_SG_GerAdv && !shadows_MenphisSI_SG_GerAdv_EnderecoSistema)
        if (clsW.HasUpdates)
        {
            HasChanges = true;
        }
        else if (ID != 0)
        {
            return 0;
        }

#endif
        if (m_AuditorQuem == 0)
            AuditorQuem = 1;
        if (pFldFQuemCad)
            clsW.Fields(DBEnderecoSistemaDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBEnderecoSistemaDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBEnderecoSistemaDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBEnderecoSistemaDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBEnderecoSistemaDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
        if (insertId != 0)
            return GravaNewId();
        var cRet = clsW.RecUpdate(oCnn);
        if (!clsW.Insert)
            return Error;
        if (!cRet.Equals("OK"))
            return Error;
        ID = clsW.GetCodigo();
        if (CampoCodigo.IsEmpty())
        {
        }
        else if (ID == 0)
        {
            Error = -2;
            ErrorDescription = "900xh100 - O registro não pode ser incluído, tente mais tarde.";
#if (!IgnoreExploreMSIDb)
            throw new Exception($"{clsW.Table} {clsW.LastError}, {ErrorDescription}, {cRet}");
#endif
        }

        int GravaNewId()
        {
            ID = insertId;
            cRet = clsW.RecUpdate(oCnn, true);
            if (cRet.Equals("OK"))
                return 0;
            ErrorDescription = "Erro de inclusão insertiva de Id!";
            return -3;
        }

        return Error;
    }
#endregion // 001

}