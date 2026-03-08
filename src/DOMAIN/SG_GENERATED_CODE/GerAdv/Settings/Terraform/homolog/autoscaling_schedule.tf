# Lambda Function para controlar desired count do ECS
resource "aws_lambda_function" "ecs_scheduler" {
  filename         = "${path.module}/lambda/ecs_scheduler.zip"
  function_name    = "${var.project_name}-ecs-scheduler"
  role            = aws_iam_role.lambda_scheduler_role.arn
  handler         = "index.handler"
  source_code_hash = filebase64sha256("${path.module}/lambda/ecs_scheduler.zip")
  runtime         = "python3.11"
  timeout         = 30

  environment {
    variables = {
      CLUSTER_NAME = aws_ecs_cluster.main.name
      SERVICE_NAME = aws_ecs_service.api.name
      REGION       = var.aws_region
    }
  }

  tags = {
    Name = "${var.project_name}-ecs-scheduler"
  }
}

# IAM Role para Lambda
resource "aws_iam_role" "lambda_scheduler_role" {
  name = "${var.project_name}-lambda-scheduler-role"

  assume_role_policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Action = "sts:AssumeRole"
        Effect = "Allow"
        Principal = {
          Service = "lambda.amazonaws.com"
        }
      }
    ]
  })

  tags = {
    Name = "${var.project_name}-lambda-scheduler-role"
  }
}

# Política para Lambda gerenciar ECS
resource "aws_iam_role_policy" "lambda_scheduler_ecs_policy" {
  name = "${var.project_name}-lambda-ecs-policy"
  role = aws_iam_role.lambda_scheduler_role.id

  policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Effect = "Allow"
        Action = [
          "ecs:DescribeServices",
          "ecs:UpdateService"
        ]
        Resource = aws_ecs_service.api.id
      },
      {
        Effect = "Allow"
        Action = [
          "logs:CreateLogGroup",
          "logs:CreateLogStream",
          "logs:PutLogEvents"
        ]
        Resource = "arn:aws:logs:${var.aws_region}:*:*"
      }
    ]
  })
}

# EventBridge Rule - Parar às 23h (horário de Brasília UTC-3)
resource "aws_cloudwatch_event_rule" "stop_schedule" {
  count               = var.enable_schedule ? 1 : 0
  name                = "${var.project_name}-stop-schedule"
  description         = "Para ECS tasks no horário configurado"
  schedule_expression = "cron(${var.schedule_stop_minute} ${var.schedule_stop_hour} * * ? *)"

  tags = {
    Name = "${var.project_name}-stop-schedule"
  }
}

# EventBridge Rule - Iniciar às 5h (horário de Brasília UTC-3)
resource "aws_cloudwatch_event_rule" "start_schedule" {
  count               = var.enable_schedule ? 1 : 0
  name                = "${var.project_name}-start-schedule"
  description         = "Inicia ECS tasks no horário configurado"
  schedule_expression = "cron(${var.schedule_start_minute} ${var.schedule_start_hour} * * ? *)"

  tags = {
    Name = "${var.project_name}-start-schedule"
  }
}

# Target - Lambda para parar
resource "aws_cloudwatch_event_target" "stop_target" {
  count = var.enable_schedule ? 1 : 0
  rule  = aws_cloudwatch_event_rule.stop_schedule[0].name
  arn   = aws_lambda_function.ecs_scheduler.arn

  input = jsonencode({
    action        = "stop"
    desiredCount  = 0
  })
}

# Target - Lambda para iniciar
resource "aws_cloudwatch_event_target" "start_target" {
  count = var.enable_schedule ? 1 : 0
  rule  = aws_cloudwatch_event_rule.start_schedule[0].name
  arn   = aws_lambda_function.ecs_scheduler.arn

  input = jsonencode({
    action        = "start"
    desiredCount  = var.api_desired_count
  })
}

# Permissão para EventBridge invocar Lambda (stop)
resource "aws_lambda_permission" "allow_eventbridge_stop" {
  count         = var.enable_schedule ? 1 : 0
  statement_id  = "AllowExecutionFromEventBridgeStop"
  action        = "lambda:InvokeFunction"
  function_name = aws_lambda_function.ecs_scheduler.function_name
  principal     = "events.amazonaws.com"
  source_arn    = aws_cloudwatch_event_rule.stop_schedule[0].arn
}

# Permissão para EventBridge invocar Lambda (start)
resource "aws_lambda_permission" "allow_eventbridge_start" {
  count         = var.enable_schedule ? 1 : 0
  statement_id  = "AllowExecutionFromEventBridgeStart"
  action        = "lambda:InvokeFunction"
  function_name = aws_lambda_function.ecs_scheduler.function_name
  principal     = "events.amazonaws.com"
  source_arn    = aws_cloudwatch_event_rule.start_schedule[0].arn
}

# CloudWatch Log Group para Lambda
resource "aws_cloudwatch_log_group" "lambda_scheduler_logs" {
  name              = "/aws/lambda/${aws_lambda_function.ecs_scheduler.function_name}"
  retention_in_days = 7

  tags = {
    Name = "${var.project_name}-lambda-scheduler-logs"
  }
}
