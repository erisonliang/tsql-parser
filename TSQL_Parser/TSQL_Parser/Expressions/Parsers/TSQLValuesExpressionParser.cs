﻿using System;
using System.Collections.Generic;

using TSQL.Clauses.Parsers;
using TSQL.Tokens;

namespace TSQL.Expressions.Parsers
{
	internal class TSQLValuesExpressionParser
	{
		public TSQLValuesExpression Parse(ITSQLTokenizer tokenizer)
		{
			TSQLValuesExpression valuesExpression = new TSQLValuesExpression();

			if (!tokenizer.Current.IsKeyword(TSQLKeywords.VALUES))
			{
				throw new InvalidOperationException("VALUES expected.");
			}

			valuesExpression.Tokens.Add(tokenizer.Current);

			TSQLSubqueryHelper.ReadUntilStop(
				tokenizer,
				valuesExpression,
				new List<TSQLFutureKeywords>() {
					TSQLFutureKeywords.OUTPUT
				},
				new List<TSQLKeywords>() {
					TSQLKeywords.ON,
					TSQLKeywords.WHEN
				},
				lookForStatementStarts: false);

			return valuesExpression;
		}
	}
}