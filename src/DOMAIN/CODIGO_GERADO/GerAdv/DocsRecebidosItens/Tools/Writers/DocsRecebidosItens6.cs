#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDocsRecebidosItensWriter
{
    Entity.DBDocsRecebidosItens Write(Models.DocsRecebidosItens docsrecebidositens, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(DocsRecebidosItensResponse docsrecebidositens, int operadorId, MsiSqlConnection oCnn);
}

public class DocsRecebidosItens : IDocsRecebidosItensWriter
{
    public void Delete(DocsRecebidosItensResponse docsrecebidositens, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[DocsRecebidosItens] WHERE driCodigo={docsrecebidositens.Id};", oCnn);
    }

    public Entity.DBDocsRecebidosItens Write(Models.DocsRecebidosItens docsrecebidositens, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = docsrecebidositens.Id.IsEmptyIDNumber() ? new Entity.DBDocsRecebidosItens() : new Entity.DBDocsRecebidosItens(docsrecebidositens.Id, oCnn);
        dbRec.FContatoCRM = docsrecebidositens.ContatoCRM;
        dbRec.FNome = docsrecebidositens.Nome;
        dbRec.FDevolvido = docsrecebidositens.Devolvido;
        dbRec.FSeraDevolvido = docsrecebidositens.SeraDevolvido;
        dbRec.FObservacoes = docsrecebidositens.Observacoes;
        dbRec.FBold = docsrecebidositens.Bold;
        dbRec.FGUID = docsrecebidositens.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}