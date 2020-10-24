using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpellbladeMod.Buffs;
using SpellbladeMod.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeMod.Items.Weapons.Hardmode.Metal
{
    public class PalladiumSpellblade : SpellbladeBase
    {
        protected override int swingDamage => 35;
        protected override float swingKnockback => 3;
        protected override int swingUseTime => 25;
        protected override int onHitManaRegen => ManaRegenT3;

        protected override int manaCost => 40;
        protected override int castUseStyle => ItemUseStyleID.HoldingUp;
        protected override int castUseTime => 20;
        protected override int projectileID => ModContent.ProjectileType<PalladiumProjectile>();
        protected override int projectileDamage => 40;
        protected override float projectileKockback => 5;
        protected override int projectileSpeed => 0;

        protected override int value => Item.sellPrice(gold:3);
        protected override int rarity => ItemRarityID.LightRed;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Palladium Spellblade");
            Tooltip.SetDefault("Defends the player with swords");
        }
        public override bool CanUseItem(Player player)
        {
            SpellbladePlayer sp = player.GetModPlayer<SpellbladePlayer>();
            SpellbladePlayer.SetItemAltUse(player, Main.myPlayer == player.whoAmI);

            if (sp.altWeaponFunc)
                OnRightClick(player);
            else
                OnLeftClick(player);

            //Main.NewText($"-Spellblade- Player: {Main.player[player.whoAmI].name} AltFunc = {sp.altWeaponFunc}");
            if (player.GetManaCost(item) > player.statMana )
                return false;
            if (sp.altWeaponFunc == true && player.HasBuff(ModContent.BuffType<SwordProtection>()))
                return false;

            return true;
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.width = 48;
            item.height = 48;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(ModContent.BuffType<SwordProtection>(), 60 * 30);
            float angleBase = MathHelper.ToRadians(360) / 8;
            for (int i = 0; i < 8; i++)
            {
                Projectile.NewProjectile(player.position, Vector2.Zero, projectileID, projectileDamage, projectileKockback, player.whoAmI, angleBase * i);
            }


            return false;
        }
    }
}
