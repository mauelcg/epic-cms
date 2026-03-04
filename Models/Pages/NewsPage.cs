using System.ComponentModel.DataAnnotations;
using EPiServer.Filters;
using EPiServer.PlugIn;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using AlloyTraining.Models.Entities;

namespace AlloyTraining.Models.Pages
{
    [ContentType(
        DisplayName = "News",
        GroupName = "Specialized", Order = 10,
        Description = "Homepage for the site")]
    public class NewsPage : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Birth date",
            Description = "My property description",
            GroupName = "Simple Types",
            Order = 10)]

        public virtual DateTime? BirthDate { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Hire date",
            Description = "My property description",
            GroupName = "Simple Types",
            Order = 10)]

        public virtual DateTime? HireDate { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            VisibleInMenu = false;
            StopPublish = DateTime.Now.AddDays(30);
            this[MetaDataProperties.PageChildOrderRule] = FilterSortOrder.Index;
            BirthDate = DateTime.Now.AddYears(-30);
            HireDate = DateTime.Now.AddYears(-5);

            // applies default values from Admin view
            base.SetDefaultValues(contentType);
        }

        [PropertyDefinitionTypePlugIn(DisplayName = "List of people i.e. IList<Person>",
        Description = "An editable list of Person instances."
        )]
        public class PropertyPersonList : PropertyList<Person>
        {
        }

        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<Person>))]
        public virtual IList<Person> People { get; set; }
    }
}
