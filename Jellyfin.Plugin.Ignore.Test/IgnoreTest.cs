namespace Jellyfin.Plugin.Ignore.Test
{
    public class IgnoreTest
    {
        [Fact]
        public void Test()
        {
            var ignore = new global::Ignore.Ignore();
            ignore.Add("SPs");
            Assert.True(ignore.IsIgnored("f:/cd/sps/ffffff.mkv"));
            Assert.True(ignore.IsIgnored("cd/sps/ffffff.mkv"));
            Assert.True(ignore.IsIgnored("/cd/sps/ffffff.mkv"));
        }

        [Fact]
        public void TestNegatePattern()
        {
            var ignore = new global::Ignore.Ignore();
            ignore.Add("SPs");
            ignore.Add("!thebestshot.mkv");
            Assert.True(ignore.IsIgnored("f:/cd/sps/ffffff.mkv"));
            Assert.True(ignore.IsIgnored("cd/sps/ffffff.mkv"));
            Assert.True(ignore.IsIgnored("/cd/sps/ffffff.mkv"));
            Assert.True(!ignore.IsIgnored("f:/cd/sps/thebestshot.mkv"));
            Assert.True(!ignore.IsIgnored("cd/sps/thebestshot.mkv"));
            Assert.True(!ignore.IsIgnored("/cd/sps/thebestshot.mkv"));
        }
    }
}
