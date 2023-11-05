public class Computer
{
    private List<string> _parts = new List<string>();

    public void Add(string part)
    {
        this._parts.Add(part);
    }

    public override string ToString()
    {
        string str = string.Empty;

        for (int i = 0; i < this._parts.Count; i++)
        {
            str += this._parts[i] + ", \n";
        }

        str = str.Remove(str.Length - 2); // removing last ",c"

        return "Computer parts: \n" + str;
    }
}
