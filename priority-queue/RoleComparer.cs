namespace PriorityQueueExample;

public class RoleComparer : IComparer<string>
{
    public int Compare(string? roleA, string? roleB)
    {
        if (roleA == roleB)
            return 0;

        return roleA switch
        {
            "admin" => -1,
            "premium" => -1,
            _ => 1
        };
    }
}