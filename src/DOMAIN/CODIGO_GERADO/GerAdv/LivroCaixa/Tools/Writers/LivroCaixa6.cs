#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ILivroCaixaWriter
{
    Entity.DBLivroCaixa Write(Models.LivroCaixa livrocaixa, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(LivroCaixaResponse livrocaixa, int operadorId, MsiSqlConnection oCnn);
}

public class LivroCaixa : ILivroCaixaWriter
{
    public void Delete(LivroCaixaResponse livrocaixa, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[LivroCaixa] WHERE livCodigo={livrocaixa.Id};", oCnn);
    }

    public Entity.DBLivroCaixa Write(Models.LivroCaixa livrocaixa, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = livrocaixa.Id.IsEmptyIDNumber() ? new Entity.DBLivroCaixa() : new Entity.DBLivroCaixa(livrocaixa.Id, oCnn);
        dbRec.FIDDes = livrocaixa.IDDes;
        dbRec.FPessoal = livrocaixa.Pessoal;
        dbRec.FAjuste = livrocaixa.Ajuste;
        dbRec.FIDHon = livrocaixa.IDHon;
        dbRec.FIDHonParc = livrocaixa.IDHonParc;
        dbRec.FIDHonSuc = livrocaixa.IDHonSuc;
        if (livrocaixa.Data != null)
            dbRec.FData = livrocaixa.Data.ToString();
        dbRec.FProcesso = livrocaixa.Processo;
        dbRec.FValor = livrocaixa.Valor;
        dbRec.FTipo = livrocaixa.Tipo;
        dbRec.FHistorico = livrocaixa.Historico;
        dbRec.FGrupo = livrocaixa.Grupo;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}