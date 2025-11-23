using System;
using Xunit;

namespace RefitKit.Shared.Tests
{
    public class HelpersTest
    {
        [Fact(DisplayName = "Base64EncodeCredentials encodes valid credentials")]
        public void Base64EncodeCredentialsEncodesValidCredentials()
        {
            var username = "testuser";
            var password = "testpass";
            
            var result = Helpers.Base64EncodeCredentials(username, password);
            
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            
            // Decode to verify
            var decoded = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(result));
            Assert.Equal($"{username}:{password}", decoded);
        }

        [Fact(DisplayName = "Base64EncodeCredentials throws on null username")]
        public void Base64EncodeCredentialsThrowsOnNullUsername()
        {
            Assert.Throws<ArgumentException>(() => 
                Helpers.Base64EncodeCredentials(null!, "password"));
        }

        [Fact(DisplayName = "Base64EncodeCredentials throws on null password")]
        public void Base64EncodeCredentialsThrowsOnNullPassword()
        {
            Assert.Throws<ArgumentException>(() => 
                Helpers.Base64EncodeCredentials("username", null!));
        }

        [Fact(DisplayName = "Base64EncodeCredentials throws on empty username")]
        public void Base64EncodeCredentialsThrowsOnEmptyUsername()
        {
            Assert.Throws<ArgumentException>(() => 
                Helpers.Base64EncodeCredentials("", "password"));
        }

        [Fact(DisplayName = "Base64EncodeCredentials throws on empty password")]
        public void Base64EncodeCredentialsThrowsOnEmptyPassword()
        {
            Assert.Throws<ArgumentException>(() => 
                Helpers.Base64EncodeCredentials("username", ""));
        }

        [Fact(DisplayName = "Base64EncodeCredentials handles special characters")]
        public void Base64EncodeCredentialsHandlesSpecialCharacters()
        {
            var username = "user@example.com";
            var password = "p@$$w0rd!";
            
            var result = Helpers.Base64EncodeCredentials(username, password);
            
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            
            // Decode to verify special characters are preserved
            var decoded = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(result));
            Assert.Equal($"{username}:{password}", decoded);
        }
    }
}
