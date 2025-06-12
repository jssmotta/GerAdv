#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGruposEmpresasWhere
{
    GruposEmpresasResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class GruposEmpresas : IGruposEmpresasWhere
{
    public GruposEmpresasResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGruposEmpresas(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var gruposempresas = new GruposEmpresasResponse
        {
            Id = dbRec.ID,
            EMail = dbRec.FEMail ?? string.Empty,
            Inativo = dbRec.FInativo,
            Oponente = dbRec.FOponente,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            Cliente = dbRec.FCliente,
            Icone = dbRec.FIcone ?? string.Empty,
            DespesaUnificada = dbRec.FDespesaUnificada,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return gruposempresas;
    }
}