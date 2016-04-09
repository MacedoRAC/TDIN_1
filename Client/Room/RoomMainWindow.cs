using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace Client.Room
{
    public partial class RoomMainWindow : Form
    {
        private int OpenMealsCounter { get; set; } = 0;
        delegate void ControlsAddDelegate(Control lvItem);
        delegate void ChCommDelegate(Meal item);
        IListSingleton listServer;
        AlterEventRepeater evRepeater;
        List<Meal> meals;

        public RoomMainWindow()
        {
            RemotingConfiguration.Configure("Client.exe.config", false);
            InitializeComponent();
            listServer = (IListSingleton)RemoteNew.New(typeof(IListSingleton));
            evRepeater = new AlterEventRepeater();
            evRepeater.alterEvent += new AlterDelegate(DoAlterations);
            listServer.AlterEvent += new AlterDelegate(evRepeater.Repeater);
            meals = listServer.GetList();
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

        private void RoomMainWindow_Load(object sender, EventArgs e)
        {
            foreach (Meal it in meals)
            {
                AddMealsToMealsContainer();
            }
        }

        public void DoAlterations(Operation op, Meal item)
        {
            ControlsAddDelegate ctrlsAdd;
            //ChCommDelegate chComm;

            switch (op)
            {
                case Operation.New:
                    ctrlsAdd = new ControlsAddDelegate(MealsContainer.Controls.Add);
                    Button ctrlItem = CreatedNewMealButton();
                    BeginInvoke(ctrlsAdd, new object[] { ctrlItem });
                    break;
                /*case Operation.Change:
                    chComm = new ChCommDelegate(ChangeAItem);
                    BeginInvoke(chComm, new object[] { item });
                    break;*/
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OpenNewMeal(object sender, EventArgs e)
        {
            listServer.AddItem(new Meal(OpenMealsCounter + 1));
        }

        private void AddMealsToMealsContainer()
        {
            var newMeal = CreatedNewMealButton();

            MealsContainer.Controls.Add(newMeal);
        }

        private Button CreatedNewMealButton ()
        {
            OpenMealsCounter++;
            Button newMealBtn =  new Button
            {
                Name = "meal_" + OpenMealsCounter,
                Text = "Meal " + OpenMealsCounter,
                Tag = OpenMealsCounter-1,
                Height = 30,
                FlatStyle = FlatStyle.Flat

            };
            newMealBtn.Click += new EventHandler(OpenMealDetails);

            return newMealBtn;
        }

        public void OpenMealDetails(object sender, EventArgs e)
        {
            meals = listServer.GetList();

            int mealId = int.Parse(((Button)sender).Tag.ToString());
            Meal meal = meals[mealId];

            var mealDetails = new MealDetaislForm(meal, mealId);
            mealDetails.Text = "Meal Number " + (mealId+1);
            mealDetails.Show();
        }

        private void exit(object sender, EventArgs e)
        {
            listServer.AlterEvent -= new AlterDelegate(evRepeater.Repeater);
            evRepeater.alterEvent -= new AlterDelegate(DoAlterations);

            Application.Exit();
        }

        private void RoomMainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            listServer.AlterEvent -= new AlterDelegate(evRepeater.Repeater);
            evRepeater.alterEvent -= new AlterDelegate(DoAlterations);
        }
    }
}
