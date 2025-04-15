namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTipoEnderecoSistema
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBTipoEnderecoSistemaDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBTipoEnderecoSistemaDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBTipoEnderecoSistemaDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTipoEnderecoSistemaDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBTipoEnderecoSistemaDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTipoEnderecoSistemaDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBTipoEnderecoSistemaDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBTipoEnderecoSistemaDicInfo.Nome => NFNome(),
        DBTipoEnderecoSistemaDicInfo.GUID => NFGUID(),
        DBTipoEnderecoSistemaDicInfo.QuemCad => NFQuemCad(),
        DBTipoEnderecoSistemaDicInfo.DtCad => MDtCad,
        DBTipoEnderecoSistemaDicInfo.QuemAtu => NFQuemAtu(),
        DBTipoEnderecoSistemaDicInfo.DtAtu => MDtAtu,
        DBTipoEnderecoSistemaDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}