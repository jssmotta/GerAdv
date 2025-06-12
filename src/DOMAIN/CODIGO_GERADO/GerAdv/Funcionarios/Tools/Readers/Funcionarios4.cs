#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFuncionariosReader
{
    FuncionariosResponse? Read(int id, MsiSqlConnection oCnn);
    FuncionariosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    FuncionariosResponse? Read(Entity.DBFuncionarios dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    FuncionariosResponse? Read(DBFuncionarios dbRec);
    FuncionariosResponseAll? ReadAll(DBFuncionarios dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Funcionarios : IFuncionariosReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) funCodigo, funNome FROM {"Funcionarios".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}funNome");
        }

        return query.ToString();
    }

    public FuncionariosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBFuncionarios(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public FuncionariosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBFuncionarios(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public FuncionariosResponse? Read(Entity.DBFuncionarios dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var funcionarios = new FuncionariosResponse
        {
            Id = dbRec.ID,
            EMailPro = dbRec.FEMailPro ?? string.Empty,
            Cargo = dbRec.FCargo,
            Nome = dbRec.FNome ?? string.Empty,
            Funcao = dbRec.FFuncao,
            Sexo = dbRec.FSexo,
            Registro = dbRec.FRegistro ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Tipo = dbRec.FTipo,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Contato = dbRec.FContato ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            CTPSNumero = dbRec.FCTPSNumero ?? string.Empty,
            CTPSSerie = dbRec.FCTPSSerie ?? string.Empty,
            PIS = dbRec.FPIS ?? string.Empty,
            Salario = dbRec.FSalario,
            LiberaAgenda = dbRec.FLiberaAgenda,
            Pasta = dbRec.FPasta ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FPeriodo_Ini, out _))
            funcionarios.Periodo_Ini = dbRec.FPeriodo_Ini;
        if (DateTime.TryParse(dbRec.FPeriodo_Fim, out _))
            funcionarios.Periodo_Fim = dbRec.FPeriodo_Fim;
        if (DateTime.TryParse(dbRec.FCTPSDtEmissao, out _))
            funcionarios.CTPSDtEmissao = dbRec.FCTPSDtEmissao;
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            funcionarios.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FData, out _))
            funcionarios.Data = dbRec.FData;
        return funcionarios;
    }

    public FuncionariosResponse? Read(DBFuncionarios dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var funcionarios = new FuncionariosResponse
        {
            Id = dbRec.ID,
            EMailPro = dbRec.FEMailPro ?? string.Empty,
            Cargo = dbRec.FCargo,
            Nome = dbRec.FNome ?? string.Empty,
            Funcao = dbRec.FFuncao,
            Sexo = dbRec.FSexo,
            Registro = dbRec.FRegistro ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Tipo = dbRec.FTipo,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Contato = dbRec.FContato ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            CTPSNumero = dbRec.FCTPSNumero ?? string.Empty,
            CTPSSerie = dbRec.FCTPSSerie ?? string.Empty,
            PIS = dbRec.FPIS ?? string.Empty,
            Salario = dbRec.FSalario,
            LiberaAgenda = dbRec.FLiberaAgenda,
            Pasta = dbRec.FPasta ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FPeriodo_Ini, out _))
            funcionarios.Periodo_Ini = dbRec.FPeriodo_Ini;
        if (DateTime.TryParse(dbRec.FPeriodo_Fim, out _))
            funcionarios.Periodo_Fim = dbRec.FPeriodo_Fim;
        if (DateTime.TryParse(dbRec.FCTPSDtEmissao, out _))
            funcionarios.CTPSDtEmissao = dbRec.FCTPSDtEmissao;
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            funcionarios.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FData, out _))
            funcionarios.Data = dbRec.FData;
        return funcionarios;
    }

    public FuncionariosResponseAll? ReadAll(DBFuncionarios dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var funcionarios = new FuncionariosResponseAll
        {
            Id = dbRec.ID,
            EMailPro = dbRec.FEMailPro ?? string.Empty,
            Cargo = dbRec.FCargo,
            Nome = dbRec.FNome ?? string.Empty,
            Funcao = dbRec.FFuncao,
            Sexo = dbRec.FSexo,
            Registro = dbRec.FRegistro ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Tipo = dbRec.FTipo,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Contato = dbRec.FContato ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            CTPSNumero = dbRec.FCTPSNumero ?? string.Empty,
            CTPSSerie = dbRec.FCTPSSerie ?? string.Empty,
            PIS = dbRec.FPIS ?? string.Empty,
            Salario = dbRec.FSalario,
            LiberaAgenda = dbRec.FLiberaAgenda,
            Pasta = dbRec.FPasta ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FPeriodo_Ini, out _))
            funcionarios.Periodo_Ini = dbRec.FPeriodo_Ini;
        if (DateTime.TryParse(dbRec.FPeriodo_Fim, out _))
            funcionarios.Periodo_Fim = dbRec.FPeriodo_Fim;
        if (DateTime.TryParse(dbRec.FCTPSDtEmissao, out _))
            funcionarios.CTPSDtEmissao = dbRec.FCTPSDtEmissao;
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            funcionarios.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FData, out _))
            funcionarios.Data = dbRec.FData;
        funcionarios.NomeCargos = dr["carNome"]?.ToString() ?? string.Empty;
        funcionarios.DescricaoFuncao = dr["funDescricao"]?.ToString() ?? string.Empty;
        funcionarios.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return funcionarios;
    }
}