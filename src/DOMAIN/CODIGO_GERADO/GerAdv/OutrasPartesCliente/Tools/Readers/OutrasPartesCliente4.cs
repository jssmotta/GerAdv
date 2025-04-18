#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOutrasPartesClienteReader
{
    OutrasPartesClienteResponse? Read(int id, SqlConnection oCnn);
    OutrasPartesClienteResponse? Read(string where, SqlConnection oCnn);
    OutrasPartesClienteResponse? Read(Entity.DBOutrasPartesCliente dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    OutrasPartesClienteResponse? Read(DBOutrasPartesCliente dbRec);
}

public partial class OutrasPartesCliente : IOutrasPartesClienteReader
{
    public OutrasPartesClienteResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOutrasPartesCliente(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OutrasPartesClienteResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOutrasPartesCliente(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OutrasPartesClienteResponse? Read(Entity.DBOutrasPartesCliente dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var outraspartescliente = new OutrasPartesClienteResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Terceirizado = dbRec.FTerceirizado,
            ClientePrincipal = dbRec.FClientePrincipal,
            Tipo = dbRec.FTipo,
            Sexo = dbRec.FSexo,
            CPF = dbRec.FCPF ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            CNPJ = dbRec.FCNPJ ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            NomeFantasia = dbRec.FNomeFantasia ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            outraspartescliente.DtNasc = dbRec.FDtNasc;
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
        outraspartescliente.Auditor = auditor;
        return outraspartescliente;
    }

    public OutrasPartesClienteResponse? Read(DBOutrasPartesCliente dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var outraspartescliente = new OutrasPartesClienteResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Terceirizado = dbRec.FTerceirizado,
            ClientePrincipal = dbRec.FClientePrincipal,
            Tipo = dbRec.FTipo,
            Sexo = dbRec.FSexo,
            CPF = dbRec.FCPF ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            CNPJ = dbRec.FCNPJ ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            NomeFantasia = dbRec.FNomeFantasia ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            outraspartescliente.DtNasc = dbRec.FDtNasc;
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
        outraspartescliente.Auditor = auditor;
        return outraspartescliente;
    }
}