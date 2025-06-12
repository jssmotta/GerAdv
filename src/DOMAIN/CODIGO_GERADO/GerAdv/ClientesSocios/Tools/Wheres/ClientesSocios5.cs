#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IClientesSociosWhere
{
    ClientesSociosResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class ClientesSocios : IClientesSociosWhere
{
    public ClientesSociosResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBClientesSocios(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var clientessocios = new ClientesSociosResponse
        {
            Id = dbRec.ID,
            SomenteRepresentante = dbRec.FSomenteRepresentante,
            Idade = dbRec.FIdade,
            IsRepresentanteLegal = dbRec.FIsRepresentanteLegal,
            Qualificacao = dbRec.FQualificacao ?? string.Empty,
            Sexo = dbRec.FSexo,
            Nome = dbRec.FNome ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            RepresentanteLegal = dbRec.FRepresentanteLegal ?? string.Empty,
            Cliente = dbRec.FCliente,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP ?? string.Empty,
            Cidade = dbRec.FCidade,
            RG = dbRec.FRG ?? string.Empty,
            CPF = dbRec.FCPF ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Participacao = dbRec.FParticipacao ?? string.Empty,
            Cargo = dbRec.FCargo ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
            CNH = dbRec.FCNH ?? string.Empty,
            CNPJ = dbRec.FCNPJ ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            SocioEmpresaAdminNome = dbRec.FSocioEmpresaAdminNome ?? string.Empty,
            EnderecoSocio = dbRec.FEnderecoSocio ?? string.Empty,
            BairroSocio = dbRec.FBairroSocio ?? string.Empty,
            CEPSocio = dbRec.FCEPSocio ?? string.Empty,
            CidadeSocio = dbRec.FCidadeSocio,
            SocioEmpresaAdminSomente = dbRec.FSocioEmpresaAdminSomente,
            Tipo = dbRec.FTipo,
            Fax = dbRec.FFax ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            clientessocios.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FDataContrato, out _))
            clientessocios.DataContrato = dbRec.FDataContrato;
        if (DateTime.TryParse(dbRec.FRGDataExp, out _))
            clientessocios.RGDataExp = dbRec.FRGDataExp;
        return clientessocios;
    }
}