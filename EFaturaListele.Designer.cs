namespace EFaturaForm
{
    partial class EFaturaListele
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            invoiceList = new DataGridView();
            list = new Button();
            startDate = new DateTimePicker();
            endDate = new DateTimePicker();
            view = new Button();
            cancel = new Button();
            direction = new ComboBox();
            create = new Button();
            clear = new Button();
            login = new Button();
            groupBox1 = new GroupBox();
            totalRecords = new Label();
            pageCount = new Label();
            pageSize = new ComboBox();
            page = new TextBox();
            last = new Button();
            next = new Button();
            previous = new Button();
            first = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)invoiceList).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // invoiceList
            // 
            invoiceList.AllowUserToOrderColumns = true;
            invoiceList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            invoiceList.Location = new Point(12, 103);
            invoiceList.Name = "invoiceList";
            invoiceList.Size = new Size(984, 560);
            invoiceList.TabIndex = 0;
            // 
            // list
            // 
            list.Location = new Point(10, 53);
            list.Name = "list";
            list.Size = new Size(75, 23);
            list.TabIndex = 1;
            list.Text = "Listele";
            list.UseVisualStyleBackColor = true;
            list.Click += List_Click;
            // 
            // startDate
            // 
            startDate.Location = new Point(141, 8);
            startDate.Name = "startDate";
            startDate.Size = new Size(200, 23);
            startDate.TabIndex = 2;
            // 
            // endDate
            // 
            endDate.Location = new Point(453, 8);
            endDate.Name = "endDate";
            endDate.Size = new Size(200, 23);
            endDate.TabIndex = 3;
            // 
            // view
            // 
            view.Location = new Point(115, 53);
            view.Name = "view";
            view.Size = new Size(75, 23);
            view.TabIndex = 4;
            view.Text = "Görüntüle";
            view.UseVisualStyleBackColor = true;
            view.Click += View_Click;
            // 
            // cancel
            // 
            cancel.Location = new Point(212, 53);
            cancel.Name = "cancel";
            cancel.Size = new Size(75, 23);
            cancel.TabIndex = 5;
            cancel.Text = "İptal Et";
            cancel.UseVisualStyleBackColor = true;
            cancel.Click += Cancel_Click;
            // 
            // direction
            // 
            direction.FormattingEnabled = true;
            direction.Location = new Point(718, 8);
            direction.Name = "direction";
            direction.Size = new Size(121, 23);
            direction.TabIndex = 6;
            // 
            // create
            // 
            create.Location = new Point(313, 53);
            create.Name = "create";
            create.Size = new Size(110, 23);
            create.TabIndex = 7;
            create.Text = "Fatura Oluştur";
            create.UseVisualStyleBackColor = true;
            create.Click += Create_Click;
            // 
            // clear
            // 
            clear.Location = new Point(454, 53);
            clear.Name = "clear";
            clear.Size = new Size(75, 23);
            clear.TabIndex = 8;
            clear.Text = "Temizle";
            clear.UseVisualStyleBackColor = true;
            clear.Click += Clear_Click;
            // 
            // login
            // 
            login.Location = new Point(921, 8);
            login.Name = "login";
            login.Size = new Size(75, 23);
            login.TabIndex = 9;
            login.Text = "Giriş Yap";
            login.UseVisualStyleBackColor = true;
            login.Click += Login_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(totalRecords);
            groupBox1.Controls.Add(pageCount);
            groupBox1.Controls.Add(pageSize);
            groupBox1.Controls.Add(page);
            groupBox1.Controls.Add(last);
            groupBox1.Controls.Add(next);
            groupBox1.Controls.Add(previous);
            groupBox1.Controls.Add(first);
            groupBox1.Location = new Point(292, 665);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(500, 40);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sayfa";
            // 
            // totalRecords
            // 
            totalRecords.AutoSize = true;
            totalRecords.Location = new Point(376, 12);
            totalRecords.Name = "totalRecords";
            totalRecords.Size = new Size(0, 15);
            totalRecords.TabIndex = 7;
            // 
            // pageCount
            // 
            pageCount.AutoSize = true;
            pageCount.Location = new Point(6, 12);
            pageCount.Name = "pageCount";
            pageCount.Size = new Size(0, 15);
            pageCount.TabIndex = 0;
            // 
            // pageSize
            // 
            pageSize.FormattingEnabled = true;
            pageSize.Items.AddRange(new object[] { "25", "50", "100", "250", "500" });
            pageSize.Location = new Point(316, 12);
            pageSize.Name = "pageSize";
            pageSize.Size = new Size(44, 23);
            pageSize.TabIndex = 6;
            pageSize.SelectedIndexChanged += PageSize_SelectedIndexChanged;
            // 
            // page
            // 
            page.Location = new Point(195, 12);
            page.Name = "page";
            page.Size = new Size(43, 23);
            page.TabIndex = 3;
            page.Text = "1";
            page.TextChanged += Page_TextChanged;
            // 
            // last
            // 
            last.Location = new Point(279, 12);
            last.Name = "last";
            last.Size = new Size(32, 23);
            last.TabIndex = 5;
            last.Text = ">>";
            last.UseVisualStyleBackColor = true;
            last.Click += Last_Click;
            // 
            // next
            // 
            next.Location = new Point(244, 12);
            next.Name = "next";
            next.Size = new Size(32, 23);
            next.TabIndex = 4;
            next.Text = ">";
            next.UseVisualStyleBackColor = true;
            next.Click += Next_Click;
            // 
            // previous
            // 
            previous.Location = new Point(158, 12);
            previous.Name = "previous";
            previous.Size = new Size(32, 23);
            previous.TabIndex = 2;
            previous.Text = "<";
            previous.UseVisualStyleBackColor = true;
            previous.Click += Previous_Click;
            // 
            // first
            // 
            first.Location = new Point(123, 12);
            first.Name = "first";
            first.Size = new Size(32, 23);
            first.TabIndex = 1;
            first.Text = "<<";
            first.UseVisualStyleBackColor = true;
            first.Click += First_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 12);
            label1.Name = "label1";
            label1.Size = new Size(130, 15);
            label1.TabIndex = 11;
            label1.Text = "Fatura Başlangıç Tarihi: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(349, 12);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 12;
            label2.Text = "Fatura Bitiş Tarihi: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(683, 12);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 13;
            label3.Text = "Yön: ";
            // 
            // EFaturaListele
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 711);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(login);
            Controls.Add(clear);
            Controls.Add(create);
            Controls.Add(direction);
            Controls.Add(cancel);
            Controls.Add(view);
            Controls.Add(endDate);
            Controls.Add(startDate);
            Controls.Add(list);
            Controls.Add(invoiceList);
            Name = "EFaturaListele";
            Text = "Faturalar";
            ((System.ComponentModel.ISupportInitialize)invoiceList).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView invoiceList;
        private Button list;
        private DateTimePicker startDate;
        private DateTimePicker endDate;
        private Button view;
        private Button cancel;
        private ComboBox direction;
        private Button create;
        private Button clear;
        private Button login;
        private GroupBox groupBox1;
        private Button previous;
        private Button first;
        private TextBox page;
        private Button last;
        private Button next;
        private ComboBox pageSize;
        private Label pageCount;
        private Label totalRecords;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}