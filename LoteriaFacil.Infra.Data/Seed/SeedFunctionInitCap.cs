﻿using LoteriaFacil.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaFacil.Infra.Data.Seed
{
    public static class SeedFunctionInitCap
    {
        public static void Seed(LoteriaFacilContext loteriaFacilContext)
        {
            var functionInitCap = @" 
                                     -- Implementing Oracle INITCAP function
                                     CREATE FUNCTION [dbo].[InitCap] (@inStr VARCHAR(8000))
                                      RETURNS VARCHAR(8000)
                                      AS
                                      BEGIN
                                        DECLARE @outStr VARCHAR(8000) = LOWER(@inStr),
		                                     @char CHAR(1),	
		                                     @alphanum BIT = 0,
		                                     @len INT = LEN(@inStr),
                                                     @pos INT = 1;		  
 
                                        -- Iterate through all characters in the input string
                                        WHILE @pos <= @len BEGIN
 
                                          -- Get the next character
                                          SET @char = SUBSTRING(@inStr, @pos, 1);
 
                                          -- If the position is first, or the previous characater is not alphanumeric
                                          -- convert the current character to upper case
                                          IF @pos = 1 OR @alphanum = 0
                                            SET @outStr = STUFF(@outStr, @pos, 1, UPPER(@char));
 
                                          SET @pos = @pos + 1;
 
                                          -- Define if the current character is non-alphanumeric
                                          IF ASCII(@char) <= 47 OR (ASCII(@char) BETWEEN 58 AND 64) OR
	                                      (ASCII(@char) BETWEEN 91 AND 96) OR (ASCII(@char) BETWEEN 123 AND 126)
	                                      SET @alphanum = 0;
                                          ELSE
	                                      SET @alphanum = 1;
 
                                        END
 
                                       RETURN @outStr;		   
                                      END";
            try
            {
                loteriaFacilContext.Database.ExecuteSqlCommand(functionInitCap);
            }
            catch (Exception ex)
            {

            }

        }
    }
}