using System;
using System.Linq;
using System.Reflection;

public class SongFactory : ISongFactory
{
    public ISong CreateSong(string name, TimeSpan duration)
    {
        Type clazz = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == "Song");
        var ctors = clazz.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        ISong song = (ISong)ctors[0].Invoke(new object[] { name, duration });

        return song;
    }
}