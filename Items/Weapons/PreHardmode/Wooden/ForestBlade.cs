using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using SpellbladeMod.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod.Items.Weapons.PreHardmode.Wooden
{
    public class ForestBlade : SpellbladeBase
    {
        protected override int value => Item.buyPrice(copper: 50);
		protected override int rarity => ItemRarityID.White;

        protected override int swingDamage => 6;
        protected override float swingKnockback => 3;
        protected override int swingUseTime => 22;
        protected override int onHitManaRegen => 4;

        protected override int manaCost => 2;
        public override bool hasWeaponArt => true;
        protected override LegacySoundStyle weaponArtSound => new LegacySoundStyle(2, 117);
        public override int arcaneCost => 2;
        protected override int castUseTime => 26;
        protected override LegacySoundStyle castSound => new LegacySoundStyle(2,8);
        protected override int projectileID => ProjectileID.TerraBeam;
        protected override int projectileDamage => 10;
        protected override float projectileKockback => 2;
        protected override int projectileSpeed => 6;

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heart of The Forest");
			Tooltip.SetDefault("Not implemented, dont use");
		}

		public override void SetDefaults()
		{
			SetBasicCustomDefaults();
		}
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            base.OnHitNPC(player, target, damage, knockBack, crit);
            if (player.altFunctionUse == 2)
                    target.AddBuff(BuffID.CursedInferno, Main.rand.Next(20, 40));
        }

        public override void WeaponArt(Player player)
        {
            if (!hasWeaponArt)
                return;

            Vector2 pos;
            Vector2 mousePosition = Main.MouseWorld;
            Main.PlaySound(weaponArtSound, mousePosition);

            int orbitRadius = 10 * 16;
            int count = 8;
            float angleRate = 360 / count;
            for (int i = 0; i < count; i++)
            {
                MagicSwordProjectile projectile = new MagicSwordProjectile();

                float angle = MathHelper.ToRadians(i * angleRate);

                Vector2 direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                pos.X = mousePosition.X + (direction.X * orbitRadius) - projectile.projectile.width / 2;
                pos.Y = mousePosition.Y + (direction.Y * orbitRadius) - projectile.projectile.height;

                Vector2 velDir = Vector2.Normalize(mousePosition - pos);

                int id = Projectile.NewProjectile(pos, velDir * 10, ModContent.ProjectileType<MagicSwordProjectile>(), 10, 2, Main.myPlayer);

                MagicSwordProjectile proj = Main.projectile[id].modProjectile as MagicSwordProjectile;
                proj.SetDelay(i * 10);
                proj.SetLifetime(60 + (i+1) * 15);
            }

        }
    }
}
