﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;

namespace SpellbladeMod.Items.Weapons.PreHardmode.Metal
{
    public class DemoniteBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(silver: 50);
        protected override int rarity => ItemRarityID.Blue;
        protected override int swingDamage => 20;
        protected override float swingKnockback => 4;
        protected override int swingUseTime => 20;
        protected override int onHitManaRegen => ManaRegenT3;

        protected override int manaCost => 20;
        protected override int castUseTime => 32;
        protected override int projectileID => ProjectileID.VilethornTip;
        protected override int projectileDamage => 20;
        protected override float projectileKockback => 1;
        protected override int projectileSpeed => 1;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demonite Spellblade");
            Tooltip.SetDefault("Shoots a Vilethorn with <right>.");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                Vector2 rootPos = player.itemLocation;
                Vector2 velDir = Vector2.Normalize(Main.MouseWorld - rootPos);
                for (int i = 0; i < 6; i++)
                {
                    Projectile.NewProjectile(rootPos + velDir * i * 32, velDir * 0.1f, ProjectileID.VilethornBase, projectileDamage, projectileKockback, Main.myPlayer);
                }
                Projectile.NewProjectile(rootPos + velDir * 6 * 32, velDir * 0.1f, ProjectileID.VilethornTip, projectileDamage, projectileKockback, Main.myPlayer);
            }
            return false;
        }
    }
}
