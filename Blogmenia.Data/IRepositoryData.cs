using Blogmenia.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blogmenia.Data
{
    public interface IRepositoryData
    {
        int Commit();

        #region Post 

        IEnumerable<Post> GetAllPost();
        IEnumerable<Post> GetLatestPost();

        IEnumerable<Post> GetAllFeaturedPost();

        Task<Post> GetPostById_Async(int Id);
        Post GetPostBySlug(string slug);
        Post GetPostById(int Id);
        IEnumerable<Post> GetHomePageList();
        Post UpdatePost(Post updatedPost);
        Post AddPost(Post newPost);
        Post DeletePost(int id);

        #endregion



        #region Comments 
        IEnumerable<Comments> GetCommentsByPostId(int Id);
        Comments AddComments(Comments items);
        Comments UpdateComments(Comments items);

        #endregion





        #region Category      
        Categories GetCategories_BySlug(string Slug);
        IEnumerable<Categories> GetAllCategories();
        Categories GetCategories_ById(int Id);
        Categories GetCategories_ById_ant(int Id);
        Categories UpdateCategory(Categories newCategory);
        Categories AddCategory(Categories newCategory);
        IEnumerable<Post> GetPost_BySlugType(string Filtertype, string Slug, int  pageIndex, int rowCount);

        #endregion





        #region Demos
        Demos GetDemoBySlug(string slug);
        Demos GetDemoById(int ID);
        IEnumerable<Demos> GetAllDemoList();

        Demos UpdateDemo(Demos newData);
        Demos AddDemo(Demos newData);

        #endregion


        #region Subscriber
        Subscriber AddSubscriber(Subscriber newSubscriber);
        Subscriber UpdateSubscriber(Subscriber newSubscriber);
        Subscriber DeleteSubscriber(int Id);

        Subscriber GetSubscriberByEmail(string emailID);
        IEnumerable<Subscriber> GetAllSubscriber();
        bool IsSubscriberExist(string emailID);

        #endregion
        IEnumerable<Sitemaping> GetAllSiteMapPages();
    }
}
