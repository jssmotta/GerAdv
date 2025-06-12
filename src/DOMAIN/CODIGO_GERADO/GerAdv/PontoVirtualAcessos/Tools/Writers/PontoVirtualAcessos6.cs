#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPontoVirtualAcessosWriter
{
    Entity.DBPontoVirtualAcessos Write(Models.PontoVirtualAcessos pontovirtualacessos, MsiSqlConnection oCnn);
    void Delete(PontoVirtualAcessosResponse pontovirtualacessos, int operadorId, MsiSqlConnection oCnn);
}

public class PontoVirtualAcessos : IPontoVirtualAcessosWriter
{
    public void Delete(PontoVirtualAcessosResponse pontovirtualacessos, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[PontoVirtualAcessos] WHERE pvaCodigo={pontovirtualacessos.Id};", oCnn);
    }

    public Entity.DBPontoVirtualAcessos Write(Models.PontoVirtualAcessos pontovirtualacessos, MsiSqlConnection oCnn)
    {
        var dbRec = pontovirtualacessos.Id.IsEmptyIDNumber() ? new Entity.DBPontoVirtualAcessos() : new Entity.DBPontoVirtualAcessos(pontovirtualacessos.Id, oCnn);
        dbRec.FOperador = pontovirtualacessos.Operador;
        if (pontovirtualacessos.DataHora != null)
            dbRec.FDataHora = pontovirtualacessos.DataHora.ToString();
        dbRec.FTipo = pontovirtualacessos.Tipo;
        dbRec.FOrigem = pontovirtualacessos.Origem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}