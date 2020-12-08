using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace MyCompLib
{
    public partial class MyComp : ComponentBase
    {
        private string imageUrl =
    "https://dummyimage.com/286x180/8EB1C7/FEFDFF.png&text=Awesome+Product";
        
        [Parameter]
        public string ProductName { get; set; } = "Awesome Product";
        [Parameter]
        public string ProductDescription { get; set; } = 
            "You won't believe how great this product is until you actually use it yourself.";
        [Parameter]
        public EventCallback<string> TextChanged { get; set; }

        [Inject]
        private ExampleJsInterop exampleJsInterop { get; set; }

        private async Task UpdateProductName()
        {
            // Call JS interop.
            var text = await exampleJsInterop.Prompt(ProductName);
            // Trigger the changed event.
            await TextChanged.InvokeAsync(text);
            // Set the property value.
            ProductName = text;
        }
    }
}