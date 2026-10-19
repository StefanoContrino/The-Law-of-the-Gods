using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Metadata;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheLawOfTheGods.Tiles.FurnitureDesecratedwood
{
    public class DesecratedTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            // Proprietà fisiche del blocco
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMergeDirt[Type] = false;

            // Registra il materiale come "Wood"
            TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Wood"]);

            // Suono quando viene colpito
            HitSound = SoundID.Dig;

            // Colore sulla mappa
            AddMapEntry(new Color(218, 169, 97));

            // Altezza del frame per l'animazione
            // (imposta a 0 se non si vuole animazione)
            AnimationFrameHeight = 270;
        }

        // Polvere generata quando il blocco viene colpito
        public override bool CreateDust(int i, int j, ref int type)
        {
            Dust.NewDust(
                new Vector2(i, j) * 16f,
                16, 16,
                DustID.WoodFurniture,
                0f, 0f, 1,
                new Color(255, 255, 255),
                1f
            );
            return false; // false = non generare la polvere di default
        }

        // Animazione del tile (dondolio dell'albero)
        public override void AnimateIndividualTile(int type, int i, int j,
            ref int frameXOffset, ref int frameYOffset)
        {
            int xPos = i % 6;
            int yPos = j % 3;
            frameXOffset = xPos * 288;
            frameYOffset = yPos * AnimationFrameHeight;
        }
    }
}