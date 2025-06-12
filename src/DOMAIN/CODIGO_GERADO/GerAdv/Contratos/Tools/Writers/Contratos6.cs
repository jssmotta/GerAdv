#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContratosWriter
{
    Entity.DBContratos Write(Models.Contratos contratos, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(ContratosResponse contratos, int operadorId, MsiSqlConnection oCnn);
}

public class Contratos : IContratosWriter
{
    public void Delete(ContratosResponse contratos, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Contratos] WHERE cttCodigo={contratos.Id};", oCnn);
    }

    public Entity.DBContratos Write(Models.Contratos contratos, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = contratos.Id.IsEmptyIDNumber() ? new Entity.DBContratos() : new Entity.DBContratos(contratos.Id, oCnn);
        dbRec.FProcesso = contratos.Processo;
        dbRec.FCliente = contratos.Cliente;
        dbRec.FAdvogado = contratos.Advogado;
        dbRec.FDia = contratos.Dia;
        dbRec.FValor = contratos.Valor;
        if (contratos.DataInicio != null)
            dbRec.FDataInicio = contratos.DataInicio.ToString();
        if (contratos.DataTermino != null)
            dbRec.FDataTermino = contratos.DataTermino.ToString();
        dbRec.FOcultarRelatorio = contratos.OcultarRelatorio;
        dbRec.FPercEscritorio = contratos.PercEscritorio;
        dbRec.FValorConsultoria = contratos.ValorConsultoria;
        dbRec.FTipoCobranca = contratos.TipoCobranca;
        dbRec.FProtestar = contratos.Protestar;
        dbRec.FJuros = contratos.Juros;
        dbRec.FValorRealizavel = contratos.ValorRealizavel;
        dbRec.FDOCUMENTO = contratos.DOCUMENTO;
        dbRec.FEMail1 = contratos.EMail1;
        dbRec.FEMail2 = contratos.EMail2;
        dbRec.FEMail3 = contratos.EMail3;
        dbRec.FPessoa1 = contratos.Pessoa1;
        dbRec.FPessoa2 = contratos.Pessoa2;
        dbRec.FPessoa3 = contratos.Pessoa3;
        dbRec.FOBS = contratos.OBS;
        dbRec.FClienteContrato = contratos.ClienteContrato;
        dbRec.FIdExtrangeiro = contratos.IdExtrangeiro;
        dbRec.FChaveContrato = contratos.ChaveContrato;
        dbRec.FAvulso = contratos.Avulso;
        dbRec.FSuspenso = contratos.Suspenso;
        dbRec.FMulta = contratos.Multa;
        dbRec.FBold = contratos.Bold;
        dbRec.FGUID = contratos.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}