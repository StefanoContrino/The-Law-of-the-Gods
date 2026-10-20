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
            
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileMergeDirt[Type] = true;

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