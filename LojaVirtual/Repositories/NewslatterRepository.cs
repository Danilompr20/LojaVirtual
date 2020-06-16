using LojaVirtual.Database;
using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class NewslatterRepository: BaseRepository<NewsletterEmail>, INewslatterRepository
    {
        private LojaVirtualContext _context;
        public NewslatterRepository(LojaVirtualContext context) : base(context)
        {

        }
    }
}
