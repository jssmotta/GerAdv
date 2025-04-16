namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAtividades
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBAtividadesDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBAtividadesDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBAtividadesDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAtividadesDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBAtividadesDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAtividadesDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBAtividadesDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBAtividadesDicInfo.Descricao => NFDescricao(),
        DBAtividadesDicInfo.GUID => NFGUID(),
        DBAtividadesDicInfo.QuemCad => NFQuemCad(),
        DBAtividadesDicInfo.DtCad => MDtCad,
        DBAtividadesDicInfo.QuemAtu => NFQuemAtu(),
        DBAtividadesDicInfo.DtAtu => MDtAtu,
        DBAtividadesDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}