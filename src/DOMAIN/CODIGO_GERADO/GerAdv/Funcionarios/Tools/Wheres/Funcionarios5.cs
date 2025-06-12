#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFuncionariosWhere
{
    FuncionariosResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Funcionarios : IFuncionariosWhere
{
    public FuncionariosResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBFuncionarios(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var funcionarios = new FuncionariosResponse
        {
            Id = dbRec.ID,
            EMailPro = dbRec.FEMailPro ?? string.Empty,
            Cargo = dbRec.FCargo,
            Nome = dbRec.FNome ?? string.Empty,
            Funcao = dbRec.FFuncao,
            Sexo = dbRec.FSexo,
            Registro = dbRec.FRegistro ?? string.Empty,
            CPF = dbRec.FCPF ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Tipo = dbRec.FTipo,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP ?? string.Empty,
            Contato = dbRec.FContato ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            CTPSNumero = dbRec.FCTPSNumero ?? string.Empty,
            CTPSSerie = dbRec.FCTPSSerie ?? string.Empty,
            PIS = dbRec.FPIS ?? string.Empty,
            Salario = dbRec.FSalario,
            LiberaAgenda = dbRec.FLiberaAgenda,
            Pasta = dbRec.FPasta ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FPeriodo_Ini, out _))
            funcionarios.Periodo_Ini = dbRec.FPeriodo_Ini;
        if (DateTime.TryParse(dbRec.FPeriodo_Fim, out _))
            funcionarios.Periodo_Fim = dbRec.FPeriodo_Fim;
        if (DateTime.TryParse(dbRec.FCTPSDtEmissao, out _))
            funcionarios.CTPSDtEmissao = dbRec.FCTPSDtEmissao;
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            funcionarios.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FData, out _))
            funcionarios.Data = dbRec.FData;
        return funcionarios;
    }
}