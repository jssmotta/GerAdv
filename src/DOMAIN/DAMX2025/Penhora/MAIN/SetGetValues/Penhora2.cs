namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPenhora
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBPenhoraDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPenhoraDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBPenhoraDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBPenhoraDicInfo.DataPenhora:
                FDataPenhora = $"{value}"; // rgo J3: DateTime
                return;
            case DBPenhoraDicInfo.PenhoraStatus:
                FPenhoraStatus = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPenhoraDicInfo.Master:
                FMaster = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPenhoraDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBPenhoraDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPenhoraDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBPenhoraDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPenhoraDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBPenhoraDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBPenhoraDicInfo.Processo => NFProcesso(),
        DBPenhoraDicInfo.Nome => NFNome(),
        DBPenhoraDicInfo.Descricao => NFDescricao(),
        DBPenhoraDicInfo.DataPenhora => NFDataPenhora(),
        DBPenhoraDicInfo.PenhoraStatus => NFPenhoraStatus(),
        DBPenhoraDicInfo.Master => NFMaster(),
        DBPenhoraDicInfo.GUID => NFGUID(),
        DBPenhoraDicInfo.QuemCad => NFQuemCad(),
        DBPenhoraDicInfo.DtCad => MDtCad,
        DBPenhoraDicInfo.QuemAtu => NFQuemAtu(),
        DBPenhoraDicInfo.DtAtu => MDtAtu,
        DBPenhoraDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}