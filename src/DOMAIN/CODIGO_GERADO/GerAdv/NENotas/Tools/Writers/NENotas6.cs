#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface INENotasWriter
{
    Entity.DBNENotas Write(Models.NENotas nenotas, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(NENotasResponse nenotas, int operadorId, MsiSqlConnection oCnn);
}

public class NENotas : INENotasWriter
{
    public void Delete(NENotasResponse nenotas, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[NENotas] WHERE nepCodigo={nenotas.Id};", oCnn);
    }

    public Entity.DBNENotas Write(Models.NENotas nenotas, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = nenotas.Id.IsEmptyIDNumber() ? new Entity.DBNENotas() : new Entity.DBNENotas(nenotas.Id, oCnn);
        dbRec.FApenso = nenotas.Apenso;
        dbRec.FPrecatoria = nenotas.Precatoria;
        dbRec.FInstancia = nenotas.Instancia;
        dbRec.FMovPro = nenotas.MovPro;
        dbRec.FNome = nenotas.Nome;
        dbRec.FNotaExpedida = nenotas.NotaExpedida;
        dbRec.FRevisada = nenotas.Revisada;
        dbRec.FProcesso = nenotas.Processo;
        dbRec.FPalavraChave = nenotas.PalavraChave;
        if (nenotas.Data != null)
            dbRec.FData = nenotas.Data.ToString();
        dbRec.FNotaPublicada = nenotas.NotaPublicada;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}