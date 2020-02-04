using AStateManagment.Entities;
using Microsoft.EntityFrameworkCore;
using StateManagment.DAL;
using System;
using System.Linq;

namespace StateManagment.EndPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new StateManegmentContext();
            var ctx2 = new StateManegmentContext();
            var person = ctx.Person.Include(c=>c.JobData).Include(c=>c.Contacts).FirstOrDefault();
            var job = ctx.JobData.Include(c => c.Person).FirstOrDefault();

            ctx2.ChangeTracker.TrackGraph(person, c =>
            {
                switch (c.Entry.Entity)
                {
                    case Person p:
                        ctx2.Entry(p).State = EntityState.Unchanged;
                        Console.WriteLine("Person:" + p.PersonID);
                        break;
                    case JobData job:
                        ctx2.Entry(job).State = EntityState.Unchanged;
                        Console.WriteLine("job:" + job.JobDataId);
                        break;
                    case Contacts contacts:
                       ctx2.Entry(contacts).State = EntityState.Unchanged;
                        Console.WriteLine("contacts:" + contacts.ContactsID);
                        break;

                }
            });
            Console.WriteLine("no thing");

           Console.WriteLine("");
            //var FirstName = ctx.Entry(person).Property(c => c.FirstName).IsModified = true;
            //UpdateCustomState(ctx, person, FirstName);
            //UpdateStates(ctx);
            //Delete02(ctx, person);
            //DeletePerson(ctx);
            //PersonFromDB(ctx);
            //JobFromDB(ctx);
            //AddPerson01(ctx);

            Console.ReadLine();
        }

        private static void UpdateCustomState(StateManegmentContext ctx, Person person, bool firstName)
        {
            Console.WriteLine("person:  " + ctx.Entry(person).State);
            Console.WriteLine("FirstName:" + ctx.Entry(person).Property(c => c.FirstName).IsModified);
            Console.WriteLine("LasttName:" + ctx.Entry(person).Property(c => c.LasttName).IsModified);
            Console.WriteLine("");

            //firstName.IsModified = true;

            person.FirstName = "Nika5";
            //ctx.Person.Update(person);
            ctx.SaveChanges();

            Console.WriteLine("");
            Console.WriteLine("person:  " + ctx.Entry(person).State);
            Console.WriteLine("FirstName:" + ctx.Entry(person).Property(c => c.FirstName).IsModified);
            Console.WriteLine("LasttName:" + ctx.Entry(person).Property(c => c.LasttName).IsModified);
        }

        private static void UpdateStates(StateManegmentContext ctx)
        {
            Person person = ctx.Person.FirstOrDefault();

            Console.WriteLine("person:  " + ctx.Entry(person).State);
            Console.WriteLine("FirstName:" + ctx.Entry(person).Property(c => c.FirstName).IsModified);
            Console.WriteLine("");

            person.FirstName = "Nika2";
            Console.WriteLine("person:  " + ctx.Entry(person).State);
            Console.WriteLine("FirstName:" + ctx.Entry(person).Property(c => c.FirstName).IsModified);
            ctx.Entry(person).Property(c => c.FirstName).IsModified = true;
            Console.WriteLine("person:  " + ctx.Entry(person).State);
            Console.WriteLine("FirstName:" + ctx.Entry(person).Property(c => c.FirstName).IsModified);
            Console.WriteLine("");

            ctx.Person.Update(person);
            Console.WriteLine("person:  " + ctx.Entry(person).State);
            Console.WriteLine("FirstName:" + ctx.Entry(person).Property(c => c.FirstName).IsModified);
            Console.WriteLine("");

            ctx.SaveChanges();

            Console.WriteLine("person:  " + ctx.Entry(person).State);
            Console.WriteLine("FirstName:" + ctx.Entry(person).Property(c => c.FirstName).IsModified);
        }

        private static void Delete02(StateManegmentContext ctx, Person person)
        {
            JobData jobData = new JobData
            {
                JobTitile = "Programmer7"
            };
            person.JobData = jobData;

            Console.WriteLine("person:  " + ctx.Entry(person).State);
            Console.WriteLine("jobData:  " + ctx.Entry(jobData).State);
            Console.WriteLine("");

            ctx.Person.Remove(person);

            Console.WriteLine("person:  " + ctx.Entry(person).State);
            Console.WriteLine("jobData:  " + ctx.Entry(jobData).State);
            Console.WriteLine("");

            ctx.SaveChanges();
            Console.WriteLine("person:  " + ctx.Entry(person).State);
            Console.WriteLine("jobData:  " + ctx.Entry(jobData).State);
            Console.WriteLine("");
        }

        private static void DeletePerson(StateManegmentContext ctx)
        {
            Person person = ctx.Person.FirstOrDefault();
            JobData jobData = new JobData
            {
                JobTitile = "Programmer7"
            };
            Console.WriteLine("person:  " + ctx.Entry(person).State);
            Console.WriteLine("jobData:  " + ctx.Entry(jobData).State);
            Console.WriteLine("");

            ctx.Person.Remove(person);

            Console.WriteLine("person:  " + ctx.Entry(person).State);
            Console.WriteLine("jobData:  " + ctx.Entry(jobData).State);
            Console.WriteLine("");

            ctx.SaveChanges();
            Console.WriteLine("person:  " + ctx.Entry(person).State);
            Console.WriteLine("jobData:  " + ctx.Entry(jobData).State);
            Console.WriteLine("");
        }

        private static void PersonFromDB(StateManegmentContext ctx)
        {
            Person person = ctx.Person.FirstOrDefault();

            JobData jobData = new JobData
            {
                JobTitile = "Programmer7"
            };
            person.JobData = jobData;

            Console.WriteLine("person:  " + ctx.Entry(person).State);
            Console.WriteLine("jobData:  " + ctx.Entry(jobData).State);
            Console.WriteLine("");


            ctx.SaveChanges();

            Console.WriteLine("person:  " + ctx.Entry(person).State);
            Console.WriteLine("jobData:  " + ctx.Entry(jobData).State);
            Console.WriteLine("");
        }

        private static void JobFromDB(StateManegmentContext ctx)
        {
            Person person = new Person
            {
                FirstName = "Bita3",
                LasttName = "Tamaddoni3"

            };

            JobData jobData = ctx.JobData.FirstOrDefault();
            person.JobData = jobData;

            Console.WriteLine("person:  " + ctx.Entry(person).State);
            Console.WriteLine("jobData:  " + ctx.Entry(jobData).State);
            Console.WriteLine("");

            ctx.Add(person);

            Console.WriteLine("person:  " + ctx.Entry(person).State);
            Console.WriteLine("jobData:  " + ctx.Entry(jobData).State);
            Console.WriteLine("");
            ctx.SaveChanges();

            Console.WriteLine("person:  " + ctx.Entry(person).State);
            Console.WriteLine("jobData:  " + ctx.Entry(jobData).State);
            Console.WriteLine("");
        }

        private static void AddPerson01(StateManegmentContext ctx)
        {
            Person person = new Person
            {
                FirstName = "Parisa",
                LasttName = "Fulady"

            };
            JobData jobData = new JobData
            {
                JobTitile = "Programmer"
            };
            person.JobData = jobData;

            Console.WriteLine("person:  " + ctx.Entry(person).State);
            Console.WriteLine("jobData:  " + ctx.Entry(jobData).State);

            ctx.Add(person);

            Console.WriteLine("person:  " + ctx.Entry(person).State);
            Console.WriteLine("jobData:  " + ctx.Entry(jobData).State);

            ctx.SaveChanges();

            Console.WriteLine("person:  " + ctx.Entry(person).State);
            Console.WriteLine("jobData:  " + ctx.Entry(jobData).State);
        }
    }
}
