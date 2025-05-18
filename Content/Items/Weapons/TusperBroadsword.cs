// Created: v0.1.0.5

using Metallurgy.Content.Items.Materials;
using Metallurgy.Content.NPCs;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Metallurgy.Content.Items.Weapons
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
                }
            }

            return base.UseItem(player);
        }
    }
}
