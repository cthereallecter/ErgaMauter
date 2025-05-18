using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;

namespace Metalurgy.Common
{
    public static class OreUtilities
    {
        public static void GenerateOreInVeins(int sourceTileType, int minVeinSize, int maxVeinSize, int oreType, float oreRatio)
        {
            for (int x = 50; x < Main.maxTilesX - 50; x++)
            {
                for (int y = (int)Main.worldSurface + 10; y < Main.maxTilesY - 150; y++)
                {
                    Tile tile = Main.tile[x, y];
                    if (tile != null && tile.HasTile && tile.TileType == sourceTileType)
                    {
                        int veinSize = WorldGen.genRand.Next(minVeinSize, maxVeinSize);
                        int oresToPlace = (int)(veinSize * oreRatio);

                        for (int i = 0; i < oresToPlace; i++)
                        {
                            TryPlaceOre(x + WorldGen.genRand.Next(-1, 2), y + WorldGen.genRand.Next(-1, 2), oreType);
                        }
                    }
                }
            }
        }

        public static void PlaceOreNear(int anchorTileType, int oreType, int maxCount, float chance = 0.3f)
        {
            int count = 0;
            for (int x = 50; x < Main.maxTilesX - 50 && count < maxCount; x++)
            {
                for (int y = (int)Main.worldSurface + 10; y < Main.maxTilesY - 150 && count < maxCount; y++)
                {
                    Tile tile = Main.tile[x, y];
                    if (tile != null && tile.HasTile && tile.TileType == anchorTileType && WorldGen.genRand.NextFloat() < chance)
                    {
                        count += TrySurroundWithOre(x, y, oreType);
                    }
                }
            }
        }

        public static void TryReplaceInVeins(int targetTileType, int oreType, int minVeinSize, float transformChance, float targetRatio)
        {
            HashSet<Point> visited = new();
            List<List<Point>> veins = new();

            for (int x = 50; x < Main.maxTilesX - 50; x++)
            {
                for (int y = 50; y < Main.maxTilesY - 150; y++)
                {
                    Point p = new(x, y);
                    if (!visited.Contains(p) && Main.tile[x, y].HasTile && Main.tile[x, y].TileType == targetTileType)
                    {
                        var vein = FloodFillVein(x, y, targetTileType, visited);
                        if (vein.Count >= minVeinSize)
                            veins.Add(vein);
                    }
                }
            }

            foreach (var vein in veins)
            {
                if (WorldGen.genRand.NextFloat() > transformChance)
                    continue;

                int targetCount = (int)(vein.Count * targetRatio);
                int placed = 0;

                for (int i = 0; i < vein.Count && placed < targetCount; i++)
                {
                    Point p = vein[WorldGen.genRand.Next(vein.Count)];
                    Tile tile = Main.tile[p.X, p.Y];
                    if (tile.HasTile && tile.TileType == targetTileType && WorldGen.genRand.Next(12) == 0)
                    {
                        tile.TileType = (ushort)oreType;
                        placed++;
                    }
                }
            }
        }

        public static void TryPlaceOre(int x, int y, int oreType)
        {
            if (!WorldGen.InWorld(x, y))
                return;

            Tile tile = Main.tile[x, y];
            if (tile != null && (!tile.HasTile || tile.TileType == TileID.Stone))
            {
                tile.TileType = (ushort)oreType;
                tile.HasTile = true;
            }
        }

        private static int TrySurroundWithOre(int x, int y, int oreType)
        {
            int placed = 0;
            foreach (var (dx, dy) in new[] { (1, 0), (-1, 0), (0, 1), (0, -1) })
            {
                int tx = x + dx, ty = y + dy;
                if (WorldGen.InWorld(tx, ty))
                {
                    Tile tile = Main.tile[tx, ty];
                    if (tile != null && (!tile.HasTile || tile.TileType == TileID.Stone))
                    {
                        tile.TileType = (ushort)oreType;
                        tile.HasTile = true;
                        placed++;
                    }
                }
            }
            return placed;
        }

        private static List<Point> FloodFillVein(int startX, int startY, int tileType, HashSet<Point> visited)
        {
            Stack<Point> stack = new();
            List<Point> vein = new();
            stack.Push(new Point(startX, startY));

            while (stack.Count > 0)
            {
                Point p = stack.Pop();
                if (!visited.Add(p) || !WorldGen.InWorld(p.X, p.Y))
                    continue;

                Tile tile = Main.tile[p.X, p.Y];
                if (tile == null || !tile.HasTile || tile.TileType != tileType)
                    continue;

                vein.Add(p);

                for (int dx = -1; dx <= 1; dx++)
                    for (int dy = -1; dy <= 1; dy++)
                        if (dx != 0 || dy != 0)
                            stack.Push(new Point(p.X + dx, p.Y + dy));
            }

            return vein;
        }
    }
}
