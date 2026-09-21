using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Enums;
using Terraria.Localization;

namespace TheLawOfTheGods.Tiles.ConsecratedLand
{
    public class ConsecratedTreeSapling : ModTile
    {
        public override void SetStaticDefaults()
        {
            // 1. Proprietà Fondamentali del Tile
            Main.tileFrameImportant[Type] = true; // Importante: il germoglio ha animazione/frame (crescita)
            Main.tileNoAttach[Type] = true;       // Non puoi attaccarci torce o quadri
            Main.tileLavaDeath[Type] = true;      // Muore se tocca la lava
            
            // 2. Dichiarazione ufficiale a Terraria
            TileID.Sets.CommonSapling[Type] = true; 
            TileID.Sets.TreeSapling[Type] = true; 
            TileID.Sets.SwaysInWindBasic[Type] = true; // Oscilla col vento

            // 3. Configurazione della Hitbox e Posizione (TileObjectData)
            // Un germoglio occupa 1 tile di larghezza e 2 di altezza (16x32 pixel)
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 2;
            
            // L'origine (0, 1) significa che il punto di ancoraggio è in basso al centro
            TileObjectData.newTile.Origin = new Point16(0, 1);
            
            // AnchorBottom: Deve essere appoggiato su un blocco solido
            // AnchorType.SolidTile significa "blocco solido qualsiasi"
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            
            // AnchorValidTiles: SU QUALI BLOCCHI SPECIFICI può crescere?
            // Qui collego il germoglio all'erba sacra (ConsecratedGrass)
            TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<ConsecratedGrass>()];

            // Configurazione grafica (Coordinate nello sprite sheet)
            // Il germoglio è largo 16px. Le altezze sono 16px per il primo frame e 18px per il secondo (leggero overlap)
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinateHeights = [16, 18];
            TileObjectData.newTile.CoordinatePadding = 2; // Spazio tra i frame nello sheet

            // Stile e Disegno
            TileObjectData.newTile.StyleHorizontal = true; // I frame di stile (crescita) sono in orizzontale nello sheet
            TileObjectData.newTile.DrawFlipHorizontal = true; // Può essere specchiato orizzontalmente
            TileObjectData.newTile.RandomStyleRange = 3; // Ci sono 3 stili di germoglio (0, 1, 2) nello sheet
            
            // Liquidi: Il germoglio non può essere piazzato sott'acqua
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.LavaDeath = true;

            // Registra il tile con queste impostazioni
            TileObjectData.addTile(Type);

            // 4. Nome nella Mappa e Polvere
            // Usa il nome localizzato vanilla per "Sapling" oppure uno personalizzato (Consecrated Sapling)
            // Sostituisci la riga 62 con questa:
            // Usa la chiave che corrisponde al percorso nel file hjson
            AddMapEntry(new Color(100, 200, 100), Language.GetText("Mods.TheLawOfTheGods.Tiles.ConsecratedSapling.DisplayName"));
            
        }

        // 5. Effetto Visivo: Specchiare il germoglio
        // Questo fa sì che i germogli vicini guardino in direzioni opposte, rendendo la foresta più naturale
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects effects)
        {
            if (i % 2 == 1) // Se la coordinata X è dispari...
            {
                effects = SpriteEffects.FlipHorizontally; // ...specchia l'immagine
            }
        }

        // 6. Logica di Crescita (RandomUpdate)
        // Viene chiamato casualmente dal gioco. Tenta di far crescere l'albero.
        public override void RandomUpdate(int i, int j)
        {
            // 1 su 20 possibilità ad ogni aggiornamento
            if (WorldGen.genRand.NextBool(20))
            {
                // Trova la parte IN BASSO del germoglio (dove tocca l'erba)
                Tile tile = Main.tile[i, j];
                int topY = j - (tile.TileFrameY / 18); // Trova il tile superiore
                int bottomY = topY + 1;               // Il tile inferiore è subito sotto

                // Verifica se un giocatore è vicino per mostrare le particelle
                bool isPlayerNear = WorldGen.PlayerLOS(i, bottomY);

                // Tenta la crescita chiamando la BASE del germoglio
                bool success = WorldGen.GrowTree(i, bottomY);

                // Se è cresciuto, fa le particelle visive
                if (success && isPlayerNear)
                {
                    WorldGen.TreeGrowFXCheck(i, bottomY);
                }
            }
        }
        
        // 7. Polvere alla rottura (Opzionale)
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            // Se fallisce (fail=true), 1 polvere. Se riesce, 3 polveri.
            num = fail ? 1 : 3;
        }
    }
}