using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;


namespace Lexico2
{
    public class Lexico : Token, IDisposable
    {
        StreamReader archivo;
        StreamWriter log;
        StreamWriter asm;
        int lineCount;



        public Lexico()
        {
            lineCount = 1;
            log = new StreamWriter("prueba.log");
            asm = new StreamWriter("prueba.asm");
            log.AutoFlush = true;
            asm.AutoFlush = true;

            if (File.Exists("prueba.cpp"))
            {
                archivo = new StreamReader("prueba.cpp");
            }
            else
            {
                throw new Error("El archivo prueba.cpp no existe", log);
            }



        }
       
        public Lexico(string nuevoArchivo)
        {
            lineCount = 1;
            if (File.Exists(nuevoArchivo) && Path.GetExtension(nuevoArchivo) == ".cpp")
            {

                log = new StreamWriter("nuevoArchivo.log");
                asm = new StreamWriter("nuevoArchivo.asm");
                log.AutoFlush = true;
                asm.AutoFlush = true;
                archivo = new StreamReader(nuevoArchivo);
            }
            else
            {
                throw new Error("El archivo no es un .cpp o no existe", log);
            }

        }


        


        public void Dispose()
        {
            log.WriteLine($"El archivo prueba.cpp tiene: {lineCount} lineas");
            archivo.Close();
            log.Close();
            asm.Close();
        }

        public void nextToken()
        {
            char c;
            string buffer = "";

            

            if (!finArchivo())
            {

                setContenido(buffer);
                string contenido = getContenido();
                string clasificacion = getClasificacion().ToString();
                log.WriteLine($"{contenido,-12} ---- {clasificacion}");

            }


        }
        public bool finArchivo()
        {
            return archivo.EndOfStream;
        }
    }
}

/*
    Expresion Regular: Metodo Formal que a traves de una secuencia de caracetres que define un patron de busqueda

                    a) Reglas BNF
                    b) Reglas BNF extendidas
                    c) Operaciones aplicadas al lenguaje

                    OAL

                    1.- Concatenacion simple (.)
                    2.- Concatenacion Exponencial (Exponente)
                    3.- Cerradura de Kleene (*)
                    4.- Cerradura Positiva (+)
                    5.- Cerradura Epsilon (?)
                    6.- Operador OR (|)
                    7.- Parentesis ()

                    L = {A, B, C, D, E, ... Z, a, b, c, d, e, ... z}
                    D = {0, 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9}

                    1.  L.D
                        LD
                        >=

                    2.  L^3 = LLL
                        D^5 = DDDDD
                        =2 = ==
                        
                    3.  L* = Cero o mas letras
                        D* = Cero o mas digitos

                    4.  L+ = Una o mas letras
                        D+ = Uno o mas digitos

                    5.  L? = Cero o una letra (La letra es optativa-opcional)

                    6.  L | D = Letra o Digito
                        + | - = Mas o Menos 
                    
                    7.  (L D) L? (Letra seguido de digito y al final letra opcional)

                    Produccion Gramatical 

                    Clasificacion del Token -> Expresion Regular

                    Identificador -> L (L | D)*

                    Numero -> D+ (. D+)? (E(+|-) D+)?
                    FinSentencia -> ;
                    InicioBloque -> {
                    FinBloque -> }
                    OperadorTermino -> + | -
                    Puntero -> ->
                    Termino+ -> + (+ | =)?
                    Termino- -> - (+ | =)?  
                    OperadorTernario -> ?
                    OperadorFactor -> * | / | %
                    IncrementoTermino -> + (+ | =) | - (- =) 
                    IncrementoFactor -> *= | /= | %=
                    Factor -> * | / | % (=)?
                    
                    Asignacion -> =
                    AsOpRel -> = (=)?
                    OperadorRelacional -> > (=)? | < (> | =)? | | = (= | !)
                    OperadorLogico -> && | || | !
                    NotOpRel -> ! (=)?
                    Cadena -> "c*"
                    Caracter -> 'c' | #D* | Lambda
                       

    Automata:   Modelo matematico que representa una expresion regular a travez de un grafo para una maquina de estado finito 
                que consiste en un conjunto de estados bien definidos:
                -un estado inicial
                -un alfabeto de entrada 
                -una funcion de transicion
*/