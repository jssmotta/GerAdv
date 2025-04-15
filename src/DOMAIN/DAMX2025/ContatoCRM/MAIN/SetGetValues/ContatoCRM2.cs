namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBContatoCRM
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBContatoCRMDicInfo.AgeClienteAvisado:
                FAgeClienteAvisado = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContatoCRMDicInfo.DocsViaRecebimento:
                FDocsViaRecebimento = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContatoCRMDicInfo.NaoPublicavel:
                FNaoPublicavel = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContatoCRMDicInfo.Notificar:
                FNotificar = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContatoCRMDicInfo.Ocultar:
                FOcultar = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContatoCRMDicInfo.Assunto:
                FAssunto = $"{value}"; // rgo J3: string
                return;
            case DBContatoCRMDicInfo.IsDocsRecebidos:
                FIsDocsRecebidos = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContatoCRMDicInfo.QuemNotificou:
                FQuemNotificou = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContatoCRMDicInfo.DataNotificou:
                FDataNotificou = $"{value}"; // rgo J3: DateTime
                return;
            case DBContatoCRMDicInfo.Operador:
                FOperador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContatoCRMDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContatoCRMDicInfo.HoraNotificou:
                FHoraNotificou = $"{value}"; // rgo J3: DateTime
                return;
            case DBContatoCRMDicInfo.ObjetoNotificou:
                FObjetoNotificou = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContatoCRMDicInfo.PessoaContato:
                FPessoaContato = $"{value}"; // rgo J3: string
                return;
            case DBContatoCRMDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBContatoCRMDicInfo.Tempo:
                FTempo = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBContatoCRMDicInfo.HoraInicial:
                FHoraInicial = $"{value}"; // rgo J3: DateTime
                return;
            case DBContatoCRMDicInfo.HoraFinal:
                FHoraFinal = $"{value}"; // rgo J3: DateTime
                return;
            case DBContatoCRMDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContatoCRMDicInfo.Importante:
                FImportante = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContatoCRMDicInfo.Urgente:
                FUrgente = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContatoCRMDicInfo.GerarHoraTrabalhada:
                FGerarHoraTrabalhada = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContatoCRMDicInfo.ExibirNoTopo:
                FExibirNoTopo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContatoCRMDicInfo.TipoContatoCRM:
                FTipoContatoCRM = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContatoCRMDicInfo.Contato:
                FContato = $"{value}"; // rgo J3: string
                return;
            case DBContatoCRMDicInfo.Emocao:
                FEmocao = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContatoCRMDicInfo.Continuar:
                FContinuar = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContatoCRMDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBContatoCRMDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBContatoCRMDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContatoCRMDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBContatoCRMDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContatoCRMDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBContatoCRMDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBContatoCRMDicInfo.AgeClienteAvisado => NFAgeClienteAvisado(),
        DBContatoCRMDicInfo.DocsViaRecebimento => NFDocsViaRecebimento(),
        DBContatoCRMDicInfo.NaoPublicavel => FNaoPublicavel.ToString(),
        DBContatoCRMDicInfo.Notificar => FNotificar.ToString(),
        DBContatoCRMDicInfo.Ocultar => FOcultar.ToString(),
        DBContatoCRMDicInfo.Assunto => NFAssunto(),
        DBContatoCRMDicInfo.IsDocsRecebidos => FIsDocsRecebidos.ToString(),
        DBContatoCRMDicInfo.QuemNotificou => NFQuemNotificou(),
        DBContatoCRMDicInfo.DataNotificou => NFDataNotificou(),
        DBContatoCRMDicInfo.Operador => NFOperador(),
        DBContatoCRMDicInfo.Cliente => NFCliente(),
        DBContatoCRMDicInfo.HoraNotificou => NFHoraNotificou(),
        DBContatoCRMDicInfo.ObjetoNotificou => NFObjetoNotificou(),
        DBContatoCRMDicInfo.PessoaContato => NFPessoaContato(),
        DBContatoCRMDicInfo.Data => NFData(),
        DBContatoCRMDicInfo.Tempo => NFTempo(),
        DBContatoCRMDicInfo.HoraInicial => NFHoraInicial(),
        DBContatoCRMDicInfo.HoraFinal => NFHoraFinal(),
        DBContatoCRMDicInfo.Processo => NFProcesso(),
        DBContatoCRMDicInfo.Importante => FImportante.ToString(),
        DBContatoCRMDicInfo.Urgente => FUrgente.ToString(),
        DBContatoCRMDicInfo.GerarHoraTrabalhada => FGerarHoraTrabalhada.ToString(),
        DBContatoCRMDicInfo.ExibirNoTopo => FExibirNoTopo.ToString(),
        DBContatoCRMDicInfo.TipoContatoCRM => NFTipoContatoCRM(),
        DBContatoCRMDicInfo.Contato => NFContato(),
        DBContatoCRMDicInfo.Emocao => NFEmocao(),
        DBContatoCRMDicInfo.Continuar => FContinuar.ToString(),
        DBContatoCRMDicInfo.Bold => FBold.ToString(),
        DBContatoCRMDicInfo.GUID => NFGUID(),
        DBContatoCRMDicInfo.QuemCad => NFQuemCad(),
        DBContatoCRMDicInfo.DtCad => MDtCad,
        DBContatoCRMDicInfo.QuemAtu => NFQuemAtu(),
        DBContatoCRMDicInfo.DtAtu => MDtAtu,
        DBContatoCRMDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}