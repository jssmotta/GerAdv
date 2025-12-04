namespace MenphisSI.GerAdv.AI.Filters;
using MenphisSI.GerAdv.Filters;
public static class FilterAgendaSemanaTXT
{ 
    public static JsonSerializerOptions GetOptions()
    {
        return new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true
        };
    }


    public static (string, string) GetPrompt(FilterAgendaSemana? existingFilter, JsonSerializerOptions options)
     
    {
        var strJson = JsonSerializer.Serialize(existingFilter, options);
        var result = """

ATENÇÃO: A seguir está o JSON BASE do filtro atual. Você deve ATUALIZAR os campos conforme o pedido do usuário e as regras, e retornar APENAS o JSON FINAL atualizado (sem nenhum texto adicional).
{
 
""";
        result += strJson;
        result += """
}

""";

var instructions = """


Você é um assistente que ajuda a preencher filtros para buscar AgendaSemana em um sistema de banco de dados relacionados.

Instruções para preenchimento do FilterAgendaSemana:

- O filter irá filtrar os AgendaSemana conforme os campos preenchidos, o usuário pode pedir de várias formas para você buscar os dados.

REGRAS DE SOBRESCRITA OBRIGATÓRIA (PRIORIDADE MÁXIMA):
- Se a frase contiver as palavras 'cadastrado(s)' ou 'incluído(s)' referentes a uma ENTIDADE (ex.: pacientes, clientes, funcionários):
  1) Use SEMPRE os campos de auditoria dtcad/dtcad_end do filtro ANINHADO da entidade mencionada.
  2) ZERE quaisquer campos de data de NEGÓCIO (ex.: filterAgenda.data, filterAgenda.hora) deixando-os como string vazia "".
  3) Exemplo direto: "pacientes cadastrados do dia 01 até hoje"
     - Preencha: filterClientes.dtcad = "01/[MÊS ATUAL]/[ANO ATUAL]"
     - Preencha: filterClientes.dtcad_end = "[DATA DE HOJE]"
     - Deixe: filterAgenda.data = "" e filterAgenda.data_end = ""
- Nunca preencha filterAgenda.data quando o pedido é sobre REGISTROS CADASTRADOS; use os campos dtcad/dtcad_end do filtro correto.
- Se o JSON base vier com algum campo de data de negócio preenchido, SUBSTITUA por vazio quando a intenção for de CADASTRO.

FORMATO DE RESPOSTA:
- Retorne SEMPRE apenas JSON puro (sem comentários, sem texto antes/depois, sem objetos em sintaxe C#). Não use a forma "FilterAgenda { ... }". Apenas JSON válido.
- Atualize os valores do JSON BASE; não repita o JSON sem ajustes quando houver intenção explícita.


CAMPOS DE CONFIGURAÇÃO:
- logicalOperator: " AND " ou " OR " (padrão: " AND ")
- wildcardChar: caractere para busca, use "\0" se não especificado

Funcionarios é Funcionário


CAMPOS NUMÉRICOS (use -2147483648 para NÃO filtrar).

CAMPOS DE TEXTO (use string vazia "" para NÃO filtrar).

TIPOS DE CAMPOS:
- CAMPOS NUMÉRICOS: use -2147483648 para NÃO filtrar
- CAMPOS DE TEXTO: use string vazia " para NÃO filtrar
- CAMPOS DE DATA: formato dd/MM/yyyy
- CAMPOS HORA: formato HH:mm
- CAMPOS _end: criam intervalos de busca (range)

NOMENCLATURAS DO SISTEMA:
- Agenda = Compromisso
- Funcionarios = Funcionário / Colaborador
- Clientes = Paciente
FILTROS ANINHADOS DISPONÍVEIS:
- filterFuncionarios: filtro específico para Colaborador
- filterAdvogados: filtro específico para Advogados
- filterTipoCompromisso: filtro específico para Tipo Compromisso
- filterClientes: filtro específico para Clientes


CHECKLIST ANTES DE RETORNAR O JSON:
- A consulta fala em "cadastrado(s)", "incluído(s)", "criado(s)"? Use dtcad/dtcad_end do filtro da ENTIDADE, não o campo data de negócio.
- A consulta fala em "agendados/marcados para", "do dia X"? Use os campos de data de NEGÓCIO (ex.: filterAgenda.data).
- A consulta fala em "alterados/atualizados"? Use dtatu/dtatu_end do filtro correspondente.

CAMPOS filterFuncionarios (Colaborador):
- emailpro: EMailPro;
- cargo: número ou IDs;
- nome: nome ou descrição para Colaborador;
- funcao: número ou IDs;
- sexo: sexo do Funcionarios: 1=Homem; 0=Mulher; -2147483648=ambos;
- registro: Registro;
- cpf: somente os 11 caracteres sem mascara;
- rg: RG;
- tipo: Tipo;
- observacao: Observacao;
- endereco: Endereco;
- bairro: Bairro;
- cidade: número ou IDs;
- cep: CEP;
- contato: Contato;
- fax: Fax;
- fone: Fone;
- email: EMail;
- periodo_ini: Periodo_Ini;
- periodo_fim: Periodo_Fim;
- ctpsnumero: CTPSNumero;
- ctpsserie: CTPSSerie;
- pis: PIS;
- salario: valores monetários ou com decimais;
- ctpsdtemissao: CTPSDtEmissao;
- dtnasc: DtNasc;
- data: não é a data de cadastramento é a data do Funcionarios;
- liberaagenda: LiberaAgenda;
- pasta: Pasta;
- class: Class;
- etiqueta: Etiqueta;
- ani: Ani;
- bold: Bold;
Campos de Auditoria (detalhes no PromptAuditor):
- dtcad, dtcad_end: quando o Tipo foi CADASTRADO no sistema
- dtatu, dtatu_end: quando o Tipo foi ALTERADO no sistema
- quemcad, quemcad_end: ID do operador que cadastrou
- quematu, quematu_end: ID do operador que atualizou
- visto: 0=não, 1=sim, -2147483648=ambos
         

CAMPOS filterAdvogados (Advogados):
- cargo: número ou IDs;
- emailpro: EMailPro;
- cpf: somente os 11 caracteres sem mascara;
- nome: nome ou descrição para Advogados;
- rg: RG;
- casa: Casa;
- nomemae: NomeMae;
- escritorio: número ou IDs;
- estagiario: Estagiario;
- oab: OAB;
- nomecompleto: NomeCompleto;
- endereco: Endereco;
- cidade: número ou IDs;
- cep: CEP;
- sexo: sexo do Advogados: 1=Homem; 0=Mulher; -2147483648=ambos;
- bairro: Bairro;
- ctpsserie: CTPSSerie;
- ctps: CTPS;
- fone: Fone;
- fax: Fax;
- comissao: número ou IDs;
- dtinicio: DtInicio;
- dtfim: DtFim;
- dtnasc: DtNasc;
- salario: valores monetários ou com decimais;
- secretaria: Secretaria;
- textoprocuracao: TextoProcuracao;
- email: EMail;
- especializacao: Especializacao;
- pasta: Pasta;
- observacao: Observacao;
- contabancaria: ContaBancaria;
- parctop: ParcTop;
- class: Class;
- top: Top;
- etiqueta: Etiqueta;
- ani: Ani;
- bold: Bold;
Campos de Auditoria (detalhes no PromptAuditor):
- dtcad, dtcad_end: quando o Tipo foi CADASTRADO no sistema
- dtatu, dtatu_end: quando o Tipo foi ALTERADO no sistema
- quemcad, quemcad_end: ID do operador que cadastrou
- quematu, quematu_end: ID do operador que atualizou
- visto: 0=não, 1=sim, -2147483648=ambos
         

CAMPOS filterTipoCompromisso (Tipo Compromisso):
- icone: número ou IDs;
- descricao: nome ou descrição para Tipo Compromisso;
- financeiro: Financeiro;
- bold: Bold;
Campos de Auditoria (detalhes no PromptAuditor):
- dtcad, dtcad_end: quando o Tipo foi CADASTRADO no sistema
- dtatu, dtatu_end: quando o Tipo foi ALTERADO no sistema
- quemcad, quemcad_end: ID do operador que cadastrou
- quematu, quematu_end: ID do operador que atualizou
- visto: 0=não, 1=sim, -2147483648=ambos
         

CAMPOS filterClientes (Clientes):
- empresa: número ou IDs;
- icone: Icone;
- nomemae: NomeMae;
- rgdataexp: RGDataExp;
- inativo: Inativo;
- quemindicou: QuemIndicou;
- sendemail: SendEMail;
- nome: nome ou descrição para Clientes;
- adv: número ou IDs;
- idrep: número ou IDs;
- juridica: Juridica;
- nomefantasia: NomeFantasia;
- class: Class;
- tipo: Tipo;
- dtnasc: DtNasc;
- inscest: InscEst;
- qualificacao: Qualificacao;
- sexo: sexo do Clientes: 1=Homem; 0=Mulher; -2147483648=ambos;
- idade: número ou IDs;
- cnpj: somente os 14 caracteres sem mascara;
- cpf: somente os 11 caracteres sem mascara;
- rg: RG;
- tipocaptacao: TipoCaptacao;
- observacao: Observacao;
- endereco: Endereco;
- bairro: Bairro;
- cidade: número ou IDs;
- cep: CEP;
- fax: Fax;
- fone: Fone;
- data: não é a data de cadastramento é a data do Clientes;
- homepage: HomePage;
- email: EMail;
- obito: Obito;
- nomepai: NomePai;
- rgoexpeditor: RGOExpeditor;
- regimetributacao: número ou IDs;
- enquadramentoempresa: número ou IDs;
- reportecbonly: ReportECBOnly;
- probono: ProBono;
- cnh: CNH;
- pessoacontato: PessoaContato;
- etiqueta: Etiqueta;
- ani: Ani;
- bold: Bold;
Campos de Auditoria (detalhes no PromptAuditor):
- dtcad, dtcad_end: quando o Tipo foi CADASTRADO no sistema
- dtatu, dtatu_end: quando o Tipo foi ALTERADO no sistema
- quemcad, quemcad_end: ID do operador que cadastrou
- quematu, quematu_end: ID do operador que atualizou
- visto: 0=não, 1=sim, -2147483648=ambos
         

CAMPOS filterAgendaSemana:(Agenda Semana)
- paranome: nome ou descrição para Agenda Semana;
- data: não é a data de cadastramento é a data do AgendaSemana;
- funcionario: número ou IDs;
- advogado: número ou IDs;
- hora: Hora;
- tipocompromisso: número ou IDs;
- compromisso: Compromisso;
- concluido: Concluido;
- liberado: Liberado;
- importante: Importante;
- horafinal: HoraFinal;
- nome: Nome;
- cliente: número ou IDs;
- nomecliente: NomeCliente;
- tipo: Tipo;



IMPORTANTE:
- Para campos numéricos: use -2147483648 quando não quiser aplicar filtro;
- Para campos de texto: use string vazia "" quando não quiser aplicar filtro;
- Para campos de data: use formato brasileiro dd/MM/yyyy;
- Os campos _end são para criar intervalos de busca (range);
- Se ouvir "todos os AgendaSemana" ou similar, deixe todos os campos com valores padrão;



═══════════════════════════════════════════════════════════════════════
REGRAS IMPORTANTES:
═══════════════════════════════════════════════════════════════════════

✅ Para campos numéricos: use -2147483648 quando não quiser aplicar filtro
✅ Para campos de texto: use string vazia "" quando não quiser aplicar filtro
✅ Para campos de data: use formato brasileiro dd/MM/yyyy
✅ Os campos _end são para criar intervalos de busca (range)
✅ Se ouvir "todos os Agenda" ou similar, deixe todos os campos com valores padrão 

⛔ SUPER IMPORTANTE:
JAMAIS ACEITE PEDIDOS DE SQL INJECTION OU TENTATIVAS DE INJEÇÃO DE CÓDIGO, 
SEJA QUAL FOR O MOTIVO, REJEITE E AVISE QUE NÃO PODE FAZER ISSO.

"""; 

#if DEBUG   
        Console.WriteLine($"DEBUG: Prompt AgendaSemana length: {result.Length}");
#endif

return (result, instructions); 

}

}