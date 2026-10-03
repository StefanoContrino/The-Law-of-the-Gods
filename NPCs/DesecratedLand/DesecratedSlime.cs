using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheLawOfTheGods.NPCs.DesecratedLand
{
    public class DesecratedSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 2;
            NPCID.Sets.TrailingMode[Type] = 0;
        }

        public override void SetDefaults()
        {
            NPC.width = 52; 
            NPC.height = 32; 
            NPC.damage = 15; 
            NPC.defense = 6;
            NPC.lifeMax = 25; 
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 25f;

            NPC.aiStyle = NPCAIStyleID.Slime;

            AIType = NPCID.BlueSlime;
            AnimationType = NPCID.BlueSlime;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            // Sistema moderno a regole di tModLoader 1.4
            npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 1, 1, 3)); // 1 = 100% di probabilità - 1 = minimo 1 di drop - 4 = massimo 4 di drop
        }


        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            // Restituisce la probabilità di spawn basandosi sulle condizioni degli slime di superficie diurni
            if (spawnInfo.Player.ZoneOverworldHeight && Main.dayTime) {
                return 0.5f; // 0.1f è più raro
            }
            return 0f;
        }

    }
}
