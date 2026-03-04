using EPiServer.Shell.ObjectEditing;
using System.Collections.Generic;

namespace AlloyTraining.Business.Factories
{
    public class WorkStatusSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            yield return new SelectItem { Text = "FT", Value = "Full-time" };
            yield return new SelectItem { Text = "PT", Value = "Part-time" };
            yield return new SelectItem { Text = "ST", Value = "Student" };
            yield return new SelectItem { Text = "UN", Value = "Unemployed" };
        }
    }
}
