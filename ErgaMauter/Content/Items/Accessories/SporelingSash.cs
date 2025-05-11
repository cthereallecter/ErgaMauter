using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace ErgaMauter.Content.Items.Accessories
{
    public class SporelingSash : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(
                                silver: 90
                            );
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen += 2;

            bool hasNatureGift = false;
            for (int i = 3; i < 13; i++)
            {
                if (player.armor[i].type == ItemID.NaturesGift)
                {
                    hasNatureGift = true;
                    break;
                }
            }

            if (hasNatureGift)
            {
                player.statDefense += 3;

                if (Main.rand.NextBool(10))
                {
                    Dust.NewDustDirect(player.position, player.width, player.height, DustID.MushroomSpray).noGravity = true;
                }
            }
        }
    }
}