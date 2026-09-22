using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace TheLawOfTheGods.Gores.Trees
{
    public class ConsecratedLeaf : ModGore
    {
        public override void SetStaticDefaults()
        {
            // Imposta la foglia come sicura per la modalità "Child Safety" di Terraria
            ChildSafety.SafeGore[Type] = true;
        }

        public override void OnSpawn(Gore gore, IEntitySource source)
        {
            ChildSafety.SafeGore[gore.type] = true;

            // Dà alla foglia una velocità e una direzione casuali quando appare
            gore.velocity = new Vector2(Main.rand.NextFloat() - 0.5f, Main.rand.NextFloat() * MathHelper.TwoPi);

            // Se lo sprite sheet ha 8 frame per la rotazione/fluttuazione della foglia
            gore.numFrames = 8;
            gore.frame = (byte)Main.rand.Next(8);
            gore.frameCounter = (byte)Main.rand.Next(8);

            // Copia la fisica di movimento delle foglie d'albero vanilla (ID 910 = foglia d'albero standard)
            UpdateType = 910;
        }
    }
}