namespace FindFirstCommonParentWithDFSGeneric.ConsoleUI.IoC
{
    using Ninject.Modules;

    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.ConsoleIO;
    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.ConsoleIO.Contracts;
    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.Contracts;
    using FindFirstCommonParentWithDFSGeneric.Data.Repositories;
    using FindFirstCommonParentWithDFSGeneric.Data.Repositories.Contracts;
    using FindFirstCommonParentWithDFSGeneric.Logic;
    using FindFirstCommonParentWithDFSGeneric.Logic.Contracts;
    using FindFirstCommonParentWithDFSGeneric.Models;
    using FindFirstCommonParentWithDFSGeneric.Models.Contracts;

    public class FindFirstCommonParentWithDFSGenericModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IEngine>().To<Engine>();
            this.Bind<INode>().To<Node>();
            this.Bind<IGenericRepository<INode>>().To<GenericRepositoryWithDictionary<INode>>().InSingletonScope();
            this.Bind<ITreeTraversal>().To<DFSTreeTraversal>();
            this.Bind<IRootNodeFinder>().To<RootNodeFinder>();
            this.Bind<IFirstCommonNodeFinder>().To<FirstCommonNodeFinder>();
            this.Bind<ICommandFactory>().To<CommandFactory>();
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<IReader>().To<ConsoleReader>();
        }
    }
}
