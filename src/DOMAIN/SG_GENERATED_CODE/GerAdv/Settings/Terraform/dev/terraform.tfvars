# Arquivo de variáveis - NÃO COMMITAR COM DADOS SENSÍVEIS
# Adicionar ao .gitignore: terraform.tfvars

project_name = "MenphisSI.GerAdv"
environment  = "dev"
aws_region   = "us-east-1" 
 
# Endpoints de observabilidade na VPS (Menphis)
vps_prometheus_endpoint = "https://p.menphis.net.br/metrics/job/MenphisSI.GerAdv"
vps_grafana_endpoint    = "https://k.menphis.net.br"
vps_loki_endpoint       = "https://loki.menphis.net.br"
vps_tempo_endpoint      = "https://tempo.menphis.net.br"

# Configurações da API
api_image_tag     = "latest"
api_cpu           = 512
api_memory        = 1024
api_desired_count = 2
api_port          = 8080

# Auto Scaling
enable_autoscaling = true
min_capacity       = 2
max_capacity       = 10

# Agendamento para economia (parar/iniciar automaticamente)
enable_schedule = true
schedule_timezone = "America/Sao_Paulo"

# Horários em UTC (ajustar conforme horário de verão)
# Brasil sem horário de verão: BRT = UTC-3
# 23h BRT = 02h UTC (próximo dia)
schedule_stop_hour   = 2
schedule_stop_minute = 0

# 5h BRT = 08h UTC
schedule_start_hour   = 8
schedule_start_minute = 0

# Aplicar apenas em dias úteis? (true = seg-sex, false = todos os dias)
schedule_weekdays_only = false

# Domínio customizado (opcional)
# domain_name = "api.example.com"
