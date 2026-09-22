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
        public override void SetStaticDefaults()
        {
            // Imposta l'erba su cui cresce l'albero
            GrowsOnTileId = new int[1] { ModContent.TileType<ConsecratedGrass>() };
        }

        public override TreePaintingSettings TreeShaderSettings => new TreePaintingSettings
        {
            UseSpecialGroups = true,
            SpecialGroupMinimalHueValue = 11f / 72f,
            SpecialGroupMaximumHueValue = 0.25f,
            SpecialGroupMinimumSaturationValue = 0.88f,
            SpecialGroupMaximumSaturationValue = 1f
        };


        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<ConsecratedTreeSapling>();
        }

        // public override void SetTreeFoliageSettings(int i, int j, Tile tile, int xoffset, ref int treeFrame, int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight) {
			
		// }
        public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
        {
            //What does this code do?
            //treeFrame = (i + j * j) % 3;
        }
        public override int DropWood() => ItemID.Wood;
        public override int CreateDust() => DustID.Grass; // Esempio per usare la polvere dell'erba vanilla

        // Restituiscono le texture salvate in precedenza
        public override Asset<Texture2D> GetTexture() => ModContent.Request<Texture2D>("TheLawOfTheGods/Tiles/ConsecratedLand/ConsecratedTree");

        public override Asset<Texture2D> GetTopTextures() => ModContent.Request<Texture2D>("TheLawOfTheGods/Tiles/ConsecratedLand/ConsecratedTree_Tops");

        public override Asset<Texture2D> GetBranchTextures() => ModContent.Request<Texture2D>("TheLawOfTheGods/Tiles/ConsecratedLand/ConsecratedTree_Branches");
    }
}