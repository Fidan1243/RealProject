using Project.Entities.Concrete;
using System.Collections.Generic;

namespace Project.Business.Abstract
{
    public interface IComboCommentService
    {
        List<ComboComment> GetComboComments();
        ComboComment GetComboComment(int id);
        List<ComboComment> GetComboCommentByCombo(int id);
        void AddComboComment(ComboComment comboComment);
        void RemoveComboComment(int id);
    }
}
