using Terraria.ID;
using Terraria.ModLoader;
using SpellbladeMod.Items.Weapons;
using SpellbladeMod.Items.Weapons.Wooden;
using SpellbladeMod.Items.Weapons.Metal;
using SpellbladeMod.Items;
using SpellbladeMod.Items.Weapons.PreHardmode;

namespace SpellbladeMod
{
    public static class RecipeManager
    {
        public static void AddConversionRecipies(Mod mod)
        {
            ModRecipe recipe;
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CopperBar);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.TinBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TinBar);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.CopperBar);
            recipe.AddRecipe();
        }
        public static void AddIngredientRecipies(Mod mod)
        {
            ModRecipe recipe;
            #region Arcane Fragments
            //lesser
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 2);
            recipe.SetResult(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddRecipe();
            //basic
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 4);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.SetResult(ModContent.ItemType<BasicArcaneFragment>());
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 4);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.SetResult(ModContent.ItemType<BasicArcaneFragment>());
            recipe.AddRecipe();
            //intermediate
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 4);
            recipe.AddIngredient(ItemID.Diamond, 1);
            recipe.SetResult(ModContent.ItemType<IntermediateArcaneFragment>());
            recipe.AddRecipe();
            #endregion
        }
        public static void AddWoodenRecipies(Mod mod)
        {
            ModRecipe recipe;
            //normal wood
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 12);
            recipe.AddIngredient(ItemID.Acorn, 4);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<WoodenBlade>());
            recipe.AddRecipe();
            //shadewood
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Shadewood, 12);
            recipe.AddIngredient(ItemID.Vertebrae, 4);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<ShadewoodBlade>());
            recipe.AddRecipe();
            //ebonwood
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ebonwood, 12);
            recipe.AddIngredient(ItemID.RottenChunk, 4);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<EbonwoodBlade>());
            recipe.AddRecipe();
            //mahogany
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RichMahogany, 12);
            recipe.AddIngredient(ItemID.Stinger, 4);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<MahoganyBlade>());
            recipe.AddRecipe();
            //palm
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalmWood, 12);
            recipe.AddIngredient(ItemID.Coral, 4);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<PalmwoodBlade>());
            recipe.AddRecipe();
            //boreal
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BorealWood, 12);
            recipe.AddIngredient(ItemID.IceBlock, 4);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<BorealBlade>());
            recipe.AddRecipe();
        }
        public static void AddMetalRecipies(Mod mod)
        {
            ModRecipe recipe;
            //iron
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 12);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<IronBlade>());
            recipe.AddRecipe();
            //lead
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LeadBar, 12);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<LeadBlade>());
            recipe.AddRecipe();
            //copper
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CopperBar, 12);
            recipe.AddIngredient(ItemID.Amethyst, 4);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<CopperBlade>());
            recipe.AddRecipe();
            //tin
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TinBar, 12);
            recipe.AddIngredient(ItemID.Topaz, 4);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<TinBlade>());
            recipe.AddRecipe();
            //Silver
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SilverBar, 12);
            recipe.AddIngredient(ItemID.Sapphire, 4);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<SilverBlade>());
            recipe.AddRecipe();
            //Tungsten
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TungstenBar, 12);
            recipe.AddIngredient(ItemID.Emerald, 4);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<TungstenBlade>());
            recipe.AddRecipe();
            //gold
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBar, 12);
            recipe.AddIngredient(ItemID.Ruby, 4);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<GoldBlade>());
            recipe.AddRecipe();
            //platinum
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PlatinumBar, 12);
            recipe.AddIngredient(ItemID.Diamond, 4);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<PlatinumBlade>());
            recipe.AddRecipe();

            //demonite
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 12);
            recipe.AddIngredient(ItemID.Vilethorn);
            recipe.AddIngredient(ModContent.ItemType<BasicArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DemoniteBlade>());
            recipe.AddRecipe();
            //demonite
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 12);
            recipe.AddIngredient(ItemID.TheRottedFork);
            recipe.AddIngredient(ModContent.ItemType<BasicArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<CrimtaneBlade>());
            recipe.AddRecipe();

            //Hellstone
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 12);
            recipe.AddIngredient(ItemID.Gel, 50);
            recipe.AddIngredient(ItemID.Fireblossom, 1);
            recipe.AddIngredient(ModContent.ItemType<IntermediateArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<HellstoneBlade>());
            recipe.AddRecipe();
            //meteorite
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Meteorite, 20);
            recipe.AddIngredient(ItemID.Ruby, 4);
            recipe.AddIngredient(ModContent.ItemType<IntermediateArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<MeteoriteBlade>());
            recipe.AddRecipe();
        }

        public static void AddMiscPreHardRecipies(Mod mod)
        {
            ModRecipe recipe;
            //cactus
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Cactus, 20);
            recipe.AddIngredient(ItemID.AntlionMandible, 4);
            recipe.AddIngredient(ModContent.ItemType<BasicArcaneFragment>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<CactusBlade>());
            recipe.AddRecipe();
            //amber
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DesertFossil, 20);
            recipe.AddIngredient(ItemID.Amber, 4);
            recipe.AddIngredient(ModContent.ItemType<BasicArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<AmberBlade>());
            recipe.AddRecipe();
            //obsidian
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Obsidian, 20);
            recipe.AddIngredient(ItemID.DemonScythe);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddIngredient(ModContent.ItemType<IntermediateArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<ObsidianBlade>());
            recipe.AddRecipe();
            //bee/jungle
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.JungleSpores, 12);
            recipe.AddIngredient(ItemID.Stinger, 6);
            recipe.AddIngredient(ItemID.Hive, 8);
            recipe.AddIngredient(ModContent.ItemType<IntermediateArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BeeBlade>());
            recipe.AddRecipe();
        }
    }
}
