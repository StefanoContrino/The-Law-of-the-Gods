using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TheLawOfTheGods.Tiles.ConsecratedLand
{
    public class ConsecratedTreeSapling : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;

            TileID.Sets.CommonSapling[Type] = true;
            TileID.Sets.TreeSapling[Type] = true;
            TileID.Sets.SwaysInWindBasic[Type] = true;

            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<ConsecratedGrass>()];

            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinateHeights = [16, 18];
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.DrawFlipHorizontal = true;
            TileObjectData.newTile.RandomStyleRange = 3;
            TileObjectData.newTile.StyleMultiplier = 3; // Fondamentale se hai più stili di sapling/albero
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.LavaDeath = true;

            TileObjectData.addTile(Type);

            // Usa MapObject.Sapling per sicurezza o la tua chiave hjson
            AddMapEntry(new Color(100, 200, 100), Language.GetText("MapObject.Sapling"));
            
            AdjTiles = [TileID.Saplings];
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects effects)
        {
            // Modificato leggermente per seguire lo standard di alternanza dell'ExampleMod
            if (i % 2 == 0)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
        }

        public override void RandomUpdate(int i, int j)
        {
            // Controllo casuale per la crescita (1 volta su 20 tick di aggiornamento casuale)
            if (!WorldGen.genRand.NextBool(20))
            {
                return;
            }

            // Metodo pulito e sicuro preso dall'ExampleMod
            bool growSuccess = WorldGen.GrowTree(i, j);
            bool isPlayerNear = WorldGen.PlayerLOS(i, j);

            if (growSuccess && isPlayerNear)
            {
                WorldGen.TreeGrowFXCheck(i, j);
            }
        }

        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    }
}