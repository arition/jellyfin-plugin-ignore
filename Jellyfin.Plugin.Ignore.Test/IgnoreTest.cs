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

        [Fact]
        public void TestReal()
        {
            var ignore = new global::Ignore.Ignore();
            ignore.Add("\\[VCB-Studio\\] Sword Art Online -Ordinal Scale- \\[Ma10p_2160p_SDR\\]\\[x265_flac\\].mkv");

            Assert.True(ignore.IsIgnored("/_done/movie/[VCB-Studio] Sword Art Online -Ordinal Scale- [Ma10p_2160p_SDR][x265_flac].mkv"));
            Assert.True(!ignore.IsIgnored("/_done/movie/[VCB-Studio] Sword Art Online -Ordinal Scale- [Ma10p_2160p_DoVi_P8.1][x265_flac].mkv"));
        }
    }
}
