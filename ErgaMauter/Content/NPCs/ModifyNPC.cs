// v0.1.0.1
using ErgaMauter.Content.Items.Accessories;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace ErgaMauter.Content.NPCs
{
    public class ModifyNPC : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            switch (npc.type)
            {
                case NPCID.EyeofCthulhu:
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