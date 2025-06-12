#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGruposEmpresasCliReader
{
    GruposEmpresasCliResponse? Read(int id, MsiSqlConnection oCnn);
    GruposEmpresasCliResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GruposEmpresasCliResponse? Read(Entity.DBGruposEmpresasCli dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GruposEmpresasCliResponse? Read(DBGruposEmpresasCli dbRec);
    GruposEmpresasCliResponseAll? ReadAll(DBGruposEmpresasCli dbRec, DataRow dr);
}

public partial class GruposEmpresasCli : IGruposEmpresasCliReader
{
    public GruposEmpresasCliResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGruposEmpresasCli(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GruposEmpresasCliResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGruposEmpresasCli(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GruposEmpresasCliResponse? Read(Entity.DBGruposEmpresasCli dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gruposempresascli = new GruposEmpresasCliResponse
        {
            Id = dbRec.ID,
            Grupo = dbRec.FGrupo,
            Cliente = dbRec.FCliente,
            Oculto = dbRec.FOculto,
        };
        return gruposempresascli;
    }

    public GruposEmpresasCliResponse? Read(DBGruposEmpresasCli dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gruposempresascli = new GruposEmpresasCliResponse
        {
            Id = dbRec.ID,
            Grupo = dbRec.FGrupo,
            Cliente = dbRec.FCliente,
            Oculto = dbRec.FOculto,
        };
        return gruposempresascli;
    }

    public GruposEmpresasCliResponseAll? ReadAll(DBGruposEmpresasCli dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gruposempresascli = new GruposEmpresasCliResponseAll
        {
            Id = dbRec.ID,
            Grupo = dbRec.FGrupo,
            Cliente = dbRec.FCliente,
            Oculto = dbRec.FOculto,
        };
        gruposempresascli.DescricaoGruposEmpresas = dr["grpDescricao"]?.ToString() ?? string.Empty;
        gruposempresascli.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return gruposempresascli;
    }
}