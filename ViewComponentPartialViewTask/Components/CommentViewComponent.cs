using Microsoft.AspNetCore.Mvc;
using ViewComponentPartialViewTask.Models;

namespace ViewComponentPartialViewTask.Components
{
    public class CommentViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int id) 
        { 
            HttpClient client = new HttpClient(); 
            
            ICollection<CommentViewModel> comments = 
                client.GetFromJsonAsync<ICollection<CommentViewModel>>
                ("https://jsonplaceholder.typicode.com/comments?postId=" + id).Result; 
            
            return View("~/views/components/comment.cshtml", comments); }
    }
}
