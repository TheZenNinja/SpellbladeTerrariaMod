using Microsoft.Xna.Framework;
using SpellbladeMod.Projectiles;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod.Items.Weapons.Metal
{
    class TungstenBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(silver: 25);
        protected override int rarity => ItemRarityID.Blue;

        protected override int swingDamage => 10;
        protected override float swingKnockback => 4.5f;
        protected override int swingUseTime => 24;
        protected override int onHitManaRegen => ManaRegenT2;

        protected override int manaCost => 40;
        protected override int castUseTime => 45;
        protected override int projectileID => ProjectileID.EmeraldBolt;
        protected override int projectileDamage => 20;
        protected override float projectileKockback => 6;
        protected override int projectileSpeed => 4;
        protected override bool autoCast => false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tungsten Spellblade");
            Tooltip.SetDefault("Shoots a mana bolt with <right>.");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
    }
}