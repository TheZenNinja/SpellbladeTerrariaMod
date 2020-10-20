using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod.Items.Weapons.Wooden
{
    public class ShadewoodBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(copper: 50);
		protected override int rarity => ItemRarityID.White;

        protected override int swingDamage => 8;
        protected override float swingKnockback => 4;
        protected override int swingUseTime => 20;
        protected override int onHitManaRegen => ManaRegenT1;

        protected override int manaCost => 4;
        protected override int castUseTime => 16;
        protected override LegacySoundStyle castSound => new LegacySoundStyle(2,21);
        protected override int projectileID => ProjectileID.BloodRain;
        protected override int projectileDamage => 8;
        protected override float projectileKockback => 4;
        protected override int projectileSpeed => 10;

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadewood Spellblade");
			Tooltip.SetDefault("Shoots a stream of blood with <right>.");
		}

		public override void SetDefaults()
		{
			SetBasicCustomDefaults();
		}
	}
}
