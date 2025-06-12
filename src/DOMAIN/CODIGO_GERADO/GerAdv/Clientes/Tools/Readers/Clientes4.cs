#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IClientesReader
{
    ClientesResponse? Read(int id, MsiSqlConnection oCnn);
    ClientesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ClientesResponse? Read(Entity.DBClientes dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ClientesResponse? Read(DBClientes dbRec);
    ClientesResponseAll? ReadAll(DBClientes dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Clientes : IClientesReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) cliCodigo, cliNome FROM {"Clientes".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}cliNome");
        }

        return query.ToString();
    }

    public ClientesResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBClientes(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ClientesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBClientes(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ClientesResponse? Read(Entity.DBClientes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var clientes = new ClientesResponse
        {
            Id = dbRec.ID,
            Empresa = dbRec.FEmpresa,
            Icone = dbRec.FIcone ?? string.Empty,
            NomeMae = dbRec.FNomeMae ?? string.Empty,
            Inativo = dbRec.FInativo,
            QuemIndicou = dbRec.FQuemIndicou ?? string.Empty,
            SendEMail = dbRec.FSendEMail,
            Nome = dbRec.FNome ?? string.Empty,
            Adv = dbRec.FAdv,
            IDRep = dbRec.FIDRep,
            Juridica = dbRec.FJuridica,
            NomeFantasia = dbRec.FNomeFantasia ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Tipo = dbRec.FTipo,
            InscEst = dbRec.FInscEst ?? string.Empty,
            Qualificacao = dbRec.FQualificacao ?? string.Empty,
            Sexo = dbRec.FSexo,
            Idade = dbRec.FIdade,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            TipoCaptacao = dbRec.FTipoCaptacao,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            HomePage = dbRec.FHomePage ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Obito = dbRec.FObito,
            NomePai = dbRec.FNomePai ?? string.Empty,
            RGOExpeditor = dbRec.FRGOExpeditor ?? string.Empty,
            RegimeTributacao = dbRec.FRegimeTributacao,
            EnquadramentoEmpresa = dbRec.FEnquadramentoEmpresa,
            ReportECBOnly = dbRec.FReportECBOnly,
            ProBono = dbRec.FProBono,
            CNH = dbRec.FCNH ?? string.Empty,
            PessoaContato = dbRec.FPessoaContato ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FRGDataExp, out _))
            clientes.RGDataExp = dbRec.FRGDataExp;
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            clientes.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FData, out _))
            clientes.Data = dbRec.FData;
        return clientes;
    }

    public ClientesResponse? Read(DBClientes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var clientes = new ClientesResponse
        {
            Id = dbRec.ID,
            Empresa = dbRec.FEmpresa,
            Icone = dbRec.FIcone ?? string.Empty,
            NomeMae = dbRec.FNomeMae ?? string.Empty,
            Inativo = dbRec.FInativo,
            QuemIndicou = dbRec.FQuemIndicou ?? string.Empty,
            SendEMail = dbRec.FSendEMail,
            Nome = dbRec.FNome ?? string.Empty,
            Adv = dbRec.FAdv,
            IDRep = dbRec.FIDRep,
            Juridica = dbRec.FJuridica,
            NomeFantasia = dbRec.FNomeFantasia ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Tipo = dbRec.FTipo,
            InscEst = dbRec.FInscEst ?? string.Empty,
            Qualificacao = dbRec.FQualificacao ?? string.Empty,
            Sexo = dbRec.FSexo,
            Idade = dbRec.FIdade,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            TipoCaptacao = dbRec.FTipoCaptacao,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            HomePage = dbRec.FHomePage ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Obito = dbRec.FObito,
            NomePai = dbRec.FNomePai ?? string.Empty,
            RGOExpeditor = dbRec.FRGOExpeditor ?? string.Empty,
            RegimeTributacao = dbRec.FRegimeTributacao,
            EnquadramentoEmpresa = dbRec.FEnquadramentoEmpresa,
            ReportECBOnly = dbRec.FReportECBOnly,
            ProBono = dbRec.FProBono,
            CNH = dbRec.FCNH ?? string.Empty,
            PessoaContato = dbRec.FPessoaContato ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FRGDataExp, out _))
            clientes.RGDataExp = dbRec.FRGDataExp;
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            clientes.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FData, out _))
            clientes.Data = dbRec.FData;
        return clientes;
    }

    public ClientesResponseAll? ReadAll(DBClientes dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var clientes = new ClientesResponseAll
        {
            Id = dbRec.ID,
            Empresa = dbRec.FEmpresa,
            Icone = dbRec.FIcone ?? string.Empty,
            NomeMae = dbRec.FNomeMae ?? string.Empty,
            Inativo = dbRec.FInativo,
            QuemIndicou = dbRec.FQuemIndicou ?? string.Empty,
            SendEMail = dbRec.FSendEMail,
            Nome = dbRec.FNome ?? string.Empty,
            Adv = dbRec.FAdv,
            IDRep = dbRec.FIDRep,
            Juridica = dbRec.FJuridica,
            NomeFantasia = dbRec.FNomeFantasia ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Tipo = dbRec.FTipo,
            InscEst = dbRec.FInscEst ?? string.Empty,
            Qualificacao = dbRec.FQualificacao ?? string.Empty,
            Sexo = dbRec.FSexo,
            Idade = dbRec.FIdade,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            TipoCaptacao = dbRec.FTipoCaptacao,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            HomePage = dbRec.FHomePage ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Obito = dbRec.FObito,
            NomePai = dbRec.FNomePai ?? string.Empty,
            RGOExpeditor = dbRec.FRGOExpeditor ?? string.Empty,
            RegimeTributacao = dbRec.FRegimeTributacao,
            EnquadramentoEmpresa = dbRec.FEnquadramentoEmpresa,
            ReportECBOnly = dbRec.FReportECBOnly,
            ProBono = dbRec.FProBono,
            CNH = dbRec.FCNH ?? string.Empty,
            PessoaContato = dbRec.FPessoaContato ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FRGDataExp, out _))
            clientes.RGDataExp = dbRec.FRGDataExp;
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            clientes.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FData, out _))
            clientes.Data = dbRec.FData;
        clientes.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        clientes.NomeRegimeTributacao = dr["rdtNome"]?.ToString() ?? string.Empty;
        clientes.NomeEnquadramentoEmpresa = dr["eqeNome"]?.ToString() ?? string.Empty;
        return clientes;
    }
}