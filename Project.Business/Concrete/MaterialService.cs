using Project.Business.Abstract;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Concrete
{
    public class MaterialService : IMaterialService
    {
        IMaterialDal _materialDal;

        public MaterialService(IMaterialDal materialDal)
        {
            _materialDal = materialDal;
        }

        public void AddMaterial(Material material)
        {
            _materialDal.Add(material);
        }

        public Material GetMaterial(int id)
        {
            var material = _materialDal.Get(g => g.Id == id);
            return material;
        }

        public List<Material> GetMaterials()
        {
            var material = _materialDal.GetList();
            return material;
        }

        public void RemoveMaterial(int id)
        {
            _materialDal.Delete(GetMaterial(id));
        }

        public void UpdateMaterial(Material material)
        {
            _materialDal.Update(material);
        }
    }
}
