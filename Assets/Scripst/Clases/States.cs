using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripst.Clases
{
    public class StatusEffect
    {
        public string Name { get; set; }
        public bool Active { get; set; } = false;
        public int Duration { get; set; } = 0;
        public int Resistence { get; set; } = 0;
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
       
        public StatusEffect Stun { get; set; } = new StatusEffect() {Name = "Aturdido", Resistence = 50 };
        public DamageOverTimeEffect Poison { get; set; } = new DamageOverTimeEffect() {Name = "Envenenado", Resistence = 30 };

        public BuffEffect AtkBuff { get; set; } = new BuffEffect() { Name = "Aumento de Ataque"};
        public BuffEffect DefBuff { get; set; } = new BuffEffect() { Name = "Aumento de Defensa"};

        public void Tick()
        {
            // Actualiza turnos y desactiva estados que terminan
            if (Stun.Active)
            {                
                if (Stun.Duration <= 0)
                    Stun.Active = false;
                else
                    Stun.Duration--;
            }

            if (Poison.Active)
            {                
                if (Poison.Duration <= 0)
                    Poison.Active = false;
                else
                    Poison.Duration--;
            }

            if (AtkBuff.Active)
            {                
                if (AtkBuff.Duration <= 0)
                    AtkBuff.Active = false;
                else
                    AtkBuff.Duration--;
            }

            if (DefBuff.Active)
            {                
                if (DefBuff.Duration <= 0)
                    DefBuff.Active = false;
                else
                    DefBuff.Duration--;
            }
        }
    }

}
