using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Abstract
{
    public interface IModelService
    {
        List<Model> GetModels();
        Model GetModel(int id);
        Model GetByName(string name);
        void AddModel(Model model);
        void UpdateModel(Model model);
        void RemoveModel(int id);
    }
}
