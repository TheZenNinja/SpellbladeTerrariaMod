﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeMod.Items
{
	public class ComplexArcaneFragment : ModItem
	{
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine line = new TooltipLine(mod, "Face", SpellbladeMod.classTitleText)
			{
				overrideColor = SpellbladeMod.classTextColor
			};
			tooltips.Insert(1, line);

			TooltipLine manaRestore = new TooltipLine(mod, "Tooltip0", "Arcing with arcane energy");
			tooltips.Add(manaRestore);
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = Item.sellPrice(gold:5);
			item.rare = ItemRarityID.Pink;
		}
	}
}