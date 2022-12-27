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
        void AddModel(Model model);
        void RemoveModel(int id);
    }
}
