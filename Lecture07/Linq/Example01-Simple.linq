<Query Kind="Statements" />

var wordList = "The quick brown fox jumps over the lazy dog".Split();
wordList.Dump();

var words =
	from word in wordList
	orderby word.ToUpper()
	select word;	
words.Dump();

var words2 = 
  wordList.
  OrderBy(word => word.ToUpper()).
  Select(word => word);
words2.Dump();