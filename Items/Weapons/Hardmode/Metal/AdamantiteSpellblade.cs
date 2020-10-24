using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpellbladeMod.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod.Items.Weapons.Hardmode.Metal
{
    public class AdamantiteSpellblade : SpellbladeBase
    {
        protected override int additiveCritChance => 4;
        protected override int swingDamage => 45;
        protected override float swingKnockback => 6;
        protected override int swingUseTime => 25;
        protected override int onHitManaRegen => ManaRegenT3;

        protected override int manaCost => 10;
        protected override int castUseTime => 6;
        protected override int projectileID => ProjectileID.AdamantiteGlaive;
        protected override int projectileDamage => 45;
        protected override float projectileKockback => 2;
        protected override int projectileSpeed => 12;
        protected override int projectileSpread => 15;

        protected override int value => Item.sellPrice(gold: 3);
        protected override int rarity => ItemRarityID.LightRed;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adamantite Spellblade");
            Tooltip.SetDefault("Rapidly send out spears with <right>.");
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.width = 48;
            item.height = 48;
        }
    }
}
