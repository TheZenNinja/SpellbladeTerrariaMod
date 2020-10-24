using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using SpellbladeMod.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod.Items.Weapons.PreHardmode.Wooden
{
    public class EbonwoodBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(copper: 50);
		protected override int rarity => ItemRarityID.White;

        protected override int swingDamage => 8;
        protected override float swingKnockback => 4;
        protected override int swingUseTime => 20;
        protected override int onHitManaRegen => ManaRegenT1;

        protected override int manaCost => 10;
        protected override int castUseTime => 26;
        protected override LegacySoundStyle castSound => new LegacySoundStyle(2,65);
        protected override int projectileID => ModContent.ProjectileType<CorruptBall>();
        protected override int projectileDamage => 12;
        protected override float projectileKockback => 6;
        protected override int projectileSpeed => 10;

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ebonwood Spellblade");
			Tooltip.SetDefault("Shoots a Corrupt glob with <right>.");
		}

		public override void SetDefaults()
		{
			SetBasicCustomDefaults();
		}
	}
}
