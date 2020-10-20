using SpellbladeMod.Projectiles;
using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod.Items.Weapons.Metal
{
    class CopperBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(silver:5);
        protected override int rarity => ItemRarityID.Blue;

        protected override int swingDamage => 6;
        protected override float swingKnockback => 4.5f;
        protected override int swingUseTime => 24;
        protected override int onHitManaRegen => ManaRegenT2;

        protected override int manaCost => 10;
        protected override int castUseTime => 30;
        protected override int projectileID => ModContent.ProjectileType<FriendlyLightning>();
        protected override int projectileDamage => 16;
        protected override float projectileKockback => 2;
        protected override int projectileSpeed => 10;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Copper Spellblade");
            Tooltip.SetDefault("Shoots a lightning bolt with <right>.");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (player.altFunctionUse == 2)
                target.AddBuff(BuffID.Weak, 120);

            base.OnHitNPC(player, target, damage, knockBack, crit);
        }
    }
}
