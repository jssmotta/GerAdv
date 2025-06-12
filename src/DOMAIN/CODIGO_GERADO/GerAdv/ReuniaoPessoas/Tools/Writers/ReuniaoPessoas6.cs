#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IReuniaoPessoasWriter
{
    Entity.DBReuniaoPessoas Write(Models.ReuniaoPessoas reuniaopessoas, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(ReuniaoPessoasResponse reuniaopessoas, int operadorId, MsiSqlConnection oCnn);
}

public class ReuniaoPessoas : IReuniaoPessoasWriter
{
    public void Delete(ReuniaoPessoasResponse reuniaopessoas, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[ReuniaoPessoas] WHERE rnpCodigo={reuniaopessoas.Id};", oCnn);
    }

    public Entity.DBReuniaoPessoas Write(Models.ReuniaoPessoas reuniaopessoas, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = reuniaopessoas.Id.IsEmptyIDNumber() ? new Entity.DBReuniaoPessoas() : new Entity.DBReuniaoPessoas(reuniaopessoas.Id, oCnn);
        dbRec.FReuniao = reuniaopessoas.Reuniao;
        dbRec.FOperador = reuniaopessoas.Operador;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}