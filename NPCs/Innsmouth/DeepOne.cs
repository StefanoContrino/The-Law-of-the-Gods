using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace TheLawOfTheGods.NPCs.Innsmouth
{
    public class DeepOne : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 16;
        }

        public override void SetDefaults()
        {
            NPC.width = 46;          // Larghezza della hitbox
            NPC.height = 50;         // Altezza della hitbox
            NPC.damage = 15;         // Danno da contatto
            NPC.defense = 6;         // Difesa
            NPC.lifeMax = 40;        // Salute massima
            NPC.HitSound = SoundID.NPCHit1; // Suono quando viene colpito
            NPC.DeathSound = SoundID.NPCDeath1; // Suono alla morte
            NPC.value = 60f;         // Valore in monete (in rame)
            
            // Usa l'intelligenza artificiale (AI) standard di un combattente terrestre (cammina, salta gli ostacoli e segue il giocatore)
            AIType = NPCID.GoblinPeon; 
            NPC.aiStyle = 3;
        }

        public override void FindFrame(int frameHeight)
        {
            // Animazione semplice basata sullo stile AI 3 (camminata)
            NPC.frameCounter++;
            if (NPC.frameCounter > 6)
            {
                NPC.frame.Y = (NPC.frame.Y + frameHeight) % (Main.npcFrameCount[NPC.type] * frameHeight);
                NPC.frameCounter = 0;
            }

            // Gira lo sprite nella direzione in cui si muove
            if (NPC.velocity.X != 0)
            {
                NPC.spriteDirection = NPC.direction;
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            // Imposta la frequenza di spawn (es. in superficie durante il giorno)
            return SpawnCondition.OverworldDay.Chance * 0.1f;
        }
    }
}