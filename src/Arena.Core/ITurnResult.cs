namespace Arena.Core
{
	public interface ITurnResult
	{
		bool IsSuccess { get; }

		string ErrorMessage { get; }

		ITurn Turn { get; }
	}
}