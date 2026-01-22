# Backend S3 para state do Terraform
# Descomentar após criar o bucket manualmente
# terraform {
#   backend "s3" {
#     bucket         = "menphissi.geradv-terraform-state"
#     key            = "terraform.tfstate"
#     region         = "us-east-1"
#     encrypt        = true
#     dynamodb_table = "menphissi.geradv-terraform-locks"
#   }
# }

# Para criar o bucket de state, execute:
# aws s3api create-bucket --bucket menphissi.geradv-terraform-state --region us-east-1
# aws s3api put-bucket-versioning --bucket menphissi.geradv-terraform-state --versioning-configuration Status=Enabled
# aws dynamodb create-table --table-name menphissi.geradv-terraform-locks --attribute-definitions AttributeName=LockID,AttributeType=S --key-schema AttributeName=LockID,KeyType=HASH --provisioned-throughput ReadCapacityUnits=1,WriteCapacityUnits=1 --region us-east-1
