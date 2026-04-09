using System;
interface IImageFilter
{
    void ApplyFilter(string filterName);
}
interface IVideoFilter
{
    void ApplyFilter(string filterName);
}
class MediaProcessor : IImageFilter, IVideoFilter
{
    void IImageFilter.ApplyFilter(string filterName)
    {
        Console.WriteLine("Фильтр для изображения: " + filterName);
    }
    void IVideoFilter.ApplyFilter(string filterName)
    {
        Console.WriteLine("Фильтр для видео: " + filterName);
    }
}
class Program
{
    static void Main()
    {
        MediaProcessor m = new MediaProcessor();
        IImageFilter img = m;
        IVideoFilter vid = m;
        img.ApplyFilter("Blur");
        vid.ApplyFilter("Sharpen");
    }
}