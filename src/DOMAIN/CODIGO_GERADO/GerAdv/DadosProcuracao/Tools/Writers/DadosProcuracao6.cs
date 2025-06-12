#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDadosProcuracaoWriter
{
    Entity.DBDadosProcuracao Write(Models.DadosProcuracao dadosprocuracao, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(DadosProcuracaoResponse dadosprocuracao, int operadorId, MsiSqlConnection oCnn);
}

public class DadosProcuracao : IDadosProcuracaoWriter
{
    public void Delete(DadosProcuracaoResponse dadosprocuracao, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[DadosProcuracao] WHERE prcCodigo={dadosprocuracao.Id};", oCnn);
    }

    public Entity.DBDadosProcuracao Write(Models.DadosProcuracao dadosprocuracao, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = dadosprocuracao.Id.IsEmptyIDNumber() ? new Entity.DBDadosProcuracao() : new Entity.DBDadosProcuracao(dadosprocuracao.Id, oCnn);
        dbRec.FCliente = dadosprocuracao.Cliente;
        dbRec.FEstadoCivil = dadosprocuracao.EstadoCivil;
        dbRec.FNacionalidade = dadosprocuracao.Nacionalidade;
        dbRec.FProfissao = dadosprocuracao.Profissao;
        dbRec.FCTPS = dadosprocuracao.CTPS;
        dbRec.FPisPasep = dadosprocuracao.PisPasep;
        dbRec.FRemuneracao = dadosprocuracao.Remuneracao;
        dbRec.FObjeto = dadosprocuracao.Objeto;
        dbRec.FGUID = dadosprocuracao.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}