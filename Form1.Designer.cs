private void InitializeComponent()
{
    this.txtSearch = new System.Windows.Forms.TextBox();
    this.btnSearch = new System.Windows.Forms.Button();
    this.listBoxResults = new System.Windows.Forms.ListBox();
    this.btnUpload = new System.Windows.Forms.Button();
    this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
    this.SuspendLayout();
    // 
    // txtSearch
    // 
    this.txtSearch.Location = new System.Drawing.Point(20, 20);
    this.txtSearch.Size = new System.Drawing.Size(200, 20);
    this.txtSearch.Text = "Enter song name...";
    // 
    // btnSearch
    // 
    this.btnSearch.Location = new System.Drawing.Point(230, 20);
    this.btnSearch.Size = new System.Drawing.Size(50, 20);
    this.btnSearch.Text = "Search";
    this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
    // 
    // listBoxResults
    // 
    this.listBoxResults.Location = new System.Drawing.Point(20, 50);
    this.listBoxResults.Size = new System.Drawing.Size(260, 160);
    this.listBoxResults.DoubleClick += new System.EventHandler(this.listBoxResults_DoubleClick);
    // 
    // btnUpload
    // 
    this.btnUpload.Location = new System.Drawing.Point(20, 220);
    this.btnUpload.Size = new System.Drawing.Size(100, 20);
    this.btnUpload.Text = "Upload Music";
    this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
    // 
    // openFileDialog1
    // 
    this.openFileDialog1.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
    // 
    // Form1
    // 
    this.ClientSize = new System.Drawing.Size(300, 250);
    this.Controls.Add(this.txtSearch);
    this.Controls.Add(this.btnSearch);
    this.Controls.Add(this.listBoxResults);
    this.Controls.Add(this.btnUpload);
    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
    this.Name = "Form1";
    this.Text = "Music Search";
    this.Load += new System.EventHandler(this.Form1_Load);
    this.ResumeLayout(false);
    this.PerformLayout();
}