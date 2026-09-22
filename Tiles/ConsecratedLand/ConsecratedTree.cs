using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using TheLawOfTheGods.Tiles.ConsecratedLand; // Assicurati che i namespace siano corretti

namespace TheLawOfTheGods.Tiles.ConsecratedLand
{
    public class ConsecratedTree : ModTree
    {
        private Asset<Texture2D> texture;
        private Asset<Texture2D> branchesTexture;
        private Asset<Texture2D> topsTexture;

        public override void SetStaticDefaults()
        {
            // Imposta l'erba su cui cresce l'albero
            GrowsOnTileId = [ModContent.TileType<ConsecratedGrass>()];

            // Caricamento corretto delle texture in SetStaticDefaults
            texture = ModContent.Request<Texture2D>("TheLawOfTheGods/Tiles/ConsecratedLand/ConsecratedTree");
            branchesTexture = ModContent.Request<Texture2D>("TheLawOfTheGods/Tiles/ConsecratedLand/ConsecratedTree_Branches");
            topsTexture = ModContent.Request<Texture2D>("TheLawOfTheGods/Tiles/ConsecratedLand/ConsecratedTree_Tops");
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

        public override void SetTreeFoliageSettings(int i, int j, Tile tile, int xoffset, ref int treeFrame, int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight) {
			// This is where fancy code could go, but let's save that for an advanced example
		}


        public override int DropWood() => ItemID.Wood;

        // Restituiscono le texture salvate in precedenza
        public override Asset<Texture2D> GetTexture() => texture;

        public override Asset<Texture2D> GetTopTextures() => topsTexture;

        public override Asset<Texture2D> GetBranchTextures() => branchesTexture;
    }
}