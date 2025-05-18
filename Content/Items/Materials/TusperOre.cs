// Created: v0.1.0.5

using Metalurgy.Content.Tiles;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Metalurgy.Content.Items.Materials
{
    public class TusperOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Tusper Ore");
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(copper: 50);
            Item.rare = ItemRarityID.Blue;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<TusperOreTile>();
        }
    }
}
