#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOponentesWhere
{
    OponentesResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Oponentes : IOponentesWhere
{
    public OponentesResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOponentes(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var oponentes = new OponentesResponse
        {
            Id = dbRec.ID,
            EMPFuncao = dbRec.FEMPFuncao,
            CTPSNumero = dbRec.FCTPSNumero ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            CTPSSerie = dbRec.FCTPSSerie ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Adv = dbRec.FAdv,
            EMPCliente = dbRec.FEMPCliente,
            IDRep = dbRec.FIDRep,
            PIS = dbRec.FPIS ?? string.Empty,
            Contato = dbRec.FContato ?? string.Empty,
            CNPJ = dbRec.FCNPJ ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Juridica = dbRec.FJuridica,
            Tipo = dbRec.FTipo,
            Sexo = dbRec.FSexo,
            CPF = dbRec.FCPF ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Cidade = dbRec.FCidade,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Top = dbRec.FTop,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return oponentes;
    }
}