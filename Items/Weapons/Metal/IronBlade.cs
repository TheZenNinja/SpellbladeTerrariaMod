using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod.Items.Weapons.Metal
{
    public class IronBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(silver:5);
        protected override int rarity => ItemRarityID.Blue;
        protected override int swingDamage => 8;
        protected override float swingKnockback => 5;
        protected override int swingUseTime => 20;
        protected override int onHitManaRegen => ManaRegenT2;

        protected override int manaCost => 10;
        protected override int castUseTime => 20;
        protected override int projectileID => ProjectileID.EnchantedBeam;
        protected override int projectileDamage => 18;
        protected override float projectileKockback => 3.5f;
        protected override int projectileSpeed => 12;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iron Spellblade");
            Tooltip.SetDefault("Shoots an enchanted sword with <right>.");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
    }
}
