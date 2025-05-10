using Microsoft.Xna.Framework;

using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace ErgaMauter.Content.Items.Weapons.Magic
{
    public class ElementalBeamStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(gold: 1);

            Item.damage = 34;
            Item.DamageType = DamageClass.Magic;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.knockBack = 4f;
            Item.crit = 4;

            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.Magic.FireBeam>();
            Item.shootSpeed = 0f; // Not used since beam spawns from sky
            Item.mana = 10;

            Item.scale = 1.3f;                            // Size scaling of the weapon (visual only)
            Item.maxStack = 1;                          // Most weapons can't stack
            Item.noMelee = true;
            Item.noUseGraphic = false;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 mouseWorld = Main.MouseWorld;
            Vector2 fireSpawn = new Vector2(mouseWorld.X - 120, mouseWorld.Y - 600f);
            Vector2 iceSpawn = new Vector2(mouseWorld.X + 120, mouseWorld.Y - 600f);

            int fire = Projectile.NewProjectile(source, fireSpawn, Vector2.Zero, ModContent.ProjectileType<Projectiles.Magic.FireBeam>(), damage, knockback, player.whoAmI);
            int ice = Projectile.NewProjectile(source, iceSpawn, Vector2.Zero, ModContent.ProjectileType<Projectiles.Magic.IceBeam>(), damage, knockback, player.whoAmI);

            if (Main.projectile.IndexInRange(fire))
            {
                Main.projectile[fire].ai[0] = mouseWorld.X;
                Main.projectile[fire].ai[1] = mouseWorld.Y;
            }
            if (Main.projectile.IndexInRange(ice))
            {
                Main.projectile[ice].ai[0] = mouseWorld.X;
                Main.projectile[ice].ai[1] = mouseWorld.Y;
            }

            return false;
        }


        public override void AddRecipes()
        {
            Recipe baseRecipe = CreateRecipe();
            baseRecipe.AddIngredient(ItemID.PlatinumBar, 8);
            baseRecipe.AddIngredient(ItemID.FrostCore);
            baseRecipe.AddIngredient(ItemID.HellstoneBar, 3);
            baseRecipe.AddTile(TileID.MythrilAnvil);
            baseRecipe.Register();

            Recipe testRecipe = CreateRecipe();
            testRecipe.AddIngredient(ItemID.Wood, 8);
            testRecipe.AddTile(TileID.Anvils);
            testRecipe.Register();
        }
    }
}
