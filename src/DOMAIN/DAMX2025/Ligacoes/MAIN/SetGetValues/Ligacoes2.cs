namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBLigacoes
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBLigacoesDicInfo.Assunto:
                FAssunto = $"{value}"; // rgo J3: string
                return;
            case DBLigacoesDicInfo.AgeClienteAvisado:
                FAgeClienteAvisado = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLigacoesDicInfo.Celular:
                FCelular = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBLigacoesDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLigacoesDicInfo.Contato:
                FContato = $"{value}"; // rgo J3: string
                return;
            case DBLigacoesDicInfo.DataRealizada:
                FDataRealizada = $"{value}"; // rgo J3: DateTime
                return;
            case DBLigacoesDicInfo.QuemID:
                FQuemID = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLigacoesDicInfo.Telefonista:
                FTelefonista = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLigacoesDicInfo.UltimoAviso:
                FUltimoAviso = $"{value}"; // rgo J3: DateTime
                return;
            case DBLigacoesDicInfo.HoraFinal:
                FHoraFinal = $"{value}"; // rgo J3: DateTime
                return;
            case DBLigacoesDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBLigacoesDicInfo.QuemCodigo:
                FQuemCodigo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLigacoesDicInfo.Solicitante:
                FSolicitante = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLigacoesDicInfo.Para:
                FPara = $"{value}"; // rgo J3: string
                return;
            case DBLigacoesDicInfo.Fone:
                FFone = $"{value}"; // rgo J3: string
                return;
            case DBLigacoesDicInfo.Ramal:
                FRamal = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLigacoesDicInfo.Particular:
                FParticular = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBLigacoesDicInfo.Realizada:
                FRealizada = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBLigacoesDicInfo.Status:
                FStatus = $"{value}"; // rgo J3: string
                return;
            case DBLigacoesDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBLigacoesDicInfo.Hora:
                FHora = $"{value}"; // rgo J3: DateTime
                return;
            case DBLigacoesDicInfo.Urgente:
                FUrgente = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBLigacoesDicInfo.LigarPara:
                FLigarPara = $"{value}"; // rgo J3: string
                return;
            case DBLigacoesDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLigacoesDicInfo.StartScreen:
                FStartScreen = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBLigacoesDicInfo.Emotion:
                FEmotion = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLigacoesDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBLigacoesDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBLigacoesDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLigacoesDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBLigacoesDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLigacoesDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBLigacoesDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBLigacoesDicInfo.Assunto => NFAssunto(),
        DBLigacoesDicInfo.AgeClienteAvisado => NFAgeClienteAvisado(),
        DBLigacoesDicInfo.Celular => FCelular.ToString(),
        DBLigacoesDicInfo.Cliente => NFCliente(),
        DBLigacoesDicInfo.Contato => NFContato(),
        DBLigacoesDicInfo.DataRealizada => NFDataRealizada(),
        DBLigacoesDicInfo.QuemID => NFQuemID(),
        DBLigacoesDicInfo.Telefonista => NFTelefonista(),
        DBLigacoesDicInfo.UltimoAviso => NFUltimoAviso(),
        DBLigacoesDicInfo.HoraFinal => NFHoraFinal(),
        DBLigacoesDicInfo.Nome => NFNome(),
        DBLigacoesDicInfo.QuemCodigo => NFQuemCodigo(),
        DBLigacoesDicInfo.Solicitante => NFSolicitante(),
        DBLigacoesDicInfo.Para => NFPara(),
        DBLigacoesDicInfo.Fone => NFFone(),
        DBLigacoesDicInfo.Ramal => NFRamal(),
        DBLigacoesDicInfo.Particular => FParticular.ToString(),
        DBLigacoesDicInfo.Realizada => FRealizada.ToString(),
        DBLigacoesDicInfo.Status => NFStatus(),
        DBLigacoesDicInfo.Data => NFData(),
        DBLigacoesDicInfo.Hora => NFHora(),
        DBLigacoesDicInfo.Urgente => FUrgente.ToString(),
        DBLigacoesDicInfo.LigarPara => NFLigarPara(),
        DBLigacoesDicInfo.Processo => NFProcesso(),
        DBLigacoesDicInfo.StartScreen => FStartScreen.ToString(),
        DBLigacoesDicInfo.Emotion => NFEmotion(),
        DBLigacoesDicInfo.Bold => FBold.ToString(),
        DBLigacoesDicInfo.GUID => NFGUID(),
        DBLigacoesDicInfo.QuemCad => NFQuemCad(),
        DBLigacoesDicInfo.DtCad => MDtCad,
        DBLigacoesDicInfo.QuemAtu => NFQuemAtu(),
        DBLigacoesDicInfo.DtAtu => MDtAtu,
        DBLigacoesDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}