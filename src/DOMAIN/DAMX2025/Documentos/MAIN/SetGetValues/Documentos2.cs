namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBDocumentos
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBDocumentosDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBDocumentosDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBDocumentosDicInfo.Observacao:
                FObservacao = $"{value}"; // rgo J3: string
                return;
            case DBDocumentosDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBDocumentosDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBDocumentosDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBDocumentosDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBDocumentosDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBDocumentosDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBDocumentosDicInfo.Processo => NFProcesso(),
        DBDocumentosDicInfo.Data => NFData(),
        DBDocumentosDicInfo.Observacao => NFObservacao(),
        DBDocumentosDicInfo.GUID => NFGUID(),
        DBDocumentosDicInfo.QuemCad => NFQuemCad(),
        DBDocumentosDicInfo.DtCad => MDtCad,
        DBDocumentosDicInfo.QuemAtu => NFQuemAtu(),
        DBDocumentosDicInfo.DtAtu => MDtAtu,
        DBDocumentosDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}