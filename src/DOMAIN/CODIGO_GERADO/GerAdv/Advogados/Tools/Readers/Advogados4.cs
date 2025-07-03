#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAdvogadosReader
{
    AdvogadosResponse? Read(int id, MsiSqlConnection oCnn);
    AdvogadosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AdvogadosResponse? Read(Entity.DBAdvogados dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AdvogadosResponse? Read(DBAdvogados dbRec);
    AdvogadosResponseAll? ReadAll(DBAdvogados dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Advogados : IAdvogadosReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) advCodigo, advNome FROM {"Advogados".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}advNome");
        }

        return query.ToString();
    }

    public AdvogadosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAdvogados(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AdvogadosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAdvogados(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AdvogadosResponse? Read(Entity.DBAdvogados dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var advogados = new AdvogadosResponse
        {
            Id = dbRec.ID,
            Cargo = dbRec.FCargo,
            EMailPro = dbRec.FEMailPro ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Casa = dbRec.FCasa,
            NomeMae = dbRec.FNomeMae ?? string.Empty,
            Escritorio = dbRec.FEscritorio,
            Estagiario = dbRec.FEstagiario,
            OAB = dbRec.FOAB ?? string.Empty,
            NomeCompleto = dbRec.FNomeCompleto ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Sexo = dbRec.FSexo,
            Bairro = dbRec.FBairro ?? string.Empty,
            CTPSSerie = dbRec.FCTPSSerie ?? string.Empty,
            CTPS = dbRec.FCTPS ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Comissao = dbRec.FComissao,
            Salario = dbRec.FSalario,
            Secretaria = dbRec.FSecretaria ?? string.Empty,
            TextoProcuracao = dbRec.FTextoProcuracao ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Especializacao = dbRec.FEspecializacao ?? string.Empty,
            Pasta = dbRec.FPasta ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            ContaBancaria = dbRec.FContaBancaria ?? string.Empty,
            ParcTop = dbRec.FParcTop,
            Class = dbRec.FClass ?? string.Empty,
            Top = dbRec.FTop,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtInicio, out _))
            advogados.DtInicio = dbRec.FDtInicio;
        if (DateTime.TryParse(dbRec.FDtFim, out _))
            advogados.DtFim = dbRec.FDtFim;
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            advogados.DtNasc = dbRec.FDtNasc;
        return advogados;
    }

    public AdvogadosResponse? Read(DBAdvogados dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var advogados = new AdvogadosResponse
        {
            Id = dbRec.ID,
            Cargo = dbRec.FCargo,
            EMailPro = dbRec.FEMailPro ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Casa = dbRec.FCasa,
            NomeMae = dbRec.FNomeMae ?? string.Empty,
            Escritorio = dbRec.FEscritorio,
            Estagiario = dbRec.FEstagiario,
            OAB = dbRec.FOAB ?? string.Empty,
            NomeCompleto = dbRec.FNomeCompleto ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Sexo = dbRec.FSexo,
            Bairro = dbRec.FBairro ?? string.Empty,
            CTPSSerie = dbRec.FCTPSSerie ?? string.Empty,
            CTPS = dbRec.FCTPS ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Comissao = dbRec.FComissao,
            Salario = dbRec.FSalario,
            Secretaria = dbRec.FSecretaria ?? string.Empty,
            TextoProcuracao = dbRec.FTextoProcuracao ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Especializacao = dbRec.FEspecializacao ?? string.Empty,
            Pasta = dbRec.FPasta ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            ContaBancaria = dbRec.FContaBancaria ?? string.Empty,
            ParcTop = dbRec.FParcTop,
            Class = dbRec.FClass ?? string.Empty,
            Top = dbRec.FTop,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtInicio, out _))
            advogados.DtInicio = dbRec.FDtInicio;
        if (DateTime.TryParse(dbRec.FDtFim, out _))
            advogados.DtFim = dbRec.FDtFim;
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            advogados.DtNasc = dbRec.FDtNasc;
        return advogados;
    }

    public AdvogadosResponseAll? ReadAll(DBAdvogados dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var advogados = new AdvogadosResponseAll
        {
            Id = dbRec.ID,
            Cargo = dbRec.FCargo,
            EMailPro = dbRec.FEMailPro ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Casa = dbRec.FCasa,
            NomeMae = dbRec.FNomeMae ?? string.Empty,
            Escritorio = dbRec.FEscritorio,
            Estagiario = dbRec.FEstagiario,
            OAB = dbRec.FOAB ?? string.Empty,
            NomeCompleto = dbRec.FNomeCompleto ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Sexo = dbRec.FSexo,
            Bairro = dbRec.FBairro ?? string.Empty,
            CTPSSerie = dbRec.FCTPSSerie ?? string.Empty,
            CTPS = dbRec.FCTPS ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Comissao = dbRec.FComissao,
            Salario = dbRec.FSalario,
            Secretaria = dbRec.FSecretaria ?? string.Empty,
            TextoProcuracao = dbRec.FTextoProcuracao ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Especializacao = dbRec.FEspecializacao ?? string.Empty,
            Pasta = dbRec.FPasta ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            ContaBancaria = dbRec.FContaBancaria ?? string.Empty,
            ParcTop = dbRec.FParcTop,
            Class = dbRec.FClass ?? string.Empty,
            Top = dbRec.FTop,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtInicio, out _))
            advogados.DtInicio = dbRec.FDtInicio;
        if (DateTime.TryParse(dbRec.FDtFim, out _))
            advogados.DtFim = dbRec.FDtFim;
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            advogados.DtNasc = dbRec.FDtNasc;
        advogados.NomeCargos = dr["carNome"]?.ToString() ?? string.Empty;
        advogados.NomeEscritorios = dr["escNome"]?.ToString() ?? string.Empty;
        advogados.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return advogados;
    }
}