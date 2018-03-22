using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public interface IHealable
    {
        void Heal(Character character);
    }
}
