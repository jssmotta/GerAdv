#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPreClientesWriter
{
    Entity.DBPreClientes Write(Models.PreClientes preclientes, int auditorQuem, SqlConnection oCnn);
}

public class PreClientes : IPreClientesWriter
{
    public Entity.DBPreClientes Write(Models.PreClientes preclientes, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = preclientes.Id.IsEmptyIDNumber() ? new Entity.DBPreClientes() : new Entity.DBPreClientes(preclientes.Id, oCnn);
        dbRec.FInativo = preclientes.Inativo;
        dbRec.FQuemIndicou = preclientes.QuemIndicou;
        dbRec.FNome = preclientes.Nome;
        dbRec.FAdv = preclientes.Adv;
        dbRec.FIDRep = preclientes.IDRep;
        dbRec.FJuridica = preclientes.Juridica;
        dbRec.FNomeFantasia = preclientes.NomeFantasia;
        dbRec.FClass = preclientes.Class;
        dbRec.FTipo = preclientes.Tipo;
        if (preclientes.DtNasc != null)
            dbRec.FDtNasc = preclientes.DtNasc.ToString();
        dbRec.FInscEst = preclientes.InscEst;
        dbRec.FQualificacao = preclientes.Qualificacao;
        dbRec.FSexo = preclientes.Sexo;
        dbRec.FIdade = preclientes.Idade;
        dbRec.FCNPJ = preclientes.CNPJ.ClearInputCnpj();
        dbRec.FCPF = preclientes.CPF.ClearInputCpf();
        dbRec.FRG = preclientes.RG;
        dbRec.FTipoCaptacao = preclientes.TipoCaptacao;
        dbRec.FObservacao = preclientes.Observacao;
        dbRec.FEndereco = preclientes.Endereco;
        dbRec.FBairro = preclientes.Bairro;
        dbRec.FCidade = preclientes.Cidade;
        dbRec.FCEP = preclientes.CEP.ClearInputCep();
        dbRec.FFax = preclientes.Fax;
        dbRec.FFone = preclientes.Fone;
        if (preclientes.Data != null)
            dbRec.FData = preclientes.Data.ToString();
        dbRec.FHomePage = preclientes.HomePage;
        dbRec.FEMail = preclientes.EMail;
        dbRec.FAssistido = preclientes.Assistido;
        dbRec.FAssRG = preclientes.AssRG;
        dbRec.FAssCPF = preclientes.AssCPF;
        dbRec.FAssEndereco = preclientes.AssEndereco;
        dbRec.FCNH = preclientes.CNH;
        dbRec.FEtiqueta = preclientes.Etiqueta;
        dbRec.FAni = preclientes.Ani;
        dbRec.FBold = preclientes.Bold;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}