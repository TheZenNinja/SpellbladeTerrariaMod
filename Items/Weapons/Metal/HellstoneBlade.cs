using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;

namespace SpellbladeMod.Items.Weapons.Metal
{
    public class HellstoneBlade : SpellbladeBase
    {
        protected override float scale => 1.1f;
        protected override int value => Item.sellPrice(silver: 75);
        protected override int rarity => ItemRarityID.Orange;
        protected override int swingDamage => 35;
        protected override float swingKnockback => 5;
        protected override int swingUseTime => 24;
        protected override int onHitManaRegen => ManaRegenT3;

        protected override int manaCost => 24;
        protected override int castUseTime => 6;
        protected override int castUseAnimationTime => 30;
        protected override LegacySoundStyle castSound => new LegacySoundStyle(2,34);
        protected override int projectileID => ProjectileID.Flames;
        protected override int projectileDamage => 15;
        protected override float projectileKockback => 1;
        protected override int projectileSpeed => 6;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellstone Spellblade");
            Tooltip.SetDefault("Shoots fire with <right>.");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            base.OnHitNPC(player, target, damage, knockBack, crit);
            if (player.altFunctionUse == 0)
                if (Main.rand.NextBool(2))
                    target.AddBuff(BuffID.OnFire, Main.rand.Next(60, 90));
        }
    }
}
