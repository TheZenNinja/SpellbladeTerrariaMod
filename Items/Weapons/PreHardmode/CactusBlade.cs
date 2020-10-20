using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using SpellbladeMod.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod.Items.Weapons.PreHardmode
{
    public class CactusBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(copper: 50);
		protected override int rarity => ItemRarityID.White;

        protected override int swingDamage => 8;
        protected override float swingKnockback => 4;
        protected override int swingUseTime => 20;
        protected override int onHitManaRegen => ManaRegenT1;

        protected override int manaCost => 3;
        protected override int castUseTime => 4;
        protected override LegacySoundStyle castSound => new LegacySoundStyle(2,17);
        protected override int projectileID => ModContent.ProjectileType<CactusNeedle>();
        protected override int projectileDamage => 4;
        protected override float projectileKockback => 1;
        protected override int projectileSpeed => 10;
        protected override int projectileSpread => 8;

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cactus Spellblade");
			Tooltip.SetDefault("Shoots a needle with <right>.");
		}

		public override void SetDefaults()
		{
			SetBasicCustomDefaults();
		}
	}
}
