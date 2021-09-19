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

# ====> Manual intermediate steps (todo domain registrar - dns changes)
# 1. Add A and TXT record for domain name:
# https://docs.microsoft.com/en-us/azure/developer/javascript/how-to/with-azure-cli/configure-app-service-custom-domain-name
# 
# 2. Map A record with the Verification ID from the APP Service:
# https://docs.microsoft.com/en-us/azure/app-service/app-service-web-tutorial-custom-domain#map-an-a-record
#
# 3. Map CNAME record with the Verification ID from the APP Service:
# https://docs.microsoft.com/en-us/azure/app-service/app-service-web-tutorial-custom-domain#create-the-cname-record

echo "Link Hostname to $WEB_APP"
az webapp config hostname add \
    --hostname $HOSTNAME \
    --resource-group $RESOURCE_GROUP \
    --webapp-name $WEB_APP

echo "Link Hostname to $WEB_APP"
az webapp config hostname add \
    --hostname $WWWHOSTNAME \
    --resource-group $RESOURCE_GROUP \
    --webapp-name $WEB_APP

echo "Create Managed ROOT SSL Certificate for $WEB_APP"
az webapp config ssl create \
    --resource-group $RESOURCE_GROUP \
    --name $WEB_APP \
    --hostname $HOSTNAME

echo "Create Managed WWW SSL Certificate for $WEB_APP"
az webapp config ssl create \
    --resource-group $RESOURCE_GROUP \
    --name $WEB_APP \
    --hostname $WWWHOSTNAME

# ====> Last manual steps
# In the Azure portal on the app service:
# 1. Added SSL binding manually for the root and www custom domains - under `Custom domains`
# 2. Enabled the HTTPS Only option (on the same page as step 1)
