# BlazorFileListTest
Illustration of a problem I've been having trying to work with a container of uploads in Blazor Server using Tewr's BlazorFileReader library. Just a simple page allowing uploads of multiple image files one by one with the ability to remove entries.

To see why I created this repository, add multiple file entries that can be visually distinguished (via filename, image content, or both) and try to remove an entry that isn't the last one (i.e. if a list contains 0.jpg, 1.jpg, 2.jpg, choose any entry to delete except for 2.jpg). No matter which entry you choose to delete, the final entry will be removed from the list.

But wait--it gets more complicated. If you try to debug this process, you'll find that the proper entry is indeed being removed from the `List<UploadViewModel>` stored in `IndexViewModel`. Thus, the bug only manifests itself through the Blazor-generated HTML; everything on the back end appears to be correct.

I am open to the possibility of this being my fault, but I also understand how new Blazor and the BlazorFileReader library are, so I have suspicions that the bug is caused by external code. Hopefully we can get to the bottom of this.
