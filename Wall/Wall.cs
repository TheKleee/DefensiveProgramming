/*
 * The Wall! : D
 * Let's make sure that whatever we're doing our foundation will not crumble!
 * If it shows signs of weakness we must quickly address them!
 */
using System;
using WorkForce;
using WorkForce.ShowWork;

public static class Wall
{
    public static void Main(string[] args)
    {

        try
        {
            var worker1 = new Worker(25, 2, "Nomad");
            var worker2 = new Worker(21, 1, "Komad");
            var worker3 = new Worker(17, 19, "Deo"); //Chuck Norris Yolo! xD
            var worker4 = new Worker(37, 10, "Ceo");

            Interview.PotentialWorkers(new Worker[] { worker1, worker2, worker3, worker4 });
        }
        catch (Exception e)
        {
            Console.Write($"{e.Message}\n{e.StackTrace}");
        }
    }

    public static void BuildFundation<T>(this T t) where T : class
    {
        //This is something workers will do once they pass the interview!!!
        //T represents their job class that isn't defined in this program...
    }
}

namespace WorkForce
{
    public class Worker
    {
        public string name { get; private set; }
        public int age { get; protected set; }    //Must be at least 18
        public int experience { get; protected set; } //Measured in years

        public Worker(int age = 18, int experience = 0, string name = "Marko")
        {
            this.name = name;
            this.age = age;
            this.experience = experience;
        }
    }

    public static class Interview
    {
        public static Worker[] PotentialWorkers(this Worker[] w, int maxInterviewNumber = 10, int desiredExpereinece = 3, int minAge = 18)
        {
            if (w == null)
                throw new ArgumentNullException("w", "There are no potential workers!");
            if (maxInterviewNumber < 1)
                throw new ArgumentOutOfRangeException("maxInterviewNumber", "You probably wanted to call someone for this interview...");

            maxInterviewNumber = maxInterviewNumber > w.Length ? w.Length : maxInterviewNumber;
            var chosenWorkers = new Worker[maxInterviewNumber];
            int toInterview = 0;
            for (int i = 0; i < w.Length; i++)
            {
                if (w[i].HasEnoughExperience(desiredExpereinece) && w[i].IsOldEnough(minAge))
                {
                    chosenWorkers[toInterview] = w[i];
                    toInterview++;
                    if (toInterview > maxInterviewNumber)
                        break;
                }
            }

            return chosenWorkers.CallForIntereview(toInterview); ;
        }

        public static Worker[] CallForIntereview(this Worker[] interviewees, int numOfPeople)
        {
            if (interviewees == null)
                throw new ArgumentNullException("interviewees", "Find some interviewees before you schedule the call for the interveiw!");
            if (numOfPeople > interviewees.Length)
            {
                numOfPeople = interviewees.Length;
                Console.WriteLine("It seems you planned on calling more people to this interview, verify your notes!");
            }

            var called = new Worker[numOfPeople];
            for (int i = 0; i < called.Length; i++)
                called[i] = interviewees[i];

            called.ShowInterveiwees();
            return called;
        }

        public static void ShowInterveiwees(this Worker[] interviewees)
        {
            foreach (var i in interviewees)
                Console.WriteLine($"Called to interview: {i.name}");
        }
    }
}

namespace WorkForce.ShowWork
{
    public static class WorkDone
    {
        public static T[] ShowWork<T>(this T[] w, T[] relevantWork) where T : class, new()
        {
            if (w == null)
                throw new ArgumentNullException("w", "There must be some work done before you can show it!");

            var r = new T[w.Length];
            int relevantNum = 0;
            for (int i = 0; i < w.Length; i++)
            {
                for (int j = 0; j < relevantWork.Length; j++)
                {
                    if(w[i].Equals(relevantWork[j]))
                    {
                        r[relevantNum] = w[i];
                        relevantNum++;
                    }
                }
            }

            return r.RelevantWork(relevantNum);
        }

        public static T[] RelevantWork<T>(this T[] rw, int numOfWork) where T : class, new()
        {
            var checkWork = new T[numOfWork];
            for (int i = 0; i < numOfWork; i++)
                checkWork[i] = rw[i];

            return checkWork;
        }

        public static bool HasEnoughExperience(this Worker e, int minExperience = 3)
        {
            if (minExperience < 0)
                throw new ArgumentOutOfRangeException("minExperience", "The given minimum experience must be a positive number!");

            return e.experience >= minExperience;
        }

        public static bool IsOldEnough(this Worker e, int minAge = 18)
        {
            if (minAge < 0)
                throw new ArgumentOutOfRangeException("minAge", "This person was not even born yet... :|");

            return e.age >= minAge;
        }
    }
}
