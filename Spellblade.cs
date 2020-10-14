using Terraria.ModLoader;

namespace Spellblade
{
	public class Spellblade : Mod
	{
        public static Spellblade instance;

        public override void Load()
        {
            instance = this;
        }
        public override void Unload()
        {
            instance = null;
        }
    }
}