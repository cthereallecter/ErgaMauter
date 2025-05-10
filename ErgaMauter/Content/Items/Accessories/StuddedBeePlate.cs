using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace ErgaMauter.Content.Items.Accessories
{
    public class StuddedBeePlate : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 32;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(
                                gold: 1,
                                silver: 75,
                                copper: 32
                            );
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense += 8;

            bool hasHoneyComb = false;

            // Check equipped accessories
            for (int i = 3; i < 3 + 10; i++)
            {
                Item accessory = player.armor[i];
                if (accessory != null && !accessory.IsAir && accessory.type == ItemID.HoneyComb)
                {
                    hasHoneyComb = true;
                    break;
                }
            }

            if (hasHoneyComb)
            {
                // Boost healing effects via honeyCombItem
                player.honeyCombItem = Item;

                // Register the combo effect
                player.GetModPlayer<StuddedHoneycombPlayer>().comboActive = true;

                // Visuals
                if (Main.rand.NextBool(5))
                {
                    Dust honeyDust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.Honey);
                    honeyDust.velocity *= 0.3f;
                    honeyDust.scale = 1.2f;
                    honeyDust.noGravity = true;
                }

                if (Main.rand.NextBool(10))
                {
                    Dust beeDust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.Bee);
                    beeDust.velocity *= 0.2f;
                    beeDust.scale = 1.4f;
                    beeDust.noGravity = true;
                }
            }
        }
    }
}