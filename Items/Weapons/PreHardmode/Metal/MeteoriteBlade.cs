using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.Audio;
using Microsoft.Xna.Framework;

namespace SpellbladeMod.Items.Weapons.PreHardmode.Metal
{
    public class MeteoriteBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(silver: 50);
        protected override int rarity => ItemRarityID.Blue;
        protected override int swingDamage => 24;
        protected override float swingKnockback => 4;
        protected override int swingUseTime => 20;
        protected override int onHitManaRegen => ManaRegenT3;

        protected override int manaCost => 20;
        protected override int castUseTime => 12;
        protected override int castUseAnimationTime => 12;
        protected override int castReuseDelay => 20;
        protected override int projectileID => ProjectileID.DD2SquireSonicBoom;
        protected override LegacySoundStyle castSound => new LegacySoundStyle(2, 92);
        protected override int castUseStyle => ItemUseStyleID.SwingThrow;
        protected override int projectileDamage => 24;
        protected override float projectileKockback => 1;
        protected override int projectileSpeed => 20;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteorite Spellblade");
            Tooltip.SetDefault("Shoot a weeb blast with <right>.");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
        public override void OnLeftClick(Player player)
        {
            base.OnLeftClick(player);
            item.noMelee = false;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 rootPos = player.itemLocation;
            Vector2 velDir = Vector2.Normalize(Main.MouseWorld - rootPos);
            int id = Projectile.NewProjectile(rootPos + Vector2.UnitY * 8, velDir * projectileSpeed, projectileID, projectileDamage, projectileKockback, Main.myPlayer);
            Main.projectile[id].tileCollide = true;
            return false;
        }
    }
}
