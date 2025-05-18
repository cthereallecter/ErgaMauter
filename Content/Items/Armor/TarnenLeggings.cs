// Created: v0.1.0.5

using Metallurgy.Content.Items.Materials;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Metallurgy.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class TarnenLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bronzium Greaves");
            // Tooltip.SetDefault("Somewhat comfy boots.");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(silver: 75);
            Item.rare = ItemRarityID.Green;
            Item.defense = 2;
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
            EquipLoader.AddEquipTexture(Mod, "Metallurgy/Content/Items/Armor/TarnenLeggings_Legs", EquipType.Legs, this, "TarnenLeggings_Legs");
        }
    }
}
