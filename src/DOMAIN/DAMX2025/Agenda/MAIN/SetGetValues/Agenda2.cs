namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgenda
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBAgendaDicInfo.IDCOB:
                FIDCOB = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.ClienteAvisado:
                FClienteAvisado = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaDicInfo.RevisarP2:
                FRevisarP2 = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaDicInfo.IDNE:
                FIDNE = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.Oculto:
                FOculto = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.CartaPrecatoria:
                FCartaPrecatoria = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.Revisar:
                FRevisar = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaDicInfo.HrFinal:
                FHrFinal = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaDicInfo.Advogado:
                FAdvogado = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.EventoGerador:
                FEventoGerador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.EventoData:
                FEventoData = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaDicInfo.Funcionario:
                FFuncionario = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaDicInfo.EventoPrazo:
                FEventoPrazo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.Hora:
                FHora = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaDicInfo.Compromisso:
                FCompromisso = $"{value}"; // rgo J3: string
                return;
            case DBAgendaDicInfo.TipoCompromisso:
                FTipoCompromisso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.Liberado:
                FLiberado = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaDicInfo.Importante:
                FImportante = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaDicInfo.Concluido:
                FConcluido = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaDicInfo.Area:
                FArea = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.Justica:
                FJustica = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.IDHistorico:
                FIDHistorico = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.IDInsProcesso:
                FIDInsProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.Usuario:
                FUsuario = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.Preposto:
                FPreposto = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.QuemID:
                FQuemID = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.QuemCodigo:
                FQuemCodigo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.Status:
                FStatus = $"{value}"; // rgo J3: string
                return;
            case DBAgendaDicInfo.Valor:
                FValor = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBAgendaDicInfo.Decisao:
                FDecisao = $"{value}"; // rgo J3: string
                return;
            case DBAgendaDicInfo.Sempre:
                FSempre = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.PrazoDias:
                FPrazoDias = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.ProtocoloIntegrado:
                FProtocoloIntegrado = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.DataInicioPrazo:
                FDataInicioPrazo = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaDicInfo.UsuarioCiente:
                FUsuarioCiente = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBAgendaDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBAgendaDicInfo.IDCOB => NFIDCOB(),
        DBAgendaDicInfo.ClienteAvisado => FClienteAvisado.ToString(),
        DBAgendaDicInfo.RevisarP2 => FRevisarP2.ToString(),
        DBAgendaDicInfo.IDNE => NFIDNE(),
        DBAgendaDicInfo.Cidade => NFCidade(),
        DBAgendaDicInfo.Oculto => NFOculto(),
        DBAgendaDicInfo.CartaPrecatoria => NFCartaPrecatoria(),
        DBAgendaDicInfo.Revisar => FRevisar.ToString(),
        DBAgendaDicInfo.HrFinal => NFHrFinal(),
        DBAgendaDicInfo.Advogado => NFAdvogado(),
        DBAgendaDicInfo.EventoGerador => NFEventoGerador(),
        DBAgendaDicInfo.EventoData => NFEventoData(),
        DBAgendaDicInfo.Funcionario => NFFuncionario(),
        DBAgendaDicInfo.Data => NFData(),
        DBAgendaDicInfo.EventoPrazo => NFEventoPrazo(),
        DBAgendaDicInfo.Hora => NFHora(),
        DBAgendaDicInfo.Compromisso => NFCompromisso(),
        DBAgendaDicInfo.TipoCompromisso => NFTipoCompromisso(),
        DBAgendaDicInfo.Cliente => NFCliente(),
        DBAgendaDicInfo.Liberado => FLiberado.ToString(),
        DBAgendaDicInfo.Importante => FImportante.ToString(),
        DBAgendaDicInfo.Concluido => FConcluido.ToString(),
        DBAgendaDicInfo.Area => NFArea(),
        DBAgendaDicInfo.Justica => NFJustica(),
        DBAgendaDicInfo.Processo => NFProcesso(),
        DBAgendaDicInfo.IDHistorico => NFIDHistorico(),
        DBAgendaDicInfo.IDInsProcesso => NFIDInsProcesso(),
        DBAgendaDicInfo.Usuario => NFUsuario(),
        DBAgendaDicInfo.Preposto => NFPreposto(),
        DBAgendaDicInfo.QuemID => NFQuemID(),
        DBAgendaDicInfo.QuemCodigo => NFQuemCodigo(),
        DBAgendaDicInfo.Status => NFStatus(),
        DBAgendaDicInfo.Valor => NFValor(),
        DBAgendaDicInfo.Decisao => NFDecisao(),
        DBAgendaDicInfo.Sempre => NFSempre(),
        DBAgendaDicInfo.PrazoDias => NFPrazoDias(),
        DBAgendaDicInfo.ProtocoloIntegrado => NFProtocoloIntegrado(),
        DBAgendaDicInfo.DataInicioPrazo => NFDataInicioPrazo(),
        DBAgendaDicInfo.UsuarioCiente => FUsuarioCiente.ToString(),
        DBAgendaDicInfo.GUID => NFGUID(),
        DBAgendaDicInfo.QuemCad => NFQuemCad(),
        DBAgendaDicInfo.DtCad => MDtCad,
        DBAgendaDicInfo.QuemAtu => NFQuemAtu(),
        DBAgendaDicInfo.DtAtu => MDtAtu,
        DBAgendaDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}