namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGruposEmpresasCli
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBGruposEmpresasCliDicInfo.Grupo:
                FGrupo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGruposEmpresasCliDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGruposEmpresasCliDicInfo.Oculto:
                FOculto = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBGruposEmpresasCliDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGruposEmpresasCliDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBGruposEmpresasCliDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGruposEmpresasCliDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBGruposEmpresasCliDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBGruposEmpresasCliDicInfo.Grupo => NFGrupo(),
        DBGruposEmpresasCliDicInfo.Cliente => NFCliente(),
        DBGruposEmpresasCliDicInfo.Oculto => FOculto.ToString(),
        DBGruposEmpresasCliDicInfo.QuemCad => NFQuemCad(),
        DBGruposEmpresasCliDicInfo.DtCad => MDtCad,
        DBGruposEmpresasCliDicInfo.QuemAtu => NFQuemAtu(),
        DBGruposEmpresasCliDicInfo.DtAtu => MDtAtu,
        DBGruposEmpresasCliDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}