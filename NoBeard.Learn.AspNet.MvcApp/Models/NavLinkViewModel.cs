namespace NoBeard.Learn.AspNet.MvcApp.Models;

//public record NavLinkViewModel
//{
//    public string Title { get; set; }

//    public string ControllerName { get; set; }

//    public string ActionName { get; set; }
//}

public record NavLinkViewModel(
    string Title, 
    string ControllerName, 
    string ActionName);
