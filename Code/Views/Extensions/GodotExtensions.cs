using Godot;

namespace Views.Extensions
{
    internal static class GodotExtensions
    {
        public static void Play(this AudioStreamPlayer player, string what)
        {
            player.Stream = ResourceLoader.Load<AudioStream>(what);
            player.Play();
        }
    }
}
