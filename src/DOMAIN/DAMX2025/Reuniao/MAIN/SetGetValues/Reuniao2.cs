namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBReuniao
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBReuniaoDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBReuniaoDicInfo.IDAgenda:
                FIDAgenda = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBReuniaoDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBReuniaoDicInfo.Pauta:
                FPauta = $"{value}"; // rgo J3: string
                return;
            case DBReuniaoDicInfo.ATA:
                FATA = $"{value}"; // rgo J3: string
                return;
            case DBReuniaoDicInfo.HoraInicial:
                FHoraInicial = $"{value}"; // rgo J3: DateTime
                return;
            case DBReuniaoDicInfo.HoraFinal:
                FHoraFinal = $"{value}"; // rgo J3: DateTime
                return;
            case DBReuniaoDicInfo.Externa:
                FExterna = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBReuniaoDicInfo.HoraSaida:
                FHoraSaida = $"{value}"; // rgo J3: DateTime
                return;
            case DBReuniaoDicInfo.HoraRetorno:
                FHoraRetorno = $"{value}"; // rgo J3: DateTime
                return;
            case DBReuniaoDicInfo.PrincipaisDecisoes:
                FPrincipaisDecisoes = $"{value}"; // rgo J3: string
                return;
            case DBReuniaoDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBReuniaoDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBReuniaoDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBReuniaoDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBReuniaoDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBReuniaoDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBReuniaoDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBReuniaoDicInfo.Cliente => NFCliente(),
        DBReuniaoDicInfo.IDAgenda => NFIDAgenda(),
        DBReuniaoDicInfo.Data => NFData(),
        DBReuniaoDicInfo.Pauta => NFPauta(),
        DBReuniaoDicInfo.ATA => NFATA(),
        DBReuniaoDicInfo.HoraInicial => NFHoraInicial(),
        DBReuniaoDicInfo.HoraFinal => NFHoraFinal(),
        DBReuniaoDicInfo.Externa => FExterna.ToString(),
        DBReuniaoDicInfo.HoraSaida => NFHoraSaida(),
        DBReuniaoDicInfo.HoraRetorno => NFHoraRetorno(),
        DBReuniaoDicInfo.PrincipaisDecisoes => NFPrincipaisDecisoes(),
        DBReuniaoDicInfo.Bold => FBold.ToString(),
        DBReuniaoDicInfo.GUID => NFGUID(),
        DBReuniaoDicInfo.QuemCad => NFQuemCad(),
        DBReuniaoDicInfo.DtCad => MDtCad,
        DBReuniaoDicInfo.QuemAtu => NFQuemAtu(),
        DBReuniaoDicInfo.DtAtu => MDtAtu,
        DBReuniaoDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}