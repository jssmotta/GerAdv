#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPrepostosReader
{
    PrepostosResponse? Read(int id, MsiSqlConnection oCnn);
    PrepostosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PrepostosResponse? Read(Entity.DBPrepostos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PrepostosResponse? Read(DBPrepostos dbRec);
    PrepostosResponseAll? ReadAll(DBPrepostos dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Prepostos : IPrepostosReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) preCodigo, preNome FROM {"Prepostos".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}preNome");
        }

        return query.ToString();
    }

    public PrepostosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPrepostos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PrepostosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPrepostos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PrepostosResponse? Read(Entity.DBPrepostos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prepostos = new PrepostosResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Funcao = dbRec.FFuncao,
            Setor = dbRec.FSetor,
            Qualificacao = dbRec.FQualificacao ?? string.Empty,
            Sexo = dbRec.FSexo,
            Idade = dbRec.FIdade,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Registro = dbRec.FRegistro ?? string.Empty,
            CTPSNumero = dbRec.FCTPSNumero ?? string.Empty,
            CTPSSerie = dbRec.FCTPSSerie ?? string.Empty,
            PIS = dbRec.FPIS ?? string.Empty,
            Salario = dbRec.FSalario,
            LiberaAgenda = dbRec.FLiberaAgenda,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Pai = dbRec.FPai ?? string.Empty,
            Mae = dbRec.FMae ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            prepostos.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FPeriodo_Ini, out _))
            prepostos.Periodo_Ini = dbRec.FPeriodo_Ini;
        if (DateTime.TryParse(dbRec.FPeriodo_Fim, out _))
            prepostos.Periodo_Fim = dbRec.FPeriodo_Fim;
        if (DateTime.TryParse(dbRec.FCTPSDtEmissao, out _))
            prepostos.CTPSDtEmissao = dbRec.FCTPSDtEmissao;
        return prepostos;
    }

    public PrepostosResponse? Read(DBPrepostos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prepostos = new PrepostosResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Funcao = dbRec.FFuncao,
            Setor = dbRec.FSetor,
            Qualificacao = dbRec.FQualificacao ?? string.Empty,
            Sexo = dbRec.FSexo,
            Idade = dbRec.FIdade,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Registro = dbRec.FRegistro ?? string.Empty,
            CTPSNumero = dbRec.FCTPSNumero ?? string.Empty,
            CTPSSerie = dbRec.FCTPSSerie ?? string.Empty,
            PIS = dbRec.FPIS ?? string.Empty,
            Salario = dbRec.FSalario,
            LiberaAgenda = dbRec.FLiberaAgenda,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Pai = dbRec.FPai ?? string.Empty,
            Mae = dbRec.FMae ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            prepostos.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FPeriodo_Ini, out _))
            prepostos.Periodo_Ini = dbRec.FPeriodo_Ini;
        if (DateTime.TryParse(dbRec.FPeriodo_Fim, out _))
            prepostos.Periodo_Fim = dbRec.FPeriodo_Fim;
        if (DateTime.TryParse(dbRec.FCTPSDtEmissao, out _))
            prepostos.CTPSDtEmissao = dbRec.FCTPSDtEmissao;
        return prepostos;
    }

    public PrepostosResponseAll? ReadAll(DBPrepostos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prepostos = new PrepostosResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Funcao = dbRec.FFuncao,
            Setor = dbRec.FSetor,
            Qualificacao = dbRec.FQualificacao ?? string.Empty,
            Sexo = dbRec.FSexo,
            Idade = dbRec.FIdade,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Registro = dbRec.FRegistro ?? string.Empty,
            CTPSNumero = dbRec.FCTPSNumero ?? string.Empty,
            CTPSSerie = dbRec.FCTPSSerie ?? string.Empty,
            PIS = dbRec.FPIS ?? string.Empty,
            Salario = dbRec.FSalario,
            LiberaAgenda = dbRec.FLiberaAgenda,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Pai = dbRec.FPai ?? string.Empty,
            Mae = dbRec.FMae ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            prepostos.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FPeriodo_Ini, out _))
            prepostos.Periodo_Ini = dbRec.FPeriodo_Ini;
        if (DateTime.TryParse(dbRec.FPeriodo_Fim, out _))
            prepostos.Periodo_Fim = dbRec.FPeriodo_Fim;
        if (DateTime.TryParse(dbRec.FCTPSDtEmissao, out _))
            prepostos.CTPSDtEmissao = dbRec.FCTPSDtEmissao;
        prepostos.DescricaoFuncao = dr["funDescricao"]?.ToString() ?? string.Empty;
        prepostos.DescricaoSetor = dr["setDescricao"]?.ToString() ?? string.Empty;
        prepostos.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return prepostos;
    }
}