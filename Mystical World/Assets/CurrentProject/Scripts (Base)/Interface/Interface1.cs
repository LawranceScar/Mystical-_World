using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    interface IDamagable
    {
        public void TakerDamage(float damage);
    }
    interface IHealable
    {
        public void Heal(float healamount);
    }
    interface ISafeZonenable
    {
        public void IsSafeZone(bool value);
    }

    interface IStartDetectable
    {
        public void StartOtherEnemiesWhenAttack();
    }
    interface IResistancable
    {
        public void UpResistance(float resistance);
    }

    interface IRigidable
    {
        public void RigidBodyChange(float kdtoawake);
    }
}
