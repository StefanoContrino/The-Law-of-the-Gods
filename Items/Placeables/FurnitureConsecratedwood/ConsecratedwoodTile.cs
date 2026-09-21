using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Metadata;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheLawOfTheGods.Tiles.ConsecratedLand
{
    public class ConsecratedWoodTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            // 1. Proprietà fisiche del Tile
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            
            // Assegna il materiale "Legno" per i suoni di camminata/interazione nativi
            TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Wood"]);

            // 2. Suono di rottura/colpo col piccone e tipo di polvere
            HitSound = SoundID.Dig;
            DustType = DustID.WoodFurniture;

            // 3. Item droppato alla rottura del blocco
            RegisterItemDrop(ModContent.ItemType<Items.Placeables.FurnitureConsecratedwood.Consecratedwood>());

            // 4. Colore sulla Minimappa
            AddMapEntry(new Color(218, 169, 97)); // Modifica le coordinate RGB con il colore del legno

            // 5. Sets di Terraria per i blocchi da costruzione in legno
            TileID.Sets.GeneralPlacementTiles[Type] = true;
            TileID.Sets.CanBeDugByShovel[Type] = false;
        }
    }
}