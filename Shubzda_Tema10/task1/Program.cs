using System;
using System.Collections.Generic;
class FontManager
{
    private static FontManager instance;
    private Dictionary<string, string> fonts = new Dictionary<string, string>();
    private FontManager() { }
    public static FontManager GetInstance()
    {
        if (instance == null)
            instance = new FontManager();
        return instance;
    }
    public void LoadFont(string fontName)
    {
        if (!fonts.ContainsKey(fontName))
        {
            fonts[fontName] = fontName;
            Console.WriteLine("Загружен шрифт: " + fontName);
        }
    }
    public string GetFont(string fontName)
    {
        if (fonts.ContainsKey(fontName))
            return fonts[fontName];
        return null;
    }
}
class Program
{
    static void Main()
    {
        FontManager f1 = FontManager.GetInstance();
        FontManager f2 = FontManager.GetInstance();
        f1.LoadFont("Arial");
        f1.LoadFont("Times");
        Console.WriteLine(f2.GetFont("Arial"));
        Console.WriteLine(object.ReferenceEquals(f1, f2));
    }
}