using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Abstract
{
    public interface IComboService
    {
        List<Combo> GetCombos();
        Combo GetCombo(int id);
        void AddCombo(Combo combo);
        void RemoveCombo(int id);
    }
}
