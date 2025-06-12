#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface INENotasWhere
{
    NENotasResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class NENotas : INENotasWhere
{
    public NENotasResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBNENotas(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var nenotas = new NENotasResponse
        {
            Id = dbRec.ID,
            Apenso = dbRec.FApenso,
            Precatoria = dbRec.FPrecatoria,
            Instancia = dbRec.FInstancia,
            MovPro = dbRec.FMovPro,
            Nome = dbRec.FNome ?? string.Empty,
            NotaExpedida = dbRec.FNotaExpedida,
            Revisada = dbRec.FRevisada,
            Processo = dbRec.FProcesso,
            PalavraChave = dbRec.FPalavraChave,
            NotaPublicada = dbRec.FNotaPublicada ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            nenotas.Data = dbRec.FData;
        return nenotas;
    }
}