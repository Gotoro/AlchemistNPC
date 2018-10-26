using Terraria.ID;
using Terraria;
using System;
using System.Linq;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class LilithCharm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lilith Charm");
			Tooltip.SetDefault("Gives 15% magic bonus damage and 10% to critical strike chance"
			+ "\nDecreases mana usage by 25%"
			+ "\nIncreases max mana by 100"
			+ "\nIncreases mana regeneration rate greatly"
			+ "\nIncreases mana stars pickup range"
			+ "\nAutomatically uses mana potions"
			+ "\nYou shoot cluster of deadly bees while using magic weapons"
			+ "\nBees has low chance to heal you after hitting the enemy"
			+ "\nHide visual to disable bees"
			+ "\nDoesn't work with some very specific weapons");
			DisplayName.AddTranslation(GameCulture.Russian, "Оберег Лилит");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает магический урон на 15% и шанс критического удара\nУменьшает затраты маны на 25%\nУвеличивает максимальную ману на 100\nЗначительно ускоряет восстановление маны\nУвеличивает радиус сбора звёзд\nАвтоматически использует зелья маны\nВы выстреливает кучку смертоносных пчёл при использовании любого магического оружия\nПчёлы имеют шанс полечить вас после удара по противнику\nСмена видимости аксессуара выключает пчёл\nПоследнее не работает с некоторым специфическим оружием");
        }
	
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 1000000;
			item.rare = 11;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (!hideVisual)
			{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).LilithEmblem = true;
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).BeeHeal = true;
			}
			if (hideVisual)
			{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).LilithEmblem = false;
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).BeeHeal = false;
			}
			player.manaMagnet = true;
			player.magicDamage += 0.15f;
			player.magicCrit += 15;
			player.statManaMax2 += 100;
			player.manaFlower = true;
            player.manaCost -= 0.25f;
			++player.manaRegenDelayBonus;
            player.manaRegenBonus += 50;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "LilithEmblem");
			recipe.AddIngredient(null, "ChromaticCrystal", 4);
			recipe.AddIngredient(null, "SunkroveraCrystal", 4);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 4);
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("NightmareFuel")), 10);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("EndothermicEnergy")), 10);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 30);
			}
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
			{
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence")), 3);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence")), 3);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence")), 3);
			}
			if (!ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
			recipe.AddTile(null, "MateriaTransmutator");
			}
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
			recipe.AddTile(null, "MateriaTransmutatorMK2");
			}
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}