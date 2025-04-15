namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTipoRecurso
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBTipoRecursoDicInfo.Justica:
                FJustica = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTipoRecursoDicInfo.Area:
                FArea = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTipoRecursoDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBTipoRecursoDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBTipoRecursoDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTipoRecursoDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBTipoRecursoDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTipoRecursoDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBTipoRecursoDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBTipoRecursoDicInfo.Justica => NFJustica(),
        DBTipoRecursoDicInfo.Area => NFArea(),
        DBTipoRecursoDicInfo.Descricao => NFDescricao(),
        DBTipoRecursoDicInfo.GUID => NFGUID(),
        DBTipoRecursoDicInfo.QuemCad => NFQuemCad(),
        DBTipoRecursoDicInfo.DtCad => MDtCad,
        DBTipoRecursoDicInfo.QuemAtu => NFQuemAtu(),
        DBTipoRecursoDicInfo.DtAtu => MDtAtu,
        DBTipoRecursoDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}