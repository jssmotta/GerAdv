#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IHonorariosDadosContratoReader
{
    HonorariosDadosContratoResponse? Read(int id, SqlConnection oCnn);
    HonorariosDadosContratoResponse? Read(string where, SqlConnection oCnn);
    HonorariosDadosContratoResponse? Read(Entity.DBHonorariosDadosContrato dbRec);
    HonorariosDadosContratoResponse? Read(DBHonorariosDadosContrato dbRec);
}

public partial class HonorariosDadosContrato : IHonorariosDadosContratoReader
{
    public HonorariosDadosContratoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBHonorariosDadosContrato(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public HonorariosDadosContratoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBHonorariosDadosContrato(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public HonorariosDadosContratoResponse? Read(Entity.DBHonorariosDadosContrato dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var honorariosdadoscontrato = new HonorariosDadosContratoResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            Fixo = dbRec.FFixo,
            Variavel = dbRec.FVariavel,
            PercSucesso = dbRec.FPercSucesso,
            Processo = dbRec.FProcesso,
            ArquivoContrato = dbRec.FArquivoContrato ?? string.Empty,
            TextoContrato = dbRec.FTextoContrato ?? string.Empty,
            ValorFixo = dbRec.FValorFixo,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataContrato, out _))
            honorariosdadoscontrato.DataContrato = dbRec.FDataContrato;
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        honorariosdadoscontrato.Auditor = auditor;
        return honorariosdadoscontrato;
    }

    public HonorariosDadosContratoResponse? Read(DBHonorariosDadosContrato dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var honorariosdadoscontrato = new HonorariosDadosContratoResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            Fixo = dbRec.FFixo,
            Variavel = dbRec.FVariavel,
            PercSucesso = dbRec.FPercSucesso,
            Processo = dbRec.FProcesso,
            ArquivoContrato = dbRec.FArquivoContrato ?? string.Empty,
            TextoContrato = dbRec.FTextoContrato ?? string.Empty,
            ValorFixo = dbRec.FValorFixo,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataContrato, out _))
            honorariosdadoscontrato.DataContrato = dbRec.FDataContrato;
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        honorariosdadoscontrato.Auditor = auditor;
        return honorariosdadoscontrato;
    }
}