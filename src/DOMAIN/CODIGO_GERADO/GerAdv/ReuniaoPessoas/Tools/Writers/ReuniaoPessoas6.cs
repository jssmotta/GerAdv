#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IReuniaoPessoasWriter
{
    Entity.DBReuniaoPessoas Write(Models.ReuniaoPessoas reuniaopessoas, int auditorQuem, SqlConnection oCnn);
}

public class ReuniaoPessoas : IReuniaoPessoasWriter
{
    public Entity.DBReuniaoPessoas Write(Models.ReuniaoPessoas reuniaopessoas, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = reuniaopessoas.Id.IsEmptyIDNumber() ? new Entity.DBReuniaoPessoas() : new Entity.DBReuniaoPessoas(reuniaopessoas.Id, oCnn);
        dbRec.FReuniao = reuniaopessoas.Reuniao;
        dbRec.FOperador = reuniaopessoas.Operador;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}