// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBParteCliente : XCodeIdBase, ICadastros
{
#region TableDefinition_ParteCliente
    [XmlIgnore]
    public string TabelaNome => "ParteCliente";

    public DBParteCliente()
    {
    }

#endregion
#region GravarDados_ParteCliente
    public int Update(MsiSqlConnection? oCnn, int insertId = 0)
    {
        var isInsert = insertId == 0 && ID == 0;
        if (!isInsert)
            if (!(pFldFCliente || pFldFProcesso))
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

        if (pFldFCliente)
            clsW.Fields(DBParteClienteDicInfo.Cliente, m_FCliente, ETiposCampos.FNumberNull);
        if (pFldFProcesso)
            clsW.Fields(DBParteClienteDicInfo.Processo, m_FProcesso, ETiposCampos.FNumberNull);
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