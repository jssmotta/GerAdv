using FluentAssertions;
using MenphisSI.BaseCommon;
using MenphisSI.GerAdv;
using MenphisSI.GerAdv.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace API.Tests.Controllers;

public class UsersControllerTests
{
    private readonly Mock<IUserService> _mockUserService;
    private readonly UsersController _controller;
    private const string TestUri = "test-uri";

    public UsersControllerTests()
    {
        _mockUserService = new Mock<IUserService>();
        _controller = new UsersController(_mockUserService.Object);
    }

    #region ChangePassword Tests

    [Fact]
    public async Task ChangePassword_ComResponseValido_DeveRetornarOk()
    {
        // Arrange
        var request = new AuthenticateRequest
        {
            Username = "testuser",
            Password = "password123"
        };
        var expectedResponse = new AuthenticateResponse(
            new OperadorResponse { Id = 1, Nome = "Test User" }, 
            "token123", 
            "user", 
            TestUri
        );

        _mockUserService
            .Setup(x => x.ChangePassword(request, TestUri))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await _controller.ChangePassword(request, TestUri);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult!.Value.Should().Be(expectedResponse);

        _mockUserService.Verify(x => x.ChangePassword(request, TestUri), Times.Once);
    }

    [Fact]
    public async Task ChangePassword_ComResponseNulo_DeveRetornarBadRequest()
    {
        // Arrange
        var request = new AuthenticateRequest
        {
            Username = "testuser",
            Password = "password123"
        };

        _mockUserService
            .Setup(x => x.ChangePassword(request, TestUri))
            .ReturnsAsync((AuthenticateResponse?)null);

        // Act
        var result = await _controller.ChangePassword(request, TestUri);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
        var badRequestResult = result as BadRequestObjectResult;
        badRequestResult!.Value.Should().BeEquivalentTo(new { message = "Error on Change Password" });

        _mockUserService.Verify(x => x.ChangePassword(request, TestUri), Times.Once);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task ChangePassword_ComUriInvalido_DeveProcessarNormalmente(string uri)
    {
        // Arrange
        var request = new AuthenticateRequest
        {
            Username = "testuser",
            Password = "password123"
        };
        var expectedResponse = new AuthenticateResponse(
            new OperadorResponse { Id = 1, Nome = "Test User" }, 
            "token123", 
            "user", 
            uri ?? string.Empty
        );

        _mockUserService
            .Setup(x => x.ChangePassword(request, uri))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await _controller.ChangePassword(request, uri);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        _mockUserService.Verify(x => x.ChangePassword(request, uri), Times.Once);
    }

    #endregion

    #region Reset Tests

    [Fact]
    public async Task Reset_ComUriValido_DeveRetornarOk()
    {
        // Arrange
        var expectedResponse = "reset-successful";

        _mockUserService
            .Setup(x => x.Reset(TestUri))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await _controller.Reset(TestUri);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult!.Value.Should().Be(expectedResponse);

        _mockUserService.Verify(x => x.Reset(TestUri), Times.Once);
    }

    [Fact]
    public async Task Reset_ComQualquerUri_SempreRetornaOk()
    {
        // Arrange
        var response = "reset-processed";

        _mockUserService
            .Setup(x => x.Reset(It.IsAny<string>()))
            .ReturnsAsync(response);

        // Act
        var result = await _controller.Reset("any-uri");

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        _mockUserService.Verify(x => x.Reset("any-uri"), Times.Once);
    }

    #endregion

    #region SetPassword Tests

    [Fact]
    public async Task SetPassword_ComUsuarioValidoESenhaForte_DeveRetornarOk()
    {
        // Arrange
        var request = new ResetPasswordRequest
        {
            Id = 1,
            Password = "U3Ryb25nUGFzc3dvcmQxMjM=" // "StrongPassword123" em base64
        };

        var dbUser = new OperadorResponse { Id = 1, Nome = "TestUser" };

        _mockUserService
            .Setup(x => x.GetById(request.Id, TestUri))
            .ReturnsAsync(dbUser);

        _mockUserService
            .Setup(x => x.SetPassword(request.Id, "StrongPassword123", TestUri))
            .ReturnsAsync(true);

        // NOTE: Cannot mock static SGHelpers.IsSenhaFraca directly. Consider using a wrapper or partial mock in production code.
        // For now, this test will pass only if the password is strong according to SGHelpers logic.

        // Act
        var result = await _controller.SetPassword(request, TestUri);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult!.Value.Should().Be(true);

        _mockUserService.Verify(x => x.GetById(request.Id, TestUri), Times.Once);
        _mockUserService.Verify(x => x.SetPassword(request.Id, "StrongPassword123", TestUri), Times.Once);
    }

    [Fact]
    public async Task SetPassword_ComUsuarioNaoEncontrado_DeveRetornarBadRequest()
    {
        // Arrange
        var request = new ResetPasswordRequest
        {
            Id = 999,
            Password = "UGFzc3dvcmQxMjM=" // "Password123" em base64
        };

        _mockUserService
            .Setup(x => x.GetById(request.Id, TestUri))
            .ReturnsAsync((OperadorResponse?)null);

        // Act
        var result = await _controller.SetPassword(request, TestUri);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
        var badRequestResult = result as BadRequestObjectResult;
        badRequestResult!.Value.Should().BeEquivalentTo(new { message = "Error setting password, operator" });

        _mockUserService.Verify(x => x.GetById(request.Id, TestUri), Times.Once);
        _mockUserService.Verify(x => x.SetPassword(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task SetPassword_ComUsuarioIdZero_DeveRetornarBadRequest()
    {
        // Arrange
        var request = new ResetPasswordRequest
        {
            Id = 1,
            Password = "UGFzc3dvcmQxMjM="
        };

        var dbUser = new OperadorResponse { Id = 0, Nome = "TestUser" }; // Id = 0

        _mockUserService
            .Setup(x => x.GetById(request.Id, TestUri))
            .ReturnsAsync(dbUser);

        // Act
        var result = await _controller.SetPassword(request, TestUri);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
        var badRequestResult = result as BadRequestObjectResult;
        badRequestResult!.Value.Should().BeEquivalentTo(new { message = "Error setting password, operator" });
    }

    [Fact]
    public async Task SetPassword_ComSetPasswordFalhando_DeveRetornarBadRequest()
    {
        // Arrange
        var request = new ResetPasswordRequest
        {
            Id = 1,
            Password = "U3Ryb25nUGFzc3dvcmQxMjM="
        };

        var dbUser = new OperadorResponse { Id = 1, Nome = "TestUser" };

        _mockUserService
            .Setup(x => x.GetById(request.Id, TestUri))
            .ReturnsAsync(dbUser);

        _mockUserService
            .Setup(x => x.SetPassword(request.Id, "StrongPassword123", TestUri))
            .ReturnsAsync(false); // Falha ao definir senha

        // Act
        var result = await _controller.SetPassword(request, TestUri);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
        var badRequestResult = result as BadRequestObjectResult;
        badRequestResult!.Value.Should().BeEquivalentTo(new { message = "Error setting password" });
    }

    [Fact]
    public async Task SetPassword_ComSenhaFraca_DeveRetornarBadRequest()
    {
        // Arrange
        var request = new ResetPasswordRequest
        {
            Id = 1,
            Password = "MTIz" // "123" em base64 - senha fraca
        };

        var dbUser = new OperadorResponse { Id = 1, Nome = "TestUser" };

        _mockUserService
            .Setup(x => x.GetById(request.Id, TestUri))
            .ReturnsAsync(dbUser);

        // Act
        var result = await _controller.SetPassword(request, TestUri);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
        var badRequestResult = result as BadRequestObjectResult;
        badRequestResult!.Value.Should().BeEquivalentTo(new { message = "Weak passord" });

        _mockUserService.Verify(x => x.GetById(request.Id, TestUri), Times.Once);
        _mockUserService.Verify(x => x.SetPassword(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    #endregion

    #region Testes de Integração com Múltiplos Cenários

    [Theory]
    [InlineData("user1", "uri1")]
    [InlineData("user2", "uri2")]
    [InlineData("admin", "production")]
    public async Task ChangePassword_ComDiferentesUsuariosEUris_DeveProcessarCorretamente(string username, string uri)
    {
        // Arrange
        var request = new AuthenticateRequest { Username = username, Password = "test123" };
        var expectedResponse = new AuthenticateResponse(
            new OperadorResponse { Id = 1, Nome = username }, 
            "token123", 
            "user", 
            uri
        );

        _mockUserService
            .Setup(x => x.ChangePassword(It.Is<AuthenticateRequest>(r => r.Username == username), uri))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await _controller.ChangePassword(request, uri);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        _mockUserService.Verify(x => x.ChangePassword(It.Is<AuthenticateRequest>(r => r.Username == username), uri), Times.Once);
    }

    #endregion
}