
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                 =  0, // (EOF)
        SYMBOL_ERROR               =  1, // (Error)
        SYMBOL_WHITESPACE          =  2, // Whitespace
        SYMBOL_MINUS               =  3, // '-'
        SYMBOL_MINUSMINUS          =  4, // '--'
        SYMBOL_EXCLAM              =  5, // '!'
        SYMBOL_EXCLAMEQ            =  6, // '!='
        SYMBOL_PERCENT             =  7, // '%'
        SYMBOL_AMPAMP              =  8, // '&&'
        SYMBOL_LPAREN              =  9, // '('
        SYMBOL_RPAREN              = 10, // ')'
        SYMBOL_TIMES               = 11, // '*'
        SYMBOL_COMMA               = 12, // ','
        SYMBOL_DIV                 = 13, // '/'
        SYMBOL_SEMI                = 14, // ';'
        SYMBOL_LBRACKET            = 15, // '['
        SYMBOL_RBRACKET            = 16, // ']'
        SYMBOL_LBRACE              = 17, // '{'
        SYMBOL_PIPEPIPE            = 18, // '||'
        SYMBOL_RBRACE              = 19, // '}'
        SYMBOL_PLUS                = 20, // '+'
        SYMBOL_PLUSPLUS            = 21, // '++'
        SYMBOL_PLUSEQ              = 22, // '+='
        SYMBOL_LT                  = 23, // '<'
        SYMBOL_LTEQ                = 24, // '<='
        SYMBOL_EQ                  = 25, // '='
        SYMBOL_MINUSEQ             = 26, // '-='
        SYMBOL_EQEQ                = 27, // '=='
        SYMBOL_GT                  = 28, // '>'
        SYMBOL_GTEQ                = 29, // '>='
        SYMBOL_BREAK               = 30, // break
        SYMBOL_CONST               = 31, // const
        SYMBOL_CONTINUE            = 32, // continue
        SYMBOL_ELSE                = 33, // else
        SYMBOL_FALSE               = 34, // false
        SYMBOL_FLOAT               = 35, // Float
        SYMBOL_FOR                 = 36, // for
        SYMBOL_FUNC                = 37, // func
        SYMBOL_IDENTIFIER          = 38, // Identifier
        SYMBOL_IF                  = 39, // if
        SYMBOL_INTEGER             = 40, // Integer
        SYMBOL_RETURN              = 41, // return
        SYMBOL_STRINGLITERAL       = 42, // StringLiteral
        SYMBOL_TRUE                = 43, // true
        SYMBOL_VAR                 = 44, // var
        SYMBOL_WHILE               = 45, // while
        SYMBOL_ADDEXP              = 46, // <Add Exp>
        SYMBOL_ARGUMENTLIST        = 47, // <ArgumentList>
        SYMBOL_ARRAYACCESS         = 48, // <ArrayAccess>
        SYMBOL_ASSIGNMENT          = 49, // <Assignment>
        SYMBOL_BLOCK               = 50, // <Block>
        SYMBOL_BREAKSTATEMENT      = 51, // <BreakStatement>
        SYMBOL_CONTINUESTATEMENT   = 52, // <ContinueStatement>
        SYMBOL_EXPRESSION          = 53, // <Expression>
        SYMBOL_FORLOOP             = 54, // <ForLoop>
        SYMBOL_FUNCTIONCALL        = 55, // <FunctionCall>
        SYMBOL_FUNCTIONDECLARATION = 56, // <FunctionDeclaration>
        SYMBOL_IFSTATEMENT         = 57, // <IfStatement>
        SYMBOL_INITIALIZATION      = 58, // <Initialization>
        SYMBOL_MULTEXP             = 59, // <Mult Exp>
        SYMBOL_PARAMETERLIST       = 60, // <ParameterList>
        SYMBOL_PROGRAM             = 61, // <Program>
        SYMBOL_RETURNSTATEMENT     = 62, // <ReturnStatement>
        SYMBOL_STATEMENT           = 63, // <Statement>
        SYMBOL_STATEMENTLIST       = 64, // <StatementList>
        SYMBOL_UNARYEXP            = 65, // <Unary Exp>
        SYMBOL_UPDATE              = 66, // <Update>
        SYMBOL_VALUE               = 67, // <Value>
        SYMBOL_VARIABLEDECLARATION = 68, // <VariableDeclaration>
        SYMBOL_WHILELOOP           = 69  // <WhileLoop>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM                                                          =  0, // <Program> ::= <StatementList>
        RULE_STATEMENTLIST                                                    =  1, // <StatementList> ::= 
        RULE_STATEMENTLIST2                                                   =  2, // <StatementList> ::= <StatementList> <Statement>
        RULE_STATEMENTLIST3                                                   =  3, // <StatementList> ::= <Statement>
        RULE_STATEMENT                                                        =  4, // <Statement> ::= <VariableDeclaration>
        RULE_STATEMENT2                                                       =  5, // <Statement> ::= <Assignment>
        RULE_STATEMENT3                                                       =  6, // <Statement> ::= <IfStatement>
        RULE_STATEMENT4                                                       =  7, // <Statement> ::= <WhileLoop>
        RULE_STATEMENT5                                                       =  8, // <Statement> ::= <ForLoop>
        RULE_STATEMENT6                                                       =  9, // <Statement> ::= <FunctionDeclaration>
        RULE_STATEMENT7                                                       = 10, // <Statement> ::= <ReturnStatement>
        RULE_STATEMENT8                                                       = 11, // <Statement> ::= <Block>
        RULE_STATEMENT9                                                       = 12, // <Statement> ::= <BreakStatement>
        RULE_STATEMENT10                                                      = 13, // <Statement> ::= <ContinueStatement>
        RULE_VARIABLEDECLARATION_VAR_IDENTIFIER_EQ_SEMI                       = 14, // <VariableDeclaration> ::= var Identifier '=' <Expression> ';'
        RULE_VARIABLEDECLARATION_CONST_IDENTIFIER_EQ_SEMI                     = 15, // <VariableDeclaration> ::= const Identifier '=' <Expression> ';'
        RULE_ASSIGNMENT_IDENTIFIER_EQ_SEMI                                    = 16, // <Assignment> ::= Identifier '=' <Expression> ';'
        RULE_ASSIGNMENT_IDENTIFIER_PLUSEQ_SEMI                                = 17, // <Assignment> ::= Identifier '+=' <Expression> ';'
        RULE_ASSIGNMENT_IDENTIFIER_MINUSEQ_SEMI                               = 18, // <Assignment> ::= Identifier '-=' <Expression> ';'
        RULE_BLOCK_LBRACE_RBRACE                                              = 19, // <Block> ::= '{' <StatementList> '}'
        RULE_BREAKSTATEMENT_BREAK_SEMI                                        = 20, // <BreakStatement> ::= break ';'
        RULE_CONTINUESTATEMENT_CONTINUE_SEMI                                  = 21, // <ContinueStatement> ::= continue ';'
        RULE_RETURNSTATEMENT_RETURN_SEMI                                      = 22, // <ReturnStatement> ::= return <Expression> ';'
        RULE_RETURNSTATEMENT_RETURN_SEMI2                                     = 23, // <ReturnStatement> ::= return ';'
        RULE_IFSTATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE                       = 24, // <IfStatement> ::= if '(' <Expression> ')' '{' <StatementList> '}'
        RULE_IFSTATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_LBRACE_RBRACE    = 25, // <IfStatement> ::= if '(' <Expression> ')' '{' <StatementList> '}' else '{' <StatementList> '}'
        RULE_WHILELOOP_WHILE_LPAREN_RPAREN_LBRACE_RBRACE                      = 26, // <WhileLoop> ::= while '(' <Expression> ')' '{' <StatementList> '}'
        RULE_FORLOOP_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE                = 27, // <ForLoop> ::= for '(' <Initialization> ';' <Expression> ';' <Update> ')' '{' <StatementList> '}'
        RULE_INITIALIZATION_VAR_IDENTIFIER_EQ                                 = 28, // <Initialization> ::= var Identifier '=' <Expression>
        RULE_INITIALIZATION_IDENTIFIER_EQ                                     = 29, // <Initialization> ::= Identifier '=' <Expression>
        RULE_UPDATE_IDENTIFIER_PLUSPLUS                                       = 30, // <Update> ::= Identifier '++'
        RULE_UPDATE_IDENTIFIER_MINUSMINUS                                     = 31, // <Update> ::= Identifier '--'
        RULE_UPDATE_IDENTIFIER_PLUSEQ                                         = 32, // <Update> ::= Identifier '+=' <Expression>
        RULE_UPDATE_IDENTIFIER_MINUSEQ                                        = 33, // <Update> ::= Identifier '-=' <Expression>
        RULE_FUNCTIONDECLARATION_FUNC_IDENTIFIER_LPAREN_RPAREN_LBRACE_RBRACE  = 34, // <FunctionDeclaration> ::= func Identifier '(' <ParameterList> ')' '{' <StatementList> '}'
        RULE_FUNCTIONDECLARATION_FUNC_IDENTIFIER_LPAREN_RPAREN_LBRACE_RBRACE2 = 35, // <FunctionDeclaration> ::= func Identifier '(' ')' '{' <StatementList> '}'
        RULE_PARAMETERLIST_IDENTIFIER                                         = 36, // <ParameterList> ::= Identifier
        RULE_PARAMETERLIST_COMMA_IDENTIFIER                                   = 37, // <ParameterList> ::= <ParameterList> ',' Identifier
        RULE_EXPRESSION_GT                                                    = 38, // <Expression> ::= <Expression> '>' <Add Exp>
        RULE_EXPRESSION_LT                                                    = 39, // <Expression> ::= <Expression> '<' <Add Exp>
        RULE_EXPRESSION_LTEQ                                                  = 40, // <Expression> ::= <Expression> '<=' <Add Exp>
        RULE_EXPRESSION_GTEQ                                                  = 41, // <Expression> ::= <Expression> '>=' <Add Exp>
        RULE_EXPRESSION_EQEQ                                                  = 42, // <Expression> ::= <Expression> '==' <Add Exp>
        RULE_EXPRESSION_EXCLAMEQ                                              = 43, // <Expression> ::= <Expression> '!=' <Add Exp>
        RULE_EXPRESSION_AMPAMP                                                = 44, // <Expression> ::= <Expression> '&&' <Add Exp>
        RULE_EXPRESSION_PIPEPIPE                                              = 45, // <Expression> ::= <Expression> '||' <Add Exp>
        RULE_EXPRESSION                                                       = 46, // <Expression> ::= <Add Exp>
        RULE_ADDEXP_PLUS                                                      = 47, // <Add Exp> ::= <Add Exp> '+' <Mult Exp>
        RULE_ADDEXP_MINUS                                                     = 48, // <Add Exp> ::= <Add Exp> '-' <Mult Exp>
        RULE_ADDEXP                                                           = 49, // <Add Exp> ::= <Mult Exp>
        RULE_MULTEXP_TIMES                                                    = 50, // <Mult Exp> ::= <Mult Exp> '*' <Unary Exp>
        RULE_MULTEXP_DIV                                                      = 51, // <Mult Exp> ::= <Mult Exp> '/' <Unary Exp>
        RULE_MULTEXP_PERCENT                                                  = 52, // <Mult Exp> ::= <Mult Exp> '%' <Unary Exp>
        RULE_MULTEXP                                                          = 53, // <Mult Exp> ::= <Unary Exp>
        RULE_UNARYEXP_MINUS                                                   = 54, // <Unary Exp> ::= '-' <Value>
        RULE_UNARYEXP_EXCLAM                                                  = 55, // <Unary Exp> ::= '!' <Value>
        RULE_UNARYEXP                                                         = 56, // <Unary Exp> ::= <Value>
        RULE_VALUE_IDENTIFIER                                                 = 57, // <Value> ::= Identifier
        RULE_VALUE_INTEGER                                                    = 58, // <Value> ::= Integer
        RULE_VALUE_FLOAT                                                      = 59, // <Value> ::= Float
        RULE_VALUE_STRINGLITERAL                                              = 60, // <Value> ::= StringLiteral
        RULE_VALUE_TRUE                                                       = 61, // <Value> ::= true
        RULE_VALUE_FALSE                                                      = 62, // <Value> ::= false
        RULE_VALUE                                                            = 63, // <Value> ::= <FunctionCall>
        RULE_VALUE2                                                           = 64, // <Value> ::= <ArrayAccess>
        RULE_VALUE_LPAREN_RPAREN                                              = 65, // <Value> ::= '(' <Expression> ')'
        RULE_FUNCTIONCALL_IDENTIFIER_LPAREN_RPAREN                            = 66, // <FunctionCall> ::= Identifier '(' <ArgumentList> ')'
        RULE_FUNCTIONCALL_IDENTIFIER_LPAREN_RPAREN2                           = 67, // <FunctionCall> ::= Identifier '(' ')'
        RULE_ARGUMENTLIST                                                     = 68, // <ArgumentList> ::= <Expression>
        RULE_ARGUMENTLIST_COMMA                                               = 69, // <ArgumentList> ::= <ArgumentList> ',' <Expression>
        RULE_ARRAYACCESS_IDENTIFIER_LBRACKET_RBRACKET                         = 70  // <ArrayAccess> ::= Identifier '[' <Expression> ']'
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lst;
        public MyParser(string filename, ListBox lst)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            this.lst = lst;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAM :
                //'!'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AMPAMP :
                //'&&'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACKET :
                //'['
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACKET :
                //']'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PIPEPIPE :
                //'||'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSEQ :
                //'+='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSEQ :
                //'-='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BREAK :
                //break
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONST :
                //const
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONTINUE :
                //continue
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FALSE :
                //false
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //Float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNC :
                //func
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTEGER :
                //Integer
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //return
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL :
                //StringLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRUE :
                //true
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VAR :
                //var
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADDEXP :
                //<Add Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGUMENTLIST :
                //<ArgumentList>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARRAYACCESS :
                //<ArrayAccess>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENT :
                //<Assignment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BLOCK :
                //<Block>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BREAKSTATEMENT :
                //<BreakStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONTINUESTATEMENT :
                //<ContinueStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORLOOP :
                //<ForLoop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTIONCALL :
                //<FunctionCall>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTIONDECLARATION :
                //<FunctionDeclaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFSTATEMENT :
                //<IfStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INITIALIZATION :
                //<Initialization>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULTEXP :
                //<Mult Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETERLIST :
                //<ParameterList>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURNSTATEMENT :
                //<ReturnStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTLIST :
                //<StatementList>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UNARYEXP :
                //<Unary Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UPDATE :
                //<Update>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALUE :
                //<Value>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEDECLARATION :
                //<VariableDeclaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILELOOP :
                //<WhileLoop>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM :
                //<Program> ::= <StatementList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST :
                //<StatementList> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST2 :
                //<StatementList> ::= <StatementList> <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST3 :
                //<StatementList> ::= <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<Statement> ::= <VariableDeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<Statement> ::= <Assignment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT3 :
                //<Statement> ::= <IfStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT4 :
                //<Statement> ::= <WhileLoop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT5 :
                //<Statement> ::= <ForLoop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT6 :
                //<Statement> ::= <FunctionDeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT7 :
                //<Statement> ::= <ReturnStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT8 :
                //<Statement> ::= <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT9 :
                //<Statement> ::= <BreakStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT10 :
                //<Statement> ::= <ContinueStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATION_VAR_IDENTIFIER_EQ_SEMI :
                //<VariableDeclaration> ::= var Identifier '=' <Expression> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATION_CONST_IDENTIFIER_EQ_SEMI :
                //<VariableDeclaration> ::= const Identifier '=' <Expression> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_IDENTIFIER_EQ_SEMI :
                //<Assignment> ::= Identifier '=' <Expression> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_IDENTIFIER_PLUSEQ_SEMI :
                //<Assignment> ::= Identifier '+=' <Expression> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_IDENTIFIER_MINUSEQ_SEMI :
                //<Assignment> ::= Identifier '-=' <Expression> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BLOCK_LBRACE_RBRACE :
                //<Block> ::= '{' <StatementList> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BREAKSTATEMENT_BREAK_SEMI :
                //<BreakStatement> ::= break ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONTINUESTATEMENT_CONTINUE_SEMI :
                //<ContinueStatement> ::= continue ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURNSTATEMENT_RETURN_SEMI :
                //<ReturnStatement> ::= return <Expression> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURNSTATEMENT_RETURN_SEMI2 :
                //<ReturnStatement> ::= return ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE :
                //<IfStatement> ::= if '(' <Expression> ')' '{' <StatementList> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_LBRACE_RBRACE :
                //<IfStatement> ::= if '(' <Expression> ')' '{' <StatementList> '}' else '{' <StatementList> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILELOOP_WHILE_LPAREN_RPAREN_LBRACE_RBRACE :
                //<WhileLoop> ::= while '(' <Expression> ')' '{' <StatementList> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORLOOP_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE :
                //<ForLoop> ::= for '(' <Initialization> ';' <Expression> ';' <Update> ')' '{' <StatementList> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INITIALIZATION_VAR_IDENTIFIER_EQ :
                //<Initialization> ::= var Identifier '=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INITIALIZATION_IDENTIFIER_EQ :
                //<Initialization> ::= Identifier '=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UPDATE_IDENTIFIER_PLUSPLUS :
                //<Update> ::= Identifier '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UPDATE_IDENTIFIER_MINUSMINUS :
                //<Update> ::= Identifier '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UPDATE_IDENTIFIER_PLUSEQ :
                //<Update> ::= Identifier '+=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UPDATE_IDENTIFIER_MINUSEQ :
                //<Update> ::= Identifier '-=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONDECLARATION_FUNC_IDENTIFIER_LPAREN_RPAREN_LBRACE_RBRACE :
                //<FunctionDeclaration> ::= func Identifier '(' <ParameterList> ')' '{' <StatementList> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONDECLARATION_FUNC_IDENTIFIER_LPAREN_RPAREN_LBRACE_RBRACE2 :
                //<FunctionDeclaration> ::= func Identifier '(' ')' '{' <StatementList> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERLIST_IDENTIFIER :
                //<ParameterList> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERLIST_COMMA_IDENTIFIER :
                //<ParameterList> ::= <ParameterList> ',' Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GT :
                //<Expression> ::= <Expression> '>' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LT :
                //<Expression> ::= <Expression> '<' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LTEQ :
                //<Expression> ::= <Expression> '<=' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GTEQ :
                //<Expression> ::= <Expression> '>=' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_EQEQ :
                //<Expression> ::= <Expression> '==' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_EXCLAMEQ :
                //<Expression> ::= <Expression> '!=' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_AMPAMP :
                //<Expression> ::= <Expression> '&&' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_PIPEPIPE :
                //<Expression> ::= <Expression> '||' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_PLUS :
                //<Add Exp> ::= <Add Exp> '+' <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_MINUS :
                //<Add Exp> ::= <Add Exp> '-' <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP :
                //<Add Exp> ::= <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_TIMES :
                //<Mult Exp> ::= <Mult Exp> '*' <Unary Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_DIV :
                //<Mult Exp> ::= <Mult Exp> '/' <Unary Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_PERCENT :
                //<Mult Exp> ::= <Mult Exp> '%' <Unary Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP :
                //<Mult Exp> ::= <Unary Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP_MINUS :
                //<Unary Exp> ::= '-' <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP_EXCLAM :
                //<Unary Exp> ::= '!' <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP :
                //<Unary Exp> ::= <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_IDENTIFIER :
                //<Value> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_INTEGER :
                //<Value> ::= Integer
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_FLOAT :
                //<Value> ::= Float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_STRINGLITERAL :
                //<Value> ::= StringLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_TRUE :
                //<Value> ::= true
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_FALSE :
                //<Value> ::= false
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE :
                //<Value> ::= <FunctionCall>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE2 :
                //<Value> ::= <ArrayAccess>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_LPAREN_RPAREN :
                //<Value> ::= '(' <Expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONCALL_IDENTIFIER_LPAREN_RPAREN :
                //<FunctionCall> ::= Identifier '(' <ArgumentList> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONCALL_IDENTIFIER_LPAREN_RPAREN2 :
                //<FunctionCall> ::= Identifier '(' ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTLIST :
                //<ArgumentList> ::= <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTLIST_COMMA :
                //<ArgumentList> ::= <ArgumentList> ',' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARRAYACCESS_IDENTIFIER_LBRACKET_RBRACKET :
                //<ArrayAccess> ::= Identifier '[' <Expression> ']'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            this.lst.Items.Add(message);
            string m2 = "Expected token: " + args.UnexpectedToken.ToString();
            this.lst.Items.Add((string)m2);
            //todo: Report message to UI?
        }

    }
}
