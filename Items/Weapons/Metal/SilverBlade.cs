﻿using Microsoft.Xna.Framework;
using SpellbladeMod.Projectiles;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod.Items.Weapons.Metal
{
    public class SilverBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(silver: 30);
        protected override int rarity => ItemRarityID.Green;

        protected override int swingDamage => 14;
        protected override float swingKnockback => 4.5f;
        protected override int swingUseTime => 20;
        protected override int onHitManaRegen => 8;

        protected override int manaCost => 12;
        protected override int castUseTime => 10;
        protected override int castUseAnimationTime => 20;
        protected override int castReuseDelay => 32;
        protected override LegacySoundStyle castSound => new LegacySoundStyle(2, 9);
        protected override int projectileID => ModContent.ProjectileType<CustomSkyFracture>();
        protected override int projectileDamage => 20;
        protected override float projectileKockback => 3;
        protected override int projectileSpeed => 16;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silver Spellblade");
            Tooltip.SetDefault("Shoots a barrage of swords with <right>.");
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SilverBar, 8);
            recipe.AddIngredient(ItemID.Sapphire, 2);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 mousePosition = Main.MouseWorld;

            Vector2 randPos = new Vector2(Main.rand.Next(-64, 64), Main.rand.Next(-64, 0));
            Vector2 pos = randPos + player.position;

            Vector2 velDir = Vector2.Normalize(mousePosition - pos);

            int id = Projectile.NewProjectile(pos, velDir * projectileSpeed, projectileID, projectileDamage, projectileKockback, Main.myPlayer);
            return false;
        }
    }
}