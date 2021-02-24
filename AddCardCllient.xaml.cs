using ClientBonusSystem.Models;
using Newtonsoft.Json;
using System.Windows;

namespace ClientBonusSystem
{
    /// <summary>
    /// Interaction logic for AddCardCllient.xaml
    /// </summary>
    public partial class AddCardCllient : Window
    {
        private BonusCard _card;

        public AddCardCllient()
        {
            InitializeComponent();
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            this._card = new BonusCard();
            _card.FirstName = this.txtFirstName.Text;
            _card.LastName = this.txtLastName.Text;
            _card.PhoneNumber = this.txtPhoneNumber.Text;

            AddNewClient();
        }

        private void AddNewClient()
        {
            var url = "api/client";

            var qryParams = $"firstName={_card.FirstName}&lastName={_card.LastName}&phone={_card.PhoneNumber}";

            url = $"{url}?{qryParams}";

            var parametrers = new AddParamsModel
            {
                FirstName = _card.FirstName,
                LastName = _card.LastName,
                PhoneNumber = _card.PhoneNumber
            };

            var postParams = JsonConvert.SerializeObject(parametrers);

            var response = new CardApiClient().Post(url, postParams);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Success");

                Close();
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }
    }
}
