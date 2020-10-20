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
using SpellbladeMod.UI;
using SpellbladeMod.Items.Weapons.Metal;

namespace SpellbladeMod
{
	public enum ModMessageType : byte
	{
		SyncPlayer,
		AltFuncUpdate,
		ForceAltUse
	}
	public class SpellbladeMod : Mod
	{
		public static readonly Color classTextColor = new Color(0, 100, 255);
		public static readonly string classTitleText = "-Spellblade Class-";

		public static ModHotKey WeaponArtKey;

		public static SpellbladeMod instance;

		private UserInterface _arcaneBarUserInterface;

		internal ArcaneResourceUI ArcaneBar;
		public override void Load()
		{
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

		public override void HandlePacket(BinaryReader reader, int whoAmI)
		{
			ModMessageType msgType = (ModMessageType)reader.ReadByte();
			switch (msgType)
			{
				case ModMessageType.SyncPlayer:
					byte playernumber = reader.ReadByte();
					SpellbladePlayer player = Main.player[playernumber].GetModPlayer<SpellbladePlayer>();
					int current = reader.ReadInt32();
					int max = reader.ReadInt32();
					int max2 = reader.ReadInt32();
					player.arcanePowerCurrent = current;
					player.arcanePowerMax = max;
					player.arcanePowerMax2 = max2;
					player.altWeaponFunc = reader.ReadBoolean();
					// SyncPlayer will be called automatically, so there is no need to forward this data to other clients.
					break;
				case ModMessageType.AltFuncUpdate:
					playernumber = reader.ReadByte();
					player = Main.player[playernumber].GetModPlayer<SpellbladePlayer>();
					player.altWeaponFunc = reader.ReadBoolean();
					if (Main.netMode == NetmodeID.Server)
					{
						var packet = GetPacket();
						packet.Write((byte)ModMessageType.AltFuncUpdate);
						packet.Write(playernumber);
						packet.Write(player.altWeaponFunc);
						packet.Send(-1, playernumber);
					}
					break;
				case ModMessageType.ForceAltUse:
					playernumber = reader.ReadByte();
					player = Main.player[playernumber].GetModPlayer<SpellbladePlayer>();
					player.ForceAltUse();
					if (Main.netMode == NetmodeID.Server)
					{
						var packet = GetPacket();
						packet.Write((byte)ModMessageType.ForceAltUse);
						packet.Write(playernumber);
						packet.Send(-1, playernumber);
					}
					break;
				default:
					Logger.WarnFormat("ExampleMod: Unknown Message type: {0}", msgType);
					break;
			}
		}

		/// <summary>
		/// From the developer of WeaponOut
		/// Registers a glowmask texture to the game's array, and returns that value.
		/// The file should be located under Glow/ItemName_Glow. Make sure to register
		/// the returned value under item.glowMask in SetDefaults.
		/// </summary>
		/// <param name="modItem">The mod item to register. </param>
		/// <returns></returns>
		public static short SetStaticDefaultsGlowMask(ModItem modItem)
		{
			if (!Main.dedServ)
			{
				Texture2D[] glowMasks = new Texture2D[Main.glowMaskTexture.Length + 1];
				for (int i = 0; i < Main.glowMaskTexture.Length; i++)
				{
					glowMasks[i] = Main.glowMaskTexture[i];
				}
				glowMasks[glowMasks.Length - 1] = instance.GetTexture("Glow/" + modItem.GetType().Name + "_Glow");
				Main.glowMaskTexture = glowMasks;
				return (short)(glowMasks.Length - 1);
			}
			else return 0;
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
					delegate
					{
						_arcaneBarUserInterface.Draw(Main.spriteBatch, new GameTime());
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}
		public override void AddRecipes()
		{
			RecipeManager.AddConversionRecipies(this);
			RecipeManager.AddIngredientRecipies(this);
			RecipeManager.AddWoodenRecipies(this);
			RecipeManager.AddMetalRecipies(this);
		}
	}
}