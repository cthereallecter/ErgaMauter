// Created: v0.1.0.5

using Metallurgy.Content.Items.Materials;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Metallurgy.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class TusperChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Tusper Chestplate");
            // Tooltip.SetDefault("Offers balanced early protection.");


            ArmorIDs.Body.Sets.HidesArms[Item.bodySlot] = false;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(silver: 90);
            Item.rare = ItemRarityID.Blue;
            Item.defense = 9;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TusperBar>(), 16)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override void Load()
        {
            // Register the body texture (_Body)
            EquipLoader.AddEquipTexture(Mod, "Metallurgy/Content/Items/Armor/TusperChestplate_Body", EquipType.Body, this, "TusperChestplate_Body");
        }
    }
}
