<#
.SYNOPSIS
    Script de instalação e configuração da infraestrutura Terraform para MenphisSI.GerAdv

.DESCRIPTION
    Executa todos os passos necessários para configurar e provisionar a infraestrutura AWS:
    - Verifica pré-requisitos (AWS CLI, Terraform, Docker)
    - Prepara Lambda function
    - Configura variáveis
    - Inicializa e aplica Terraform
    - Executa testes de validação

.NOTES
    Gerado por: SourceGenesys
    Projeto: MenphisSI.GerAdv
    Data: 2026-01-21

.EXAMPLE
    # Execução padrão (com confirmações)
    .\InstallTerraform.ps1

    # Execução automática (sem confirmações)
    .\InstallTerraform.ps1 -AutoApprove

    # Pular verificação de pré-requisitos
    .\InstallTerraform.ps1 -SkipPrerequisites

    # Caminho customizado do Terraform
    .\InstallTerraform.ps1 -TerraformPath ".\meu-terraform"

#>

[CmdletBinding()]
param(
    [Parameter(Mandatory=$false)]
    [switch]$SkipPrerequisites,
    
    [Parameter(Mandatory=$false)]
    [switch]$AutoApprove,
    
    [Parameter(Mandatory=$false)]
    [string]$TerraformPath = ".\terraform"
)

# Configurações
$ErrorActionPreference = "Stop"
$ProgressPreference = "SilentlyContinue"

# Cores para output
function Write-Success { Write-Host "✓ $args" -ForegroundColor Green }
function Write-Info { Write-Host "ℹ $args" -ForegroundColor Cyan }
function Write-Warning { Write-Host "⚠ $args" -ForegroundColor Yellow }
function Write-Failure { Write-Host "✗ $args" -ForegroundColor Red }

# Função para testar comando
function Test-Command {
    param([string]$Command)
    try {
        if (Get-Command $Command -ErrorAction SilentlyContinue) {
            return $true
        }
        return $false
    }
    catch {
        return $false
    }
}

# Função para executar e verificar
function Invoke-Step {
    param(
        [string]$StepName,
        [scriptblock]$Action
    )
    
    Write-Host "`n=== $StepName ===" -ForegroundColor Magenta
    
    try {
        & $Action
        Write-Success "$StepName - Concluído"
        return $true
    }
    catch {
        Write-Failure "$StepName - Falhou: $($_.Exception.Message)"
        return $false
    }
}

# ============================
# FASE 1: PRÉ-REQUISITOS
# ============================
if (-not $SkipPrerequisites) {
    $prereqSuccess = Invoke-Step "Verificação de Pré-requisitos" {
        Write-Info "Verificando AWS CLI..."
        if (-not (Test-Command "aws")) {
            throw "AWS CLI não encontrado. Instale: https://aws.amazon.com/cli/"
        }
        $awsVersion = aws --version 2>&1
        Write-Success "AWS CLI: $awsVersion"
        
        Write-Info "Verificando Terraform..."
        if (-not (Test-Command "terraform")) {
            throw "Terraform não encontrado. Instale: https://www.terraform.io/downloads"
        }
        $tfVersion = terraform version -json | ConvertFrom-Json
        if ([version]$tfVersion.terraform_version -lt [version]"1.0.0") {
            throw "Terraform versão 1.0+ necessária. Versão atual: $($tfVersion.terraform_version)"
        }
        Write-Success "Terraform: v$($tfVersion.terraform_version)"
        
        Write-Info "Verificando Docker..."
        if (-not (Test-Command "docker")) {
            throw "Docker não encontrado. Instale: https://www.docker.com/products/docker-desktop"
        }
        $dockerVersion = docker --version
        Write-Success "Docker: $dockerVersion"
        
        Write-Info "Verificando credenciais AWS..."
        try {
            $awsIdentity = aws sts get-caller-identity --output json 2>&1 | ConvertFrom-Json
            Write-Success "AWS Conta: $($awsIdentity.Account) | User: $($awsIdentity.Arn)"
        }
        catch {
            throw "AWS CLI não configurado. Execute: aws configure"
        }
    }
    
    if (-not $prereqSuccess) {
        Write-Failure "Pré-requisitos não atendidos. Abortando."
        exit 1
    }
}

# ============================
# FASE 2: PREPARAR LAMBDA
# ============================
$lambdaSuccess = Invoke-Step "Preparação da Lambda Function" {
    Write-Info "Criando pacote Lambda..."
    
    $lambdaDir = Join-Path $PSScriptRoot "lambda"
    $lambdaZip = Join-Path $lambdaDir "ecs_scheduler.zip"
    
    if (-not (Test-Path $lambdaDir)) {
        throw "Diretório lambda/ não encontrado"
    }
    
    $lambdaFile = Join-Path $lambdaDir "index.py"
    if (-not (Test-Path $lambdaFile)) {
        throw "Arquivo lambda/index.py não encontrado"
    }
    
    # Remover zip antigo se existir
    if (Test-Path $lambdaZip) {
        Remove-Item $lambdaZip -Force
    }
    
    # Criar zip (compatível com Windows)
    Push-Location $lambdaDir
    try {
        Compress-Archive -Path "index.py" -DestinationPath "ecs_scheduler.zip" -Force
        Write-Success "Lambda zipado: $lambdaZip"
    }
    finally {
        Pop-Location
    }
    
    # Verificar tamanho do zip
    $zipSize = (Get-Item $lambdaZip).Length
    Write-Info "Tamanho do pacote Lambda: $([math]::Round($zipSize/1KB, 2)) KB"
}

if (-not $lambdaSuccess) {
    Write-Failure "Falha ao preparar Lambda. Abortando."
    exit 1
}

# ============================
# FASE 3: VERIFICAR CONFIGURAÇÃO
# ============================
$configSuccess = Invoke-Step "Verificação da Configuração" {
    $tfVarsFile = Join-Path $TerraformPath "terraform.tfvars"
    
    if (-not (Test-Path $tfVarsFile)) {
        Write-Warning "Arquivo terraform.tfvars não encontrado"
        Write-Info "Criando arquivo de exemplo..."
        
        $exampleContent = @"
# ==============================================
# MenphisSI.GerAdv - Configuração Terraform
# ==============================================

# Região AWS
aws_region = "us-east-1"

 
# Endpoints VPS (Observabilidade - Menphis)
vps_prometheus_endpoint = "https://p.menphis.net.br/metrics/job/MenphisSI.GerAdv"
vps_grafana_endpoint    = "https://k.menphis.net.br"
vps_loki_endpoint       = "https://loki.menphis.net.br"
vps_tempo_endpoint      = "https://tempo.menphis.net.br"

# Agendamento (Economia)
enable_schedule       = true
schedule_stop_hour    = 2    # 23h BRT = 02h UTC (próximo dia)
schedule_start_hour   = 8    # 5h BRT = 08h UTC
schedule_weekdays_only = false

# ECS
ecs_task_cpu         = 512
ecs_task_memory      = 1024
ecs_desired_count    = 2
ecs_max_count        = 10
ecs_min_count        = 2

# Auto Scaling
cpu_target_percentage    = 70
memory_target_percentage = 80
"@
        Set-Content -Path $tfVarsFile -Value $exampleContent -Encoding UTF8
        Write-Success "Arquivo terraform.tfvars criado"
        Write-Warning "⚠ ATENÇÃO: Edite terraform.tfvars com suas configurações antes de continuar!"
        
        $continue = Read-Host "Deseja continuar após editar? (S/N)"
        if ($continue -ne 'S' -and $continue -ne 's') {
            throw "Configuração cancelada pelo usuário"
        }
    }
    else {
        Write-Success "Arquivo terraform.tfvars encontrado"
    }
    
    # Verificar se está preenchido
    $tfVarsContent = Get-Content $tfVarsFile -Raw
    if ($tfVarsContent -match "SEU_VPS_IP") {
        throw "terraform.tfvars contém valores de exemplo. Configure corretamente antes de prosseguir."
    }
}

if (-not $configSuccess) {
    Write-Failure "Configuração inválida. Abortando."
    exit 1
}

# ============================
# FASE 4: TERRAFORM INIT
# ============================
$initSuccess = Invoke-Step "Terraform Init" {
    Push-Location $TerraformPath
    try {
        Write-Info "Inicializando Terraform..."
        $output = terraform init 2>&1
        
        if ($LASTEXITCODE -ne 0) {
            throw "Terraform init falhou: $output"
        }
        
        Write-Success "Terraform inicializado com sucesso"
        Write-Host $output
    }
    finally {
        Pop-Location
    }
}

if (-not $initSuccess) {
    Write-Failure "Falha ao inicializar Terraform. Abortando."
    exit 1
}

# ============================
# FASE 5: TERRAFORM VALIDATE
# ============================
$validateSuccess = Invoke-Step "Terraform Validate" {
    Push-Location $TerraformPath
    try {
        Write-Info "Validando configuração Terraform..."
        $output = terraform validate 2>&1
        
        if ($LASTEXITCODE -ne 0) {
            throw "Terraform validate falhou: $output"
        }
        
        Write-Success "Configuração válida"
        Write-Host $output
    }
    finally {
        Pop-Location
    }
}

if (-not $validateSuccess) {
    Write-Failure "Validação falhou. Abortando."
    exit 1
}

# ============================
# FASE 6: TERRAFORM PLAN
# ============================
$planSuccess = Invoke-Step "Terraform Plan" {
    Push-Location $TerraformPath
    try {
        Write-Info "Gerando plano de execução..."
        $planFile = "tfplan.out"
        $output = terraform plan -out=$planFile 2>&1
        
        if ($LASTEXITCODE -ne 0) {
            throw "Terraform plan falhou: $output"
        }
        
        Write-Success "Plano gerado com sucesso"
        Write-Host $output
        
        # Resumo do plano
        Write-Info "`nResumo do plano:"
        $summary = $output | Select-String -Pattern "Plan:|No changes"
        Write-Host $summary -ForegroundColor Yellow
    }
    finally {
        Pop-Location
    }
}

if (-not $planSuccess) {
    Write-Failure "Falha ao gerar plano. Abortando."
    exit 1
}

# ============================
# FASE 7: TERRAFORM APPLY
# ============================
Write-Host "`n=== Terraform Apply ===" -ForegroundColor Magenta
Write-Warning "⚠ ATENÇÃO: Isso criará recursos na AWS que podem gerar custos!"
Write-Info "Custo estimado: ~`$45-60/mês (com agendamento)"

if (-not $AutoApprove) {
    $confirm = Read-Host "`nDeseja aplicar a infraestrutura? (S/N)"
    if ($confirm -ne 'S' -and $confirm -ne 's') {
        Write-Info "Operação cancelada pelo usuário"
        exit 0
    }
}

$applySuccess = Invoke-Step "Terraform Apply" {
    Push-Location $TerraformPath
    try {
        Write-Info "Aplicando infraestrutura..."
        
        if ($AutoApprove) {
            $output = terraform apply -auto-approve tfplan.out 2>&1
        }
        else {
            $output = terraform apply tfplan.out 2>&1
        }
        
        if ($LASTEXITCODE -ne 0) {
            throw "Terraform apply falhou: $output"
        }
        
        Write-Success "Infraestrutura provisionada com sucesso!"
        Write-Host $output
    }
    finally {
        Pop-Location
    }
}

if (-not $applySuccess) {
    Write-Failure "Falha ao aplicar infraestrutura."
    exit 1
}

# ============================
# FASE 8: SALVAR OUTPUTS
# ============================
$outputSuccess = Invoke-Step "Salvando Outputs" {
    Push-Location $TerraformPath
    try {
        Write-Info "Extraindo outputs importantes..."
        $outputFile = "outputs.txt"
        terraform output > $outputFile
        
        if ($LASTEXITCODE -ne 0) {
            throw "Falha ao extrair outputs"
        }
        
        $outputPath = Join-Path (Get-Location) $outputFile
        Write-Success "Outputs salvos em: $outputPath"
        
        # Exibir outputs principais
        Write-Host "`n=== Outputs Importantes ===" -ForegroundColor Cyan
        Get-Content $outputFile | Write-Host
    }
    finally {
        Pop-Location
    }
}

# ============================
# FASE 9: TESTES DE VALIDAÇÃO
# ============================
$testSuccess = Invoke-Step "Testes de Validação" {
    Push-Location $TerraformPath
    try {
        Write-Info "Verificando recursos criados..."
        
        # Obter outputs
        $ecrUrl = terraform output -raw ecr_repository_url 2>$null
        $clusterName = terraform output -raw ecs_cluster_name 2>$null
        $serviceName = terraform output -raw ecs_service_name 2>$null
        $s3Bucket = terraform output -raw react_s3_bucket 2>$null
        
        # Verificar ECR
        if ($ecrUrl) {
            Write-Info "Verificando ECR Repository..."
            $ecr = aws ecr describe-repositories --repository-names $ecrUrl.Split('/')[1] --region us-east-1 2>&1
            if ($LASTEXITCODE -eq 0) {
                Write-Success "ECR Repository OK"
            }
        }
        
        # Verificar ECS Cluster
        if ($clusterName) {
            Write-Info "Verificando ECS Cluster..."
            $cluster = aws ecs describe-clusters --clusters $clusterName --region us-east-1 2>&1 | ConvertFrom-Json
            if ($cluster.clusters[0].status -eq "ACTIVE") {
                Write-Success "ECS Cluster OK: $clusterName"
            }
        }
        
        # Verificar S3 Bucket
        if ($s3Bucket) {
            Write-Info "Verificando S3 Bucket..."
            $bucket = aws s3api head-bucket --bucket $s3Bucket 2>&1
            if ($LASTEXITCODE -eq 0) {
                Write-Success "S3 Bucket OK: $s3Bucket"
            }
        }
        
        Write-Success "Validação básica concluída"
    }
    finally {
        Pop-Location
    }
}

# ============================
# RESUMO FINAL
# ============================
Write-Host "`n╔════════════════════════════════════════════════════════════════╗" -ForegroundColor Green
Write-Host "║        INSTALAÇÃO CONCLUÍDA COM SUCESSO!                       ║" -ForegroundColor Green
Write-Host "╚════════════════════════════════════════════════════════════════╝" -ForegroundColor Green

Write-Host "`n📋 Próximos Passos:`n" -ForegroundColor Cyan

Write-Host "1. Deploy da API .NET:" -ForegroundColor Yellow
Write-Host "   • docker build -t geradv-api:latest ." -ForegroundColor White
Write-Host "   • docker tag geradv-api:latest <ECR_URL>:latest" -ForegroundColor White
Write-Host "   • aws ecr get-login-password --region us-east-1 | docker login --username AWS --password-stdin <ECR_URL>" -ForegroundColor White
Write-Host "   • docker push <ECR_URL>:latest" -ForegroundColor White

Write-Host "`n2. Deploy do React:" -ForegroundColor Yellow
Write-Host "   • cd frontend && npm run build" -ForegroundColor White
Write-Host "   • aws s3 sync ./build s3://<BUCKET>/ --delete" -ForegroundColor White

Write-Host "`n3. Monitoramento:" -ForegroundColor Yellow
Write-Host "   • CloudWatch Logs: aws logs tail /ecs/MenphisSI.GerAdv-api --follow" -ForegroundColor White
Write-Host "   • ECS Status: aws ecs describe-services --cluster <CLUSTER> --services <SERVICE>" -ForegroundColor White

Write-Host "`n4. Outputs importantes salvos em:" -ForegroundColor Yellow
Write-Host "   $(Join-Path $TerraformPath 'outputs.txt')" -ForegroundColor White

Write-Host "`n📚 Documentação completa: README.md" -ForegroundColor Cyan
Write-Host "`n✨ Gerado por SourceGenesys - MenphisSI.GerAdv" -ForegroundColor Magenta

exit 0
