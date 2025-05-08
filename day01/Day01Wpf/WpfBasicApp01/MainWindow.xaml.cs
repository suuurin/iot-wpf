﻿using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBasicApp01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 메인윈도우 로드후 이벤트처리 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // DB연결
            // 데이터그리드에 데이터를 읽어오기
            LoadControlFromDb();
            LoadGridFromDb();
        }

        private async void LoadControlFromDb()
        {
            // 1. 연결문자열(DB연결문자열은 필수)
            string connectionString = "Server=localhost;Database=bookrentalshop;Uid=root;Pwd=12345;Charset=utf8;";
            // 2. 사용쿼리
            string query = "SELECT division, names FROM divtbl";

            // Dictionary나 KeyValuePair 둘다 상관없음
            List<KeyValuePair<string, string>> divisions = new List<KeyValuePair<string, string>>();
            
            // 3. DB연결, 명령, 리더
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader(); // 데이터 가져올때                    

                    while (reader.Read())
                    {
                        var division = reader.GetString("division");
                        var names = reader.GetString("names");

                        
                        divisions.Add(new KeyValuePair<string, string>(division, names));
                    }
                }
                catch (MySqlException ex)
                {
                    await this.ShowMessageAsync($"에러! {ex.Message}", "에러");
                }
            } // conn.Close() 자동발생

            CboDivisions.ItemsSource = divisions; // 데이터연동
        }

        private void LoadGridFromDb()
        {
            // 1. 연결문자열(DB연결문자열은 필수)
            string connectionString = "Server=localhost;Database=bookrentalshop;Uid=root;Pwd=12345;Charset=utf8;";
            // 2. 사용쿼리, 기본쿼리로 먼저 작업 후 필요한 실제쿼리로 변경해도
            string query = @"SELECT b.Idx, b.Author, b.Division, b.Names, b.ReleaseDate, b.ISBN, b.Price,
                                    d.Names AS dNames
                               FROM bookstbl AS b, divtbl AS d
                              WHERE b.Division = d.Division
                              ORDER by b.Idx";

            // 3. DB연결, 명령, 리더
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    GrdBooks.ItemsSource = dt.DefaultView;
                }
                catch (MySqlException ex)
                {
                    // 나중에...
                }
            } // conn.Close() 자동발생
        }

        /// <summary>
        /// 데이터그리드 더블클릭 이벤트핸들러
        /// 선택한 그리드의 레코트값이 오른쪽 상세에 출력함
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GrdBooks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (GrdBooks.SelectedItems.Count == 1)
            {   // 그리드 데이터를 하나만 선택했을 때
                var item = GrdBooks.SelectedItems[0] as DataRowView;  // 데이터그리드의 데이터는 IList형식, 그중 한건은 DataRowView 객체로 형변환가능


                //MessageBox.Show(item.Row["Names"].ToString());
                NudIdx.Value = Convert.ToDouble(item.Row["Idx"]);
                CboDivisions.SelectedValue = Convert.ToString(item.Row["Division"]);
                TxtNames.Text = Convert.ToString(item.Row["Names"]);
                TxtAuthor.Text = Convert.ToString(item.Row["Author"]);
                TxtIsbn.Text = Convert.ToString(item.Row["ISBN"]);
                TxtPrice.Text = Convert.ToString(item.Row["Price"]);

                DpcReleaseDate.Text = Convert.ToString(item.Row["ReleaseDate"]);
            }

            await this.ShowMessageAsync($"처리완료!", "메시지");
        }
    }
}