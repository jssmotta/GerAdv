namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGraph
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBGraphDicInfo.Tabela:
                FTabela = $"{value}"; // rgo J3: string
                return;
            case DBGraphDicInfo.TabelaId:
                FTabelaId = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGraphDicInfo.Imagem:
                if (value != null)
                    FImagem = value as byte[] ?? []; // rgo J3: byte[]
                return;
            case DBGraphDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBGraphDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGraphDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBGraphDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGraphDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBGraphDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBGraphDicInfo.Tabela => NFTabela(),
        DBGraphDicInfo.TabelaId => NFTabelaId(),
        DBGraphDicInfo.Imagem => NFImagem(),
        DBGraphDicInfo.GUID => NFGUID(),
        DBGraphDicInfo.QuemCad => NFQuemCad(),
        DBGraphDicInfo.DtCad => MDtCad,
        DBGraphDicInfo.QuemAtu => NFQuemAtu(),
        DBGraphDicInfo.DtAtu => MDtAtu,
        DBGraphDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}