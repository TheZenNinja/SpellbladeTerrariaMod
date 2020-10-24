using SpellbladeMod.Items.Weapons.Hardmode;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod.NPCs
{
    public class MyGlobalNPC : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
		{
			if (npc.type == NPCID.WallofFlesh)
			{
				if (Main.rand.Next(Main.expertMode ? 2 : 4) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Caliburn>());
			}
		}
		
	}
}
