using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripst.Clases
{
    public class StatusEffect
    {
        public bool Active { get; set; } = false;
        public int Duration { get; set; } = 0;
    }

    public class DamageOverTimeEffect : StatusEffect
    {
        public int DamagePerTurn { get; set; }
    }

    public class BuffEffect : StatusEffect
    {
        public int Value { get; set; }
    }

    public class States
    {
        public bool Dead { get; set; } = false;

        public int StunResistance { get; set; } = 50;
        public StatusEffect Stun { get; set; } = new StatusEffect();

        public int PoisonResistance { get; set; } = 30;
        public DamageOverTimeEffect Poison { get; set; } = new DamageOverTimeEffect();

        public BuffEffect AtkBuff { get; set; } = new BuffEffect();
        public BuffEffect DefBuff { get; set; } = new BuffEffect();

        public void Tick()
        {
            // Actualiza turnos y desactiva estados que terminan
            if (Stun.Active)
            {
                Stun.Duration--;
                if (Stun.Duration <= 0)
                    Stun.Active = false;
            }

            if (Poison.Active)
            {
                Poison.Duration--;
                if (Poison.Duration <= 0)
                    Poison.Active = false;
            }

            if (AtkBuff.Active)
            {
                AtkBuff.Duration--;
                if (AtkBuff.Duration <= 0)
                    AtkBuff.Active = false;
            }

            if (DefBuff.Active)
            {
                DefBuff.Duration--;
                if (DefBuff.Duration <= 0)
                    DefBuff.Active = false;
            }
        }
    }

}
