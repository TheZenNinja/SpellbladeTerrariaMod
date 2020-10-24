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
	public abstract class SpellbladeSwitchBase : SpellbladeRootItem
	{
		
		protected int projectileSpread;
		protected class ModeData
		{
			public int additiveCritChance = 0;
			public int damage;
			public float knockback;
			public LegacySoundStyle sound = SoundID.Item1;

			public int useStyle = ItemUseStyleID.SwingThrow;
			public int useTime;
			public int useReuseDelay = -1;
			public int useAnimationTime = -1;

			public bool autoUse = true;
			public bool useTurn = false;
            public bool channel = false;

			public int manaCost;
			public int projectileID = ProjectileID.None;
			public int projectileSpeed;
			public int projectileSpread = 5;

            public Action onSwapAction;

            public ModeData(int damage, float knockback, int useTime, int manaCost)
            {
                this.damage = damage;
                this.knockback = knockback;
                this.useTime = useTime;
                this.manaCost = manaCost;
            }

            public ModeData(int damage, float knockback, int manaCost, LegacySoundStyle sound, int useStyle, int useTime, int projectileID, int projectileSpeed, int projectileSpread)
            {
                this.damage = damage;
                this.knockback = knockback;
                this.manaCost = manaCost;
                this.sound = sound;
                this.useStyle = useStyle;
                this.useTime = useTime;
                this.projectileID = projectileID;
                this.projectileSpeed = projectileSpeed;
                this.projectileSpread = projectileSpread;
            }

            public ModeData(int additiveCritChance, int damage, float knockback, LegacySoundStyle sound, int useStyle, int useTime, int useReuseDelay, int useAnimationTime, bool autoUse, bool useTurn, int manaCost, int projectileID, int projectileSpeed, int projectileSpread)
            {
                this.additiveCritChance = additiveCritChance;
                this.damage = damage;
                this.knockback = knockback;
                this.sound = sound;
                this.useStyle = useStyle;
                this.useTime = useTime;
                this.useReuseDelay = useReuseDelay;
                this.useAnimationTime = useAnimationTime;
                this.autoUse = autoUse;
                this.useTurn = useTurn;
                this.manaCost = manaCost;
                this.projectileID = projectileID;
                this.projectileSpeed = projectileSpeed;
                this.projectileSpread = projectileSpread;
            }

            public void SwitchData(SpellbladeSwitchBase modItem)
			{
				Item item = modItem.item;

				item.damage = damage;
				item.knockBack = knockback;
				item.crit = additiveCritChance;
				item.UseSound = sound;
				item.useStyle = useStyle;
				item.useTime = useTime;
				item.useStyle = damage;
				if (useReuseDelay != -1)
					item.reuseDelay = useReuseDelay;
				else
					item.reuseDelay = useTime;
				if (useAnimationTime != -1)
					item.useAnimation = useAnimationTime;
				else
					item.useAnimation = useTime;

				item.autoReuse = autoUse;
				item.useTurn = useTurn;

				item.mana = manaCost;
				item.shoot = projectileID;
				item.shootSpeed = projectileSpeed;
				modItem.projectileSpread = projectileSpread;

                onSwapAction?.Invoke();
            }
        }
        public bool altMode = false;
        public virtual int maxModes { get; } = 2;
        protected abstract ModeData primaryMode { get; }
        protected abstract ModeData secondaryMode { get; }
        public override bool CanUseItem(Player player)
        {
            SpellbladePlayer sp = player.GetModPlayer<SpellbladePlayer>();
            if (player.altFunctionUse == 2)
            {
                Main.NewText("rightclick");
                Main.NewText($"Mode = {altMode}");
                SwapMode();
                return false;
            }
            if (player.GetManaCost(item) > player.statMana)
                return false;
            return true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);
		}
		protected override sealed void SetBasicCustomDefaults()
		{
			base.SetBasicCustomDefaults();
            primaryMode.SwitchData(this);
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
        }
        public void SwapMode()
        {
            altMode = !altMode;
            if (altMode)
                secondaryMode.SwitchData(this);
            else
                primaryMode.SwitchData(this);
            Main.PlaySound(SoundID.MenuTick, item.position);
            Main.NewText("====");
        }
    }
}