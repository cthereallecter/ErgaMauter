using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ErgaMauter.Content.Projectiles.Magic
{
    public class IceBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 5;
            Projectile.timeLeft = 30;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;

            Main.projFrames[Projectile.type] = 8; // 8 vertical frames
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value;
            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            Rectangle sourceRectangle = new Rectangle(0, frameHeight * Projectile.frame, texture.Width, frameHeight);
            Vector2 origin = sourceRectangle.Size() / 2f;

            Main.EntitySpriteDraw(
                texture,
                Projectile.Center - Main.screenPosition,
                sourceRectangle,
                lightColor,
                Projectile.rotation,
                origin,
                Projectile.scale,
                SpriteEffects.None,
                0
            );

            return false;
        }

        public override void AI()
        {
            if (!Projectile.localAI[0].Equals(1f)) // Only run this once
            {
                Vector2 target = new Vector2(Projectile.ai[0], Projectile.ai[1]);
                Vector2 direction = target - Projectile.Center;
                direction.Normalize();
                Projectile.velocity = direction * 40f;
                Projectile.localAI[0] = 1f;
            }

            // Rotation (spinning)
            Projectile.rotation += 0.4f;

            // Beam effects
            Lighting.AddLight(Projectile.Center, 0.1f, 0.4f, 1f);
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Ice);

            // Destroy projectile if it's near the target point
            Vector2 targetPos = new Vector2(Projectile.ai[0], Projectile.ai[1]);
            if (Vector2.Distance(Projectile.Center, targetPos) < 10f)
            {
                Projectile.Kill();
            }
        }
    }
}
