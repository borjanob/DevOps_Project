using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApplication.Models.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }

        public int MovieShowingId { get; set; }

        [ForeignKey("MovieShowingId")]
        [ValidateNever]
        public  MovieShowing MovieShowing{ get; set; }

        public int NumberOfTickets { get; set; }    

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        [ValidateNever]
        public ApplicationUser User { get; set; }
    }
}
