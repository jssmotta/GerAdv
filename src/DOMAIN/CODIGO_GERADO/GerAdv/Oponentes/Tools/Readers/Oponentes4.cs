#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOponentesReader
{
    OponentesResponse? Read(int id, MsiSqlConnection oCnn);
    OponentesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OponentesResponse? Read(Entity.DBOponentes dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OponentesResponse? Read(DBOponentes dbRec);
    OponentesResponseAll? ReadAll(DBOponentes dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Oponentes : IOponentesReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) opoCodigo, opoNome FROM {"Oponentes".dbo(oCnn)} (NOLOCK) ");
        if (!string.IsNullOrEmpty(whereClause))
        {
            query.Append(!whereClause.ToUpperInvariant().Contains(TSql.Where, StringComparison.OrdinalIgnoreCase) ? TSql.Where : string.Empty).Append(whereClause);
        }

        if (!string.IsNullOrEmpty(orderClause))
        {
            query.Append(!orderClause.ToUpperInvariant().Contains(TSql.OrderBy, StringComparison.OrdinalIgnoreCase) ? TSql.OrderBy : string.Empty).Append(orderClause);
        }
        else
        {
            query.Append($"{TSql.OrderBy}opoNome");
        }

        return query.ToString();
    }

    public OponentesResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOponentes(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OponentesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOponentes(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OponentesResponse? Read(Entity.DBOponentes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var oponentes = new OponentesResponse
        {
            Id = dbRec.ID,
            EMPFuncao = dbRec.FEMPFuncao,
            CTPSNumero = dbRec.FCTPSNumero ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            CTPSSerie = dbRec.FCTPSSerie ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Adv = dbRec.FAdv,
            EMPCliente = dbRec.FEMPCliente,
            IDRep = dbRec.FIDRep,
            PIS = dbRec.FPIS ?? string.Empty,
            Contato = dbRec.FContato ?? string.Empty,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Juridica = dbRec.FJuridica,
            Tipo = dbRec.FTipo,
            Sexo = dbRec.FSexo,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Cidade = dbRec.FCidade,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Top = dbRec.FTop,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return oponentes;
    }

    public OponentesResponse? Read(DBOponentes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var oponentes = new OponentesResponse
        {
            Id = dbRec.ID,
            EMPFuncao = dbRec.FEMPFuncao,
            CTPSNumero = dbRec.FCTPSNumero ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            CTPSSerie = dbRec.FCTPSSerie ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Adv = dbRec.FAdv,
            EMPCliente = dbRec.FEMPCliente,
            IDRep = dbRec.FIDRep,
            PIS = dbRec.FPIS ?? string.Empty,
            Contato = dbRec.FContato ?? string.Empty,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Juridica = dbRec.FJuridica,
            Tipo = dbRec.FTipo,
            Sexo = dbRec.FSexo,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Cidade = dbRec.FCidade,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Top = dbRec.FTop,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return oponentes;
    }

    public OponentesResponseAll? ReadAll(DBOponentes dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var oponentes = new OponentesResponseAll
        {
            Id = dbRec.ID,
            EMPFuncao = dbRec.FEMPFuncao,
            CTPSNumero = dbRec.FCTPSNumero ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            CTPSSerie = dbRec.FCTPSSerie ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Adv = dbRec.FAdv,
            EMPCliente = dbRec.FEMPCliente,
            IDRep = dbRec.FIDRep,
            PIS = dbRec.FPIS ?? string.Empty,
            Contato = dbRec.FContato ?? string.Empty,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Juridica = dbRec.FJuridica,
            Tipo = dbRec.FTipo,
            Sexo = dbRec.FSexo,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Cidade = dbRec.FCidade,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Top = dbRec.FTop,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        oponentes.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return oponentes;
    }
}