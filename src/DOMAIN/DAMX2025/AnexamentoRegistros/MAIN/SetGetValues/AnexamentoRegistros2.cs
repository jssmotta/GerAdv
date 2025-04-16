namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAnexamentoRegistros
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBAnexamentoRegistrosDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAnexamentoRegistrosDicInfo.GUIDReg:
                FGUIDReg = $"{value}"; // rgo J3: string
                return;
            case DBAnexamentoRegistrosDicInfo.CodigoReg:
                FCodigoReg = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAnexamentoRegistrosDicInfo.IDReg:
                FIDReg = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAnexamentoRegistrosDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBAnexamentoRegistrosDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBAnexamentoRegistrosDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAnexamentoRegistrosDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBAnexamentoRegistrosDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAnexamentoRegistrosDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBAnexamentoRegistrosDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBAnexamentoRegistrosDicInfo.Cliente => NFCliente(),
        DBAnexamentoRegistrosDicInfo.GUIDReg => NFGUIDReg(),
        DBAnexamentoRegistrosDicInfo.CodigoReg => NFCodigoReg(),
        DBAnexamentoRegistrosDicInfo.IDReg => NFIDReg(),
        DBAnexamentoRegistrosDicInfo.Data => NFData(),
        DBAnexamentoRegistrosDicInfo.GUID => NFGUID(),
        DBAnexamentoRegistrosDicInfo.QuemCad => NFQuemCad(),
        DBAnexamentoRegistrosDicInfo.DtCad => MDtCad,
        DBAnexamentoRegistrosDicInfo.QuemAtu => NFQuemAtu(),
        DBAnexamentoRegistrosDicInfo.DtAtu => MDtAtu,
        DBAnexamentoRegistrosDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}