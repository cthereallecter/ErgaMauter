// Created: v0.1.0.5

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Metallurgy.Content.Items.Materials
{
    public class TarnenBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bronzium Bar");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(silver: 5);
            Item.rare = ItemRarityID.White;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TarnenOre>(), 3)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}
