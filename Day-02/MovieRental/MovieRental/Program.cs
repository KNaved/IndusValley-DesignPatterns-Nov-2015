using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRental
{
    public class Movie {

   public const  int  CHILDRENS = 2;
   public const  int  REGULAR = 0;
   public const  int  NEW_RELEASE = 1;

   
   private int _priceCode;
        private string _title;

        public Movie(String title, int priceCode) {
       _title = title;
       _priceCode = priceCode;
   }

					
   public int PriceCode {
       get { return _priceCode; }
       set { _priceCode = value; }
   }


        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
    }

    class Rental
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
    }

    class Customer
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
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            IEnumerator<Rental> rentals = _rentals.GetEnumerator();
            String result = "Rental Record for " + getName() + "\n";
            while (rentals.MoveNext())
            {
                double thisAmount = 0;
                Rental each = (Rental)rentals.Current;

                //determine amounts for each line
                switch (each.getMovie().PriceCode)
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.getDaysRented() > 2)
                            thisAmount += (each.getDaysRented() - 2) * 1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += each.getDaysRented() * 3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (each.getDaysRented() > 3)
                            thisAmount += (each.getDaysRented() - 3) * 1.5;
                        break;

                }

                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((each.getMovie().PriceCode == Movie.NEW_RELEASE) && each.getDaysRented() > 1) frequentRenterPoints++;

                //show figures for this rental
                result += "\t" + each.getMovie().Title + "\t" + thisAmount + "\n";
                totalAmount += thisAmount;

            }
            //add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints +" frequent renter points";
            return result;

        }


    
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
