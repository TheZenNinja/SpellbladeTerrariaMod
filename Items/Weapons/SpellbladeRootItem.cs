using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;

namespace SpellbladeMod.Items.Weapons
{
    public abstract class SpellbladeRootItem : ModItem
    {
        protected virtual float scale { get; } = 1f;
        protected virtual int width { get; } = 32;
        protected virtual int height { get; } = 32;
        protected abstract int value { get; }
        protected abstract int rarity { get; }

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
        }
        public override bool AltFunctionUse(Player player) => true;

        protected virtual void SetBasicCustomDefaults()
        {
            item.magic = true;
            item.mana = 0;

            item.scale = scale;
            item.width = width;
            item.height = height;

            Item.staff[item.type] = true;

            item.value = value;
            item.rare = rarity;
        }

        public virtual void WeaponArt(Player player)
        {
            if (!hasWeaponArt)
                return;
        }
    }
}
