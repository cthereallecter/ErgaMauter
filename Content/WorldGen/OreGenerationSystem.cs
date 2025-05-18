// Created: v0.1.0.5

using System.Collections.Generic;

using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

using Metallurgy.Common;
using Metallurgy.Content.Tiles;
using Metallurgy.Common.Configs;

namespace Metallurgy.Content.Systems
{
    public class OreGenerationSystem : ModSystem
    {
        public static int EaterKillCount = 0;

        public static int EaterOfWorldsPowerLevel => EaterKillCount / 3;

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(genpass => genpass.Name == "Shinies");
            if (shiniesIndex == -1)
                return;

            tasks.Insert(shiniesIndex + 1, new PassLegacy("Metallurgy Ore Generation", GenerateOres));
        }

        private void GenerateOres(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating Metallurgy Ores";

            var config = ModContent.GetInstance<MetallurgyOreConfig>();

            OreUtilities.TryReplaceInVeins(
                TileID.Copper,
                ModContent.TileType<TarnenOreTile>(),
                minVeinSize: 15,
                transformChance: config.TarnenScarcity,
                targetRatio: config.TarnenTargetRatio,
                minHeight: config.TarnenMinHeight,
                maxHeight: config.TarnenMaxHeight
            );
        }

    }
}
