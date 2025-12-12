using Asp.Versioning;

namespace MenphisSI.BaseCommon.Services;

/// <summary>
/// Configurações para personalizar a inicialização da aplicação
/// Permite reutilizar IniciarApps em diferentes sistemas com configurações específicas
/// </summary>
public class ConfiguracaoInicializacao
{
    /// <summary>
    /// URL de redirecionamento para o endpoint raiz
    /// </summary>
    public string UrlRedirecionamentoRoot { get; set; } = "https://menphis.com.br/?ur=aaj";

    /// <summary>
    /// URL de redirecionamento para o endpoint da API
    /// </summary>
    public string UrlRedirecionamentoApi { get; set; } = "https://menphis.com.br/?ur=aajpi";
    
    /// <summary>
    /// Cultura a ser configurada (padrão: pt-BR)
    /// </summary>
    public string Cultura { get; set; } = "pt-BR";

    /// <summary>
    /// Nome da política CORS
    /// </summary>
    public string NomePoliticaCORS { get; set; } = "AllowSpecificOrigins";

    /// <summary>
    /// Origens CORS adicionais para desenvolvimento
    /// </summary>
    public List<string> OrigensCORSDesenvolvimento { get; set; } = ["http://localhost:3000"];

    /// <summary>
    /// Habilitar/desabilitar health checks
    /// </summary>
    public bool HabilitarHealthChecks { get; set; } = true;

    /// <summary>
    /// Habilitar/desabilitar compressão de resposta
    /// </summary>
    public bool HabilitarCompressao { get; set; } = true;

    /// <summary>
    /// Habilitar/desabilitar cache híbrido
    /// </summary>
    public bool HabilitarCacheHibrido { get; set; } = true;

    /// <summary>
    /// Habilitar/desabilitar autenticação JWT
    /// </summary>
    public bool HabilitarAutenticacaoJWT { get; set; } = true;

    /// <summary>
    /// Configurações customizadas de JWT
    /// </summary>
    public ConfiguracaoJWT ConfiguracaoJWT { get; set; } = new();

    /// <summary>
    /// Configurações de API Versioning
    /// </summary>
    public ConfiguracaoApiVersioning ConfiguracaoApiVersioning { get; set; } = new();

    /// <summary>
    /// Ação customizada para registrar serviços específicos do domínio
    /// </summary>
    public Action<WebApplicationBuilder>? RegistrarServicosCustomizados { get; set; }

    /// <summary>
    /// Ação customizada para configurar middlewares adicionais
    /// </summary>
    public Action<WebApplication>? ConfigurarMiddlewaresCustomizados { get; set; }

    /// <summary>
    /// Ação customizada para configurar endpoints adicionais
    /// </summary>
    public Action<WebApplication>? ConfigurarEndpointsCustomizados { get; set; }
}

/// <summary>
/// Configurações específicas para JWT
/// </summary>
public class ConfiguracaoJWT
{
    /// <summary>
    /// Requer HTTPS para metadata
    /// </summary>
    public bool RequireHttpsMetadata { get; set; } = false;

    /// <summary>
    /// Salvar token
    /// </summary>
    public bool SaveToken { get; set; } = true;

    /// <summary>
    /// Validar chave de assinatura do emissor
    /// </summary>
    public bool ValidateIssuerSigningKey { get; set; } = true;

    /// <summary>
    /// Validar emissor
    /// </summary>
    public bool ValidateIssuer { get; set; } = false;

    /// <summary>
    /// Validar audiência
    /// </summary>
    public bool ValidateAudience { get; set; } = false;

    /// <summary>
    /// Clock skew (diferença de tempo permitida)
    /// </summary>
    public TimeSpan ClockSkew { get; set; } = TimeSpan.Zero;
}

/// <summary>
/// Configurações para API Versioning
/// </summary>
public class ConfiguracaoApiVersioning
{
    /// <summary>
    /// Reportar versões da API
    /// </summary>
    public bool ReportApiVersions { get; set; } = true;

    /// <summary>
    /// Assumir versão padrão quando não especificada
    /// </summary>
    public bool AssumeDefaultVersionWhenUnspecified { get; set; } = true;

    /// <summary>
    /// Versão padrão da API
    /// </summary>
    public ApiVersion DefaultApiVersion { get; set; } = new(1, 0);
}