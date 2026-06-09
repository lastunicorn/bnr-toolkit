namespace DustInTheWind.Bnr.Toolkit.ExchangeRates;

internal class ExchangeRatesOnlineStream : Stream
{
	private readonly Uri uri;

	private HttpClient httpClient;
	private HttpResponseMessage httpResponseMessage;
	private Stream stream;

	public override bool CanRead => stream.CanRead;

	public override bool CanSeek => stream.CanSeek;

	public override bool CanWrite => stream.CanWrite;

	public override long Length => stream.Length;

	public override long Position
	{
		get => stream.Position;
		set => stream.Position = value;
	}

	public ExchangeRatesOnlineStream(Uri uri)
	{
		this.uri = uri ?? throw new ArgumentNullException(nameof(uri));
	}

	public async Task Open(CancellationToken cancellationToken)
	{
		httpClient?.Dispose();
		httpResponseMessage?.Dispose();
		if (stream != null)
			await stream.DisposeAsync();

		
		httpClient = new HttpClient();
		httpResponseMessage = await httpClient.GetAsync(uri, cancellationToken);

		if (!httpResponseMessage.IsSuccessStatusCode)
			throw new Exception($"Error reading exchange rates from BNR website. URL: {uri}");

		stream = await httpResponseMessage.Content.ReadAsStreamAsync(cancellationToken);
	}

	public override void Flush()
	{
		stream?.Flush();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		return stream.Read(buffer, offset, count);
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		return stream.Seek(offset, origin);
	}

	public override void SetLength(long value)
	{
		stream.SetLength(value);
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		stream.Write(buffer, offset, count);
	}

	protected override void Dispose(bool disposing)
	{
		httpClient?.Dispose();
		httpResponseMessage?.Dispose();
		stream?.Dispose();

		base.Dispose(disposing);
	}
}