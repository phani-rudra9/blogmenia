using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;



namespace Blogmenia.Core
{
    public class MetaTags
    {
        public MetaTags(IOptions<AppDefaultSetting> options)
        {
            Title = options.Value.DefaultTitle;
            Keywords = options.Value.DefaultKeywords;
            Description = options.Value.DefaultDescription;
            Web_Url = options.Value.BaseUrl;
            BaseUrl = options.Value.BaseUrl;

        }
        public string Title { get; set; }
        public string FeaturedImg { get; set; }
        public string Web_Url { get; set; }

        public string Description { get; set; }

        public string Keywords { get; set; }

        public string PrimaryCategory { get; set; }

        public string PublishDate { get; set; }

        public string ModifyDate { get; set; }
        public string BaseUrl { get; set; }
    }
}
