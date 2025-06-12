#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOutrasPartesClienteWhere
{
    OutrasPartesClienteResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class OutrasPartesCliente : IOutrasPartesClienteWhere
{
    public OutrasPartesClienteResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOutrasPartesCliente(sqlWhere: where, parameters: parameters, oCnn: oCnn);
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
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            outraspartescliente.DtNasc = dbRec.FDtNasc;
        return outraspartescliente;
    }
}