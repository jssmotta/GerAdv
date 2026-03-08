# MenphisSI.GerAdv - Infraestrutura AWS

Configuração Terraform gerada pelo **SourceGenesys** para deployment de aplicação React + API .NET 10 na AWS.

## Arquitetura

### Frontend (React)
- **S3**: Hospedagem dos arquivos estáticos
- **CloudFront**: CDN global com cache e HTTPS

### Backend (API .NET 10)
- **ECR**: Repositório de imagens Docker
- **ECS Fargate**: Execução de containers serverless
- **Application Load Balancer**: Distribuição de tráfego
- **Auto Scaling**: Escala automática baseada em CPU/Memória

### Economia (Agendamento)
- **Lambda**: Função para parar/iniciar ECS
- **EventBridge**: Agendamento automático (cron)
- **Configurável**: Horários personalizados via variáveis

### Dados e Observabilidade
- **SQL Server**: Na VPS própria (não gerenciado pela AWS)
- **Prometheus**: Métricas em https://p.menphis.net.br
- **Grafana**: Dashboards em https://k.menphis.net.br
- **Loki**: Logs em https://loki.menphis.net.br
- **Tempo**: Traces em https://tempo.menphis.net.br
- **CloudWatch**: Logs e métricas AWS

## Pré-requisitos

1. AWS CLI configurado
2. Terraform >= 1.0 instalado
3. Docker instalado
4. Python 3.11+ (para testar Lambda localmente - opcional)
5. Acesso à VPS com SQL Server e stack de observabilidade

## Configuração Inicial

### 1. Preparar Lambda Function
```bash
# Linux/Mac
chmod +x package_lambda.sh
./package_lambda.sh

# Windows
package_lambda.bat
```

### 2. Configurar variáveis sensíveis

Edite `terraform.tfvars` e configure:
```hcl
 
 
vps_prometheus_endpoint = "https://p.menphis.net.br/metrics/job/MenphisSI.GerAdv"
vps_grafana_endpoint = "https://k.menphis.net.br"
vps_loki_endpoint = "https://loki.menphis.net.br"
vps_tempo_endpoint = "https://tempo.menphis.net.br"

# Agendamento
enable_schedule = true
schedule_stop_hour = 2    # 23h BRT = 02h UTC (próximo dia)
schedule_start_hour = 8   # 5h BRT = 08h UTC
```

### 3. Inicializar Terraform
```bash
cd terraform
terraform init
```

### 4. Validar configuração
```bash
terraform validate
terraform plan
```

### 5. Aplicar infraestrutura
```bash
terraform apply
```

Salve os outputs importantes:
```bash
terraform output > outputs.txt
```

## Agendamento para Economia

### Como funciona

O sistema de agendamento usa **EventBridge + Lambda** para:
1. **Parar** o ECS Service (desired count = 0) no horário configurado
2. **Iniciar** o ECS Service (desired count = valor original) no horário configurado

### Conversão de horários (Brasil → UTC)

**Brasil (BRT = UTC-3)**:
- 23h BRT = 02h UTC (próximo dia)
- 5h BRT = 08h UTC

**Exemplos de configuração**:
```hcl
# Desligar às 23h e ligar às 5h (BRT)
schedule_stop_hour = 2    # 23h BRT
schedule_start_hour = 8   # 5h BRT

# Desligar à meia-noite e ligar às 6h (BRT)
schedule_stop_hour = 3    # 00h BRT
schedule_start_hour = 9   # 6h BRT

# Desligar às 22h e ligar às 7h (BRT)
schedule_stop_hour = 1    # 22h BRT
schedule_start_hour = 10  # 7h BRT
```

### Economia estimada

Com agendamento **23h-5h** (6 horas/dia desligado):
- **Economia**: ~25% nos custos de ECS Fargate
- **Economia mensal**: ~$7.50 em um setup de 2 tasks

### Habilitar/Desabilitar agendamento
```hcl
# Habilitar
enable_schedule = true

# Desabilitar (manter sempre ligado)
enable_schedule = false
```

### Aplicar apenas em dias úteis
```hcl
# Segunda a sexta apenas
schedule_weekdays_only = true

# Todos os dias (incluindo fim de semana)
schedule_weekdays_only = false
```

### Verificar agendamento
```bash
# Ver regras do EventBridge
aws events list-rules --name-prefix MenphisSI.GerAdv

# Ver próximas execuções (não disponível diretamente, ver logs após execução)
aws logs tail /aws/lambda/MenphisSI.GerAdv-ecs-scheduler --follow

# Verificar estado atual do ECS
aws ecs describe-services \
  --cluster MenphisSI.GerAdv-cluster \
  --services MenphisSI.GerAdv-api-service
```

### Parar/Iniciar manualmente
```bash
# Parar manualmente
aws ecs update-service \
  --cluster MenphisSI.GerAdv-cluster \
  --service MenphisSI.GerAdv-api-service \
  --desired-count 0

# Iniciar manualmente
aws ecs update-service \
  --cluster MenphisSI.GerAdv-cluster \
  --service MenphisSI.GerAdv-api-service \
  --desired-count 2
```

## Deploy da API

### 1. Build e Push da imagem Docker
```bash
# Obter URL do ECR
ECR_URL=$(terraform output -raw ecr_repository_url)

# Login no ECR
aws ecr get-login-password --region us-east-1 | docker login --username AWS --password-stdin $ECR_URL

# Build da imagem
docker build -t MenphisSI.GerAdv-api:latest .

# Tag da imagem
docker tag MenphisSI.GerAdv-api:latest $ECR_URL:latest

# Push da imagem
docker push $ECR_URL:latest
```

### 2. Atualizar serviço ECS
```bash
# Forçar novo deployment
CLUSTER=$(terraform output -raw ecs_cluster_name)
SERVICE=$(terraform output -raw ecs_service_name)

aws ecs update-service \
  --cluster $CLUSTER \
  --service $SERVICE \
  --force-new-deployment \
  --region us-east-1
```

### 3. Verificar deploy
```bash
# Verificar status do serviço
aws ecs describe-services \
  --cluster $CLUSTER \
  --services $SERVICE \
  --region us-east-1

# Ver logs
aws logs tail /ecs/MenphisSI.GerAdv-api --follow --region us-east-1
```

## Deploy do React

### 1. Build do React
```bash
cd frontend
npm install
npm run build
```

### 2. Upload para S3
```bash
# Obter nome do bucket
BUCKET=$(terraform output -raw react_s3_bucket)

# Sync dos arquivos
aws s3 sync ./build s3://$BUCKET/ --delete

# Invalidar cache do CloudFront
DISTRIBUTION_ID=$(terraform output -raw cloudfront_distribution_id)
aws cloudfront create-invalidation \
  --distribution-id $DISTRIBUTION_ID \
  --paths "/*"
```

## Configuração da Aplicação React

No arquivo `.env` ou configuração do React, adicione:
```env
REACT_APP_API_URL=http://SEU_ALB_URL
REACT_APP_AUTH_ENDPOINT=/auth
```

A **URI** será gerenciada no nível da aplicação via **GerAAA** e passada na rota `/auth`.

## Monitoramento

### CloudWatch Logs
```bash
# Ver logs da API
aws logs tail /ecs/MenphisSI.GerAdv-api --follow --region us-east-1

# Ver logs do Lambda Scheduler
aws logs tail /aws/lambda/MenphisSI.GerAdv-ecs-scheduler --follow --region us-east-1
```

### Prometheus (Menphis)
- Métricas da aplicação enviadas para: `https://p.menphis.net.br`
- Consultar no Grafana: `https://k.menphis.net.br`

### Loki (Menphis)
- Logs agregados em: `https://loki.menphis.net.br`

### Tempo (Menphis)
- Traces distribuídos em: `https://tempo.menphis.net.br`

## URLs Importantes

Após o deploy, as URLs estarão disponíveis:
```bash
# API
terraform output api_url_full

# React
terraform output react_url_full
```

## Auto Scaling

O auto scaling está configurado para:
- **Mínimo**: 2 tasks
- **Máximo**: 10 tasks
- **Scale Up**: CPU > 70% ou Memory > 80%
- **Scale Down**: CPU < 70% e Memory < 80%

## Custos Estimados (us-east-1)

### Sem agendamento (24/7):
- **ECS Fargate** (2 tasks 512CPU/1024MB): ~$30/mês
- **Application Load Balancer**: ~$16/mês
- **CloudFront**: ~$1-10/mês (depende do tráfego)
- **S3**: <$1/mês
- **CloudWatch Logs**: ~$5/mês
- **ECR**: <$1/mês
- **Lambda**: <$0.20/mês
- **Total**: ~$53-62/mês

### Com agendamento (23h-5h desligado, 6h/dia):
- **ECS Fargate**: ~$22.50/mês (economia de $7.50)
- **Outros custos**: inalterados
- **Total**: ~$45.50-54.50/mês
- **Economia anual**: ~$90

## Troubleshooting

### API não inicia
```bash
# Ver logs detalhados
aws logs tail /ecs/MenphisSI.GerAdv-api --follow

# Verificar health check
aws elbv2 describe-target-health \
  --target-group-arn $(terraform output -raw target_group_arn)
```

### Agendamento não funciona
```bash
# Verificar regras EventBridge
aws events list-rules --name-prefix MenphisSI.GerAdv

# Ver logs do Lambda
aws logs tail /aws/lambda/MenphisSI.GerAdv-ecs-scheduler --follow

# Testar Lambda manualmente
aws lambda invoke \
  --function-name MenphisSI.GerAdv-ecs-scheduler \
  --payload '{"action":"stop","desiredCount":0}' \
  response.json
```

### React não carrega
```bash
# Verificar arquivos no S3
aws s3 ls s3://$(terraform output -raw react_s3_bucket)/

# Testar CloudFront
curl -I https://$(terraform output -raw react_cloudfront_url)
```

### Problemas de conexão com SQL Server
- Verificar security group da VPS
- Testar conectividade: `telnet <VPS_IP> 1433`
- Verificar connection string no Secrets Manager

## Limpeza

Para destruir toda a infraestrutura:
```bash
terraform destroy
```

**Atenção**: Isso apagará todos os recursos. Faça backup antes!

## Estrutura de Arquivos
```
terraform/
├── main.tf                   # Provider e recursos principais
├── variables.tf              # Definição de variáveis
├── outputs.tf                # Outputs importantes
├── backend.tf                # Configuração de state remoto
├── ecs.tf                    # ECS, ECR, ALB, Auto Scaling
├── s3_cloudfront.tf          # S3 e CloudFront para React
├── security_groups.tf        # Security Groups
├── iam.tf                    # Roles e políticas IAM
├── autoscaling_schedule.tf   # Agendamento Lambda + EventBridge
├── terraform.tfvars          # Valores das variáveis (não commitar!)
├── package_lambda.sh         # Script para zipar Lambda (Linux/Mac)
├── package_lambda.bat        # Script para zipar Lambda (Windows)
├── lambda/
│   ├── index.py             # Código da função Lambda
│   └── ecs_scheduler.zip    # Gerado pelo script
└── README.md                 # Esta documentação
```

## Próximos Passos

1. ✅ Configurar domínio customizado (Route 53)
2. ✅ Adicionar certificado SSL (ACM)
3. ✅ Configurar CI/CD (GitHub Actions)
4. ✅ Implementar backup automatizado
5. ✅ Configurar alertas no CloudWatch
6. ✅ Ajustar horários de agendamento conforme necessidade

---

**Gerado por**: SourceGenesys  
**Projeto**: MenphisSI.GerAdv  
**Ambiente**: production  
**Data**: 2026-03-07
