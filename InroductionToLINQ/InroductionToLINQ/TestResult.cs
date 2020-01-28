using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace InroductionToLINQ
{
    [Serializable]
    public class TestResult:IComparable
    {
        public int ID;
        public string StudentName;
        public string TestName;
        public DateTime Date;
        public byte Assessment;

        public TestResult(int id, string studentName, string testName, DateTime date, byte assessment)
        {
            ID = id;
            StudentName = studentName;
            TestName = testName;
            Date = date;
            Assessment = assessment;
        }

        public int CompareTo(object obj)
        {
            return GetHashCode() - obj.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is TestResult result &&
                   ID == result.ID &&
                   StudentName == result.StudentName &&
                   TestName == result.TestName &&
                   Date == result.Date &&
                   Assessment == result.Assessment;
        }

        public override int GetHashCode()
        {
            var hashCode = 294409409;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(StudentName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TestName);
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + Assessment.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{ID} {StudentName} {TestName} {Date.ToString("dd.MM.yyyy")} {Assessment}";
        }

        public string ToString(int IDLenght, int StudentNameLenght, int TestNameLenght, int dateLenght, int assessmentLenght, string viewCriteria)
        {
            var result = new StringBuilder();
            for (int i = 0; i < viewCriteria.Length; i++)
            {
                switch (viewCriteria.ToLower()[i])
                {
                    case 'i':
                        {
                            result.Append(DataFormate(IDLenght, ID.ToString()));
                            break;
                        }
                    case 's':
                        {
                            result.Append(DataFormate(StudentNameLenght, StudentName));
                            break;
                        }
                    case 't':
                        {
                            result.Append(DataFormate(TestNameLenght, TestName));
                            break;
                        }
                    case 'd':
                        {
                            result.Append(DataFormate(dateLenght, Date.ToString("dd.MM.yyyy")));
                            break;
                        }
                    case 'a':
                        {
                            result.Append(DataFormate(assessmentLenght, Assessment.ToString()));
                            break;
                        }
                    default:
                        {
                            result.Append(viewCriteria[i]);
                            break;
                        }
                }
            }
            return result.ToString();
        }

        public static string DataFormate(int dataLenght, string data)
        {
            var result = new StringBuilder();
            for (int i = 0; i < dataLenght;)
            {
                if (i < data.Length)
                {
                    result.Append(data);
                    i += data.Length;
                }
                else
                {
                    result.Append(" ");
                    i++;
                }
            }
            return result.ToString();
        }
    }

    [Serializable]
    public class TestResults : IEnumerable<TestResult>
    {
        public BinaryTree<TestResult> results = new BinaryTree<TestResult>();

        /// <summary>
        /// Serialize class instance to a binary file
        /// </summary>
        /// <param name="results">class instance</param>
        /// <param name="filePath">file path</param>
        public static void WriteResultsTo(TestResults results, string filePath)
        {
            var binaryFormatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fs, results);
                Console.WriteLine("Object serialized");
            }
        }

        /// <summary>
        /// deserialize class instence from .bin file
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns>class instance</returns>
        public static TestResults ReadResultsFrom(string filePath)
        {
            TestResults results;
            var binaryFormatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                results = (TestResults)binaryFormatter.Deserialize(fs);

            }
            results.results.TransverceMethod = results.results.root.InOrderTraversing;
            return results;
        }

        public static string ToString(IEnumerable<TestResult> results,string viewCriteria = "I|S|T|D|A")
        {
            var result = new StringBuilder();
            var IDLenght = results.Select(x => x.ID.ToString().Length).Append("ID".Length).Max();
            var studentNameLenght = results.Select(x => x.StudentName.Length).Append("Student".Length).Max();
            var testNameLenght = results.Select(x => x.TestName.Length).Append("Test".Length).Max();
            var dateLenght = results.Select(x => x.Date.ToString("dd.MM.yyyy").Length).Append("Date".Length).Max();
            var assessmentLenght = results.Select(x => x.Assessment.ToString().Length).Append("Assessment".Length).Max();
            for(int i = 0; i<viewCriteria.Length; i++)
            {
                switch (viewCriteria.ToLower()[i])
                {
                    case 'i':
                        {
                            result.Append(TestResult.DataFormate(IDLenght, "ID"));
                            break;
                        }
                    case 's':
                        {
                            result.Append(TestResult.DataFormate(studentNameLenght, "Student"));
                            break;
                        }
                    case 't':
                        {
                            result.Append(TestResult.DataFormate(testNameLenght, "Test"));
                            break;
                        }
                    case 'd':
                        {
                            result.Append(TestResult.DataFormate(dateLenght, "Date"));
                            break;
                        }
                    case 'a':
                        {
                            result.Append(TestResult.DataFormate(assessmentLenght, "Assessment"));
                            break;
                        }
                    default:
                        {
                            result.Append(viewCriteria[i]);
                            break;
                        }
                }
            }
            result.Append('\n');
            foreach (var test in results)
            {
                result.Append(test.ToString(IDLenght,studentNameLenght,testNameLenght,dateLenght,assessmentLenght,viewCriteria)+"\n");
            }
            return result.ToString();
        }

        public string ToString(string viewCriteria)
        {
            return TestResults.ToString(this, viewCriteria);
        }

        public IEnumerator<TestResult> GetEnumerator()
        {
            foreach(var result in results)
            {
                yield return result;
            }
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var result in results)
            {
                yield return result;
            }
            yield break;
        }
    }
}
