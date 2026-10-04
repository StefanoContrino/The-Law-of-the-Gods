using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace TheLawOfTheGods.NPCs.DesecratedLand
{
	public class DesecratedZombie : ModNPC
	{
		public override void SetStaticDefaults() {
			Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Zombie];

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers() {
				Velocity = 1f
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
		}

		public override void SetDefaults() {
			NPC.width = 18;
			NPC.height = 40;
			NPC.damage = 14;
			NPC.defense = 6;
			NPC.lifeMax = 200;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = 60f;
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = NPCAIStyleID.Fighter;

			AIType = NPCID.Zombie;
			AnimationType = NPCID.Zombie;
			Banner = Item.NPCtoBanner(NPCID.Zombie);
			BannerItem = Item.BannerToItem(Banner);
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange([
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
				new FlavorTextBestiaryInfoElement("Uno zombie personalizzato per la mod."),
			]);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			// Spawna di notte in superficie, evitando che ce ne siano troppi contemporaneamente
			if (spawnInfo.Player.ZoneOverworldHeight && !Main.dayTime && !NPC.AnyNPCs(Type)) {
				return SpawnCondition.OverworldNightMonster.Chance * 0.1f;
			}

			return 0f;
		}
	}
}