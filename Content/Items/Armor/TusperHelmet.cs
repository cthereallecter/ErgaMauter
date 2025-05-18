// Created: v0.1.0.5

using Metallurgy.Content.Items.Materials;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Metallurgy.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class TusperHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Tusper Helmet");
            // Tooltip.SetDefault("A sturdy pre-midgame helmet.");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(silver: 60);
            Item.rare = ItemRarityID.Blue;
            Item.defense = 7;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<TusperChestplate>() &&
                   legs.type == ModContent.ItemType<TusperLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases defense by 3";
            player.statDefense += 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TusperBar>(), 12)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override void Load()
        {
            // Register the head texture (_Head)
            EquipLoader.AddEquipTexture(Mod, "Metallurgy/Content/Items/Armor/TusperHelmet_Head", EquipType.Head, this, "TusperHelmet_Head");
        }
    }
}
