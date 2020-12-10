SET DAY=0%1
SET DAY=%DAY:~-2%
echo %DAY%
mkdir Day%DAY%
copy Day00\Day00.cs Day%DAY%\Day%DAY%.cs
copy Day00\Day00Test.cs Day%DAY%\Day%DAY%Test.cs
copy Day00\Day00.csproj Day%DAY%\Day%DAY%.csproj
cd Day%DAY%
sed -i -- 's/Day00/Day%DAY%/g' *
cd ..

curl --output Day%DAY%\Day%DAY%.txt https://adventofcode.com/2020/day/%1/input --cookie "session=%AoCcookie%"