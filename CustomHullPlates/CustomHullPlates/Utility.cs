using System;
using System.IO;
using UnityEngine;

namespace CustomHullPlates
{
	// Token: 0x02000005 RID: 5
	public class Utility
	{
		// Token: 0x0600000F RID: 15 RVA: 0x00002334 File Offset: 0x00000534
		public static Texture2D LoadTexture(string path, TextureFormat format, int width = 2, int height = 2)
		{
			bool flag = File.Exists(path);
			if (flag)
			{
				byte[] array = File.ReadAllBytes(path);
				Texture2D texture2D = new Texture2D(width, height, format, false);
				bool flag2 = texture2D.LoadImage(array);
				if (flag2)
				{
					return texture2D;
				}
			}
			return null;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002378 File Offset: 0x00000578
		public static Sprite TextureToSprite(Texture2D tex, Vector2 pivot = default(Vector2), float pixelsPerUnit = 100f, SpriteMeshType spriteType = default, Vector4 border = default)
		{
			return Sprite.Create(tex, new Rect(0f, 0f, (float)tex.width, (float)tex.height), pivot, pixelsPerUnit, 0u, spriteType, border);
		}
	}
}
