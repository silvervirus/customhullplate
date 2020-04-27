using System;
using System.IO;
using Oculus.Newtonsoft.Json;
using UnityEngine;

namespace CustomHullPlates
{
	// Token: 0x02000004 RID: 4
	public class CustomHullPlate
	{
		// Token: 0x0600000C RID: 12 RVA: 0x00002248 File Offset: 0x00000448
		public bool LoadInfo(string path)
		{
			Console.WriteLine(path + "\\info.json");
			string path2 = path + "/info.json";
			string value = File.ReadAllText(path2);
			CustomHullPlateInfo info = JsonConvert.DeserializeObject<CustomHullPlateInfo>(value);
			this.Info = info;
			return true;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002290 File Offset: 0x00000490
		public GameObject GetHullPlate()
		{
			bool flag = this.Texture == null;
			GameObject result;
			if (flag)
			{
				result = null;
			}
			else
			{
				GameObject gameObject = Resources.Load<GameObject>("Submarine/Build/DioramaHullPlate");
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(gameObject);
				MeshRenderer component = Radical.FindChild(gameObject2, "Icon").GetComponent<MeshRenderer>();
				component.material.mainTexture = this.Texture;
				PrefabIdentifier component2 = gameObject2.GetComponent<PrefabIdentifier>();
				component2.ClassId = this.Info.InternalName;
				TechTag component3 = gameObject2.GetComponent<TechTag>();
				component3.type = this.TechType;
				Constructable component4 = gameObject2.GetComponent<Constructable>();
				component4.techType = this.TechType;
				result = gameObject2;
			}
			return result;
		}

		// Token: 0x04000005 RID: 5
		public CustomHullPlateInfo Info;

		// Token: 0x04000006 RID: 6
		public TechType TechType;

		// Token: 0x04000007 RID: 7
		public Texture2D Texture;

		// Token: 0x04000008 RID: 8
		public Atlas.Sprite Icon;
	}
}
