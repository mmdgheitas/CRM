using Interface.Models.Factor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interface.Models.Google
{
    public class Locations
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter city name")]
        [Display(Name = "City Name")]
        public string CityName { get; set; }
        [Required(ErrorMessage = "Please enter city latitude")]
        public double Latitude { get; set; }
        [Required(ErrorMessage = "Please enter city longitude ")]
        public double Longitude { get; set; }
        public string Description { get; set; }
        public string Shoplatitude { get; set; }
        public string Shoplongitude { get; set; }
        public string ShopAddress { get; set; }
        public List<RequestEstimateAppointmentModel> ListAppointment { get; set; }
        public List<User> ListUsers { get; set; }
        public List<UserLocation> UserLocations { get; set; }
        public string CurrentUserImage { get; set; }


    }
    public class UserLocation
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string Image { get; set; }
    }
}