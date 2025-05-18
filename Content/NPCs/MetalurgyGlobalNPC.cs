using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Metalurgy.Common;
using Metalurgy.Content.Tiles;
using Metalurgy.Content.Systems;

namespace Metalurgy.Content
{
    public class MetalurgyGlobalNPC : GlobalNPC
    {
        public override void OnKill(NPC npc)
        {
            if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail)
            {
                // Ensure EoW is fully dead (multi-segment boss)
                if (!NPC.AnyNPCs(NPCID.EaterofWorldsHead) &&
                    !NPC.AnyNPCs(NPCID.EaterofWorldsBody) &&
                    !NPC.AnyNPCs(NPCID.EaterofWorldsTail))
                {
                    // Increment kill count
                    OreGenerationSystem.EaterKillCount++;

                    OreUtilities.PlaceOreNear(
                                    TileID.Demonite,
                                    ModContent.TileType<TusperOreTile>(),
                                    maxCount: 500,
                                    chance: 0.3f
                                 );
                }
            }
        }

        public override void SetDefaults(NPC npc)
        {
            if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail)
            {
                int powerLevel = OreGenerationSystem.EaterOfWorldsPowerLevel;
                if (powerLevel > 0)
                {
                    float healthMultiplier = 1f + (0.05f * powerLevel);
                    float damageMultiplier = 1f + (0.02f * powerLevel);

                    npc.lifeMax = (int)(npc.lifeMax * healthMultiplier);
                    npc.damage = (int)(npc.damage * damageMultiplier);

                    if (npc.life > 0) // Update current life to match new max
                        npc.life = npc.lifeMax;
                }
            }
        }
    }
}
