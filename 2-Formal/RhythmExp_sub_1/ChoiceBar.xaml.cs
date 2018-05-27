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

using System.IO;




namespace RhythmExp_sub_1
{
    /// <summary>
    /// Interaction logic for ChoiceBar.xaml
    /// </summary>
    public partial class ChoiceBar : UserControl
    {
        public ChoiceBar()
        {
            InitializeComponent();
            
           
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            var main = App.Current.MainWindow as MainWindow;


            if (main.CB_UL.Visibility == System.Windows.Visibility.Visible)
            {
                main.quiz_click[main.countTask, 1] = System.DateTime.Now;
                main.answers[main.countTask, 0] = "Cue1";
                if (main.randomisedCues[main.countTask, 0] == "Cue1")
                { main.TorF[main.countTask, 0] = "True"; main.performance[main.type, 1]++;
                    write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 0] + "-" + main.answers[main.countTask, 0], "True", System.DateTime.Now); }
                else
                { main.TorF[main.countTask, 0] = "False"; write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 0] + "-" + main.answers[main.countTask, 0], "False", System.DateTime.Now); }

                main.CB_UL.Visibility = System.Windows.Visibility.Hidden;
                main.CB_UR.Visibility = System.Windows.Visibility.Visible;

            }
            else if (main.CB_UR.Visibility == System.Windows.Visibility.Visible)
            {
                main.quiz_click[main.countTask, 2] = System.DateTime.Now;
                main.answers[main.countTask, 1] = "Cue1";
                if (main.randomisedCues[main.countTask, 1] == "Cue1")
                { main.TorF[main.countTask, 1] = "True"; main.performance[main.type, 1]++;
                    write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 1] + "-" + main.answers[main.countTask, 1], "True", System.DateTime.Now); }
                else
                { main.TorF[main.countTask, 1] = "False"; write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 1] + "-" + main.answers[main.countTask, 1], "False", System.DateTime.Now); }

                main.CB_UR.Visibility = System.Windows.Visibility.Hidden;
                main.CB_DR.Visibility = System.Windows.Visibility.Visible;
            }
            else if (main.CB_DR.Visibility == System.Windows.Visibility.Visible)
            {
                main.quiz_click[main.countTask, 3] = System.DateTime.Now;
                main.answers[main.countTask, 2] = "Cue1";
                if (main.randomisedCues[main.countTask, 2] == "Cue1")
                { main.TorF[main.countTask, 2] = "True"; main.performance[main.type, 1]++;
                    write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 2] + "-" + main.answers[main.countTask, 2], "True", System.DateTime.Now); }
                else
                { main.TorF[main.countTask, 2] = "False"; write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 2] + "-" + main.answers[main.countTask, 2], "False", System.DateTime.Now); }

                main.CB_DR.Visibility = System.Windows.Visibility.Hidden;
                main.CB_DL.Visibility = System.Windows.Visibility.Visible;
            }
            else if (main.CB_DL.Visibility == System.Windows.Visibility.Visible)
            {
                main.quiz_click[main.countTask, 4] = System.DateTime.Now;
                main.answers[main.countTask, 3] = "Cue1";
                if (main.randomisedCues[main.countTask, 3] == "Cue1")
                { main.TorF[main.countTask, 3] = "True"; main.performance[main.type, 1]++;
                    write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 3] + "-" + main.answers[main.countTask, 3], "True", System.DateTime.Now); }
                else
                { main.TorF[main.countTask, 3] = "False"; write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 3] + "-" + main.answers[main.countTask, 3], "False", System.DateTime.Now); }

                main.CB_DL.Visibility = System.Windows.Visibility.Hidden;

                main.click_interval[main.countTask, 1] = main.quiz_click[main.countTask, 1] - main.quiz_click[main.countTask, 0];
                main.click_interval_ms[main.countTask, 1] = Convert.ToInt32(main.click_interval[main.countTask, 1].TotalMilliseconds);
                main.click_interval[main.countTask, 2] = main.quiz_click[main.countTask, 2] - main.quiz_click[main.countTask, 1];
                main.click_interval_ms[main.countTask, 2] = Convert.ToInt32(main.click_interval[main.countTask, 2].TotalMilliseconds);
                main.click_interval[main.countTask, 3] = main.quiz_click[main.countTask, 3] - main.quiz_click[main.countTask, 2];
                main.click_interval_ms[main.countTask, 3] = Convert.ToInt32(main.click_interval[main.countTask, 3].TotalMilliseconds);
                main.click_interval[main.countTask, 4] = main.quiz_click[main.countTask, 4] - main.quiz_click[main.countTask, 3];
                main.click_interval_ms[main.countTask, 4] = Convert.ToInt32(main.click_interval[main.countTask, 4].TotalMilliseconds);
                write_rhythm(main.taskType[main.type], main.countTask, "UserClicks", main.click_interval_ms[main.countTask, 1], main.click_interval_ms[main.countTask, 2],
                    main.click_interval_ms[main.countTask, 3], main.click_interval_ms[main.countTask, 4], System.DateTime.Now);



                main.next_cue = 1;
               

                if (main.subTask <= 29)
                {
                    main.countTask++;
                    main.subTask++;
                    main.randomiseCues(main.countTask);
                    if (main.type == 1)
                    {
                        main.Prepare_1.Visibility = System.Windows.Visibility.Visible;

                        if (main.avg_self_paced_interval >= 300)
                        {
                            main.uiTimer0_1.Interval = (int)(1 * (double)main.avg_self_paced_interval); main.uiTimer0_1.Tick += main.hidePlus_1;
                            main.uiTimer0_2.Interval = (int)(2 * (double)main.avg_self_paced_interval); main.uiTimer0_2.Tick += main.hidePlus_2;
                            main.uiTimer0_3.Interval = (int)(3 * (double)main.avg_self_paced_interval); main.uiTimer0_3.Tick += main.hidePlus_3;
                            main.uiTimer0_4.Interval = (int)(4 * (double)main.avg_self_paced_interval); main.uiTimer0_4.Tick += main.hidePlus_4;
                            main.uiTimer1.Interval = (int)(5 * (double)main.avg_self_paced_interval); main.uiTimer1.Tick += main.hideUpLeft;
                            main.uiTimer2.Interval = (int)(6 * (double)main.avg_self_paced_interval); main.uiTimer2.Tick += main.hideUpRight;
                            main.uiTimer3.Interval = (int)(7 * (double)main.avg_self_paced_interval); main.uiTimer3.Tick += main.hideDownRight;
                            main.uiTimer4.Interval = (int)(8 * (double)main.avg_self_paced_interval); main.uiTimer4.Tick += main.hideDownLeft;

                        }
                        else
                        {

                            main.uiTimer0_1.Interval = 660; main.uiTimer0_1.Tick += main.hidePlus_1;
                            main.uiTimer0_2.Interval = 2 * 660; main.uiTimer0_2.Tick += main.hidePlus_2;
                            main.uiTimer0_3.Interval = 3 * 660; main.uiTimer0_3.Tick += main.hidePlus_3;
                            main.uiTimer0_4.Interval = 4 * 660; main.uiTimer0_4.Tick += main.hidePlus_4;

                            main.uiTimer1.Interval = 5 * 660; main.uiTimer1.Tick += main.hideUpLeft;
                            main.uiTimer2.Interval = 6 * 660; main.uiTimer2.Tick += main.hideUpRight;
                            main.uiTimer3.Interval = 7 * 660; main.uiTimer3.Tick += main.hideDownRight;
                            main.uiTimer4.Interval = 8 * 660; main.uiTimer4.Tick += main.hideDownLeft;
                        }

                        write_rhythm(main.taskType[main.type], main.countTask, "Computer_pre_Rhythmic", main.uiTimer0_1.Interval,
main.uiTimer0_2.Interval - main.uiTimer0_1.Interval, main.uiTimer0_3.Interval - main.uiTimer0_2.Interval, main.uiTimer0_4.Interval - main.uiTimer0_3.Interval, System.DateTime.Now);
                        write_rhythm(main.taskType[main.type], main.countTask, "ComputerRhythmic", main.uiTimer1.Interval - main.uiTimer0_4.Interval,
    main.uiTimer2.Interval - main.uiTimer1.Interval, main.uiTimer3.Interval - main.uiTimer2.Interval, main.uiTimer4.Interval - main.uiTimer3.Interval, System.DateTime.Now);

                        main.uiTimer0_1.Start();
                        main.uiTimer0_2.Start();
                        main.uiTimer0_3.Start();
                        main.uiTimer0_4.Start();

                        main.uiTimer1.Start();
                        main.uiTimer2.Start();
                        main.uiTimer3.Start();
                        main.uiTimer4.Start();
                        main.Cursor = System.Windows.Input.Cursors.None;

                    }

                    else if (main.type == 2)
                    {
                        main.Prepare_1.Visibility = System.Windows.Visibility.Visible;
                        /*
                        Random timer_Rnd = new Random();
                        int a1 = timer_Rnd.Next(100); int a2 = timer_Rnd.Next(100);
                        int b1 = timer_Rnd.Next(100); int b2 = timer_Rnd.Next(100);
                        int c1 = timer_Rnd.Next(100); int c2 = timer_Rnd.Next(100);
                        int d1 = timer_Rnd.Next(100); int d2 = timer_Rnd.Next(100);
                        int e1 = timer_Rnd.Next(100);

                        main.uiTimer0_1.Interval = 250 + 3000 * a1 / (a1 + b1 + c1 + d1 + e1); main.uiTimer0_1.Tick += main.hidePlus_1;
                        main.uiTimer0_2.Interval = main.uiTimer0_1.Interval + 250 + 3000 * b1 / (a1 + b1 + c1 + d1 + e1); main.uiTimer0_2.Tick += main.hidePlus_2;
                        main.uiTimer0_3.Interval = main.uiTimer0_2.Interval + 250 + 3000 * c1 / (a1 + b1 + c1 + d1 + e1); main.uiTimer0_3.Tick += main.hidePlus_3;
                        main.uiTimer0_4.Interval = main.uiTimer0_3.Interval + 250 + 3000 * d1 / (a1 + b1 + c1 + d1 + e1); main.uiTimer0_4.Tick += main.hidePlus_4;
                        write_rhythm(main.taskType[main.type], main.countTask, "PreAperiodicIntervals", main.uiTimer0_1.Interval,
                           main.uiTimer0_2.Interval - main.uiTimer0_1.Interval, main.uiTimer0_3.Interval - main.uiTimer0_2.Interval, main.uiTimer0_4.Interval - main.uiTimer0_3.Interval, System.DateTime.Now);


                        main.uiTimer1.Interval = 4000 + 250 + 3250 * a2 / (a2 + b2 + c2 + d2); main.uiTimer1.Tick += main.hideUpLeft;
                        main.uiTimer2.Interval = main.uiTimer1.Interval + 250 + 3250 * b2 / (a2 + b2 + c2 + d2); main.uiTimer2.Tick += main.hideUpRight;
                        main.uiTimer3.Interval = main.uiTimer2.Interval + 250 + 3250 * c2 / (a2 + b2 + c2 + d2); main.uiTimer3.Tick += main.hideDownRight;
                        main.uiTimer4.Interval = 8000; main.uiTimer4.Tick += main.hideDownLeft;*/


                        main.uiTimer0_1.Interval = main.aperiodic_interval[main.subTask - 1, 0]; main.uiTimer0_1.Tick += main.hidePlus_1;
                        main.uiTimer0_2.Interval = main.uiTimer0_1.Interval + main.aperiodic_interval[main.subTask - 1, 1]; main.uiTimer0_2.Tick += main.hidePlus_2;
                        main.uiTimer0_3.Interval = main.uiTimer0_2.Interval + main.aperiodic_interval[main.subTask - 1, 2]; main.uiTimer0_3.Tick += main.hidePlus_3;
                        main.uiTimer0_4.Interval = main.uiTimer0_3.Interval + main.aperiodic_interval[main.subTask - 1, 3]; main.uiTimer0_4.Tick += main.hidePlus_4;

                        main.uiTimer1.Interval = main.uiTimer0_4.Interval + main.aperiodic_interval[main.subTask - 1, 4]; main.uiTimer1.Tick += main.hideUpLeft;
                        main.uiTimer2.Interval = main.uiTimer1.Interval + main.aperiodic_interval[main.subTask - 1, 5]; main.uiTimer2.Tick += main.hideUpRight;
                        main.uiTimer3.Interval = main.uiTimer2.Interval + main.aperiodic_interval[main.subTask - 1, 6]; main.uiTimer3.Tick += main.hideDownRight;
                        main.uiTimer4.Interval = main.uiTimer3.Interval + main.aperiodic_interval[main.subTask - 1, 7];  main.uiTimer4.Tick += main.hideDownLeft;
                        write_rhythm(main.taskType[main.type], main.countTask, "Computer_pre_Aperiodic", main.aperiodic_interval[main.subTask - 1, 0], main.aperiodic_interval[main.subTask - 1, 1], 
                            main.aperiodic_interval[main.subTask - 1, 2], main.aperiodic_interval[main.subTask - 1, 3], System.DateTime.Now);
                        write_rhythm(main.taskType[main.type], main.countTask, "Computer_Aperiodic", main.aperiodic_interval[main.subTask - 1, 4], main.aperiodic_interval[main.subTask - 1, 5], 
                            main.aperiodic_interval[main.subTask - 1, 6], main.aperiodic_interval[main.subTask - 1, 7], System.DateTime.Now);




                        main.uiTimer0_1.Start();
                        main.uiTimer0_2.Start();
                        main.uiTimer0_3.Start();
                        main.uiTimer0_4.Start();

                        main.uiTimer1.Start();
                        main.uiTimer2.Start();
                        main.uiTimer3.Start();
                        main.uiTimer4.Start();
                        main.Cursor = System.Windows.Input.Cursors.None;

                    }
                    else if (main.type == 3)
                    {
                        //main.Prepare.Visibility =
                        //main.Task3Switch.Visibility = 
                        main.Task34_prepare_1.Visibility = System.Windows.Visibility.Visible;
                        main.pre_cue_click[main.countTask, 0] = System.DateTime.Now;
                        main.Cursor = System.Windows.Input.Cursors.Arrow;

                        //main.uiTimer0.Interval = 2000; main.uiTimer0.Tick += main.hidePlus;
                        //main.uiTimer0.Start();
                        //main.Task3Switch.Content = "+";

                    }
                    else if (main.type == 4)
                    {
                        main.Task34_prepare_1.Visibility = System.Windows.Visibility.Visible;
                        main.pre_cue_click[main.countTask, 0] = System.DateTime.Now;
                        main.Cursor = System.Windows.Input.Cursors.Arrow;

                        /*
                        main.Prepare.Visibility = System.Windows.Visibility.Visible;
                        main.uiTimer0.Interval = 1000; main.uiTimer0.Tick += main.hidePlus;
                        main.uiTimer1.Interval = 1000 + main.click_interval_ms[main.countTask - 1, 1]; main.uiTimer1.Tick += main.hideUpLeft;
                        main.uiTimer2.Interval = 1000 + main.click_interval_ms[main.countTask - 1, 1] + main.click_interval_ms[main.countTask - 1, 2]; main.uiTimer2.Tick += main.hideUpRight;
                        main.uiTimer3.Interval = 1000 + main.click_interval_ms[main.countTask - 1, 1] + main.click_interval_ms[main.countTask - 1, 2] + main.click_interval_ms[main.countTask - 1, 3]; main.uiTimer3.Tick += main.hideDownRight;
                        main.uiTimer4.Interval = 1000 + main.click_interval_ms[main.countTask - 1, 1] + main.click_interval_ms[main.countTask - 1, 2] + main.click_interval_ms[main.countTask - 1, 3] + main.click_interval_ms[main.countTask - 1, 4]; main.uiTimer4.Tick += main.hideDownLeft;
                        write_rhythm(main.taskType[main.type], main.countTask, "AlignedIntervals", main.click_interval_ms[main.countTask - 1, 1], main.click_interval_ms[main.countTask - 1, 2],
                        main.click_interval_ms[main.countTask - 1, 3], main.click_interval_ms[main.countTask - 1, 4], System.DateTime.Now);
                        main.uiTimer0.Start();
                        main.uiTimer1.Start();
                        main.uiTimer2.Start();
                        main.uiTimer3.Start();
                        main.uiTimer4.Start();
                        */
                    }
                }
            
            else
            {
                    main.Task_Rating.Visibility = System.Windows.Visibility.Visible;
                    main.subTask = 0;
            }

            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            var main = App.Current.MainWindow as MainWindow;

            if (main.CB_UL.Visibility == System.Windows.Visibility.Visible)
            {
                main.quiz_click[main.countTask, 1] = System.DateTime.Now;
                main.answers[main.countTask, 0] = "Cue2";
                if (main.randomisedCues[main.countTask, 0] == "Cue2")
                { main.TorF[main.countTask, 0] = "True"; main.performance[main.type, 1]++;
                    write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 0] + "-" + main.answers[main.countTask, 0], "True", System.DateTime.Now); }
                else
                { main.TorF[main.countTask, 0] = "False"; write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 0] + "-" + main.answers[main.countTask, 0], "False", System.DateTime.Now); }
                main.CB_UL.Visibility = System.Windows.Visibility.Hidden;
                main.CB_UR.Visibility = System.Windows.Visibility.Visible;
            }
            else if (main.CB_UR.Visibility == System.Windows.Visibility.Visible)
            {
                main.quiz_click[main.countTask, 2] = System.DateTime.Now;
                main.answers[main.countTask, 1] = "Cue2";
                if (main.randomisedCues[main.countTask, 1] == "Cue2")
                { main.TorF[main.countTask, 1] = "True"; main.performance[main.type, 1]++;
                    write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 1] + "-" + main.answers[main.countTask, 1], "True", System.DateTime.Now); }
                else
                { main.TorF[main.countTask, 1] = "False"; write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 1] + "-" + main.answers[main.countTask, 1], "False", System.DateTime.Now); }
                main.CB_UR.Visibility = System.Windows.Visibility.Hidden;
                main.CB_DR.Visibility = System.Windows.Visibility.Visible;
            }
            else if (main.CB_DR.Visibility == System.Windows.Visibility.Visible)
            {
                main.quiz_click[main.countTask, 3] = System.DateTime.Now;
                main.answers[main.countTask, 2] = "Cue2";
                if (main.randomisedCues[main.countTask, 2] == "Cue2")
                { main.TorF[main.countTask, 2] = "True"; main.performance[main.type, 1]++;
                    write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 2] + "-" + main.answers[main.countTask, 2], "True", System.DateTime.Now); }
                else
                { main.TorF[main.countTask, 2] = "False"; write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 2] + "-" + main.answers[main.countTask, 2], "False", System.DateTime.Now); }
                main.CB_DR.Visibility = System.Windows.Visibility.Hidden;
                main.CB_DL.Visibility = System.Windows.Visibility.Visible;
            }
            else if (main.CB_DL.Visibility == System.Windows.Visibility.Visible)
            {
                main.quiz_click[main.countTask, 4] = System.DateTime.Now;
                main.answers[main.countTask, 3] = "Cue2";
                if (main.randomisedCues[main.countTask, 3] == "Cue2")
                { main.TorF[main.countTask, 3] = "True"; main.performance[main.type, 1]++;
                    write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 3] + "-" + main.answers[main.countTask, 3], "True", System.DateTime.Now); }
                else
                { main.TorF[main.countTask, 3] = "False"; write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 3] + "-" + main.answers[main.countTask, 3], "False", System.DateTime.Now); }
                main.CB_DL.Visibility = System.Windows.Visibility.Hidden;

                main.click_interval[main.countTask, 1] = main.quiz_click[main.countTask, 1] - main.quiz_click[main.countTask, 0];
                main.click_interval_ms[main.countTask, 1] = Convert.ToInt32(main.click_interval[main.countTask, 1].TotalMilliseconds);
                main.click_interval[main.countTask, 2] = main.quiz_click[main.countTask, 2] - main.quiz_click[main.countTask, 1];
                main.click_interval_ms[main.countTask, 2] = Convert.ToInt32(main.click_interval[main.countTask, 2].TotalMilliseconds);
                main.click_interval[main.countTask, 3] = main.quiz_click[main.countTask, 3] - main.quiz_click[main.countTask, 2];
                main.click_interval_ms[main.countTask, 3] = Convert.ToInt32(main.click_interval[main.countTask, 3].TotalMilliseconds);
                main.click_interval[main.countTask, 4] = main.quiz_click[main.countTask, 4] - main.quiz_click[main.countTask, 3];
                main.click_interval_ms[main.countTask, 4] = Convert.ToInt32(main.click_interval[main.countTask, 4].TotalMilliseconds);
                write_rhythm(main.taskType[main.type], main.countTask, "UserClicks", main.click_interval_ms[main.countTask, 1], main.click_interval_ms[main.countTask, 2],
                    main.click_interval_ms[main.countTask, 3], main.click_interval_ms[main.countTask, 4], System.DateTime.Now);



                main.next_cue = 1;
                
                if (main.subTask <= 29)
                {
                    main.countTask++;
                    main.subTask++;
                    main.randomiseCues(main.countTask);
                    if (main.type == 1)
                    {
                        main.Prepare_1.Visibility = System.Windows.Visibility.Visible;

                        if (main.avg_self_paced_interval >= 300)
                        {
                            main.uiTimer0_1.Interval = (int)(1 * (double)main.avg_self_paced_interval); main.uiTimer0_1.Tick += main.hidePlus_1;
                            main.uiTimer0_2.Interval = (int)(2 * (double)main.avg_self_paced_interval); main.uiTimer0_2.Tick += main.hidePlus_2;
                            main.uiTimer0_3.Interval = (int)(3 * (double)main.avg_self_paced_interval); main.uiTimer0_3.Tick += main.hidePlus_3;
                            main.uiTimer0_4.Interval = (int)(4 * (double)main.avg_self_paced_interval); main.uiTimer0_4.Tick += main.hidePlus_4;
                            main.uiTimer1.Interval = (int)(5 * (double)main.avg_self_paced_interval); main.uiTimer1.Tick += main.hideUpLeft;
                            main.uiTimer2.Interval = (int)(6 * (double)main.avg_self_paced_interval); main.uiTimer2.Tick += main.hideUpRight;
                            main.uiTimer3.Interval = (int)(7 * (double)main.avg_self_paced_interval); main.uiTimer3.Tick += main.hideDownRight;
                            main.uiTimer4.Interval = (int)(8 * (double)main.avg_self_paced_interval); main.uiTimer4.Tick += main.hideDownLeft;

                        }
                        else
                        {

                            main.uiTimer0_1.Interval = 660; main.uiTimer0_1.Tick += main.hidePlus_1;
                            main.uiTimer0_2.Interval = 2 * 660; main.uiTimer0_2.Tick += main.hidePlus_2;
                            main.uiTimer0_3.Interval = 3 * 660; main.uiTimer0_3.Tick += main.hidePlus_3;
                            main.uiTimer0_4.Interval = 4 * 660; main.uiTimer0_4.Tick += main.hidePlus_4;

                            main.uiTimer1.Interval = 5 * 660; main.uiTimer1.Tick += main.hideUpLeft;
                            main.uiTimer2.Interval = 6 * 660; main.uiTimer2.Tick += main.hideUpRight;
                            main.uiTimer3.Interval = 7 * 660; main.uiTimer3.Tick += main.hideDownRight;
                            main.uiTimer4.Interval = 8 * 660; main.uiTimer4.Tick += main.hideDownLeft;
                        }

                        write_rhythm(main.taskType[main.type], main.countTask, "Computer_pre_Rhythmic", main.uiTimer0_1.Interval,
main.uiTimer0_2.Interval - main.uiTimer0_1.Interval, main.uiTimer0_3.Interval - main.uiTimer0_2.Interval, main.uiTimer0_4.Interval - main.uiTimer0_3.Interval, System.DateTime.Now);
                        write_rhythm(main.taskType[main.type], main.countTask, "ComputerRhythmic", main.uiTimer1.Interval - main.uiTimer0_4.Interval,
    main.uiTimer2.Interval - main.uiTimer1.Interval, main.uiTimer3.Interval - main.uiTimer2.Interval, main.uiTimer4.Interval - main.uiTimer3.Interval, System.DateTime.Now);

                        main.uiTimer0_1.Start();
                        main.uiTimer0_2.Start();
                        main.uiTimer0_3.Start();
                        main.uiTimer0_4.Start();

                        main.uiTimer1.Start();
                        main.uiTimer2.Start();
                        main.uiTimer3.Start();
                        main.uiTimer4.Start();
                        main.Cursor = System.Windows.Input.Cursors.None;

                    }
                    else if (main.type == 2)
                    {
                        main.Prepare_1.Visibility = System.Windows.Visibility.Visible;
                        /*
                        Random timer_Rnd = new Random();
                        int a1 = timer_Rnd.Next(100); int a2 = timer_Rnd.Next(100);
                        int b1 = timer_Rnd.Next(100); int b2 = timer_Rnd.Next(100);
                        int c1 = timer_Rnd.Next(100); int c2 = timer_Rnd.Next(100);
                        int d1 = timer_Rnd.Next(100); int d2 = timer_Rnd.Next(100);
                        int e1 = timer_Rnd.Next(100);

                        main.uiTimer0_1.Interval = 250 + 3000 * a1 / (a1 + b1 + c1 + d1 + e1); main.uiTimer0_1.Tick += main.hidePlus_1;
                        main.uiTimer0_2.Interval = main.uiTimer0_1.Interval + 250 + 3000 * b1 / (a1 + b1 + c1 + d1 + e1); main.uiTimer0_2.Tick += main.hidePlus_2;
                        main.uiTimer0_3.Interval = main.uiTimer0_2.Interval + 250 + 3000 * c1 / (a1 + b1 + c1 + d1 + e1); main.uiTimer0_3.Tick += main.hidePlus_3;
                        main.uiTimer0_4.Interval = main.uiTimer0_3.Interval + 250 + 3000 * d1 / (a1 + b1 + c1 + d1 + e1); main.uiTimer0_4.Tick += main.hidePlus_4;
                        write_rhythm(main.taskType[main.type], main.countTask, "PreAperiodicIntervals", main.uiTimer0_1.Interval,
                           main.uiTimer0_2.Interval - main.uiTimer0_1.Interval, main.uiTimer0_3.Interval - main.uiTimer0_2.Interval, main.uiTimer0_4.Interval - main.uiTimer0_3.Interval, System.DateTime.Now);


                        main.uiTimer1.Interval = 4000 + 250 + 3250 * a2 / (a2 + b2 + c2 + d2); main.uiTimer1.Tick += main.hideUpLeft;
                        main.uiTimer2.Interval = main.uiTimer1.Interval + 250 + 3250 * b2 / (a2 + b2 + c2 + d2); main.uiTimer2.Tick += main.hideUpRight;
                        main.uiTimer3.Interval = main.uiTimer2.Interval + 250 + 3250 * c2 / (a2 + b2 + c2 + d2); main.uiTimer3.Tick += main.hideDownRight;
                        main.uiTimer4.Interval = 8000; main.uiTimer4.Tick += main.hideDownLeft;

                        write_rhythm(main.taskType[main.type], main.countTask, "AperiodicIntervals", main.uiTimer1.Interval - 4000, main.uiTimer2.Interval - main.uiTimer1.Interval,
                            main.uiTimer3.Interval - main.uiTimer2.Interval, main.uiTimer4.Interval - main.uiTimer3.Interval, System.DateTime.Now);
                        
                    */
                        main.uiTimer0_1.Interval = main.aperiodic_interval[main.subTask - 1, 0]; main.uiTimer0_1.Tick += main.hidePlus_1;
                        main.uiTimer0_2.Interval = main.uiTimer0_1.Interval + main.aperiodic_interval[main.subTask - 1, 1]; main.uiTimer0_2.Tick += main.hidePlus_2;
                        main.uiTimer0_3.Interval = main.uiTimer0_2.Interval + main.aperiodic_interval[main.subTask - 1, 2]; main.uiTimer0_3.Tick += main.hidePlus_3;
                        main.uiTimer0_4.Interval = main.uiTimer0_3.Interval + main.aperiodic_interval[main.subTask - 1, 3]; main.uiTimer0_4.Tick += main.hidePlus_4;

                        main.uiTimer1.Interval = main.uiTimer0_4.Interval + main.aperiodic_interval[main.subTask - 1, 4]; main.uiTimer1.Tick += main.hideUpLeft;
                        main.uiTimer2.Interval = main.uiTimer1.Interval + main.aperiodic_interval[main.subTask - 1, 5]; main.uiTimer2.Tick += main.hideUpRight;
                        main.uiTimer3.Interval = main.uiTimer2.Interval + main.aperiodic_interval[main.subTask - 1, 6]; main.uiTimer3.Tick += main.hideDownRight;
                        main.uiTimer4.Interval = main.uiTimer3.Interval + main.aperiodic_interval[main.subTask - 1, 7]; main.uiTimer4.Tick += main.hideDownLeft;
                        write_rhythm(main.taskType[main.type], main.countTask, "Computer_pre_Aperiodic", main.aperiodic_interval[main.subTask - 1, 0], main.aperiodic_interval[main.subTask - 1, 1],
                            main.aperiodic_interval[main.subTask - 1, 2], main.aperiodic_interval[main.subTask - 1, 3], System.DateTime.Now);
                        write_rhythm(main.taskType[main.type], main.countTask, "Computer_Aperiodic", main.aperiodic_interval[main.subTask - 1, 4], main.aperiodic_interval[main.subTask - 1, 5],
                            main.aperiodic_interval[main.subTask - 1, 6], main.aperiodic_interval[main.subTask - 1, 7], System.DateTime.Now);



                        main.uiTimer0_1.Start();
                        main.uiTimer0_2.Start();
                        main.uiTimer0_3.Start();
                        main.uiTimer0_4.Start();

                        main.uiTimer1.Start();
                        main.uiTimer2.Start();
                        main.uiTimer3.Start();
                        main.uiTimer4.Start();
                        main.Cursor = System.Windows.Input.Cursors.None;

                    }
                    else if (main.type == 3)
                    {
                        //main.Prepare.Visibility = 
                        //main.Task3Switch.Visibility = System.Windows.Visibility.Visible;
                        main.Task34_prepare_1.Visibility = System.Windows.Visibility.Visible;
                        main.pre_cue_click[main.countTask, 0] = System.DateTime.Now;
                        main.Cursor = System.Windows.Input.Cursors.Arrow;

                        //main.uiTimer0.Interval = 2000; main.uiTimer0.Tick += main.hidePlus;
                        //main.uiTimer0.Start();
                        //main.Task3Switch.Content = "+";
                    }
                    else if (main.type == 4)
                    {
                        main.Task34_prepare_1.Visibility = System.Windows.Visibility.Visible;
                        main.pre_cue_click[main.countTask, 0] = System.DateTime.Now;
                        main.Cursor = System.Windows.Input.Cursors.Arrow;

                        /*
                        main.Prepare.Visibility = System.Windows.Visibility.Visible;
                        main.uiTimer0.Interval = 1000; main.uiTimer0.Tick += main.hidePlus;
                        main.uiTimer1.Interval = 1000 + main.click_interval_ms[main.countTask - 1, 1]; main.uiTimer1.Tick += main.hideUpLeft;
                        main.uiTimer2.Interval = 1000 + main.click_interval_ms[main.countTask - 1, 1] + main.click_interval_ms[main.countTask - 1, 2]; main.uiTimer2.Tick += main.hideUpRight;
                        main.uiTimer3.Interval = 1000 + main.click_interval_ms[main.countTask - 1, 1] + main.click_interval_ms[main.countTask - 1, 2] + main.click_interval_ms[main.countTask - 1, 3]; main.uiTimer3.Tick += main.hideDownRight;
                        main.uiTimer4.Interval = 1000 + main.click_interval_ms[main.countTask - 1, 1] + main.click_interval_ms[main.countTask - 1, 2] + main.click_interval_ms[main.countTask - 1, 3] + main.click_interval_ms[main.countTask - 1, 4]; main.uiTimer4.Tick += main.hideDownLeft;
                        write_rhythm(main.taskType[main.type], main.countTask, "AlignedIntervals", main.click_interval_ms[main.countTask - 1, 1], main.click_interval_ms[main.countTask - 1, 2],
                        main.click_interval_ms[main.countTask - 1, 3], main.click_interval_ms[main.countTask - 1, 4], System.DateTime.Now);
                        main.uiTimer0.Start();
                        main.uiTimer1.Start();
                        main.uiTimer2.Start();
                        main.uiTimer3.Start();
                        main.uiTimer4.Start();
                        */
                    }

                }
            else
            {
                    main.Task_Rating.Visibility = System.Windows.Visibility.Visible;
                    main.subTask = 0;

                }
            }
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            var main = App.Current.MainWindow as MainWindow;

            if (main.CB_UL.Visibility == System.Windows.Visibility.Visible)
            {
                main.quiz_click[main.countTask, 1] = System.DateTime.Now;
                main.answers[main.countTask, 0] = "Cue3";
                if (main.randomisedCues[main.countTask, 0] == "Cue3")
                { main.TorF[main.countTask, 0] = "True"; main.performance[main.type, 1]++;
                    write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 0] + "-" + main.answers[main.countTask, 0], "True", System.DateTime.Now); }
                else
                { main.TorF[main.countTask, 0] = "False"; write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 0] + "-" + main.answers[main.countTask, 0], "False", System.DateTime.Now); }
                main.CB_UL.Visibility = System.Windows.Visibility.Hidden;
                main.CB_UR.Visibility = System.Windows.Visibility.Visible;
            }
            else if (main.CB_UR.Visibility == System.Windows.Visibility.Visible)
            {
                main.quiz_click[main.countTask, 2] = System.DateTime.Now;
                main.answers[main.countTask, 1] = "Cue3";
                if (main.randomisedCues[main.countTask, 1] == "Cue3")
                { main.TorF[main.countTask, 1] = "True"; main.performance[main.type, 1]++;
                    write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 1] + "-" + main.answers[main.countTask, 1], "True", System.DateTime.Now); }
                else
                { main.TorF[main.countTask, 1] = "False"; write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 1] + "-" + main.answers[main.countTask, 1], "False", System.DateTime.Now); }
                main.CB_UR.Visibility = System.Windows.Visibility.Hidden;
                main.CB_DR.Visibility = System.Windows.Visibility.Visible;
            }
            else if (main.CB_DR.Visibility == System.Windows.Visibility.Visible)
            {
                main.quiz_click[main.countTask, 3] = System.DateTime.Now;
                main.answers[main.countTask, 2] = "Cue3";
                if (main.randomisedCues[main.countTask, 2] == "Cue3")
                { main.TorF[main.countTask, 2] = "True"; main.performance[main.type, 1]++;
                    write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 2] + "-" + main.answers[main.countTask, 2], "True", System.DateTime.Now); }
                else
                { main.TorF[main.countTask, 2] = "False"; write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 2] + "-" + main.answers[main.countTask, 2], "False", System.DateTime.Now); }
                main.CB_DR.Visibility = System.Windows.Visibility.Hidden;
                main.CB_DL.Visibility = System.Windows.Visibility.Visible;
            }
            else if (main.CB_DL.Visibility == System.Windows.Visibility.Visible)
            {
                main.quiz_click[main.countTask, 4] = System.DateTime.Now;
                main.answers[main.countTask, 3] = "Cue3";
                if (main.randomisedCues[main.countTask, 3] == "Cue3")
                { main.TorF[main.countTask, 3] = "True"; main.performance[main.type, 1]++;
                    write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 3] + "-" + main.answers[main.countTask, 3], "True", System.DateTime.Now); }
                else
                { main.TorF[main.countTask, 3] = "False"; write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 3] + "-" + main.answers[main.countTask, 3], "False", System.DateTime.Now); }
                main.CB_DL.Visibility = System.Windows.Visibility.Hidden;

                main.click_interval[main.countTask, 1] = main.quiz_click[main.countTask, 1] - main.quiz_click[main.countTask, 0];
                main.click_interval_ms[main.countTask, 1] = Convert.ToInt32(main.click_interval[main.countTask, 1].TotalMilliseconds);
                main.click_interval[main.countTask, 2] = main.quiz_click[main.countTask, 2] - main.quiz_click[main.countTask, 1];
                main.click_interval_ms[main.countTask, 2] = Convert.ToInt32(main.click_interval[main.countTask, 2].TotalMilliseconds);
                main.click_interval[main.countTask, 3] = main.quiz_click[main.countTask, 3] - main.quiz_click[main.countTask, 2];
                main.click_interval_ms[main.countTask, 3] = Convert.ToInt32(main.click_interval[main.countTask, 3].TotalMilliseconds);
                main.click_interval[main.countTask, 4] = main.quiz_click[main.countTask, 4] - main.quiz_click[main.countTask, 3];
                main.click_interval_ms[main.countTask, 4] = Convert.ToInt32(main.click_interval[main.countTask, 4].TotalMilliseconds);
                write_rhythm(main.taskType[main.type], main.countTask, "UserClicks", main.click_interval_ms[main.countTask, 1], main.click_interval_ms[main.countTask, 2],
                    main.click_interval_ms[main.countTask, 3], main.click_interval_ms[main.countTask, 4], System.DateTime.Now);


                main.next_cue = 1;
               
                if (main.subTask <= 29)
                {
                    main.countTask++;
                    main.subTask++;
                    main.randomiseCues(main.countTask);
                    if (main.type == 1)
                    {
                        main.Prepare_1.Visibility = System.Windows.Visibility.Visible;

                        if (main.avg_self_paced_interval >= 300)
                        {
                            main.uiTimer0_1.Interval = (int)(1 * (double)main.avg_self_paced_interval); main.uiTimer0_1.Tick += main.hidePlus_1;
                            main.uiTimer0_2.Interval = (int)(2 * (double)main.avg_self_paced_interval); main.uiTimer0_2.Tick += main.hidePlus_2;
                            main.uiTimer0_3.Interval = (int)(3 * (double)main.avg_self_paced_interval); main.uiTimer0_3.Tick += main.hidePlus_3;
                            main.uiTimer0_4.Interval = (int)(4 * (double)main.avg_self_paced_interval); main.uiTimer0_4.Tick += main.hidePlus_4;
                            main.uiTimer1.Interval = (int)(5 * (double)main.avg_self_paced_interval); main.uiTimer1.Tick += main.hideUpLeft;
                            main.uiTimer2.Interval = (int)(6 * (double)main.avg_self_paced_interval); main.uiTimer2.Tick += main.hideUpRight;
                            main.uiTimer3.Interval = (int)(7 * (double)main.avg_self_paced_interval); main.uiTimer3.Tick += main.hideDownRight;
                            main.uiTimer4.Interval = (int)(8 * (double)main.avg_self_paced_interval); main.uiTimer4.Tick += main.hideDownLeft;

                        }
                        else
                        {

                            main.uiTimer0_1.Interval = 660; main.uiTimer0_1.Tick += main.hidePlus_1;
                            main.uiTimer0_2.Interval = 2 * 660; main.uiTimer0_2.Tick += main.hidePlus_2;
                            main.uiTimer0_3.Interval = 3 * 660; main.uiTimer0_3.Tick += main.hidePlus_3;
                            main.uiTimer0_4.Interval = 4 * 660; main.uiTimer0_4.Tick += main.hidePlus_4;

                            main.uiTimer1.Interval = 5 * 660; main.uiTimer1.Tick += main.hideUpLeft;
                            main.uiTimer2.Interval = 6 * 660; main.uiTimer2.Tick += main.hideUpRight;
                            main.uiTimer3.Interval = 7 * 660; main.uiTimer3.Tick += main.hideDownRight;
                            main.uiTimer4.Interval = 8 * 660; main.uiTimer4.Tick += main.hideDownLeft;
                        }

                        write_rhythm(main.taskType[main.type], main.countTask, "Computer_pre_Rhythmic", main.uiTimer0_1.Interval,
main.uiTimer0_2.Interval - main.uiTimer0_1.Interval, main.uiTimer0_3.Interval - main.uiTimer0_2.Interval, main.uiTimer0_4.Interval - main.uiTimer0_3.Interval, System.DateTime.Now);
                        write_rhythm(main.taskType[main.type], main.countTask, "ComputerRhythmic", main.uiTimer1.Interval - main.uiTimer0_4.Interval,
    main.uiTimer2.Interval - main.uiTimer1.Interval, main.uiTimer3.Interval - main.uiTimer2.Interval, main.uiTimer4.Interval - main.uiTimer3.Interval, System.DateTime.Now);

                        main.uiTimer0_1.Start();
                        main.uiTimer0_2.Start();
                        main.uiTimer0_3.Start();
                        main.uiTimer0_4.Start();

                        main.uiTimer1.Start();
                        main.uiTimer2.Start();
                        main.uiTimer3.Start();
                        main.uiTimer4.Start();
                        main.Cursor = System.Windows.Input.Cursors.None;

                    }
                    else if (main.type == 2)
                    {
                        main.Prepare_1.Visibility = System.Windows.Visibility.Visible;
                        /*
                        Random timer_Rnd = new Random();
                        int a1 = timer_Rnd.Next(100); int a2 = timer_Rnd.Next(100);
                        int b1 = timer_Rnd.Next(100); int b2 = timer_Rnd.Next(100);
                        int c1 = timer_Rnd.Next(100); int c2 = timer_Rnd.Next(100);
                        int d1 = timer_Rnd.Next(100); int d2 = timer_Rnd.Next(100);
                        int e1 = timer_Rnd.Next(100);

                        main.uiTimer0_1.Interval = 250 + 3000 * a1 / (a1 + b1 + c1 + d1 + e1); main.uiTimer0_1.Tick += main.hidePlus_1;
                        main.uiTimer0_2.Interval = main.uiTimer0_1.Interval + 250 + 3000 * b1 / (a1 + b1 + c1 + d1 + e1); main.uiTimer0_2.Tick += main.hidePlus_2;
                        main.uiTimer0_3.Interval = main.uiTimer0_2.Interval + 250 + 3000 * c1 / (a1 + b1 + c1 + d1 + e1); main.uiTimer0_3.Tick += main.hidePlus_3;
                        main.uiTimer0_4.Interval = main.uiTimer0_3.Interval + 250 + 3000 * d1 / (a1 + b1 + c1 + d1 + e1); main.uiTimer0_4.Tick += main.hidePlus_4;
                        write_rhythm(main.taskType[main.type], main.countTask, "PreAperiodicIntervals", main.uiTimer0_1.Interval,
                           main.uiTimer0_2.Interval - main.uiTimer0_1.Interval, main.uiTimer0_3.Interval - main.uiTimer0_2.Interval, main.uiTimer0_4.Interval - main.uiTimer0_3.Interval, System.DateTime.Now);


                        main.uiTimer1.Interval = 4000 + 250 + 3250 * a2 / (a2 + b2 + c2 + d2); main.uiTimer1.Tick += main.hideUpLeft;
                        main.uiTimer2.Interval = main.uiTimer1.Interval + 250 + 3250 * b2 / (a2 + b2 + c2 + d2); main.uiTimer2.Tick += main.hideUpRight;
                        main.uiTimer3.Interval = main.uiTimer2.Interval + 250 + 3250 * c2 / (a2 + b2 + c2 + d2); main.uiTimer3.Tick += main.hideDownRight;
                        main.uiTimer4.Interval = 8000; main.uiTimer4.Tick += main.hideDownLeft;

                        write_rhythm(main.taskType[main.type], main.countTask, "AperiodicIntervals", main.uiTimer1.Interval - 4000, main.uiTimer2.Interval - main.uiTimer1.Interval,
                            main.uiTimer3.Interval - main.uiTimer2.Interval, main.uiTimer4.Interval - main.uiTimer3.Interval, System.DateTime.Now);
                        */

                        main.uiTimer0_1.Interval = main.aperiodic_interval[main.subTask - 1, 0]; main.uiTimer0_1.Tick += main.hidePlus_1;
                        main.uiTimer0_2.Interval = main.uiTimer0_1.Interval + main.aperiodic_interval[main.subTask - 1, 1]; main.uiTimer0_2.Tick += main.hidePlus_2;
                        main.uiTimer0_3.Interval = main.uiTimer0_2.Interval + main.aperiodic_interval[main.subTask - 1, 2]; main.uiTimer0_3.Tick += main.hidePlus_3;
                        main.uiTimer0_4.Interval = main.uiTimer0_3.Interval + main.aperiodic_interval[main.subTask - 1, 3]; main.uiTimer0_4.Tick += main.hidePlus_4;

                        main.uiTimer1.Interval = main.uiTimer0_4.Interval + main.aperiodic_interval[main.subTask - 1, 4]; main.uiTimer1.Tick += main.hideUpLeft;
                        main.uiTimer2.Interval = main.uiTimer1.Interval + main.aperiodic_interval[main.subTask - 1, 5]; main.uiTimer2.Tick += main.hideUpRight;
                        main.uiTimer3.Interval = main.uiTimer2.Interval + main.aperiodic_interval[main.subTask - 1, 6]; main.uiTimer3.Tick += main.hideDownRight;
                        main.uiTimer4.Interval = main.uiTimer3.Interval + main.aperiodic_interval[main.subTask - 1, 7]; main.uiTimer4.Tick += main.hideDownLeft;
                        write_rhythm(main.taskType[main.type], main.countTask, "Computer_pre_Aperiodic", main.aperiodic_interval[main.subTask - 1, 0], main.aperiodic_interval[main.subTask - 1, 1],
                            main.aperiodic_interval[main.subTask - 1, 2], main.aperiodic_interval[main.subTask - 1, 3], System.DateTime.Now);
                        write_rhythm(main.taskType[main.type], main.countTask, "Computer_Aperiodic", main.aperiodic_interval[main.subTask - 1, 4], main.aperiodic_interval[main.subTask - 1, 5],
                            main.aperiodic_interval[main.subTask - 1, 6], main.aperiodic_interval[main.subTask - 1, 7], System.DateTime.Now);



                        main.uiTimer0_1.Start();
                        main.uiTimer0_2.Start();
                        main.uiTimer0_3.Start();
                        main.uiTimer0_4.Start();

                        main.uiTimer1.Start();
                        main.uiTimer2.Start();
                        main.uiTimer3.Start();
                        main.uiTimer4.Start();
                        main.Cursor = System.Windows.Input.Cursors.None;

                    }
                    else if (main.type == 3)
                    {
                        // main.Prepare.Visibility = 
                        //main.Task3Switch.Visibility = System.Windows.Visibility.Visible;
                        main.Task34_prepare_1.Visibility = System.Windows.Visibility.Visible;
                        main.pre_cue_click[main.countTask, 0] = System.DateTime.Now;
                        main.Cursor = System.Windows.Input.Cursors.Arrow;

                        //main.uiTimer0.Interval = 2000; main.uiTimer0.Tick += main.hidePlus;
                        //main.uiTimer0.Start();
                        //main.Task3Switch.Content = "+";
                    }
                    else if (main.type == 4)
                    {
                        main.Task34_prepare_1.Visibility = System.Windows.Visibility.Visible;
                        main.pre_cue_click[main.countTask, 0] = System.DateTime.Now;
                        main.Cursor = System.Windows.Input.Cursors.Arrow;

                        /*
                        main.Prepare.Visibility = System.Windows.Visibility.Visible;
                        main.uiTimer0.Interval = 1000; main.uiTimer0.Tick += main.hidePlus;
                        main.uiTimer1.Interval = 1000 + main.click_interval_ms[main.countTask - 1, 1]; main.uiTimer1.Tick += main.hideUpLeft;
                        main.uiTimer2.Interval = 1000 + main.click_interval_ms[main.countTask - 1, 1] + main.click_interval_ms[main.countTask - 1, 2]; main.uiTimer2.Tick += main.hideUpRight;
                        main.uiTimer3.Interval = 1000 + main.click_interval_ms[main.countTask - 1, 1] + main.click_interval_ms[main.countTask - 1, 2] + main.click_interval_ms[main.countTask - 1, 3]; main.uiTimer3.Tick += main.hideDownRight;
                        main.uiTimer4.Interval = 1000 + main.click_interval_ms[main.countTask - 1, 1] + main.click_interval_ms[main.countTask - 1, 2] + main.click_interval_ms[main.countTask - 1, 3] + main.click_interval_ms[main.countTask - 1, 4]; main.uiTimer4.Tick += main.hideDownLeft;
                        write_rhythm(main.taskType[main.type], main.countTask, "AlignedIntervals", main.click_interval_ms[main.countTask - 1, 1], main.click_interval_ms[main.countTask - 1, 2],
                        main.click_interval_ms[main.countTask - 1, 3], main.click_interval_ms[main.countTask - 1, 4], System.DateTime.Now);
                        main.uiTimer0.Start();
                        main.uiTimer1.Start();
                        main.uiTimer2.Start();
                        main.uiTimer3.Start();
                        main.uiTimer4.Start();
                        */

                    }
                }
            else
            {
                    main.Task_Rating.Visibility = System.Windows.Visibility.Visible;
                    main.subTask = 0;

                }
            }
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            var main = App.Current.MainWindow as MainWindow;

            if (main.CB_UL.Visibility == System.Windows.Visibility.Visible)
            {
                main.quiz_click[main.countTask, 1] = System.DateTime.Now;
                main.answers[main.countTask, 0] = "Cue4";
                if (main.randomisedCues[main.countTask, 0] == "Cue4")
                { main.TorF[main.countTask, 0] = "True"; main.performance[main.type, 1]++;
                    write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 0] + "-" + main.answers[main.countTask, 0], "True", System.DateTime.Now); }
                else
                { main.TorF[main.countTask, 0] = "False"; write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 0] + "-" + main.answers[main.countTask, 0], "False", System.DateTime.Now); }
                main.CB_UL.Visibility = System.Windows.Visibility.Hidden;
                main.CB_UR.Visibility = System.Windows.Visibility.Visible;
            }
            else if (main.CB_UR.Visibility == System.Windows.Visibility.Visible)
            {
                main.quiz_click[main.countTask, 2] = System.DateTime.Now;
                main.answers[main.countTask, 1] = "Cue4";
                if (main.randomisedCues[main.countTask, 1] == "Cue4")
                { main.TorF[main.countTask, 1] = "True"; main.performance[main.type, 1]++;
                    write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 1] + "-" + main.answers[main.countTask, 1], "True", System.DateTime.Now); }
                else
                { main.TorF[main.countTask, 1] = "False"; write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 1] + "-" + main.answers[main.countTask, 1], "False", System.DateTime.Now); }
                main.CB_UR.Visibility = System.Windows.Visibility.Hidden;
                main.CB_DR.Visibility = System.Windows.Visibility.Visible;
            }
            else if (main.CB_DR.Visibility == System.Windows.Visibility.Visible)
            {
                main.quiz_click[main.countTask, 3] = System.DateTime.Now;
                main.answers[main.countTask, 2] = "Cue4";
                if (main.randomisedCues[main.countTask, 2] == "Cue4")
                { main.TorF[main.countTask, 2] = "True"; main.performance[main.type, 1]++;
                    write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 2] + "-" + main.answers[main.countTask, 2], "True", System.DateTime.Now); }
                else
                { main.TorF[main.countTask, 2] = "False"; write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 2] + "-" + main.answers[main.countTask, 2], "False", System.DateTime.Now); }
                main.CB_DR.Visibility = System.Windows.Visibility.Hidden;
                main.CB_DL.Visibility = System.Windows.Visibility.Visible;
            }
            else if (main.CB_DL.Visibility == System.Windows.Visibility.Visible)
            {
                main.quiz_click[main.countTask, 4] = System.DateTime.Now;
                main.answers[main.countTask, 3] = "Cue4";
                if (main.randomisedCues[main.countTask, 3] == "Cue4")
                { main.TorF[main.countTask, 3] = "True"; main.performance[main.type, 1]++;
                    write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 3] + "-" + main.answers[main.countTask, 3], "True", System.DateTime.Now); }
                else
                { main.TorF[main.countTask, 3] = "False"; write_answer(main.taskType[main.type], main.countTask, main.randomisedCues[main.countTask, 3] + "-" + main.answers[main.countTask, 3], "False", System.DateTime.Now); }
                main.CB_DL.Visibility = System.Windows.Visibility.Hidden;

                main.click_interval[main.countTask, 1] = main.quiz_click[main.countTask, 1] - main.quiz_click[main.countTask, 0];
                main.click_interval_ms[main.countTask, 1] = Convert.ToInt32(main.click_interval[main.countTask, 1].TotalMilliseconds);
                main.click_interval[main.countTask, 2] = main.quiz_click[main.countTask, 2] - main.quiz_click[main.countTask, 1];
                main.click_interval_ms[main.countTask, 2] = Convert.ToInt32(main.click_interval[main.countTask, 2].TotalMilliseconds);
                main.click_interval[main.countTask, 3] = main.quiz_click[main.countTask, 3] - main.quiz_click[main.countTask, 2];
                main.click_interval_ms[main.countTask, 3] = Convert.ToInt32(main.click_interval[main.countTask, 3].TotalMilliseconds);
                main.click_interval[main.countTask, 4] = main.quiz_click[main.countTask, 4] - main.quiz_click[main.countTask, 3];
                main.click_interval_ms[main.countTask, 4] = Convert.ToInt32(main.click_interval[main.countTask, 4].TotalMilliseconds);
                write_rhythm(main.taskType[main.type], main.countTask, "UserClicks", main.click_interval_ms[main.countTask, 1], main.click_interval_ms[main.countTask, 2],
                    main.click_interval_ms[main.countTask, 3], main.click_interval_ms[main.countTask, 4], System.DateTime.Now);


                main.next_cue = 1;
              

                if (main.subTask <= 29)
                {
                    main.countTask++;
                    main.subTask++;
                    main.randomiseCues(main.countTask);
                    if (main.type == 1)
                    {
                        main.Prepare_1.Visibility = System.Windows.Visibility.Visible;

                        if (main.avg_self_paced_interval >= 300)
                        {
                            main.uiTimer0_1.Interval = (int)(1 * (double)main.avg_self_paced_interval); main.uiTimer0_1.Tick += main.hidePlus_1;
                            main.uiTimer0_2.Interval = (int)(2 * (double)main.avg_self_paced_interval); main.uiTimer0_2.Tick += main.hidePlus_2;
                            main.uiTimer0_3.Interval = (int)(3 * (double)main.avg_self_paced_interval); main.uiTimer0_3.Tick += main.hidePlus_3;
                            main.uiTimer0_4.Interval = (int)(4 * (double)main.avg_self_paced_interval); main.uiTimer0_4.Tick += main.hidePlus_4;
                            main.uiTimer1.Interval = (int)(5 * (double)main.avg_self_paced_interval); main.uiTimer1.Tick += main.hideUpLeft;
                            main.uiTimer2.Interval = (int)(6 * (double)main.avg_self_paced_interval); main.uiTimer2.Tick += main.hideUpRight;
                            main.uiTimer3.Interval = (int)(7 * (double)main.avg_self_paced_interval); main.uiTimer3.Tick += main.hideDownRight;
                            main.uiTimer4.Interval = (int)(8 * (double)main.avg_self_paced_interval); main.uiTimer4.Tick += main.hideDownLeft;

                        }
                        else
                        {

                            main.uiTimer0_1.Interval = 660; main.uiTimer0_1.Tick += main.hidePlus_1;
                            main.uiTimer0_2.Interval = 2 * 660; main.uiTimer0_2.Tick += main.hidePlus_2;
                            main.uiTimer0_3.Interval = 3 * 660; main.uiTimer0_3.Tick += main.hidePlus_3;
                            main.uiTimer0_4.Interval = 4 * 660; main.uiTimer0_4.Tick += main.hidePlus_4;

                            main.uiTimer1.Interval = 5 * 660; main.uiTimer1.Tick += main.hideUpLeft;
                            main.uiTimer2.Interval = 6 * 660; main.uiTimer2.Tick += main.hideUpRight;
                            main.uiTimer3.Interval = 7 * 660; main.uiTimer3.Tick += main.hideDownRight;
                            main.uiTimer4.Interval = 8 * 660; main.uiTimer4.Tick += main.hideDownLeft;
                        }

                            write_rhythm(main.taskType[main.type], main.countTask, "Computer_pre_Rhythmic", main.uiTimer0_1.Interval,
    main.uiTimer0_2.Interval - main.uiTimer0_1.Interval, main.uiTimer0_3.Interval - main.uiTimer0_2.Interval, main.uiTimer0_4.Interval - main.uiTimer0_3.Interval, System.DateTime.Now);
                        write_rhythm(main.taskType[main.type], main.countTask, "ComputerRhythmic", main.uiTimer1.Interval - main.uiTimer0_4.Interval,
    main.uiTimer2.Interval - main.uiTimer1.Interval, main.uiTimer3.Interval - main.uiTimer2.Interval, main.uiTimer4.Interval - main.uiTimer3.Interval, System.DateTime.Now);

                        main.uiTimer0_1.Start();
                        main.uiTimer0_2.Start();
                        main.uiTimer0_3.Start();
                        main.uiTimer0_4.Start();

                        main.uiTimer1.Start();
                        main.uiTimer2.Start();
                        main.uiTimer3.Start();
                        main.uiTimer4.Start();
                        main.Cursor = System.Windows.Input.Cursors.None;

                    }
                    else if (main.type == 2)
                    {
                        main.Prepare_1.Visibility = System.Windows.Visibility.Visible;
                        /*
                        Random timer_Rnd = new Random();
                        int a1 = timer_Rnd.Next(100); int a2 = timer_Rnd.Next(100);
                        int b1 = timer_Rnd.Next(100); int b2 = timer_Rnd.Next(100);
                        int c1 = timer_Rnd.Next(100); int c2 = timer_Rnd.Next(100);
                        int d1 = timer_Rnd.Next(100); int d2 = timer_Rnd.Next(100);
                        int e1 = timer_Rnd.Next(100);

                        main.uiTimer0_1.Interval = 250 + 3000 * a1 / (a1 + b1 + c1 + d1 + e1); main.uiTimer0_1.Tick += main.hidePlus_1;
                        main.uiTimer0_2.Interval = main.uiTimer0_1.Interval + 250 + 3000 * b1 / (a1 + b1 + c1 + d1 + e1); main.uiTimer0_2.Tick += main.hidePlus_2;
                        main.uiTimer0_3.Interval = main.uiTimer0_2.Interval + 250 + 3000 * c1 / (a1 + b1 + c1 + d1 + e1); main.uiTimer0_3.Tick += main.hidePlus_3;
                        main.uiTimer0_4.Interval = main.uiTimer0_3.Interval + 250 + 3000 * d1 / (a1 + b1 + c1 + d1 + e1); main.uiTimer0_4.Tick += main.hidePlus_4;
                        write_rhythm(main.taskType[main.type], main.countTask, "PreAperiodicIntervals", main.uiTimer0_1.Interval,
                           main.uiTimer0_2.Interval - main.uiTimer0_1.Interval, main.uiTimer0_3.Interval - main.uiTimer0_2.Interval, main.uiTimer0_4.Interval - main.uiTimer0_3.Interval, System.DateTime.Now);


                        main.uiTimer1.Interval = 4000 + 250 + 3250 * a2 / (a2 + b2 + c2 + d2); main.uiTimer1.Tick += main.hideUpLeft;
                        main.uiTimer2.Interval = main.uiTimer1.Interval + 250 + 3250 * b2 / (a2 + b2 + c2 + d2); main.uiTimer2.Tick += main.hideUpRight;
                        main.uiTimer3.Interval = main.uiTimer2.Interval + 250 + 3250 * c2 / (a2 + b2 + c2 + d2); main.uiTimer3.Tick += main.hideDownRight;
                        main.uiTimer4.Interval = 8000; main.uiTimer4.Tick += main.hideDownLeft;
                        write_rhythm(main.taskType[main.type], main.countTask, "AperiodicIntervals", main.uiTimer1.Interval - 4000, main.uiTimer2.Interval - main.uiTimer1.Interval,
                            main.uiTimer3.Interval - main.uiTimer2.Interval, main.uiTimer4.Interval - main.uiTimer3.Interval, System.DateTime.Now);
                            */
                        main.uiTimer0_1.Interval = main.aperiodic_interval[main.subTask - 1, 0]; main.uiTimer0_1.Tick += main.hidePlus_1;
                        main.uiTimer0_2.Interval = main.uiTimer0_1.Interval + main.aperiodic_interval[main.subTask - 1, 1]; main.uiTimer0_2.Tick += main.hidePlus_2;
                        main.uiTimer0_3.Interval = main.uiTimer0_2.Interval + main.aperiodic_interval[main.subTask - 1, 2]; main.uiTimer0_3.Tick += main.hidePlus_3;
                        main.uiTimer0_4.Interval = main.uiTimer0_3.Interval + main.aperiodic_interval[main.subTask - 1, 3]; main.uiTimer0_4.Tick += main.hidePlus_4;

                        main.uiTimer1.Interval = main.uiTimer0_4.Interval + main.aperiodic_interval[main.subTask - 1, 4]; main.uiTimer1.Tick += main.hideUpLeft;
                        main.uiTimer2.Interval = main.uiTimer1.Interval + main.aperiodic_interval[main.subTask - 1, 5]; main.uiTimer2.Tick += main.hideUpRight;
                        main.uiTimer3.Interval = main.uiTimer2.Interval + main.aperiodic_interval[main.subTask - 1, 6]; main.uiTimer3.Tick += main.hideDownRight;
                        main.uiTimer4.Interval = main.uiTimer3.Interval + main.aperiodic_interval[main.subTask - 1, 7]; main.uiTimer4.Tick += main.hideDownLeft;
                        write_rhythm(main.taskType[main.type], main.countTask, "Computer_pre_Aperiodic", main.aperiodic_interval[main.subTask - 1, 0], main.aperiodic_interval[main.subTask - 1, 1],
                            main.aperiodic_interval[main.subTask - 1, 2], main.aperiodic_interval[main.subTask - 1, 3], System.DateTime.Now);
                        write_rhythm(main.taskType[main.type], main.countTask, "Computer_Aperiodic", main.aperiodic_interval[main.subTask - 1, 4], main.aperiodic_interval[main.subTask - 1, 5],
                            main.aperiodic_interval[main.subTask - 1, 6], main.aperiodic_interval[main.subTask - 1, 7], System.DateTime.Now);



                        main.uiTimer0_1.Start();
                        main.uiTimer0_2.Start();
                        main.uiTimer0_3.Start();
                        main.uiTimer0_4.Start();

                        main.uiTimer1.Start();
                        main.uiTimer2.Start();
                        main.uiTimer3.Start();
                        main.uiTimer4.Start();
                        main.Cursor = System.Windows.Input.Cursors.None;

                    }
                    else if (main.type == 3)
                    {
                        //main.Prepare.Visibility = 
                        //main.Task3Switch.Visibility = System.Windows.Visibility.Visible;
                        main.Task34_prepare_1.Visibility = System.Windows.Visibility.Visible;
                        main.pre_cue_click[main.countTask, 0] = System.DateTime.Now;
                        main.Cursor = System.Windows.Input.Cursors.Arrow;

                        //main.uiTimer0.Interval = 2000; main.uiTimer0.Tick += main.hidePlus;
                        //main.uiTimer0.Start();
                        //main.Task3Switch.Content = "+";
                    }
                    else if (main.type == 4)
                    {
                        main.Task34_prepare_1.Visibility = System.Windows.Visibility.Visible;
                        main.pre_cue_click[main.countTask, 0] = System.DateTime.Now;
                        main.Cursor = System.Windows.Input.Cursors.Arrow;

                        /*
                        main.Prepare.Visibility = System.Windows.Visibility.Visible;
                        main.uiTimer0.Interval = 1000; main.uiTimer0.Tick += main.hidePlus;
                        main.uiTimer1.Interval = 1000 + main.click_interval_ms[main.countTask - 1, 1]; main.uiTimer1.Tick += main.hideUpLeft;
                        main.uiTimer2.Interval = 1000 + main.click_interval_ms[main.countTask - 1, 1] + main.click_interval_ms[main.countTask - 1, 2]; main.uiTimer2.Tick += main.hideUpRight;
                        main.uiTimer3.Interval = 1000 + main.click_interval_ms[main.countTask - 1, 1] + main.click_interval_ms[main.countTask - 1, 2] + main.click_interval_ms[main.countTask - 1, 3]; main.uiTimer3.Tick += main.hideDownRight;
                        main.uiTimer4.Interval = 1000 + main.click_interval_ms[main.countTask - 1, 1] + main.click_interval_ms[main.countTask - 1, 2] + main.click_interval_ms[main.countTask - 1, 3] + main.click_interval_ms[main.countTask - 1, 4]; main.uiTimer4.Tick += main.hideDownLeft;
                        write_rhythm(main.taskType[main.type], main.countTask, "AlignedIntervals", main.click_interval_ms[main.countTask - 1, 1], main.click_interval_ms[main.countTask - 1, 2],
                        main.click_interval_ms[main.countTask - 1, 3], main.click_interval_ms[main.countTask - 1, 4], System.DateTime.Now);
                        main.uiTimer0.Start();
                        main.uiTimer1.Start();
                        main.uiTimer2.Start();
                        main.uiTimer3.Start();
                        main.uiTimer4.Start();
                        */

                    }
                }
            else
            {
                    main.Task_Rating.Visibility = System.Windows.Visibility.Visible;
                    main.subTask = 0;


                }
            }
        }



        private void write_rhythm(string taskType, int taskNum, string generator, int time1, int time2, int time3, int time4, DateTime dt)
        {
            System.DateTime currentTime = System.DateTime.Now;

            var dir = new DirectoryInfo(System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory));

            string file = dir.Parent.FullName + @"\TXT\Rhythm.txt";
            string strYMD = currentTime.ToString("dd-MM-yy");
            //("yyyy-MM-dd HH：mm：ss：ffff");

            string FILE_NAME = strYMD + ".txt";//每天按照日期建立一个不同的文件名
            StreamWriter sr;
        

            sr = File.AppendText(file);
            
            sr.WriteLine(dt.ToString("hh:mm:ss.fff") + "\t" + taskType + "\t" + taskNum + "\t" + generator + ":\t" + time1 + "\t" + time2 + "\t" + time3 + "\t" + time4);//将传入的字符串加上时间写入文本文件一行
            sr.Close();
        }

        private void write_answer(string taskType, int taskNum, string Choice, string TorF, DateTime dt)
        {
            System.DateTime currentTime = System.DateTime.Now;

            var dir = new DirectoryInfo(System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory));

            string file = dir.Parent.FullName + @"\TXT\Answers.txt";
            string strYMD = currentTime.ToString("dd-MM-yy");
            
            string FILE_NAME = strYMD + ".txt";//每天按照日期建立一个不同的文件名
            StreamWriter sr;
           
            sr = File.AppendText(file);
            sr.WriteLine(dt.ToString("hh:mm:ss.fff") + "\t" + taskType + "\t" + taskNum + "\t" + Choice + "\t" + TorF);//将传入的字符串加上时间写入文本文件一行
            sr.Close();
        }
    }

}
