using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    class CollageManagement
    {
        Dictionary<string, Dictionary<string, int>> studentRecords = new Dictionary<string, Dictionary<string, int>>();

        Dictionary<string, LinkedList<KeyValuePair<string, int>>> studentSubjectsOrder = new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();

        Dictionary<string, Dictionary<string, int>> subjectsRecords = new Dictionary<string, Dictionary<string, int>>();

        Dictionary<string, LinkedList<KeyValuePair<string, int>>> subjectsStudentsOrder = new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();


        public int AddStudent(string studentId, string subject, int marks)
        {
            if (!studentRecords.ContainsKey(studentId))
            {
                studentRecords[studentId] = new Dictionary<string, int>();
                studentSubjectsOrder[studentId] = new LinkedList<KeyValuePair<string, int>>();
            }

            if (!subjectsRecords.ContainsKey(subject))
            {
                subjectsRecords[subject] = new Dictionary<string, int>();
                subjectsStudentsOrder[subject] = new LinkedList<KeyValuePair<string, int>>();
            }

            if (!studentRecords[studentId].ContainsKey(subject))
            {
                studentRecords[studentId][subject] = marks;
                studentSubjectsOrder[studentId].AddLast(new KeyValuePair<string, int>(subject, marks));

                subjectsRecords[subject][studentId] = marks;
                subjectsStudentsOrder[subject].AddLast(new KeyValuePair<string, int>(studentId, marks));
            }
            else
            {
                if (marks > studentRecords[studentId][subject])
                {
                    studentRecords[studentId][subject] = marks;
                    subjectsRecords[subject][studentId] = marks;

                    var node = studentSubjectsOrder[studentId].First;
                    while (node != null)
                    {
                        if (node.Value.Key == subject)
                        {
                            node.Value = new KeyValuePair<string, int>(subject, marks);
                            break;
                        }
                        node = node.Next;
                    }

                    var node2 = subjectsStudentsOrder[subject].First;
                    while (node2 != null)
                    {
                        if (node2.Value.Key == studentId)
                        {
                            node2.Value = new KeyValuePair<string, int>(studentId, marks);
                            break;
                        }
                        node2 = node2.Next;
                    }
                }
            }

            return 1;
        }

        public int RemoveStudent(string studentId)
        {
            if (!studentRecords.ContainsKey(studentId))
                return 0;

            foreach (var subject in studentRecords[studentId].Keys)
            {
                subjectsRecords[subject].Remove(studentId);

                var node = subjectsStudentsOrder[subject].First;
                while (node != null)
                {
                    if (node.Value.Key == studentId)
                    {
                        subjectsStudentsOrder[subject].Remove(node);
                        break;
                    }
                    node = node.Next;
                }
            }

            studentRecords.Remove(studentId);
            studentSubjectsOrder.Remove(studentId);

            return 1;
        }

        public string TopStudent(string subject)
        {
            if (!subjectsRecords.ContainsKey(subject))
                return "";

            int max = subjectsRecords[subject].Values.Max();

            string result = "";

            foreach (var pair in subjectsStudentsOrder[subject])
            {
                if (pair.Value == max)
                {
                    result += pair.Key + " " + pair.Value + "\n";
                }
            }

            return result.Trim();
        }

        public string Result()
        {
            string output = "";

            foreach (var student in studentRecords)
            {
                double avg = student.Value.Values.Average();
                output += student.Key + " " + avg.ToString("F2") + "\n";
            }

            return output.Trim();
        }
    }


       public static void Main()
    {
        CollageManagement cm = new CollageManagement();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            string[] parts = input.Split();

            if (parts[0] == "ADD")
            {
                cm.AddStudent(parts[1], parts[2], int.Parse(parts[3]));
            }
            else if (parts[0] == "REMOVE")
            {
                cm.RemoveStudent(parts[1]);
            }
            else if (parts[0] == "TOP")
            {
                Console.WriteLine(cm.TopStudent(parts[1]));
            }
            else if (parts[0] == "RESULT")
            {
                Console.WriteLine(cm.Result());
            }
        
    }
}
}