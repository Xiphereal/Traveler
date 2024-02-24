using Godot;
using System;

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
            return item.Name switch
            {
                "Map" => ResourceLoader.Load<Texture2D>("res://Assets/Map"),
                _ => throw new ArgumentException(
                    $"No conversion to texture for {item.Name}"),
            };
        }
    }
}
