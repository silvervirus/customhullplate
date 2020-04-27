using System;
using System.Collections.Generic;
using System.IO;
using SMLHelper.V2;
using SMLHelper.V2.Crafting;
using SMLHelper.V2.Handlers;
using UnityEngine;

namespace CustomHullPlates
{
	// Token: 0x02000002 RID: 2
	public class Main
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static void Patch()
		{
			Main.LoadHullplates();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000205C File Offset: 0x0000025C
		public static void LoadHullplates()
		{
			string path = ".\\QMods\\CustomHullPlates\\HullPlates";
			string[] directories = Directory.GetDirectories(path);
			foreach (string text in directories)
			{
				CustomHullPlate customHullPlate = new CustomHullPlate();
				Console.WriteLine(customHullPlate.LoadInfo(text));
				Texture2D texture = Utility.LoadTexture(Path.Combine(text, "texture.png"), default, 2, 2);
				Texture2D texture2D = Utility.LoadTexture(Path.Combine(text, "icon.png"), default, 2, 2);
				customHullPlate.Icon = new Atlas.Sprite(texture2D);
				customHullPlate.Texture = texture;
				customHullPlate.TechType = TechTypeHandler.AddTechType(customHullPlate.Info.InternalName, customHullPlate.Info.DisplayName, customHullPlate.Info.Description);
				
				SpriteHandler.RegisterSprite(customHullPlate.TechType, customHullPlate.Icon);
				CraftDataHandler.AddBuildable(customHullPlate.TechType);
				CraftDataHandler.AddToGroup(TechGroup.Miscellaneous, TechCategory.MiscHullplates, customHullPlate.TechType);
				var techData = new TechData()
				{
					craftAmount = 1,
					Ingredients = new List<Ingredient>
					{
						new Ingredient(TechType.Titanium, 2)
					}
				};
				CraftDataHandler.SetTechData(customHullPlate.TechType, techData);
				Console.WriteLine(string.Format("[CustomHullPlates] Loaded Hull Plate: {0} succesfully!", customHullPlate.Info.InternalName));
			}
		}

		// Token: 0x04000001 RID: 1
		private static List<CustomHullPlate> loadedHullPlates = new List<CustomHullPlate>();
	}
}
