using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class Fungalosphere : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 120;
			item.ranged = true;
			item.width = 76;
			item.height = 36;
			item.useTime = 10;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.UseSound = SoundID.Item34;
			item.value = 1000000;
			item.rare = ItemRarityID.Purple;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("FungalosphereProjectile");
			item.shootSpeed = 8f;
			item.useAmmo = AmmoID.Gel;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fungalosphere");
			Tooltip.SetDefault("Consumes gel as ammo"
			+"\nInflicts Electrocute and Frostburn debuffs"
			+"\n33% chance not to consume gel");

            DisplayName.AddTranslation(GameCulture.Chinese, "凝胶喷射器");
            Tooltip.AddTranslation(GameCulture.Chinese, "消耗凝胶作为弹药\n造成触电和霜火Debuff\n33%的概率不消耗凝胶");
        }

		public override bool ConsumeAmmo(Player player)
		{
		return Main.rand.NextFloat() >= .33;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
		int numberProjectiles = 4;
		for (int i = 0; i < numberProjectiles; i++)
			{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
			Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("FungalosphereProjectile"), damage, knockBack, player.whoAmI);
			}
		for (int i = 0; i < numberProjectiles; i++)
			{
			Vector2 perturbedSpeed1 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
			Projectile.NewProjectile(position.X, position.Y, perturbedSpeed1.X, perturbedSpeed1.Y, mod.ProjectileType("FungalosphereProjectileDummy"), damage, knockBack, player.whoAmI);
			}
			return true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShroomiteBar, 20);
			recipe.AddIngredient(ItemID.SoulofLight, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddIngredient(ItemID.FragmentSolar, 5);
			recipe.AddIngredient(ItemID.FragmentNebula, 5);
			recipe.AddIngredient(ItemID.FragmentVortex, 5);
			recipe.AddIngredient(ItemID.FragmentStardust, 5);
			recipe.AddIngredient(ItemID.Flamethrower);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
