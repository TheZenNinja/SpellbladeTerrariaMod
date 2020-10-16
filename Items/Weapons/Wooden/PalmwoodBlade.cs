using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Spellblade.Items.Weapons.Wooden
{
    public class PalmwoodBlade : SpellswordBase
    {
        protected override int value => Item.buyPrice(copper: 50);
		protected override int rarity => ItemRarityID.White;

        protected override int swingDamage => 8;
        protected override float swingKnockback => 4;
        protected override int swingUseTime => 20;
        protected override int onHitManaRegen => 4;

        protected override int manaCost => 2;
        protected override int castUseTime => 10;
        protected override LegacySoundStyle castSound => new LegacySoundStyle(2,21);
        protected override int projectileID => 22;
        protected override int projectileDamage => 6;
        protected override float projectileKockback => 2;
        protected override int projectileSpeed => 10;

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Palmwood Spellblade");
			Tooltip.SetDefault("Shoots a stream of water with <right>.");
		}

		public override void SetDefaults()
		{
			SetBasicCustomDefaults();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PalmWood, 6);
			recipe.AddIngredient(ItemID.FallenStar, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
