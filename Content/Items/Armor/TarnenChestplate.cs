// Created: v0.1.0.5

using Metallurgy.Content.Items.Materials;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Metallurgy.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class TarnenChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bronzium Chestplate");
            // Tooltip.SetDefault("Offers balanced early protection.");


            ArmorIDs.Body.Sets.HidesArms[Item.bodySlot] = false;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(silver: 90);
            Item.rare = ItemRarityID.Green;
            Item.defense = 3;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TarnenBar>(), 18)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override void Load()
        {
            // Register the body texture (_Body)
            EquipLoader.AddEquipTexture(Mod, "Metallurgy/Content/Items/Armor/TarnenChestplate_Body", EquipType.Body, this, "TarnenChestplate_Body");
        }
    }
}
