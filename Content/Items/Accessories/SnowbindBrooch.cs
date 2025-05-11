// Created: v0.1.0.3

using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace ErgaMauter.Content.Items.Accessories
{
    public class SnowbindBrooch : ModItem
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
            Item.value = Item.sellPrice(silver: 50);
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<Players.SnowbindBroochPlayer>().slowEffect = true;
        }
    }

    public class SnowbindBroochGlobalItem : GlobalItem
    {
        public override void OnHitNPC(Item item, Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (player.GetModPlayer<Players.SnowbindBroochPlayer>().slowEffect &&
                (item.type == ItemID.SnowballCannon || item.type == ItemID.IceBoomerang))
            {
                target.AddBuff(BuffID.Slow, 120); // 2 seconds of Slow
            }
        }
    }
}