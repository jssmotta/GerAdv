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
    public enum ETipoDadosSysteminfo
    {
        /// <summary>
        /// Campo código (ID)
        /// </summary>
        SysteminfoContador = 1,
        /// <summary>
        /// Campo Texto
        /// </summary>
        SysteminfoText = 20,
        /// <summary>
        /// Classificação do Cadastro VIP++, VIP, A, B, C, E, Z
        /// </summary>
        SysteminfoTextClassificacaoStar = 201,
        /// <summary>
        /// Campo nome do cadastro (UNIQUE)
        /// </summary>
        SysteminfoTextNome = 21,
        /// <summary>
        /// Número de Telefone
        /// </summary>
        SysteminfoTextFone = 22,
        /// <summary>
        /// Número do Fax
        /// </summary>
        SysteminfoTextFax = 23,
        /// <summary>
        /// Endereço físico
        /// </summary>
        SysteminfoTextEndereco = 24,
        /// <summary>
        /// Bairro
        /// </summary>
        SysteminfoTextBairro = 25,
        /// <summary>
        /// CEP
        /// </summary>
        SysteminfoTextCep = 26,
        /// <summary>
        /// Cadastro de Pessoa Física CPF
        /// </summary>
        SysteminfoTextCpf = 27,
        /// <summary>
        /// Regisro Geral - Carteira de Identidade
        /// </summary>
        SysteminfoTextRG = 28,
        /// <summary>
        /// Cadastro Nacional de Pessoa Jurídica
        /// </summary>
        SysteminfoTextCnpj = 29,
        /// <summary>
        /// Inscrição Estadual
        /// </summary>
        SysteminfoTextInscricao = 30,
        /// <summary>
        /// E-mail pessoal
        /// </summary>
        SysteminfoTextEmail = 31,
        /// <summary>
        /// E-mail profissional
        /// </summary>
        SysteminfoTextEmailPro = 32,
        /// <summary>
        /// WebSite da Empresa
        /// </summary>
        SysteminfoTextWebsite = 33,
        /// <summary>
        /// WebSite da empresa
        /// </summary>
        SysteminfoTextWebpage = 34,
        /// <summary>
        /// Carteira de Trabalho
        /// </summary>
        SysteminfoTextCtps = 35,
        /// <summary>
        /// Número de Série da Carteira de Trabalho
        /// </summary>
        SysteminfoTextCtpsserie = 36,
        /// <summary>
        /// PIS
        /// </summary>
        SysteminfoTextPis = 37,
        /// <summary>
        /// Campo Global Unique Id (GUID) do registro
        /// </summary>
        SysteminfoTextGuid = 38,
        /// <summary>
        /// Endereço de e-mail para cobrança
        /// </summary>
        SysteminfoTextEmailCob = 39,
        /// <summary>
        /// Carteira Nacional de Habilitação
        /// </summary>
        SysteminfoTextCnh = 301,
        /// <summary>
        /// Campo Lógico (Sim/Não)
        /// </summary>
        SysteminfoBoolean = 40,
        /// <summary>
        /// Campo Sexo
        /// </summary>
        SysteminfoBooleanSexo = 41,
        /// <summary>
        /// Campo indicando se o registro deve ser negritado na tela
        /// </summary>
        SysteminfoBooleanBold = 42,
        /// <summary>
        /// Auditor - Campo que indentifica se foi revisado o cadastramento
        /// </summary>
        SysteminfoBooleanVisto = 43,
        /// <summary>
        /// Campo indicando se é para criar etiqueta
        /// </summary>
        SysteminfoBooleanEtiqueta = 43,
        /// <summary>
        /// Tipo da Pessoa (Físca ou Jurídica)
        /// </summary>
        SysteminfoBooleanTipoPessoa = 44,
        /// <summary>
        /// Campo para lembrar ou não de lembrar do aniversário
        /// </summary>
        SysteminfoBooleanLembrarAniversario = 45, // 24-03-2017
        /// <summary>
        /// Campo numérico INT
        /// </summary>
        SysteminfoNumber = 5,
        /// <summary>
        /// Campo com decimais (dinheiro)
        /// </summary>
        SysteminfoDouble = 6,
        /// <summary>
        /// Campo numérico long
        /// </summary>
        SysteminfoNumberLong = 7,
        /// <summary>
        /// Campo Salário
        /// </summary>
        SysteminfoDoubleSalario = 61,
        /// <summary>
        /// Campo Data/Hora
        /// </summary>
        SysteminfoDatetime = 7,
        /// <summary>
        /// Data de nascimento ou constituição
        /// </summary>
        SysteminfoDataNascimento = 71,
        /// <summary>
        /// Auditor - Data do Cadastramento do registro
        /// </summary>
        SysteminfoDataCadastramento = 72,
        /// <summary>
        /// Auditor - Data da Última alteração do registro
        /// </summary>
        SysteminfoDataModificacao = 73,
        /// <summary>
        /// Data de Início (Colaborador, Advogado, etc.)
        /// </summary>
        SysteminfoDataInicio = 74,
        /// <summary>
        /// Data de Término (Colaborador, Advogado, etc.)
        /// </summary>
        SysteminfoDataTermino = 75,
        /// <summary>
        /// É uma chave estrangeira
        /// </summary>
        SysteminfoForeingkey = 10,
        /// <summary>
        /// Campo INT cidade
        /// </summary>
        SysteminfoForeingkeyCidade = 101,
        /// <summary>
        /// Campo INT Auditor Quem Cadastrou
        /// </summary>
        SysteminfoForeingkeyQuemCad = 102,
        /// <summary>
        /// Campo INT Auditor Quem Alterou por último
        /// </summary>
        SysteminfoForeingkeyQuemAtu = 103,
        /// <summary>
        /// Campo memo
        /// </summary>
        SysteminfoMemo = 11,
        /// <summary>
        /// Campo Memo usado para observação do Cadastro
        /// </summary>
        SysteminfoMemoObservacao = 111,
        /// <summary>
        /// Informação de Geolocalização
        /// </summary>
        SysteminfoGPS = 120,
        /// <summary>
        /// Byte
        /// </summary>
        SysteminfoByte = 130,
        /// <summary>
        /// Imagem byte[]
        /// </summary>
        SysteminfoByteArrayImagem = 131
    }

 