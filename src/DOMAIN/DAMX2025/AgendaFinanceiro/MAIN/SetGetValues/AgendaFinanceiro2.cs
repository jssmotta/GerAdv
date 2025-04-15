namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaFinanceiro
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBAgendaFinanceiroDicInfo.IDCOB:
                FIDCOB = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.IDNE:
                FIDNE = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.PrazoProvisionado:
                FPrazoProvisionado = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.Oculto:
                FOculto = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.CartaPrecatoria:
                FCartaPrecatoria = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.RepetirDias:
                FRepetirDias = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.HrFinal:
                FHrFinal = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaFinanceiroDicInfo.Repetir:
                FRepetir = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.Advogado:
                FAdvogado = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.EventoGerador:
                FEventoGerador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.EventoData:
                FEventoData = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaFinanceiroDicInfo.Funcionario:
                FFuncionario = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaFinanceiroDicInfo.EventoPrazo:
                FEventoPrazo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.Hora:
                FHora = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaFinanceiroDicInfo.Compromisso:
                FCompromisso = $"{value}"; // rgo J3: string
                return;
            case DBAgendaFinanceiroDicInfo.TipoCompromisso:
                FTipoCompromisso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.DDias:
                FDDias = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaFinanceiroDicInfo.Dias:
                FDias = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.Liberado:
                FLiberado = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaFinanceiroDicInfo.Importante:
                FImportante = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaFinanceiroDicInfo.Concluido:
                FConcluido = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaFinanceiroDicInfo.Area:
                FArea = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.Justica:
                FJustica = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.IDHistorico:
                FIDHistorico = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.IDInsProcesso:
                FIDInsProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.Usuario:
                FUsuario = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.Preposto:
                FPreposto = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.QuemID:
                FQuemID = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.QuemCodigo:
                FQuemCodigo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.Status:
                FStatus = $"{value}"; // rgo J3: string
                return;
            case DBAgendaFinanceiroDicInfo.Valor:
                FValor = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBAgendaFinanceiroDicInfo.CompromissoHTML:
                FCompromissoHTML = $"{value}"; // rgo J3: string
                return;
            case DBAgendaFinanceiroDicInfo.Decisao:
                FDecisao = $"{value}"; // rgo J3: string
                return;
            case DBAgendaFinanceiroDicInfo.Revisar:
                FRevisar = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaFinanceiroDicInfo.RevisarP2:
                FRevisarP2 = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaFinanceiroDicInfo.Sempre:
                FSempre = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.PrazoDias:
                FPrazoDias = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.ProtocoloIntegrado:
                FProtocoloIntegrado = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.DataInicioPrazo:
                FDataInicioPrazo = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaFinanceiroDicInfo.UsuarioCiente:
                FUsuarioCiente = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaFinanceiroDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBAgendaFinanceiroDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaFinanceiroDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaFinanceiroDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaFinanceiroDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBAgendaFinanceiroDicInfo.IDCOB => NFIDCOB(),
        DBAgendaFinanceiroDicInfo.IDNE => NFIDNE(),
        DBAgendaFinanceiroDicInfo.PrazoProvisionado => NFPrazoProvisionado(),
        DBAgendaFinanceiroDicInfo.Cidade => NFCidade(),
        DBAgendaFinanceiroDicInfo.Oculto => NFOculto(),
        DBAgendaFinanceiroDicInfo.CartaPrecatoria => NFCartaPrecatoria(),
        DBAgendaFinanceiroDicInfo.RepetirDias => NFRepetirDias(),
        DBAgendaFinanceiroDicInfo.HrFinal => NFHrFinal(),
        DBAgendaFinanceiroDicInfo.Repetir => NFRepetir(),
        DBAgendaFinanceiroDicInfo.Advogado => NFAdvogado(),
        DBAgendaFinanceiroDicInfo.EventoGerador => NFEventoGerador(),
        DBAgendaFinanceiroDicInfo.EventoData => NFEventoData(),
        DBAgendaFinanceiroDicInfo.Funcionario => NFFuncionario(),
        DBAgendaFinanceiroDicInfo.Data => NFData(),
        DBAgendaFinanceiroDicInfo.EventoPrazo => NFEventoPrazo(),
        DBAgendaFinanceiroDicInfo.Hora => NFHora(),
        DBAgendaFinanceiroDicInfo.Compromisso => NFCompromisso(),
        DBAgendaFinanceiroDicInfo.TipoCompromisso => NFTipoCompromisso(),
        DBAgendaFinanceiroDicInfo.Cliente => NFCliente(),
        DBAgendaFinanceiroDicInfo.DDias => NFDDias(),
        DBAgendaFinanceiroDicInfo.Dias => NFDias(),
        DBAgendaFinanceiroDicInfo.Liberado => FLiberado.ToString(),
        DBAgendaFinanceiroDicInfo.Importante => FImportante.ToString(),
        DBAgendaFinanceiroDicInfo.Concluido => FConcluido.ToString(),
        DBAgendaFinanceiroDicInfo.Area => NFArea(),
        DBAgendaFinanceiroDicInfo.Justica => NFJustica(),
        DBAgendaFinanceiroDicInfo.Processo => NFProcesso(),
        DBAgendaFinanceiroDicInfo.IDHistorico => NFIDHistorico(),
        DBAgendaFinanceiroDicInfo.IDInsProcesso => NFIDInsProcesso(),
        DBAgendaFinanceiroDicInfo.Usuario => NFUsuario(),
        DBAgendaFinanceiroDicInfo.Preposto => NFPreposto(),
        DBAgendaFinanceiroDicInfo.QuemID => NFQuemID(),
        DBAgendaFinanceiroDicInfo.QuemCodigo => NFQuemCodigo(),
        DBAgendaFinanceiroDicInfo.Status => NFStatus(),
        DBAgendaFinanceiroDicInfo.Valor => NFValor(),
        DBAgendaFinanceiroDicInfo.CompromissoHTML => NFCompromissoHTML(),
        DBAgendaFinanceiroDicInfo.Decisao => NFDecisao(),
        DBAgendaFinanceiroDicInfo.Revisar => FRevisar.ToString(),
        DBAgendaFinanceiroDicInfo.RevisarP2 => FRevisarP2.ToString(),
        DBAgendaFinanceiroDicInfo.Sempre => NFSempre(),
        DBAgendaFinanceiroDicInfo.PrazoDias => NFPrazoDias(),
        DBAgendaFinanceiroDicInfo.ProtocoloIntegrado => NFProtocoloIntegrado(),
        DBAgendaFinanceiroDicInfo.DataInicioPrazo => NFDataInicioPrazo(),
        DBAgendaFinanceiroDicInfo.UsuarioCiente => FUsuarioCiente.ToString(),
        DBAgendaFinanceiroDicInfo.GUID => NFGUID(),
        DBAgendaFinanceiroDicInfo.QuemCad => NFQuemCad(),
        DBAgendaFinanceiroDicInfo.DtCad => MDtCad,
        DBAgendaFinanceiroDicInfo.QuemAtu => NFQuemAtu(),
        DBAgendaFinanceiroDicInfo.DtAtu => MDtAtu,
        DBAgendaFinanceiroDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}