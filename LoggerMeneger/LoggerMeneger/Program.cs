using Serilog;
using Serilog.Context;

class MyClass
{
    static void Main()
    {
        string connStr = @"Data Source=.;Database=LogDB;user=Test;password=123";
        string tblName = "Logs";
        Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.MSSqlServer(connStr, tblName)
                    .CreateLogger();
        Log.Information("infoi orinak");
        try
        {
            int a = 23;
            int b = 0;
            Log.Debug($"Values are {a} and {b}");
            int c = a/b;
        }
        catch (Exception ex)
        {
            LogContext.PushProperty("user", "sdffsf");
            Log.Error(ex,"Some error!");
        }
        Log.CloseAndFlush();
        Console.WriteLine("verj");
        Console.ReadKey();
    }

}
