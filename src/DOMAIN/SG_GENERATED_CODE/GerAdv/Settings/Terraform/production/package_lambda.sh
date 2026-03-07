#!/bin/bash
cd lambda
zip -r ecs_scheduler.zip index.py
cd ..
echo "Lambda function zipped successfully!"
