namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBNEPalavrasChaves
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBNEPalavrasChavesDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBNEPalavrasChavesDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBNEPalavrasChavesDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBNEPalavrasChavesDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBNEPalavrasChavesDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBNEPalavrasChavesDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBNEPalavrasChavesDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBNEPalavrasChavesDicInfo.Nome => NFNome(),
        DBNEPalavrasChavesDicInfo.Bold => FBold.ToString(),
        DBNEPalavrasChavesDicInfo.QuemCad => NFQuemCad(),
        DBNEPalavrasChavesDicInfo.DtCad => MDtCad,
        DBNEPalavrasChavesDicInfo.QuemAtu => NFQuemAtu(),
        DBNEPalavrasChavesDicInfo.DtAtu => MDtAtu,
        DBNEPalavrasChavesDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}