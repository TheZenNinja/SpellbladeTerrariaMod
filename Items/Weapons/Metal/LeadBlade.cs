using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod.Items.Weapons.Metal
{
    class LeadBlade : SpellbladeBase
    {
        protected override int value => Item.buyPrice(silver: 6);
        protected override int rarity => ItemRarityID.Green;
        protected override int swingDamage => 8;
        protected override float swingKnockback => 5.5f;
        protected override int swingUseTime => 20;
        protected override int onHitManaRegen => 6;
        protected override int manaCost => 10;
        protected override int castUseTime => 22;
        protected override int projectileID => ProjectileID.EnchantedBeam;
        protected override int projectileDamage => 26;
        protected override float projectileKockback => 4f;
        protected override int projectileSpeed => 10;

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);
            TooltipLine extra = new TooltipLine(mod, "Tooltip2", "Poisons enemies")
            {
                overrideColor = Color.Lime
            };
            tooltips.Add(extra);
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lead Spellblade");
            Tooltip.SetDefault("Shoots an enchanted sword with <right>.");
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            //if (Main.rand.NextBool(4))
            target.AddBuff(BuffID.Poisoned, Main.rand.Next(30, 60));

            base.OnHitNPC(player, target, damage, knockBack, crit);
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LeadBar, 8);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
