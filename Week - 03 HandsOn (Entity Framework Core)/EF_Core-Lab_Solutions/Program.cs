class Program
{
    static async Task Main(string[] args)
    {
        Lab1_IntroORM.Run();
        Lab2_DbContext.Run();
        Lab3_Migrations.Run();
        await Lab4_InsertData.RunAsync();
        await Lab5_RetrieveData.RunAsync();  
    }
}
