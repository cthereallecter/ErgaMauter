using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace ErgaMauter.Content.Items.Accessories
{
    public class CursedCogwheel : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(
                                silver: 80
                            );
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetAttackSpeed(DamageClass.Ranged) += 0.15f;

            if (player.HeldItem.type == ItemID.Minishark)
            {
                player.GetAttackSpeed(DamageClass.Ranged) += 0.10f;

                if (Main.rand.NextBool(8))
                    Dust.NewDustDirect(player.position, player.width, player.height, DustID.Smoke).noGravity = true;
            }
        }
    }
}