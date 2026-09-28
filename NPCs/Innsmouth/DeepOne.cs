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
            NPC.width = 46;
            NPC.height = 50;
            NPC.damage = 15;
            NPC.defense = 6;
            NPC.lifeMax = 40;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 60f;
            
            NPC.aiStyle = NPCAIStyleID.Fighter;
            AIType = NPCID.Zombie; 
        }

        public override void AI()
        {
            NPC.TargetClosest(true);

            if (NPC.HasPlayerTarget)
            {
                Player target = Main.player[NPC.target];

                bool isGrounded = NPC.velocity.Y == 0;

                // Gestione del cooldown del salto (usa NPC.ai[0] come timer)
                if (NPC.ai[0] > 0)
                {
                    NPC.ai[0]--; // Riduce il timer a ogni tick
                }

                if (isGrounded)
                {
                    // Calcola la distanza orizzontale e verticale dal giocatore
                    float distanceX = System.Math.Abs(target.Center.X - NPC.Center.X);
                    bool playerIsHigher = target.Center.Y < NPC.Center.Y - 24f; // Deve essere abbastanza più in alto
                    
                    // Controlla se c'è un blocco solido davanti a lui
                    int tileX = (int)(NPC.Center.X + (NPC.direction * (NPC.width / 2 + 8))) / 16;
                    int tileY = (int)(NPC.Bottom.Y / 16);
                    bool blockedAhead = WorldGen.SolidTile(tileX, tileY - 1) || WorldGen.SolidTile(tileX, tileY - 2);

                    // SALTA SOLO SE:
                    // - Il timer di cooldown è a 0
                    // - È abbastanza vicino orizzontalmente (es. entro 150 pixel)
                    // - Il player è più in alto OPPURE c'è un blocco davanti
                    if (NPC.ai[0] <= 0 && distanceX < 50f && (playerIsHigher || blockedAhead))
                    {
                        NPC.velocity.Y = -6.5f; // Forza del salto
                        NPC.ai[0] = 40; // Cooldown di 40 tick (circa 2/3 di secondo) prima di poter saltare di nuovo
                    }
                }
            }
        }

        public override void FindFrame(int frameHeight)
        {
            if (NPC.velocity.Y != 0)
            {
                NPC.frame.Y = 3 * frameHeight; // Frame del salto
            }
            else if (NPC.velocity.X != 0)
            {
                NPC.frameCounter++;
                if (NPC.frameCounter > 6)
                {
                    int minFrame = 0;
                    int maxFrame = 7; 

                    NPC.frame.Y += frameHeight;
                    if (NPC.frame.Y < minFrame * frameHeight || NPC.frame.Y > maxFrame * frameHeight)
                    {
                        NPC.frame.Y = minFrame * frameHeight;
                    }
                    NPC.frameCounter = 0;
                }
            }
            else
            {
                NPC.frame.Y = 0; 
            }

            if (NPC.direction != 0)
            {
                NPC.spriteDirection = NPC.direction;
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 0.1f;
        }
    }
}