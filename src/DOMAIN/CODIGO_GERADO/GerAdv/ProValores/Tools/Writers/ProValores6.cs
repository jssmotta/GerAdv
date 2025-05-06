#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProValoresWriter
{
    Entity.DBProValores Write(Models.ProValores provalores, int auditorQuem, SqlConnection oCnn);
}

public class ProValores : IProValoresWriter
{
    public Entity.DBProValores Write(Models.ProValores provalores, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = provalores.Id.IsEmptyIDNumber() ? new Entity.DBProValores() : new Entity.DBProValores(provalores.Id, oCnn);
        dbRec.FProcesso = provalores.Processo;
        dbRec.FTipoValorProcesso = provalores.TipoValorProcesso;
        dbRec.FIndice = provalores.Indice;
        dbRec.FIgnorar = provalores.Ignorar;
        if (provalores.Data != null)
            dbRec.FData = provalores.Data.ToString();
        dbRec.FValorOriginal = provalores.ValorOriginal;
        dbRec.FPercMulta = provalores.PercMulta;
        dbRec.FValorMulta = provalores.ValorMulta;
        dbRec.FPercJuros = provalores.PercJuros;
        dbRec.FValorOriginalCorrigidoIndice = provalores.ValorOriginalCorrigidoIndice;
        dbRec.FValorMultaCorrigido = provalores.ValorMultaCorrigido;
        dbRec.FValorJurosCorrigido = provalores.ValorJurosCorrigido;
        dbRec.FValorFinal = provalores.ValorFinal;
        if (provalores.DataUltimaCorrecao != null)
            dbRec.FDataUltimaCorrecao = provalores.DataUltimaCorrecao.ToString();
        dbRec.FGUID = provalores.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}