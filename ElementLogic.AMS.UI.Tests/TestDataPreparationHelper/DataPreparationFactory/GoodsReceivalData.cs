using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.ImportFactory;
using System;
using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.DataPreparationFactory
{
    public class GoodsReceivalData
    {
        public static GoodsReceivalData Instance => Singleton.Value;

        public void PrepareGoodsReceivalTestData(IList<GoodsReceivalLine> goodsReceivalLines, 
            ScenarioContext scenarioContext)
        {
            GoodsReceivalImport.Instance.ImportGoodsReceival(goodsReceivalLines, scenarioContext);
        }

        private GoodsReceivalData() { }

        private static readonly Lazy<GoodsReceivalData> Singleton = new Lazy<GoodsReceivalData>(() => new GoodsReceivalData());
    }
}
