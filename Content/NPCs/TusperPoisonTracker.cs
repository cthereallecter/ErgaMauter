using Metalurgy.Content.Items.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Metalurgy.Content.NPCs
{
    public class TusperPoisonTracker : GlobalNPC
    {
        public int tusperPoisonOwner = -1;
        public int poisonTimer = 0;

        public override bool InstancePerEntity => true;

        public void SetTusperPoison(int playerID)
        {
            tusperPoisonOwner = playerID;
            poisonTimer = TusperGlobalData.TusperPoisonTagTimer;
        }

        public override void ResetEffects(NPC npc)
        {
            if (poisonTimer > 0)
                poisonTimer--;
            else
                tusperPoisonOwner = -1;
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (npc.HasBuff(BuffID.Poisoned) && tusperPoisonOwner != -1)
            {
                // Poison damage is applied here every tick via lifeRegen

                int lifeLost = damage;

                if (lifeLost > 0 && Main.player.IndexInRange(tusperPoisonOwner))
                {
                    Player player = Main.player[tusperPoisonOwner];

                    // Heal player for poison damage dealt (1:1 ratio)
                    player.statLife += lifeLost;
                    player.HealEffect(lifeLost, true);
                }
            }
        }
    }
}
