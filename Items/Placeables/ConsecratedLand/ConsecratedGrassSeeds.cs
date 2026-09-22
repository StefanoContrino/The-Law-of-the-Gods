using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TheLawOfTheGods.Tiles.ConsecratedLand;

namespace TheLawOfTheGods.Items.Placeables.ConsecratedLand
{
    public class ConsecratedGrassSeeds : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Quanti pezzi servono per sbloccarlo nella Journey Mode (25 è lo standard per i semi)
            Item.ResearchUnlockCount = 25;
        }

        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 14;
            Item.maxStack = Item.CommonMaxStack; // Fino a 9999 pezzi
            
            // Impostazioni d'uso (simile ai semi vanilla)
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            
            Item.rare = ItemRarityID.White;
            Item.value = Item.buyPrice(copper: 20); // Prezzo di vendita/acquisto base
        }

        // Logica per trasformare la terra in ConsecratedGrass quando si clicca
        public override bool? UseItem(Player player)
        {
            // Coordinate del tile su cui il giocatore sta cliccando col mouse
            int i = Player.tileTargetX;
            int j = Player.tileTargetY;

            Tile tile = Main.tile[i, j];

            // Verifica se il blocco cliccato è attivo ed è Terra Vanilla (Dirt)
            if (tile.HasTile && tile.TileType == TileID.Dirt)
            {
                // Trasforma il blocco in ConsecratedGrass
                tile.TileType = (ushort)ModContent.TileType<ConsecratedGrass>();
                
                // Suono del posizionamento del seme e aggiornamento grafico dei blocchi adiacenti
                SoundEngine.PlaySound(SoundID.Dig, new Vector2(i * 16, j * 16));
                WorldGen.SquareTileFrame(i, j, true);

                // In multiplayer, invia il pacchetto di rete per sincronizzare il cambio blocco con gli altri giocatori
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    NetMessage.SendTileSquare(-1, i, j, 1);
                }

                return true; // Consuma l'item
            }

            return false; // Non consuma l'item se non clicchi sulla terra
        }

        /*
        // Se vuoi aggiungere una ricetta per sintetizzare i semi (es. da una ghianda o da un fiore)
        public override void AddRecipes()
        {
            // CreateRecipe(5)
            //     .AddIngredient(ItemID.Acorn)
            //     .AddTile(TileID.WorkBenches)
            //     .Register();
        }
        */
    }
}