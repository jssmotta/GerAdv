namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPosicaoOutrasPartes
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBPosicaoOutrasPartesDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBPosicaoOutrasPartesDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBPosicaoOutrasPartesDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBPosicaoOutrasPartesDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPosicaoOutrasPartesDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBPosicaoOutrasPartesDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPosicaoOutrasPartesDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBPosicaoOutrasPartesDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBPosicaoOutrasPartesDicInfo.Descricao => NFDescricao(),
        DBPosicaoOutrasPartesDicInfo.Bold => FBold.ToString(),
        DBPosicaoOutrasPartesDicInfo.GUID => NFGUID(),
        DBPosicaoOutrasPartesDicInfo.QuemCad => NFQuemCad(),
        DBPosicaoOutrasPartesDicInfo.DtCad => MDtCad,
        DBPosicaoOutrasPartesDicInfo.QuemAtu => NFQuemAtu(),
        DBPosicaoOutrasPartesDicInfo.DtAtu => MDtAtu,
        DBPosicaoOutrasPartesDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}