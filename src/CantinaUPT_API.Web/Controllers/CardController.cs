using CantinaUPT_API.Core.Interfaces;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace CantinaUPT_API.Web.Controllers;

[Route("api/Card")]
[ApiController]
public class CardController: ControllerBase
{
  private readonly ICardService _cardService;
  public CardController(ICardService cardService)
  {
    _cardService = cardService;
  }

  [Route("GetUsersCards")]
  [HttpGet]
  public async Task<IActionResult> GetUsersCards([FromQuery]int userId)
  {
    try
    {
      var cardList = await _cardService.GetUsersCards(userId);
      var cardDtoList = new List<CardDTO>();

      cardList.ForEach(card =>
      {
        var cardDto = new CardDTO
        {
          Id = card.Id,
          Cvc = "",
          Name = card.Name,
          Expiry = card.Expiry,
          Number = _cardService.DecryptCardNumber(card.EncryptedNumber)
        };

        cardDtoList.Add(cardDto);
      });

      return Ok(cardDtoList);
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [Route("AddCard/{userId}")]
  [HttpPost]
  public async Task<IActionResult> AddCard(int userId,[FromBody] CardDTO cardDto)
  {
    try
    {
      var encryptedData = _cardService.CreateEncryptedCardData(cardDto.Number, cardDto.Cvc);
      var card = new Card
      {
        EncryptedNumber = encryptedData.EncryptedNumber,
        EncryptedCvc = encryptedData.EncryptedCvc,
        Name = cardDto.Name,
        Expiry = cardDto.Expiry
      };
      await _cardService.AddNewCard(userId, card);
      return Ok();
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }
}
