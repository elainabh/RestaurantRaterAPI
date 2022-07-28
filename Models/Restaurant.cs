using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RestaurantRaterAPI.Models
{
    public class Restaurant
    {
         [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Location { get; set; }
        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();
        public double AverageFoodScore
        {
            get
            {
                if (Ratings.Count == 0)
                {
                    return 0;
                }
                double total = 0.0;
                foreach (Rating rating in Ratings)
                {
                    total += rating.FoodScore;
                }
                return total / Ratings.Count;
            }
        }

        public double AverageAtmosphereScore
        {
            get
            {
                if (Ratings.Count == 0)
                {
                    return 0;
                }
                double total = 0.0;
                foreach (Rating rating in Ratings)
                {
                    total += rating.AtmosphereScore;
                }
                return total / Ratings.Count;
            }
        }

        public double AverageCleanlinessScore
        {
            get
            {
                if (Ratings.Count == 0)
                {
                    return 0;
                }
                double total = 0.0;
                foreach (Rating rating in Ratings)
                {
                    total += rating.CleanlinessScore;
                }
                return total / Ratings.Count;
            }
        }
        public float AverageTotalScore 
        {
            get 
            {
                if (Ratings.Count == 0)
                {
                    return 0;
                }
                float total = 0;
                foreach (Rating rating in Ratings)
                {
                    total += rating.TotalScore;
                }
            return total / Ratings.Count;
            }
        }
        }

    public class Rating
         {
             [Key]
             public int Id { get; set; }
             [Required]
             [ForeignKey("Restaurant")]
             public int RestaurantId { get; set; }
            [Required]
            public double FoodScore { get; set; }
            [Required]
            public double CleanlinessScore { get; set; }
            [Required]
            public double AtmosphereScore { get; set; }
            public float TotalScore { get; set; }
        }
    }
