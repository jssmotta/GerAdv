#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAdvogadosWriter
{
    Entity.DBAdvogados Write(Models.Advogados advogados, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(AdvogadosResponse advogados, int operadorId, MsiSqlConnection oCnn);
}

public class Advogados : IAdvogadosWriter
{
    public void Delete(AdvogadosResponse advogados, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Advogados] WHERE advCodigo={advogados.Id};", oCnn);
    }

    public Entity.DBAdvogados Write(Models.Advogados advogados, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = advogados.Id.IsEmptyIDNumber() ? new Entity.DBAdvogados() : new Entity.DBAdvogados(advogados.Id, oCnn);
        dbRec.FCargo = advogados.Cargo;
        dbRec.FEMailPro = advogados.EMailPro;
        dbRec.FCPF = advogados.CPF.ClearInputCpf();
        dbRec.FNome = advogados.Nome;
        dbRec.FRG = advogados.RG;
        dbRec.FCasa = advogados.Casa;
        dbRec.FNomeMae = advogados.NomeMae;
        dbRec.FEscritorio = advogados.Escritorio;
        dbRec.FEstagiario = advogados.Estagiario;
        dbRec.FOAB = advogados.OAB;
        dbRec.FNomeCompleto = advogados.NomeCompleto;
        dbRec.FEndereco = advogados.Endereco;
        dbRec.FCidade = advogados.Cidade;
        dbRec.FCEP = advogados.CEP.ClearInputCep();
        dbRec.FSexo = advogados.Sexo;
        dbRec.FBairro = advogados.Bairro;
        dbRec.FCTPSSerie = advogados.CTPSSerie;
        dbRec.FCTPS = advogados.CTPS;
        dbRec.FFone = advogados.Fone;
        dbRec.FFax = advogados.Fax;
        dbRec.FComissao = advogados.Comissao;
        if (advogados.DtInicio != null)
            dbRec.FDtInicio = advogados.DtInicio.ToString();
        if (advogados.DtFim != null)
            dbRec.FDtFim = advogados.DtFim.ToString();
        if (advogados.DtNasc != null)
            dbRec.FDtNasc = advogados.DtNasc.ToString();
        dbRec.FSalario = advogados.Salario;
        dbRec.FSecretaria = advogados.Secretaria;
        dbRec.FTextoProcuracao = advogados.TextoProcuracao;
        dbRec.FEMail = advogados.EMail;
        dbRec.FEspecializacao = advogados.Especializacao;
        dbRec.FPasta = advogados.Pasta;
        dbRec.FObservacao = advogados.Observacao;
        dbRec.FContaBancaria = advogados.ContaBancaria;
        dbRec.FParcTop = advogados.ParcTop;
        dbRec.FClass = advogados.Class;
        dbRec.FTop = advogados.Top;
        dbRec.FEtiqueta = advogados.Etiqueta;
        dbRec.FAni = advogados.Ani;
        dbRec.FBold = advogados.Bold;
        dbRec.FGUID = advogados.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}