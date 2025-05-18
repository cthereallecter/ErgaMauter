// Created: v0.1.0.5

using Metallurgy.Content.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace Metallurgy.Content.Items.Tools
{
    public class TarnenPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 11;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = Item.buyPrice(gold: 1); // Buy this item for one gold - change gold to any coin and change the value to any number <= 100
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.pick = 40; // How strong the pickaxe is, see https://terraria.wiki.gg/wiki/Pickaxe_power for a list of common values
            Item.attackSpeedOnlyAffectsWeaponAnimation = true; // Melee speed affects how fast the tool swings for damage purposes, but not how fast it can dig
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TarnenBar>(), 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}