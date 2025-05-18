using Terraria.ModLoader.Config;
using System.ComponentModel;

namespace Metallurgy.Common.Configs
{
    public class MetallurgyOreConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("$Mods.Metallurgy.Configs.TarnenOreHeader")]

        [Range(0, 600)]
        [DefaultValue(0)]
        public int TarnenMinHeight;

        [Range(0, 600)]
        [DefaultValue(300)]
        public int TarnenMaxHeight;

        [Range(0f, 1f)]
        [DefaultValue(0.25f)]
        public float TarnenScarcity;

        [Range(0f, 1f)]
        [DefaultValue(0.2f)]
        public float TarnenTargetRatio;
    }
}
