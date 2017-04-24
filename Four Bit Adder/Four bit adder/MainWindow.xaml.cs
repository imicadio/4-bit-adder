using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Four_bit_adder
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Kod kod = new Kod();
        public MainWindow()
        {
            InitializeComponent();
            red.Visibility = Visibility.Hidden;
            grey.Visibility = Visibility.Hidden;

            A10.Visibility = Visibility.Hidden;
            A11.Visibility = Visibility.Hidden;
            A12.Visibility = Visibility.Hidden;
            A13.Visibility = Visibility.Hidden;

            B10.Visibility = Visibility.Hidden;
            B11.Visibility = Visibility.Hidden;
            B12.Visibility = Visibility.Hidden;
            B13.Visibility = Visibility.Hidden;

            ab10b1.Visibility = Visibility.Hidden;
            ab11b1.Visibility = Visibility.Hidden;
            ab12b1.Visibility = Visibility.Hidden;
            ab13b1.Visibility = Visibility.Hidden;

            ab10a1.Visibility = Visibility.Hidden;
            ab11a1.Visibility = Visibility.Hidden;
            ab12a1.Visibility = Visibility.Hidden;
            ab13a1.Visibility = Visibility.Hidden;

            Cin10.Visibility = Visibility.Hidden;
            Cin11.Visibility = Visibility.Hidden;
            Cin12.Visibility = Visibility.Hidden;
            Cin13.Visibility = Visibility.Hidden;
            Cin14.Visibility = Visibility.Hidden;

            S10.Visibility = Visibility.Hidden;
            S11.Visibility = Visibility.Hidden;
            S12.Visibility = Visibility.Hidden;
            S13.Visibility = Visibility.Hidden;

            AB10.Visibility = Visibility.Hidden;
            AB11.Visibility = Visibility.Hidden;
            AB12.Visibility = Visibility.Hidden;
            AB13.Visibility = Visibility.Hidden;

            cyferki.Visibility = Visibility.Hidden;
        }
        #region Dane, bramek i wyjść A i B
        int[] S = new int[] { 0, 0, 0, 0 };
        int[] A = new int[] { 0, 0, 0, 0 };
        int[] B = new int[] { 0, 0, 0, 0 };
        int[] D = new int[] { 0, 0, 0, 0 };
        int[] C = new int[] { 0, 0, 0, 0, 0 };

        string binarna1 = "";
        string binarna2 = "";

        int[] a = new int[] { 0, 0, 0, 0 };
        int[] b = new int[] { 0, 0, 0, 0 };
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            binarna1 = Liczba1.Text;
            binarna2 = Liczba2.Text;

            if (binarna1 == "" || binarna2 == "")
                MessageBox.Show("Musisz wprowadzić lidzby binarne");
            else                        
                if (kod.IsBin(binarna1) && kod.IsBin(binarna2))
                {
                    #region zamiana stringa na inta

                    binarna1.ToCharArray();
                    binarna2.ToCharArray();

                    int[] Aint = new int[binarna1.Length];
                    int[] Bint = new int[binarna2.Length];

                    for (int i = 0; i < binarna1.Length; i++)
                    {
                        Aint[i] = Convert.ToInt32(binarna1[i].ToString());
                    }

                    for (int i = 0; i < binarna2.Length; i++)
                    {
                        Bint[i] = Convert.ToInt32(binarna2[i].ToString());
                    }                    

                    if (binarna1.Length < 4)
                    {
                        int u = binarna1.Length - 1;
                        int g = 3;
                        while (u != -1)
                        {
                            if (Aint[u] == 1 || Aint[u] == 0)
                                a[g] = Aint[u];
                            else
                                continue;
                            g -= 1;
                            u -= 1;
                        }
                    }
                    else
                        a = Aint;

                    if (binarna2.Length < 4)
                    {
                        int u = binarna2.Length - 1;
                        int t = 3;
                        while (u != -1)
                        {
                            if (Bint[u] == 1 || Bint[u] == 0)
                                b[t] = Bint[u];
                            else
                                continue;
                            t -= 1;
                            u -= 1;
                        }
                    }
                    else
                        b = Bint;
                #endregion

                kod.Oblicz(a, b, S, A, B, D, C);

                wynik.Text = kod.Informacja(C, S);

                grey.Visibility = Visibility.Visible;

                #region wyświetlanie poszczególnych obrazków
                for (int i = a.Length - 1; i >= 0; i--)
                {
                    if (a[i] == 1 & i == 3)
                        A10.Visibility = Visibility.Visible;

                    else if (a[i] == 1 & i == 2)
                        A11.Visibility = Visibility.Visible;

                    else if (a[i] == 1 & i == 1)
                        A12.Visibility = Visibility.Visible;

                    else if (a[i] == 1 & i == 0)
                        A13.Visibility = Visibility.Visible;
                    else
                        continue;
                }

                for (int i = b.Length - 1; i >= 0; i--)
                {
                    if (b[i] == 1 && i == 3)
                        B10.Visibility = Visibility.Visible;

                    else if (b[i] == 1 && i == 2)
                        B11.Visibility = Visibility.Visible;

                    else if (b[i] == 1 && i == 1)
                        B12.Visibility = Visibility.Visible;

                    else if (b[i] == 1 && i == 0)
                        B13.Visibility = Visibility.Visible;
                    else
                        continue;
                }

                for (int i = A.Length - 1; i >= 0; i--)
                {
                    if (A[i] == 1 && i == 3)
                        ab10b1.Visibility = Visibility.Visible;

                    else if (A[i] == 1 && i == 2)
                        ab11b1.Visibility = Visibility.Visible;

                    else if (A[i] == 1 && i == 1)
                        ab12b1.Visibility = Visibility.Visible;

                    else if (A[i] == 1 && i == 0)
                        ab13b1.Visibility = Visibility.Visible;
                    else
                        continue;
                }

                for (int i = D.Length - 1; i >= 0; i--)
                {
                    if (D[i] == 1 & i == 3)
                        ab10a1.Visibility = Visibility.Visible;

                    else if (D[i] == 1 & i == 2)
                        ab11a1.Visibility = Visibility.Visible;

                    else if (D[i] == 1 && i == 1)
                        ab12a1.Visibility = Visibility.Visible;

                    else if (D[i] == 1 && i == 0)
                        ab13a1.Visibility = Visibility.Visible;
                    else
                        continue;
                }

                for (int i = C.Length - 1; i >= 0; i--)
                {
                    if (C[i] == 1 && i == 4)
                        Cin10.Visibility = Visibility.Visible;

                    else if (C[i] == 1 && i == 3)
                        Cin11.Visibility = Visibility.Visible;

                    else if (C[i] == 1 && i == 2)
                        Cin12.Visibility = Visibility.Visible;

                    else if (C[i] == 1 && i == 1)
                        Cin13.Visibility = Visibility.Visible;

                    else if (C[i] == 1 && i == 0)
                        Cin14.Visibility = Visibility.Visible;
                    else
                        continue;
                }

                for (int i = B.Length - 1; i >= 0; i--)
                {
                    if (B[i] == 1 && i == 3)
                        AB10.Visibility = Visibility.Visible;

                    else if (B[i] == 1 && i == 2)
                        AB11.Visibility = Visibility.Visible;

                    else if (B[i] == 1 && i == 1)
                        AB12.Visibility = Visibility.Visible;

                    else if (B[i] == 1 && i == 0)
                        AB13.Visibility = Visibility.Visible;
                    else
                        continue;
                }

                for (int i = S.Length - 1; i >= 0; i--)
                {
                    if (S[i] == 1 && i == 3)
                        S10.Visibility = Visibility.Visible;

                    else if (S[i] == 1 && i == 2)
                        S11.Visibility = Visibility.Visible;

                    else if (S[i] == 1 && i == 1)
                        S12.Visibility = Visibility.Visible;

                    else if (S[i] == 1 && i == 0)
                        S13.Visibility = Visibility.Visible;
                    else
                        continue;
                }

                #endregion

                red.Visibility = Visibility.Visible;
                cyferki.Visibility = Visibility.Visible;
            }
                else
                    MessageBox.Show("Wprowadziłeś złe wartości");
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            Liczba1.Text = String.Empty;
            Liczba2.Text = String.Empty;
            wynik.Text = " ";

            Array.Clear(A, 0, A.Length);
            Array.Clear(B, 0, B.Length);
            Array.Clear(C, 0, C.Length);
            Array.Clear(D, 0, D.Length);
            Array.Clear(S, 0, S.Length);
            Array.Clear(a, 0, a.Length);
            Array.Clear(b, 0, b.Length);

            red.Visibility = Visibility.Hidden;
            grey.Visibility = Visibility.Hidden;

            A10.Visibility = Visibility.Hidden;
            A11.Visibility = Visibility.Hidden;
            A12.Visibility = Visibility.Hidden;
            A13.Visibility = Visibility.Hidden;

            B10.Visibility = Visibility.Hidden;
            B11.Visibility = Visibility.Hidden;
            B12.Visibility = Visibility.Hidden;
            B13.Visibility = Visibility.Hidden;

            ab10b1.Visibility = Visibility.Hidden;
            ab11b1.Visibility = Visibility.Hidden;
            ab12b1.Visibility = Visibility.Hidden;
            ab13b1.Visibility = Visibility.Hidden;

            ab10a1.Visibility = Visibility.Hidden;
            ab11a1.Visibility = Visibility.Hidden;
            ab12a1.Visibility = Visibility.Hidden;
            ab13a1.Visibility = Visibility.Hidden;

            Cin10.Visibility = Visibility.Hidden;
            Cin11.Visibility = Visibility.Hidden;
            Cin12.Visibility = Visibility.Hidden;
            Cin13.Visibility = Visibility.Hidden;
            Cin14.Visibility = Visibility.Hidden;

            S10.Visibility = Visibility.Hidden;
            S11.Visibility = Visibility.Hidden;
            S12.Visibility = Visibility.Hidden;
            S13.Visibility = Visibility.Hidden;

            AB10.Visibility = Visibility.Hidden;
            AB11.Visibility = Visibility.Hidden;
            AB12.Visibility = Visibility.Hidden;
            AB13.Visibility = Visibility.Hidden;

            cyferki.Visibility = Visibility.Hidden;

        }
    }
}
