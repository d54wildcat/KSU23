namespace Login200Server
{
    public partial class ServerConsole : Form
    {
        public ServerConsole()
        {
            InitializeComponent();
        }

        public void AddToListBox(String data)
        {
            this.Invoke(new Action(() => uxRequestListBox.Items.Add(data)));
        }
    }
}