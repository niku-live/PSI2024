<Query Kind="Statements" />

var wordList = "The quick brown fox jumps over the lazy dog".Split();
wordList.Dump();

var words =
	from word in wordList
	orderby word.ToUpper()
	select word;	
words.Dump();

var words2 =
	from word in wordList
	orderby word.ToUpper()
	select word.ToUpper();	
words2.Dump();

var words3 =
	from word in wordList
	orderby word.ToUpper()
	select new { Word = word, Length = word.Length, Uppercased = word.ToUpper() };	
words3.Dump();



var numberList = "1 5 6 7 4".Split();
var numbers =
   from n in numberList
   select int.Parse(n);
numbers.Dump();
