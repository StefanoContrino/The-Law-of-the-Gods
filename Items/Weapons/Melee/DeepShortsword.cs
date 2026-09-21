using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheLawOfTheGods.Items.Materials;

namespace TheLawOfTheGods.Items.Weapons.Melee
{
    public class DeepShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            // Statistiche di combattimento
            Item.damage = 22;
            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 3f;
            Item.crit = 6;

            // Tempi e animazione per la stoccata classica
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.useStyle = ItemUseStyleID.Thrust; // Stoccata/Affondo classico senza proiettile
            Item.autoReuse = false; // Auto Swing: No
            Item.UseSound = SoundID.Item1;

            // Valore e Rarità
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(silver: 60);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<DeepScale>(6)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}