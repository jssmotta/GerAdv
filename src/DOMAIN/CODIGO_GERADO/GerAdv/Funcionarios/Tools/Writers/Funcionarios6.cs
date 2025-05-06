#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFuncionariosWriter
{
    Entity.DBFuncionarios Write(Models.Funcionarios funcionarios, int auditorQuem, SqlConnection oCnn);
}

public class Funcionarios : IFuncionariosWriter
{
    public Entity.DBFuncionarios Write(Models.Funcionarios funcionarios, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = funcionarios.Id.IsEmptyIDNumber() ? new Entity.DBFuncionarios() : new Entity.DBFuncionarios(funcionarios.Id, oCnn);
        dbRec.FEMailPro = funcionarios.EMailPro;
        dbRec.FCargo = funcionarios.Cargo;
        dbRec.FNome = funcionarios.Nome;
        dbRec.FFuncao = funcionarios.Funcao;
        dbRec.FSexo = funcionarios.Sexo;
        dbRec.FRegistro = funcionarios.Registro;
        dbRec.FCPF = funcionarios.CPF.ClearInputCpf();
        dbRec.FRG = funcionarios.RG;
        dbRec.FTipo = funcionarios.Tipo;
        dbRec.FObservacao = funcionarios.Observacao;
        dbRec.FEndereco = funcionarios.Endereco;
        dbRec.FBairro = funcionarios.Bairro;
        dbRec.FCidade = funcionarios.Cidade;
        dbRec.FCEP = funcionarios.CEP.ClearInputCep();
        dbRec.FContato = funcionarios.Contato;
        dbRec.FFax = funcionarios.Fax;
        dbRec.FFone = funcionarios.Fone;
        dbRec.FEMail = funcionarios.EMail;
        if (funcionarios.Periodo_Ini != null)
            dbRec.FPeriodo_Ini = funcionarios.Periodo_Ini.ToString();
        if (funcionarios.Periodo_Fim != null)
            dbRec.FPeriodo_Fim = funcionarios.Periodo_Fim.ToString();
        dbRec.FCTPSNumero = funcionarios.CTPSNumero;
        dbRec.FCTPSSerie = funcionarios.CTPSSerie;
        dbRec.FPIS = funcionarios.PIS;
        dbRec.FSalario = funcionarios.Salario;
        if (funcionarios.CTPSDtEmissao != null)
            dbRec.FCTPSDtEmissao = funcionarios.CTPSDtEmissao.ToString();
        if (funcionarios.DtNasc != null)
            dbRec.FDtNasc = funcionarios.DtNasc.ToString();
        if (funcionarios.Data != null)
            dbRec.FData = funcionarios.Data.ToString();
        dbRec.FLiberaAgenda = funcionarios.LiberaAgenda;
        dbRec.FPasta = funcionarios.Pasta;
        dbRec.FClass = funcionarios.Class;
        dbRec.FEtiqueta = funcionarios.Etiqueta;
        dbRec.FAni = funcionarios.Ani;
        dbRec.FBold = funcionarios.Bold;
        dbRec.FGUID = funcionarios.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}