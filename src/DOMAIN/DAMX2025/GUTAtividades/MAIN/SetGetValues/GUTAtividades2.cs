namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGUTAtividades
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBGUTAtividadesDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBGUTAtividadesDicInfo.Observacao:
                FObservacao = $"{value}"; // rgo J3: string
                return;
            case DBGUTAtividadesDicInfo.GUTGrupo:
                FGUTGrupo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGUTAtividadesDicInfo.GUTPeriodicidade:
                FGUTPeriodicidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGUTAtividadesDicInfo.Operador:
                FOperador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGUTAtividadesDicInfo.Concluido:
                FConcluido = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBGUTAtividadesDicInfo.DataConcluido:
                FDataConcluido = $"{value}"; // rgo J3: DateTime
                return;
            case DBGUTAtividadesDicInfo.DiasParaIniciar:
                FDiasParaIniciar = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGUTAtividadesDicInfo.MinutosParaRealizar:
                FMinutosParaRealizar = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGUTAtividadesDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBGUTAtividadesDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGUTAtividadesDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBGUTAtividadesDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGUTAtividadesDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBGUTAtividadesDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBGUTAtividadesDicInfo.Nome => NFNome(),
        DBGUTAtividadesDicInfo.Observacao => NFObservacao(),
        DBGUTAtividadesDicInfo.GUTGrupo => NFGUTGrupo(),
        DBGUTAtividadesDicInfo.GUTPeriodicidade => NFGUTPeriodicidade(),
        DBGUTAtividadesDicInfo.Operador => NFOperador(),
        DBGUTAtividadesDicInfo.Concluido => FConcluido.ToString(),
        DBGUTAtividadesDicInfo.DataConcluido => NFDataConcluido(),
        DBGUTAtividadesDicInfo.DiasParaIniciar => NFDiasParaIniciar(),
        DBGUTAtividadesDicInfo.MinutosParaRealizar => NFMinutosParaRealizar(),
        DBGUTAtividadesDicInfo.GUID => NFGUID(),
        DBGUTAtividadesDicInfo.QuemCad => NFQuemCad(),
        DBGUTAtividadesDicInfo.DtCad => MDtCad,
        DBGUTAtividadesDicInfo.QuemAtu => NFQuemAtu(),
        DBGUTAtividadesDicInfo.DtAtu => MDtAtu,
        DBGUTAtividadesDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}