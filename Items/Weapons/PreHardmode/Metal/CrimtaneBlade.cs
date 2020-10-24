using Microsoft.Xna.Framework;
using SpellbladeMod.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod.Items.Weapons.PreHardmode.Metal
{
    public class CrimtaneBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(silver: 50);
        protected override int rarity => ItemRarityID.Blue;
        protected override int swingDamage => 20;
        protected override float swingKnockback => 4;
        protected override int swingUseTime => 20;
        protected override int onHitManaRegen => ManaRegenT3;

        protected override int manaCost => 20;
        protected override int castUseTime => 32;
        protected override int projectileID => ModContent.ProjectileType<RottedForkProjectile>();
        protected override int projectileDamage => 12;
        protected override float projectileKockback => 4;
        protected override int projectileSpeed => 8;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crimtane Spellblade");
            Tooltip.SetDefault("Summon spears at the cursor with <right>.");
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int radius = 16 * 16;

            Vector2 goalPos = Main.MouseWorld;

            int maxDist = (int)Vector2.Distance(Main.MouseWorld, player.position);
            Vector2 dir = Vector2.Normalize(Main.MouseWorld - player.position);

            for (int i = 32; i < maxDist; i++)
            {
                if (!Collision.CanHit(player.position, 1, 1, player.position + dir * i, 1, 1))
                {
                    goalPos = player.position + dir * i;
                    break;
                }    
            }

            for (int i = 0; i < 4; i++)
            {
                float angle = 360 / 4 * i + 45;
                Vector2 randPos = new Vector2((float)Math.Cos(MathHelper.ToRadians(angle)), (float)Math.Sin(MathHelper.ToRadians(angle)));
                Vector2 pos = randPos * radius + goalPos;
                Vector2 velDir = Vector2.Normalize(goalPos - pos);

                Projectile.NewProjectile(pos, velDir * projectileSpeed, projectileID, projectileDamage, projectileKockback, Main.myPlayer);
            }
            
            return false;
        }
    }
}
