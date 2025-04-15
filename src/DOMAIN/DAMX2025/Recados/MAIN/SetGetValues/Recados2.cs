namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBRecados
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBRecadosDicInfo.ClienteNome:
                FClienteNome = $"{value}"; // rgo J3: string
                return;
            case DBRecadosDicInfo.De:
                FDe = $"{value}"; // rgo J3: string
                return;
            case DBRecadosDicInfo.Para:
                FPara = $"{value}"; // rgo J3: string
                return;
            case DBRecadosDicInfo.Assunto:
                FAssunto = $"{value}"; // rgo J3: string
                return;
            case DBRecadosDicInfo.Concluido:
                FConcluido = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBRecadosDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBRecadosDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBRecadosDicInfo.Recado:
                FRecado = $"{value}"; // rgo J3: string
                return;
            case DBRecadosDicInfo.Urgente:
                FUrgente = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBRecadosDicInfo.Importante:
                FImportante = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBRecadosDicInfo.Hora:
                FHora = $"{value}"; // rgo J3: DateTime
                return;
            case DBRecadosDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBRecadosDicInfo.Voltara:
                FVoltara = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBRecadosDicInfo.Pessoal:
                FPessoal = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBRecadosDicInfo.Retornar:
                FRetornar = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBRecadosDicInfo.RetornoData:
                FRetornoData = $"{value}"; // rgo J3: DateTime
                return;
            case DBRecadosDicInfo.Emotion:
                FEmotion = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBRecadosDicInfo.InternetID:
                FInternetID = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBRecadosDicInfo.Uploaded:
                FUploaded = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBRecadosDicInfo.Natureza:
                FNatureza = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBRecadosDicInfo.BIU:
                FBIU = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBRecadosDicInfo.AguardarRetorno:
                FAguardarRetorno = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBRecadosDicInfo.AguardarRetornoPara:
                FAguardarRetornoPara = $"{value}"; // rgo J3: string
                return;
            case DBRecadosDicInfo.AguardarRetornoOK:
                FAguardarRetornoOK = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBRecadosDicInfo.ParaID:
                FParaID = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBRecadosDicInfo.NaoPublicavel:
                FNaoPublicavel = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBRecadosDicInfo.IsContatoCRM:
                FIsContatoCRM = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBRecadosDicInfo.MasterID:
                FMasterID = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBRecadosDicInfo.ListaPara:
                FListaPara = $"{value}"; // rgo J3: string
                return;
            case DBRecadosDicInfo.Typed:
                FTyped = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBRecadosDicInfo.AssuntoRecado:
                FAssuntoRecado = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBRecadosDicInfo.Historico:
                FHistorico = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBRecadosDicInfo.ContatoCRM:
                FContatoCRM = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBRecadosDicInfo.Ligacoes:
                FLigacoes = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBRecadosDicInfo.Agenda:
                FAgenda = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBRecadosDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBRecadosDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBRecadosDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBRecadosDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBRecadosDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBRecadosDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBRecadosDicInfo.ClienteNome => NFClienteNome(),
        DBRecadosDicInfo.De => NFDe(),
        DBRecadosDicInfo.Para => NFPara(),
        DBRecadosDicInfo.Assunto => NFAssunto(),
        DBRecadosDicInfo.Concluido => FConcluido.ToString(),
        DBRecadosDicInfo.Processo => NFProcesso(),
        DBRecadosDicInfo.Cliente => NFCliente(),
        DBRecadosDicInfo.Recado => NFRecado(),
        DBRecadosDicInfo.Urgente => FUrgente.ToString(),
        DBRecadosDicInfo.Importante => FImportante.ToString(),
        DBRecadosDicInfo.Hora => NFHora(),
        DBRecadosDicInfo.Data => NFData(),
        DBRecadosDicInfo.Voltara => FVoltara.ToString(),
        DBRecadosDicInfo.Pessoal => FPessoal.ToString(),
        DBRecadosDicInfo.Retornar => FRetornar.ToString(),
        DBRecadosDicInfo.RetornoData => NFRetornoData(),
        DBRecadosDicInfo.Emotion => NFEmotion(),
        DBRecadosDicInfo.InternetID => NFInternetID(),
        DBRecadosDicInfo.Uploaded => FUploaded.ToString(),
        DBRecadosDicInfo.Natureza => NFNatureza(),
        DBRecadosDicInfo.BIU => FBIU.ToString(),
        DBRecadosDicInfo.AguardarRetorno => FAguardarRetorno.ToString(),
        DBRecadosDicInfo.AguardarRetornoPara => NFAguardarRetornoPara(),
        DBRecadosDicInfo.AguardarRetornoOK => FAguardarRetornoOK.ToString(),
        DBRecadosDicInfo.ParaID => NFParaID(),
        DBRecadosDicInfo.NaoPublicavel => FNaoPublicavel.ToString(),
        DBRecadosDicInfo.IsContatoCRM => FIsContatoCRM.ToString(),
        DBRecadosDicInfo.MasterID => NFMasterID(),
        DBRecadosDicInfo.ListaPara => NFListaPara(),
        DBRecadosDicInfo.Typed => FTyped.ToString(),
        DBRecadosDicInfo.AssuntoRecado => NFAssuntoRecado(),
        DBRecadosDicInfo.Historico => NFHistorico(),
        DBRecadosDicInfo.ContatoCRM => NFContatoCRM(),
        DBRecadosDicInfo.Ligacoes => NFLigacoes(),
        DBRecadosDicInfo.Agenda => NFAgenda(),
        DBRecadosDicInfo.GUID => NFGUID(),
        DBRecadosDicInfo.QuemCad => NFQuemCad(),
        DBRecadosDicInfo.DtCad => MDtCad,
        DBRecadosDicInfo.QuemAtu => NFQuemAtu(),
        DBRecadosDicInfo.DtAtu => MDtAtu,
        DBRecadosDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}