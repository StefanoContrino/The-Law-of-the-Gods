using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheLawOfTheGods.Items.Materials;

namespace TheLawOfTheGods.Items.Weapons.Ranged
{
    public class DeepBow : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 32;
            Item.value = 100;
            Item.rare = ItemRarityID.Blue;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.noMelee = true;
            Item.UseSound = SoundID.Item5;
            Item.useAmmo = AmmoID.Arrow;
            Item.shoot = ProjectileID.WoodenArrowHostile;
            Item.shootSpeed = 8;
            Item.damage = 18;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 3; // Il massimo è 20
            Item.crit = 0; // Il giocatore ha un crit base di 4
        }

        public override void AddRecipes()
        {
            
            Recipe recipe = CreateRecipe();
            
            
            recipe.AddIngredient(ModContent.ItemType<DeepScale>(), 10);
            
            recipe.AddTile(TileID.Anvils);
                   
            recipe.Register();
        }
    }
}