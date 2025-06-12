#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IClientesWriter
{
    Entity.DBClientes Write(Models.Clientes clientes, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(ClientesResponse clientes, int operadorId, MsiSqlConnection oCnn);
}

public class Clientes : IClientesWriter
{
    public void Delete(ClientesResponse clientes, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Clientes] WHERE cliCodigo={clientes.Id};", oCnn);
    }

    public Entity.DBClientes Write(Models.Clientes clientes, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = clientes.Id.IsEmptyIDNumber() ? new Entity.DBClientes() : new Entity.DBClientes(clientes.Id, oCnn);
        dbRec.FEmpresa = clientes.Empresa;
        dbRec.FIcone = clientes.Icone;
        dbRec.FNomeMae = clientes.NomeMae;
        if (clientes.RGDataExp != null)
            dbRec.FRGDataExp = clientes.RGDataExp.ToString();
        dbRec.FInativo = clientes.Inativo;
        dbRec.FQuemIndicou = clientes.QuemIndicou;
        dbRec.FSendEMail = clientes.SendEMail;
        dbRec.FNome = clientes.Nome;
        dbRec.FAdv = clientes.Adv;
        dbRec.FIDRep = clientes.IDRep;
        dbRec.FJuridica = clientes.Juridica;
        dbRec.FNomeFantasia = clientes.NomeFantasia;
        dbRec.FClass = clientes.Class;
        dbRec.FTipo = clientes.Tipo;
        if (clientes.DtNasc != null)
            dbRec.FDtNasc = clientes.DtNasc.ToString();
        dbRec.FInscEst = clientes.InscEst;
        dbRec.FQualificacao = clientes.Qualificacao;
        dbRec.FSexo = clientes.Sexo;
        dbRec.FIdade = clientes.Idade;
        dbRec.FCNPJ = clientes.CNPJ.ClearInputCnpj();
        dbRec.FCPF = clientes.CPF.ClearInputCpf();
        dbRec.FRG = clientes.RG;
        dbRec.FTipoCaptacao = clientes.TipoCaptacao;
        dbRec.FObservacao = clientes.Observacao;
        dbRec.FEndereco = clientes.Endereco;
        dbRec.FBairro = clientes.Bairro;
        dbRec.FCidade = clientes.Cidade;
        dbRec.FCEP = clientes.CEP.ClearInputCep();
        dbRec.FFax = clientes.Fax;
        dbRec.FFone = clientes.Fone;
        if (clientes.Data != null)
            dbRec.FData = clientes.Data.ToString();
        dbRec.FHomePage = clientes.HomePage;
        dbRec.FEMail = clientes.EMail;
        dbRec.FObito = clientes.Obito;
        dbRec.FNomePai = clientes.NomePai;
        dbRec.FRGOExpeditor = clientes.RGOExpeditor;
        dbRec.FRegimeTributacao = clientes.RegimeTributacao;
        dbRec.FEnquadramentoEmpresa = clientes.EnquadramentoEmpresa;
        dbRec.FReportECBOnly = clientes.ReportECBOnly;
        dbRec.FProBono = clientes.ProBono;
        dbRec.FCNH = clientes.CNH;
        dbRec.FPessoaContato = clientes.PessoaContato;
        dbRec.FEtiqueta = clientes.Etiqueta;
        dbRec.FAni = clientes.Ani;
        dbRec.FBold = clientes.Bold;
        dbRec.FGUID = clientes.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}