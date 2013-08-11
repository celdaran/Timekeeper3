using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Timekeeper.Forms
{
    public partial class CategoryManager : Forms.ListAttributeManager
    {
        //----------------------------------------------------------------------
        // Constructor for Subclassed Form
        //----------------------------------------------------------------------

        public CategoryManager()
            : base()
        {
            InitializeComponent();

            this.Kind = ListAttributeKind.Category;

            LocationTimeZone.Visible = false;
            LocationTimeZoneLabel.Visible = false;
        }

        //----------------------------------------------------------------------
        // "Callbacks"
        //----------------------------------------------------------------------

        protected override List<IdObjectPair> GetItems()
        {
            Classes.CategoryCollection Categories = new Classes.CategoryCollection();
            List<IdObjectPair> Items = Categories.Fetch(true);
            return Items;
        }

        //----------------------------------------------------------------------

        protected override bool CreateItem(int sortOrderNo)
        {
            Classes.Category Category = new Classes.Category();

            Category.Name = AttributeName.Text;
            Category.Description = AttributeDescription.Text;
            Category.SortOrderNo = sortOrderNo;
            Category.IsHidden = AttributeIsHiddenCheckBox.Checked;

            return Category.Create();
        }

        //----------------------------------------------------------------------

        protected override bool UpdateItem()
        {
            Classes.Category Category = (Classes.Category)((IdObjectPair)CurrentItem).Object;

            Category.Name = AttributeName.Text;
            Category.Description = AttributeDescription.Text;
            Category.IsHidden = AttributeIsHiddenCheckBox.Checked;

            return Category.Save();
        }

        //----------------------------------------------------------------------

    }
}
