namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBDocsRecebidosItens
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBDocsRecebidosItensDicInfo.ContatoCRM:
                FContatoCRM = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBDocsRecebidosItensDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBDocsRecebidosItensDicInfo.Devolvido:
                FDevolvido = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBDocsRecebidosItensDicInfo.SeraDevolvido:
                FSeraDevolvido = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBDocsRecebidosItensDicInfo.Observacoes:
                FObservacoes = $"{value}"; // rgo J3: string
                return;
            case DBDocsRecebidosItensDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBDocsRecebidosItensDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBDocsRecebidosItensDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBDocsRecebidosItensDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBDocsRecebidosItensDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBDocsRecebidosItensDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBDocsRecebidosItensDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBDocsRecebidosItensDicInfo.ContatoCRM => NFContatoCRM(),
        DBDocsRecebidosItensDicInfo.Nome => NFNome(),
        DBDocsRecebidosItensDicInfo.Devolvido => FDevolvido.ToString(),
        DBDocsRecebidosItensDicInfo.SeraDevolvido => FSeraDevolvido.ToString(),
        DBDocsRecebidosItensDicInfo.Observacoes => NFObservacoes(),
        DBDocsRecebidosItensDicInfo.Bold => FBold.ToString(),
        DBDocsRecebidosItensDicInfo.GUID => NFGUID(),
        DBDocsRecebidosItensDicInfo.QuemCad => NFQuemCad(),
        DBDocsRecebidosItensDicInfo.DtCad => MDtCad,
        DBDocsRecebidosItensDicInfo.QuemAtu => NFQuemAtu(),
        DBDocsRecebidosItensDicInfo.DtAtu => MDtAtu,
        DBDocsRecebidosItensDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}