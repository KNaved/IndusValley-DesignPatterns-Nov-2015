using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRental
{

    public abstract class PriceBase
    {
        private readonly int _priceCode;

        protected PriceBase(int priceCode)
        {
            _priceCode = priceCode;
        }

        public int getPriceCode()
        {
            return _priceCode;
        }

        public abstract double getAmount(int daysRented);
    }

    public class ChildrenMoviePrice : PriceBase
    {
        public ChildrenMoviePrice(int priceCode) : base(priceCode)
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

    public class NewMoviePrice : PriceBase
    {
        public NewMoviePrice(int priceCode) : base(priceCode)
        {
        }

        public override double getAmount(int daysRented)
        {
            return  daysRented * 3;
        }
    }

    public class RegularMoviePrice : PriceBase
    {
        public RegularMoviePrice(int priceCode) : base(priceCode)
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

    public interface IPriceFactory
    {
        PriceBase CreatePrice(int priceCode);
    }

    public class PriceFactory : IPriceFactory
    {
        public PriceBase CreatePrice(int priceCode)
        {
            PriceBase _price = null;
            switch (priceCode)
            {
                case 2:
                    _price = new ChildrenMoviePrice(priceCode);
                    break;
                case 1:
                    _price = new NewMoviePrice(priceCode);
                    break;
                case 0:
                    _price = new RegularMoviePrice(priceCode);
                    break;
            }
            return _price;
        }
    }

    public class Movie {

       public const  int  CHILDRENS = 2;
       public const  int  REGULAR = 0;
       public const  int  NEW_RELEASE = 1;


       private PriceBase _price;

       private int _priceCode;
            private string _title;
        private readonly IPriceFactory _priceFactory;

        public Movie(String title, int priceCode, IPriceFactory priceFactory) {
           _title = title;
                _priceFactory = priceFactory;
                setPrice(priceCode);
       }

        private void setPrice(int priceCode)
        {
            this._price = _priceFactory.CreatePrice(priceCode);
        }
					
       public int PriceCode {
           get { return _price.getPriceCode(); }
           set { setPrice(value);}
       }


        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public double getAmount(int daysRented)
        {
            return _price.getAmount(daysRented);
        }

        public int getFrequentRenterPoints(int daysRented)
        {
            int frequentRenterPoints = 1;
            // add bonus for a two day new release rental
            if ((this.PriceCode == Movie.NEW_RELEASE) && daysRented > 1) ++frequentRenterPoints;
            return frequentRenterPoints;
        }
    }

    public class Rental
    {
        private Movie _movie;
        private int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }
        public int getDaysRented()
        {
            return _daysRented;
        }
        public Movie getMovie()
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

    public class Customer
    {
        private String _name;
        private List<Rental> _rentals = new List<Rental>();

        public Customer(String name)
        {
            _name = name;
        }

    

        public void addRental(Rental arg)
        {
            _rentals.Add(arg);
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

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
