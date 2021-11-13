using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ServiceModel.Syndication;
using System.Net;
using System.Xml;

namespace mp3scrApi
{
    public class Mp3scrApi
    {
        public Mp3scrApi()
        {
            enabled = true;
            url = string.Empty;
            urlPrefix = "=";
            destBase = string.Empty;
            destFolderName = string.Empty;
            existingFeedFolder = string.Empty;
            guidPrefix = string.Empty;
            mp3Filter = string.Empty;
            indirectFilter = string.Empty;
            indirect = false;
            channelTitle = string.Empty;
            channelNotes = string.Empty;
            sortDescending = true;
            retainOrphans = false;
            stripBaseName = false;
            prependRelative = string.Empty;
            refreshDays = 7;
            ftpPath = string.Empty;
            ftpUserName = string.Empty;
            ftpPassword = string.Empty;
            permissionRevoked = string.Empty;
            allowHttps = false;
            wraparound = false;
            scrapeExtension = ".mp3";
            maxWebRequests = 20;
        }

        /// <summary>
        /// The version of the API
        /// </summary>
        public string Ver
        {
            get
            {
                try
                {
                    return Assembly.GetExecutingAssembly().GetName().Version.ToString();
                }
                catch { return "0.0.0.0"; }
            }
        }

        // Private cache for Enabled
        private bool enabled = true;
        /// <summary>
        /// If true, process a scrape with this config setup
        /// </summary>
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        /// <summary>
        /// Set the Enabled property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void EnabledFromObj(object o)
        {
            enabled = false;
            if (o != null)
                bool.TryParse(o.ToString(), out enabled);
        }

        // Private cache for Url
        private string url = string.Empty;
        /// <summary>
        /// The fully qualified web address to scrape
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        /// <summary>
        /// Set the Url property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void UrlFromObj(object o)
        {
            url = (o == null) ? string.Empty : o.ToString();
        }

        // Private cache for UrlPrefix
        private string urlPrefix = "=";
        /// <summary>
        /// The string expected prior to each MP3 link, in the source markup
        /// </summary>
        public string UrlPrefix
        {
            get { return urlPrefix; }
            set { urlPrefix = value; }
        }
        /// <summary>
        /// Set the UrlPrefix property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void UrlPrefixFromObj(object o)
        {
            urlPrefix = (o == null) ? string.Empty : o.ToString();
        }

        // Private cache for DestBase
        private string destBase = string.Empty;
        /// <summary>
        /// The base name of the RSS file to be generated
        /// </summary>
        public string DestBase
        {
            get { return destBase; }
            set { destBase = value; }
        }
        /// <summary>
        /// Set the DestBase property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void DestBaseFromObj(object o)
        {
            destBase = (o == null) ? string.Empty : o.ToString();
        }

        // Private cache for DestFolderName
        private string destFolderName = string.Empty;
        /// <summary>
        /// The folder into which the generated RSS file will be saved
        /// </summary>
        public string DestFolderName
        {
            get { return destFolderName; }
            set { destFolderName = value; }
        }
        /// <summary>
        /// Set the DestFolderName property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void DestFolderNameFromObj(object o)
        {
            destFolderName = (o == null) ? string.Empty : o.ToString();
        }

        // Private cache for ExistingFeedFolder
        private string existingFeedFolder = string.Empty;
        /// <summary>
        /// The remote folder where the RSS file is hosted
        /// </summary>
        public string ExistingFeedFolder
        {
            get { return existingFeedFolder; }
            set { existingFeedFolder = value; }
        }
        /// <summary>
        /// Set the ExistingFeedFolder property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void ExistingFeedFolderFromObj(object o)
        {
            existingFeedFolder = (o == null) ? string.Empty : o.ToString();
        }

        // Private cache for GuidPrefix
        private string guidPrefix = string.Empty;
        /// <summary>
        /// A string to use inside the RSS item for this scraped feed
        /// </summary>
        public string GuidPrefix
        {
            get { return guidPrefix; }
            set { guidPrefix = value; }
        }
        /// <summary>
        /// Set the GuidPrefix property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void GuidPrefixFromObj(object o)
        {
            guidPrefix = (o == null) ? string.Empty : o.ToString();
        }

        // Private cache for Mp3Filter
        private string mp3Filter = string.Empty;
        /// <summary>
        /// Only save MP3s that contain this string. Precede with ! if the MP3 name should NOT contain the string.
        /// </summary>
        public string Mp3Filter
        {
            get { return mp3Filter; }
            set { mp3Filter = value; }
        }
        /// <summary>
        /// Set the Mp3Filter property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void Mp3FilterFromObj(object o)
        {
            mp3Filter = (o == null) ? string.Empty : o.ToString();
        }

        // Private cache for IndirectFilter
        private string indirectFilter = string.Empty;
        /// <summary>
        /// A filter for indirect links
        /// </summary>
        public string IndirectFilter
        {
            get { return indirectFilter; }
            set { indirectFilter = value; }
        }
        /// <summary>
        /// Set the IndirectFilter property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void IndirectFilterFromObj(object o)
        {
            indirectFilter = (o == null) ? string.Empty : o.ToString();
        }

        // Private cache for Indirect
        private bool indirect = false;
        /// <summary>
        /// False if the scraped page contains MP3 links, true if the scraped page has links to other pages containing MP3 links.
        /// </summary>
        public bool Indirect
        {
            get { return indirect; }
            set { indirect = value; }
        }
        /// <summary>
        /// Set the Indirect property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void IndirectFromObj(object o)
        {
            indirect = false;
            if (o != null)
                bool.TryParse(o.ToString(), out indirect);
        }

        // Private cache for ChannelTitle
        private string channelTitle = string.Empty;
        /// <summary>
        /// Channel title for the RSS file
        /// </summary>
        public string ChannelTitle
        {
            get { return channelTitle; }
            set { channelTitle = value; }
        }
        /// <summary>
        /// Set the ChannelTitle property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void ChannelTitleFromObj(object o)
        {
            channelTitle = (o == null) ? string.Empty : o.ToString();
        }

        // Private cache for ChannelNotes
        private string channelNotes = string.Empty;
        /// <summary>
        /// Notes, such as why this feed is being scraped
        /// </summary>
        public string ChannelNotes
        {
            get { return channelNotes; }
            set { channelNotes = value; }
        }
        /// <summary>
        /// Set the ChannelNotes property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void ChannelNotesFromObj(object o)
        {
            channelNotes = (o == null) ? string.Empty : o.ToString();
        }

        // Private cache for SortDescending
        private bool sortDescending = true;
        /// <summary>
        /// True if the MP3 links in the feed being scraped show the most recent feed at the top.
        /// </summary>
        public bool SortDescending
        {
            get { return sortDescending; }
            set { sortDescending = value; }
        }
        /// <summary>
        /// Set the SortDescending property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void SortDescendingFromObj(object o)
        {
            sortDescending = true;
            if (o != null)
                bool.TryParse(o.ToString(), out sortDescending);
        }

        // Private cache for RetainOrphans
        private bool retainOrphans = false;
        /// <summary>
        /// True if previously scraped links should be saved in a new RSS even if a new scrape doesn't contain the link.
        /// </summary>
        public bool RetainOrphans
        {
            get { return retainOrphans; }
            set { retainOrphans = value; }
        }
        /// <summary>
        /// Set the RetainOrphans property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void RetainOrphansFromObj(object o)
        {
            retainOrphans = false;
            if (o != null)
                bool.TryParse(o.ToString(), out retainOrphans);
        }

        // Private cache for StripBaseName
        private bool stripBaseName = false;
        /// <summary>
        /// Use the base name of scraped links to prepend them with something other than the original host name
        /// </summary>
        public bool StripBaseName
        {
            get { return stripBaseName; }
            set { stripBaseName = value; }
        }
        /// <summary>
        /// Set the StripBaseName property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void StripBaseNameFromObj(object o)
        {
            stripBaseName = false;
            if (o != null)
                bool.TryParse(o.ToString(), out stripBaseName);
        }

        // Private cache for PrependRelative
        private string prependRelative = string.Empty;
        /// <summary>
        /// Prepend base names with this host address
        /// </summary>
        public string PrependRelative
        {
            get { return prependRelative; }
            set { prependRelative = value; }
        }
        /// <summary>
        /// Set the PrependRelative property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void PrependRelativeFromObj(object o)
        {
            prependRelative = (o == null) ? string.Empty : o.ToString();
        }

        // Private cache for RefreshDays
        private int refreshDays = 7;
        /// <summary>
        /// Number of days to wait before scraping again
        /// </summary>
        public int RefreshDays
        {
            get { return refreshDays; }
            set { refreshDays = value; }
        }
        /// <summary>
        /// Set the RefreshDays property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void RefreshDaysFromObj(object o)
        {
            refreshDays = -1;
            if (o != null)
                int.TryParse(o.ToString(), out refreshDays);
        }

        // Private cache for FtpPath
        private string ftpPath = string.Empty;
        /// <summary>
        /// The root path to the FTP site where the RSS file will be uploaded
        /// </summary>
        public string FtpPath
        {
            get { return ftpPath; }
            set { ftpPath = value; }
        }
        /// Set the FtpPath property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void FtpPathFromObj(object o)
        {
            ftpPath = (o == null) ? string.Empty : o.ToString();
        }

        // Private cache for FtpUserName
        private string ftpUserName = string.Empty;
        /// <summary>
        /// User name for uploading to the FTP site
        /// </summary>
        public string FtpUserName
        {
            get { return ftpUserName; }
            set { ftpUserName = value; }
        }
        /// Set the FtpUserName property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void FtpUserNameFromObj(object o)
        {
            ftpUserName = (o == null) ? string.Empty : o.ToString();
        }

        // Private cache for FtpPassword
        private string ftpPassword = string.Empty;
        /// <summary>
        /// Password for uploading to the FTP site
        /// </summary>
        public string FtpPassword
        {
            get { return ftpPassword; }
            set { ftpPassword = value; }
        }
        /// Set the FtpPassword property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void FtpPasswordFromObj(object o)
        {
            ftpPassword = (o == null) ? string.Empty : o.ToString();
        }

        // Private cache for PermissionRevoked
        private string permissionRevoked = string.Empty;
        /// <summary>
        /// If non-empty, a date or information about why permission to scrape was revoked for a 3rd party site
        /// </summary>
        public string PermissionRevoked
        {
            get { return permissionRevoked; }
            set { permissionRevoked = value; }
        }
        /// Set the PermissionRevoked property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void PermissionRevokedFromObj(object o)
        {
            permissionRevoked = (o == null) ? string.Empty : o.ToString();
        }

        // Private cache for AllowHttps
        private bool allowHttps = false;
        /// <summary>
        /// If true, don't convert https links to http. https is invalid for RSS.
        /// </summary>
        public bool AllowHttps
        {
            get { return allowHttps; }
            set { allowHttps = value; }
        }
        /// <summary>
        /// Set the AllowHttps property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void AllowHttpsFromObj(object o)
        {
            allowHttps = false;
            if (o != null)
                bool.TryParse(o.ToString(), out allowHttps);
        }

        // Private cache for Wraparound
        private bool wraparound = false;
        /// <summary>
        /// True if an algorithm should be used to cycle through the links in the remote feed and save a different link in the RSS each time
        /// </summary>
        public bool Wraparound
        {
            get { return wraparound; }
            set { wraparound = value; }
        }
        /// <summary>
        /// Set the Wraparound property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void WraparoundFromObj(object o)
        {
            wraparound = false;
            if (o != null)
                bool.TryParse(o.ToString(), out wraparound);
        }

        // Private cache for ScrapeExtension
        private string scrapeExtension = ".mp3";
        /// <summary>
        /// The extension of the links to scrape
        /// </summary>
        public string ScrapeExtension
        {
            get { return scrapeExtension; }
            set { scrapeExtension = value; }
        }
        /// <summary>
        /// Set the ScrapeExtension property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void ScrapeExtensionFromObj(object o)
        {
            scrapeExtension = (o == null) ? string.Empty : o.ToString();
        }

        // Private cache for MaxWebRequests
        private int maxWebRequests = 20;
        /// <summary>
        /// Maximum number of items to investigate via a web request, for eventual entry into RSS.
        /// </summary>
        public int MaxWebRequests
        {
            get { return maxWebRequests; }
            set { maxWebRequests = value; }
        }
        /// <summary>
        /// Set the maxWebRequests property from an object, such as a config file value
        /// </summary>
        /// <param name="o"></param>
        public void MaxWebRequestsFromObj(object o)
        {
            maxWebRequests = -1;
            if (o != null)
                int.TryParse(o.ToString(), out maxWebRequests);
        }

        /// <summary>
        /// Get the markup of a URL from the config file.
        /// </summary>
        /// <param name="fullUrl">The URL</param>
        /// <returns>The HTML markup</returns>
        public string Mp3PageMarkup(string fullUrl)
        {
            string htmlDoc = string.Empty;
            try
            {
                htmlDoc = VerifyAndLoadString(fullUrl);
            }
            catch (Exception ex)
            {
                throw new Exception("Mp3PageMarkup for " + fullUrl + ": " + ex.Message);
            }
            return htmlDoc;
        }

        /// <summary>
        /// Test a URL for security-related issues (throws ArgumentException if bad)
        /// then return the HTML markup for that URL (rethrows exceptions).
        /// </summary>
        /// <param name="url">The full URL, not relative.</param>
        /// <returns>The string markup.</returns>
        private string VerifyAndLoadString(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                {
                    throw new ArgumentException("Null or empty URLs not allowed.");
                }
                if (url.Length > 256)
                {
                    throw new ArgumentException("URLs longer than 256 chars not allowed.");
                }
                if ((url.IndexOf("http://") < 0) && (url.IndexOf("https://") < 0))
                {
                    throw new ArgumentException("Protocols other than http or https not allowed.");
                }
                if (url.IndexOf("..") >= 0)
                {
                    throw new ArgumentException("Relative URLs not allowed.");
                }

                System.Net.HttpWebRequest request =
                    (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                request.UserAgent = "gocek.org"; // UserAgent is null by default, some sites reject that, especially if https.
                request.Timeout = 10000;
                string d = string.Empty;
                using (System.IO.Stream s = request.GetResponse().GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                    {
                        d = sr.ReadToEnd();
                    }
                }
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception("VerifyAndLoadString for " + url + ": " + ex.Message);
            }
        }

        /// <summary>
        /// Scrape a web page for MP3 file addresses
        /// </summary>
        /// <param name="markup">The full markup to scrape</param>
        /// <param name="filterVal">A URL must contain this to be considered</param>
        /// <param name="prependRel">A host address to use to prepend relative addresses</param>
        /// <param name="stripBaseNameVal">Pull the base name out of the URL, typically to prepend it with something other than the original host name</param>
        /// <param name="urlPrefixVal">Look backward before the .mp3 for this leading string. Usually, this is an equals sign,
        /// since usually looking for src="http etc." But sometimes we want to scrape JSON content or other non-HTML markup.</param>
        /// <returns>A list of MP3 URLs</returns>
        public List<string> Mp3PageScrape(string markup, string filterVal, string prependRel, bool stripBaseNameVal, string urlPrefixVal)
        {
            // Look for MP3 links in the page source.
            // Not all are full addresses with http, so look for an equals sign followed by .MP3.
            // You might see a string like     =,,,,=/sounds/sound.mp3
            // And there might be several occurrences wrapped in junk.
            // I had trouble using regular expressions to skip over the first = to get to the real address.
            // So, here's the algorithm:
            // Look forward to find .mp3
            // Look backwards to find the previous occurrence of the string defined in urlPrefixVal (usually "=")
            // Make sure everything in between is letter digit % - _ : /
            // If it's valid, save it.
            // Start again after the .mp3

            List<string> savedUrls = new List<string>();

            int markupDex = 0;
            int dotmp3Dex = 0;
            int equalsDex = 0;
            string curMp3Addr = string.Empty;

            bool isNoFilterVal = string.IsNullOrEmpty(filterVal); // There is no filter (include all valid addresses)
            bool isPosFilterVal = !isNoFilterVal && !filterVal.StartsWith("!"); // Include addresses with the filter
            bool isNegFilterVal = !isNoFilterVal && filterVal.StartsWith("!"); // Exclude addresses with the filter
            string useFilterVal = filterVal;
            if (isNegFilterVal)
                useFilterVal = useFilterVal.Substring(1);

            try
            {
                // Look forward to find .mp3
                dotmp3Dex = markup.IndexOf(this.ScrapeExtension, markupDex, StringComparison.InvariantCultureIgnoreCase);
                while (dotmp3Dex > -1)
                {
                    // Look backward to find = or whatever the prefix is
                    equalsDex = markup.LastIndexOf(urlPrefixVal, dotmp3Dex, StringComparison.InvariantCultureIgnoreCase);
                    if ((equalsDex > -1) && (dotmp3Dex > equalsDex))
                    {
                        // Skip the prefix
                        equalsDex += urlPrefixVal.Length;
                        if ((markup[equalsDex] == '\'') || (markup[equalsDex] == '\"'))
                        {
                            // The first char after the = is a quote. Skip it.
                            equalsDex++;
                        }
                        if (markup.Substring(equalsDex, 6) == "&quot;")
                        {
                            // The first char after the = is &quot;. Skip it.
                            equalsDex += 6;
                        }
                        // Grab the address from = to the end of .mp3
                        curMp3Addr = markup.Substring(equalsDex, (dotmp3Dex + 4) - equalsDex).Trim();
                        // Validate the characters in between
                        string resultUrl = string.Empty;
                        if (
                            IsValidUrl(curMp3Addr, prependRel, stripBaseNameVal, out resultUrl) &&
                            (
                            (isNoFilterVal || (isPosFilterVal && (resultUrl.IndexOf(useFilterVal, StringComparison.InvariantCultureIgnoreCase) >= 0))) ||
                            (isNoFilterVal || (isNegFilterVal && (resultUrl.IndexOf(useFilterVal, StringComparison.InvariantCultureIgnoreCase) < 0)))
                            )
                            )
                        {
                            // The URL is valid and contains the filter val if there is a filter val
                            savedUrls.Add(resultUrl.Trim());
                        }
                    }
                    // No = before this .mp3. Ignore this .mp3

                    // Move the markup pointer past the .mp3
                    markupDex = dotmp3Dex + 1;
                    // Find the next .mp3
                    dotmp3Dex = markup.IndexOf(this.ScrapeExtension, markupDex, StringComparison.InvariantCultureIgnoreCase);
                    // Return to the top and start again
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Mp3PageScrape: " + ex.Message);
            }
            return savedUrls;
        }

        /// <summary>
        /// Scrape the page for URLs (to later be scraped for MP3s)
        /// </summary>
        /// <param name="markup">The full markup to scrape</param>
        /// <param name="indirectFilterVal">A URL must contain this to be considered</param>
        /// <returns>A list of addresses</returns>
        public List<string> IndirectPageScrape(string markup, string indirectFilterVal)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ensure a string looks like a URL.
        /// </summary>
        /// <param name="url">The string to test</param>
        /// <param name="prependRel">Prepend the URL with this string</param>
        /// <param name="stripBaseNameVal">Pull the base name out of the URL, typically to prepend it with something other than the original host name</param>
        /// <param name="resultUrl">The incoming URL if valid, or the decoded URL if that is valid,
        /// or the empty string if invalid.</param>
        /// <returns>True if it looks like a URL</returns>
        private bool IsValidUrl(string url, string prependRel, bool stripBaseNameVal, out string resultUrl)
        {
            resultUrl = string.Empty;
            Uri testUri = null;

            if (!string.IsNullOrEmpty(prependRel) && stripBaseNameVal)
            {
                // Even if a valid URL was found, the stripBaseName attribute says to strip out the base file name.
                // The URL ends with ".mp3" (that's why we're here). Look backwards from the end until finding a char
                // that's not a filename char.
                int baseIndex = url.Length - 1;
                while ((baseIndex > 0) &&
                    (char.IsLetterOrDigit(url[baseIndex]) ||
                    (url[baseIndex] == '-') ||
                    (url[baseIndex] == '_') ||
                    (url[baseIndex] == '+') ||
                    (url[baseIndex] == '.') ||
                    (url[baseIndex] == '%')))
                {
                    baseIndex--;
                }
                url = url.Substring(baseIndex + 1);
            }

            // If as relative URL, prepend it now.
            if (!string.IsNullOrEmpty(prependRel) && !url.StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
            {
                url = prependRel + url;
            }

            // Abort if any junk
            if (url.Contains('<') || url.Contains('>') || url.Contains("&gt;") || url.Contains("&lt;"))
                return false;

            // Create  URI from the URL
            bool ret = Uri.TryCreate(url,
                (url.StartsWith("http", StringComparison.InvariantCultureIgnoreCase) ? UriKind.Absolute : UriKind.Relative),
                out testUri);
            if (ret && testUri.IsAbsoluteUri)
            {
                // The raw URL is valid and absolute (starts with http)
                resultUrl = url;
                ret = true;
            }
            else if (!ret && url.StartsWith("http", StringComparison.InvariantCultureIgnoreCase) && url.Contains('%'))
            {
                // The URL is invalid but it is absolute and contains %
                // Try decoding the url and see what happens.
                ret = Uri.TryCreate(System.Web.HttpUtility.UrlDecode(url),
                    UriKind.Absolute,
                    out testUri);
                if (ret)
                {
                    // The decoded URL is valid and absolute
                    resultUrl = System.Web.HttpUtility.UrlDecode(url);
                    ret = true;
                }
            }
            else
            {
                ret = false;
                resultUrl = string.Empty;
            }
            return ret;
        }

        /// <summary>
        /// Generate an RSS object from a URL
        /// </summary>
        /// <param name="existingRssUrl">The URL</param>
        public SyndicationFeed RssFromUrl(string existingRssUrl)
        {
            SyndicationFeed ret = null;
            try
            {
                using (System.Xml.XmlReader rssReader = System.Xml.XmlReader.Create(existingRssUrl))
                {
                    ret = SyndicationFeed.Load(rssReader);
                }
            }
            catch (Exception ex)
            {
                // If existingRssUrl doesn't exist, XmlReader.Create will throw.
                // What if it exists but it isn't a syndication feed?
                throw new Exception("RssFromUrl: " + existingRssUrl + " probably does not exist or not an RSS file: " + ex.Message);
            }
            return ret;
        }

        /// <summary>
        /// Create a SyndicationItem for an MP3
        /// </summary>
        /// <param name="mp3Addr">The full MP3 link</param>
        /// <param name="itemDescPrefix">From the config file</param>
        /// <param name="guidPrefix">From the config file</param>
        /// <param name="homeUrl">From the config file</param>
        /// <param name="pubDate">The number</param>
        /// <returns>The item or an exception with info on what went wrong when trying to get the file info or null if couldn't get the info</returns>
        public SyndicationItem ItemForMp3(string mp3Addr, string itemDescPrefix, string guidPrefix,
            string homeUrl, bool allowHttps)
        {
            // First make sure the link points to a real file
            long mp3Size = 0L;
            DateTime mp3Mod = DateTime.UtcNow;
            bool exists = false;
            try
            {
                exists = Mp3Info(mp3Addr, out mp3Size, out mp3Mod);
            }
            catch (WebException)
            {
                exists = false; // Might be info in this exception and its inner exception
                throw;
            }
            catch (Exception)
            {
                exists = false;
                throw;
            }
            if (!exists)
                return null; // Retried a couple times but could not get the file info

            // The W3C RSS validator reports a failure when an enclosure address uses https. After the MP3 is proved to exist (just above),
            // convert https to http if necessary. As far as I can tell, the resulting http link always works.
            // ALSO, https links don't work with my internet radio.
            if (!allowHttps && mp3Addr.ToLower().StartsWith("https"))
            {
                mp3Addr = "http" + mp3Addr.Substring(5);
            }

            Uri myUri = new Uri(mp3Addr);
            string baseMp3Name = myUri.Segments[myUri.Segments.Length - 1]; // The MP3 name including the extension
            string mp3Ext = System.IO.Path.GetExtension(myUri.LocalPath); // The extension including the period
            baseMp3Name = baseMp3Name.Substring(0, baseMp3Name.Length - mp3Ext.Length); // The name without the extension

            SyndicationItem si = new SyndicationItem();
            si.Id = guidPrefix + baseMp3Name; // guid

            SyndicationLink sl0 =
                new SyndicationLink(new Uri(homeUrl), "alternate", itemDescPrefix + "-" + baseMp3Name, null, 0);
            SyndicationLink sl1 = null;
            sl1 =
                new SyndicationLink(new Uri(mp3Addr), "enclosure", itemDescPrefix + "-" + baseMp3Name, "audio/mpeg", mp3Size);

            si.Links.Add(sl0);
            si.Links.Add(sl1);

            si.Summary = new TextSyndicationContent(itemDescPrefix + "-" + baseMp3Name, TextSyndicationContentKind.Plaintext);
            si.Title = new TextSyndicationContent(itemDescPrefix + "-" + baseMp3Name, TextSyndicationContentKind.Plaintext);

            si.PublishDate = new DateTimeOffset(mp3Mod, new TimeSpan(0));
            si.LastUpdatedTime = new DateTimeOffset(mp3Mod, new TimeSpan(0));

            return si;
        }

        /// <summary>
        /// Get info about a remote MP3
        /// </summary>
        /// <param name="mp3Url">The link to the MP3</param>
        /// <param name="fileBytes">The size of the remote MP3 file in bytes</param>
        /// <param name="fileLastMod">The modification data of the remote MP3 file</param>
        /// <returns>True if the file exists</returns>
        private bool Mp3Info(string mp3Url, out long fileBytes, out DateTime fileLastMod)
        {
            fileBytes = -2L;
            fileLastMod = DateTime.UtcNow;
            // Sometimes after poking at a server with lots of MP3 files,
            // the server will return an error. If this throws, retry a few times.
            while (fileBytes < 0)
            {
                try
                {
                    System.Net.HttpWebRequest req = System.Net.HttpWebRequest.CreateHttp(mp3Url);
                    // Some sites say to set req.Method = "POST", but this hasn't seemed to be necessary.
                    // UserAgent seems to be important for some sites.
                    req.UserAgent = "gocek.org";
                    using (System.Net.HttpWebResponse resp = (System.Net.HttpWebResponse)req.GetResponse())
                    {
                        if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            fileBytes = resp.ContentLength;
                            fileLastMod = resp.LastModified.ToUniversalTime();
                        }
                    }
                }
                catch (WebException webEx)
                {
                    if (fileBytes == -2L)
                    {
                        // Retry once, maybe we'll get lucky
                        fileBytes++;
                        System.Threading.Thread.Sleep(7000);
                    }
                    else
                    {
                        // Second WebException - throw back with the information
                        WebResponse webResponse = webEx.Response;
                        using (System.IO.Stream respStr = webResponse.GetResponseStream())
                        {
                            if (respStr == null)
                            {
                                throw;
                            }
                            using (System.IO.StreamReader reader = new System.IO.StreamReader(respStr))
                            {
                                if (reader == null)
                                {
                                    throw;
                                }
                                string text = reader.ReadToEnd();
                                throw new WebException(text, webEx);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    fileBytes++;
                    // Probably should sleep something like 120000.
                    // 503 errors, service unavailable, usually refer to a busy or otherwise underpowered server.
                    if (ex.Message.Contains("503"))
                        System.Threading.Thread.Sleep(7000);
                }
            }
            return (fileBytes > 0);
        }

        /// <summary>
        /// Upload localName to the FTP site.
        /// </summary>
        /// <param name="localName">The full path to the file to upload on the local device.</param>
        /// <param name="destBaseVal">The base file name.</param>
        /// <param name="ftpPathVal">FTP path</param>
        /// <param name="ftpUserNameVal">FTP user</param>
        /// <param name="ftpPasswordVal">FTP password</param>
        public void FtpUpload(string localName, string destBaseVal, string ftpPathVal, string ftpUserNameVal, string ftpPasswordVal)
        {
            try
            {
                System.Net.FtpWebRequest request = null;

                request = WebRequest.Create(new Uri(ftpPathVal + destBaseVal)) as FtpWebRequest;
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UseBinary = false;
                request.UsePassive = false;
                request.KeepAlive = false;
                request.Credentials = new NetworkCredential(ftpUserNameVal, ftpPasswordVal);
                request.ConnectionGroupName = "group";

                using (System.IO.FileStream fs = System.IO.File.OpenRead(localName))
                {
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();
                    System.IO.Stream requestStream = request.GetRequestStream();
                    requestStream.Write(buffer, 0, buffer.Length);
                    requestStream.Flush();
                    requestStream.Close();
                }
                // uploaded successfully
            }
            catch (Exception ex)
            {
                throw new Exception("FtpUpload: " + ftpPathVal + destBaseVal + " upload failed: " + ex.Message);
            }
        }

        /// <summary>
        /// Generate a feed object and add any provided items
        /// </summary>
        /// <param name="channelTitleVal">Channel title</param>
        /// <param name="feedUrl">Channel URL</param>
        /// <param name="lang">Language ID</param>
        /// <param name="permissionRevokedVal">A string describing the revocation of permission to publicly post the generated RSS</param>
        /// <param name="itemsToAdd">Newly scraped items to add to the feed</param>
        /// <param name="itemsToKeep">Items from an old feed to keep in the new feed</param>
        /// <param name="genVal">A string for the channel generator property</param>
        /// <param name="channelNotesVal">Channel notes, such as why the provider site is being scraped.</param>
        /// <returns>The feed object</returns>
        public SyndicationFeed GenerateFeed(string channelTitleVal, string feedUrl, string lang, string permissionRevokedVal,
            List<SyndicationItem> itemsToAdd, List<SyndicationItem> itemsToKeep, string genVal, string channelNotesVal)
        {
            SyndicationFeed sf = null;
            try
            {
                sf = new SyndicationFeed();
                sf.Title = new TextSyndicationContent(channelTitleVal, TextSyndicationContentKind.Plaintext);
                SyndicationLink sl0 =
                    new SyndicationLink(new Uri(feedUrl), "alternate", channelTitleVal, null, 0);
                sf.Links.Add(sl0);
                sf.Description = new TextSyndicationContent(channelTitleVal, TextSyndicationContentKind.Plaintext);
                sf.Language = lang;

                // Display permissionRevoked as an attribute on the root channel node.
                sf.AttributeExtensions.Add(new XmlQualifiedName("permissionRevoked", ""), permissionRevokedVal);
                // Display channelNotes as an attribute on the root channel node.
                sf.AttributeExtensions.Add(new XmlQualifiedName("notes", ""), channelNotesVal);

                sf.ImageUrl = new Uri("http://www.gocek.org/podcasts/mp3scraper-logo.jpg");

                // Note that mp3scraper generated this feed
                sf.Generator = genVal;

                // Add the items being retained to the end of the items containing the scraped MP3 links
                foreach (SyndicationItem si in itemsToKeep)
                    itemsToAdd.Add(si);
                // Set the feed items
                sf.Items = itemsToAdd;

                return sf;
            }
            catch (Exception ex)
            {
                throw new Exception("GenerateFeed: " + channelTitleVal + " failed: " + ex.Message);
            }
        }

        /// <summary>
        /// Wraparound processing.
        /// Here is the algorithm for selecting a feed item from a non-changing source, such as a
        /// defunct podcast or a directory of MP3 files.
        /// When processing a defunct source, generate a feed with only one item. You'll get a new item next period.
        /// </summary>
        /// <param name="sf">The sydication feed from which to select an item</param>
        /// <returns>A list with one item. That is the item to be saved into the RSS feed.</returns>
        public List<SyndicationItem> WrapAroundItems(SyndicationFeed sf)
        {
            DateTimeOffset forcedLastTimestamp = new DateTimeOffset(new DateTime(2016, 12, 31, 0, 0, 0), new TimeSpan(0));

            // Set the wraparound period according to the number of items in the source feed.
            double wrapDays = 7D; // skip to the next item every seventh day
            if (sf.Items.Count() > 700)
                wrapDays = 1D; // skip to the next item every day
            else if (sf.Items.Count() > 600)
                wrapDays = 2D; // etc.
            else if (sf.Items.Count() > 500)
                wrapDays = 3D;
            else if (sf.Items.Count() > 400)
                wrapDays = 4D;
            else if (sf.Items.Count() > 300)
                wrapDays = 5D;
            else if (sf.Items.Count() > 200)
                wrapDays = 6D;
            else
                wrapDays = 7D;

            try
            {
                if (sf.Items.Any())
                {
                    // There is at least one item, default to returning the last one (the latest one).
                    int selectIndex = sf.Items.Count() - 1;
                    // Get the date of the latest item
                    DateTimeOffset lastItemByModDt = (from feedItem in sf.Items
                                                       select feedItem.LastUpdatedTime).Max();

                    // Determine if an item has recenly been added to the feed
                    if (((DateTime.Now - lastItemByModDt.LocalDateTime).Days >= 2) &&
                        ((DateTime.Now - lastItemByModDt.LocalDateTime).Days <= 30) &&
                        (sf.Items.ElementAt(sf.Items.Count() - 1).LastUpdatedTime == lastItemByModDt))
                    {
                        // The most recent item is between 2 and 30 days old and the LastUpdatedTime of the last item in the list is the latest LastUpdatedTime.
                        // The source published a new item. Use this instead of the wraparound algorithm.
                        selectIndex = sf.Items.Count() - 1;
                    }
                    else
                    {
                        // Most MP3 files in most feeds will have a reasonable LastUpdatedTime. The clause above verifies that by considering only files at
                        // least two days old. But sometimes, LastUpdatedTime is junk, and may appear as the current date-time. So, aside from new items
                        // located above, never assume LastUpdatedTime is valid.  Assume the list of items is in ascending date-time order.
                        // Force a timestamp because if all the items have the same LastUpdatedTime, the same item will be selected every time.
                        // Start at 12/31/2016 (forcedLastTimestamp from above).
                        for (int iii = sf.Items.Count() - 1; iii >= 0; iii--)
                        {
                            // Set the current item's LastUpdatedTime to the current value of forcedLastTimestamp
                            sf.Items.ElementAt(iii).LastUpdatedTime = forcedLastTimestamp;
                            // Move backwards in time some number of days
                            forcedLastTimestamp = (forcedLastTimestamp - new TimeSpan(Convert.ToInt32(wrapDays), 0, 0, 0));
                        }

                        // Now the wraparound algorithm:
                        // Get the date of the earliest item. The point of forcing the timestamps is that for a defunct feed, the number
                        // of items will always be the same and firstItemByModDt will always be the same as long as wrapDays isn't changed
                        // and the initial value of forcedLastTimestamp isn't changed. As UtcNow progresses, selectIndex will progress.
                        DateTimeOffset firstItemByModDt = (from feedItem in sf.Items
                                                           select feedItem.LastUpdatedTime).Min();
                        // Determine the index of the item that should be chosen based on a wraparound time period.
                        // Start with the number of periods of wrapDays days, from the oldest item to today.
                        int periodsSinceFirst = Convert.ToInt32((DateTime.UtcNow - firstItemByModDt).TotalDays / wrapDays);
                        // Let's say the first item was Jan 1 2000, and today is Mar 1 2000.
                        // And let's say there are five items in the feed, indices 0-4.
                        // The number of days is 31 + 29 + 1 = 61, and periodsSinceFirst = 8 (since wrapDays is 7 for a feed with 5 items).
                        // selectIndex = 8 % 5 = 3, i.e., the item we want to keep in the generated feed is items[3], the 4th item.
                        // 100 items is 1.9 years worth of weekly items. 401 items is 4.4 years worth of 4-day items.
                        // You'll never cycle through thousands of items unless you're podcatching multiple times per day.
                        selectIndex = periodsSinceFirst % sf.Items.Count();
                    }

                    SyndicationItem siKeep = sf.Items.ElementAt(selectIndex);
                    // Pretend it was just published today
                    siKeep.LastUpdatedTime = new DateTimeOffset(DateTime.UtcNow, new TimeSpan(0));
                    siKeep.PublishDate = new DateTimeOffset(DateTime.UtcNow, new TimeSpan(0));
                    // When processing a defunct source, generate a feed with only one item. You'll get a new item next period.
                    return new List<SyndicationItem>() { siKeep };
                }
            }
            catch
            {
                // Return null. The caller will presumably continue as if defunct feed processing did not occur.
            }
            return null;
        }
    }
}
