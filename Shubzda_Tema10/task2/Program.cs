using System;
class HTMLPage
{
    public string Header;
    public string Body;
    public string Footer;
    public void Show()
    {
        Console.WriteLine(Header);
        Console.WriteLine(Body);
        Console.WriteLine(Footer);
    }
}
interface IHTMLBuilder
{
    void BuildHeader();
    void BuildBody();
    void BuildFooter();
    HTMLPage GetPage();
}
class BasicHTMLBuilder : IHTMLBuilder
{
    HTMLPage page = new HTMLPage();
    public void BuildHeader()
    {
        page.Header = "<html><head><title>Page</title></head><body>";
    }
    public void BuildBody()
    {
        page.Body = "<h1>Обычная HTML страница</h1>";
    }
    public void BuildFooter()
    {
        page.Footer = "</body></html>";
    }
    public HTMLPage GetPage()
    {
        return page;
    }
}
class BootstrapHTMLBuilder : IHTMLBuilder
{
    HTMLPage page = new HTMLPage();
    public void BuildHeader()
    {
        page.Header = "<html><head><title>Bootstrap</title></head><body class='container'>";
    }
    public void BuildBody()
    {
        page.Body = "<button class='btn btn-primary'>Кнопка</button>";
    }
    public void BuildFooter()
    {
        page.Footer = "</body></html>";
    }
    public HTMLPage GetPage()
    {
        return page;
    }
}
class MaterialUIHTMLBuilder : IHTMLBuilder
{
    HTMLPage page = new HTMLPage();
    public void BuildHeader()
    {
        page.Header = "<html><head><title>Material UI</title></head><body>";
    }
    public void BuildBody()
    {
        page.Body = "<div class='mui-card'>Material UI page</div>";
    }
    public void BuildFooter()
    {
        page.Footer = "</body></html>";
    }
    public HTMLPage GetPage()
    {
        return page;
    }
}
class Director
{
    public HTMLPage CreatePage(IHTMLBuilder builder)
    {
        builder.BuildHeader();
        builder.BuildBody();
        builder.BuildFooter();
        return builder.GetPage();
    }
}
interface IPageStrategy
{
    void Use(HTMLPage page);
}
class ShowStrategy : IPageStrategy
{
    public void Use(HTMLPage page)
    {
        page.Show();
    }
}
class SaveStrategy : IPageStrategy
{
    public void Use(HTMLPage page)
    {
        Console.WriteLine("Страница сохранена");
        page.Show();
    }
}
class PageContext
{
    public IPageStrategy Strategy;
    public PageContext(IPageStrategy strategy)
    {
        Strategy = strategy;
    }
    public void Execute(HTMLPage page)
    {
        Strategy.Use(page);
    }
}
class Program
{
    static void Main()
    {
        Director d = new Director();
        HTMLPage p1 = d.CreatePage(new BasicHTMLBuilder());
        HTMLPage p2 = d.CreatePage(new BootstrapHTMLBuilder());
        HTMLPage p3 = d.CreatePage(new MaterialUIHTMLBuilder());
        PageContext c1 = new PageContext(new ShowStrategy());
        PageContext c2 = new PageContext(new SaveStrategy());
        c1.Execute(p1);
        Console.WriteLine();
        c1.Execute(p2);
        Console.WriteLine();
        c2.Execute(p3);
    }
}