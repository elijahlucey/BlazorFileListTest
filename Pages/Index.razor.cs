using System.Threading.Tasks;
using BlazorFileListTest.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BlazorFileListTest.Pages {
    public class IndexBase : ComponentBase {
        protected IndexViewModel _vm;

        protected override async Task OnInitializedAsync() {
            await Initialize();
        }

        protected override async Task OnParametersSetAsync() {
            await Initialize();
        }

        private async Task Initialize() {
            _vm = new IndexViewModel();

            // the real application does async stuff in here
        }

        protected void AddBlankUpload() {
            var upload = new UploadViewModel();
            // not sure why we have to manually force the view to update here
            upload.Remove += (sender, e) => {
                _vm.Uploads.Remove(upload);
                foreach(UploadViewModel vm in _vm.Uploads) {
                    System.Diagnostics.Debug.Print(vm.ImageFile.ReadFileInfoAsync().GetAwaiter().GetResult().Name);
                }
                StateHasChanged();
            };
            upload.Changed += (sender, e) => {
                StateHasChanged();
            };

            _vm.Uploads.Add(upload);
        }
    }
}