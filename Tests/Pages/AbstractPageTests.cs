﻿using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;
using Abc.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Pages {

    public abstract class AbstractPageTests<TClass, TBaseClass> : AbstractClassTests<TClass, TBaseClass>
        where TClass : BasePage<IMeasuresRepository, Measure, MeasureView, MeasureData> {

        internal TestRepository db; 
        internal class TestClass : CommonPage<IMeasuresRepository, Measure, MeasureView, MeasureData> {

            protected internal TestClass(IMeasuresRepository r) : base(r) {
                PageTitle = "Measures";
            }

            public override string ItemId => Item?.Id ?? string.Empty;

            protected internal override string getPageUrl() => "/Quantity/Measures";

            protected internal override Measure toObject(MeasureView view) => MeasureViewFactory.Create(view);

            protected internal override MeasureView toView(Measure obj) => MeasureViewFactory.Create(obj);

        }

        internal class TestRepository : BaseTestRepositoryForUniqueEntity<Measure, MeasureData>, IMeasuresRepository { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            db = new TestRepository();
        }

    }

}
