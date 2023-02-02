using Project.Business.Abstract;
using Project.Entities.Concrete;
using Project.UI.Models;
using Project.UI.Services;
using Project.UI.Statics;
using System.Collections.Generic;

namespace Project.UI.Helpers
{
    public class ComboProductsHelper
    {
        private IProductService _productService;
        private IModelService _modelService;
        private IMaterialService _materialService;
        private ICartSessionService _cartService;
        public ComboProductsHelper(IProductService productService, IModelService modelService, ICartSessionService cartSessionService, IMaterialService materialService)
        {
            _productService = productService;
            _modelService = modelService;
            _materialService = materialService;
        }
        public ComboProductsViewModel CreateViewModel(User user)
        {

            var mirror_id = _modelService.GetByName(Static.Mirrors).Id;
            var sink_unit_id = _modelService.GetByName(Static.SinkUnits).Id;
            var toilet_id = _modelService.GetByName(Static.Toilets).Id;
            var shower_id = _modelService.GetByName(Static.Showers).Id;
            var marble_id = _modelService.GetByName(Static.Marbles).Id;
            var d_marble_id = _modelService.GetByName(Static.Decoration_Marbles).Id;

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
                Decoration_Marbles = decoration_marbles,
                Models = _modelService.GetModels(),
                Materials = _materialService.GetMaterials(),
                User = user
            };
        }
        public List<ComboMViewModel> ListViewModel(List<Combo> combos)
        {
            var list = new List<ComboMViewModel>();
            foreach (var item in combos)
            {
                var cvitem = new ComboMViewModel()
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
        public ComboMViewModel ViewModel(Combo combos)
        {
            var cvitem = new ComboMViewModel()
            {
                Id = combos.Id,
                Name = combos.Name,
                Total = combos.Total,
                Decoration_Marble_Count = combos.Decoration_Marble_Count,
                Marble_Count = combos.Marble_Count,
                Toilet = _productService.GetProduct(combos.Toilet_Id),
                Mirror = _productService.GetProduct(combos.Mirror_Id),
                SinkUnit = _productService.GetProduct(combos.Sink_Unit_Id),
                Shower = _productService.GetProduct(combos.Shower_Id),
                Marble = _productService.GetProduct(combos.Marble_Id),
                Decoration_Marble = _productService.GetProduct(combos.Decoration_Marble_Id),
            };
            return cvitem;
        }
    }
}
