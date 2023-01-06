 public class CodeService
{
    private const string Characters = "ACDEFGHKLMNPRTXYZ234579";
    private const string Key = "5386";
    private readonly List<string> _codes = new();

    public string GenerateUniqueCode()
    {
        string code;
        var random = new Random();

        while (true)
        {
            code = "";
            for (int i = 0; i < 4; i++)
            {
                var rnd = random.Next(Characters.Length);
                code += Characters[rnd];
                code += Characters[Math.Abs(rnd - Convert.ToInt32(Key[i].ToString()))];
            }

            if (_codes.Contains(code)) continue;
            _codes.Add(code);
            break;
        }

        return code;
    }

    public static bool ValidateCode(string code)
    {
        if (code.Length != 8)
        {
            return false;
        }

        for (var i = 0; i < 4; i++)
        {
            if (!Characters.IndexOf(code[2 * i + 1])
                    .Equals(Math.Abs(Convert.ToInt32(Key[i].ToString()) - Characters.IndexOf(code[2 * i]))))
            {
                return false;
            }
        }

        return true;
    }
}