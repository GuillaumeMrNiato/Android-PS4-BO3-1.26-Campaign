using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using PS4Lib;

namespace App1
{
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        PS4API PS4 = new PS4API();
        public MainPage()
        {
            InitializeComponent();
        }
        private void ConnectPS4(object sender, EventArgs e)
        {
            try
            {
                PS4.ConnectTarget(ip.Text);
                PS4.Notify(222, "Connected");
                ConnectLabel.Text = "PS4 Connected";
                ConnectLabel.TextColor = Color.ForestGreen;
                DisplayAlert("Information", "The PS4 is connected !", "OK");
            }
            catch
            {
                DisplayAlert("Information", "PS4 is not connected !", "OK");
            }
        }

        private void AttachProcess(object sender, EventArgs e)
        {
            try
            {
                PS4.AttachProcess();
                PS4.Notify(222, "Process is attached");
                AttachLabel.Text = "Process attached";
                AttachLabel.TextColor = Color.ForestGreen;
                DisplayAlert("Information", "The process is attached !", "OK");
            }
            catch
            {
                DisplayAlert("Information", "Process can't be attached !", "OK");
            }
        }

        private void DisconnectPS4(object sender, EventArgs e)
        {
            PS4.Notify(222, "PS4 will be disconnected in 1 sec");
            PS4.DisconnectTarget();
            ConnectLabel.Text = "Connected ?";
            ConnectLabel.TextColor = Color.Red;
            AttachLabel.Text = "Process ?";
            AttachLabel.TextColor = Color.Red;
            DisplayAlert("Information", "PS4 has been disconnected !", "OK");
        }
        bool godmodeclient0 = false;
        bool ammoclient0 = false;
        bool snake = false;
        bool TakeWeapf = false;
        private void GodMode(object sender, EventArgs e)
        {
            if (godmodeclient0 == false)
            {
                PS4.SetMemory(0x8439C10, new byte[] { 0x05 });
                DisplayAlert("Information", "God Mode Enabled", "Ok");
                PS4.Notify(222, "God Mode Enabled");
                godmodeclient0 = true;
            }
            else if (godmodeclient0 == true)
            {
                PS4.SetMemory(0x8439C10, new byte[] { 0x04 });
                DisplayAlert("Information", "God Mode Disabled", "Ok");
                PS4.Notify(222, "God Mode Disabled");
                godmodeclient0 = false;
            }
        }
        private void Ammo(object sender, EventArgs e)
        {
            if (ammoclient0 == false)
            {
                PS4.SetMemory(0x843A274, new byte[] { 0xff, 0xff });
                PS4.SetMemory(0x843A238, new byte[] { 0xff, 0xff });
                PS4.SetMemory(0x843A278, new byte[] { 0xff, 0xff });
                PS4.SetMemory(0x843A23C, new byte[] { 0xff, 0xff });
                PS4.SetMemory(0x843A27C, new byte[] { 0xff, 0xff });
                DisplayAlert("Information", "Unlimited Ammo given", "Ok");
                PS4.Notify(222, "Unlimited Ammo given");
                ammoclient0 = true;
            }
            else if (ammoclient0 == true)
            {
                PS4.SetMemory(0x843A274, new byte[] { 0x06, 0x00 });
                PS4.SetMemory(0x843A238, new byte[] { 0x06, 0x00 });
                PS4.SetMemory(0x843A278, new byte[] { 0x06, 0x00 });
                PS4.SetMemory(0x843A23C, new byte[] { 0x06, 0x00 });
                PS4.SetMemory(0x843A27C, new byte[] { 0x01, 0x00 });
                DisplayAlert("Information", "Unlimited Ammo removed", "Ok");
                PS4.Notify(222, "Unlimited Ammo removed");
                ammoclient0 = false;
            }
        }
        private void Snake(object sender, EventArgs e)
        {
            if (snake == false)
            {
                PS4.SetMemory(0x8439C04, new byte[] { 0xff });
                DisplayAlert("Information", "Snake Mod Enabled", "Ok");
                PS4.Notify(222, "Snake Mod Enabled");
                snake = true;
            }
            else if (snake == true)
            {
                PS4.SetMemory(0x8439C04, new byte[] { 0x00 });
                DisplayAlert("Information", "Snake Mod Disabled", "Ok");
                PS4.Notify(222, "Snake Mod Disabled");
                snake = false;
            }
        }
        private void TakeWeap(object sender, EventArgs e)
        {
            if (TakeWeapf == false)
            {
                PS4.SetMemory(0x8439C08, new byte[] { 0xff });
                DisplayAlert("Information", "Weapons removed", "Ok");
                PS4.Notify(222, "Weapons removed");
                TakeWeapf = true;
            }
            else if (TakeWeapf == true)
            {
                PS4.SetMemory(0x8439C08, new byte[] { 0x00 });
                DisplayAlert("Information", "Weapons taken", "Ok");
                PS4.Notify(222, "Weapons given");
                TakeWeapf = false;
            }
        }
        private void GiveWeapons(object sender, EventArgs e)
        {
            if (weaponslist.SelectedIndex == 0)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x01 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 1)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x02 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 2)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x04 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 3)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x06 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 4)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x06 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 5)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x0a });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 6)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x0C });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 7)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x0F });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 8)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x11 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 9)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x13 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 10)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x15 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 11)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x17 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 12)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x19 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 13)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x1B });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 14)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x1E });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 15)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x1F });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 16)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x20 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 17)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x21 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 18)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x22 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 19)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x28 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 20)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x2B });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 21)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x2D });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 22)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x2F });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 23)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x31 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 24)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x34 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 25)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x39 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 26)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x3C });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 27)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x3D });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 28)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x3E });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 29)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x3F });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 30)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x43 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 31)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x46 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 32)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x60 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 33)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x61 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
            if (weaponslist.SelectedIndex == 34)
            {
                PS4.SetMemory(0x8439F98, new byte[] { 0x64 });
                DisplayAlert("Information", "Weapons given : " + weaponslist.SelectedItem, "Ok");
                PS4.Notify(222, "Weapons given : " + weaponslist.SelectedItem);
            }
        }
    }
}
