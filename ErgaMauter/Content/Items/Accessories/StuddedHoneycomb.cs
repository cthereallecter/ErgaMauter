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
            Item.width = 28;
            Item.height = 32;
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
            // Create a recipe for crafting the Studded Honeycomb - thematically appropriate materials
            Recipe IronBarRecipe = CreateRecipe();
            IronBarRecipe.AddIngredient(ItemID.Hive, 15);  // Requires Hive Blocks
            IronBarRecipe.AddIngredient(ItemID.Stinger, 3);  // Requires Stingers from the jungle
            IronBarRecipe.AddIngredient(ItemID.IronBar, 3);  // Requires 3 Iron Bars for the studs
            IronBarRecipe.AddTile(TileID.Anvils);  // Crafted at an Anvil
            IronBarRecipe.Register();

            // Alternative recipe with Lead instead of Iron
            Recipe LeadBarRecipe = CreateRecipe();
            LeadBarRecipe.AddIngredient(ItemID.Hive, 15);  // Requires Hive Blocks
            LeadBarRecipe.AddIngredient(ItemID.Stinger, 3);  // Requires Stingers from the jungle
            LeadBarRecipe.AddIngredient(ItemID.LeadBar, 3);  // Requires 3 Lead Bars for the studs
            LeadBarRecipe.AddTile(TileID.Anvils);  // Crafted at an Anvil
            LeadBarRecipe.Register();

            // Alternative recipe with Lead instead of Iron
            Recipe TinBarRecipe = CreateRecipe();
            TinBarRecipe.AddIngredient(ItemID.Hive, 15);  // Requires Hive Blocks
            TinBarRecipe.AddIngredient(ItemID.Stinger, 3);  // Requires Stingers from the jungle
            TinBarRecipe.AddIngredient(ItemID.TinBar, 5);  // Requires 3 Tin Bars for the studs
            TinBarRecipe.AddTile(TileID.Anvils);  // Crafted at an Anvil
            TinBarRecipe.Register();
        }
    }
}