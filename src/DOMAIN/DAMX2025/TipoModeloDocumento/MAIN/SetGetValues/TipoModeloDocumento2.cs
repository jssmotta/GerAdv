namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTipoModeloDocumento
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBTipoModeloDocumentoDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBTipoModeloDocumentoDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBTipoModeloDocumentoDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTipoModeloDocumentoDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBTipoModeloDocumentoDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTipoModeloDocumentoDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBTipoModeloDocumentoDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBTipoModeloDocumentoDicInfo.Nome => NFNome(),
        DBTipoModeloDocumentoDicInfo.GUID => NFGUID(),
        DBTipoModeloDocumentoDicInfo.QuemCad => NFQuemCad(),
        DBTipoModeloDocumentoDicInfo.DtCad => MDtCad,
        DBTipoModeloDocumentoDicInfo.QuemAtu => NFQuemAtu(),
        DBTipoModeloDocumentoDicInfo.DtAtu => MDtAtu,
        DBTipoModeloDocumentoDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}