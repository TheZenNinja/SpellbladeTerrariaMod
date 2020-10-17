using Microsoft.Xna.Framework;
using SpellbladeMod.Projectiles;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod.Items.Weapons.Metal
{
    class TungstenBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(silver: 1);
        protected override int rarity => ItemRarityID.Green;

        protected override int swingDamage => 6;
        protected override float swingKnockback => 4.5f;
        protected override int swingUseTime => 24;
        protected override int onHitManaRegen => 8;

        protected override int manaCost => 40;
        protected override int castUseTime => 45;
        protected override int projectileID => 0;
        protected override int projectileDamage => 20;
        protected override float projectileKockback => 6;
        protected override int projectileSpeed => 4;
        protected override bool autoCast => false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tungsten Spellblade");
            Tooltip.SetDefault("Creates a large sword projection with <right>.");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
        public override void OnRightClick(Player player)
        {
                Item.staff[item.type] = false;
                item.useStyle = ItemUseStyleID.SwingThrow;
                item.reuseDelay = 0;
                item.noMelee = false;
                item.useTime = castUseTime;
                item.UseSound = castSound;
                item.useAnimation = castUseTime;
                item.reuseDelay = 0;
                item.shoot = ProjectileID.None;
                item.useTurn = true;
                item.autoReuse = autoCast;

                item.damage = projectileDamage;
                item.knockBack = projectileKockback;

                int id = Projectile.NewProjectile(player.position, Vector2.Zero, ModContent.ProjectileType<MegaSword>(), projectileDamage, projectileKockback, Main.myPlayer);
                MegaSword proj = Main.projectile[id].modProjectile as MegaSword;
                proj.SetData(player, 30);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TungstenBar, 8);
            recipe.AddIngredient(ItemID.Emerald, 2);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}