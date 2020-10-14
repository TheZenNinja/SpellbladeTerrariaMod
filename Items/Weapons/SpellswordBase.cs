using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Spellblade.Items.Weapons
{
    public abstract class SpellswordBase : ModItem
	{
		protected int projectileID = ProjectileID.EnchantedBeam;

		protected int swingDamage = 8;

		protected int swingUseTime = 20;
		protected int shootUseTime = 30;


		protected int projectileDamage = 10;
		protected int projectileSpeed = 12;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("You shouldn't be able to see this");
			Tooltip.SetDefault("This weapon does something special with <right>.");
		}
		protected void SetCustomDamageData(int swingDmg, int swingUseTime, int shootDmg, int shootUseTime, int shootProjectileSpeed)
		{
			this.swingDamage = swingDmg;
			this.swingUseTime = swingUseTime;

			this.projectileDamage = shootDmg;
			this.shootUseTime = shootUseTime;

			this.projectileSpeed = 12;
		}
		protected void SetCustomDefaults()
		{
			item.damage = swingDamage;
			item.magic = true;
			item.knockBack = 6;
			item.mana = 10;
			item.crit = 6;

			item.scale = 0.5f;
			item.width = 40;
			item.height = 40;

			item.useTime = swingUseTime;
			item.useAnimation = swingUseTime;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.autoReuse = true;

			item.value = Item.buyPrice(silver:20);
			item.rare = ItemRarityID.Blue;

			item.shoot = projectileID;
			item.shootSpeed = projectileSpeed;
		}

		public override bool AltFunctionUse(Player player) => true;
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.staff[item.type] = true;
				item.useStyle = ItemUseStyleID.HoldingOut;
				item.useTime = shootUseTime;
				item.UseSound = SoundID.Item9;
				item.useAnimation = shootUseTime;
				item.reuseDelay = shootUseTime;
				item.noMelee = true;
				item.damage = projectileDamage;
				item.shoot = projectileID;
				item.useTurn = false;
			}
			else
			{
				Item.staff[item.type] = false;
				item.useStyle = ItemUseStyleID.SwingThrow;
				item.useTime = swingUseTime;
				item.UseSound = SoundID.Item1;
				item.useAnimation = swingUseTime;
				item.damage = swingDamage;
				item.reuseDelay = 0;
				item.noMelee = false;
				player.manaCost = 0;
				player.manaRegenDelayBonus = 0;
				item.shoot = ProjectileID.None;
				item.useTurn = true;
			}
			return base.CanUseItem(player);
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (player.altFunctionUse != 2)
				player.statMana += (int)Math.Round((float)damage / 2);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			// Fix the speedX and Y to point them horizontally.
			speedX = new Vector2(speedX, speedY).Length() * (speedX > 0 ? 1 : -1);
			speedY = 0;

			// Add random Rotation
			Vector2 speed = new Vector2(speedX, speedY);
			speed = speed.RotatedBy(player.itemRotation);
			speed = speed.RotatedByRandom(MathHelper.ToRadians(5));

			damage = projectileDamage;
			speedX = speed.X;
			speedY = speed.Y;
			return true;
		}
	}
}