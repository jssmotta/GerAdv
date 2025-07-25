// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBFuncionarios : VAuditor, ICadastros, IAuditor
{
#region TableDefinition_Funcionarios
    [XmlIgnore]
    public string TabelaNome => "Funcionarios";

    public DBFuncionarios()
    {
    }

#endregion
    public DBFuncionarios(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
    {
        // Tracking: 250605-0
        if (oCnn is null)
            return;
        if (string.IsNullOrEmpty(fullSql) && !string.IsNullOrEmpty(cNome))
        {
            if (cNome is null)
            {
                return;
            }

            sqlWhere = cNome;
        }

        if (sqlWhere.NotIsEmpty() || fullSql.NotIsEmpty())
        {
            using var ds = ConfiguracoesDBT.GetDataTable(parameters, fullSql.IsEmpty() ? $"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) {join}  WHERE {sqlWhere};" : fullSql, CommandBehavior.SingleRow, oCnn);
            if (ds != null)
                CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
        }
        else
        {
            using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [{CampoNome}]  COLLATE SQL_Latin1_General_CP1_CI_AI  like @CampoNome", oCnn?.InnerConnection);
            cmd.Parameters.AddWithValue("@CampoNome", cNome?.trim() ?? string.Empty);
            using var ds = ConfiguracoesDBT.GetDataTable(cmd, CommandBehavior.SingleRow, oCnn);
            if (ds != null)
                CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
        }
    }

    // ReSharper disable once UnusedParameter.Local
    public DBFuncionarios(in string? sqlWhere, MsiSqlConnection? oCnn)
    {
        using var ds = ConfiguracoesDBT.GetDataTable($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome} (NOLOCK) WHERE {sqlWhere};", CommandBehavior.SingleRow, oCnn);
        if (ds != null)
            CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
    }

#region GravarDados_Funcionarios
    internal int Update(MsiSqlConnection? oCnn, int insertId = 0)
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFEMailPro || pFldFCargo || pFldFNome || pFldFFuncao || pFldFSexo || pFldFRegistro || pFldFCPF || pFldFRG || pFldFTipo || pFldFObservacao || pFldFEndereco || pFldFBairro || pFldFCidade || pFldFCEP || pFldFContato || pFldFFax || pFldFFone || pFldFEMail || pFldFPeriodo_Ini || pFldFPeriodo_Fim || pFldFCTPSNumero || pFldFCTPSSerie || pFldFPIS || pFldFSalario || pFldFCTPSDtEmissao || pFldFDtNasc || pFldFData || pFldFLiberaAgenda || pFldFPasta || pFldFClass || pFldFEtiqueta || pFldFAni || pFldFBold))
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
        if (this.FNome.IsEmpty())
        {
            // Validação preventiva por que ao chegar aqui já passou por outras fases
            throw new Exception("Campo 'Nome' está vazio!");
        }

        var clsW = new DBToolWTable32(PTabelaNome, CampoCodigo, ID == 0)
        {
            IsMachineCode = true
        };
        if (clsW.Insert)
        {
            if (insertId == 0)
            {
            }
            else
            {
            }
        }
        else
        {
            clsW.Where = $"{CampoCodigo}={ID}";
        }

        if (string.IsNullOrEmpty(m_FGUID))
            FGUID = Guid.NewGuid().ToString();
        if (pFldFEMailPro)
            clsW.Fields(DBFuncionariosDicInfo.EMailPro, m_FEMailPro, ETiposCampos.FString);
        if (pFldFCargo)
            clsW.Fields(DBFuncionariosDicInfo.Cargo, m_FCargo, ETiposCampos.FNumberNull);
        if (pFldFNome)
            clsW.Fields(DBFuncionariosDicInfo.Nome, m_FNome, ETiposCampos.FString);
        if (pFldFFuncao)
            clsW.Fields(DBFuncionariosDicInfo.Funcao, m_FFuncao, ETiposCampos.FNumberNull);
        if (pFldFSexo || ID.IsEmptyIDNumber())
            clsW.Fields(DBFuncionariosDicInfo.Sexo, m_FSexo, ETiposCampos.FBoolean);
        if (pFldFRegistro)
            clsW.Fields(DBFuncionariosDicInfo.Registro, m_FRegistro, ETiposCampos.FString);
        if (pFldFCPF)
            clsW.Fields(DBFuncionariosDicInfo.CPF, m_FCPF, ETiposCampos.FString);
        if (pFldFRG)
            clsW.Fields(DBFuncionariosDicInfo.RG, m_FRG, ETiposCampos.FString);
        if (pFldFTipo || ID.IsEmptyIDNumber())
            clsW.Fields(DBFuncionariosDicInfo.Tipo, m_FTipo, ETiposCampos.FBoolean);
        if (pFldFObservacao)
            clsW.Fields(DBFuncionariosDicInfo.Observacao, m_FObservacao, ETiposCampos.FString);
        if (pFldFEndereco)
            clsW.Fields(DBFuncionariosDicInfo.Endereco, m_FEndereco, ETiposCampos.FString);
        if (pFldFBairro)
            clsW.Fields(DBFuncionariosDicInfo.Bairro, m_FBairro, ETiposCampos.FString);
        if (pFldFCidade)
            clsW.Fields(DBFuncionariosDicInfo.Cidade, m_FCidade, ETiposCampos.FNumberNull);
        if (pFldFCEP)
            clsW.Fields(DBFuncionariosDicInfo.CEP, m_FCEP, ETiposCampos.FString);
        if (pFldFContato)
            clsW.Fields(DBFuncionariosDicInfo.Contato, m_FContato, ETiposCampos.FString);
        if (pFldFFax)
            clsW.Fields(DBFuncionariosDicInfo.Fax, m_FFax, ETiposCampos.FString);
        if (pFldFFone)
            clsW.Fields(DBFuncionariosDicInfo.Fone, m_FFone, ETiposCampos.FString);
        if (pFldFEMail)
            clsW.Fields(DBFuncionariosDicInfo.EMail, m_FEMail, ETiposCampos.FString);
        if (pFldFPeriodo_Ini)
            clsW.Fields(DBFuncionariosDicInfo.Periodo_Ini, m_FPeriodo_Ini, ETiposCampos.FDate);
        if (pFldFPeriodo_Fim)
            clsW.Fields(DBFuncionariosDicInfo.Periodo_Fim, m_FPeriodo_Fim, ETiposCampos.FDate);
        if (pFldFCTPSNumero)
            clsW.Fields(DBFuncionariosDicInfo.CTPSNumero, m_FCTPSNumero, ETiposCampos.FString);
        if (pFldFCTPSSerie)
            clsW.Fields(DBFuncionariosDicInfo.CTPSSerie, m_FCTPSSerie, ETiposCampos.FString);
        if (pFldFPIS)
            clsW.Fields(DBFuncionariosDicInfo.PIS, m_FPIS, ETiposCampos.FString);
        if (pFldFSalario)
            clsW.Fields(DBFuncionariosDicInfo.Salario, m_FSalario, ETiposCampos.FDecimal);
        if (pFldFCTPSDtEmissao)
            clsW.Fields(DBFuncionariosDicInfo.CTPSDtEmissao, m_FCTPSDtEmissao, ETiposCampos.FDate);
        if (pFldFDtNasc)
            clsW.Fields(DBFuncionariosDicInfo.DtNasc, m_FDtNasc, ETiposCampos.FDate);
        if (pFldFData)
            clsW.Fields(DBFuncionariosDicInfo.Data, m_FData, ETiposCampos.FDate);
        if (pFldFLiberaAgenda || ID.IsEmptyIDNumber())
            clsW.Fields(DBFuncionariosDicInfo.LiberaAgenda, m_FLiberaAgenda, ETiposCampos.FBoolean);
        if (pFldFPasta)
            clsW.Fields(DBFuncionariosDicInfo.Pasta, m_FPasta, ETiposCampos.FString);
        if (pFldFClass)
            clsW.Fields(DBFuncionariosDicInfo.Class, m_FClass, ETiposCampos.FString);
        if (pFldFEtiqueta || ID.IsEmptyIDNumber())
            clsW.Fields(DBFuncionariosDicInfo.Etiqueta, m_FEtiqueta, ETiposCampos.FBoolean);
        if (pFldFAni || ID.IsEmptyIDNumber())
            clsW.Fields(DBFuncionariosDicInfo.Ani, m_FAni, ETiposCampos.FBoolean);
        if (pFldFBold || ID.IsEmptyIDNumber())
            clsW.Fields(DBFuncionariosDicInfo.Bold, m_FBold, ETiposCampos.FBoolean);
        if (pFldFGUID)
            clsW.Fields(DBFuncionariosDicInfo.GUID, m_FGUID, ETiposCampos.FString);
#if (!shadowsDisabled && !shadows_MenphisSI_SG_GerAdv && !shadows_MenphisSI_SG_GerAdv_Funcionarios)
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
            clsW.Fields(DBFuncionariosDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBFuncionariosDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBFuncionariosDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBFuncionariosDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBFuncionariosDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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
            clsW.Fields(CampoCodigo, insertId, ETiposCampos.FNumber);
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