// Created: v0.1.0.5

using Metallurgy.Content.Items.Materials;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Metallurgy.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class TusperLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Tusper Greaves");
            // Tooltip.SetDefault("Somewhat comfy boots.");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(silver: 75);
            Item.rare = ItemRarityID.Blue;
            Item.defense = 8;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TarnenBar>(), 12)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override void Load()
        {
            // Register the legs texture (_Legs)
            EquipLoader.AddEquipTexture(Mod, "Metallurgy/Content/Items/Armor/TusperLeggings_Legs", EquipType.Legs, this, "TusperLeggings_Legs");
        }
    }
}
