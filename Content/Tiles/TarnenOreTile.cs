using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Metalurgy.Content.Tiles
{
    public class TarnenOreTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileShine[Type] = 1150;
            Main.tileShine2[Type] = true;
            Main.tileOreFinderPriority[Type] = 410;

            AddMapEntry(new Color(200, 150, 100), Language.GetText("Mods.Metalurgy.Tiles.TarnenOreTile.MapEntry"));

            DustType = DustID.Copper;
            HitSound = SoundID.Tink;
            MineResist = 2f;
            MinPick = 35;
        }

        public override bool CanExplode(int i, int j) => true;
    }
}
