@echo off
cd lambda
tar -a -c -f ecs_scheduler.zip index.py
cd ..
echo Lambda function zipped successfully!
