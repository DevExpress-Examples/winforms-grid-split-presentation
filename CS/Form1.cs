using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Collections;

namespace CreateGridSplitContainer {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

            IList dataSource = CreateDataSource();

            GridSplitContainer gridSplitContainer = new GridSplitContainer();
            gridSplitContainer.Parent = this;
            gridSplitContainer.Location = new Point(0, 0);
            gridSplitContainer.Size = new Size(350, 300);
            gridSplitContainer.Initialize();
            gridSplitContainer.SplitViewCreated += new EventHandler(gridSplitContainer_SplitViewCreated);

            // Customize the first grid control.
            GridControl grid = gridSplitContainer.Grid;
            GridView view = grid.MainView as GridView;
            // Specify a data source.
            grid.DataSource = dataSource;
            // Resize columns according to their values.
            view.BestFitColumns();
            // Locate a row containing a specific value.
            view.FocusedRowHandle = view.LocateByValue("Country", "UK");

            // Display a splitter and second grid control.
            gridSplitContainer.ShowSplitView();

            // Customize the second grid control.
            GridControl secondGrid = gridSplitContainer.SplitChildGrid;
            GridView secondView = secondGrid.MainView as GridView;
            // Locate a row containing a specific value.
            secondView.FocusedRowHandle = secondView.LocateByValue("Country", "Sweden");
        }

        private void gridSplitContainer_SplitViewCreated(object sender, EventArgs e) {
            // Display the Embedded Navigator for the second grid control 
            // in the horizontally oriented Split View.
            GridSplitContainer gsc = sender as GridSplitContainer;
            if (!gsc.Horizontal)
                gsc.SplitChildGrid.UseEmbeddedNavigator = true;
        }


        private IList CreateDataSource() {
            List<MyRecord> list = new List<MyRecord>();
            list.Add(new MyRecord(1, "Rene Phillips", "USA"));
            list.Add(new MyRecord(2, "Robert McKinsey", "UK"));
            list.Add(new MyRecord(3, "Christina Berglund", "Sweden"));
            list.Add(new MyRecord(4, "Martín Sommer", "Spain"));
            list.Add(new MyRecord(5, "Laurence Lebihan", "France"));
            list.Add(new MyRecord(6, "Elizabeth Lincoln", "Canada"));
            list.Add(new MyRecord(7, "Steven Baum", "USA"));
            return list;
        }

        
    }

    public class MyRecord {
        public int ID { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public MyRecord(int id, string name, string country) {
            ID = id;
            Name = name;
            Country = country;
        }
    }
}
