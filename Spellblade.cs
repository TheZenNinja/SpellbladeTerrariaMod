using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using Spellblade.UI;

namespace Spellblade
{
	public class Spellblade : Mod
	{
        public static readonly Color classTextColor = new Color(0, 100, 255);
        public static readonly string classTitleText = "-Spellblade Class-";

        public static ModHotKey WeaponArtKey;

        public static Spellblade instance;

        private UserInterface _arcaneBarUserInterface;

        internal ArcaneResourceUI ArcaneBar;
        public override void Load()
        {
            Logger.InfoFormat("{0} example logging", Name);
            instance = this;

            WeaponArtKey = RegisterHotKey("Weapon Art", "V");

            if (!Main.dedServ)
            {
                ArcaneBar = new ArcaneResourceUI();
                _arcaneBarUserInterface = new UserInterface();
                _arcaneBarUserInterface.SetState(ArcaneBar);
            }
        }
        public override void Unload()
        {
            instance = null;
            WeaponArtKey = null;
        }
        public override void UpdateUI(GameTime gameTime)
        {
            _arcaneBarUserInterface?.Update(gameTime);
        }
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
			if (resourceBarIndex != -1)
			{
				layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
					"Spellblade: Arcane Resource Bar",
					delegate {
						_arcaneBarUserInterface.Draw(Main.spriteBatch, new GameTime());
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}
	}
}