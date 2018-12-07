### Problem Overview
--- Part One ---
Given a set of lines like below, find the total sum.

Input:
`
+1
+1
-1
`
Result: 1

--- Part Two ---
Find the first sum that repeats if you cycle through the input until a repeat number sum is reached. For the input above, the result is 1.

### Solution Notes
The solution for this problem is pretty straight forward. An outline of the solution to part one is:
1. Loop Through Each Line in the Input
2. Convert the Line to an Integer
3. Add the Integer to the Total
4. Return the Total

This solution is O(n) for both space and time complexity since it iterates through each line and stores each line in memory.

Part two was a little more difficult. To solve it, I used a Set to store the totals that had already occured. If the new total is already in the set, that's our answer. Otherwise, continue looping through the lines.

### Stats
This is where I finished overall. The time is how long after the puzzle went live, not how long it took me.

Part 1: 24103
Part 2: 19530
Time: 21:18:35