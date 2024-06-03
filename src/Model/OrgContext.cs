#pragma warning disable CS1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: Microsoft.Xrm.Sdk.Client.ProxyTypesAssemblyAttribute()]

namespace Timeline.Plugins
{
	
	
	/// <summary>
	/// Represents a source of entities bound to a Dataverse service. It tracks and manages changes made to the retrieved entities.
	/// </summary>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Dataverse Model Builder", "2.0.0.6")]
	public partial class OrgContext : Microsoft.Xrm.Sdk.Client.OrganizationServiceContext
	{
		
		/// <summary>
		/// Constructor.
		/// </summary>
		public OrgContext(Microsoft.Xrm.Sdk.IOrganizationService service) : 
				base(service)
		{
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Timeline.Plugins.Account"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Timeline.Plugins.Account> AccountSet
		{
			get
			{
				return this.CreateQuery<Timeline.Plugins.Account>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Timeline.Plugins.Contact"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Timeline.Plugins.Contact> ContactSet
		{
			get
			{
				return this.CreateQuery<Timeline.Plugins.Contact>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Timeline.Plugins.Post"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Timeline.Plugins.Post> PostSet
		{
			get
			{
				return this.CreateQuery<Timeline.Plugins.Post>();
			}
		}
	}
}
#pragma warning restore CS1591