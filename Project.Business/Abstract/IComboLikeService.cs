using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Abstract
{
    public interface IComboLikeService
    {
        List<ComboLike> GetComboLikes();
        ComboLike GetComboLike(int id);
        List<ComboLike> GetComboLikeByCombo(int id);
        void AddComboLike(ComboLike comboLike);
        void RemoveComboLike(int id);
    }
}
