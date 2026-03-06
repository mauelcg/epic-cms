using EPiServer.Shell.ObjectEditing;
using System.Collections.Generic;

namespace AlloyTraining.Business.Factories
{
    public class ThemeSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            yield return new SelectItem { Text = "Orange", Value = "theme1" };
            yield return new SelectItem { Text = "Purple", Value = "theme2" };
            yield return new SelectItem { Text = "Green", Value = "theme3" };
        }
    }
}
