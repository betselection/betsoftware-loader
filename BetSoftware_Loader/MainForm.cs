//  MainForm.cs
//
//  Author:
//       Victor L. Senior (VLS) <betselection(&)gmail.com>
//
//  Web: 
//       http://betselection.cc/betsoftware/
//
//  Sources:
//       http://github.com/betselection/
//
//  Copyright (c) 2014 Victor L. Senior
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

/// <summary>
/// BetSoftware Loader
/// </summary>
namespace BetSoftware_Loader
{
    // Directives
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.IO.Compression;
    using System.Net;
    using System.Reflection;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;

    /// <summary>
    /// Main form class
    /// </summary>
    public class MainForm : Form
    {
        /// <summary>
        /// The member.
        /// </summary>
        private string member;

        /// <summary>
        /// The subscriber boolean flag.
        /// </summary>
        private bool subscriber;

        /// <summary>
        /// Regular version number.
        /// </summary>
        private Version version = new Version("0.1");

        /// <summary>
        /// Subscriber version number.
        /// </summary>
        private Version subscriberVersion = new Version("0.1");

        /// <summary>
        /// The menu strip.
        /// </summary>
        private MenuStrip menuStrip;

        /// <summary>
        /// The status strip.
        /// </summary>
        private StatusStrip statusStrip;

        /// <summary>
        /// The user tool strip status label.
        /// </summary>
        private ToolStripStatusLabel userToolStripStatusLabel;

        /// <summary>
        /// The choose game label.
        /// </summary>
        private Label chooseGameLabel;

        /// <summary>
        /// The baccarat button.
        /// </summary>
        private Button baccaratButton;

        /// <summary>
        /// The roulette button.
        /// </summary>
        private Button rouletteButton;

        /// <summary>
        /// The tool strip status label5.
        /// </summary>
        private ToolStripStatusLabel statusToolStripStatusLabel;

        /// <summary>
        /// The message tool strip status label.
        /// </summary>
        private ToolStripStatusLabel msgToolStripStatusLabel;

        /// <summary>
        /// The separator tool strip status label.
        /// </summary>
        private ToolStripStatusLabel separatorToolStripStatusLabel;

        /// <summary>
        /// The member tool strip status label.
        /// </summary>
        private ToolStripStatusLabel memberToolStripStatusLabel;

        /// <summary>
        /// The about tool strip menu item.
        /// </summary>
        private ToolStripMenuItem aboutToolStripMenuItem;

        /// <summary>
        /// The bet software subscription tool strip menu item.
        /// </summary>
        private ToolStripMenuItem betSoftwareSubscriptionToolStripMenuItem;

        /// <summary>
        /// The bet software web tool strip menu item.
        /// </summary>
        private ToolStripMenuItem betSoftwareWebToolStripMenuItem;

        /// <summary>
        /// The home tool strip menu item.
        /// </summary>
        private ToolStripMenuItem homeToolStripMenuItem;

        /// <summary>
        /// The help tool strip menu item.
        /// </summary>
        private ToolStripMenuItem helpToolStripMenuItem;

        /// <summary>
        /// The download tool strip menu item.
        /// </summary>
        private ToolStripMenuItem downloadToolStripMenuItem;

        /// <summary>
        /// Initializes a new instance of the <see cref="BetSoftware_Loader.MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            /* GUI */

            this.chooseGameLabel = new Label();
            this.rouletteButton = new Button();
            this.menuStrip = new MenuStrip();
            this.homeToolStripMenuItem = new ToolStripMenuItem();
            this.betSoftwareWebToolStripMenuItem = new ToolStripMenuItem();
            this.betSoftwareSubscriptionToolStripMenuItem = new ToolStripMenuItem();
            this.helpToolStripMenuItem = new ToolStripMenuItem();
            this.downloadToolStripMenuItem = new ToolStripMenuItem();
            this.aboutToolStripMenuItem = new ToolStripMenuItem();
            this.statusStrip = new StatusStrip();
            this.userToolStripStatusLabel = new ToolStripStatusLabel();
            this.memberToolStripStatusLabel = new ToolStripStatusLabel();
            this.separatorToolStripStatusLabel = new ToolStripStatusLabel();
            this.msgToolStripStatusLabel = new ToolStripStatusLabel();
            this.statusToolStripStatusLabel = new ToolStripStatusLabel();
            this.baccaratButton = new Button();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // chooseGameLabel
            this.chooseGameLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.chooseGameLabel.ForeColor = Color.Navy;
            this.chooseGameLabel.Location = new Point(12, 37);
            this.chooseGameLabel.Name = "chooseGameLabel";
            this.chooseGameLabel.Size = new Size(268, 23);
            this.chooseGameLabel.TabIndex = 0;
            this.chooseGameLabel.Text = "Please choose your game:";
            this.chooseGameLabel.TextAlign = ContentAlignment.MiddleCenter;

            // rouletteButton
            this.rouletteButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.rouletteButton.ForeColor = Color.Red;
            this.rouletteButton.Location = new Point(12, 65);
            this.rouletteButton.Name = "rouletteButton";
            this.rouletteButton.Size = new Size(130, 40);
            this.rouletteButton.TabIndex = 0;
            this.rouletteButton.Text = "Roulette";
            this.rouletteButton.Enabled = false;
            this.rouletteButton.UseVisualStyleBackColor = true;
            this.rouletteButton.Click += new System.EventHandler(this.RouletteButtonClick);

            // menuStrip
            this.menuStrip.Items.AddRange(new ToolStripItem[]
                {
                    this.homeToolStripMenuItem,
                    this.helpToolStripMenuItem,
                    this.downloadToolStripMenuItem
                });
            this.menuStrip.Location = new Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new Size(292, 24);
            this.menuStrip.TabIndex = 2;

            // homeToolStripMenuItem
            this.homeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
                {
                    this.betSoftwareWebToolStripMenuItem,
                    this.betSoftwareSubscriptionToolStripMenuItem
                });
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new Size(46, 20);
            this.homeToolStripMenuItem.Text = "Hom&e";

            // betSoftwareWebToolStripMenuItem
            this.betSoftwareWebToolStripMenuItem.Name = "betSoftwareWebToolStripMenuItem";
            this.betSoftwareWebToolStripMenuItem.Size = new Size(206, 22);
            this.betSoftwareWebToolStripMenuItem.Text = "BetSoftware Web";
            this.betSoftwareWebToolStripMenuItem.Click += new System.EventHandler(this.BetSoftwareWebToolStripMenuItemClick);

            // betSoftwareSubscriptionToolStripMenuItem
            this.betSoftwareSubscriptionToolStripMenuItem.Name = "betSoftwareSubscriptionToolStripMenuItem";
            this.betSoftwareSubscriptionToolStripMenuItem.Size = new Size(206, 22);
            this.betSoftwareSubscriptionToolStripMenuItem.Text = "BetSoftware Subscription";
            this.betSoftwareSubscriptionToolStripMenuItem.Click += new System.EventHandler(this.BetSoftwareSubscriptionToolStripMenuItemClick);

            // helpToolStripMenuItem
            this.helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
                {
                    this.aboutToolStripMenuItem
                });
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";

            // downloadToolStripMenuItem
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Visible = false;
            this.downloadToolStripMenuItem.Size = new Size(40, 20);
            this.downloadToolStripMenuItem.Text = "&Get latest version";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.DownloadToolStripMenuItemClick);

            // aboutToolStripMenuItem
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new Size(114, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);

            // statusStrip
            this.statusStrip.Items.AddRange(new ToolStripItem[]
                {
                    this.userToolStripStatusLabel,
                    this.memberToolStripStatusLabel,
                    this.separatorToolStripStatusLabel,
                    this.msgToolStripStatusLabel,
                    this.statusToolStripStatusLabel
                });
            this.statusStrip.Location = new Point(0, 119);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new Size(292, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";

            // userToolStripStatusLabel
            this.userToolStripStatusLabel.Name = "userToolStripStatusLabel";
            this.userToolStripStatusLabel.Size = new Size(33, 17);
            this.userToolStripStatusLabel.Text = "User:";

            // memberToolStripStatusLabel
            this.memberToolStripStatusLabel.Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.memberToolStripStatusLabel.ForeColor = Color.Navy;
            this.memberToolStripStatusLabel.Margin = new Padding(-5, 3, 0, 2);
            this.memberToolStripStatusLabel.Name = "toolStripStatusLabel2";
            this.memberToolStripStatusLabel.Size = new Size(40, 17);
            this.memberToolStripStatusLabel.Text = "Guest";

            // separatorToolStripStatusLabel
            this.separatorToolStripStatusLabel.Name = "separatorToolStripStatusLabel";
            this.separatorToolStripStatusLabel.Size = new Size(0, 17);

            // msgToolStripStatusLabel
            this.msgToolStripStatusLabel.Name = "msgToolStripStatusLabel";
            this.msgToolStripStatusLabel.Size = new Size(30, 17);
            this.msgToolStripStatusLabel.Text = "Msg:";

            // statusToolStripStatusLabel
            this.statusToolStripStatusLabel.Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.statusToolStripStatusLabel.ForeColor = Color.Navy;
            this.statusToolStripStatusLabel.Margin = new Padding(-5, 3, 0, 2);
            this.statusToolStripStatusLabel.Name = "statusToolStripStatusLabel";
            this.statusToolStripStatusLabel.Size = new Size(135, 17);
            this.statusToolStripStatusLabel.Text = "Checking...";

            // baccaratButton
            this.baccaratButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            this.baccaratButton.ForeColor = Color.Blue;
            this.baccaratButton.Location = new Point(150, 65);
            this.baccaratButton.Name = "baccaratButton";
            this.baccaratButton.Size = new Size(130, 40);
            this.baccaratButton.TabIndex = 1;
            this.baccaratButton.Text = "Baccarat";
            this.baccaratButton.Enabled = false;
            this.baccaratButton.UseVisualStyleBackColor = true;
            this.baccaratButton.Click += new System.EventHandler(this.BaccaratButtonClick);

            // MainForm
            this.AutoScaleMode = AutoScaleMode.None;
            this.Icon = new Icon(Assembly.GetExecutingAssembly().GetManifestResourceStream("betsoftware.ico"));
            this.ClientSize = new Size(292, 141);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.baccaratButton);
            this.Controls.Add(this.rouletteButton);
            this.Controls.Add(this.chooseGameLabel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "BetSoftware Loader";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        [STAThread]
        private static void Main(string[] args)
        {
            /* Temporary release */

            // Set framework path
            string frameworkPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "BetSoftware" + Path.DirectorySeparatorChar + "Bin" + Path.DirectorySeparatorChar + "BetSoftware_Framework" + Path.DirectorySeparatorChar + "BetSoftware_Framework.exe");

            // Start framework
            Process p = new Process();
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.FileName = frameworkPath;
            p.Start();

            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());*/
        }

        /// <summary>
        /// BetSoftware website
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void BetSoftwareWebToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Launch BetSoftware website
            Process.Start("http://betselection.cc/betsoftware/");
        }

        /// <summary>
        /// Subscription sales page
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void BetSoftwareSubscriptionToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Launch subscription sales page
            Process.Start("http://betselection.cc/subscription/");
        }

        /// <summary>
        /// Displays about message.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO About message
        }

        /// <summary>
        /// Downloads the tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void DownloadToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Launch download section
            Process.Start("http://betselection.cc/betsoftware-download/");
        }

        /// <summary>
        /// Roulette button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void RouletteButtonClick(object sender, EventArgs e)
        {
            // TODO Launch framework with game = roulette 
        }

        /// <summary>
        /// Baccarat button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void BaccaratButtonClick(object sender, EventArgs e)
        {
            // TODO Launch framework with game = baccarat
        }

        /// <summary>
        /// Main form load event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void MainFormLoad(object sender, EventArgs e)
        {
            // Declare xml string
            string xmlString = string.Empty;

            // Try to get info
            try
            {
                // Set xmlString
                xmlString = new WebClient().DownloadString("http://betselection.cc/scripts/betsoftware/getinfo/");

                // Check there's something
                if (xmlString.Length > 0)
                {
                    // Create an XmlReader
                    using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
                    {
                        // Set reader position
                        reader.ReadToFollowing("member");

                        // Set member name
                        this.member = reader.ReadInnerXml();

                        // Place member name on status bar
                        this.memberToolStripStatusLabel.Text = this.member;

                        // Set reader position
                        reader.ReadToFollowing("subscriber");

                        // Set subscriber variable
                        this.subscriber = reader.ReadInnerXml() == "1" ? true : false;

                        // Colorize subscriber name
                        if (this.subscriber)
                        {
                            /* Process subscriber auto-update */

                            // Make it red
                            this.memberToolStripStatusLabel.ForeColor = Color.Red;

                            // Set reader position
                            reader.ReadToFollowing("sversion");

                            // Set fetched subscriber version
                            Version subscriberVersion2 = new Version(reader.ReadInnerXml());

                            // Compare subscriber version
                            int cmp = subscriberVersion2.CompareTo(this.subscriberVersion);

                            // Check for higher
                            if (cmp > 0)
                            {
                                // Set status text
                                this.statusToolStripStatusLabel.Text = "Updating...";

                                // It is greater, download xml for new subscriber version
                                using (WebClient webClient = new WebClient())
                                {
                                    // Try to get file
                                    try
                                    {
                                        // Download xml to temp dir

                                        // Process every directory 

                                        // Process every file by checksum

                                        // Download files

                                        // Set framework update flag

                                        // Updated, set status
                                        this.statusToolStripStatusLabel.Text = "Subscriber version!(U)";
                                    }
                                    catch (WebException we)
                                    {
                                        // Error
                                        this.statusToolStripStatusLabel.Text = "Download error.";
                                    }
                                    catch (Exception ex)
                                    {
                                        // Every other exception
                                        this.statusToolStripStatusLabel.Text = "Couldn't download.";
                                    }
                                }                                
                            }
                            else
                            {
                                // Up to date, set status
                                this.statusToolStripStatusLabel.Text = "Subscriber version!";

                                // Set color 
                                this.statusToolStripStatusLabel.ForeColor = Color.Green;
                            }
                        }
                        else
                        {
                            /* Regular user; compare version */

                            // Set reader position
                            reader.ReadToFollowing("version");

                            // Set version
                            Version version2 = new Version(reader.ReadInnerXml());

                            // Compare version
                            int cmp = version2.CompareTo(this.version);

                            // Check for higher
                            if (cmp > 0)
                            {
                                // It is greater, advice
                                this.statusToolStripStatusLabel.Text = "Outdated version.";

                                // Make download menu item visible
                                this.downloadToolStripMenuItem.Visible = true;
                            }
                        }
                    }
                }
            }
            catch (WebException we)
            {
                // Offline mode
                this.statusToolStripStatusLabel.Text = "Offline mode.";
            }
            catch (Exception ex)
            {
                // Every other exception
                this.statusToolStripStatusLabel.Text = "Couldn't update.";
            }
        }
    }
}