namespace Utils
{
    public static class StringExtensions
    {
        public static string WithWeight(this string str, Weight weight)
        {
            return $"<font-weight=\"{(int)weight}\">{str}</font-weight>";
        }
        
        public static string WithColor(this string str, string color)
        {
            return $"<color={color}>{str}</color>";
        }
    }
    
    public enum Weight
    {
        Thin = 100,
        ExtraLight = 200,
        Light = 300,
        Normal = 400,
        Medium = 500,
        SemiBold = 600,
        Bold = 700,
        Boldest = 900
    }
}