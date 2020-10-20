using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;

namespace SpellbladeMod.Items.Weapons.PreHardmode
{
    public class GraniteBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(gold: 2);
        protected override int rarity => ItemRarityID.Orange;
        protected override int swingDamage => 25;
        protected override float swingKnockback => 4;
        protected override int swingUseTime => 20;
        protected override int onHitManaRegen => SpellbladeBase.ManaRegenT3;

        protected override int manaCost => 24;
        protected override int castUseTime => 18;
        protected override int projectileID => ProjectileID.DemonScythe;
        protected override LegacySoundStyle castSound => new LegacySoundStyle(2, 8);
        protected override int projectileDamage => 40;
        protected override float projectileKockback => 3;
        protected override int projectileSpeed => 1;

        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Spellblade");
            Tooltip.SetDefault("Shoots a demonic scythe with <right>.");
            customGlowMask = SpellbladeMod.SetStaticDefaultsGlowMask(this);
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.width = 48;
            item.height = 48;
            item.glowMask = customGlowMask;
        }
        public override void OnRightClick(Player player)
        {
            base.OnRightClick(player);
            item.glowMask = customGlowMask;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Items/Weapons/PreHardmode/GraniteGlow");
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width * 0.5f,
					item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale,
				SpriteEffects.None,
				0f
			);
		}
	}
}
