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
            ((System.ComponentModel.ISupportInitialize)invoiceList).BeginInit();
            SuspendLayout();
            // 
            // invoiceList
            // 
            invoiceList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            invoiceList.Location = new Point(12, 67);
            invoiceList.Name = "invoiceList";
            invoiceList.Size = new Size(939, 350);
            invoiceList.TabIndex = 0;
            // 
            // list
            // 
            list.Location = new Point(12, 38);
            list.Name = "list";
            list.Size = new Size(75, 23);
            list.TabIndex = 1;
            list.Text = "Listele";
            list.UseVisualStyleBackColor = true;
            list.Click += List_Click;
            // 
            // startDate
            // 
            startDate.Location = new Point(12, 9);
            startDate.Name = "startDate";
            startDate.Size = new Size(200, 23);
            startDate.TabIndex = 2;
            // 
            // endDate
            // 
            endDate.Location = new Point(218, 9);
            endDate.Name = "endDate";
            endDate.Size = new Size(200, 23);
            endDate.TabIndex = 3;
            // 
            // view
            // 
            view.Location = new Point(118, 38);
            view.Name = "view";
            view.Size = new Size(75, 23);
            view.TabIndex = 4;
            view.Text = "Görüntüle";
            view.UseVisualStyleBackColor = true;
            view.Click += View_Click;
            // 
            // cancel
            // 
            cancel.Location = new Point(218, 38);
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
            direction.Location = new Point(424, 9);
            direction.Name = "direction";
            direction.Size = new Size(121, 23);
            direction.TabIndex = 6;
            // 
            // create
            // 
            create.Location = new Point(325, 38);
            create.Name = "create";
            create.Size = new Size(110, 23);
            create.TabIndex = 7;
            create.Text = "Fatura Oluştur";
            create.UseVisualStyleBackColor = true;
            create.Click += Create_Click;
            // 
            // clear
            // 
            clear.Location = new Point(470, 38);
            clear.Name = "clear";
            clear.Size = new Size(75, 23);
            clear.TabIndex = 8;
            clear.Text = "Temizle";
            clear.UseVisualStyleBackColor = true;
            clear.Click += Clear_Click;
            // 
            // EFaturaListele
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 450);
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
            ResumeLayout(false);
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
    }
}