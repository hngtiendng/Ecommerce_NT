using CustomerSite.Services.Interfaces;
using CustomerSite.ViewComponents;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using SharedVm;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace XUniteTest.ViewComponent
{
    public class CategoryTest
    {
        [Fact]
        public async Task getCategoryViewComponent_Success()
        {
            //Arrange View Component
            var httpContext = new DefaultHttpContext();
            var viewContext = new ViewContext();
            viewContext.HttpContext = httpContext;
            var viewComponentContext = new ViewComponentContext();
            viewComponentContext.ViewContext = viewContext;

            //Arrange Mock Client
            var categoryApiClientMock = new Mock<ICategoryApiClient>();
            categoryApiClientMock.Setup(c => c.GetAllCategory()).Returns(getCategoriesValue());
            var viewComponent = new CategoryViewComponent(categoryApiClientMock.Object);

            //Act - Check final result is viewcomponent
            var result = viewComponent.InvokeAsync();
            var createdAtActionResult = await Assert.IsType<Task<IViewComponentResult>>(result);
        }

        private Task<IList<CategoryVm>> getCategoriesValue()
        {
            IList<CategoryVm> categoriesValue = new List<CategoryVm>();
            return Task.FromResult(categoriesValue);
        }
    }
}
