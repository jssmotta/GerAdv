#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDadosProcuracaoWriter
{
    Entity.DBDadosProcuracao Write(Models.DadosProcuracao dadosprocuracao, int auditorQuem, SqlConnection oCnn);
}

public class DadosProcuracao : IDadosProcuracaoWriter
{
    public Entity.DBDadosProcuracao Write(Models.DadosProcuracao dadosprocuracao, int auditorQuem, SqlConnection oCnn)
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
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}