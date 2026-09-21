using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Events;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace TheLawOfTheGods.NPCs.TownNPCs
{
    
    public class Charles : ModNPC
    {

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 25;
            NPCID.Sets.ExtraFramesCount[Type] = 9;
            NPCID.Sets.AttackFrameCount[Type] = 4;
            NPCID.Sets.DangerDetectRange[Type] = 500;
            NPCID.Sets.AttackType[Type] = 0;
            NPCID.Sets.AttackTime[Type] = 60;
            NPCID.Sets.AttackAverageChance[Type] = 10;
            NPCID.Sets.ShimmerTownTransform[Type] = false;
            
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifiers);

        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.lavaImmune = false;
            NPC.width = 20;
            NPC.height = 40;
            NPC.aiStyle = NPCAIStyleID.Passive;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250; //Im not special :(
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.PartyGirl;
            NPC.Happiness
            .SetBiomeAffection<OceanBiome>(AffectionLevel.Love);
        }

        public override string GetChat()
        {
            return "Hi folk. I don't really like people, but you... you seem like someone who can understand me.";
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Dialogue";
            button2 = null;
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                WeightedRandom<string> dialogue = new WeightedRandom<string>();

                dialogue.Add("The sea remembers everything. Every ship that sinks, every name that is forgotten...");
                dialogue.Add("Do not listen too closely to the waves at night. Sometimes they whisper things that were never meant for human ears.");
                dialogue.Add("My ancestors made a pact beneath the cold waters. They gained eternity... but lost something far more precious.");
                dialogue.Add("There are ruins beneath the ocean older than any kingdom of man. Some things down there still wait for their return.");
                dialogue.Add("The people of this town used to pray to the stars. Now they pray to what lies beyond the waves.");
                dialogue.Add("Have you ever wondered why the fishermen never speak about what they find in the deep?");
                dialogue.Add("The fog around this place is not natural. It hides what should remain unseen.");
                dialogue.Add("I once saw a creature rising from the abyss. I still dream of its impossible shape.");
                dialogue.Add("The old families of Innsmouth knew the truth: the ocean was never empty.");
                dialogue.Add("There are voices beneath the tides calling my name. I fear that one day I will answer.");

                Main.npcChatText = dialogue;
            }
        }


        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            return true;
        }


        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                if (!Main.dedServ)
                {
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CharlesGoreArm").Type, 1f);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CharlesGoreHead").Type, 1f);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CharlesGoreLeg").Type, 1f);
                }
            }
        }

    }
}
