using Terraria;
using Terraria.ModLoader;
using AlchemistNPC.NPCs;
using Terraria.Localization;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace AlchemistNPC.Buffs
{
	public class Electrocute : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Electrocute");
			Description.SetDefault("High voltage is going through you..");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Электрошок");
			Description.AddTranslation(GameCulture.Russian, "Через вас проходит высокое напряжение");
            DisplayName.AddTranslation(GameCulture.Chinese, "触电");
            Description.AddTranslation(GameCulture.Chinese, "掉血ing");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
			npc.GetGlobalNPC<ModGlobalNPC>(mod).electrocute = true;
			if (Main.rand.Next(20) == 0)
			{
			npc.velocity.X = 0.1f;
			npc.velocity.Y = 0.1f;
			}
        }
	}
}
