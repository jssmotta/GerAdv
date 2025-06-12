#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IColaboradoresWhere
{
    ColaboradoresResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Colaboradores : IColaboradoresWhere
{
    public ColaboradoresResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBColaboradores(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var colaboradores = new ColaboradoresResponse
        {
            Id = dbRec.ID,
            Cargo = dbRec.FCargo,
            Cliente = dbRec.FCliente,
            Sexo = dbRec.FSexo,
            Nome = dbRec.FNome ?? string.Empty,
            CPF = dbRec.FCPF ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Idade = dbRec.FIdade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP ?? string.Empty,
            Cidade = dbRec.FCidade,
            Fone = dbRec.FFone ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            CNH = dbRec.FCNH ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            colaboradores.DtNasc = dbRec.FDtNasc;
        return colaboradores;
    }
}