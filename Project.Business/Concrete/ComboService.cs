using Project.Business.Abstract;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Concrete
{
    public class ComboService : IComboService
    {
        private IComboDal _comboDal;

        public ComboService(IComboDal comboDal)
        {
            _comboDal = comboDal;
        }

        public void AddCombo(Combo combo)
        {
            _comboDal.Add(combo);
        }

        public Combo GetCombo(int id)
        {
            var combo = _comboDal.Get(g => g.Id == id);
            return combo;
        }

        public List<Combo> GetCombos()
        {
            var combo = _comboDal.GetList();
            return combo;
        }

        public void RemoveCombo(int id)
        {
            _comboDal.Delete(GetCombo(id));
        }
    }
}
