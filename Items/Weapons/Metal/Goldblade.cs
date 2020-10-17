using Microsoft.Xna.Framework;
using SpellbladeMod.Projectiles;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod.Items.Weapons.Metal
{
    public class GoldBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(silver: 30);
        protected override int rarity => ItemRarityID.Green;

        protected override int swingDamage => 14;
        protected override float swingKnockback => 4.5f;
        protected override int swingUseTime => 20;
        protected override int onHitManaRegen => 8;

        protected override int manaCost => 3;
        protected override int castUseTime => 2;
        protected override LegacySoundStyle castSound => new LegacySoundStyle(2,9);
        protected override int projectileID => ModContent.ProjectileType<CustomSkyFracture>();
        protected override int projectileDamage => 5;
        protected override float projectileKockback => 1;
        protected override int projectileSpeed => 14;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gold Spellblade");
            Tooltip.SetDefault("Shoots a barrage of swords at the cursor with <right>.");
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBar, 8);
            recipe.AddIngredient(ItemID.Ruby, 2);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
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
        }
    }
}