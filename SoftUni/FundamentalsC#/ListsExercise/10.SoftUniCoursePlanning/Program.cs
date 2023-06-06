using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(", ").ToList();
            List<string> commands = Console.ReadLine().Split(':').ToList();

            while (commands[0] != "course start")
            {
                string operation = commands[0];

                if (operation == "Add")
                {
                    bool found = false;
                    foreach (string lesson in lessons)
                    {
                        if (commands[1] == lesson)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                        lessons.Add(commands[1]);
                }
                else if (operation == "Insert")
                {
                    int index = int.Parse(commands[2]);
                    bool found = false;
                    if (index >= 0 && index < lessons.Count)
                    {
                        for (int i = 0; i < lessons.Count; i++)
                        {
                            if (commands[1] == lessons[i])
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                            lessons.Insert(index, commands[1]);
                    }
                }
                else if (operation == "Remove")
                {
                    string lessonTitle = commands[1];
                    for (int i = lessons.Count-1; i >= 0; i--)
                    {
                        if (lessonTitle == lessons[i])
                            lessons.Remove(lessons[i]);

                        try
                        {
                            if ($"{lessonTitle}-Exercise" == lessons[i])
                                lessons.Remove(lessons[i]);
                        }
                        catch { continue; }
                    }
                }
                else if (operation == "Swap")
                {
                    string lessonTitle1 = commands[1];
                    string lessonTitle2 = commands[2];
                    bool lessonTitle1Found = false, lessonTitle2Found = false;
                    bool exercise1Found = false, exercise2Found = false;
                    string exTitle1 = string.Empty, exTitle2 = string.Empty;
                    int indexLesson1 = 0, indexLesson2 = 0;
                    int indexEx1 = 0, indexEx2 = 0;
                    for (int i = 0; i < lessons.Count; i++)
                    {
                        if (lessonTitle1 == lessons[i])
                        {
                            lessonTitle1Found = true;
                            indexLesson1 = i;
                        }

                        if (lessonTitle2 == lessons[i])
                        {
                            lessonTitle2Found = true;
                            indexLesson2 = i;
                        }

                        if ($"{lessonTitle1}-Exercise" == lessons[i])
                        {
                            exTitle1 = lessons[i];
                            indexEx1 = i;
                            exercise1Found = true;
                        }

                        if ($"{lessonTitle2}-Exercise" == lessons[i])
                        {
                            exTitle2 = lessons[i];
                            indexEx2 = i;
                            exercise2Found = true;
                        }
                    }


                    if (lessonTitle1Found && lessonTitle2Found)
                    {
                        string swap = lessonTitle1;
                        lessons[indexLesson1] = lessons[indexLesson2];
                        lessons[indexLesson2] = swap;

                        if (exercise1Found && exercise2Found)
                        {
                            string swapEx = exTitle1;
                            lessons[indexEx1] = lessons[indexEx2];
                            lessons[indexEx2] = swapEx;
                        }
                        else if (exercise1Found)
                        {
                            lessons.RemoveAt(indexEx1);
                            if (indexLesson2 + 1 > lessons.Count - 1)
                                lessons.Add(exTitle1);
                            else
                                lessons.Insert(indexLesson2 + 1, exTitle1);
                        }
                        else if (exercise2Found)
                        {
                            lessons.RemoveAt(indexEx2);
                            if (indexLesson1 + 1 > lessons.Count - 1)
                                lessons.Add(exTitle2);
                            else
                                lessons.Insert(indexLesson1 + 1, exTitle2);
                        }
                    }
                }
                else if (operation == "Exercise")
                {
                    string lessonTitel = commands[1];
                    bool lessonFound = false, exerciseFound = false;
                    int index = 0;
                    for (int i = 0; i < lessons.Count; i++)
                    {
                        if (lessons[i] == lessonTitel)
                        {
                            lessonFound = true;
                            index = i;
                        }
                        if ($"{lessonTitel}-Exercise" == lessons[i])
                        {
                            exerciseFound = true;
                        }
                    }
                    if (lessonFound && !exerciseFound)
                    {
                        lessons.Insert(index + 1, $"{lessonTitel}-Exercise");
                    }
                    else if (!lessonFound && !exerciseFound)
                    {
                        lessons.Add(lessonTitel);
                        lessons.Add($"{lessonTitel}-Exercise");
                    }
                }
                commands = Console.ReadLine().Split(':').ToList();
            }
            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }
        }
    }
}
