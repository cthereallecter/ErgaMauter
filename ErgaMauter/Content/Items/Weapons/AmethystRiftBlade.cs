using Microsoft.Xna.Framework;

using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace ErgaMauter.Content.Items.Weapons
{
    public class AmethystRiftBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            // Basic Item Properties
            Item.width = 32;                            // Hitbox width of the item
            Item.height = 32;                           // Hitbox height of the item
            Item.rare = ItemRarityID.Blue;              // Item rarity
            Item.value = Item.sellPrice(silver: 35);    // Item sell value
            
            // Combat Properties
            Item.damage = 20;                           // Base damage 
            Item.DamageType = DamageClass.Melee;        // Damage type (Melee, Ranged, Magic, etc.)
            Item.useStyle = ItemUseStyleID.Swing;       // Animation style (Swing is common for swords)
            Item.useTime = 20;                          // Speed of use - lower is faster
            Item.useAnimation = 20;                     // Animation duration - should match useTime for most weapons
            Item.knockBack = 6f;                        // Knockback power
            Item.crit = 6;                              // Critical strike chance bonus (base is 4%)
            
            // Sound and Visual Properties
            Item.UseSound = SoundID.Item1;              // Sound when used
            Item.autoReuse = true;                      // Auto-reuse (hold to keep swinging)
            
            // Projectile Properties (if the sword shoots projectiles)
            // Item.shoot = ProjectileID.Fireball;         // No projectile by default - change for projectile swords
            // Item.shootSpeed = 3f;                       // Speed of projectile if applicable
            
            // Other Properties
            Item.scale = 1.3f;                            // Size scaling of the weapon (visual only)
            Item.maxStack = 1;                          // Most weapons can't stack
            Item.noMelee = false;                       // True would disable the melee hitbox
            Item.noUseGraphic = false;                  // True would hide the item sprite when used
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            // Optional: Add dust effects when swinging
            if (Main.rand.NextBool(3))                  // 1/3 chance each frame of the animation
            {
                // Create dust at a random position within the hitbox
                Dust.NewDust(
                    new Vector2(hitbox.X, hitbox.Y), 
                    hitbox.Width, 
                    hitbox.Height, 
                    DustID.Torch,                       // Change dust type as needed
                    0f, 0f, 0, Color.Purple, 1f
                );
            }
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            // Optional: Add effects when hitting an enemy
            // Example: Apply a buff or debuff
            target.AddBuff(BuffID.Bleeding, 180);         // Set target on bleeding for 3 seconds (60 frames = 1 second)
        }

        public override void AddRecipes()
        {
            // Updated recipe using amethyst and materials that make sense for a rift blade
            Recipe ShadowScaleRecipe = CreateRecipe();
            ShadowScaleRecipe.AddIngredient(ItemID.Amethyst, 8);      // 8 Amethyst gems
            ShadowScaleRecipe.AddIngredient(ItemID.ShadowScale, 5);   // 5 Shadow Scales for the rift property
            ShadowScaleRecipe.AddIngredient(ItemID.DemoniteBar, 8);  // 8 Demonite Bars
            ShadowScaleRecipe.AddTile(TileID.Anvils);                 // Requires an Anvil
            ShadowScaleRecipe.Register();
            
            // Alternative recipe with Tungsten and Tissue Samples
            Recipe TissueSampleRecipe = CreateRecipe();
            TissueSampleRecipe.AddIngredient(ItemID.Amethyst, 8);      // 8 Amethyst gems
            TissueSampleRecipe.AddIngredient(ItemID.TissueSample, 5);  // 5 Tissue Samples (Crimson equivalent)
            TissueSampleRecipe.AddIngredient(ItemID.DemoniteBar, 8);  // 8 Demonite Bars
            TissueSampleRecipe.AddTile(TileID.Anvils);                 // Requires an Anvil
            TissueSampleRecipe.Register();
        }

        // Optional: Make the weapon have an aura when held or swing projectiles
        /*
        public override void HoldItem(Player player)
        {
            // Create aura effects around the player
            if (Main.rand.NextBool(20))
            {
                Dust.NewDust(
                    player.position,
                    player.width,
                    player.height,
                    DustID.Torch,                           // Change dust type as needed
                    0f, 0f, 0, Color.Violet, 1f
                );
            }
        }
        */
        
        /*
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // Create projectiles when swinging
            // Useful for swords that shoot beams or other projectiles
            // Example: Star Fury-like star projectile
            Projectile.NewProjectile(source, position, velocity, ProjectileID.Fireball, damage, knockback, player.whoAmI);
            return false; // Return false to prevent the default projectile from being shot
        }
        */
    }
}