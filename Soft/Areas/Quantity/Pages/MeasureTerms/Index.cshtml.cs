using System.Threading.Tasks;
using Abc.Domain.Quantity;
using Abc.Pages.Quantity;

namespace Abc.Soft.Areas.Quantity.Pages.MeasureTerms
{
    public class IndexModel : MeasureTermsPage
    {
        
        public IndexModel(IMeasureTermRepository r) : base(r)
        {
        }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex, string fixedValue, string fixedFilter) {

            await getList(sortOrder, currentFilter, searchString, pageIndex, fixedFilter, fixedValue);

        }
    }
}
