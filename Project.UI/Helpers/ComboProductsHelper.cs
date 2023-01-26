using Project.Business.Abstract;
using Project.Entities.Concrete;
using Project.UI.Models;
using Project.UI.Statics;
using System.Collections.Generic;

namespace Project.UI.Helpers
{
    public class ComboProductsHelper
    {
        private IProductService _productService;
        private IModelService _modelService;

        public ComboProductsHelper(IProductService productService, IModelService modelService)
        {
            _productService = productService;
            _modelService = modelService;
        }
        public ComboProductsViewModel CreateViewModel()
        {

            var mirror_id = _modelService.GetByName(ComboStatic.Mirrors).Id;
            var sink_unit_id = _modelService.GetByName(ComboStatic.SinkUnits).Id;
            var toilet_id = _modelService.GetByName(ComboStatic.Toilets).Id;
            var shower_id = _modelService.GetByName(ComboStatic.Showers).Id;
            var marble_id = _modelService.GetByName(ComboStatic.Marbles).Id;
            var d_marble_id = _modelService.GetByName(ComboStatic.Decoration_Marbles).Id;

            var toilets = _productService.GetProductByModel(toilet_id);
            var mirrors = _productService.GetProductByModel(mirror_id);
            var sink_units = _productService.GetProductByModel(sink_unit_id);
            var showers = _productService.GetProductByModel(shower_id);
            var marbles = _productService.GetProductByModel(marble_id);
            var decoration_marbles = _productService.GetProductByModel(d_marble_id);

            return new ComboProductsViewModel
            {
                Toilets = toilets,
                Mirrors = mirrors,
                SinkUnits = sink_units,
                Showers = showers,
                Marbles = marbles,
                Decoration_Marbles = decoration_marbles
            };
        }
        public List<ComboViewModel> ListViewModel(List<Combo> combos)
        {
            var list = new List<ComboViewModel>();
            foreach (var item in combos)
            {
                var cvitem = new ComboViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Total = item.Total,
                    Decoration_Marble_Count = item.Decoration_Marble_Count,
                    Marble_Count = item.Marble_Count,
                    Toilet = _productService.GetProduct(item.Toilet_Id),
                    Mirror = _productService.GetProduct(item.Mirror_Id),
                    SinkUnit = _productService.GetProduct(item.Sink_Unit_Id),
                    Shower = _productService.GetProduct(item.Shower_Id),
                    Marble = _productService.GetProduct(item.Marble_Id),
                    Decoration_Marble = _productService.GetProduct(item.Decoration_Marble_Id),
                };
                list.Add(cvitem);
            }
            return list;
        }
    }
}
