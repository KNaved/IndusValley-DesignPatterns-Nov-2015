using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRental
{
    public abstract class MovieBase
    {
        private readonly string _title;

        protected MovieBase(string title)
        {
            _title = title;
        }


        public abstract double getAmount(int daysRented);

        public virtual int getFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }

    public class ChildrensMovie : MovieBase
    {
        public ChildrensMovie(string title) : base(title)
        {
            
        }

        public override double getAmount(int daysRented)
        {
            double thisAmount = 1.5;
            if (daysRented > 3)
                thisAmount += (daysRented - 3) * 1.5;
            return thisAmount;
            
        }
    }

    public class RegularMovie : MovieBase
    {
        public RegularMovie(string title) : base(title)
        {
            
        }
        public override double getAmount(int daysRented)
        {
            double thisAmount = 2;
            if (daysRented > 2)
                thisAmount += (daysRented - 2) * 1.5;
            return thisAmount;
        }
    }

    public class NewReleaseMovie : MovieBase
    {
        public NewReleaseMovie(string title) : base(title)
        {
        }

        public override double getAmount(int daysRented)
        {
            return daysRented * 3;
        }

        public override int getFrequentRenterPoints(int daysRented)
        {
            return daysRented > 1 ? 2 : 1;
        }
    }

    

    public class Rental
    {
        private MovieBase _movie;
        private int _daysRented;

        public Rental(MovieBase movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }
        public int getDaysRented()
        {
            return _daysRented;
        }
        public MovieBase getMovie()
        {
            return _movie;
        }
        public double getAmount()
        {
            return getMovie().getAmount(this.getDaysRented());
        }

        public int getFrequentRenterPoints()
        {
            return getMovie().getFrequentRenterPoints(this.getDaysRented());
        }

    }

    public enum MovieTypeEnum
    {
        Childrens,
        NewRelease,
        Regular
    }

    public class Customer
    {
        private String _name;
        private List<Rental> _rentals = new List<Rental>();

        public Customer(String name)
        {
            _name = name;
        }

        public void addRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        public String getName()
        {
            return _name;
        }

        public String statement()
        {
            String result = "Rental Record for " + getName() + "\n";
            foreach (var rental in _rentals)
            {
                //show figures for this rental
                result += "\t" + rental.getMovie().Title + "\t" + rental.getAmount() + "\n";
            }
            //add footer lines
            result += "Amount owed is " + getTotalAmount() + "\n";
            result += "You earned " + getTotalFrequentRenterPoints() + " frequent renter points";
            return result;

        }

        private double getTotalAmount()
        {
            double totalAmount = 0;
            foreach (var rental in _rentals)
            {
                totalAmount += rental.getAmount();
            }
            return totalAmount;
        }

        private int getTotalFrequentRenterPoints()
        {
            int frequentRenterPoints = 0;
            foreach (var rental in _rentals)
            {
                // add frequent renter points
                frequentRenterPoints += rental.getFrequentRenterPoints();
            }
            return frequentRenterPoints;
        }
    }

    public class MovieFactory{
        public MovieBase Create(MovieTypeEnum movieType, string title)
        {
            switch (movieType)
            {
                case MovieTypeEnum.Childrens:
                    return new ChildrensMovie(title);
                case MovieTypeEnum.NewRelease:
                    return new NewReleaseMovie(title);
                case MovieTypeEnum.Regular:
                    return new RegularMovie(title);
                default:
                    throw new Exception("Invalid movie type");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
