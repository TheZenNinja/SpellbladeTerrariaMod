using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod.Items.Weapons
{
	/*
	public class TestSword : SpellswordBase
	{
        protected override int projectileID => Terraria.ID.ProjectileID.EnchantedBeam;
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Test Sword");
			Tooltip.SetDefault("This weapon does something special with <right>.");
		}

		public override void SetDefaults()
		{
			SetCustomDamageData(8, 20, 10, 30, 12);
			SetBasicCustomDefaults();


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
			item.UseSound = SoundID.Item1;

			item.value = 10000;
			item.rare = ItemRarityID.Blue;
			
			item.shoot = projectileID;
			item.shootSpeed = projectileSpeed;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<WoodBladeFrag>(), 6);
			recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				if (player.altFunctionUse == 2)
				{
					int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 169, 0f, 0f, 100, default(Color), 2f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity.X += player.direction * 2f;
					Main.dust[dust].velocity.Y += 0.2f;
				}
				else
				{
					//int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire, player.velocity.X * 0.2f + (float)(player.direction * 3), player.velocity.Y * 0.2f, 100, default(Color), 2.5f);
					//Main.dust[dust].noGravity = true;
				}
			}
		}

	}*/
}