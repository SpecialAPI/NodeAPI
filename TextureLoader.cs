using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using UnityEngine;
using System.Text;

namespace NodeAPI
{
    public static class TextureLoader
    {
        public static Texture2D GetTextureFromResource(string resourceName)
        {
            string file = resourceName;
            file = file.Replace("/", ".");
            file = file.Replace("\\", ".");
            byte[] bytes = ExtractEmbeddedResource(file);
            if (bytes == null)
            {
                return null;
            }
            Texture2D texture = new Texture2D(1, 1, TextureFormat.RGBA32, false);
            texture.LoadImage(bytes);
            texture.filterMode = FilterMode.Point;
            string name = file.Substring(0, file.LastIndexOf('.'));
            if (name.LastIndexOf('.') >= 0)
            {
                name = name.Substring(name.LastIndexOf('.') + 1);
            }
            texture.name = name;
            return texture;
        }

        public static byte[] ExtractEmbeddedResource(string filePath)
        {
            filePath = filePath.Replace("/", ".");
            filePath = filePath.Replace("\\", ".");
            var baseAssembly = Assembly.GetCallingAssembly();
            using (Stream resFilestream = baseAssembly.GetManifestResourceStream(filePath))
            {
                if (resFilestream == null)
                {
                    return null;
                }
                byte[] ba = new byte[resFilestream.Length];
                resFilestream.Read(ba, 0, ba.Length);
                return ba;
            }
        }
    }
}
