#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IHonorariosDadosContratoWriter
{
    Entity.DBHonorariosDadosContrato Write(Models.HonorariosDadosContrato honorariosdadoscontrato, int auditorQuem, SqlConnection oCnn);
}

public class HonorariosDadosContrato : IHonorariosDadosContratoWriter
{
    public Entity.DBHonorariosDadosContrato Write(Models.HonorariosDadosContrato honorariosdadoscontrato, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = honorariosdadoscontrato.Id.IsEmptyIDNumber() ? new Entity.DBHonorariosDadosContrato() : new Entity.DBHonorariosDadosContrato(honorariosdadoscontrato.Id, oCnn);
        dbRec.FCliente = honorariosdadoscontrato.Cliente;
        dbRec.FFixo = honorariosdadoscontrato.Fixo;
        dbRec.FVariavel = honorariosdadoscontrato.Variavel;
        dbRec.FPercSucesso = honorariosdadoscontrato.PercSucesso;
        dbRec.FProcesso = honorariosdadoscontrato.Processo;
        dbRec.FArquivoContrato = honorariosdadoscontrato.ArquivoContrato;
        dbRec.FTextoContrato = honorariosdadoscontrato.TextoContrato;
        dbRec.FValorFixo = honorariosdadoscontrato.ValorFixo;
        dbRec.FObservacao = honorariosdadoscontrato.Observacao;
        if (honorariosdadoscontrato.DataContrato != null)
            dbRec.FDataContrato = honorariosdadoscontrato.DataContrato.ToString();
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}