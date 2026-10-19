// ============================================================================
//  DesecratedTile.cs – Tile "legno custom" piazzabile (tModLoader 1.4.4+)
//  Percorso suggerito: Content/Tiles/DesecratedTile.cs
//  Texture: Content/Tiles/DesecratedTile.png
//  Sheet: 15 righe x 16 colonne di frame 16x16, stride 18px (file 288x270px).
//  Il merge con la terra usa gli sprite extra previsti dal "Template 2"
//  (quello che fonde con la dirt) della guida Basic Tile del wiki tModLoader.
// ============================================================================

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheLawOfTheGods.Items.Placeables.FurnitureDesecratedwood;

namespace TheLawOfTheGods.Tiles.FurnitureDesecratedwood
{
    public class DesecratedwoodTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            // Tile "terrain" 1x1, come terra/pietra/legno vanilla:
            // si ricollega da solo ai blocchi dello stesso tipo adiacenti.
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileMergeDirt[Type] = true; // <-- FUSIONE CON LA TERRA (dirt)

            // IMPORTANTE: NESSUN TileObjectData qui!
            // Con TileObjectData il tile diventa "FrameImportant" (tipo mobile):
            // - il frame resta bloccato -> non si collega ai vicini né alla terra
            // - compare la preview fantasma di piazzamento
            // Da tile terrain (senza TileObjectData) la preview NON esiste,
            // e il gioco ricalcola il frame in automatico sui vicini.

            // Drop: l'item che il tile rilascia quando distrutto
            RegisterItemDrop(ModContent.ItemType<Desecratedwood>());

            // Colore e nome sulla mappa
            AddMapEntry(new Color(151, 107, 75), CreateMapEntryName());
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3; // quantità di polvere allo scavo
        }
    }
}