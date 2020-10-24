using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpellbladeMod.Projectiles;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod.Items.Weapons.Hardmode.Metal
{
    public class TitaniumSpellblade : SpellbladeBase
    {
        protected override int additiveCritChance => 4;
        protected override int swingDamage => 45;
        protected override float swingKnockback => 6;
        protected override int swingUseTime => 25;
        protected override int onHitManaRegen => ManaRegenT3;

        protected override int manaCost => 8;
        protected override int castUseTime => 4;
        protected override int projectileID => ModContent.ProjectileType<CustomSkyFracture>();
        protected override int projectileDamage => 25;
        protected override float projectileKockback => 2;
        protected override int projectileSpeed => 15;

        protected override int value => Item.sellPrice(gold: 3);
        protected override int rarity => ItemRarityID.LightRed;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adamantite Spellblade");
            Tooltip.SetDefault("Rapidly send out spears with <right>.");
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.width = 48;
            item.height = 48;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int radius = 16 * 16;
            Vector2 mousePosition = Main.MouseWorld;

            double angle = Main.rand.NextDouble() * 360;
            Vector2 randPos = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            Vector2 pos = randPos * radius + mousePosition;

            Vector2 velDir = Vector2.Normalize(mousePosition - pos);

            int id = Projectile.NewProjectile(pos, velDir * projectileSpeed, projectileID, projectileDamage, projectileKockback, Main.myPlayer, 1);
            Main.projectile[id].timeLeft = 30;
            return false;
        }
    }
}
