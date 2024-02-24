using System.Threading;

namespace Models.Utils;

public class IdGenerator
{
    private static int lastId = 0;

    public static int NewId()
    {
        return Interlocked.Increment(ref lastId);
    }
}