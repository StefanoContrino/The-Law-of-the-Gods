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
            // 1. Proprietà fisiche di base
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileBrick[Type] = true;
            TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Grass"]);

            // 2. Unione dei bordi (Merge) con la Terra Vanilla
            Main.tileMerge[Type][TileID.Dirt] = true;
            Main.tileMerge[TileID.Dirt][Type] = true;

            // 3. Polvere, Drop e Mappa
            DustType = DustID.Grass; 
            RegisterItemDrop(ItemID.DirtBlock); // Scavando l'erba ottieni il blocco di terra vanilla

            AddMapEntry(new Color(100, 200, 100)); // Colore sulla minimappa

            // 4. Sets di Terraria per la gestione dell'Erba
            TileID.Sets.Grass[Type] = true;
            TileID.Sets.Conversion.Grass[Type] = true;
            TileID.Sets.NeedsGrassFraming[Type] = true;
            TileID.Sets.NeedsGrassFramingDirt[Type] = TileID.Dirt; // Si collega alla terra vanilla
            TileID.Sets.CanBeDugByShovel[Type] = true;
        }

        // 5. Quantità di polvere generata alla rottura
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        // 6. Trasformazione in Terra Vanilla al primo colpo di piccone
        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (fail && !effectOnly)
            {
                Main.tile[i, j].TileType = TileID.Dirt;
            }
        }

        // 7. Supporto per la Pozione Biome Sight
        public override bool IsTileBiomeSightable(int i, int j, ref Color sightColor)
        {
            sightColor = new Color(100, 200, 100);
            return true;
        }
    }
}