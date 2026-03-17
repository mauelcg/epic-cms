using System.ComponentModel.DataAnnotations;
using EPiServer.Filters;
using EPiServer.PlugIn;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using AlloyTraining.Models.Entities;

namespace AlloyTraining.Models.Pages
{
    [ContentType(DisplayName = "Authentication", GroupName = SiteGroupNames.Base, Order = 10)]
    public class AuthenticationPage : SitePageData
    {
        [CultureSpecific]
        [Display(Name = "User Name", GroupName = "Simple Types", Order = 10)]
        public virtual string? UserName { get; set; }

        [CultureSpecific]
        [Display(Name = "First Name", Description = "My property description", GroupName = "Simple Types", Order = 10)]
        public virtual string? FirstName { get; set; }

        [CultureSpecific]
        [Display(Name = "First Name", Description = "My property description", GroupName = "Simple Types", Order = 10)]
        public virtual string? LastName { get; set; }

        [CultureSpecific]
        [Display(Name = "Email Address", Description = "My property description", GroupName = "Simple Types", Order = 10)]
        public virtual string? Email { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            VisibleInMenu = false;
            StopPublish = DateTime.Now.AddDays(30);
            this[MetaDataProperties.PageChildOrderRule] = FilterSortOrder.Index;

            // applies default values from Admin view
            base.SetDefaultValues(contentType);
        }

        [PropertyDefinitionTypePlugIn(DisplayName = "List of people i.e. IList<Person>", Description = "An editable list of Person instances.")]
        public class PropertyPersonList : PropertyList<Person>
        {
        }

        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<Person>))]
        public virtual IList<Person> People { get; set; }
    }
}
