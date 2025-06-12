#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEscritoriosWriter
{
    Entity.DBEscritorios Write(Models.Escritorios escritorios, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(EscritoriosResponse escritorios, int operadorId, MsiSqlConnection oCnn);
}

public class Escritorios : IEscritoriosWriter
{
    public void Delete(EscritoriosResponse escritorios, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Escritorios] WHERE escCodigo={escritorios.Id};", oCnn);
    }

    public Entity.DBEscritorios Write(Models.Escritorios escritorios, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = escritorios.Id.IsEmptyIDNumber() ? new Entity.DBEscritorios() : new Entity.DBEscritorios(escritorios.Id, oCnn);
        dbRec.FCNPJ = escritorios.CNPJ.ClearInputCnpj();
        dbRec.FCasa = escritorios.Casa;
        dbRec.FParceria = escritorios.Parceria;
        dbRec.FNome = escritorios.Nome;
        dbRec.FOAB = escritorios.OAB;
        dbRec.FEndereco = escritorios.Endereco;
        dbRec.FCidade = escritorios.Cidade;
        dbRec.FBairro = escritorios.Bairro;
        dbRec.FCEP = escritorios.CEP.ClearInputCep();
        dbRec.FFone = escritorios.Fone;
        dbRec.FFax = escritorios.Fax;
        dbRec.FSite = escritorios.Site;
        dbRec.FEMail = escritorios.EMail;
        dbRec.FOBS = escritorios.OBS;
        dbRec.FAdvResponsavel = escritorios.AdvResponsavel;
        dbRec.FSecretaria = escritorios.Secretaria;
        dbRec.FInscEst = escritorios.InscEst;
        dbRec.FCorrespondente = escritorios.Correspondente;
        dbRec.FTop = escritorios.Top;
        dbRec.FEtiqueta = escritorios.Etiqueta;
        dbRec.FBold = escritorios.Bold;
        dbRec.FGUID = escritorios.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}