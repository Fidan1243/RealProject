using Project.Business.Abstract;
using Project.UI.Models;

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

            var mirror_id = _modelService.GetByName("Mirror").Id;
            var sink_unit_id = _modelService.GetByName("Sink Unit").Id;
            var toilet_id = _modelService.GetByName("Toilet").Id;
            var shower_id = _modelService.GetByName("Shower").Id;
            var marble_id = _modelService.GetByName("Marble").Id;

            var toilets = _productService.GetProductByModel(toilet_id);
            var mirrors = _productService.GetProductByModel(mirror_id);
            var sink_units = _productService.GetProductByModel(sink_unit_id);
            var showers = _productService.GetProductByModel(shower_id);
            var marbles = _productService.GetProductByModel(marble_id);

            return new ComboProductsViewModel
            {
                Toilets = toilets,
                Mirrors = mirrors,
                SinkUnits = sink_units,
                Showers = showers,
                Marbles = marbles
            };
        }
    }
}
