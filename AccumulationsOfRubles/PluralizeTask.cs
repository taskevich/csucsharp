namespace Pluralize;

public static class PluralizeTask
{
	public static string PluralizeRubles(int count)
	{
		return (count % 100 >= 11 && count % 100 <= 14) ? "рублей" :
			(count % 10 == 1) ? "рубль" :
			(count % 10 >= 2 && count % 10 <= 4) ? "рубля" :
			"рублей";
	}
}