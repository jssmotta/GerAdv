namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOperadorGruposAgenda
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBOperadorGruposAgendaDicInfo.SQLWhere:
                FSQLWhere = $"{value}"; // rgo J3: string
                return;
            case DBOperadorGruposAgendaDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBOperadorGruposAgendaDicInfo.Operador:
                FOperador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorGruposAgendaDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBOperadorGruposAgendaDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorGruposAgendaDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBOperadorGruposAgendaDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorGruposAgendaDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBOperadorGruposAgendaDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBOperadorGruposAgendaDicInfo.SQLWhere => NFSQLWhere(),
        DBOperadorGruposAgendaDicInfo.Nome => NFNome(),
        DBOperadorGruposAgendaDicInfo.Operador => NFOperador(),
        DBOperadorGruposAgendaDicInfo.GUID => NFGUID(),
        DBOperadorGruposAgendaDicInfo.QuemCad => NFQuemCad(),
        DBOperadorGruposAgendaDicInfo.DtCad => MDtCad,
        DBOperadorGruposAgendaDicInfo.QuemAtu => NFQuemAtu(),
        DBOperadorGruposAgendaDicInfo.DtAtu => MDtAtu,
        DBOperadorGruposAgendaDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}