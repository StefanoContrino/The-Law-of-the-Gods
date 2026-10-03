using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Metadata;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheLawOfTheGods.Tiles.ConsecratedLand
{
    public class ConsecratedGrass : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][TileID.Dirt] = true;
            Main.tileMerge[TileID.Dirt][Type] = true;
            TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Grass"]);
            

            RegisterItemDrop(ItemID.DirtBlock);
            AddMapEntry(new Color(133, 109, 140));

            TileID.Sets.Grass[Type] = true;
            TileID.Sets.Conversion.Grass[Type] = true;

            // Grass framing
            TileID.Sets.NeedsGrassFraming[Type] = true;
            TileID.Sets.NeedsGrassFramingDirt[Type] = TileID.Dirt;
            TileID.Sets.CanBeDugByShovel[Type] = true;
        }

        int animationFrameWidth = 288;

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (fail && !effectOnly)
            {
                Main.tile[i, j].TileType = TileID.Dirt;
            }
        }        

        public override bool IsTileBiomeSightable(int i, int j, ref Color sightColor)
        {
            sightColor = new Color(100, 200, 100);
            return true;
        }

        public override void RandomUpdate(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            Tile up = Main.tile[i, j - 1];
            Tile up2 = Main.tile[i, j - 2];
        }
    }
}