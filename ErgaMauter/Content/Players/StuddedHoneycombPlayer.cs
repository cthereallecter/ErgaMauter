using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ErgaMauter.Content.Items.Accessories
{
    public class StuddedHoneycombPlayer : ModPlayer
    {
        public bool comboActive;

        public override void ResetEffects()
        {
            comboActive = false;
        }

        public override void OnHurt(Player.HurtInfo info)
        {
            if (!comboActive)
                return;

            int beeCount = Main.rand.Next(3, 5); // Normally 1-3, we boost this a bit
            int extraBees = (int)(beeCount * 0.5f); // 50% more bees
            beeCount += extraBees;

            for (int i = 0; i < beeCount; i++)
            {
                Vector2 velocity = new Vector2(Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(-4f, -1f));
                Projectile.NewProjectile(
                    Player.GetSource_OnHurt(info.DamageSource),
                    Player.Center,
                    velocity,
                    ProjectileID.GiantBee,
                    info.Damage / 2,
                    0f,
                    Player.whoAmI
                );
            }
        }
    }
}
