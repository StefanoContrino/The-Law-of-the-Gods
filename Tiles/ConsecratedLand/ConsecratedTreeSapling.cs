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
            // Proprietà di base
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;

            // Sets di Terraria 1.4.4 per i sapling
            TileID.Sets.CommonSapling[Type] = true;
            TileID.Sets.TreeSapling[Type] = true;
            TileID.Sets.SwaysInWindBasic[Type] = true;

            // TileObjectData
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            
            // Definisce l'erba su cui può essere piazzato
            TileObjectData.newTile.AnchorValidTiles = new int[] { ModContent.TileType<ConsecratedGrass>() };

            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.DrawFlipHorizontal = true;
            TileObjectData.newTile.RandomStyleRange = 3;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.LavaDeath = true;

            TileObjectData.addTile(Type);

            AddMapEntry(new Color(100, 200, 100), Language.GetText("Mods.TheLawOfTheGods.Tiles.ConsecratedSapling.DisplayName"));
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects effects)
        {
            if (i % 2 == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
        }

        // tModLoader 1.4.4 invoca Automaticamente questo metodo a caso nella mappa
        public override void RandomUpdate(int i, int j)
        {
            // 1 possibilità su 10 ad ogni RandomUpdate
            if (WorldGen.genRand.NextBool(10))
            {
                Tile tile = Main.tile[i, j];

                // Calcola la Y della parte inferiore (base) del sapling
                int topY = j - (tile.TileFrameY / 18);
                int bottomY = topY + 1;

                bool isPlayerNear = WorldGen.PlayerLOS(i, bottomY);

                // Esegue il tentativo di crescita sulla coordinata inferiore
                bool success = WorldGen.GrowTree(i, bottomY);

                if (success && isPlayerNear)
                {
                    WorldGen.TreeGrowFXCheck(i, bottomY);
                }
            }
        }

        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    }
}