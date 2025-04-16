#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaRelatorioReader
{
    AgendaRelatorioResponse? Read(DBAgendaRelatorio dbRec);
}

public partial class AgendaRelatorio : IAgendaRelatorioReader
{
    public AgendaRelatorioResponse? Read(DBAgendaRelatorio dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarelatorio = new AgendaRelatorioResponse
        {
            Id = dbRec.ID,
            Data = dbRec.FData ?? string.Empty,
            Processo = dbRec.FProcesso,
            ParaNome = dbRec.FParaNome ?? string.Empty,
            ParaPessoas = dbRec.FParaPessoas ?? string.Empty,
            BoxAudiencia = dbRec.FBoxAudiencia ?? string.Empty,
            BoxAudienciaMobile = dbRec.FBoxAudienciaMobile ?? string.Empty,
            NomeAdvogado = dbRec.FNomeAdvogado ?? string.Empty,
            NomeForo = dbRec.FNomeForo ?? string.Empty,
            NomeJustica = dbRec.FNomeJustica ?? string.Empty,
            NomeArea = dbRec.FNomeArea ?? string.Empty,
        };
        return agendarelatorio;
    }
}