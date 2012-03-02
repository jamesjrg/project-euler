module _24

(*
0 1 2 3 4 5 6 7 8 9 permutations
permutations starting with a given number is (n - 1)! = 9! = 362880
362880 * 2 is less than 1,000,000, whilst 362880 * 3 is greater than 1,000,000
so permutation must start with 2

permutations starting with 2, then another given number is (n -2)! = 8! = 40320
so 2, 0 brings us up to 725760 + 40320 = 766080
2, 1 up to 806400
...2, 6 up to 967680
2, 7 too many
so begins with 2, 6

(n - 3)! = 7! = 5040
2,6,0 up to 972720
2,6,1 up to 977760
2,6,2 up to 982800

etc
*)





