using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Timekeeper.Classes
{
    //--------------------------------------------------------------------------
    /*
       This is NOT officially part of the Timekeeper Codebase. However, since
       that's what I'm working on, and it's a solid, real-life test bed, I'd
       like to have a place to keep my ORM thoughts. Eventually, something like
       this might be my new ORM. It might make it's way into TBX. Or who knows.
       For now [2014-04-27] it's a place for me to try out some ideas I've had
       about how this thing just might work.

       Fundamentals: a lightweight sqlite object-oriented interface, which
       leans heavily towards convention over configuration. It dictates how
       your database schema should behave and does not adapt to just any schema.
       It handles all C# <--> SQLite datatype mapping and frees the caller from
       having to worry about this.

       This is intended to be a base class which the caller extends its own
       database objects around. e.g., if you have a Product table in the db
       that you need OO access to, create a class "Product : Model", add 
       properties and datatype mapping definitions, then call the ancenstor
       classes to do all the work.

       Sample usage:

         Product = new Product();
         Product.Name = "Widget";
         Product.Description = "A fine new product.";
         Product.Save();

         Product = new Product(13);
         Product.Name = "New Widget";
         Product.Save();

         Product = new Product("New Widget");
         Product.Price *= 2;
         Product.Save();

       At a minimum, tables follow this base pattern:

        CREATE TABLE Product (
            ProductId INTEGER AUTO_INCREMENT,
            CreatedTime DATETIME,
            ModifiedTime DATETIME
        );
    */
    //--------------------------------------------------------------------------

    public class Model
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Model()
        {
            Timekeeper.Warn("SOMEONE IS USING Timekeeper.Classes.Model AND HE SHOULDN'T BE.");
        }

        //----------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------

        public long Insert()
        {
            return 0;
        }

        public long Update()
        {
            return 0;
        }

        public long Save()
        {
            return 0;
        }

        public long Delete()
        {
            return 0;
        }

        //----------------------------------------------------------------------
        // Helpers
        //----------------------------------------------------------------------

    }
}
