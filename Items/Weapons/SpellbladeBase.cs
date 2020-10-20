using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using SpellbladeMod.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod.Items.Weapons
{
	public enum ModMessageType : byte
	{
		SyncPlayer,
		UpdateAltFunc,
		WeaponArt
	}
	public abstract class SpellbladeBase : ModItem
	{
		public static readonly int ManaRegenT1 = 8;
		public static readonly int ManaRegenT2 = 16;
		public static readonly int ManaRegenT3 = 24;


		public override bool CloneNewInstances => true;

		#region basic attribues
		protected virtual int critChance { get; } = 2;
		protected virtual float scale { get; } = 1f;
		protected virtual int width { get; } = 32;
		protected virtual int height { get; } = 32;
		protected abstract int value { get; }
        protected abstract int rarity { get; }
		#endregion
        
		#region melee attribues
        protected abstract int swingDamage { get; }
		protected abstract float swingKnockback { get; }
		protected abstract int swingUseTime { get; }
		protected virtual Terraria.Audio.LegacySoundStyle swingSound { get; } = SoundID.Item1;
		protected virtual bool autoSwing { get; } = true;
		protected abstract int onHitManaRegen { get; }
		#endregion

		#region casting attribues
		protected abstract int manaCost { get; }
		protected abstract int castUseTime { get; }
		protected virtual int castUseAnimationTime { get; } = -1;
		protected virtual int castReuseDelay { get; } = -1;
		protected virtual int castUseStyle { get; } = ItemUseStyleID.HoldingOut;
		protected virtual Terraria.Audio.LegacySoundStyle castSound { get; } = SoundID.Item8;
		protected abstract int projectileID { get; }
		protected abstract int projectileDamage { get; }
		protected abstract float projectileKockback { get; }
		protected abstract int projectileSpeed { get; }
		protected virtual int projectileSpread { get; } = 5;
		protected virtual bool autoCast { get; } = true;
		#endregion

		#region Weapon Arts
		public virtual int arcaneCost { get; } = 0;
		public virtual bool hasWeaponArt { get; } = false;
		protected virtual LegacySoundStyle weaponArtSound { get; } = null;
		#endregion

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine line = new TooltipLine(mod, "Face", SpellbladeMod.classTitleText)
			{
				overrideColor = SpellbladeMod.classTextColor
			};
			tooltips.Insert(1, line);

			Player p = Main.player[Main.myPlayer];
			item.damage = swingDamage;
			int swingDmg = p.GetWeaponDamage(item);
			item.damage = projectileDamage;
			int projDmg = p.GetWeaponDamage(item);

			TooltipLine damageReplacement = new TooltipLine(mod, "Damage", $"{swingDmg} ({projDmg}) Magic Damage");
			int dmgIndex = tooltips.FindIndex(t => t.Name == "Damage");
			tooltips[dmgIndex] = damageReplacement;


			if (tooltips.Find(t => t.Name == "PrefixUseMana") != null)
				tooltips.RemoveAll(t => t.Name == "PrefixUseMana");

			item.mana = manaCost;
			int cost = p.GetManaCost(item);
			TooltipLine manaData = new TooltipLine(mod, "PrefixUseMana", $"Uses {cost} mana\nRestores {onHitManaRegen} Mana on Melee Hit");
			tooltips.Insert(6, manaData);
		}
		protected void SetBasicCustomDefaults()
		{
			item.damage = swingDamage;
			item.magic = true;
			item.knockBack = swingKnockback;
			item.mana = 0;
			item.crit = critChance;

			item.scale = scale;
			item.width = width;
			item.height = height;

			item.useTime = swingUseTime;
			item.useAnimation = swingUseTime;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.autoReuse = autoSwing;
			Item.staff[item.type] = true;

			item.value = value;
			item.rare = rarity;

			item.shoot = projectileID;
			item.shootSpeed = projectileSpeed;
		}
		public override bool AltFunctionUse(Player player) => true;
		public override bool CanUseItem(Player player)
		{
			SpellbladePlayer sp = player.GetModPlayer<SpellbladePlayer>();
			{
				if (SpellbladePlayer.CanUseItemAlt(player, Main.myPlayer == player.whoAmI))
					if (player.GetManaCost(item) > player.statMana)
						return false;
			}

			
			if (sp.altWeaponFunc)
				OnRightClick(player);
			else
				OnLeftClick(player);

			//Main.NewText($"-Spellblade- Player: {Main.player[player.whoAmI].name} AltFunc = {sp.altWeaponFunc}");

			return true;
		}
        public virtual void OnLeftClick(Player player)
		{
			//Item.staff[item.type] = false;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTime = swingUseTime;
			item.useAnimation = swingUseTime;
			item.UseSound = swingSound;
			item.damage = swingDamage;
			item.reuseDelay = 0;
			item.noMelee = false;
			item.knockBack = swingKnockback;
			item.mana = 0;

			item.shoot = ProjectileID.None;
			//item.useTurn = true;
			item.autoReuse = autoSwing;
		}
        public virtual void OnRightClick(Player player)
		{
			//Item.staff[item.type] = true;
			item.useStyle = castUseStyle;
			item.useTime = castUseTime;
			item.mana = manaCost;
			if (castUseAnimationTime != -1)
				item.useAnimation = castUseAnimationTime;
			else
				item.useAnimation = castUseTime;

			item.UseSound = castSound;

			if (castReuseDelay != -1)
				item.reuseDelay = castReuseDelay;
			else
				item.reuseDelay = castUseTime;

			item.noMelee = true;
			item.damage = projectileDamage;
			item.shoot = projectileID;
			item.useTurn = false;
			item.autoReuse = autoCast;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (player.altFunctionUse != 2)
			{
				player.statMana += (int)Math.Round((float)damage / swingDamage * onHitManaRegen);
			}
			player.GetModPlayer<SpellbladePlayer>().TryToGainArcane();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			// Fix the speedX and Y to point them horizontally.
			speedX = new Vector2(speedX, speedY).Length() * (speedX > 0 ? 1 : -1);
			speedY = 0;

			// Add random Rotation
			Vector2 speed = new Vector2(speedX, speedY);
			speed = speed.RotatedBy(player.itemRotation);
			speed = speed.RotatedByRandom(MathHelper.ToRadians(projectileSpread));

			damage = projectileDamage;
			speedX = speed.X;
			speedY = speed.Y;
			return true;
		}
        public virtual void WeaponArt(Player player)
		{
			if (!hasWeaponArt)
				return;
		}
	}
}