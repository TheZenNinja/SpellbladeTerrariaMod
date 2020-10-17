using Microsoft.Xna.Framework;
using SpellbladeMod.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod
{
	public class SpellbladePlayer : ModPlayer
    {
		public static SpellbladePlayer ModPlayer(Player player)
		{
			return player.GetModPlayer<SpellbladePlayer>();
		}

		// Here we include a custom resource, similar to mana or health.
		// Creating some variables to define the current value of our example resource as well as the current maximum value. We also include a temporary max value, as well as some variables to handle the natural regeneration of this resource.
		public int arcanePowerCurrent;
		public const int DefaulArcanePower = 5;
		public int arcanePowerMax;
		public int arcanePowerMax2;

		public int arcanePowerGainRate;
		public bool canGainArcane;
		public float arcaneGainCooldownMulti = 1;
		internal int arcaneGainCooldownTimer = 0;

		public bool altWeaponFunc = false;


		//public static readonly Color HealExampleResource = new Color(187, 91, 201); // We can use this for CombatText, if you create an item that replenishes exampleResourceCurrent.

		/*
		In order to make the Example Resource example straightforward, several things have been left out that would be needed for a fully functional resource similar to mana and health. 
		Here are additional things you might need to implement if you intend to make a custom resource:
		- Multiplayer Syncing: The current example doesn't require MP code, but pretty much any additional functionality will require this. ModPlayer.SendClientChanges and clientClone will be necessary, as well as SyncPlayer if you allow the user to increase exampleResourceMax.
		- Save/Load and increased max resource: You'll need to implement Save/Load to remember increases to your exampleResourceMax cap.
		- Resouce replenishment item: Use GlobalNPC.NPCLoot to drop the item. ModItem.OnPickup and ModItem.ItemSpace will allow it to behave like Mana Star or Heart. Use code similar to Player.HealEffect to spawn (and sync) a colored number suitable to your resource.
		*/

		public override void Initialize()
		{
			arcanePowerMax = DefaulArcanePower;
		}

		public override void ResetEffects()
		{
			ResetVariables();
		}

		public override void UpdateDead()
		{
			ResetVariables();
		}

		private void ResetVariables()
		{
			canGainArcane = false;
			arcanePowerGainRate = 1;
			arcaneGainCooldownMulti = 1f;
			arcanePowerMax2 = arcanePowerMax;
		}

		public override void PostUpdateMiscEffects()
		{
			UpdateResource();
		}

		// Lets do all our logic for the custom resource here, such as limiting it, increasing it and so on.
		private void UpdateResource()
		{
			// For our resource lets make it regen slowly over time to keep it simple, let's use exampleResourceRegenTimer to count up to whatever value we want, then increase currentResource.
			if (!canGainArcane)
			{
				arcaneGainCooldownTimer++; //Increase it by 60 per second, or 1 per tick.

				// A simple timer that goes up to 1 seconds, increases the exampleResourceCurrent by 1 and then resets back to 0.
				if (arcaneGainCooldownTimer > 60 * (2-arcaneGainCooldownMulti))
					canGainArcane = true;
			}

			arcanePowerCurrent = Utils.Clamp(arcanePowerCurrent, 0, arcanePowerMax2);
		}
		public override void clientClone(ModPlayer clientClone)
		{
			SpellbladePlayer clone = clientClone as SpellbladePlayer;
			// Here we would make a backup clone of values that are only correct on the local players Player instance.
			// Some examples would be RPG stats from a GUI, Hotkey states, and Extra Item Slots
			clone.arcanePowerCurrent = arcanePowerCurrent;
			clone.arcanePowerMax = arcanePowerMax;
			clone.arcanePowerMax2 = arcanePowerMax2;
			clone.altWeaponFunc = altWeaponFunc;
		}

		//thank you weaponout mod dev, you saved my life here
		public bool CanUseItemAlt(Player player)
		{
			SpellbladePlayer p = player.GetModPlayer<SpellbladePlayer>();

			bool wasChange = false;
			if (p.altWeaponFunc != (player.altFunctionUse == 2))
				wasChange = true;
				p.altWeaponFunc = player.altFunctionUse == 2;
			if (wasChange)
			{
				if (Main.myPlayer == player.whoAmI)
				{
					ModPacket packet = mod.GetPacket();
					packet.Write((byte)ModMessageType.AltFuncUpdate);
					packet.Write((byte)player.whoAmI);
					packet.Write((player.altFunctionUse == 2));
					packet.Send();
				}
			}
			//SendClientChanges(p);

			return player.altFunctionUse == 2;
		}
		
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
		{
			ModPacket packet = mod.GetPacket();
			packet.Write((byte)ModMessageType.SyncPlayer);
			packet.Write((byte)player.whoAmI);
			packet.Write(arcanePowerCurrent); // While we sync nonStopParty in SendClientChanges, we still need to send it here as well so newly joining players will receive the correct value.
			packet.Write(arcanePowerMax);
			packet.Write(arcanePowerMax2);
			packet.Write(altWeaponFunc);
			packet.Send(toWho, fromWho);
		}


			/// <summary>
			/// Tests if the player can gain arcane power and adds it if they can
			/// </summary>
			public void TryToGainArcane()
		{
			if (canGainArcane)
			{
				arcanePowerCurrent += arcanePowerGainRate;
				arcanePowerCurrent = Utils.Clamp(arcanePowerCurrent, 0, arcanePowerMax2);
				arcaneGainCooldownTimer = 0;
			}
		}
        
        public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (SpellbladeMod.WeaponArtKey.JustPressed)
			{
				if (!(Main.LocalPlayer.HeldItem.modItem is SpellbladeBase))
					return;
				SpellbladeBase s = player.HeldItem.modItem as SpellbladeBase;
				if (!s.hasWeaponArt)
					return;
				if (ModPlayer(player).arcanePowerCurrent < s.arcaneCost)
					return;
				ModPlayer(player).arcanePowerCurrent -= s.arcaneCost;

				s.WeaponArt(player);
			}
		}
    }
}
