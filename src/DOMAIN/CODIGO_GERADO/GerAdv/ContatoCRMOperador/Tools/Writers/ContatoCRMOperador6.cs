#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContatoCRMOperadorWriter
{
    Entity.DBContatoCRMOperador Write(Models.ContatoCRMOperador contatocrmoperador, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(ContatoCRMOperadorResponse contatocrmoperador, int operadorId, MsiSqlConnection oCnn);
}

public class ContatoCRMOperador : IContatoCRMOperadorWriter
{
    public void Delete(ContatoCRMOperadorResponse contatocrmoperador, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[ContatoCRMOperador] WHERE ccoCodigo={contatocrmoperador.Id};", oCnn);
    }

    public Entity.DBContatoCRMOperador Write(Models.ContatoCRMOperador contatocrmoperador, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = contatocrmoperador.Id.IsEmptyIDNumber() ? new Entity.DBContatoCRMOperador() : new Entity.DBContatoCRMOperador(contatocrmoperador.Id, oCnn);
        dbRec.FContatoCRM = contatocrmoperador.ContatoCRM;
        dbRec.FCargoEsc = contatocrmoperador.CargoEsc;
        dbRec.FOperador = contatocrmoperador.Operador;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}