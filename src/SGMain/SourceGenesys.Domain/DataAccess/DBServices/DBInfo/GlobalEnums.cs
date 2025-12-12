namespace MenphisSI;


/// <summary>
/// Grupos de dados
/// </summary>
[Serializable]
public enum EGroupSepDados
{
    /// <summary>
    /// Grupo Padrão/Básico
    /// </summary>
    GroupSepBasico = 0,
    /// <summary>
    /// Grupo com Informações
    /// </summary>
    GroupSepInformacao = 1,
    /// <summary>
    /// Dados da Pessoa Física
    /// </summary>
    GroupSepDadosPF = 2,
    /// <summary>
    /// Dados da Pessoa Jurídica
    /// </summary>
    GroupSepDadosPJ = 3,
    /// <summary>
    /// Representante legal
    /// </summary>
    GroupSepRepresentante = 4,
    /// <summary>
    /// Período (datas)
    /// </summary>
    GroupSepPeriodo = 5,
    /// <summary>
    /// Dados de Contato
    /// </summary>
    GroupSepContato = 6,
    /// <summary>
    /// Dados da carteira de Trabalho
    /// </summary>
    GroupSepCarteiraTrabalho = 7,
    /// <summary>
    /// Dados do Endereço
    /// </summary>
    GroupSepEndereco = 8,
    /// <summary>
    /// Separador
    /// </summary>
    GroupSepDadosGerais = 9,
    /// <summary>
    /// Dados de configuração
    /// </summary>
    GroupSepConfig = 10,
    /// <summary>
    /// Auditor do Sistema
    /// </summary>
    GroupSepAuditor = 11,
    /// <summary>
    /// Campos Shadows
    /// </summary>
    GroupSepShadows = 12
}
/// <summary>
/// Enumerador de tipos de dados dos Sistemas Menphis SI
/// </summary>
[Serializable]
public enum EDataTypeSystemInfo
{
    /// <summary>
    /// Campo código (ID)
    /// </summary>
    SystemInfoAutoincrement = 1,
    /// <summary>
    /// Campo Texto
    /// </summary>
    SystemInfoText = 20,
    /// <summary>
    /// Classification VIP++, VIP, A, B, C, E, Z
    /// </summary>
    SystemInfoTextClassificationStar = 201,
    /// <summary>
    /// Campo nome do cadastro (UNIQUE)
    /// </summary>
    SystemInfoTextNameDescription = 21,
    /// <summary>
    /// Número de Telefone
    /// </summary>
    SystemInfoTextPhoneNumber = 22,
    /// <summary>
    /// Número do Fax
    /// </summary>
    SystemInfoTextFax = 23,
    /// <summary>
    /// Endereço físico
    /// </summary>
    SystemInfoTextAddress = 24,
    /// <summary>
    /// Bairro
    /// </summary>
    SystemInfoTextDistrict = 25,
    /// <summary>
    /// CEP
    /// </summary>
    SystemInfoTextCep = 26,
    /// <summary>
    /// Cadastro de Pessoa Física CPF
    /// </summary>
    SystemInfoTextCpf = 27,
    /// <summary>
    /// Regisro Geral - Carteira de Identidade
    /// </summary>
    SystemInfoTextRG = 28,
    /// <summary>
    /// Cadastro Nacional de Pessoa Jurídica
    /// </summary>
    SystemInfoTextCnpj = 29,
    /// <summary>
    /// Inscrição Estadual
    /// </summary>
    SystemInfoTextInscricao = 30,
    /// <summary>
    /// E-mail pessoal
    /// </summary>
    SystemInfoTextEmail = 31,
    /// <summary>
    /// E-mail profissional
    /// </summary>
    SystemInfoTextEmailPro = 32,
    /// <summary>
    /// WebSite da Empresa
    /// </summary>
    SystemInfoTextWebsite = 33,
    /// <summary>
    /// WebSite da empresa
    /// </summary>
    SystemInfoTextWebpage = 34,
    /// <summary>
    /// Carteira de Trabalho
    /// </summary>
    SystemInfoTextCtps = 35,
    /// <summary>
    /// Número de Série da Carteira de Trabalho
    /// </summary>
    SystemInfoTextCtpsSerie = 36,
    /// <summary>
    /// PIS
    /// </summary>
    SystemInfoTextPis = 37,
    /// <summary>
    /// Campo Global Unique Id (GUID) do registro
    /// </summary>
    SystemInfoTextGuid = 38,
    /// <summary>
    /// Endereço de e-mail para cobrança
    /// </summary>
    SystemInfoTextEmailBilling = 39,
    /// <summary>
    /// Carteira Nacional de Habilitação
    /// </summary>
    SystemInfoTextCnh = 301,
    /// <summary>
    /// Campo Lógico (Sim/Não)
    /// </summary>
    SystemInfoBoolean = 40,
    /// <summary>
    /// Campo Sexo
    /// </summary>
    SystemInfoBooleanSex = 41,
    /// <summary>
    /// Campo indicando se o registro deve ser negritado na tela
    /// </summary>
    SystemInfoBooleanBold = 42,
    /// <summary>
    /// Auditor - Campo que indentifica se foi revisado o cadastramento
    /// </summary>
    SystemInfoBooleanAuditorReviewed = 43,
    /// <summary>
    /// Campo indicando se é para criar etiqueta
    /// </summary>
    SystemInfoBooleanTag = 443,
    /// <summary>
    /// Tipo da Pessoa (Físca ou Jurídica)
    /// </summary>
    SystemInfoBooleanTypePerson = 44,
    /// <summary>
    /// Campo para lembrar ou não de lembrar do aniversário
    /// </summary>
    SystemInfoBooleanRemmeberBirthday = 45,
    /// <summary>
    /// Campo numérico INT
    /// </summary>
    SystemInfoNumber = 5,
    /// <summary>
    /// Campo com decimais (dinheiro)
    /// </summary>
    SystemInfoDouble = 6,
    /// <summary>
    /// Campo numérico long
    /// </summary>
    SystemInfoNumberLong = 77,
    /// <summary>
    /// Campo Salário
    /// </summary>
    SystemInfoNumberSalary = 61,
    /// <summary>
    /// Campo Data/Hora
    /// </summary>
    SystemInfoDatetime = 7,
    SystemInfoTime = 777,
    /// <summary>
    /// Data de nascimento ou constituição
    /// </summary>
    SystemInfoDateBirthday = 71,
    /// <summary>
    /// Auditor - Data do Cadastramento do registro
    /// </summary>
    SystemInfoDateAdd = 72,
    SystemInfoDateOnly = 772,
    SystemInfoTimeOnly = 7772,
    /// <summary>
    /// Auditor - Data da Última alteração do registro
    /// </summary>
    SystemInfoDateUpdt = 73,
    /// <summary>
    /// Data de Início (Colaborador, Advogado, etc.)
    /// </summary>
    SystemInfoDateStart = 74,
    /// <summary>
    /// Data de Término (Colaborador, Advogado, etc.)
    /// </summary>
    SystemInfoDateEnds = 75,
    /// <summary>
    /// É uma chave estrangeira
    /// </summary>
    SystemInfoForeingkey = 10,
    /// <summary>
    /// Campo INT Auditor Quem Cadastrou
    /// </summary>
    SystemInfoForeingkeyWhoAdd = 102,
    /// <summary>
    /// Campo INT Auditor Quem Alterou por último
    /// </summary>
    SystemInfoForeingkeyWhoUpdt = 103,
    /// <summary>
    /// Campo memo
    /// </summary>
    SystemInfoMemo = 11,
    /// <summary>
    /// Campo Memo usado para observação do Cadastro
    /// </summary>
    SystemInfoMemoObservations = 111,
    /// <summary>
    /// Informação de Geolocalização
    /// </summary>
    SystemInfoGPS = 120,
    /// <summary>
    /// Byte
    /// </summary>
    SystemInfoByte = 130,
    /// <summary>
    /// Imagem byte[]
    /// </summary>
    SystemInfoByteArrayImagem = 131
}

