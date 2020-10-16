using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace Spellblade.Items.Weapons
{
    public class SpellswordPlayer : ModPlayer
    {
		public static SpellswordPlayer ModPlayer(Player player)
		{
			return player.GetModPlayer<SpellswordPlayer>();
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
			if (Spellblade.WeaponArtKey.JustPressed)
			{
				if (!(Main.LocalPlayer.HeldItem.modItem is SpellswordBase))
					return;
				SpellswordBase s = player.HeldItem.modItem as SpellswordBase;
				if (!s.hasWeaponArt)
					return;
				if (ModPlayer(player).arcanePowerCurrent < s.arcaneCost)
					return;
				ModPlayer(player).arcanePowerCurrent -= s.arcaneCost;

				s.WeaponArt(player);
			}
		}

		public override void OnHitAnything(float x, float y, Entity victim)
        {
			TryToGainArcane();
			base.OnHitAnything(x, y, victim);
        }
    }
}
