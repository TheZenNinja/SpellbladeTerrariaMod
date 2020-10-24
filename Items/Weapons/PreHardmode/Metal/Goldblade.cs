﻿using Microsoft.Xna.Framework;
using SpellbladeMod.Projectiles;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod.Items.Weapons.PreHardmode.Metal
{
    public class GoldBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(silver: 50);
        protected override int rarity => ItemRarityID.Blue;

        protected override int swingDamage => 12;
        protected override float swingKnockback => 4.5f;
        protected override int swingUseTime => 20;
        protected override int onHitManaRegen => ManaRegenT2;

        protected override int manaCost => 40;
        protected override int castUseTime => 45;
        protected override int projectileID => 0;
        protected override int projectileDamage => 20;
        protected override float projectileKockback => 6;
        protected override int projectileSpeed => 4;
        protected override bool autoCast => false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gold Spellblade");
            Tooltip.SetDefault("Projects a large sword with <right>.");
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
        public override void OnRightClick(Player player)
        {
            base.OnRightClick(player);
            Item.staff[item.type] = false;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.reuseDelay = 0;
            item.noMelee = false;
            item.shoot = ProjectileID.None;

            if (player.whoAmI == Main.myPlayer)
            {
                int id = Projectile.NewProjectile(player.position, Vector2.Zero, ModContent.ProjectileType<MegaSword>(), projectileDamage, projectileKockback, Main.myPlayer);
                MegaSword proj = Main.projectile[id].modProjectile as MegaSword;
                proj.SetData(player, 30);
            }
        }
        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int radius = 16 * 16;
            Vector2 mousePosition = Main.MouseWorld;

            double angle = Main.rand.NextDouble() * 360;
            Vector2 randPos = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            Vector2 pos = randPos * radius + mousePosition;

            Vector2 velDir = Vector2.Normalize(mousePosition - pos);

            int id = Projectile.NewProjectile(pos, velDir * projectileSpeed, projectileID, projectileDamage, projectileKockback, Main.myPlayer);
            Main.projectile[id].timeLeft = 30;
            return false;
        }*/
    }
}