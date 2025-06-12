#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTAtividadesWhere
{
    GUTAtividadesResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class GUTAtividades : IGUTAtividadesWhere
{
    public GUTAtividadesResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTAtividades(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var gutatividades = new GUTAtividadesResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUTGrupo = dbRec.FGUTGrupo,
            GUTPeriodicidade = dbRec.FGUTPeriodicidade,
            Operador = dbRec.FOperador,
            Concluido = dbRec.FConcluido,
            DiasParaIniciar = dbRec.FDiasParaIniciar,
            MinutosParaRealizar = dbRec.FMinutosParaRealizar,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataConcluido, out _))
            gutatividades.DataConcluido = dbRec.FDataConcluido;
        return gutatividades;
    }
}