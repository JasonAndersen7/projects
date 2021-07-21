--SQL Script: 
--Author: Jason Andersen
--Date: July 11, 2019
--Purpose: Update Serial Number fixed length field and prefix to accomodate larger numbers 

--Remove the "0" from the prefix
UPDATE [printconfig] 
SET    snprefix = '1T' 
WHERE  snprefix = '1T0' 

-- set the length to 5 to accomodate larger serial numbers for example
-- compare 1T09999 to 1T99999
UPDATE [workgenpreferences] 
SET    path = '5' 
WHERE  type = 'MaxSerNoSuffixInput' 