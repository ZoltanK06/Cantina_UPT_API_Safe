using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.Core.Interfaces;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.Core.ProjectAggregate.Specifications;
using CantinaUPT_API.SharedKernel.Interfaces;

namespace CantinaUPT_API.Core.Services;
public class CardService: ICardService
{
  private readonly IReadRepository<User> _readRepository;
  private readonly IRepository<User> _repository;

  public CardService(IReadRepository<User> readRepository, IRepository<User> repository)
  {
    _readRepository = readRepository;
    _repository = repository;
  }

  public async Task<List<Card>> GetUsersCards(int userId)
  {
    var specification = new UserWithCards(userId);
    var user = await _readRepository.GetBySpecAsync(specification);
    return user.Cards;
  }

  public async Task AddNewCard(int userId, Card card)
  {
    var specification = new UserWithCards(userId);
    var user = await _readRepository.GetBySpecAsync(specification);
    if(user.Cards == null)
    {
      user.Cards = new List<Card> { card };
    }
    else
    {
      user.Cards.Add(card);
    }
    await _repository.SaveChangesAsync();
  }

  public EncryptedCardData CreateEncryptedCardData(string cardNumber, string cvc)
  {
    string encryptedNumber;
    string encryptedCvc;

    cardNumber += "m1t09s3cr3tk31@";
    cvc += "m1t09s3cr3tk31@";
    encryptedNumber = Convert.ToBase64String(Encoding.UTF8.GetBytes(cardNumber));
    encryptedCvc = Convert.ToBase64String(Encoding.UTF8.GetBytes(cvc));

    return new EncryptedCardData
    {
      EncryptedNumber = encryptedNumber,
      EncryptedCvc = encryptedCvc
    };
  }

  public string DecryptCardNumber(string encryptedNumber)
  {
    var decryptedNumber = Encoding.UTF8.GetString(Convert.FromBase64String(encryptedNumber));
    return decryptedNumber.Substring(decryptedNumber.Length - 19, 4);
  }

}
