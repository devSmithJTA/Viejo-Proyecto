﻿namespace AplicacionPUNTONET
{
    public class Config
    {
        public static IConfigurationRoot GetConfiguracion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        public static string GetConString()
        {
            string ConString = "";
            var Conf = GetConfiguracion();
            ConString = Conf.GetSection("Data").GetSection("ConnectionString").Value;
            Console.WriteLine(ConString);
            return ConString;
        }
    }
}
