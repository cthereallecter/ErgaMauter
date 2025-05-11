using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

using ErgaMauter.Content.Items.Accessories;

namespace ErgaMauter.Content.NPCs
{
    public class ModifyNPC : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            switch (npc.type)
            {
                case 507: // Angry Tumbler
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CursedCogwheel>(), 40)); // 2.5%
                    break;
                case NPCID.CaveBat:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BatwingTrinket>(), 40)); // 2.5%
                    break;
                case NPCID.EyeofCthulhu:
                    break;
                case NPCID.FaceMonster:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CrimsonFangPendant>(), 40)); // 2.5%
                    break;
                case NPCID.GiantFungiBulb:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SporelingSash>(), 33)); // ~3.03%
                    break;
                case NPCID.IceSlime:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SnowbindBrooch>(), 40)); // 2.5%
                    break;
                case NPCID.KingSlime:
                    break;
                case NPCID.Retinazer:
                case NPCID.Spazmatism:
                    break;
                case NPCID.QueenBee:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StuddedBeePlate>(), 12, 1, 1));
                    break;
            }
        }
    }
}