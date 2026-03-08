variable "project_name" {
  description = "Nome do projeto gerado pelo SourceGenesys"
  type        = string
  default     = "MenphisSI.GerAdv"
}

variable "environment" {
  description = "Ambiente (dev, staging, production)"
  type        = string
  default     = "production"
}

variable "aws_region" {
  description = "Região AWS"
  type        = string
  default     = "us-east-1"
} 

variable "vps_prometheus_endpoint" {
  description = "Endpoint do Prometheus no Menphis (ex: https://p.menphis.net.br/metrics/job/seu-projeto)"
  type        = string
}

variable "vps_grafana_endpoint" {
  description = "Endpoint do Grafana no Menphis (https://k.menphis.net.br)"
  type        = string
  default     = ""
}

variable "vps_loki_endpoint" {
  description = "Endpoint do Loki no Menphis (https://loki.menphis.net.br)"
  type        = string
  default     = ""
}

variable "vps_tempo_endpoint" {
  description = "Endpoint do Tempo no Menphis (https://tempo.menphis.net.br)"
  type        = string
  default     = ""
}

variable "api_image_tag" {
  description = "Tag da imagem Docker da API"
  type        = string
  default     = "latest"
}

variable "api_cpu" {
  description = "CPU para task definition da API (256, 512, 1024, etc)"
  type        = number
  default     = 512
}

variable "api_memory" {
  description = "Memória para task definition da API (512, 1024, 2048, etc)"
  type        = number
  default     = 1024
}

variable "api_desired_count" {
  description = "Número desejado de tasks rodando"
  type        = number
  default     = 2
}

variable "api_port" {
  description = "Porta da API .NET"
  type        = number
  default     = 8080
}

variable "domain_name" {
  description = "Domínio customizado (opcional)"
  type        = string
  default     = ""
}

variable "enable_autoscaling" {
  description = "Habilitar auto scaling para ECS"
  type        = bool
  default     = true
}

variable "min_capacity" {
  description = "Capacidade mínima para auto scaling"
  type        = number
  default     = 2
}

variable "max_capacity" {
  description = "Capacidade máxima para auto scaling"
  type        = number
  default     = 10
}

# Variáveis de agendamento (Schedule)
variable "enable_schedule" {
  description = "Habilitar agendamento para parar/iniciar ECS automaticamente"
  type        = bool
  default     = false
}

variable "schedule_timezone" {
  description = "Timezone para o agendamento (informativo, cron usa UTC)"
  type        = string
  default     = "America/Sao_Paulo"
}

variable "schedule_stop_hour" {
  description = "Hora para parar (UTC - ex: 23h BRT = 02h UTC no horário de verão, 03h UTC no horário normal)"
  type        = number
  default     = 2
  
  validation {
    condition     = var.schedule_stop_hour >= 0 && var.schedule_stop_hour <= 23
    error_message = "Hora deve estar entre 0 e 23."
  }
}

variable "schedule_stop_minute" {
  description = "Minuto para parar (0-59)"
  type        = number
  default     = 0
  
  validation {
    condition     = var.schedule_stop_minute >= 0 && var.schedule_stop_minute <= 59
    error_message = "Minuto deve estar entre 0 e 59."
  }
}

variable "schedule_start_hour" {
  description = "Hora para iniciar (UTC - ex: 5h BRT = 08h UTC no horário de verão, 09h UTC no horário normal)"
  type        = number
  default     = 8
  
  validation {
    condition     = var.schedule_start_hour >= 0 && var.schedule_start_hour <= 23
    error_message = "Hora deve estar entre 0 e 23."
  }
}

variable "schedule_start_minute" {
  description = "Minuto para iniciar (0-59)"
  type        = number
  default     = 0
  
  validation {
    condition     = var.schedule_start_minute >= 0 && var.schedule_start_minute <= 59
    error_message = "Minuto deve estar entre 0 e 59."
  }
}

variable "schedule_weekdays_only" {
  description = "Aplicar agendamento apenas em dias úteis (segunda a sexta)"
  type        = bool
  default     = false
}
