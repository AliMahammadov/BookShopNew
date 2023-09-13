using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopViewModel.Entites
{
    public class BasketContactVM
    {
        [Required, MaxLength (15),MinLength(3)]
        public string Name { get; set; }
        [MaxLength(30), MinLength(5)]
        public string? Surname { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required, MaxLength(20)]
        public string Phone { get; set; }
        [MinLength(5)]
        public string? Message { get; set; }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public float BookPrice { get; set; }
    }
}
