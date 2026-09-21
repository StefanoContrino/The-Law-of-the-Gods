using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheLawOfTheGods.Tiles.ConsecratedLand;

namespace TheLawOfTheGods.Items.Placeables.FurnitureConsecratedwood
{
    public class Consecratedwood : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Sblocca l'item nella Journey Mode con 100 pezzi
            Item.ResearchUnlockCount = 100;

            // Trasformazione nello Shimmer (converte in Legno Vanilla)
            ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.Wood;
        }

        public override void SetDefaults()
        {
            // Imposta automaticamente l'item come blocco piazzabile
            // collegandolo al blocco ConsecratedWoodTile
            Item.DefaultToPlaceableTile(ModContent.TileType<ConsecratedWoodTile>());
        }

        /* 
        // per le ricette:
        public override void AddRecipes()
        {
            // CreateRecipe()
            //     .AddIngredient<ConsecratedWoodPlatform>(2)
            //     .DisableDecraft()
            //     .Register();
        }
        */
    }
}