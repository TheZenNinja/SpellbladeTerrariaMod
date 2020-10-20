using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace SpellbladeMod.Items.Weapons.PreHardmode
{
    class ObsidianBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(gold: 2);
        protected override int rarity => ItemRarityID.Orange;
        protected override int swingDamage => 25;
        protected override float swingKnockback => 4;
        protected override int swingUseTime => 20;
        protected override int onHitManaRegen => SpellbladeBase.ManaRegenT3;

        protected override int manaCost => 24;
        protected override int castUseTime => 18;
        protected override int projectileID => ProjectileID.DemonScythe;
        protected override LegacySoundStyle castSound => new LegacySoundStyle(2,8);
        protected override int projectileDamage => 40;
        protected override float projectileKockback => 3;
        protected override int projectileSpeed => 1;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Obsidian Spellblade");
            Tooltip.SetDefault("Shoots a demonic scythe with <right>.");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.width = 48;
            item.height = 48;
        }
    }
}
