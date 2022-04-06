namespace PropertyChangedEventsDemo
{
    public partial class Form1 : Form
    {
        private Person person;

        private const string windowTitlePrefix = "CptS 321: Property Change";
        public Form1()
        {
            InitializeComponent();

            person = new Person("","");

            person.PropertyChanged += Person_PropertyChanged;

            person.FirstName = "Joe";
            person.LastName = "Smith";
        }

        private void Person_PropertyChanged(Button btnFirstName1, Button btnFirstName2, Button btnLastName1, Button btnLastName2, object sender, PropertyChangedEventArgs e)
        {
            if("FirstName" == e.PropertyName)
            {
                updateNameButtons(btnFirstName1, btnFirstName2, "First name", person.FirstName);
            }

            if ("LastName" == e.PropertyName)
            {
                updateNameButtons(btnLastName1, btnLastName2, "Last Name", person.LastName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            person.FirstName =((Button)sender).Tag.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            person.LastName = (sender as Button).Tag.ToString();
        }
    }
}