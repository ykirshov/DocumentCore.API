﻿using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace DocumentCore.API.Extensions
{
	public static class ImageExtension
	{
		public static byte[] ToByteArray(this Image image, ImageFormat format)
		{
			using (MemoryStream ms = new MemoryStream())
			{
				image.Save(ms, format);
				return ms.ToArray();
			}
		}
	}
}