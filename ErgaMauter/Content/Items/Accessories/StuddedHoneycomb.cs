using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace ErgaMauter.Content.Items.Accessories
{
    public class StuddedHoneycomb : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            // Basic item properties
            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice(silver: 75);
            Item.rare = ItemRarityID.Blue; // Blue rarity
            Item.accessory = true; // This marks the item as an accessory
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // This is where we apply the defense buff when the accessory is equipped
            player.statDefense += 10;
        }

        public override void AddRecipes()
        {
            // Create a recipe for crafting the Studded Honeycomb
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.IronBar, 5);  // Requires 5 Iron Bars
            recipe1.AddIngredient(ItemID.StoneBlock, 10);  // Requires 10 Stone Blocks
            recipe1.AddTile(TileID.Anvils);  // Crafted at an Anvil
            recipe1.Register();

            // Alternative recipe with Lead instead of Iron
            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.LeadBar, 5);  // Requires 5 Lead Bars
            recipe2.AddIngredient(ItemID.StoneBlock, 10);  // Requires 10 Stone Blocks
            recipe2.AddTile(TileID.Anvils);  // Crafted at an Anvil
            recipe2.Register();

            // Alternative recipe with Tin instead of Iron
            Recipe recipe3 = CreateRecipe();
            recipe3.AddIngredient(ItemID.TinBar, 5);  // Requires 5 Lead Bars
            recipe3.AddIngredient(ItemID.StoneBlock, 10);  // Requires 10 Stone Blocks
            recipe3.AddTile(TileID.Anvils);  // Crafted at an Anvil
            recipe3.Register();
        }
    }
}