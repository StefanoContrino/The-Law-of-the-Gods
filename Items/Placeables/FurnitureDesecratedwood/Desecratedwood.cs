using Terraria.ID;
using Terraria.ModLoader;
using TheLawOfTheGods.Tiles.FurnitureDesecratedwood;

namespace TheLawOfTheGods.Items.Placeables.FurnitureDesecratedwood // ← cambia con il namespace del tuo mod
{
    // Riferimento al tile che hai creato nel messaggio precedente

    public class Desecratedwood : ModItem // ← rinomina la classe
    {
        public new string LocalizationCategory => "Items.Placeables";

        public override void SetStaticDefaults()
        {
            // Quantità necessaria per sbloccare la ricerca nel Bestiario/Creativo
            Item.ResearchUnlockCount = 100;

            // Se buttato nella Shimmer, si trasforma in legno vanilla
            ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.Wood;
        }

        public override void SetDefaults()
        {
            // Il blocco è piazzabile e punta al tuo tile
            Item.DefaultToPlaceableTile(ModContent.TileType<DesecratedwoodTile>());
        }

        // Categoria nel menu Creativo
        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.Wood;
        }

        public override void AddRecipes()
        {
            // Esempio: 2 piattaforme → 1 blocco (non de-craftabile)
            // Rimuovi o commenta se non hai ancora le piattaforme
            /*
            CreateRecipe()
                .AddIngredient<YourWoodPlatform>(2)
                .DisableDecraft()
                .Register();
            */

            // Esempio: 4 muri → 1 blocco al banco da lavoro
            // Rimuovi o commenta se non hai ancora i muri
            /*
            CreateRecipe()
                .AddIngredient<YourWoodWallItem>(4)
                .AddTile(TileID.WorkBenches)
                .DisableDecraft()
                .Register();
            */
        }
    }
}