using Microsoft.Xna.Framework;
using Spellblade.Projectiles;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Spellblade.Items.Weapons.Metal
{
    public class GoldBlade : SpellswordBase
    {
        protected override int value => Item.sellPrice(silver: 30);
        protected override int rarity => ItemRarityID.Green;

        protected override int swingDamage => 14;
        protected override float swingKnockback => 4.5f;
        protected override int swingUseTime => 20;
        protected override int onHitManaRegen => 8;

        protected override int manaCost => 12;
        protected override int castUseTime => 10;
        protected override int projectileID => ProjectileID.SkyFracture;
        protected override int projectileDamage => 10;
        protected override float projectileKockback => 2;
        protected override int projectileSpeed => 12;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gold Spellblade");
            Tooltip.SetDefault("Shoots a stream of ichor with <right>.");
        }
        public override void OnRightClick(Player player)
        {
            Item.staff[item.type] = true;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTime = castUseTime;
            item.UseSound = castSound;
            item.useAnimation = castUseTime;
            item.reuseDelay = castUseTime;


            int width = 7 * 16;
            int height = 20 * 16;
            Vector2 mousePosition = Main.MouseWorld;

            for (int i = -2; i < 4; i++)
            {
                Vector2 pos = new Vector2((i) * width - width / 2, -height) + mousePosition;

                Vector2 velDir = Vector2.Normalize(mousePosition - pos);

                int id = Projectile.NewProjectile(pos, velDir * projectileSpeed, projectileID, projectileDamage, projectileKockback, Main.myPlayer);

                Projectile proj = Main.projectile[id];
            }


            item.noMelee = true;
            item.damage = projectileDamage;
            item.shoot = ProjectileID.None;
            item.useTurn = false;
            item.autoReuse = autoCast;

        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PlatinumBar, 8);
            recipe.AddIngredient(ItemID.Diamond, 2);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}