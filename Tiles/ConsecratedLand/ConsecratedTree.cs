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
            // Imposta l'erba su cui cresce l'albero
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

        // Metodo fondamentale mancante e richiesto da ModTree (abstract)
        public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
        {
            // Puoi lasciare la logica standard o personalizzarla se necessario
        }

        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<ConsecratedTreeSapling>();
        }

        public override int DropWood() => ItemID.Wood;

        public override Asset<Texture2D> GetTexture() 
            => ModContent.Request<Texture2D>("TheLawOfTheGods/Tiles/ConsecratedLand/ConsecratedTree"); 

        // Restituisce il numero di cime presenti nel file delle texture (vedendone 3 nell'immagine, restituiamo 3)
        public override Asset<Texture2D> GetTopTextures() 
            => ModContent.Request<Texture2D>("TheLawOfTheGods/Tiles/ConsecratedLand/ConsecratedTree_Tops");

        public override Asset<Texture2D> GetBranchTextures() 
            => ModContent.Request<Texture2D>("TheLawOfTheGods/Tiles/ConsecratedLand/ConsecratedTree_Branches");
    }
}