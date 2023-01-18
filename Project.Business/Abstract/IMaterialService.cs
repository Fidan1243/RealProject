using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Abstract
{
    public interface IMaterialService
    {
        List<Material> GetMaterials();
        Material GetMaterial(int id);
        void AddMaterial(Material material);
        void UpdateMaterial(Material material);
        void RemoveMaterial(int id);
    }
}
