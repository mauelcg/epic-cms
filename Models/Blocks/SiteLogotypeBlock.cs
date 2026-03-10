using System.ComponentModel.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;

namespace AlloyTraining.Models.Blocks;

/// <summary>
/// Used to provide a composite property on the start page to set site logotype settings
/// </sumamry>
[ContentType(GUID = "09854019-91A5-4B93-8623-17F038346001", AvailableInEditMode = false)]
[SiteImageUrl]
public class SiteLogotypeBlock : SiteBlockData
{
    [DefaultDragAndDropTarget]
    [UIHint(UIHint.Image)]
    public virtual Url Url
    {
        get
        {
            var url = this.GetPropertyValue(b => b.Url);
            return url == null || url.IsEmpty() ? new Url("/gfx/logotype.png") : url;
        }
        set => this.SetPropertyValue(b => b.Url, value);
    }

    [CultureSpecific]
    public virtual string Title { get; set; }
}
