using Project.Business.Abstract;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Concrete
{
    public class ComboLikeService : IComboLikeService
    {
        private IComboLikeDal _comboLikeDal;

        public ComboLikeService(IComboLikeDal comboLikeDal)
        {
            _comboLikeDal = comboLikeDal;
        }

        public void AddComboLike(ComboLike comboLike)
        {
            _comboLikeDal.Add(comboLike);
        }

        public ComboLike GetComboLike(int id)
        {
            var comboLike = _comboLikeDal.Get(g => g.Id == id);
            return comboLike;
        }

        public List<ComboLike> GetComboLikeByCombo(int id)
        {
            var comboLike = _comboLikeDal.GetList(g => g.Combo_Id == id);
            return comboLike;
        }

        public List<ComboLike> GetComboLikes()
        {
            var comboLike = _comboLikeDal.GetList();
            return comboLike;
        }

        public void RemoveComboLike(int id)
        {
            _comboLikeDal.Delete(GetComboLike(id));
        }
    }
}
