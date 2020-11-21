using System;
using System.Collections.Generic;
using System.Text;

namespace Blogmenia.Data
{
  public   class clsCommon
    {
        private readonly IRepositoryData repositoryData;

        public clsCommon(IRepositoryData repositoryData )
        {
            this.repositoryData = repositoryData;
        }



    }
}
