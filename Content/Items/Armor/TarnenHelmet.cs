// Created: v0.1.0.5

using Metalurgy.Content.Items.Materials;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Metalurgy.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class TarnenHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bronzium Helmet");
            // Tooltip.SetDefault("A sturdy pre-midgame helmet.");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(silver: 60);
            Item.rare = ItemRarityID.Green;
            Item.defense = 3;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<TarnenChestplate>() &&
                   legs.type == ModContent.ItemType<TarnenLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases movement speed by 8%\nIncreases defense by 3";
            player.moveSpeed += 0.08f;
            player.statDefense += 3;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TarnenBar>(), 14)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override void Load()
        {
            // Register the head texture (_Head)
            EquipLoader.AddEquipTexture(Mod, "Metalurgy/Content/Items/Armor/TarnenHelmet_Head", EquipType.Head, this, "TarnenHelmet_Head");
        }
    }
}
