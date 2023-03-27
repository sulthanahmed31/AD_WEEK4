namespace AD_WEEK4
{
    public partial class Form1 : Form
    {
        List<Team> Timbaru = new List<Team>();
        string selectplayer = "";
        public Form1()
        {
            Preset preset = new Preset();
            InitializeComponent();
            Timbaru.Add(preset.TeamMU());
            Timbaru.Add(preset.TeamBARCA());
            Timbaru.Add(preset.TeamRM());
            nambahcountry();
        }
        public class Preset
        {
            public Team TeamMU()
            {
                Team timbaru3 = new Team();
                timbaru3.teamCity = "Manchester";
                timbaru3.teamCountry = "England";
                timbaru3.teamName = "Manchester United";
                timbaru3.players = new List<Players>();
                string dataplayer = "1-GK-David de Gea-2-DF-Victor Lindelof-4-DF-Phil Jones-5-DF-Harry Maguire-6-DF-Lisandro Martínez-8-MF-Bruno Fernandes-9-FW-Anthony Martial-10-FW-Marcus Rashford-11-FW-Mason Greenwood-14-MF-Christian Eriksen-15-MF-Marcel Sabitzer-17-MF-Fred";
                string[] data2 = dataplayer.Split('-');
                for (int i = 0; i < data2.Length; i = i + 3)
                {
                    Players player1 = new Players();
                    player1.playerNum = data2[i];
                    player1.playerPos = data2[i + 1];
                    player1.playerName = data2[i + 2];
                    timbaru3.players.Add(player1);
                }
                return timbaru3;
            }
            public Team TeamBARCA()
            {
                Team timbaru3 = new Team();
                timbaru3.teamCity = "Barcelona";
                timbaru3.teamCountry = "Spain";
                timbaru3.teamName = "FC Barcelona";
                timbaru3.players = new List<Players>();
                string dataplayer = "1-GK-Marc AndreStegen-4-DF-Ronald Araujo-5-MF-Sergio Busquets-6-MF-Gavi-7-FW-OusmaneDembel-8-MF-Pedri-9-FW-RobertLewandowski-10-FW-AnsuFati-11-FW-Feran Torres-13-GK-Inaki Pena-15-DF-AndreasChristense-17-DF-Marcos Alonso";
                string[] data2 = dataplayer.Split('-');
                for (int i = 0; i < data2.Length; i = i + 3)
                {
                    Players player1 = new Players();
                    player1.playerNum = data2[i];
                    player1.playerPos = data2[i + 1];
                    player1.playerName = data2[i + 2];
                    timbaru3.players.Add(player1);
                }
                return timbaru3;
            }
            public Team TeamRM()
            {
                Team timbaru3 = new Team();
                timbaru3.teamCity = "Madrid";
                timbaru3.teamCountry = "Spain";
                timbaru3.teamName = "Real Madrid";
                timbaru3.players = new List<Players>();
                string dataplayer = "1-GK-Thibaut Courtois-2-DF-Dani Carvajal-3-DF-Eder Militao-4-DF-David Alaba-5-DF-Jesus Vallejo-6-DF-Nacho-7-FW-Eden Hazard-8-MF-Toni Kroos-9-FW-Karim Benzema-10-MF-Luka Modric-11-FW-Marco Asensio-12-MF-Eduardo Camavinga";
                string[] data2 = dataplayer.Split('-');
                for (int i = 0; i < data2.Length; i = i + 3)
                {
                    Players player1 = new Players();
                    player1.playerNum = data2[i];
                    player1.playerPos = data2[i + 1];
                    player1.playerName = data2[i + 2];
                    timbaru3.players.Add(player1);
                }
                return timbaru3;
            }
        }
        public class Players
        {
            public string playerName;
            public string playerPos;
            public string playerNum;

        }

        public class Team
        {
            public string teamName;
            public string teamCountry;
            public string teamCity;
            public List<Players> players = new List<Players>();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void nambahcountry()
        {
            combobox_choosecountry.Items.Clear();
            foreach (Team timbaru2 in Timbaru)
            {
                if (!combobox_choosecountry.Items.Contains(timbaru2.teamCountry))
                {
                    combobox_choosecountry.Items.Add(timbaru2.teamCountry);
                }
            }


        }
        private void nambahteam()
        {
            combobox_chooseteam.Items.Clear();
            foreach (Team timbaru2 in Timbaru)
            {
                if (timbaru2.teamCountry == combobox_choosecountry.SelectedItem.ToString())
                {
                    combobox_chooseteam.Items.Add(timbaru2.teamName);
                }
            }
        }


        private void button_addteam_Click(object sender, EventArgs e)
        {
            bool add = false;
            foreach (Team timm in Timbaru)
            {
                if (timm.teamName == txtbox_teamname.Text)
                {
                    MessageBox.Show("Team Sudah di list");
                    add = true;
                }
            }
            if (add == false)
            {
                combobox_chooseteam.Items.Clear();
                Team Timbaru1 = new Team();
                Timbaru1.teamCountry = txtbox_teamcountry.Text;
                Timbaru1.teamName = txtbox_teamname.Text;
                Timbaru1.teamCity = txtbox_teamcity.Text;
                Timbaru1.players = new List<Players>();
                Timbaru.Add(Timbaru1);
                nambahcountry();
                txtbox_teamcountry.Text = "";
                txtbox_teamname.Text = "";
                txtbox_teamcity.Text = "";
            }


        }

        private void pilih_negara(object sender, EventArgs e)
        {
            listbox_list.Items.Clear();
            nambahteam();
        }

        private void updatepemain()
        {
            listbox_list.Items.Clear();
            foreach (Team timbaru2 in Timbaru)
            {
                if (timbaru2.teamName == combobox_chooseteam.SelectedItem.ToString())
                {
                    foreach (Players player1 in timbaru2.players)
                    {
                        listbox_list.Items.Add($"[{player1.playerNum}]{player1.playerName},{player1.playerPos}");
                    }
                }
            }
            listbox_list.Sorted = true;
        }

        private void button_addplayer_Click(object sender, EventArgs e)
        {

            if (txtbox_playername.Text == "" || txtbox_playernumber.Text == "" || combobox_playerposition.SelectedIndex != -1)
            {
                bool add = false;
                bool number = false;
                foreach (Team timbaru2 in Timbaru)
                {
                    for (int i = 0; i < timbaru2.players.Count; i++)
                    {
                        if (timbaru2.players[i].playerName == txtbox_playername.Text)
                        {
                            add = true;
                        }
                    }
                    for (int i = 0; i < timbaru2.players.Count; i++)
                    {
                        if (timbaru2.players[i].playerNum == txtbox_playernumber.Text)
                        {
                            number = true;
                        }
                    }
                    if (add)
                    {
                        MessageBox.Show("Player already added");
                        break;
                    }
                    if (timbaru2.teamName == combobox_chooseteam.SelectedItem.ToString() && add == false)
                    {
                        Players playerr = new Players();
                        playerr.playerName = txtbox_playername.Text;
                        playerr.playerNum = txtbox_playernumber.Text;
                        playerr.playerPos = this.combobox_playerposition.GetItemText(this.combobox_playerposition.SelectedItem);
                        timbaru2.players.Add(playerr);
                        timbaru2.players.OrderBy(o => o.playerNum).ToList();
                        updatepemain();
                        txtbox_playername.Text = "";
                        txtbox_playernumber.Text = "";
                        combobox_playerposition.SelectedIndex = -1;
                    }
                }
            }
            else
            {
                MessageBox.Show("INVALID");
            }
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            foreach (Team timbaru2 in Timbaru)
            {
                if (timbaru2.teamName == combobox_chooseteam.SelectedItem.ToString())
                {
                    if (timbaru2.players.Count > 11)
                    {
                        for (int i = 0; i < timbaru2.players.Count; i++)
                        {
                            if ($"[{timbaru2.players[i].playerNum}]{timbaru2.players[i].playerName},{timbaru2.players[i].playerPos}" == selectplayer)
                            {
                                timbaru2.players.RemoveAt(i);
                                i--;
                                updatepemain();
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Player terlalu sedikit");
                        break;
                    }

                    break;
                }
            }
        }

        private void pilih_team(object sender, EventArgs e)
        {
            updatepemain();
        }

        private void listbox_valuechange(object sender, EventArgs e)
        {
            selectplayer = listbox_list.SelectedItem.ToString();
        }

        private void combobox_choosecountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}