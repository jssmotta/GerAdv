#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IClientesSociosReader
{
    ClientesSociosResponse? Read(int id, SqlConnection oCnn);
    ClientesSociosResponse? Read(string where, SqlConnection oCnn);
    ClientesSociosResponse? Read(Entity.DBClientesSocios dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    ClientesSociosResponse? Read(DBClientesSocios dbRec);
}

public partial class ClientesSocios : IClientesSociosReader
{
    public ClientesSociosResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBClientesSocios(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ClientesSociosResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBClientesSocios(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ClientesSociosResponse? Read(Entity.DBClientesSocios dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

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
        clientessocios.Auditor = auditor;
        return clientessocios;
    }

    public ClientesSociosResponse? Read(DBClientesSocios dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

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
        clientessocios.Auditor = auditor;
        return clientessocios;
    }
}