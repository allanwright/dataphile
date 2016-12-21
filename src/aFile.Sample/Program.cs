using System;
using Microsoft.Extensions.DependencyInjection;
using aFile;

namespace aFile.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddFileStore("");
        }
    }
}