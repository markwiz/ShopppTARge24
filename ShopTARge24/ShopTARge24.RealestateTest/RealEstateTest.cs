namespace ShopTARge24.RealestateTest
{

public class RealEstateTest
    {
        [Fact]
        public void Test1()
        RealEstateDto dto = new()
        {
            Title = "Test Property",
            Description = "A lovely test property",
            Price = 250000,
            Address = "123 Test St, Testville",
            Bedrooms = 3,
            Bathrooms = 2,
            SquareFeet = 1500
        };

        var result = await Svc<IRealEstateServices>().Create(dto);

        Assert.Notnull(result);
        {
    }
}