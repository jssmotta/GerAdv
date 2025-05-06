#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPrepostosWriter
{
    Entity.DBPrepostos Write(Models.Prepostos prepostos, int auditorQuem, SqlConnection oCnn);
}

public class Prepostos : IPrepostosWriter
{
    public Entity.DBPrepostos Write(Models.Prepostos prepostos, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = prepostos.Id.IsEmptyIDNumber() ? new Entity.DBPrepostos() : new Entity.DBPrepostos(prepostos.Id, oCnn);
        dbRec.FNome = prepostos.Nome;
        dbRec.FFuncao = prepostos.Funcao;
        dbRec.FSetor = prepostos.Setor;
        if (prepostos.DtNasc != null)
            dbRec.FDtNasc = prepostos.DtNasc.ToString();
        dbRec.FQualificacao = prepostos.Qualificacao;
        dbRec.FSexo = prepostos.Sexo;
        dbRec.FIdade = prepostos.Idade;
        dbRec.FCPF = prepostos.CPF.ClearInputCpf();
        dbRec.FRG = prepostos.RG;
        if (prepostos.Periodo_Ini != null)
            dbRec.FPeriodo_Ini = prepostos.Periodo_Ini.ToString();
        if (prepostos.Periodo_Fim != null)
            dbRec.FPeriodo_Fim = prepostos.Periodo_Fim.ToString();
        dbRec.FRegistro = prepostos.Registro;
        dbRec.FCTPSNumero = prepostos.CTPSNumero;
        dbRec.FCTPSSerie = prepostos.CTPSSerie;
        if (prepostos.CTPSDtEmissao != null)
            dbRec.FCTPSDtEmissao = prepostos.CTPSDtEmissao.ToString();
        dbRec.FPIS = prepostos.PIS;
        dbRec.FSalario = prepostos.Salario;
        dbRec.FLiberaAgenda = prepostos.LiberaAgenda;
        dbRec.FObservacao = prepostos.Observacao;
        dbRec.FEndereco = prepostos.Endereco;
        dbRec.FBairro = prepostos.Bairro;
        dbRec.FCidade = prepostos.Cidade;
        dbRec.FCEP = prepostos.CEP.ClearInputCep();
        dbRec.FFone = prepostos.Fone;
        dbRec.FFax = prepostos.Fax;
        dbRec.FEMail = prepostos.EMail;
        dbRec.FPai = prepostos.Pai;
        dbRec.FMae = prepostos.Mae;
        dbRec.FClass = prepostos.Class;
        dbRec.FEtiqueta = prepostos.Etiqueta;
        dbRec.FAni = prepostos.Ani;
        dbRec.FBold = prepostos.Bold;
        dbRec.FGUID = prepostos.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}