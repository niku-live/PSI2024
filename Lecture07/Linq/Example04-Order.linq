<Query Kind="Statements" />

var wordList = "The quick brown fox jumps over the lazy dog".Split();
wordList.Dump();

var words =
	from word in wordList
	where word.Length > 3
	orderby word.ToUpper()
	orderby word.Length
	select word;	
words.Dump();


var words2 = 
  wordList.
  Where(word => word.Length > 3).
  OrderBy(word => word.ToUpper()).
  OrderBy(word => word.Length).
  Select(word => word);
words2.Dump();

var words3 =
	from word in wordList
	where word.Length > 3
	orderby word.ToUpper(), word.Length
	select word;	
words3.Dump();

var words4 = 
  wordList.
  Where(word => word.Length > 3).
  OrderBy(word => word.ToUpper()).
  ThenBy(word => word.Length).
  Select(word => word);
words4.Dump();

var words5 =
	from word in wordList
	where word.Length > 3
	orderby word.ToUpper() descending, word.Length
	select word;	
words5.Dump();

var words6 = 
  wordList.
  Where(word => word.Length > 3).
  OrderByDescending(word => word.ToUpper()).
  ThenBy(word => word.Length).
  Select(word => word);
words6.Dump();