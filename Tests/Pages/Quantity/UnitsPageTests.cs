﻿using System.Linq;
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
    public class UnitsPageTests : AbstractClassTests<UnitsPage,
        CommonPage<IUnitsRepository, Unit, UnitView, UnitData>>
    {
        private class TestClass : UnitsPage
        {
            internal TestClass(IUnitsRepository r, IMeasuresRepository m) : base(r, m) { }
        }

        private class UnitsRepository : BaseTestRepository<Unit, UnitData>, IUnitsRepository { }
        private class MeasuresRepository : BaseTestRepository<Measure, MeasureData>, IMeasuresRepository { }

        private UnitsRepository units = new UnitsRepository();
        private MeasuresRepository measures = new MeasuresRepository();
        private MeasureData data;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            units = new UnitsRepository();
            measures = new MeasuresRepository();
            data = GetRandom.Object<MeasureData>();
            var m = new Measure(data);
            measures.Add(m).GetAwaiter();
            addRandomMeasures();
            obj = new TestClass(units, measures);
        }

        private void addRandomMeasures()
        {
            for (var i = 0; i < GetRandom.UInt8(0, 10); i++)
            {
                var d = GetRandom.Object<MeasureData>();
                var m = new Measure(d);
                measures.Add(m).GetAwaiter();
            }
        }

        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<UnitView>();
            obj.Item = item;
            Assert.AreEqual(item.Id, obj.ItemId);
            obj.Item = null;
            Assert.AreEqual(string.Empty, obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Units", obj.PageTitle);
        [TestMethod] public void PageUrlTest() => Assert.AreEqual("/Quantity/Units", obj.PageUrl);
        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<UnitView>();
            var o = obj.toObject(view);
            testArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest() {
            var d = GetRandom.Object<UnitData>();
            var view = obj.toView(new Unit(d));
            testArePropertyValuesEqual(view, d);
        }

        [TestMethod]
        public void GetMeasureNameTest() {
           var name = obj.GetMeasureName(data.Id);
           Assert.AreEqual(data.Name, name);
        }

        [TestMethod]
        public void MeasuresTest()
        {
            var list = measures.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Measures.Count());
        }

    }

}
    
