using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.Core.ProjectAggregate;

namespace CantinaUPT_API.Core.Interfaces;
public interface ICardService
{
  Task AddNewCard(int userId, Card card);
  EncryptedCardData CreateEncryptedCardData(string cardNumber, string cvc);
  Task<List<Card>> GetUsersCards(int userId);
  string DecryptCardNumber(string encryptedNumber);
}
