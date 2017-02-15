namespace FindFirstCommonParentWithDFSGeneric.ConsoleUI
{
    using Ninject;

    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.IoC;

    public class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel(new FindFirstCommonParentWithDFSGenericModule());
            var engine = kernel.Get<Engine>();

            engine.Run();
        }          
    }
}
