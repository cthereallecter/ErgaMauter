// Created: v0.1.0.5

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Metallurgy.Content.Tiles
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

            AddMapEntry(new Color(200, 150, 100), Language.GetText("Mods.Metallurgy.Tiles.TarnenOreTile.MapEntry"));

            DustType = DustID.Copper;
            HitSound = SoundID.Tink;
            MineResist = 2f;
            MinPick = 35;
        }

        public override bool CanExplode(int i, int j) => true;
    }
}
