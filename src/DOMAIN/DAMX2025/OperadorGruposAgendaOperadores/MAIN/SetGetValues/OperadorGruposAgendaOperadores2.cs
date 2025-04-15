namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOperadorGruposAgendaOperadores
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda:
                FOperadorGruposAgenda = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorGruposAgendaOperadoresDicInfo.Operador:
                FOperador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorGruposAgendaOperadoresDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBOperadorGruposAgendaOperadoresDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorGruposAgendaOperadoresDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorGruposAgendaOperadoresDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBOperadorGruposAgendaOperadoresDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda => NFOperadorGruposAgenda(),
        DBOperadorGruposAgendaOperadoresDicInfo.Operador => NFOperador(),
        DBOperadorGruposAgendaOperadoresDicInfo.GUID => NFGUID(),
        DBOperadorGruposAgendaOperadoresDicInfo.QuemCad => NFQuemCad(),
        DBOperadorGruposAgendaOperadoresDicInfo.DtCad => MDtCad,
        DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu => NFQuemAtu(),
        DBOperadorGruposAgendaOperadoresDicInfo.DtAtu => MDtAtu,
        DBOperadorGruposAgendaOperadoresDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}