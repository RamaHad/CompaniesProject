using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Repo
{
    public class ItemRepo : IItemIRepo
    {
        private readonly ApplicationDbContext _context;

        public ItemRepo()
        {
            _context =new ApplicationDbContext ();
        }

        public ItemDto Add(ItemDto dto)
        {
            try
            {
                Item item = new();
                Guid guid = Guid.NewGuid();
                item.Id = guid;
                item.Name = dto.Name;
                _context.Add(item);
                _context.SaveChanges();
                return dto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
