

using System.Text.Json;
using System.Text.Json.Serialization;

namespace MenphisSI.GerAdv.AI.Filters;
using MenphisSI.GerAdv.Filters;
public static class FilterFuncionariosTXT
{ 
    public static JsonSerializerOptions GetOptions()
    {
        var options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true
        };
        return options;
    }

 private const string PromptHeader = """

ATENÇÃO: A seguir está o JSON BASE do filtro atual. Você deve ATUALIZAR os campos conforme o pedido do usuário e as regras, e retornar APENAS o JSON FINAL atualizado (sem nenhum texto adicional).
{
 
""";
    private const string PromptFooter = """
}

""";

private const string Instructions = """


Você é um assistente que ajuda a preencher filtros para buscar Funcionarios em um sistema de banco de dados relacionados.

Instruções para preenchimento do FilterFuncionarios:

- O filter irá filtrar os Funcionarios conforme os campos preenchidos, o usuário pode pedir de várias formas para você buscar os dados.

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
Cargos é Cargo


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
- filterCargos: filtro específico para Cargos
- filterFuncao: filtro específico para Função
- filterCidade: filtro específico para Cidade


CHECKLIST ANTES DE RETORNAR O JSON:
- A consulta fala em "cadastrado(s)", "incluído(s)", "criado(s)"? Use dtcad/dtcad_end do filtro da ENTIDADE, não o campo data de negócio.
- A consulta fala em "agendados/marcados para", "do dia X"? Use os campos de data de NEGÓCIO (ex.: filterAgenda.data).
- A consulta fala em "alterados/atualizados"? Use dtatu/dtatu_end do filtro correspondente.

CAMPOS filterCargos (Cargos):
- nome: _nome ou descrição para Cargos;
Campos de Auditoria (detalhes no PromptAuditor):
- dtcad, dtcad_end: quando o Tipo foi CADASTRADO no sistema
- dtatu, dtatu_end: quando o Tipo foi ALTERADO no sistema
- quemcad, quemcad_end: ID do operador que cadastrou
- quematu, quematu_end: ID do operador que atualizou
- visto: 0=não, 1=sim, -2147483648=ambos
         

CAMPOS filterFuncao (Função):
- descricao: _nome ou descrição para Função;
Campos de Auditoria (detalhes no PromptAuditor):
- dtcad, dtcad_end: quando o Tipo foi CADASTRADO no sistema
- dtatu, dtatu_end: quando o Tipo foi ALTERADO no sistema
- quemcad, quemcad_end: ID do operador que cadastrou
- quematu, quematu_end: ID do operador que atualizou
- visto: 0=não, 1=sim, -2147483648=ambos
         

CAMPOS filterCidade (Cidade):
- ddd: DDD;
- top: Top;
- comarca: Comarca;
- capital: Capital;
- nome: _nome ou descrição para Cidade;
- uf: número ou IDs;
- sigla: Sigla;
Campos de Auditoria (detalhes no PromptAuditor):
- dtcad, dtcad_end: quando o Tipo foi CADASTRADO no sistema
- dtatu, dtatu_end: quando o Tipo foi ALTERADO no sistema
- quemcad, quemcad_end: ID do operador que cadastrou
- quematu, quematu_end: ID do operador que atualizou
- visto: 0=não, 1=sim, -2147483648=ambos
         

CAMPOS filterFuncionarios:(Colaborador)
- emailpro: EMailPro;
- cargo: número ou IDs;
- nome: _nome ou descrição para Colaborador;
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
         



IMPORTANTE:
- Para campos numéricos: use -2147483648 quando não quiser aplicar filtro;
- Para campos de texto: use string vazia "" quando não quiser aplicar filtro;
- Para campos de data: use formato brasileiro dd/MM/yyyy;
- Os campos _end são para criar intervalos de busca (range);
- Se ouvir "todos os Funcionarios" ou similar, deixe todos os campos com valores padrão;



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
    public static (string, string) GetPrompt(FilterFuncionarios? existingFilter, JsonSerializerOptions options)
     
    {
        var strJson = JsonSerializer.Serialize(existingFilter, options);
        var result = BuildPrompt(strJson); 

#if DEBUG   
        Console.WriteLine($"DEBUG: Prompt Funcionarios length: {result.Length}");
#endif

return (result, Instructions); 

}

private static string BuildPrompt(string jsonContent)
    {
        return PromptHeader + jsonContent + PromptFooter;
    }

}