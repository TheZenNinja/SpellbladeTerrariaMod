using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using SpellbladeMod.Items.Weapons;
using SpellbladeMod.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeMod.Items.Weapons.Hardmode
{
    public class Caliburn : SpellbladeBase
    {
        protected override int value => Item.sellPrice(gold: 2);
        protected override int rarity => ItemRarityID.Orange;

        protected override int swingDamage => 35;
        protected override float swingKnockback => 4;
        protected override int swingUseTime => 20;
        protected override int onHitManaRegen => SpellbladeBase.ManaRegenT3;

        protected override int manaCost => 5;
        protected override int castUseTime => 10;
        protected override int projectileID => ModContent.ProjectileType<CaliburnLaser>();
        protected override LegacySoundStyle castSound => new LegacySoundStyle(2, 60);
        protected override int projectileDamage => 14;
        protected override float projectileKockback => 3;
        protected override int projectileSpeed => 14;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Caliburn");
            Tooltip.SetDefault("Switch between a beam of holy light and normal sword with <right>.");
        }
        public override void HoldItem(Player player)
        {
            base.HoldItem(player);
            if (player.whoAmI == Main.myPlayer && Main.mouseRightRelease)
                if (!Main.mouseLeft && Main.mouseRight)
                    SwapMode(player);
        }
        public override bool CanUseItem(Player player)
        {
            SpellbladePlayer sp = player.GetModPlayer<SpellbladePlayer>();
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                if (sp.altWeaponFunc)
                    OnRightClick(player);
                else
                    OnLeftClick(player);

            }
            if (player.altFunctionUse == 2)
                return false;
            if (player.GetManaCost(item) > player.statMana)
                return false;

            return true;
        }
        public void SwapMode(Player player)
        {
            Main.PlaySound(SoundID.Item9, player.position);
            SpellbladePlayer.SwapItemAltUse(player, true);

            if (player.GetModPlayer<SpellbladePlayer>().altWeaponFunc)
                OnRightClick(player);
            else
                OnLeftClick(player);
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.width = 64;
            item.height = 64;
            item.channel = true;
            OnLeftClick(null);
        }
        public override void OnLeftClick(Player player)
        {
            base.OnLeftClick(player);
            if (player != null)
                player.channel = false;
        }
    }
}
