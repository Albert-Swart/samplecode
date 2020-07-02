namespace Strike.Common.Objects.Factories
{
    public interface ISpecificationFactory<TInstance, TSpecification>
    {
        TInstance CreateFromSpecification(TSpecification specification);
    }
}