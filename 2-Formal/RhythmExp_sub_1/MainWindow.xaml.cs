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
using System.Windows.Resources;

using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.IO;
using System.Timers;


namespace RhythmExp_sub_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        public delegate void ClickHandler(object sender, EventArgs e);

        public System.Windows.Forms.Timer uiTimer0 = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer uiTimer0_1 = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer uiTimer0_2 = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer uiTimer0_3 = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer uiTimer0_4 = new System.Windows.Forms.Timer();

        public System.Windows.Forms.Timer uiTimer1 = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer uiTimer2 = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer uiTimer3 = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer uiTimer4 = new System.Windows.Forms.Timer();

        public int uiTimer1Intv = 1000;
        public int uiTimer2Intv = 1000;
        public int uiTimer3Intv = 1000;
        public int uiTimer4Intv = 1000;
        public int avg_self_paced_interval = 660;


        public int[] userAnswerTime = new int[500];
        public int[] targetDisplayTime = new int[500];

        //public DateTime[] quiz_display = new DateTime[500];
        // public DateTime[] quiz_disappear = new DateTime[500];
        // public TimeSpan[] quiz_answer = new TimeSpan[500];
        // public int[] quiz_answer_ms = new int[500];

        public DateTime[,] quiz_click = new DateTime[500, 5];
        public TimeSpan[,] click_interval = new TimeSpan[500, 5];
        public int[,] click_interval_ms = new int[500, 5];

        public DateTime[,] cue_click = new DateTime[500, 5];
        public TimeSpan[,] cue_interval = new TimeSpan[500, 5];
        public int[,] cue_interval_ms = new int[500, 5];

        public DateTime[,] pre_cue_click = new DateTime[500, 5];
        public TimeSpan[,] pre_cue_interval = new TimeSpan[500, 5];
        public int[,] pre_cue_interval_ms = new int[500, 5];

        public int[,] aperiodic_interval = new int[36, 9];


        public int[,] performance = new int[5, 5];

        public int taskNum = 0;
        public int subTask = 0;
        public int countTask = 0;

        public int next_cue = 1;

        public int type = 0;
        public string[] taskType = { "SelfPacedClick", "ComputerRhythmic", "ComputerAperiodic", "UserActivated", "ComputerAligned" };
        public int[] taskFlag = new int[5];

        public int UL_Index = 0;
        public int UR_Index = 0;
        public int DL_Index = 0;
        public int DR_Index = 0;


        public string[,] randomisedCues = new string[500, 4];
        public string[,] answers = new string[500, 4];
        public string[,] TorF = new string[500, 4];


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            taskFlag[1] = taskFlag[2] = taskFlag[3] = taskFlag[4] = 0;

            var brush0 = new ImageBrush();
            brush0.ImageSource = new BitmapImage(new Uri("Images/blurred-cross.png", UriKind.Relative));
            Task34_prepare_1.Background = Task34_prepare_2.Background = Task34_prepare_3.Background = Task34_prepare_4.Background = brush0;


            // Canvas.SetLeft(Task2Btn, (***.Width - Task2Btn.Width) / 2);

            //初始化用户控件的图片
            //myLeftCursor.image1.Source = new BitmapImage(new Uri("/KinectSmartRecipe;component/Images/pic/CursorHand_Left.png", UriKind.Relative));

            // ColourTarget.image1.Source = new BitmapImage(new Uri("/RhythmExp_trial_01;component/Images/blue-red-black.png", UriKind.Relative));
            //BackBtn1.image1.Source = new BitmapImage(new Uri("/KinectSmartRecipe;component/Images/eng/back1_1.png", UriKind.Relative));
            //BackBtn1.image2.Source = new BitmapImage(new Uri("/KinectSmartRecipe;component/Images/eng/back1_2.png", UriKind.Relative));

        }
        public void hidePlus(object sender, EventArgs e)
        {
            if (uiTimer0.Enabled)
            {


                if (type == 3)
                {
                    Task3Switch.Visibility = System.Windows.Visibility.Hidden;
                    UpLeftBtn.Visibility = System.Windows.Visibility.Visible;
                    cue_click[countTask, 0] = System.DateTime.Now;
                }
                else
                {
                    UpLeft.Visibility = System.Windows.Visibility.Visible;
                    Prepare_1.Visibility = System.Windows.Visibility.Hidden;
                    //Prepare_2.Visibility = System.Windows.Visibility.Visible;
                }
            }
            uiTimer0.Tick -= hidePlus;
            uiTimer0.Stop();
        }
        public void hidePlus_1(object sender, EventArgs e)
        {
            if (uiTimer0_1.Enabled)
            {


                if (type == 3)
                {
                    Task3Switch.Visibility = System.Windows.Visibility.Hidden;
                    UpLeftBtn.Visibility = System.Windows.Visibility.Visible;
                    cue_click[countTask, 0] = System.DateTime.Now;
                }
                else
                {
                    //UpLeft.Visibility = System.Windows.Visibility.Visible;
                    Prepare_1.Visibility = System.Windows.Visibility.Hidden;
                    Prepare_2.Visibility = System.Windows.Visibility.Visible;
                }
            }
            uiTimer0_1.Tick -= hidePlus_1;
            uiTimer0_1.Stop();
        }
        public void hidePlus_2(object sender, EventArgs e)
        {
            if (uiTimer0_2.Enabled)
            {


                if (type == 3)
                {
                    Task3Switch.Visibility = System.Windows.Visibility.Hidden;
                    UpLeftBtn.Visibility = System.Windows.Visibility.Visible;
                    cue_click[countTask, 0] = System.DateTime.Now;
                }
                else
                {
                    Prepare_2.Visibility = System.Windows.Visibility.Hidden;
                    Prepare_3.Visibility = System.Windows.Visibility.Visible;
                }
            }
            uiTimer0_2.Tick -= hidePlus_2;
            uiTimer0_2.Stop();
        }
        public void hidePlus_3(object sender, EventArgs e)
        {
            if (uiTimer0_3.Enabled)
            {


                if (type == 3)
                {
                    Task3Switch.Visibility = System.Windows.Visibility.Hidden;
                    UpLeftBtn.Visibility = System.Windows.Visibility.Visible;
                    cue_click[countTask, 0] = System.DateTime.Now;
                }
                else
                {
                    Prepare_3.Visibility = System.Windows.Visibility.Hidden;
                    Prepare_4.Visibility = System.Windows.Visibility.Visible;
                }
            }
            uiTimer0_3.Tick -= hidePlus_3;
            uiTimer0_3.Stop();
        }
        public void hidePlus_4(object sender, EventArgs e)
        {
            if (uiTimer0_4.Enabled)
            {


                if (type == 3)
                {
                    Task3Switch.Visibility = System.Windows.Visibility.Hidden;
                    UpLeftBtn.Visibility = System.Windows.Visibility.Visible;
                    cue_click[countTask, 0] = System.DateTime.Now;
                }
                else
                {
                    Prepare_4.Visibility = System.Windows.Visibility.Hidden;

                    UpLeft.Visibility = System.Windows.Visibility.Visible;

                }
            }
            uiTimer0_4.Tick -= hidePlus_4;
            uiTimer0_4.Stop();
        }

        public void hideUpLeft(object sender, EventArgs e)
        {
            if (uiTimer1.Enabled)
            {
                UpLeft.Visibility = System.Windows.Visibility.Hidden;
                UpRight.Visibility = System.Windows.Visibility.Visible;
            }
            uiTimer1.Tick -= hideUpLeft;
            uiTimer1.Stop();
        }

        public void hideUpRight(object sender, EventArgs e)
        {
            if (uiTimer2.Enabled)
            {
                UpRight.Visibility = System.Windows.Visibility.Hidden;
                DownRight.Visibility = System.Windows.Visibility.Visible;
            }
            uiTimer2.Tick -= hideUpRight;
            uiTimer2.Stop();
        }

        public void hideDownRight(object sender, EventArgs e)
        {
            if (uiTimer3.Enabled)
            {
                DownRight.Visibility = System.Windows.Visibility.Hidden;
                DownLeft.Visibility = System.Windows.Visibility.Visible;
            }
            uiTimer3.Tick -= hideDownRight;
            uiTimer3.Stop();
        }

        public void hideDownLeft(object sender, EventArgs e)
        {
            if (uiTimer4.Enabled)
            {
                DownLeft.Visibility = System.Windows.Visibility.Hidden;
                CB_UL.Visibility = System.Windows.Visibility.Visible;
                this.Cursor = System.Windows.Input.Cursors.Arrow;

            }
            uiTimer4.Tick -= hideDownLeft;
            uiTimer4.Stop();
            quiz_click[countTask, 0] = System.DateTime.Now;
        }


        private void TaskBtn1_Click(object sender, RoutedEventArgs e)
        {
            type = 1;
            taskFlag[1] = 1;
            countTask++;
            subTask++;
            TaskBtn1.Visibility = TaskBtn2.Visibility = TaskBtn3.Visibility = TaskBtn4.Visibility = System.Windows.Visibility.Hidden;

            this.Cursor = System.Windows.Input.Cursors.None;

            randomiseCues(countTask);

            var brush0 = new ImageBrush();
            brush0.ImageSource = new BitmapImage(new Uri("Images/blurred-cross.png", UriKind.Relative));
            Prepare_1.Background = Prepare_2.Background = Prepare_3.Background = Prepare_4.Background = brush0;

            Prepare_1.Visibility = System.Windows.Visibility.Visible;

            if (avg_self_paced_interval >= 300)
            {
                uiTimer0_1.Interval = (int)(1 * (double)avg_self_paced_interval); uiTimer0_1.Tick += hidePlus_1;
                uiTimer0_2.Interval = (int)(2 * (double)avg_self_paced_interval); uiTimer0_2.Tick += hidePlus_2;
                uiTimer0_3.Interval = (int)(3 * (double)avg_self_paced_interval); uiTimer0_3.Tick += hidePlus_3;
                uiTimer0_4.Interval = (int)(4 * (double)avg_self_paced_interval); uiTimer0_4.Tick += hidePlus_4;
                uiTimer1.Interval = (int)(5 * (double)avg_self_paced_interval); uiTimer1.Tick += hideUpLeft;
                uiTimer2.Interval = (int)(6 * (double)avg_self_paced_interval); uiTimer2.Tick += hideUpRight;
                uiTimer3.Interval = (int)(7 * (double)avg_self_paced_interval); uiTimer3.Tick += hideDownRight;
                uiTimer4.Interval = (int)(8 * (double)avg_self_paced_interval); uiTimer4.Tick += hideDownLeft;


            }
            else
            {
                uiTimer0_1.Interval = 660; uiTimer0_1.Tick += hidePlus_1;
                uiTimer0_2.Interval = 2 * 660; uiTimer0_2.Tick += hidePlus_2;
                uiTimer0_3.Interval = 3 * 660; uiTimer0_3.Tick += hidePlus_3;
                uiTimer0_4.Interval = 4 * 660; uiTimer0_4.Tick += hidePlus_4;
                uiTimer1.Interval = 5 * 660; uiTimer1.Tick += hideUpLeft;
                uiTimer2.Interval = 6 * 660; uiTimer2.Tick += hideUpRight;
                uiTimer3.Interval = 7 * 660; uiTimer3.Tick += hideDownRight;
                uiTimer4.Interval = 8 * 660; uiTimer4.Tick += hideDownLeft;
            }
            write_rhythm(taskType[type], countTask, "Computer_pre_Rhythmic", uiTimer0_1.Interval, uiTimer0_2.Interval - uiTimer0_1.Interval, uiTimer0_3.Interval - uiTimer0_2.Interval, uiTimer0_4.Interval - uiTimer0_3.Interval, System.DateTime.Now);

            write_rhythm(taskType[type], countTask, "ComputerRhythmic", uiTimer1.Interval - uiTimer0_4.Interval, uiTimer2.Interval - uiTimer1.Interval, uiTimer3.Interval - uiTimer2.Interval, uiTimer4.Interval - uiTimer3.Interval, System.DateTime.Now);

            uiTimer0_1.Start();
            uiTimer0_2.Start();
            uiTimer0_3.Start();
            uiTimer0_4.Start();
            uiTimer1.Start();
            uiTimer2.Start();
            uiTimer3.Start();
            uiTimer4.Start();
        }

        private void TaskBtn2_Click(object sender, RoutedEventArgs e)
        {
            type = 2;
            taskFlag[2] = 1;
            countTask++;
            subTask++;
            Prepare_1.Visibility = System.Windows.Visibility.Visible;
            TaskBtn1.Visibility = TaskBtn2.Visibility = TaskBtn3.Visibility = TaskBtn4.Visibility = System.Windows.Visibility.Hidden;

            this.Cursor = System.Windows.Input.Cursors.None;

            randomiseCues(countTask);

            var brush0 = new ImageBrush();
            brush0.ImageSource = new BitmapImage(new Uri("Images/blurred-cross.png", UriKind.Relative));
            Prepare_1.Background = Prepare_2.Background = Prepare_3.Background = Prepare_4.Background = brush0;


            ReadAperiodicInterval(aperiodic_interval);
            /*
            Random timer_Rnd = new Random();
            int a1 = timer_Rnd.Next(100); int a2 = timer_Rnd.Next(100);
            int b1 = timer_Rnd.Next(100); int b2 = timer_Rnd.Next(100);
            int c1 = timer_Rnd.Next(100); int c2 = timer_Rnd.Next(100);
            int d1 = timer_Rnd.Next(100); int d2 = timer_Rnd.Next(100);
            int e1 = timer_Rnd.Next(100);

            uiTimer0_1.Interval = 250 + 3000 * a1 / (a1 + b1 + c1 + d1 + e1); uiTimer0_1.Tick += hidePlus_1;
            uiTimer0_2.Interval = uiTimer0_1.Interval + 250 + 3000 * b1 / (a1 + b1 + c1 + d1 + e1); uiTimer0_2.Tick += hidePlus_2;
            uiTimer0_3.Interval = uiTimer0_2.Interval + 250 + 3000 * c1 / (a1 + b1 + c1 + d1 + e1); uiTimer0_3.Tick += hidePlus_3;
            uiTimer0_4.Interval = uiTimer0_3.Interval + 250 + 3000 * d1 / (a1 + b1 + c1 + d1 + e1); uiTimer0_4.Tick += hidePlus_4;

            uiTimer1.Interval = 4000 + 250 + 3250 * a2 / (a2 + b2 + c2 + d2); uiTimer1.Tick += hideUpLeft;
            uiTimer2.Interval = uiTimer1.Interval + 250 + 3250 * b2 / (a2 + b2 + c2 + d2); uiTimer2.Tick += hideUpRight;
            uiTimer3.Interval = uiTimer2.Interval + 250 + 3250 * c2 / (a2 + b2 + c2 + d2); uiTimer3.Tick += hideDownRight;
            uiTimer4.Interval = 8000; uiTimer4.Tick += hideDownLeft;
            */

            uiTimer0_1.Interval = aperiodic_interval[subTask-1, 0]; uiTimer0_1.Tick += hidePlus_1;
            uiTimer0_2.Interval = uiTimer0_1.Interval + aperiodic_interval[subTask-1, 1]; uiTimer0_2.Tick += hidePlus_2;
            uiTimer0_3.Interval = uiTimer0_2.Interval + aperiodic_interval[subTask-1, 2]; uiTimer0_3.Tick += hidePlus_3;
            uiTimer0_4.Interval = uiTimer0_3.Interval + aperiodic_interval[subTask-1, 3]; uiTimer0_4.Tick += hidePlus_4;

            uiTimer1.Interval = uiTimer0_4.Interval + aperiodic_interval[subTask-1, 4]; uiTimer1.Tick += hideUpLeft;
            uiTimer2.Interval = uiTimer1.Interval + aperiodic_interval[subTask-1, 5]; uiTimer2.Tick += hideUpRight;
            uiTimer3.Interval = uiTimer2.Interval + aperiodic_interval[subTask-1, 6]; uiTimer3.Tick += hideDownRight;
            uiTimer4.Interval = uiTimer3.Interval + aperiodic_interval[subTask-1, 7]; ; uiTimer4.Tick += hideDownLeft;
            write_rhythm(taskType[type], countTask, "Aperiodic_pre_Intervals", aperiodic_interval[subTask-1, 0], aperiodic_interval[subTask-1, 1], aperiodic_interval[subTask-1, 2], aperiodic_interval[subTask-1, 3], System.DateTime.Now);
            write_rhythm(taskType[type], countTask, "AperiodicIntervals", aperiodic_interval[subTask - 1, 4], aperiodic_interval[subTask - 1, 5], aperiodic_interval[subTask - 1, 6], aperiodic_interval[subTask - 1, 7], System.DateTime.Now);
            uiTimer0_1.Start();
            uiTimer0_2.Start();
            uiTimer0_3.Start();
            uiTimer0_4.Start();

            uiTimer1.Start();
            uiTimer2.Start();
            uiTimer3.Start();
            uiTimer4.Start();


        }

        private void TaskBtn3_Click(object sender, RoutedEventArgs e)
        {
            type = 3;
            taskFlag[3] = 1;
            countTask++;
            subTask++;
            //Prepare.Visibility = System.Windows.Visibility.Visible;
            TaskBtn1.Visibility = TaskBtn2.Visibility = TaskBtn3.Visibility = TaskBtn4.Visibility = System.Windows.Visibility.Hidden;
            //CB_UL.Visibility = CB_UR.Visibility = CB_DL.Visibility = CB_DR.Visibility = System.Windows.Visibility.Hidden;

            randomiseCues(countTask);
            var brush0 = new ImageBrush();
            brush0.ImageSource = new BitmapImage(new Uri("Images/blurred-cross.png", UriKind.Relative));
            Task34_prepare_1.Background = Task34_prepare_2.Background = Task34_prepare_3.Background = Task34_prepare_4.Background = brush0;
            //Task3Switch.Visibility = System.Windows.Visibility.Visible;
            Task34_prepare_1.Visibility = System.Windows.Visibility.Visible;
            pre_cue_click[countTask, 0] = System.DateTime.Now;
            //Task3Switch.Content = "+";
            // var brush0 = new ImageBrush();
            //brush0.ImageSource = new BitmapImage(new Uri("Images/Clock.png", UriKind.Relative));

            //  Task34_prepare_1.Background = Task34_prepare_2.Background = Task34_prepare_3.Background = Task34_prepare_4.Background = brush0;

        }

        private void Task3Switch_Click(object sender, RoutedEventArgs e)
        {

            if (next_cue == 1)
            {
                cue_click[countTask, 0] = System.DateTime.Now;
                Prepare.Visibility = System.Windows.Visibility.Hidden;
                Task3Switch.Visibility = System.Windows.Visibility.Hidden;
                UpLeft.Visibility = System.Windows.Visibility.Hidden;
                UpLeftBtn.Visibility = System.Windows.Visibility.Visible;
                Task3Switch.Content = "+";
                next_cue = 2;
            }
            else if (next_cue == 2)
            {
                cue_click[countTask, 1] = System.DateTime.Now;
                UpLeft.Visibility = System.Windows.Visibility.Hidden;
                //UpRight.Visibility = System.Windows.Visibility.Visible;
                Task3Switch.Content = "+";
                next_cue = 3;
            }
            else if (next_cue == 3)
            {
                cue_click[countTask, 2] = System.DateTime.Now;
                UpRight.Visibility = System.Windows.Visibility.Hidden;
                //DownRight.Visibility = System.Windows.Visibility.Visible;
                Task3Switch.Content = "+";
                next_cue = 4;
            }
            else if (next_cue == 4)
            {
                cue_click[countTask, 3] = System.DateTime.Now;
                DownRight.Visibility = System.Windows.Visibility.Hidden;
                //DownLeft.Visibility = System.Windows.Visibility.Visible;
                Task3Switch.Content = "+";
                next_cue = 5;
            }
            else if (next_cue == 5)
            {
                cue_click[countTask, 4] = System.DateTime.Now;
                DownLeft.Visibility = Task3Switch.Visibility = System.Windows.Visibility.Hidden;
                quiz_click[countTask, 0] = System.DateTime.Now;
                CB_UL.Visibility = System.Windows.Visibility.Visible;
                Task3Switch.Content = "+";

                cue_interval[countTask, 1] = cue_click[countTask, 1] - cue_click[countTask, 0];
                cue_interval_ms[countTask, 1] = Convert.ToInt32(cue_interval[countTask, 1].TotalMilliseconds);
                cue_interval[countTask, 2] = cue_click[countTask, 2] - cue_click[countTask, 1];
                cue_interval_ms[countTask, 2] = Convert.ToInt32(cue_interval[countTask, 2].TotalMilliseconds);
                cue_interval[countTask, 3] = cue_click[countTask, 3] - cue_click[countTask, 2];
                cue_interval_ms[countTask, 3] = Convert.ToInt32(cue_interval[countTask, 3].TotalMilliseconds);
                cue_interval[countTask, 4] = cue_click[countTask, 4] - cue_click[countTask, 3];
                cue_interval_ms[countTask, 4] = Convert.ToInt32(cue_interval[countTask, 4].TotalMilliseconds);

                write_rhythm(taskType[type], countTask, "SelfPaced_cue_Rhythm", cue_interval_ms[countTask, 1], cue_interval_ms[countTask, 2],
                    cue_interval_ms[countTask, 3], cue_interval_ms[countTask, 4], System.DateTime.Now);

            }
        }

        private void TaskBtn4_Click(object sender, RoutedEventArgs e)
        {
            type = 4;
            taskFlag[4] = 1;
            countTask++;
            subTask++;
            TaskBtn1.Visibility = TaskBtn2.Visibility = TaskBtn3.Visibility = TaskBtn4.Visibility = System.Windows.Visibility.Hidden;
            randomiseCues(countTask);
            var brush0 = new ImageBrush();
            brush0.ImageSource = new BitmapImage(new Uri("Images/blurred-cross.png", UriKind.Relative));
            Task34_prepare_1.Background = Task34_prepare_2.Background = Task34_prepare_3.Background = Task34_prepare_4.Background = brush0;

            Task34_prepare_1.Visibility = System.Windows.Visibility.Visible;
            pre_cue_click[countTask, 0] = System.DateTime.Now;
            /*
            TaskBtn1.Visibility = TaskBtn2.Visibility = TaskBtn3.Visibility = TaskBtn4.Visibility = System.Windows.Visibility.Hidden;

            randomiseCues(countTask);
            Prepare.Visibility = System.Windows.Visibility.Visible;
            uiTimer0.Interval = 1000; uiTimer0.Tick += hidePlus;
            uiTimer1.Interval = 2000; uiTimer1.Tick += hideUpLeft;
            uiTimer2.Interval = 3000; uiTimer2.Tick += hideUpRight;
            uiTimer3.Interval = 4000; uiTimer3.Tick += hideDownRight;
            uiTimer4.Interval = 5000; uiTimer4.Tick += hideDownLeft;
            write_rhythm(taskType[type], countTask, "PresetRhythm", uiTimer1.Interval - uiTimer0.Interval, uiTimer2.Interval - uiTimer1.Interval, uiTimer3.Interval - uiTimer2.Interval, uiTimer4.Interval - uiTimer3.Interval, System.DateTime.Now);

            uiTimer0.Start();
            uiTimer1.Start();
            uiTimer2.Start();
            uiTimer3.Start();
            uiTimer4.Start();
            */

        }

        public void randomiseCues(int countTask)
        {
            Random cue_Rnd = new Random();
            int cue_1 = cue_Rnd.Next(4);
            int cue_2 = cue_Rnd.Next(4);
            int cue_3 = cue_Rnd.Next(4);
            int cue_4 = cue_Rnd.Next(4);
            var brush1 = new ImageBrush();
            brush1.ImageSource = new BitmapImage(new Uri("Images/Cue-1.png", UriKind.Relative));
            var brush2 = new ImageBrush();
            brush2.ImageSource = new BitmapImage(new Uri("Images/Cue-2.png", UriKind.Relative));
            var brush3 = new ImageBrush();
            brush3.ImageSource = new BitmapImage(new Uri("Images/Cue-3.png", UriKind.Relative));
            var brush4 = new ImageBrush();
            brush4.ImageSource = new BitmapImage(new Uri("Images/Cue-4.png", UriKind.Relative));



            if (cue_1 == 1)
            {
                UpLeft.Source = new BitmapImage(new Uri("/RhythmExp_sub_1;component/Images/Cue-1.png", UriKind.Relative));

                UpLeftBtn.Background = brush1;

                randomisedCues[countTask, 0] = "Cue1";
            }
            else if (cue_1 == 2)
            {
                UpLeft.Source = new BitmapImage(new Uri("/RhythmExp_sub_1;component/Images/Cue-2.png", UriKind.Relative));
                UpLeftBtn.Background = brush2;
                randomisedCues[countTask, 0] = "Cue2";
            }
            else if (cue_1 == 3)
            {
                UpLeft.Source = new BitmapImage(new Uri("/RhythmExp_sub_1;component/Images/Cue-3.png", UriKind.Relative));
                UpLeftBtn.Background = brush3;
                randomisedCues[countTask, 0] = "Cue3";
            }
            else if (cue_1 == 0)
            {
                UpLeft.Source = new BitmapImage(new Uri("/RhythmExp_sub_1;component/Images/Cue-4.png", UriKind.Relative));
                UpLeftBtn.Background = brush4;
                randomisedCues[countTask, 0] = "Cue4";
            }


            if (cue_2 == 2)
            {
                UpRight.Source = new BitmapImage(new Uri("/RhythmExp_sub_1;component/Images/Cue-1.png", UriKind.Relative));
                UpRightBtn.Background = brush1;
                randomisedCues[countTask, 1] = "Cue1";
            }
            else if (cue_2 == 3)
            {
                UpRight.Source = new BitmapImage(new Uri("/RhythmExp_sub_1;component/Images/Cue-2.png", UriKind.Relative));
                UpRightBtn.Background = brush2;
                randomisedCues[countTask, 1] = "Cue2";
            }
            else if (cue_2 == 0)
            {
                UpRight.Source = new BitmapImage(new Uri("/RhythmExp_sub_1;component/Images/Cue-3.png", UriKind.Relative));
                UpRightBtn.Background = brush3;
                randomisedCues[countTask, 1] = "Cue3";
            }
            else if (cue_2 == 1)
            {
                UpRight.Source = new BitmapImage(new Uri("/RhythmExp_sub_1;component/Images/Cue-4.png", UriKind.Relative));
                UpRightBtn.Background = brush4;
                randomisedCues[countTask, 1] = "Cue4";
            }

            if (cue_3 == 3)
            {
                DownRight.Source = new BitmapImage(new Uri("/RhythmExp_sub_1;component/Images/Cue-1.png", UriKind.Relative));
                DownRightBtn.Background = brush1;
                randomisedCues[countTask, 2] = "Cue1";
            }
            else if (cue_3 == 0)
            {
                DownRight.Source = new BitmapImage(new Uri("/RhythmExp_sub_1;component/Images/Cue-2.png", UriKind.Relative));
                DownRightBtn.Background = brush2;
                randomisedCues[countTask, 2] = "Cue2";
            }
            else if (cue_3 == 1)
            {
                DownRight.Source = new BitmapImage(new Uri("/RhythmExp_sub_1;component/Images/Cue-3.png", UriKind.Relative));
                DownRightBtn.Background = brush3;
                randomisedCues[countTask, 2] = "Cue3";
            }
            else if (cue_3 == 2)
            {
                DownRight.Source = new BitmapImage(new Uri("/RhythmExp_sub_1;component/Images/Cue-4.png", UriKind.Relative));
                DownRightBtn.Background = brush4;
                randomisedCues[countTask, 2] = "Cue4";
            }

            if (cue_4 == 0)
            {
                DownLeft.Source = new BitmapImage(new Uri("/RhythmExp_sub_1;component/Images/Cue-1.png", UriKind.Relative));
                DownLeftBtn.Background = brush1;
                randomisedCues[countTask, 3] = "Cue1";
            }
            else if (cue_4 == 1)
            {
                DownLeft.Source = new BitmapImage(new Uri("/RhythmExp_sub_1;component/Images/Cue-2.png", UriKind.Relative));
                DownLeftBtn.Background = brush2;
                randomisedCues[countTask, 3] = "Cue2";
            }
            else if (cue_4 == 2)
            {
                DownLeft.Source = new BitmapImage(new Uri("/RhythmExp_sub_1;component/Images/Cue-3.png", UriKind.Relative));
                DownLeftBtn.Background = brush3;
                randomisedCues[countTask, 3] = "Cue3";
            }
            else if (cue_4 == 3)
            {
                DownLeft.Source = new BitmapImage(new Uri("/RhythmExp_sub_1;component/Images/Cue-4.png", UriKind.Relative));
                DownLeftBtn.Background = brush4;
                randomisedCues[countTask, 3] = "Cue4";
            }

        }

        private void write_answer(string taskType, int taskNum, string Choice, string TorF, DateTime dt)
        {
            System.DateTime currentTime = System.DateTime.Now;

            var dir = new DirectoryInfo(System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory));

            string file = dir.Parent.FullName + @"\TXT\Answers.txt";

            //string strWFPath = @"W:\MyCoding\Trial\RhythmExp_trial_02\RhythmExp_trial_02\TXT\DataFlow.txt";

            //string strWFPath_2 = @"W:\windows_home\MyCoding\Trial\RhythmExp_trial_02\RhythmExp_trial_02\RhythmExp_trial_02\TXT\DataFlow.txt";

            string strYMD = currentTime.ToString("dd-MM-yy");
            //("yyyy-MM-dd HH：mm：ss：ffff");

            string FILE_NAME = strYMD + ".txt";//每天按照日期建立一个不同的文件名
            StreamWriter sr;
            /*
            if (File.Exists(strWFPath)) //如果文件存在,则创建File.AppendText对象
            {
                sr = File.AppendText(strWFPath);
            }
            else  //如果文件不存在,则创建File.CreateText对象
            {
                sr = File.AppendText(strWFPath_2);
            }
            */

            sr = File.AppendText(file);
            //DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss.fff")
            sr.WriteLine(dt.ToString("hh:mm:ss.fff") + "\t" + taskType + "\t" + taskNum + "\t" + Choice + "\t" + TorF);//将传入的字符串加上时间写入文本文件一行
            sr.Close();
        }

        private void write_rhythm(string taskType, int taskNum, string generator, int time1, int time2, int time3, int time4, DateTime dt)
        {
            System.DateTime currentTime = System.DateTime.Now;

            var dir = new DirectoryInfo(System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory));

            string file = dir.Parent.FullName + @"\TXT\Rhythm.txt";

            //string strWFPath = @"W:\MyCoding\Trial\RhythmExp_trial_02\RhythmExp_trial_02\TXT\DataFlow.txt";

            //string strWFPath_2 = @"W:\windows_home\MyCoding\Trial\RhythmExp_trial_02\RhythmExp_trial_02\RhythmExp_trial_02\TXT\DataFlow.txt";

            string strYMD = currentTime.ToString("dd-MM-yy");
            //("yyyy-MM-dd HH：mm：ss：ffff");

            string FILE_NAME = strYMD + ".txt";//每天按照日期建立一个不同的文件名
            StreamWriter sr;
            /*
            if (File.Exists(strWFPath)) //如果文件存在,则创建File.AppendText对象
            {
                sr = File.AppendText(strWFPath);
            }
            else  //如果文件不存在,则创建File.CreateText对象
            {
                sr = File.AppendText(strWFPath_2);
            }
            */

            sr = File.AppendText(file);
            //DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss.fff")
            sr.WriteLine(dt.ToString("hh:mm:ss.fff") + "\t" + taskType + "\t" + taskNum + "\t" + generator + ":\t" + time1 + "\t" + time2 + "\t" + time3 + "\t" + time4);//将传入的字符串加上时间写入文本文件一行
            sr.Close();
        }

        private void UpLeftBtn_Click(object sender, RoutedEventArgs e)
        {

            UpLeftBtn.Visibility = UpRight.Visibility = System.Windows.Visibility.Hidden;
            UpRightBtn.Visibility = System.Windows.Visibility.Visible;
            cue_click[countTask, 1] = System.DateTime.Now;
        }

        private void UpRightBtn_Click(object sender, RoutedEventArgs e)
        {
            UpRightBtn.Visibility = DownRight.Visibility = System.Windows.Visibility.Hidden;
            DownRightBtn.Visibility = System.Windows.Visibility.Visible;
            cue_click[countTask, 2] = System.DateTime.Now;
        }

        private void DownRightBtn_Click(object sender, RoutedEventArgs e)
        {
            DownRightBtn.Visibility = DownLeft.Visibility = System.Windows.Visibility.Hidden;
            DownLeftBtn.Visibility = System.Windows.Visibility.Visible;
            cue_click[countTask, 3] = System.DateTime.Now;
        }

        private void DownLeftBtn_Click(object sender, RoutedEventArgs e)
        {
            DownLeftBtn.Visibility = System.Windows.Visibility.Hidden;
            CB_UL.Visibility = System.Windows.Visibility.Visible;
            cue_click[countTask, 4] = System.DateTime.Now;
            quiz_click[countTask, 0] = System.DateTime.Now;

            cue_interval[countTask, 1] = cue_click[countTask, 1] - cue_click[countTask, 0];
            cue_interval_ms[countTask, 1] = Convert.ToInt32(cue_interval[countTask, 1].TotalMilliseconds);
            cue_interval[countTask, 2] = cue_click[countTask, 2] - cue_click[countTask, 1];
            cue_interval_ms[countTask, 2] = Convert.ToInt32(cue_interval[countTask, 2].TotalMilliseconds);
            cue_interval[countTask, 3] = cue_click[countTask, 3] - cue_click[countTask, 2];
            cue_interval_ms[countTask, 3] = Convert.ToInt32(cue_interval[countTask, 3].TotalMilliseconds);
            cue_interval[countTask, 4] = cue_click[countTask, 4] - cue_click[countTask, 3];
            cue_interval_ms[countTask, 4] = Convert.ToInt32(cue_interval[countTask, 4].TotalMilliseconds);

            write_rhythm(taskType[type], countTask, "SelfPaced_Clicks", cue_interval_ms[countTask, 1], cue_interval_ms[countTask, 2],
                cue_interval_ms[countTask, 3], cue_interval_ms[countTask, 4], System.DateTime.Now);

        }

        private void Task34_prepare_1_Click(object sender, RoutedEventArgs e)
        {
            Task34_prepare_1.Visibility = System.Windows.Visibility.Hidden;
            Task34_prepare_2.Visibility = System.Windows.Visibility.Visible;
            pre_cue_click[countTask, 1] = System.DateTime.Now;
        }


        private void Task34_prepare_2_Click(object sender, RoutedEventArgs e)
        {
            Task34_prepare_2.Visibility = System.Windows.Visibility.Hidden;
            Task34_prepare_3.Visibility = System.Windows.Visibility.Visible;
            pre_cue_click[countTask, 2] = System.DateTime.Now;
        }

        private void Task34_prepare_3_Click(object sender, RoutedEventArgs e)
        {
            Task34_prepare_3.Visibility = System.Windows.Visibility.Hidden;
            Task34_prepare_4.Visibility = System.Windows.Visibility.Visible;
            pre_cue_click[countTask, 3] = System.DateTime.Now;
        }

        private void Task34_prepare_4_Click(object sender, RoutedEventArgs e)
        {
            Task34_prepare_4.Visibility = System.Windows.Visibility.Hidden;
            cue_click[countTask, 0] = System.DateTime.Now;
            pre_cue_click[countTask, 4] = System.DateTime.Now;


            pre_cue_interval[countTask, 1] = pre_cue_click[countTask, 1] - pre_cue_click[countTask, 0];
            pre_cue_interval_ms[countTask, 1] = Convert.ToInt32(pre_cue_interval[countTask, 1].TotalMilliseconds);
            pre_cue_interval[countTask, 2] = pre_cue_click[countTask, 2] - pre_cue_click[countTask, 1];
            pre_cue_interval_ms[countTask, 2] = Convert.ToInt32(pre_cue_interval[countTask, 2].TotalMilliseconds);
            pre_cue_interval[countTask, 3] = pre_cue_click[countTask, 3] - pre_cue_click[countTask, 2];
            pre_cue_interval_ms[countTask, 3] = Convert.ToInt32(pre_cue_interval[countTask, 3].TotalMilliseconds);
            pre_cue_interval[countTask, 4] = pre_cue_click[countTask, 4] - pre_cue_click[countTask, 3];
            pre_cue_interval_ms[countTask, 4] = Convert.ToInt32(pre_cue_interval[countTask, 4].TotalMilliseconds);
            write_rhythm(taskType[type], countTask, "SelfPaced_pre_Clicks", pre_cue_interval_ms[countTask, 1], pre_cue_interval_ms[countTask, 2],
                pre_cue_interval_ms[countTask, 3], pre_cue_interval_ms[countTask, 4], System.DateTime.Now);

            if (type == 3)
            {
                UpLeftBtn.Visibility = System.Windows.Visibility.Visible;
            }
            else if (type == 4)
            {
                UpLeft.Visibility = System.Windows.Visibility.Visible;
                uiTimer1.Interval = pre_cue_interval_ms[countTask, 1]; uiTimer1.Tick += hideUpLeft;
                uiTimer2.Interval = uiTimer1.Interval + pre_cue_interval_ms[countTask, 2]; uiTimer2.Tick += hideUpRight;
                uiTimer3.Interval = uiTimer2.Interval + pre_cue_interval_ms[countTask, 3]; uiTimer3.Tick += hideDownRight;
                uiTimer4.Interval = uiTimer3.Interval + pre_cue_interval_ms[countTask, 4]; uiTimer4.Tick += hideDownLeft;
                write_rhythm(taskType[type], countTask, "ComputerAlignedRhythm", uiTimer1.Interval, uiTimer2.Interval - uiTimer1.Interval, uiTimer3.Interval - uiTimer2.Interval, uiTimer4.Interval - uiTimer3.Interval, System.DateTime.Now);

                //uiTimer0.Start();
                uiTimer1.Start();
                uiTimer2.Start();
                uiTimer3.Start();
                uiTimer4.Start();
                this.Cursor = System.Windows.Input.Cursors.None;

            }
            else if (type == 0)
            {
                countTask++;
                if (countTask <= 20)
                {
                    Task34_prepare_1.Visibility = System.Windows.Visibility.Visible;
                    pre_cue_click[countTask, 0] = System.DateTime.Now;


                }
                if (countTask == 21)
                {
                    countTask = 20;
                    int sum = 0;
                    for (int i = 1; i <= 20; i++)
                    {
                        sum = sum + pre_cue_interval_ms[i, 1] + pre_cue_interval_ms[i, 2] + pre_cue_interval_ms[i, 3] + pre_cue_interval_ms[i, 4];
                    }
                    avg_self_paced_interval = (int)(sum / 80);
                    avgselfpace.Content = avg_self_paced_interval.ToString();
                    TaskBtn1.Visibility = TaskBtn2.Visibility = TaskBtn3.Visibility = TaskBtn4.Visibility = System.Windows.Visibility.Visible;
                    write_preferredrhythm(avg_self_paced_interval);
                    Wait.Visibility = Cover.Visibility = DoneSetting.Visibility = System.Windows.Visibility.Visible;

                }


            }


        }

        private void TaskBtn0_Click(object sender, RoutedEventArgs e)
        {
            TaskBtn0.Visibility = SkipTask.Visibility = Cover.Visibility = TaskBtn1.Visibility = TaskBtn2.Visibility = TaskBtn3.Visibility = TaskBtn4.Visibility = System.Windows.Visibility.Hidden;
            countTask++;
            var brush0 = new ImageBrush();
            brush0.ImageSource = new BitmapImage(new Uri("Images/blurred-cross.png", UriKind.Relative));
            Task34_prepare_1.Background = Task34_prepare_2.Background = Task34_prepare_3.Background = Task34_prepare_4.Background = brush0;

            Task34_prepare_1.Visibility = System.Windows.Visibility.Visible;
            pre_cue_click[countTask, 0] = System.DateTime.Now;
        }

        public int SkipFlag = 0;

        private void SkipTask_Click(object sender, RoutedEventArgs e)
        {
            if (SkipFlag == 0)
            {
                SkipTask0.Visibility = SkipTask1.Visibility = SkipTask2.Visibility = SkipTask3.Visibility = SkipTask4.Visibility = System.Windows.Visibility.Visible;
                SkipFlag = 1;
                SkipTask.Content = "Done skipping";

            }
            else if (SkipFlag == 1)
            {
                Cover.Visibility = SkipTask.Visibility = SkipTask0.Visibility = SkipTask1.Visibility = SkipTask2.Visibility = SkipTask3.Visibility = SkipTask4.Visibility = System.Windows.Visibility.Hidden;
            }


        }

        private void SkipTask0_Click(object sender, RoutedEventArgs e)
        {
            TaskBtn0.Visibility = SkipTask0.Visibility = System.Windows.Visibility.Hidden;
        }

        private void SkipTask1_Click(object sender, RoutedEventArgs e)
        {
            TaskBtn1.Visibility = SkipTask1.Visibility = System.Windows.Visibility.Hidden;
            taskFlag[1] = 1;

        }

        private void SkipTask2_Click(object sender, RoutedEventArgs e)
        {
            TaskBtn2.Visibility = SkipTask2.Visibility = System.Windows.Visibility.Hidden;
            taskFlag[2] = 1;
        }

        private void SkipTask3_Click(object sender, RoutedEventArgs e)
        {
            TaskBtn3.Visibility = SkipTask3.Visibility = System.Windows.Visibility.Hidden;
            taskFlag[3] = 1;
        }

        private void SkipTask4_Click(object sender, RoutedEventArgs e)
        {
            TaskBtn4.Visibility = SkipTask4.Visibility = System.Windows.Visibility.Hidden;
            taskFlag[4] = 1;
        }


        private void write_preferredrhythm(int t)
        {
            var main = App.Current.MainWindow as MainWindow;

            var dir = new DirectoryInfo(System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory));

            string file = dir.Parent.FullName + @"\TXT\PreferredRhythm.txt";

            StreamWriter sr;


            sr = File.AppendText(file);

            sr.WriteLine("Preferred time interval: " + t + "\t" + System.DateTime.Now.ToString("hh:mm:ss.fff"));//将传入的字符串加上时间写入文本文件一行

            sr.Close();
        }


        public void ReadAperiodicInterval(int[,] aperiodic_interval)
        {
            var dir = new DirectoryInfo(System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory));

            string file = dir.Parent.FullName + @"\TXT\Aperiodic_Intervals\Aperiodic_Interval_1.txt";

            StreamReader sr = new StreamReader(file);

            // var lines = File.ReadAllLines(file).ToList();
            for (int i = 0; i < 30; i++)
            {
                string thisLine = sr.ReadLine();
                string[] thisLineData = thisLine.Split(new char[0]);
                for (int j = 0; j < 8; j++)
                {
                    aperiodic_interval[i, j] = Int32.Parse(thisLineData[j]);

                    // Int32.Parse(lines[i].Split('\t'));
                    //aperiodic_interval[i, j] = Int.TryParse(ioi_table.Rows[i][j]);
                }
            }
        }

        private void DoneSetting_Click(object sender, RoutedEventArgs e)
        {
            Wait.Visibility = Cover.Visibility = DoneSetting.Visibility = System.Windows.Visibility.Hidden;

        }
    }

}