using System;
using System.Text;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;

namespace Timeline.Plugins
{
    public class GetPostUrlForRowPlugin : PluginBase
    {
        public GetPostUrlForRowPlugin() 
            : base(typeof(GetPostUrlForRowPlugin))
        {
            
        }

        protected override void ExecuteDataversePlugin(ILocalPluginContext localPluginContext)
        {
            if (null == localPluginContext)
            {
                throw new ArgumentNullException(nameof(localPluginContext));
            }
            
            //Lets get some parameters from the action 
            var rowReference = GetRegardingFromInputParameters(localPluginContext.PluginExecutionContext);
            var entityTypeCode = GetEntityTypeCode(rowReference, localPluginContext.InitiatingUserService);
            var linkText = GetLinkTextFromInputParameters(localPluginContext.PluginExecutionContext);

            var stringBuilder = new StringBuilder();
            stringBuilder.Append("@[");
            stringBuilder.Append(entityTypeCode);
            stringBuilder.Append(",");
            stringBuilder.Append(rowReference.Id.ToString("D"));
            stringBuilder.Append(",\"");
            stringBuilder.Append(linkText);
            stringBuilder.Append("\"]");
            var link = stringBuilder.ToString();
            localPluginContext.PluginExecutionContext.OutputParameters
                .AddOrUpdateIfNotNull("PostLink", link);
        }

        public int GetEntityTypeCode(EntityReference reference, IOrganizationService orgService)
        {
            var metadata = (RetrieveEntityResponse) orgService.Execute(new RetrieveEntityRequest
            {
                LogicalName = reference.LogicalName,
                EntityFilters = EntityFilters.Entity
            });

            return metadata.EntityMetadata.ObjectTypeCode.Value;
        }
        
        public EntityReference GetRegardingFromInputParameters(IPluginExecutionContext executionContext)
        {
            if (!executionContext.InputParameters.TryGetValue<string>("RowId", out var rowIdAsString))
            {
                throw new ArgumentException("The Row Id cannot be found.");
            }

            if (!executionContext.InputParameters.TryGetValue<string>("TableName", out var tableName))
            {
                throw new ArgumentException("The Table Name cannot be found.");
            }

            if (!Guid.TryParse(rowIdAsString, out var rowId))
            {
                throw new ArgumentException("Cannot parse Row Id as a valid Guid");
            }

            var rowReference = new EntityReference(tableName, rowId);
            return rowReference;
        }

        public string GetLinkTextFromInputParameters(IPluginExecutionContext executionContext)
        {
            if(!executionContext.InputParameters.TryGetValue<string>("LinkText", out var linkText))
            {
                throw new ArgumentException("The Link Text cannot be found");
            }

            return linkText;
        }
    }
}