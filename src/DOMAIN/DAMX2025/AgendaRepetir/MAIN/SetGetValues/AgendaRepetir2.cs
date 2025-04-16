namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaRepetir
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBAgendaRepetirDicInfo.Advogado:
                FAdvogado = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRepetirDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRepetirDicInfo.DataFinal:
                FDataFinal = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaRepetirDicInfo.Funcionario:
                FFuncionario = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRepetirDicInfo.HoraFinal:
                FHoraFinal = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaRepetirDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRepetirDicInfo.Pessoal:
                FPessoal = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaRepetirDicInfo.Frequencia:
                FFrequencia = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRepetirDicInfo.Dia:
                FDia = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRepetirDicInfo.Mes:
                FMes = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRepetirDicInfo.Hora:
                FHora = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaRepetirDicInfo.IDQuem:
                FIDQuem = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRepetirDicInfo.IDQuem2:
                FIDQuem2 = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRepetirDicInfo.Mensagem:
                FMensagem = $"{value}"; // rgo J3: string
                return;
            case DBAgendaRepetirDicInfo.IDTipo:
                FIDTipo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRepetirDicInfo.ID1:
                FID1 = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRepetirDicInfo.ID2:
                FID2 = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRepetirDicInfo.ID3:
                FID3 = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRepetirDicInfo.ID4:
                FID4 = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRepetirDicInfo.Segunda:
                FSegunda = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaRepetirDicInfo.Quarta:
                FQuarta = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaRepetirDicInfo.Quinta:
                FQuinta = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaRepetirDicInfo.Sexta:
                FSexta = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaRepetirDicInfo.Sabado:
                FSabado = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaRepetirDicInfo.Domingo:
                FDomingo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaRepetirDicInfo.Terca:
                FTerca = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaRepetirDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRepetirDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaRepetirDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRepetirDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaRepetirDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBAgendaRepetirDicInfo.Advogado => NFAdvogado(),
        DBAgendaRepetirDicInfo.Cliente => NFCliente(),
        DBAgendaRepetirDicInfo.DataFinal => NFDataFinal(),
        DBAgendaRepetirDicInfo.Funcionario => NFFuncionario(),
        DBAgendaRepetirDicInfo.HoraFinal => NFHoraFinal(),
        DBAgendaRepetirDicInfo.Processo => NFProcesso(),
        DBAgendaRepetirDicInfo.Pessoal => FPessoal.ToString(),
        DBAgendaRepetirDicInfo.Frequencia => NFFrequencia(),
        DBAgendaRepetirDicInfo.Dia => NFDia(),
        DBAgendaRepetirDicInfo.Mes => NFMes(),
        DBAgendaRepetirDicInfo.Hora => NFHora(),
        DBAgendaRepetirDicInfo.IDQuem => NFIDQuem(),
        DBAgendaRepetirDicInfo.IDQuem2 => NFIDQuem2(),
        DBAgendaRepetirDicInfo.Mensagem => NFMensagem(),
        DBAgendaRepetirDicInfo.IDTipo => NFIDTipo(),
        DBAgendaRepetirDicInfo.ID1 => NFID1(),
        DBAgendaRepetirDicInfo.ID2 => NFID2(),
        DBAgendaRepetirDicInfo.ID3 => NFID3(),
        DBAgendaRepetirDicInfo.ID4 => NFID4(),
        DBAgendaRepetirDicInfo.Segunda => FSegunda.ToString(),
        DBAgendaRepetirDicInfo.Quarta => FQuarta.ToString(),
        DBAgendaRepetirDicInfo.Quinta => FQuinta.ToString(),
        DBAgendaRepetirDicInfo.Sexta => FSexta.ToString(),
        DBAgendaRepetirDicInfo.Sabado => FSabado.ToString(),
        DBAgendaRepetirDicInfo.Domingo => FDomingo.ToString(),
        DBAgendaRepetirDicInfo.Terca => FTerca.ToString(),
        DBAgendaRepetirDicInfo.QuemCad => NFQuemCad(),
        DBAgendaRepetirDicInfo.DtCad => MDtCad,
        DBAgendaRepetirDicInfo.QuemAtu => NFQuemAtu(),
        DBAgendaRepetirDicInfo.DtAtu => MDtAtu,
        DBAgendaRepetirDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}