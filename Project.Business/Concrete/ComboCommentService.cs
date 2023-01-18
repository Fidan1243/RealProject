using Project.Business.Abstract;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Concrete
{
    public class ComboCommentService : IComboCommentService
    {
        private IComboCommentDal _comboCommentDal;

        public ComboCommentService(IComboCommentDal comboCommentDal)
        {
            _comboCommentDal = comboCommentDal;
        }

        public void AddComboComment(ComboComment comboComment)
        {
            _comboCommentDal.Add(comboComment);
        }

        public ComboComment GetComboComment(int id)
        {
            var comboComment = _comboCommentDal.Get(g => g.Id == id);
            return comboComment;
        }

        public List<ComboComment> GetComboCommentByCombo(int id)
        {
            var comboComment = _comboCommentDal.GetList(g => g.Combo_Id == id);
            return comboComment;
        }

        public List<ComboComment> GetComboComments()
        {
            var comboComment = _comboCommentDal.GetList();
            return comboComment;
        }

        public void RemoveComboComment(int id)
        {
            _comboCommentDal.Delete(GetComboComment(id));
        }
    }
}
