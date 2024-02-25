using Godot;
using System;
using System.Linq;

namespace Views.Extensions
{
    internal static class GodotExtensions
    {
        public static void Play(this AudioStreamPlayer player, string what)
        {
            player.Stream = ResourceLoader.Load<AudioStream>(what);
            player.Play();
        }

        public static Texture2D ToTexture(this Models.Item item)
        {
            if (item.Name == "null")
            {
                return null;
            }

            var candidateTexturePath = $"res://Assets/{item.Name}.png";

            if (!ResourceLoader.Exists(candidateTexturePath))
            {
                throw new ArgumentException(
                    $"No conversion to texture for {item.Name} " +
                    $"at {candidateTexturePath}");
            }

            return ResourceLoader.Load<Texture2D>(candidateTexturePath);
        }

        public static Models.Item ToItem(this Texture2D texture)
        {
            string name = texture.ResourcePath.Split("/").Last()
                .Replace(".png", string.Empty);

            return new Models.Item(name);
        }
    }
}
