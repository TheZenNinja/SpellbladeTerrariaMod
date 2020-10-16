using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Spellblade.Items.Weapons.Metal
{
    class TinBlade : SpellswordBase
    {
        protected override int value => Item.sellPrice(silver: 1);
        protected override int rarity => ItemRarityID.Green;

        protected override int swingDamage => 6;
        protected override float swingKnockback => 4.5f;
        protected override int swingUseTime => 24;
        protected override int onHitManaRegen => 8;

        protected override int manaCost => 12;
        protected override int castUseTime => 35;
        protected override int projectileID => ProjectileID.BallofFire;
        protected override int projectileDamage => 12;
        protected override float projectileKockback => 2;
        protected override int projectileSpeed => 4;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tin Spellblade");
            Tooltip.SetDefault("Shoots a Fireball with <right>.");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TinBar, 8);
            recipe.AddIngredient(ItemID.Topaz, 2);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}