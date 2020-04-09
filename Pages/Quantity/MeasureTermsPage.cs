using System;
using System.Collections.Generic;
using System.Text;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;

namespace Abc.Pages.Quantity
{
    public class MeasureTermsPage : CommonPage<IMeasureTermRepository, MeasureTerm, MeasureTermView, MeasureTermData>
    {

        protected internal MeasureTermsPage(IMeasureTermRepository r = null) : base(r)
        {
            PageTitle = "Measure Terms";
        }

        public override string ItemId
        {
            get
            {
                if (Item is null) return string.Empty;
                return $"{Item.MasterId}.{Item.TermId}";
            }
        }

        protected internal override string getPageUrl() => "/Quantity/MeasureTerms";

        protected internal override MeasureTerm toObject(MeasureTermView view)
        {
            return MeasureTermViewFactory.Create(view);
        }

        protected internal override MeasureTermView toView(MeasureTerm obj)
        {
            return MeasureTermViewFactory.Create(obj);
        }

    }

}
