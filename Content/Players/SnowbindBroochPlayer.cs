using Terraria;
using Terraria.ModLoader;

namespace ErgaMauter.Content.Players
{
    public class SnowbindBroochPlayer : ModPlayer
    {
        public bool slowEffect;

        public override void ResetEffects()
        {
            slowEffect = false;
        }
    }
}
