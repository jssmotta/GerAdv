namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPoderJudiciarioAssociado
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBPoderJudiciarioAssociadoDicInfo.Justica:
                FJustica = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPoderJudiciarioAssociadoDicInfo.JusticaNome:
                FJusticaNome = $"{value}"; // rgo J3: string
                return;
            case DBPoderJudiciarioAssociadoDicInfo.Area:
                FArea = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPoderJudiciarioAssociadoDicInfo.AreaNome:
                FAreaNome = $"{value}"; // rgo J3: string
                return;
            case DBPoderJudiciarioAssociadoDicInfo.Tribunal:
                FTribunal = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPoderJudiciarioAssociadoDicInfo.TribunalNome:
                FTribunalNome = $"{value}"; // rgo J3: string
                return;
            case DBPoderJudiciarioAssociadoDicInfo.Foro:
                FForo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPoderJudiciarioAssociadoDicInfo.ForoNome:
                FForoNome = $"{value}"; // rgo J3: string
                return;
            case DBPoderJudiciarioAssociadoDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome:
                FSubDivisaoNome = $"{value}"; // rgo J3: string
                return;
            case DBPoderJudiciarioAssociadoDicInfo.CidadeNome:
                FCidadeNome = $"{value}"; // rgo J3: string
                return;
            case DBPoderJudiciarioAssociadoDicInfo.SubDivisao:
                FSubDivisao = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPoderJudiciarioAssociadoDicInfo.Tipo:
                FTipo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPoderJudiciarioAssociadoDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBPoderJudiciarioAssociadoDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPoderJudiciarioAssociadoDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBPoderJudiciarioAssociadoDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPoderJudiciarioAssociadoDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBPoderJudiciarioAssociadoDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBPoderJudiciarioAssociadoDicInfo.Justica => NFJustica(),
        DBPoderJudiciarioAssociadoDicInfo.JusticaNome => NFJusticaNome(),
        DBPoderJudiciarioAssociadoDicInfo.Area => NFArea(),
        DBPoderJudiciarioAssociadoDicInfo.AreaNome => NFAreaNome(),
        DBPoderJudiciarioAssociadoDicInfo.Tribunal => NFTribunal(),
        DBPoderJudiciarioAssociadoDicInfo.TribunalNome => NFTribunalNome(),
        DBPoderJudiciarioAssociadoDicInfo.Foro => NFForo(),
        DBPoderJudiciarioAssociadoDicInfo.ForoNome => NFForoNome(),
        DBPoderJudiciarioAssociadoDicInfo.Cidade => NFCidade(),
        DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome => NFSubDivisaoNome(),
        DBPoderJudiciarioAssociadoDicInfo.CidadeNome => NFCidadeNome(),
        DBPoderJudiciarioAssociadoDicInfo.SubDivisao => NFSubDivisao(),
        DBPoderJudiciarioAssociadoDicInfo.Tipo => NFTipo(),
        DBPoderJudiciarioAssociadoDicInfo.GUID => NFGUID(),
        DBPoderJudiciarioAssociadoDicInfo.QuemCad => NFQuemCad(),
        DBPoderJudiciarioAssociadoDicInfo.DtCad => MDtCad,
        DBPoderJudiciarioAssociadoDicInfo.QuemAtu => NFQuemAtu(),
        DBPoderJudiciarioAssociadoDicInfo.DtAtu => MDtAtu,
        DBPoderJudiciarioAssociadoDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}