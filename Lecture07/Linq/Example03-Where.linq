<Query Kind="Statements" />

var wordList = "The quick brown fox jumps over the lazy dog".Split();
wordList.Dump();

var words =
	from word in wordList
	where word.Length > 3
	orderby word.ToUpper()
	select word;	
words.Dump();

var words2 = 
  wordList.
  Where(word => word.Length > 3).
  OrderBy(word => word.ToUpper()).
  Select(word => word);
words2.Dump();


var words3 =
	from word in wordList
	where word.Length > 3
	where word.Length < 5
	orderby word.ToUpper()
	select word;	
words3.Dump();

var words4 = 
  wordList.
  Where(word => word.Length > 3).
  Where(word => word.Length < 5).
  OrderBy(word => word.ToUpper()).
  Select(word => word);
words4.Dump();