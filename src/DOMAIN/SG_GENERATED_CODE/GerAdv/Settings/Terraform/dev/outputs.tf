output "api_url" {
  description = "URL do Application Load Balancer da API"
  value       = aws_lb.api_alb.dns_name
}

output "api_url_full" {
  description = "URL completa da API"
  value       = "http://${aws_lb.api_alb.dns_name}"
}

output "react_cloudfront_url" {
  description = "URL do CloudFront para aplicação React"
  value       = aws_cloudfront_distribution.react_distribution.domain_name
}

output "react_url_full" {
  description = "URL completa do React"
  value       = "https://${aws_cloudfront_distribution.react_distribution.domain_name}"
}

output "react_s3_bucket" {
  description = "Nome do bucket S3 para React"
  value       = aws_s3_bucket.react_bucket.id
}

output "ecr_repository_url" {
  description = "URL do repositório ECR para imagens Docker"
  value       = aws_ecr_repository.api_repository.repository_url
}

output "ecs_cluster_name" {
  description = "Nome do cluster ECS"
  value       = aws_ecs_cluster.main.name
}

output "ecs_service_name" {
  description = "Nome do serviço ECS"
  value       = aws_ecs_service.api.name
}

output "api_log_group" {
  description = "CloudWatch Log Group da API"
  value       = aws_cloudwatch_log_group.api_logs.name
}

output "target_group_arn" {
  description = "ARN do Target Group"
  value       = aws_lb_target_group.api_tg.arn
}

output "cloudfront_distribution_id" {
  description = "ID da distribuição CloudFront"
  value       = aws_cloudfront_distribution.react_distribution.id
}
