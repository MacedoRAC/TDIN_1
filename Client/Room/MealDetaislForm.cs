using System;
using System.Windows.Forms;

namespace Client.Room
{
    public partial class MealDetaislForm : Form
    {
        protected Meal Meal;
        public string MealId { get; set; }

        public MealDetaislForm(Meal meal, int mealId)
        {
            Meal = meal;
            MealId = mealId.ToString();
            InitializeComponent();
        }

        public void MealDetailsForm_Load(object sender, EventArgs e)
        {
            
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            Close();
        }
    }
}
