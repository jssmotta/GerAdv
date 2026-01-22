import json
import boto3
import os
from datetime import datetime

ecs = boto3.client('ecs')

def handler(event, context):
    cluster_name = os.environ['CLUSTER_NAME']
    service_name = os.environ['SERVICE_NAME']
    region = os.environ['REGION']
    
    action = event.get('action', 'unknown')
    desired_count = event.get('desiredCount', 0)
    
    print(f"Timestamp: {datetime.utcnow().isoformat()}")
    print(f"Action: {action}")
    print(f"Cluster: {cluster_name}")
    print(f"Service: {service_name}")
    print(f"Desired Count: {desired_count}")
    
    try:
        # Obter estado atual do serviço
        response = ecs.describe_services(
            cluster=cluster_name,
            services=[service_name]
        )
        
        if not response['services']:
            raise Exception(f'Service {service_name} not found in cluster {cluster_name}')
        
        current_desired_count = response['services'][0]['desiredCount']
        current_running_count = response['services'][0]['runningCount']
        
        print(f"Current Desired Count: {current_desired_count}")
        print(f"Current Running Count: {current_running_count}")
        
        # Atualizar desired count
        update_response = ecs.update_service(
            cluster=cluster_name,
            service=service_name,
            desiredCount=desired_count
        )
        
        new_desired_count = update_response['service']['desiredCount']
        
        message = f'{action.capitalize()} scheduled executed successfully'
        print(f"Message: {message}")
        print(f"New Desired Count: {new_desired_count}")
        
        return {
            'statusCode': 200,
            'body': json.dumps({
                'message': message,
                'action': action,
                'cluster': cluster_name,
                'service': service_name,
                'previousDesiredCount': current_desired_count,
                'newDesiredCount': new_desired_count,
                'timestamp': datetime.utcnow().isoformat()
            })
        }
        
    except Exception as e:
        error_message = f'Error {action}ing service: {str(e)}'
        print(f"Error: {error_message}")
        
        return {
            'statusCode': 500,
            'body': json.dumps({
                'error': error_message,
                'action': action,
                'timestamp': datetime.utcnow().isoformat()
            })
        }
