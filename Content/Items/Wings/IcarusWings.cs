// Created: v0.1.0.5

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Metalurgy.Content.Items.Materials;

namespace Metalurgy.Content.Items.Wings
{
    public class IcarusWings : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Fly with caution... \nthey fall off if you go too high!");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
            Item.accessory = true;
            Item.value = Item.buyPrice(silver: 50);
            Item.rare = ItemRarityID.Blue;
            Item.wingSlot = EquipLoader.GetEquipSlot(Mod, "IcarusWings_Wings", EquipType.Wings);
        }

        public override void Load()
        {
            if (!Main.dedServ)
            {
                EquipLoader.AddEquipTexture(Mod, "Metalurgy/Content/Items/Wings/IcarusWings_Wings", EquipType.Wings, this, "IcarusWings_Wings");
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.Center.Y < Main.worldSurface * 16 - 200f)
            {
                player.wingTime = 0;
                if (Main.rand.NextBool(8))
                    Dust.NewDust(player.position, player.width, player.height, DustID.Cloud, 0, -2);
            }
            else
            {
                player.wingTimeMax = 50;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BeeWax, 8);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddIngredient(ModContent.ItemType<TarnenBar>(), 10);
            recipe.AddIngredient(ItemID.Feather, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
