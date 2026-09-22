using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheLawOfTheGods.Tiles.ConsecratedLand
{
    public class ConsecratedTree : ModTree
    {
        private Asset<Texture2D> texture;
        private Asset<Texture2D> branchesTexture;
        private Asset<Texture2D> topsTexture;

        public override void SetStaticDefaults()
        {
            // Imposta l'erba su cui cresce l'albero
            GrowsOnTileId = [ModContent.TileType<ConsecratedGrass>()];

            // Caricamento corretto delle texture in SetStaticDefaults
            texture = ModContent.Request<Texture2D>("TheLawOfTheGods/Tiles/ConsecratedLand/ConsecratedTree");
            branchesTexture = ModContent.Request<Texture2D>("TheLawOfTheGods/Tiles/ConsecratedLand/ConsecratedTree_Branches");
            topsTexture = ModContent.Request<Texture2D>("TheLawOfTheGods/Tiles/ConsecratedLand/ConsecratedTree_Tops");
        }

        public override TreePaintingSettings TreeShaderSettings => new TreePaintingSettings
        {
            UseSpecialGroups = false,
            SpecialGroupMinimalHueValue = 0f,
            SpecialGroupMaximumHueValue = 0f,
            SpecialGroupMinimumSaturationValue = 0f,
            SpecialGroupMaximumSaturationValue = 0f
        };

        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<ConsecratedTreeSapling>();
        }

        public override void SetTreeFoliageSettings(int i, int j, Tile tile, int xoffset, ref int treeFrame, int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight) {
			
		}

        public override int TreeLeaf() => ModContent.GoreType<Gores.Trees.ConsecratedLeaf>();
        public override int DropWood() => ItemID.Wood;

        public override bool Shake(int x, int y, ref bool createLeaves)
        {
            int randAmt = Main.rand.Next(1, 3);
            
            if (Main.getGoodWorld && Main.rand.NextBool(15))
            {
                Projectile.NewProjectile(new EntitySource_ShakeTree(x, y), x * 16, y * 16, Main.rand.NextFloat(-100f, 100f) * 0.002f, 0f, ProjectileID.Bomb, 0, 0f, Player.FindClosest(new Vector2(x * 16, y * 16), 16, 16));
            }
            else if (Main.rand.NextBool(7))
            {
                createLeaves = true;
                Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), x * 16, y * 16, 16, 16, ItemID.Acorn, randAmt);
            }
            else if (Main.rand.NextBool(35) && Main.halloween)
            {
                createLeaves = true;
                Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), x * 16, y * 16, 16, 16, ItemID.RottenEgg, randAmt);
            }
            else if (Main.rand.NextBool(12))
            {
                createLeaves = true;
                // Sostituisci DropWood() con il legno vanilla che preferisci, es. ItemID.Wood
                Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), x * 16, y * 16, 16, 16, ItemID.Wood, Main.rand.Next(1, 4));
            }
            else if (Main.rand.NextBool(20))
            {
                createLeaves = true;
                int coin = ItemID.CopperCoin;
                int amount = Main.rand.Next(50, 100);
                if (Main.rand.NextBool(30))
                {
                    coin = ItemID.GoldCoin;
                    amount = 1;
                    if (Main.rand.NextBool(5))
                        amount++;

                    if (Main.rand.NextBool(10))
                        amount++;
                }
                else if (Main.rand.NextBool(10))
                {
                    coin = ItemID.SilverCoin;
                    amount = Main.rand.Next(1, 21);
                    if (Main.rand.NextBool(3))
                        amount += Main.rand.Next(1, 21);

                    if (Main.rand.NextBool(4))
                        amount += Main.rand.Next(1, 21);
                }

                Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), x * 16, y * 16, 16, 16, coin, amount);
            }
            else if (Main.rand.NextBool(20))
            {
                createLeaves = true;
                int type = NPCID.EnchantedNightcrawler; // Creatura vanilla
                NPC.NewNPC(new EntitySource_ShakeTree(x, y), x * 16, y * 16, type);
            }
            else if (Main.rand.NextBool(15))
            {
                createLeaves = true;
                int type = ItemID.FallenStar;
                Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), new Vector2(x, y) * 16, type, randAmt);
            }
    
            return false;
        }

        // Restituiscono le texture salvate in precedenza
        public override Asset<Texture2D> GetTexture() => texture;

        public override Asset<Texture2D> GetTopTextures() => topsTexture;

        public override Asset<Texture2D> GetBranchTextures() => branchesTexture;
    }
}