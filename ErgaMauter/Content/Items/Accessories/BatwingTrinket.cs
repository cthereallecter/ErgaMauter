using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace ErgaMauter.Content.Items.Accessories
{
    public class BatwingTrinket : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(silver: 55);
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax += 10; // pseudo flapping boost

            bool hasCloud = false;
            for (int i = 3; i < 13; i++)
            {
                if (player.armor[i].type == ItemID.CloudinaBottle)
                {
                    hasCloud = true;
                    break;
                }
            }

            if (hasCloud)
            {
                player.jumpSpeedBoost += 1.8f;
                player.moveSpeed += 0.08f;

                if (Main.rand.NextBool(10))
                {
                    Dust.NewDustDirect(player.position, player.width, player.height, DustID.Cloud).noGravity = true;
                }
            }
        }
    }
}