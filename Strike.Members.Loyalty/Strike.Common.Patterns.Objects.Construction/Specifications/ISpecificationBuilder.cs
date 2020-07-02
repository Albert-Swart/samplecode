namespace Strike.Common.Objects.Specifications
{
    public interface ISpecificationBuilder<TSpecification>
    {
        TSpecification Build();
    }
}