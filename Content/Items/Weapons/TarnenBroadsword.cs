// Created: v0.1.0.5

using Metalurgy.Content.Items.Materials;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Metalurgy.Content.Items.Weapons
{
    public class TarnenBroadsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bronzium Blade");
            // Tooltip.SetDefault("A sharp blade forged from Bronzium.");
        }

        public override void SetDefaults()
        {
            Item.damage = 16;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 5;
            Item.value = Item.buyPrice(silver: 90);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TarnenBar>(), 12)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
