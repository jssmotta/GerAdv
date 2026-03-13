//using Domain.Sistemas.VoiceCommander;


//namespace API.Sistemas.VoiceCommander;

//[Route("api/v{version:apiVersion}/{tenantKey}/[controller]")]
//[ApiController]
//[ApiVersion("1.0")]
//[ExcludeFromCodeCoverage]
//public class CommanderSpeakerController : ControllerBase
//{
//    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
//    private readonly ICommandSpeakerService _commandSpeakerService;

//    public CommanderSpeakerController(ICommandSpeakerService commandSpeakerService)
//    {
//        _commandSpeakerService = commandSpeakerService ?? throw new ArgumentNullException(nameof(commandSpeakerService));
//    }

//    [HttpPost]
//    [Microsoft.AspNetCore.Authorization.Authorize]
//    public async Task<IActionResult> CommandSpeaker([FromBody] CommandSpeakerRequest request, [FromRoute, Required] string tenantKey, CancellationToken cancellationToken = default)
//    {
//        _logger.Info("CommanderSpeaker: Received message from {0}, Message: {1}", tenantKey, request?.Message);

//        try
//        {
//            // Validate request
//            if (request == null || string.IsNullOrWhiteSpace(request.Message))
//            {
//                _logger.Warn("CommanderSpeaker: Invalid or empty message received from {0}", tenantKey);
//                return BadRequest(new { error = "Message is required and cannot be empty" });
//            }

//            // Log the received voice command
//            _logger.Info("CommanderSpeaker: Processing voice command from {0}: '{1}'", tenantKey, request.Message);

//            // Process voice command using the service with correct context for the system's name structure
//            var dataAtual = DateTime.Now.ToString("dd/MM/yyyy (dddd)", new System.Globalization.CultureInfo("pt-BR"));
//            var context = $@"Você é um assistente especializado em extrair dados de pacientes de comandos de voz em português para agendamento médico.

//DATA ATUAL: {dataAtual}

//ESTRUTURA DE NOMES NO SISTEMA:
//1. Nome: TODOS os nomes EXCETO o último (pode conter múltiplas palavras)
//2. Sobrenome: APENAS A ÚLTIMA palavra do nome completo
//3. Identifique data/hora do agendamento (pode ser em formato natural como 'terça às 19h')
//4. Procure por número de prontuário se mencionado
//5. Se houver data de nascimento, extraia também

//FORMATOS DE DATA/HORA ACEITOS:
//- Dias da semana: 'segunda', 'terça', 'quarta', 'quinta', 'sexta', 'sábado', 'domingo'
//- Datas específicas: 'dia 1º de novembro', '15 de janeiro', '10/11/2024', '25/12'
//- Expressões: 'hoje', 'amanhã', 'próxima semana'
//- Horas: '18h', '19h30', '14:30', '09:00'

//REGRAS DE DATA/HORA:
//- Use a DATA ATUAL como referência para interpretar datas relativas
//- 'hoje' = {DateTime.Today:dd/MM/yyyy}
//- 'amanhã' = {DateTime.Today.AddDays(1):dd/MM/yyyy}
//- Para dias da semana (ex: 'segunda'), considere a PRÓXIMA ocorrência desse dia
//- Para meses futuros (ex: 'novembro'), use o ano atual se ainda não passou, senão próximo ano

//EXEMPLOS CORRETOS:
//- 'José Silva Pinto' → nome: 'José Silva', sobrenome: 'Pinto'
//- 'Maria Santos' → nome: 'Maria', sobrenome: 'Santos'  
//- 'João da Silva Oliveira' → nome: 'João da Silva', sobrenome: 'Oliveira'
//- 'Ana Paula Ferreira Lima' → nome: 'Ana Paula Ferreira', sobrenome: 'Lima'
//- 'Jefferson da Silva Júnior' → nome: 'Jefferson da Silva', sobrenome: 'Júnior'

//EXEMPLOS COMPLETOS:
//- 'Agendar para João Silva terça às 14h' → nome: 'João', sobrenome: 'Silva', dataHora: 'terça às 14h'
//- 'Consulta da Maria Santos prontuário 12345 amanhã às 9h' → nome: 'Maria', sobrenome: 'Santos', prontuario: '12345', dataHora: 'amanhã às 9h'
//- 'agenda para Jefferson da Silva Júnior no dia 1º de novembro as 18h' → nome: 'Jefferson da Silva', sobrenome: 'Júnior', dataHora: '1º de novembro as 18h'

//REGRAS IMPORTANTES: 
//- Nome = TODOS os nomes MENOS o último (ex: 'Jefferson da Silva' de 'Jefferson da Silva Júnior')
//- Sobrenome = SÓ A ÚLTIMA palavra (ex: 'Júnior' de 'Jefferson da Silva Júnior')
//- Para nomes com uma palavra só como 'João': nome='João', sobrenome='' (vazio)
//- Se detectar 'novo paciente' ou similar, coloque 'NOVO_PACIENTE' no campo prontuario
//- Mantenha o formato EXATO da data/hora para processamento posterior (não altere)
//- Números podem ser prontuários se mencionados explicitamente
//- SEMPRE considere a data atual fornecida para interpretar datas relativas

//Instruções para ESTRUTURA DE NOMES:
//- nome: TODOS os nomes EXCETO o último (ex: ""Jeferson Silva"" de ""Jeferson Silva Motta"")
//- sobrenome: APENAS a última palavra (ex: ""Motta"" de ""Jeferson Silva Motta"")
//- dataNascimento: data de nascimento se mencionada
//- prontuario: 'NOVO_PACIENTE' se detectar novo paciente, senão número do prontuário se mencionado
//- dataHora: data/hora do agendamento exatamente como mencionado
    
//IMPORTANTE: 
//- Para 'José Silva Pinto' → nome: 'José Silva', sobrenome: 'Pinto'
//- Para 'Maria Santos' → nome: 'Maria', sobrenome: 'Santos'
//- Para 'João' → nome: 'João', sobrenome: '' (vazio se só uma palavra)
//- Se ouvir ""novo paciente"" ou similar, coloque ""NOVO_PACIENTE"" no prontuario

//    Retorne APENAS um JSON válido no seguinte formato (sem texto adicional):
//    {{
//        ""nome"": """",
//        ""sobrenome"": """",
//        ""dataNascimento"": """",
//        ""prontuario"": """",
//        ""dataHora"": """"
//    }}



//";

//            var agendaResponse = await _commandSpeakerService.ProcessVoiceCommandAsync(context, request.Message, tenantKey);
            
//            if (agendaResponse != null)
//            {
//                var response = new CommandSpeakerResponse
//                {
//                    Success = true,
//                    Message = "Compromisso agendado com sucesso",
//                    ProcessedCommand = request.Message,
//                    Timestamp = DateTime.UtcNow,
//                    Uri = tenantKey,
//                    AgendaId = agendaResponse.Id,
//                    AgendaData = agendaResponse.Data,
//                    AgendaHora = agendaResponse.Hora,
//                    AgendaCompromisso = agendaResponse.Compromisso
//                };

//                _logger.Info("CommanderSpeaker: Successfully created appointment {0} for {1}", agendaResponse.Id, tenantKey);
//                return Ok(response);
//            }
//            else
//            {
//                var response = new CommandSpeakerResponse
//                {
//                    Success = false,
//                    Message = "Não foi possível processar o comando de voz e criar o compromisso",
//                    ProcessedCommand = request.Message,
//                    Timestamp = DateTime.UtcNow,
//                    Uri = tenantKey
//                };

//                _logger.Warn("CommanderSpeaker: Failed to create appointment for {0}", tenantKey);
//                return Ok(response);
//            }
//        }
//        catch (Exception ex)
//        {
//            _logger.Error(ex, "CommanderSpeaker: Error processing command from {0}", tenantKey);
//            return StatusCode(500, new { error = "Internal server error while processing voice command" });
//        }
//    }
//}



///// <summary>
///// Response model for voice command processing
///// </summary>
//public class CommandSpeakerResponse
//{
//    [JsonPropertyName("success")]
//    public bool Success { get; set; }

//    [JsonPropertyName("message")]
//    public string Message { get; set; } = string.Empty;

//    [JsonPropertyName("processedCommand")]
//    public string ProcessedCommand { get; set; } = string.Empty;

//    [JsonPropertyName("timestamp")]
//    public DateTime Timestamp { get; set; }

//    [JsonPropertyName("tenantKey")]
//    public string Uri { get; set; } = string.Empty;

//    [JsonPropertyName("agendaId")]
//    public int? AgendaId { get; set; }

//    [JsonPropertyName("agendaData")]
//    public string? AgendaData { get; set; }

//    [JsonPropertyName("agendaHora")]
//    public string? AgendaHora { get; set; }

//    [JsonPropertyName("agendaCompromisso")]
//    public string? AgendaCompromisso { get; set; }
//}
