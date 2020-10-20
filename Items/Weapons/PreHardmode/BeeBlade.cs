﻿using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace SpellbladeMod.Items.Weapons.PreHardmode
{
    public class BeeBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(gold: 2);
        protected override int rarity => ItemRarityID.Orange;
        protected override int swingDamage => 25;
        protected override float swingKnockback => 4;
        protected override int swingUseTime => 20;
        protected override int onHitManaRegen => SpellbladeBase.ManaRegenT3;

        protected override int manaCost => 24;
        protected override int castUseTime => 32;
        protected override int projectileID => ProjectileID.Bee;
        protected override LegacySoundStyle castSound => new LegacySoundStyle(2, 97);
        protected override int projectileDamage => 12;
        protected override float projectileKockback => 3;
        protected override int projectileSpeed =>10;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Spellblade");
            Tooltip.SetDefault("Shoots a swarm of bees with <right>.");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int num = Main.rand.Next(16, 32);

            for (int i = 0; i < num; i++)
            {
                Vector2 randPos = new Vector2(Main.rand.Next(-8, 8), Main.rand.Next(-16, 16));
                Vector2 rotation = player.itemRotation.ToRotationVector2();
                rotation.RotatedByRandom(MathHelper.ToRadians(15));
                rotation *= player.direction;
                float speed = projectileSpeed * MathHelper.Clamp((float)Main.rand.NextDouble() + 0.5f, 0.8f, 1.2f);

                Projectile.NewProjectile(player.itemLocation + randPos, rotation * speed, projectileID, projectileDamage, projectileKockback, Main.myPlayer);
            }

            return false;
        }

    }
}
