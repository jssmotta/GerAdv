namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBStatusTarefas
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBStatusTarefasDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBStatusTarefasDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBStatusTarefasDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBStatusTarefasDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBStatusTarefasDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBStatusTarefasDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBStatusTarefasDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBStatusTarefasDicInfo.Nome => NFNome(),
        DBStatusTarefasDicInfo.GUID => NFGUID(),
        DBStatusTarefasDicInfo.QuemCad => NFQuemCad(),
        DBStatusTarefasDicInfo.DtCad => MDtCad,
        DBStatusTarefasDicInfo.QuemAtu => NFQuemAtu(),
        DBStatusTarefasDicInfo.DtAtu => MDtAtu,
        DBStatusTarefasDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}