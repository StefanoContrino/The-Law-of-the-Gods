using Terraria;
using Terraria.ModLoader;

namespace TheLawOfTheGods.Content.Items.Materials
{
    public class DeepScale : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 25;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 24;

            Item.maxStack = 9999;
            Item.value = Item.buyPrice(silver: 50);

            Item.rare = Terraria.ID.ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            // Eventuali ricette future
        }
    }
}