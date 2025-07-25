// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBAgendaRepetir : VAuditor, ICadastros, IAuditor
{
#region TableDefinition_AgendaRepetir
    [XmlIgnore]
    public string TabelaNome => "AgendaRepetir";

    public DBAgendaRepetir()
    {
    }

#endregion
    // REF. 250325
    public DBAgendaRepetir(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "")
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
                throw new Exception("Erro de parâmetros sqlWhere: AgendaRepetir");
            }
        }
        else
        {
            using var ds = ConfiguracoesDBT.GetDataTable(fullSql, CommandBehavior.SingleRow, oCnn);
            if (ds != null)
                CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
        }
    }

#region GravarDados_AgendaRepetir
    internal int Update(MsiSqlConnection? oCnn, int insertId = 0)
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFAdvogado || pFldFCliente || pFldFDataFinal || pFldFFuncionario || pFldFHoraFinal || pFldFProcesso || pFldFPessoal || pFldFFrequencia || pFldFDia || pFldFMes || pFldFHora || pFldFIDQuem || pFldFIDQuem2 || pFldFMensagem || pFldFIDTipo || pFldFID1 || pFldFID2 || pFldFID3 || pFldFID4 || pFldFSegunda || pFldFQuarta || pFldFQuinta || pFldFSexta || pFldFSabado || pFldFDomingo || pFldFTerca))
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

        if (pFldFAdvogado)
            clsW.Fields(DBAgendaRepetirDicInfo.Advogado, m_FAdvogado, ETiposCampos.FNumberNull);
        if (pFldFCliente)
            clsW.Fields(DBAgendaRepetirDicInfo.Cliente, m_FCliente, ETiposCampos.FNumberNull);
        if (pFldFDataFinal)
            clsW.Fields(DBAgendaRepetirDicInfo.DataFinal, m_FDataFinal, ETiposCampos.FDate);
        if (pFldFFuncionario)
            clsW.Fields(DBAgendaRepetirDicInfo.Funcionario, m_FFuncionario, ETiposCampos.FNumberNull);
        if (pFldFHoraFinal)
            clsW.Fields(DBAgendaRepetirDicInfo.HoraFinal, m_FHoraFinal, ETiposCampos.FDate);
        if (pFldFProcesso)
            clsW.Fields(DBAgendaRepetirDicInfo.Processo, m_FProcesso, ETiposCampos.FNumberNull);
        if (pFldFPessoal || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaRepetirDicInfo.Pessoal, m_FPessoal, ETiposCampos.FBoolean);
        if (pFldFFrequencia)
            clsW.Fields(DBAgendaRepetirDicInfo.Frequencia, m_FFrequencia, ETiposCampos.FNumberNull);
        if (pFldFDia)
            clsW.Fields(DBAgendaRepetirDicInfo.Dia, m_FDia, ETiposCampos.FNumberNull);
        if (pFldFMes)
            clsW.Fields(DBAgendaRepetirDicInfo.Mes, m_FMes, ETiposCampos.FNumberNull);
        if (pFldFHora)
            clsW.Fields(DBAgendaRepetirDicInfo.Hora, m_FHora, ETiposCampos.FDate);
        if (pFldFIDQuem)
            clsW.Fields(DBAgendaRepetirDicInfo.IDQuem, m_FIDQuem, ETiposCampos.FNumberNull);
        if (pFldFIDQuem2)
            clsW.Fields(DBAgendaRepetirDicInfo.IDQuem2, m_FIDQuem2, ETiposCampos.FNumberNull);
        if (pFldFMensagem)
            clsW.Fields(DBAgendaRepetirDicInfo.Mensagem, m_FMensagem, ETiposCampos.FString);
        if (pFldFIDTipo)
            clsW.Fields(DBAgendaRepetirDicInfo.IDTipo, m_FIDTipo, ETiposCampos.FNumberNull);
        if (pFldFID1)
            clsW.Fields(DBAgendaRepetirDicInfo.ID1, m_FID1, ETiposCampos.FNumberNull);
        if (pFldFID2)
            clsW.Fields(DBAgendaRepetirDicInfo.ID2, m_FID2, ETiposCampos.FNumberNull);
        if (pFldFID3)
            clsW.Fields(DBAgendaRepetirDicInfo.ID3, m_FID3, ETiposCampos.FNumberNull);
        if (pFldFID4)
            clsW.Fields(DBAgendaRepetirDicInfo.ID4, m_FID4, ETiposCampos.FNumberNull);
        if (pFldFSegunda || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaRepetirDicInfo.Segunda, m_FSegunda, ETiposCampos.FBoolean);
        if (pFldFQuarta || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaRepetirDicInfo.Quarta, m_FQuarta, ETiposCampos.FBoolean);
        if (pFldFQuinta || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaRepetirDicInfo.Quinta, m_FQuinta, ETiposCampos.FBoolean);
        if (pFldFSexta || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaRepetirDicInfo.Sexta, m_FSexta, ETiposCampos.FBoolean);
        if (pFldFSabado || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaRepetirDicInfo.Sabado, m_FSabado, ETiposCampos.FBoolean);
        if (pFldFDomingo || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaRepetirDicInfo.Domingo, m_FDomingo, ETiposCampos.FBoolean);
        if (pFldFTerca || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaRepetirDicInfo.Terca, m_FTerca, ETiposCampos.FBoolean);
#if (!shadowsDisabled && !shadows_MenphisSI_SG_GerAdv && !shadows_MenphisSI_SG_GerAdv_AgendaRepetir)
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
            clsW.Fields(DBAgendaRepetirDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBAgendaRepetirDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBAgendaRepetirDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBAgendaRepetirDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBAgendaRepetirDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
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