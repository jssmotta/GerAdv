namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBEnquadramentoEmpresa
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBEnquadramentoEmpresaDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBEnquadramentoEmpresaDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBEnquadramentoEmpresaDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBEnquadramentoEmpresaDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBEnquadramentoEmpresaDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBEnquadramentoEmpresaDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBEnquadramentoEmpresaDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBEnquadramentoEmpresaDicInfo.Nome => NFNome(),
        DBEnquadramentoEmpresaDicInfo.GUID => NFGUID(),
        DBEnquadramentoEmpresaDicInfo.QuemCad => NFQuemCad(),
        DBEnquadramentoEmpresaDicInfo.DtCad => MDtCad,
        DBEnquadramentoEmpresaDicInfo.QuemAtu => NFQuemAtu(),
        DBEnquadramentoEmpresaDicInfo.DtAtu => MDtAtu,
        DBEnquadramentoEmpresaDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}