namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBNENotas
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBNENotasDicInfo.Apenso:
                FApenso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBNENotasDicInfo.Precatoria:
                FPrecatoria = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBNENotasDicInfo.Instancia:
                FInstancia = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBNENotasDicInfo.MovPro:
                FMovPro = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBNENotasDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBNENotasDicInfo.NotaExpedida:
                FNotaExpedida = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBNENotasDicInfo.Revisada:
                FRevisada = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBNENotasDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBNENotasDicInfo.PalavraChave:
                FPalavraChave = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBNENotasDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBNENotasDicInfo.NotaPublicada:
                FNotaPublicada = $"{value}"; // rgo J3: string
                return;
            case DBNENotasDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBNENotasDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBNENotasDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBNENotasDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBNENotasDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBNENotasDicInfo.Apenso => NFApenso(),
        DBNENotasDicInfo.Precatoria => NFPrecatoria(),
        DBNENotasDicInfo.Instancia => NFInstancia(),
        DBNENotasDicInfo.MovPro => FMovPro.ToString(),
        DBNENotasDicInfo.Nome => NFNome(),
        DBNENotasDicInfo.NotaExpedida => FNotaExpedida.ToString(),
        DBNENotasDicInfo.Revisada => FRevisada.ToString(),
        DBNENotasDicInfo.Processo => NFProcesso(),
        DBNENotasDicInfo.PalavraChave => NFPalavraChave(),
        DBNENotasDicInfo.Data => NFData(),
        DBNENotasDicInfo.NotaPublicada => NFNotaPublicada(),
        DBNENotasDicInfo.QuemCad => NFQuemCad(),
        DBNENotasDicInfo.DtCad => MDtCad,
        DBNENotasDicInfo.QuemAtu => NFQuemAtu(),
        DBNENotasDicInfo.DtAtu => MDtAtu,
        DBNENotasDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}