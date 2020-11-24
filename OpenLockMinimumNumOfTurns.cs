/*
You have a lock in front of you with 4 circular wheels. Each wheel has 10 slots: '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'. The wheels can rotate freely and wrap around: for example we can turn '9' to be '0', or '0' to be '9'. Each move consists of turning one wheel one slot.

The lock initially starts at '0000', a string representing the state of the 4 wheels.

You are given a list of deadends dead ends, meaning if the lock displays any of these codes, the wheels of the lock will stop turning and you will be unable to open it.

Given a target representing the value of the wheels that will unlock the lock, return the minimum total number of turns required to open the lock, or -1 if it is impossible.

Example 1:

Input: deadends = ["0201","0101","0102","1212","2002"], target = "0202"
Output: 6
Explanation:
A sequence of valid moves would be "0000" -> "1000" -> "1100" -> "1200" -> "1201" -> "1202" -> "0202".
Note that a sequence like "0000" -> "0001" -> "0002" -> "0102" -> "0202" would be invalid,
because the wheels of the lock become stuck after the display becomes the dead end "0102".

Example 2:
Input: deadends = ["8888"], target = "0009"
Output: 1
Explanation:
We can turn the last wheel in reverse to move from "0000" -> "0009".

Example 3:
Input: deadends = ["8887","8889","8878","8898","8788","8988","7888","9888"], target = "8888"
Output: -1
Explanation:
We can't reach the target without getting stuck.

Example 4:
Input: deadends = ["0000"], target = "8888"
Output: -1
 
Constraints:
1 <= deadends.length <= 500
deadends[i].length == 4
target.length == 4
target will not be in the list deadends.
target and deadends[i] consist of digits only.

*/

public class Solution {
    public int OpenLock(string[] deadends, string target) {
        // start with 0000 in queue
        /*
            add to deadStates
            get next states by de
        */
        string start = "0000";
        var deads = deadends.ToHashSet();
        // if we can't add start to deadends, it is already there and it not the target either so we are stuck here at the start
        if(!deads.Add(start) && start != target){
            return -1;
        }
        
        // initialize a new queue to store combos as we explore them, start by adding the starting combo
        Queue<string> ComboToExplore = new Queue<string>(new[] {start});
        
        // while we have unexplored Combos, count the number of iterations aka number of turns on the lock
        for(int steps = 0; ComboToExplore.Count > 0; steps++){
            // in one step, we will add all the possbile turns from that current state, since in the end only one turn will be chosen anyway
            for(int numOfcurrentSteps = ComboToExplore.Count; numOfcurrentSteps > 0; numOfcurrentSteps--){
                // get the added combo
                string combo = ComboToExplore.Dequeue();
                if(combo == target) return steps;
                foreach(string neighbor in GetNeighbors(combo)){
                    // if the neighbor is not a deadend, add it as a possibility to explore
                    if(deads.Add(neighbor)){
                        ComboToExplore.Enqueue(neighbor);
                    }
                }
            }
        }
        return -1;
    }
    
    public IEnumerable<string> GetNeighbors(string state){
        for(int wheelNum = 0; wheelNum < 4; wheelNum++){
            // compute all neighbors by turning each wheel either up or down
            yield return MoveWheelUp(state, wheelNum);
            yield return MoveWheelDown(state, wheelNum);
        }
    }
    
    public string MoveWheelUp(string state, int wheelNum){
        var strB = new StringBuilder(state);
        strB[wheelNum] = (char) ((strB[wheelNum] - '0' + 1) % 10 + '0');
        return strB.ToString();
    }
    public string MoveWheelDown(string state, int wheelNum){
        var strB = new StringBuilder(state);
        // add 9 instead of subtracting 1 to ensure we never reach a negative number
        strB[wheelNum] = (char) ((strB[wheelNum] - '0' + 9) % 10 + '0');
        return strB.ToString();
    }
    
}