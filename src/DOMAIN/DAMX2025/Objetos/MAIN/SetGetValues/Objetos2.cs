namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBObjetos
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBObjetosDicInfo.Justica:
                FJustica = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBObjetosDicInfo.Area:
                FArea = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBObjetosDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBObjetosDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBObjetosDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBObjetosDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBObjetosDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBObjetosDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBObjetosDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBObjetosDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBObjetosDicInfo.Justica => NFJustica(),
        DBObjetosDicInfo.Area => NFArea(),
        DBObjetosDicInfo.Nome => NFNome(),
        DBObjetosDicInfo.Bold => FBold.ToString(),
        DBObjetosDicInfo.GUID => NFGUID(),
        DBObjetosDicInfo.QuemCad => NFQuemCad(),
        DBObjetosDicInfo.DtCad => MDtCad,
        DBObjetosDicInfo.QuemAtu => NFQuemAtu(),
        DBObjetosDicInfo.DtAtu => MDtAtu,
        DBObjetosDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}