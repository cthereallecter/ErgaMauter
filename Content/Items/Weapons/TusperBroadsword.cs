// Created: v0.1.0.5

using Metalurgy.Content.Items.Materials;
using Metalurgy.Content.NPCs;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Metalurgy.Content.Items.Weapons
{

    // Shared identifier for poisoned enemies
    public static class TusperGlobalData
    {
        public static int TusperPoisonTagTimer = 300; // 5 seconds
    }

    public class TusperBroadsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Tusper Broadsword");
            // Tooltip.SetDefault("A sharp blade forged from Tusper, its edge coated in toxic waste. Inflicts lingering poison on hit.");
        }

        public override void SetDefaults()
        {
            Item.damage = 30; // Increased damage
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 25; // Standard swing speed
            Item.useAnimation = 25; // Standard swing animation time
            Item.useStyle = ItemUseStyleID.Swing; // Swing style
            Item.knockBack = 6; // Knockback value
            Item.value = Item.buyPrice(gold: 4, silver: 50); // Adjusted price
            Item.rare = ItemRarityID.Blue; // Pre-Hardmode rarity
            Item.UseSound = SoundID.Item1; // Swing sound
            Item.autoReuse = true; // Allows for automatic re-use
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TusperBar>(), 12)
                .AddIngredient(46) // Light's Bane
                .AddIngredient(ModContent.ItemType<TarnenBroadsword>())
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override bool? UseItem(Player player)
        {
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC target = Main.npc[i];

                if (target.active && player.Hitbox.Intersects(target.Hitbox))
                {
                    target.AddBuff(BuffID.Poisoned, 300); // Poisoned for 5 seconds

                    // Tag with Tusper poison metadata
                    target.GetGlobalNPC<TusperPoisonTracker>().SetTusperPoison(player.whoAmI);

                    SpawnToxicDust(player);
                }
            }

            return base.UseItem(player);
        }

        // This method spawns toxic dust effect when swinging the sword
        private void SpawnToxicDust(Player player)
        {
            // Play sound effect for the toxic waste dust effect
            SoundEngine.PlaySound(SoundID.Item29, player.position); // Example sound of a "toxic spill"

            // Create a dust effect matching the green and purple theme
            for (int i = 0; i < 20; i++) // Number of dusts to spawn
            {
                // Spawn dust with a toxic green and purple color
                Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.GreenTorch, 0f, 0f, 0, new Color(100, 255, 100), 1.5f);
                dust.noGravity = true; // Make it float in the air like toxic waste dust
                dust.velocity *= 2f; // Make the dust travel outward a bit more

                // Optionally mix green with purple tones for a more "toxic" feel
                Dust dust2 = Dust.NewDustDirect(player.position, player.width, player.height, DustID.PurpleTorch, 0f, 0f, 0, new Color(180, 80, 255), 1.2f);
                dust2.noGravity = true;
                dust2.velocity *= 2f;
            }
        }
    }
}
