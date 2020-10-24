using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpellbladeMod.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeMod.Items.Weapons.Hardmode.Metal
{
    public class MythrilSpellblade : SpellbladeBase
    {
        protected override int additiveCritChance => 4;
        protected override int swingDamage => 45;
        protected override float swingKnockback => 4;
        protected override int swingUseTime => 24;
        protected override int onHitManaRegen => ManaRegenT3;

        protected override int manaCost => 20;
        protected override int castUseTime => 35;
        protected override int projectileID => ModContent.ProjectileType<MythrilProjectile>();
        protected override int projectileDamage => 70;
        protected override float projectileKockback => 5;
        protected override int projectileSpeed => 12;

        protected override int value => Item.sellPrice(gold:5);
        protected override int rarity => ItemRarityID.LightRed;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mythril Spellblade");
            Tooltip.SetDefault("Shoots a homing with <right>.");
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.width = 48;
            item.height = 48;
        }
    }
}
