using SpellbladeMod.Projectiles;
using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod.Items.Weapons.Metal
{
    class CopperBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(silver:1);
        protected override int rarity => ItemRarityID.Green;

        protected override int swingDamage => 6;
        protected override float swingKnockback => 4.5f;
        protected override int swingUseTime => 24;
        protected override int onHitManaRegen => 8;

        protected override int manaCost => 10;
        protected override int castUseTime => 30;
        protected override int projectileID => ModContent.ProjectileType<FriendlyLightning>();
        protected override int projectileDamage => 10;
        protected override float projectileKockback => 2;
        protected override int projectileSpeed => 10;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Copper Spellblade");
            Tooltip.SetDefault("Shoots a lightning bolt with <right>.");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CopperBar, 8);
            recipe.AddIngredient(ItemID.Amethyst, 2);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (player.altFunctionUse == 2)
                target.AddBuff(BuffID.Weak, 60 * 2);


            base.OnHitNPC(player, target, damage, knockBack, crit);
        }
    }
}
