using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace ErgaMauter.Content.Items.Accessories
{
    public class CrimsonFangPendant : ModItem
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
                                gold: 1,
                                silver: 12,
                                copper: 91
                            );
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) += 0.05f;

            bool hasSharkTooth = false;
            for (int i = 3; i < 13; i++)
            {
                if (player.armor[i].type == ItemID.SharkToothNecklace)
                {
                    hasSharkTooth = true;
                    break;
                }
            }

            if (hasSharkTooth)
            {
                // player.armorPenetration += 5;

                if (Main.rand.NextBool(6))
                    Dust.NewDustDirect(player.position, player.width, player.height, DustID.Blood).noGravity = true;
            }
        }
    }
}