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
        }
    }
}
