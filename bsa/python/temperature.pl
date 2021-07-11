#!/usr/bin/env python3
 
#...initialize looping variable, assume 'yes' as the first answer
continueYN = "y"
 
while continueYN == "y":
   #...get temperature input from the user
   sDegreeF = input("Enter next temperature in degrees Farenheight (F):")
 
   #...convert text entry to number value that can be used in equations
   nDegreeF = int(sDegreeF)
 
   #...convert temperature from F to Celsius
   nDegreeC = (nDegreeF - 32) * 5 / 9
 
   print ("Temperature in degrees C is:", nDegreeC)
 
   #...check for temperature below freezing..
   if nDegreeC < 0:
      print ("Pack long underwear!")
 
   #...check for it being a hot day...
   if nDegreeF > 100:
      print ("Remember to hydrate!")
 
   continueYN = input("Input another?")
 
#exit the program
