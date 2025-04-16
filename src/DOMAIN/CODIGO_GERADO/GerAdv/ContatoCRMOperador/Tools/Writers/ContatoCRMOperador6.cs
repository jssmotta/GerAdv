#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContatoCRMOperadorWriter
{
    Entity.DBContatoCRMOperador Write(Models.ContatoCRMOperador contatocrmoperador, int auditorQuem, SqlConnection oCnn);
}

public class ContatoCRMOperador : IContatoCRMOperadorWriter
{
    public Entity.DBContatoCRMOperador Write(Models.ContatoCRMOperador contatocrmoperador, int auditorQuem, SqlConnection oCnn)
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