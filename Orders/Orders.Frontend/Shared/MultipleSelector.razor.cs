using Microsoft.AspNetCore.Components;
using Orders.Frontend.Helpers;

namespace Orders.Frontend.Shared
{
    public partial class MultipleSelector
    {
        private string addAllText = ">>";
        private string removeAllText = "<<";

        [Parameter] public List<MultipleSelectorModel> NonSelected { get; set; } = new();
        [Parameter] public List<MultipleSelectorModel> Selected { get; set; } = new();

        private void Select(MultipleSelectorModel item)
        {
            NonSelected.Remove(item);
            Selected.Add(item);
        }

        private void UnSelect(MultipleSelectorModel item)
        {
            Selected.Remove(item);
            NonSelected.Add(item);
        }

        private void SelectAll()
        {
            Selected.AddRange(NonSelected);
            NonSelected.Clear();
        }

        private void UnSelectAll()
        {
            NonSelected.AddRange(Selected);
            Selected.Clear();
        }
    }
}