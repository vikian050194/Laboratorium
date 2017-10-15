//Problem 9 - Special Pythagorean triplet - solved
//A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
//a^2 + b^2 = c^2
//For example, 32 + 42 = 9 + 16 = 25 = 52.
//There exists exactly one Pythagorean triplet for which a + b + c = 1000.
//Find the product abc.

let answer = [ for a = 1 to 1000 do
                   for b = 1 to 1000 do
                       for c = 1 to 1000 do
                           if (a + b + c = 1000) && (a*a+b*b=c*c)
                           then yield a*b*c ]