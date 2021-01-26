using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DaGrasso.Data.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        [Display(Name ="First Name")]
        [Required(ErrorMessage = "Podaj swoje imie")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Podaj swoje nazwisko")]
        [StringLength(30,MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Podaj nazwe ulicy")]
        [StringLength(50)]
        public string Street { get; set; }

        [Required(ErrorMessage = "Podaj swój adres")]
        [StringLength(50)]
        public string BuildingNumber { get; set; }

        public string HouseNumber { get; set; }

        [Required(ErrorMessage = "Podaj kod pocztowy")]
        [Display (Name ="Zip Code")]
        [StringLength(10,MinimumLength = 4)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Podaj swoj nr telefonu")]
        [StringLength(14)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="Podaj swoj adres e-mail")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public string OrderTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderPlaced { get; set; }


    }
}
