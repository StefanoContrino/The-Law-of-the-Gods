using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheLawOfTheGods.Items.Materials;

namespace TheLawOfTheGods.Items.Weapons.Melee
{
    public class DeepBroadsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Sblocca l'item nella Journey Mode con 1 unità
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            // Dimensione dell'hitbox dello sprite
            Item.width = 40;
            Item.height = 40;

            // Statistiche di combattimento
            Item.damage = 25;
            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 4f;
            Item.crit = 6; // 6% di probabilità di colpo critico

            // Tempi e animazione di attacco
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Swing; // Attacco a fendente classico
            Item.autoReuse = true; // Auto Swing: Sì
            Item.UseSound = SoundID.Item1;

            // Valore e Rarità
            Item.rare = ItemRarityID.Green; // Rarità Verde
            Item.value = Item.sellPrice(silver: 75); // Valore di vendita: 75 d'argento
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<DeepScale>(), 8) // Richiede 8 Deep Scale
                .AddTile(TileID.Anvils) // Richiede un'Anudine (Anvil) qualsiasi
                .Register();
        }
    }
}