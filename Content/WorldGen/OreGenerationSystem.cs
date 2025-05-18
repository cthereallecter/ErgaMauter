using System.Collections.Generic;

using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

using Metalurgy.Common;
using Metalurgy.Content.Tiles;

namespace Metalurgy.Content.Systems
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

            tasks.Insert(shiniesIndex + 1, new PassLegacy("Metalurgy Ore Generation", GenerateOres));
        }

        private void GenerateOres(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating Metalurgy Ores";

            // Replace copper veins with Tarnen
            OreUtilities.TryReplaceInVeins(
                TileID.Copper,
                ModContent.TileType<TarnenOreTile>(),
                minVeinSize: 15,
                transformChance: 0.25f,
                targetRatio: 0.2f
            );
        }
    }
}
