using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace TheLawOfTheGods.NPCs.TownNPCs.Charles
{
    public class Charles : ModNPC
    {
        public const string ShopName = "Shop";

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 25;
            NPCID.Sets.ExtraFramesCount[Type] = 9;
            NPCID.Sets.AttackFrameCount[Type] = 4;
            NPCID.Sets.DangerDetectRange[Type] = 500;
            NPCID.Sets.AttackType[Type] = 3;
            NPCID.Sets.AttackTime[Type] = 60;
            NPCID.Sets.AttackAverageChance[Type] = 10;
            NPCID.Sets.ShimmerTownTransform[Type] = false;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers =
                new NPCID.Sets.NPCBestiaryDrawModifiers() { Velocity = 1f };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifiers);
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.lavaImmune = false;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = NPCAIStyleID.Passive;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Merchant;
            NPC.Happiness.SetBiomeAffection<OceanBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<JungleBiome>(AffectionLevel.Hate);
            NPC.Happiness.SetNPCAffection(NPCID.Guide, AffectionLevel.Love);
            NPCHappiness.AffectionLevelToPriceMultiplier[AffectionLevel.Hate] = 15;
        }

        // I dialoghi casuali appaiono direttamente nel fumetto quando parli con Charles
        public override string GetChat()
        {
            WeightedRandom<string> dialogue = new WeightedRandom<string>();

            dialogue.Add(
                "Do you feel this crushing drowsiness in the air? It isn't fatigue... it's the weight of millennia of deep slumber."
            );
            dialogue.Add(
                "There is no true life here, but no true death either. Just a motionless waiting that has lasted for eons."
            );
            dialogue.Add(
                "The sky above us is perpetually pale. It's almost as if it's afraid to show what once walked upon these lands."
            );
            dialogue.Add(
                "No ancient prophecy chose this place. It was just pure bad luck: the foundations of our world built right atop the bed of a nightmare."
            );
            dialogue.Add(
                "You walk among fragments of an ancient passage. Every stone here preserves the echoes of a madness our minds cannot comprehend."
            );
            dialogue.Add(
                "When the Ancients stirred from their sleep, their sheer, unbridled presence tore tomorrow away from this world."
            );
            dialogue.Add(
                "What you see all around you is just the scar. Imagine the lunatic power that carved it into the earth..."
            );
            dialogue.Add(
                "Every now and then, I think I hear a whisper. Then I realize it's just the residual memory of what lived here before everything else."
            );
            dialogue.Add(
                "The Mi-Go do not protect this place out of devotion... they guard it like a cage, or a forgotten sanctuary."
            );
            dialogue.Add(
                "If you see strange shadows buzzing across the pale sky, don't try to understand them. Just run."
            );
            dialogue.Add(
                "They are servants to entities that transcend time itself. To them, our entire existence is nothing more than the blink of an eye."
            );
            dialogue.Add(
                "These lands are barren, yet we are not alone. They watch us—cold, methodical, and distant—from the edges of their sleep."
            );
            dialogue.Add(
                "Have you noticed how the wind here never howls? It only murmurs in a language that predates the stars."
            );
            dialogue.Add(
                "Some places are cursed because of sins committed. This place is cursed simply because it was in the way when they decided to wake."
            );
            dialogue.Add(
                "Look at the ground beneath your feet. Even the dust remembers the weight of footsteps that shouldn't exist."
            );
            dialogue.Add(
                "I found an artifact half-buried in the ash yesterday. It felt warm to the touch... as if something inside were still dreaming."
            );
            dialogue.Add(
                "Do not gaze too long into the pale mists. Sometimes, shapes move within them that vanish the moment you blink."
            );
            dialogue.Add(
                "The Mi-Go care nothing for our gold or our power. They are collecting pieces of a puzzle we were never meant to see completed."
            );
            dialogue.Add(
                "Time flows differently in the Consecrated Land. Minutes stretch like centuries, and centuries pass in the space of a heartbeat."
            );
            dialogue.Add(
                "If an Ancient ever opens its eyes fully, this reality will snap like dry twigs. Let us pray they remain blind a little longer."
            );

            return dialogue;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            // Bottone impostato come "Shop" (nativo)
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = ""; // Secondo bottone disattivato
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            // Siccome c'è un solo bottone, se viene premuto si apre direttamente lo shop
            if (firstButton)
            {
                shopName = ShopName;
            }
        }

        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, ShopName);

            npcShop.Add(ItemID.Coral);
            npcShop.Add(ItemID.Starfish);
            npcShop.Add(ItemID.Seashell);

            // Per aggiungere un oggetto personalizzato della mod:
            // npcShop.Add(ModContent.ItemType<NomeDelTuoOggetto>());

            npcShop.Register();
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
                    Gore.NewGore(
                        NPC.GetSource_Death(),
                        NPC.position,
                        NPC.velocity,
                        Mod.Find<ModGore>("CharlesGoreArm").Type,
                        1f
                    );
                    Gore.NewGore(
                        NPC.GetSource_Death(),
                        NPC.position,
                        NPC.velocity,
                        Mod.Find<ModGore>("CharlesGoreHead").Type,
                        1f
                    );
                    Gore.NewGore(
                        NPC.GetSource_Death(),
                        NPC.position,
                        NPC.velocity,
                        Mod.Find<ModGore>("CharlesGoreLeg").Type,
                        1f
                    );
                }
            }
        }
    }
}
