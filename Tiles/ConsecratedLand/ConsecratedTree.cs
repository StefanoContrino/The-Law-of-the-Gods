using Terraria;
using Terraria.ModLoader;
using ReLogic.Content;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.GameContent;

namespace TheLawOfTheGods.Tiles.ConsecratedLand
{
    public class ConsecratedTree : ModTree
    {
        // 1. Dove cresce
        public override void SetStaticDefaults()
        {
            // Inserire blocco di terra personalizzato
            GrowsOnTileId = [ModContent.TileType<ConsecratedGrass>()]; 
        }

        public override TreePaintingSettings TreeShaderSettings 
        { 
            get 
            { 
                // Restituisce le impostazioni vanilla standard (nessun cambio colore speciale)
                return new TreePaintingSettings
                {
                    UseSpecialGroups = false,
                    SpecialGroupMinimalHueValue = 0f,
                    SpecialGroupMaximumHueValue = 0f,
                    SpecialGroupMinimumSaturationValue = 0f,
                    SpecialGroupMaximumSaturationValue = 0f
                };
            } 
        }


        // 2. Quali immagini usa
        public override Asset<Texture2D> GetTexture() 
            => ModContent.Request<Texture2D>("TheLawOfTheGods/Tiles/ConsecratedTree"); // Il sheet 16x16
            
        public override Asset<Texture2D> GetTopTextures() 
            => ModContent.Request<Texture2D>("TheLawOfTheGods/Tiles/ConsecratedTree_Tops"); // La chioma 208x320
            
        public override Asset<Texture2D> GetBranchTextures() 
            => ModContent.Request<Texture2D>("TheLawOfTheGods/Tiles/ConsecratedTree_Branches"); // I rami

        // 3. Che legno cade
       /* public override int DropWood() 
            => ModContent.ItemType<Items.Placeables.FurnitureConsecratedwood.Consecratedwood>();
            */

            public override int DropWood() => ItemID.Wood;

        // 4. Che germoglio usa per crescere
        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<ConsecratedTreeSapling>();
        }
    }
}