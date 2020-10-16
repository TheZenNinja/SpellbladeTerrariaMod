using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Spellblade.Items.Weapons.Wooden
{
    public class BorealBlade : SpellswordBase
    {
        protected override int value => Item.buyPrice(copper: 50);
		protected override int rarity => ItemRarityID.White;

        protected override int swingDamage => 8;
        protected override float swingKnockback => 4;
        protected override int swingUseTime => 20;
        protected override int onHitManaRegen => 4;

        protected override int manaCost => 5;
        protected override int castUseTime => 26;
        protected override LegacySoundStyle castSound => new LegacySoundStyle(2,30);
        protected override int projectileID => ProjectileID.IceBolt;
        protected override int projectileDamage => 14;
        protected override float projectileKockback => 4;
        protected override int projectileSpeed => 10;

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boreal Spellblade");
			Tooltip.SetDefault("Shoots an ice bolt with <right>.");
		}

		public override void SetDefaults()
		{
			SetBasicCustomDefaults();
		}
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            base.OnHitNPC(player, target, damage, knockBack, crit);
            if (player.altFunctionUse == 2)
                if (Main.rand.NextBool(3))
                    target.AddBuff(BuffID.Chilled, Main.rand.Next(30, 60));
        }
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BorealWood, 6);
			recipe.AddIngredient(ItemID.FallenStar, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
