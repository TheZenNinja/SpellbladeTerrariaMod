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
    public class Muramasa : SpellbladeBase
    {
        protected override int value => Item.sellPrice(gold: 2);
        protected override int rarity => ItemRarityID.Orange;
        protected override int swingDamage => 24;
        protected override float swingKnockback => 4;
        protected override int swingUseTime => 16;
        protected override int onHitManaRegen => SpellbladeBase.ManaRegenT3/2;

        protected override int manaCost => 24;
        protected override int castUseTime => 40;
        protected override int projectileID => ModContent.ProjectileType<Vortex>();
        protected override LegacySoundStyle castSound => new LegacySoundStyle(2, 92);
        protected override int projectileDamage => 12;
        protected override float projectileKockback => 8;
        protected override int projectileSpeed => 10;

        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Suijin");
            Tooltip.SetDefault("Shoots a water vortex with <right>.");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.width = 48;
            item.height = 48;
        }
    }
}
