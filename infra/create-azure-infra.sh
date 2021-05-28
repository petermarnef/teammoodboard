#!/bin/bash

source config.sh

echo "Creating Resource Group $RESOURCE_GROUP"
az group create \
    --name $RESOURCE_GROUP \
    --location $LOCATION

echo "Creating App Service Plan $APP_SERVICE_PLAN"
az appservice plan create \
    --resource-group $RESOURCE_GROUP \
    --name $APP_SERVICE_PLAN \
    --is-linux \
    --sku B1

echo "Creating Web App $WEB_APP"
az webapp create \
    --resource-group $RESOURCE_GROUP \
    --plan $APP_SERVICE_PLAN \
    --name $WEB_APP \
    --runtime "DOTNET|5.0"
