namespace ProgramSystem.Data.Repository.Factories
{
    public interface ISqlLiteRepositoryContextFactory
    {
        RepositoryContext Create();
    }
}