using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheLawOfTheGods.Tiles.ConsecratedLand
{
    public class ConsecratedTree : ModTree
    {
        public override void SetStaticDefaults()
        {
            GrowsOnTileId = new int[] { ModContent.TileType<ConsecratedGrass>() };
        }

        public override TreePaintingSettings TreeShaderSettings => new TreePaintingSettings
        {
            UseSpecialGroups = false,
            SpecialGroupMinimalHueValue = 0f,
            SpecialGroupMaximumHueValue = 0f,
            SpecialGroupMinimumSaturationValue = 0f,
            SpecialGroupMaximumSaturationValue = 0f
        };

        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<ConsecratedTreeSapling>();
        }

        public override int DropWood() => ItemID.Wood;

        public override Asset<Texture2D> GetTexture() 
            => ModContent.Request<Texture2D>("TheLawOfTheGods/Tiles/ConsecratedLand/ConsecratedTree"); 

        public override Asset<Texture2D> GetTopTextures() 
            => ModContent.Request<Texture2D>("TheLawOfTheGods/Tiles/ConsecratedLand/ConsecratedTree_Tops");

        public override Asset<Texture2D> GetBranchTextures() 
            => ModContent.Request<Texture2D>("TheLawOfTheGods/Tiles/ConsecratedLand/ConsecratedTree_Branches");
    }
}