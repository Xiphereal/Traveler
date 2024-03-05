using Godot;

namespace Views;

public partial class Roadmap : Node
{
    private readonly Models.Roadmap roadmap;

    public Roadmap()
    {
        roadmap = new Models.Roadmap();

        SkipIntro();
    }

    private void SkipIntro()
    {
        roadmap.NextStop();
    }

    public string NextStop() => roadmap.NextStop();
}
