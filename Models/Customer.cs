using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Assignment.Models
{
    public class Customer
    {
        [JsonIgnore]
        [Key]
        public int CustomerId {get;set;}
        [Required]
        [StringLength(30, ErrorMessage="Name exceeds 30 characters.")]
        public string Name {get;set;}
        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage="Email exceeds 30 characters")]
        [RegularExpression(@"^[a-zA-Z0-9._-]{2,}@{1}[a-zA-Z0-9.-]{2,}\.+[a-zA-Z]{2,}$", ErrorMessage="Please enter a valid email address.")]
        public string Email {get;set;}
        [Required]
        public string Gender {get;set;}
        [JsonIgnore]
        [Required]
        [Display(Name = "Date Registered")]
        [CheckDate("01/01/2019","07/30/2019")]
        [DataType(DataType.Date)]
        public DateTime? Registered {get;set;}
        [NotMapped]
        public string DateRegistered {
            get
            {
                DateTime SafeDate = this.Registered ?? DateTime.MinValue;
                return SafeDate.ToString("dd/MM/yyyy");
            }
        }
        [JsonIgnore]
        public bool DayOne {get;set;}
        [JsonIgnore]
        public bool DayTwo {get;set;}
        [JsonIgnore]
        public bool DayThree {get;set;}
        [NotMapped]
        [Display(Name = "Days Attending")]
        public string DaysAttending {
            get
            {
                List<string> DaysAttending = new List<string> {};
                if (this.DayOne == true) DaysAttending.Add("Day 1");
                if (this.DayTwo == true) DaysAttending.Add("Day 2");
                if (this.DayThree == true) DaysAttending.Add("Day 3");
                return string.Join(", ", DaysAttending);
            }
        }
        [Display(Name = "Additional Request")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(100, ErrorMessage="Additional Request exceeds 100 characters.")]
        public string Request {get;set;}
    }

    public class CheckDateAttribute : ValidationAttribute
    {
        private DateTime start;
        private DateTime end;

        public CheckDateAttribute(string start, string end)
        {
            this.start = DateTime.Parse(start);
            this.end = DateTime.Parse(end);
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null || start > (DateTime)value || (DateTime)value > end)
            {
                return new ValidationResult($"Please enter a date between {start.ToString("dd MMMM yyyy")} and {end.ToString("dd MMMM yyyy")}.");
            }
            return ValidationResult.Success;
        }
    }

}