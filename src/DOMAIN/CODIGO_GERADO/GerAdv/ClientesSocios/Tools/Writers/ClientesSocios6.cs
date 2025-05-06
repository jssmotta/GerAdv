#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IClientesSociosWriter
{
    Entity.DBClientesSocios Write(Models.ClientesSocios clientessocios, int auditorQuem, SqlConnection oCnn);
}

public class ClientesSocios : IClientesSociosWriter
{
    public Entity.DBClientesSocios Write(Models.ClientesSocios clientessocios, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = clientessocios.Id.IsEmptyIDNumber() ? new Entity.DBClientesSocios() : new Entity.DBClientesSocios(clientessocios.Id, oCnn);
        dbRec.FSomenteRepresentante = clientessocios.SomenteRepresentante;
        dbRec.FIdade = clientessocios.Idade;
        dbRec.FIsRepresentanteLegal = clientessocios.IsRepresentanteLegal;
        dbRec.FQualificacao = clientessocios.Qualificacao;
        dbRec.FSexo = clientessocios.Sexo;
        if (clientessocios.DtNasc != null)
            dbRec.FDtNasc = clientessocios.DtNasc.ToString();
        dbRec.FNome = clientessocios.Nome;
        dbRec.FSite = clientessocios.Site;
        dbRec.FRepresentanteLegal = clientessocios.RepresentanteLegal;
        dbRec.FCliente = clientessocios.Cliente;
        dbRec.FEndereco = clientessocios.Endereco;
        dbRec.FBairro = clientessocios.Bairro;
        dbRec.FCEP = clientessocios.CEP.ClearInputCep();
        dbRec.FCidade = clientessocios.Cidade;
        dbRec.FRG = clientessocios.RG;
        dbRec.FCPF = clientessocios.CPF.ClearInputCpf();
        dbRec.FFone = clientessocios.Fone;
        dbRec.FParticipacao = clientessocios.Participacao;
        dbRec.FCargo = clientessocios.Cargo;
        dbRec.FEMail = clientessocios.EMail;
        dbRec.FObs = clientessocios.Obs;
        dbRec.FCNH = clientessocios.CNH;
        if (clientessocios.DataContrato != null)
            dbRec.FDataContrato = clientessocios.DataContrato.ToString();
        dbRec.FCNPJ = clientessocios.CNPJ.ClearInputCnpj();
        dbRec.FInscEst = clientessocios.InscEst;
        dbRec.FSocioEmpresaAdminNome = clientessocios.SocioEmpresaAdminNome;
        dbRec.FEnderecoSocio = clientessocios.EnderecoSocio;
        dbRec.FBairroSocio = clientessocios.BairroSocio;
        dbRec.FCEPSocio = clientessocios.CEPSocio;
        dbRec.FCidadeSocio = clientessocios.CidadeSocio;
        if (clientessocios.RGDataExp != null)
            dbRec.FRGDataExp = clientessocios.RGDataExp.ToString();
        dbRec.FSocioEmpresaAdminSomente = clientessocios.SocioEmpresaAdminSomente;
        dbRec.FTipo = clientessocios.Tipo;
        dbRec.FFax = clientessocios.Fax;
        dbRec.FClass = clientessocios.Class;
        dbRec.FEtiqueta = clientessocios.Etiqueta;
        dbRec.FAni = clientessocios.Ani;
        dbRec.FBold = clientessocios.Bold;
        dbRec.FGUID = clientessocios.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}