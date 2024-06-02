using System;
using Microsoft.Xrm.Sdk;

namespace Timeline.Plugins
{
    public class CreateAutoPostForTimelinePlugin : PluginBase
    {
        public CreateAutoPostForTimelinePlugin() 
            : base(typeof(CreateAutoPostForTimelinePlugin))
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
            var message = GetPostMessage(localPluginContext.PluginExecutionContext);
            var link = GetPostLink(localPluginContext.PluginExecutionContext);

            var post = new Post
            {
                RegardingObjectId = rowReference,
                Source = post_source.AutoPost,
                Text =
                    "<div data-wrapper=\'true\' style=\'font-size:14px;font-family:\'Segoe UI\',\'Helvetica Neue\',\'sans-serif\';\'><div><a href=\'" +
                    link + "\' target=\'_blank\'>\'" + message + "\'</a></div></div>"
            };
            var context = new OrgContext(localPluginContext.InitiatingUserService);
            context.AddObject(post);
            context.SaveChanges();
        }

        private string GetPostLink(IPluginExecutionContext pluginExecutionContext)
        {
            if (!pluginExecutionContext.InputParameters.TryGetValue<string>("LinkAddress", out var linkAddress))
            {
                throw new ArgumentException("Cannot get link address from input parameters");
            }

            //TODO: Validate is a link maybe? 
            return linkAddress;
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

        public string GetPostMessage(IPluginExecutionContext executionContext)
        {
            if (!executionContext.InputParameters.TryGetValue<string>("PostMessage", out var message))
            {
                throw new ArgumentException("Cannot get Post Message from Input Parameters");
            }

            return message;
        }
    }
}