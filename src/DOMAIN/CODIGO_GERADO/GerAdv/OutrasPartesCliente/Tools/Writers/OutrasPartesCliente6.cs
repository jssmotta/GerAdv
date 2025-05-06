#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOutrasPartesClienteWriter
{
    Entity.DBOutrasPartesCliente Write(Models.OutrasPartesCliente outraspartescliente, int auditorQuem, SqlConnection oCnn);
}

public class OutrasPartesCliente : IOutrasPartesClienteWriter
{
    public Entity.DBOutrasPartesCliente Write(Models.OutrasPartesCliente outraspartescliente, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = outraspartescliente.Id.IsEmptyIDNumber() ? new Entity.DBOutrasPartesCliente() : new Entity.DBOutrasPartesCliente(outraspartescliente.Id, oCnn);
        dbRec.FNome = outraspartescliente.Nome;
        dbRec.FTerceirizado = outraspartescliente.Terceirizado;
        dbRec.FClientePrincipal = outraspartescliente.ClientePrincipal;
        dbRec.FTipo = outraspartescliente.Tipo;
        dbRec.FSexo = outraspartescliente.Sexo;
        if (outraspartescliente.DtNasc != null)
            dbRec.FDtNasc = outraspartescliente.DtNasc.ToString();
        dbRec.FCPF = outraspartescliente.CPF.ClearInputCpf();
        dbRec.FRG = outraspartescliente.RG;
        dbRec.FCNPJ = outraspartescliente.CNPJ.ClearInputCnpj();
        dbRec.FInscEst = outraspartescliente.InscEst;
        dbRec.FNomeFantasia = outraspartescliente.NomeFantasia;
        dbRec.FEndereco = outraspartescliente.Endereco;
        dbRec.FCidade = outraspartescliente.Cidade;
        dbRec.FCEP = outraspartescliente.CEP.ClearInputCep();
        dbRec.FBairro = outraspartescliente.Bairro;
        dbRec.FFone = outraspartescliente.Fone;
        dbRec.FFax = outraspartescliente.Fax;
        dbRec.FEMail = outraspartescliente.EMail;
        dbRec.FSite = outraspartescliente.Site;
        dbRec.FClass = outraspartescliente.Class;
        dbRec.FEtiqueta = outraspartescliente.Etiqueta;
        dbRec.FAni = outraspartescliente.Ani;
        dbRec.FBold = outraspartescliente.Bold;
        dbRec.FGUID = outraspartescliente.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}