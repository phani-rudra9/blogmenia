using Blogmenia.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogmenia.Data
{

    public class RepositoryData : IRepositoryData
    {

        private readonly BlogmeniaDbContext db;
        public RepositoryData(BlogmeniaDbContext db)
        {
            this.db = db;
        }


        public Post GetPostById(int Id)
        {
            return db.Post.Find(Id);
        }

        public IEnumerable<Post> GetAllPost()
        {
            return db.Post.AsNoTracking();
        }

        public IEnumerable<Post> GetLatestPost()
        {
            return db.Post.AsNoTracking().OrderByDescending(m => m.Id);
        }

        public Post GetPostBySlug(string slug)
        {
            return db.Post.AsNoTracking().FirstOrDefault(m => m.Slug == slug);
        }

        public async Task<Post> GetPostById_Async(int Id)
        {
            return await db.Post.FindAsync(Id);
        }

        public ICollection<Postcategory> addPostCategory(string multiValue, int postId)
        {
            string[] sptValue = multiValue.Split(",");
            ICollection<Postcategory> pc = new Collection<Postcategory>(); ;

            foreach (var item in sptValue)
            {
                Postcategory obj = new Postcategory();
                obj.CategoryId = Convert.ToInt32(item);
                obj.PostId = postId;
                pc.Add(obj);
            }

            return pc;
        }


        public Post UpdatePost(Post updatedPost)
        {
            ICollection<Postcategory> pc = addPostCategory(updatedPost.MultipleCategory, updatedPost.Id);
            updatedPost.Postcategory = pc;



            var oldPostCategories = db.Postcategory.Where(b => EF.Property<int>(b, "PostId") == updatedPost.Id);
            foreach (var item in oldPostCategories)
            {
                updatedPost.Postcategory.Remove(item);
            }

            var entity = db.Post.Attach(updatedPost);
            entity.State = EntityState.Modified;
            return updatedPost;
        }

        public Post AddPost(Post newPost)
        {
            ICollection<Postcategory> pc = addPostCategory(newPost.MultipleCategory, newPost.Id);
            newPost.Postcategory = pc;
            db.Post.Add(newPost);
            return newPost;
        }


        public Post DeletePost(int Id)
        {
            var Post = GetPostById(Id);
            if (Post != null)
            {
                db.Post.Remove(Post);
            }
            return Post;
        }


        public Comments AddComments(Comments items)
        {
            db.Comments.Add(items);
            return items;
        }


        public Comments UpdateComments(Comments items)
        {

            var entity = db.Comments.Attach(items);
            entity.State = EntityState.Modified;
            return items;

        }

        public Subscriber GetSubscriberByEmail(string emailId)
        {
            return db.Subscriber.AsNoTracking().FirstOrDefault(m => m.EmailId.ToLower() == emailId.ToLower());
        }


        public bool IsSubscriberExist(string emailId)
        {
            return db.Subscriber.Any(m => m.EmailId.ToLower() == emailId.ToLower());
        }

        public Subscriber AddSubscriber(Subscriber newSubscriber)
        {
            db.Subscriber.Add(newSubscriber);
            return newSubscriber;
        }

        public Subscriber UpdateSubscriber(Subscriber updatedSubscriber)
        {
            var entity = db.Subscriber.Attach(updatedSubscriber);
            entity.State = EntityState.Modified;
            return updatedSubscriber;
        }





        public Subscriber DeleteSubscriber(int Id)
        {
            return null;
        }



        public int Commit()
        {
            return db.SaveChanges();
        }


        public IEnumerable<Post> GetHomePageList()
        {
            return db.Post.FromSqlRaw("Call GetHomepagePostList");
        }

        public Categories GetCategories_BySlug(string Slug)
        {
            return db.Categories.AsNoTracking().FirstOrDefault(a => a.Slug == Slug);
        }

        public IEnumerable<Categories> GetAllCategories()
        {
            return db.Categories.AsNoTracking().Where(a => a.IsActive == "Y").OrderBy(a => a.Name);
        }

        public Categories GetCategories_ById(int Id)
        {
            return db.Categories.FirstOrDefault(m => m.CategoryId == Id);
        }


        public Categories GetCategories_ById_ant(int Id)
        {
            return db.Categories.AsNoTracking().FirstOrDefault(m => m.CategoryId == Id);
        }

        public IEnumerable<Comments> GetCommentsByPostId(int Id)
        {
            return db.Comments.AsNoTracking().Where(v => v.PostId == Id && v.Status == "1");
        }
        public IEnumerable<Sitemaping> GetAllSiteMapPages()
        {
            return db.Sitemaping.AsNoTracking().Where(m => m.IsActive == 1);
        }

        public Demos GetDemoBySlug(string slug)
        {
            return db.Demos.AsNoTracking().FirstOrDefault(m => m.Slug == slug);

        }

        public Demos GetDemoById(int ID)
        {
            return db.Demos.FirstOrDefault(m => m.DemoId == ID);
        }

        public IEnumerable<Demos> GetAllDemoList()
        {
            return db.Demos.AsNoTracking();
        }

        public Categories UpdateCategory(Categories newCategory)
        {

            db.Categories.Update(newCategory);
            return newCategory;
        }

        public Categories AddCategory(Categories newCategory)
        {

            db.Categories.Add(newCategory);
            return newCategory;
        }

        public Demos UpdateDemo(Demos newData)
        {

            var entity = db.Demos.Attach(newData);
            entity.State = EntityState.Modified;
            return newData;
        }


        public Demos AddDemo(Demos newData)
        {
            db.Demos.Add(newData);
            return newData;
        }





        public IEnumerable<Subscriber> GetAllSubscriber()
        {
            return db.Subscriber.AsNoTracking();
        }

        public IEnumerable<Post> GetPost_BySlugType(string Filtertype, string Slug, int pageIndex, int rowCount)
        {
            return db.Post.FromSqlRaw("Call GetPost({0},{1},{2},{3})", Filtertype, Slug, pageIndex, rowCount);
        }
    }
}
