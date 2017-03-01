namespace contracts.backend
{
    using Nancy;

    public class ContractsModule : NancyModule
    {
        public ContractsModule()
        {
            Get("/contracts", _ => "contracts!");
        }
    }
}
