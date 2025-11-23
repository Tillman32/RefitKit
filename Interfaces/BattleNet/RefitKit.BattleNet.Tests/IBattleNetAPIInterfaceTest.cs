using Refit;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace RefitKit.BattleNet.Tests
{
    public class IBattleNetAPIInterfaceTest
    {
        [Fact(DisplayName = "Interface has expected methods")]
        public void InterfaceHasExpectedMethods()
        {
            var methods = typeof(IBattleNetAPI).GetMethods();
            
            Assert.NotEmpty(methods);
            Assert.Contains(methods, m => m.Name == "AuthorizeUser");
            Assert.Contains(methods, m => m.Name == "GetAccessToken");
            Assert.Contains(methods, m => m.Name == "AuthorizeApplication");
            Assert.Contains(methods, m => m.Name == "ValidateToken");
        }

        [Fact(DisplayName = "AuthorizeUser method has correct Refit attributes")]
        public void AuthorizeUserMethodHasCorrectAttributes()
        {
            var method = typeof(IBattleNetAPI).GetMethod("AuthorizeUser");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("oauth/authorize", getAttr!.Path);
        }

        [Fact(DisplayName = "GetAccessToken method has correct Refit attributes")]
        public void GetAccessTokenMethodHasCorrectAttributes()
        {
            var method = typeof(IBattleNetAPI).GetMethod("GetAccessToken");
            Assert.NotNull(method);
            
            var postAttr = method!.GetCustomAttribute<PostAttribute>();
            Assert.NotNull(postAttr);
            Assert.Contains("oauth/token", postAttr!.Path);
        }

        [Fact(DisplayName = "AuthorizeApplication method has correct Refit attributes")]
        public void AuthorizeApplicationMethodHasCorrectAttributes()
        {
            var method = typeof(IBattleNetAPI).GetMethod("AuthorizeApplication");
            Assert.NotNull(method);
            
            var postAttr = method!.GetCustomAttribute<PostAttribute>();
            Assert.NotNull(postAttr);
            Assert.Contains("oauth/token", postAttr!.Path);
            
            var headersAttr = method.GetCustomAttribute<HeadersAttribute>();
            Assert.NotNull(headersAttr);
        }

        [Fact(DisplayName = "ValidateToken method has correct Refit attributes")]
        public void ValidateTokenMethodHasCorrectAttributes()
        {
            var method = typeof(IBattleNetAPI).GetMethod("ValidateToken");
            Assert.NotNull(method);
            
            var postAttr = method!.GetCustomAttribute<PostAttribute>();
            Assert.NotNull(postAttr);
            Assert.Contains("oauth/check_token", postAttr!.Path);
        }

        [Fact(DisplayName = "All methods return Task")]
        public void AllMethodsReturnTask()
        {
            var methods = typeof(IBattleNetAPI).GetMethods();
            
            foreach (var method in methods)
            {
                Assert.True(method.ReturnType.IsGenericType);
                Assert.Equal(typeof(Task<>), method.ReturnType.GetGenericTypeDefinition());
            }
        }

        [Fact(DisplayName = "Constants class has BNetAPIBaseURL")]
        public void ConstantsHasBNetAPIBaseURL()
        {
            Assert.NotNull(Constants.BNetAPIBaseURL);
            Assert.NotEmpty(Constants.BNetAPIBaseURL);
            Assert.StartsWith("https://", Constants.BNetAPIBaseURL);
        }
    }
}
