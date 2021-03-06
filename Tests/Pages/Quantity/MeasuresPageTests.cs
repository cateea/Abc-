﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Abc.Aids;
using Abc.Data.Quantity;
using Abc.Domain.Quantity;
using Abc.Facade.Quantity;
using Abc.Pages;
using Abc.Pages.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Pages.Quantity
{
    [TestClass]
    public class MeasuresPageTests : AbstractClassTests<MeasuresPage,
        CommonPage<IMeasuresRepository, Measure, MeasureView, MeasureData>>
    {
        private class TestClass : MeasuresPage
        {
            internal TestClass(IMeasuresRepository r, IMeasureTermRepository t) : base(r, t) { }
        }

        private class TestRepository : BaseTestRepositoryForUniqueEntity<Measure, MeasureData>, IMeasuresRepository { }
        private class TermRepository : BaseTestRepositoryForPeriodEntity<MeasureTerm, MeasureTermData>, 
            IMeasureTermRepository {
            
            protected override bool isThis(MeasureTerm entity, string id)
            {
                throw new System.NotImplementedException();
            }

            protected override string getId(MeasureTerm entity)
            {
                throw new System.NotImplementedException();
            }

            public Task<List<MeasureTerm>> Get()
            {
                throw new System.NotImplementedException();
            }
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var r = new TestRepository();
            var t = new TermRepository();
            obj = new TestClass(r, t);
        }

        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<MeasureView>();
            obj.Item = item;
            Assert.AreEqual(item.Id, obj.ItemId);
            obj.Item = null;
            Assert.AreEqual(string.Empty, obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Measures", obj.PageTitle);

        [TestMethod] public void PageUrlTest() => Assert.AreEqual("/Quantity/Measures", obj.PageUrl);

        [TestMethod] public void ToObjectTest()
        {
            var view = GetRandom.Object<MeasureView>();
            var o = obj.toObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod] public void ToViewTest() 
        {
            var data = GetRandom.Object<MeasureData>();
            var view = obj.toView(new Measure(data));
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod] public void LoadDetailsTest()
        {
            var v = GetRandom.Object<MeasureView>();
            obj.LoadDetails(v);
            Assert.IsNotNull(obj.Terms);
        }
        [TestMethod] public void TermsTest()
        {
            isReadOnlyProperty(obj, nameof(obj.Terms), obj.Terms);
        }

    }

}
