#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAdvogadosWhere
{
    AdvogadosResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Advogados : IAdvogadosWhere
{
    public AdvogadosResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAdvogados(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var advogados = new AdvogadosResponse
        {
            Id = dbRec.ID,
            Cargo = dbRec.FCargo,
            EMailPro = dbRec.FEMailPro ?? string.Empty,
            CPF = dbRec.FCPF ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Casa = dbRec.FCasa,
            NomeMae = dbRec.FNomeMae ?? string.Empty,
            Escritorio = dbRec.FEscritorio,
            Estagiario = dbRec.FEstagiario,
            OAB = dbRec.FOAB ?? string.Empty,
            NomeCompleto = dbRec.FNomeCompleto ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP ?? string.Empty,
            Sexo = dbRec.FSexo,
            Bairro = dbRec.FBairro ?? string.Empty,
            CTPSSerie = dbRec.FCTPSSerie ?? string.Empty,
            CTPS = dbRec.FCTPS ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Comissao = dbRec.FComissao,
            Salario = dbRec.FSalario,
            Secretaria = dbRec.FSecretaria ?? string.Empty,
            TextoProcuracao = dbRec.FTextoProcuracao ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Especializacao = dbRec.FEspecializacao ?? string.Empty,
            Pasta = dbRec.FPasta ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            ContaBancaria = dbRec.FContaBancaria ?? string.Empty,
            ParcTop = dbRec.FParcTop,
            Class = dbRec.FClass ?? string.Empty,
            Top = dbRec.FTop,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtInicio, out _))
            advogados.DtInicio = dbRec.FDtInicio;
        if (DateTime.TryParse(dbRec.FDtFim, out _))
            advogados.DtFim = dbRec.FDtFim;
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            advogados.DtNasc = dbRec.FDtNasc;
        return advogados;
    }
}