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
        public override void SetStaticDefaults()
        {
            // CRUCIALE: Dice all'albero su quale blocco può essere generato
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

        // Ritorna l'ID del germoglio associato a questo albero
        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<ConsecratedTreeSapling>();
        }

        public override int DropWood() => ItemID.Wood;

        // TEXTURE: Se uno di questi file non esiste o ha il percorso sbagliato, GrowTree fallisce silenziosamente!
        public override Asset<Texture2D> GetTexture() 
            => ModContent.Request<Texture2D>("TheLawOfTheGods/Tiles/ConsecratedLand/ConsecratedTree"); 

        public override Asset<Texture2D> GetTopTextures() 
            => ModContent.Request<Texture2D>("TheLawOfTheGods/Tiles/ConsecratedLand/ConsecratedTree_Tops");

        public override Asset<Texture2D> GetBranchTextures() 
            => ModContent.Request<Texture2D>("TheLawOfTheGods/Tiles/ConsecratedLand/ConsecratedTree_Branches");
    }
}