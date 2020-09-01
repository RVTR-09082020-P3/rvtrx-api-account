using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RVTR.Account.ObjectModel.Models;
using Xunit;

namespace RVTR.Account.UnitTesting.Tests
{
  public class AccountModelTest
  {
    public static readonly IEnumerable<object[]> _accounts = new List<object[]>
    {
      new object[]
      {
        new AccountModel()
        {
          Id = 0,
          Address = new AddressModel(),
          Name = "name",
          Payments = new List<PaymentModel>(),
          Profiles = new List<ProfileModel>()
        }
      }
    };

    [Theory]
    [MemberData(nameof(_accounts))]
    public void Test_Create_AccountModel(AccountModel account)
    {
      var validationContext = new ValidationContext(account);
      var actual = Validator.TryValidateObject(account, validationContext, null, true);

      Assert.True(actual);
    }

    [Theory]
    [MemberData(nameof(_accounts))]
    public void Test_Validate_AccountModel(AccountModel account)
    {
      var validationContext = new ValidationContext(account);

      Assert.Empty(account.Validate(validationContext));
    }
  }
}
