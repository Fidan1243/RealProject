using Project.Business.Abstract;
using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.DataAccess.Abstract;

namespace Project.Business.Concrete
{
    public class ModelService : IModelService
    {
        IModelDal _modelDal;

        public ModelService(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public void AddModel(Model model)
        {
            _modelDal.Add(model);
        }

        public Model GetByName(string name)
        {
            var model = _modelDal.Get(g => g.Name == name);
            return model;
        }

        public Model GetModel(int id)
        {
            var model = _modelDal.Get(g => g.Id == id);
            return model;
        }

        public List<Model> GetModels()
        {
            var model = _modelDal.GetList();
            return model;
        }

        public void RemoveModel(int id)
        {
            _modelDal.Delete(GetModel(id));
        }

        public void UpdateModel(Model model)
        {
            _modelDal.Update(model);
        }
    }
}
