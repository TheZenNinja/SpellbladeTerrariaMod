using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod.Items.Weapons.PreHardmode.Metal
{
    class TinBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(silver: 5);
        protected override int rarity => ItemRarityID.Blue;

        protected override int swingDamage => 6;
        protected override float swingKnockback => 4.5f;
        protected override int swingUseTime => 24;
        protected override int onHitManaRegen => ManaRegenT2;

        protected override int manaCost => 12;
        protected override int castUseTime => 34;
        protected override int projectileID => ProjectileID.BallofFire;
        protected override int projectileDamage => 12;
        protected override float projectileKockback => 2;
        protected override int projectileSpeed => 6;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tin Spellblade");
            Tooltip.SetDefault("Shoots a Fireball with <right>.");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
    }
}