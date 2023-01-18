using DreamOrbit.Greetings.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamOrbit.Greetings.EmailComponent.EmailComponent
{
    public static class RandomEmailMessage
    {

        public static EmailMessage PickRandomEmailMessage(List<EmailMessage> emailMessage)
        {

            var randomValue = new EmailMessage
            {
               // Wish = emailMessage.OrderByDescending(r => Guid.NewGuid()).Select(r => r.Wish).FirstOrDefault(),
               // Photo = emailMessage.OrderBy(r => Guid.NewGuid()).Select(r => r.Photo).FirstOrDefault(),
                Wish = emailMessage.Select(r => r.Wish).OrderBy(r => Guid.NewGuid()).FirstOrDefault(),
                Photo = emailMessage.Select(r => r.Photo).OrderBy(r => Guid.NewGuid()).FirstOrDefault()
            };
            return randomValue;

/*
             var random = new Random();

             //to get the random photo
             var imagePaths = emailMessage.Select(i => i.Photo).ToList();
             var index1 = random.Next(imagePaths.Count);
             var imagePath = imagePaths[index1];

             //to get the random wish
              var wishPaths = emailMessage.Select(i => i.Wish).ToList();
              var index2 = random.Next(wishPaths.Count);
              var wishPath = wishPaths[index2];

            var randomValue = new EmailMessage
            {
                Photo = imagePath,
                Wish= wishPath
            };
            return randomValue;*/
        }
    }
}
