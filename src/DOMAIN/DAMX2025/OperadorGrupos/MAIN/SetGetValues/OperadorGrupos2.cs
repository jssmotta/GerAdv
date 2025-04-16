namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOperadorGrupos
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBOperadorGruposDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBOperadorGruposDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorGruposDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBOperadorGruposDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorGruposDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBOperadorGruposDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBOperadorGruposDicInfo.Nome => NFNome(),
        DBOperadorGruposDicInfo.QuemCad => NFQuemCad(),
        DBOperadorGruposDicInfo.DtCad => MDtCad,
        DBOperadorGruposDicInfo.QuemAtu => NFQuemAtu(),
        DBOperadorGruposDicInfo.DtAtu => MDtAtu,
        DBOperadorGruposDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}