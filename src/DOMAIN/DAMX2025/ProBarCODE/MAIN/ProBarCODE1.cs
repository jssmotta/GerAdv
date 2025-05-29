// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBProBarCODE : VAuditor, ICadastros, IAuditor
{
#if (DEBUG)
#if (!shadowsDisabled && !shadows_MenphisSI_GerAdv && !shadows_MenphisSI_GerAdv_ProBarCODE)
#pragma warning disable CA1822 // Mark members as static

//public bool CertSignature() => DicionarioDeDadosManagedDatabaseCode.CodeSigntature_DBProBarCODE();
#pragma warning restore CA1822 // Mark members as static

#endif
#endif
#region TableDefinition_ProBarCODE
    [XmlIgnore]
    public string TabelaNome => "ProBarCODE";

    public DBProBarCODE()
    {
    }

#endregion
#if (forWeb)
public int Update(MsiSqlConnection? oCnn = null, int insertId = 0)
{
    if (oCnn != null) return UpdateX(oCnn, insertId);
    using var cnn = Configuracoes.GetConnectionRw();
    return UpdateX(cnn, insertId);
}
#endif
#region GravarDados_ProBarCODE
#if (forWeb)
                private int UpdateX(MsiSqlConnection? oCnn, int insertId = 0)
#else
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
#endif
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFBarCODE || pFldFProcesso))
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
        var clsW = new DBToolWTable32(PTabelaNome, ID == 0)
        {
            IsMachineCode = true
        };
        if (clsW.Insert)
        {
            if (clsW.Insert && insertId != 0)
            {
                throw new Exception("Tentativa se inserir um código em uma tabela sem CampoCodigo");
            }
        }
        else
        {
        }

        if (pFldFBarCODE)
            clsW.Fields(DBProBarCODEDicInfo.BarCODE, m_FBarCODE, ETiposCampos.FString);
        if (pFldFProcesso)
            clsW.Fields(DBProBarCODEDicInfo.Processo, m_FProcesso, ETiposCampos.FNumberNull);
        if (m_AuditorQuem == 0)
            AuditorQuem = 1;
        if (pFldFQuemCad)
            clsW.Fields(DBProBarCODEDicInfo.QuemCad, m_FQuemCad, ETiposCampos.FNumberNull);
        if (pFldFDtCad)
            clsW.Fields(DBProBarCODEDicInfo.DtCad, m_FDtCad, ETiposCampos.FDate);
        if (pFldFQuemAtu)
            clsW.Fields(DBProBarCODEDicInfo.QuemAtu, m_FQuemAtu, ETiposCampos.FNumberNull);
        if (pFldFDtAtu)
            clsW.Fields(DBProBarCODEDicInfo.DtAtu, m_FDtAtu, ETiposCampos.FDate);
        if (pFldFVisto || ID.IsEmptyIDNumber())
            clsW.Fields(DBProBarCODEDicInfo.Visto, m_FVisto, ETiposCampos.FBoolean);
        if (insertId != 0)
            return GravaNewId();
        var cRet = clsW.RecUpdate(oCnn);
        if (!clsW.Insert)
            return Error;
        if (!cRet.Equals("OK"))
            return Error;
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