using PruebaSumatoriaCubo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaSumatoriaCubo.BO
{
    public class OperacionesBO
    {
        /// <summary>
        /// Metodo que evalua la entrada y retorna los resultados
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        public static string EvaluarEntrada(string entrada)
        {
            string respuesta = "";
            int T = 0;
            int indice = 0;
            List<CasoPrueba> casosPrueba = new List<CasoPrueba>();

            try
            {
                //Convierte la entrada en una lista de string
                List<string> instrucciones = entrada.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (instrucciones.Count > indice)
                {
                    //Valida la primera lina que corresponde a T (numero de casos de prueba)
                    if(!string.IsNullOrEmpty(instrucciones[indice]))
                    {
                         T = Convert.ToInt32(instrucciones[indice]);

                        //Si es mayor que 50 y menor que 1 es invalido
                        if(T<1 || T > 50)
                        {
                            respuesta += "El valor ingresado para T es invalido.";
                            return respuesta; //Corta la prueba y retorna el error
                        }

                        indice++;
                    }

                    while(indice < instrucciones.Count)
                    {
                        //Valida que los valores de N y M sean correctos para la prueba
                        if (instrucciones.Count > indice)
                        {
                            if (!string.IsNullOrEmpty(instrucciones[indice]))
                            {
                                List<string> valoresNyM = instrucciones[indice].Split(' ').ToList();

                                if (valoresNyM.Count != 2) // deben ser 2 valores para N y M
                                {
                                    respuesta += "El valor ingresado para N y M es invalido.";
                                    return respuesta; //Corta la prueba y retorna el error
                                }
                                else
                                {
                                    CasoPrueba casoPrueba = new CasoPrueba();
                                    casoPrueba.N = Convert.ToInt32(valoresNyM[0]);

                                    //Si es mayor que 100 y menor que 1 es invalido
                                    if (casoPrueba.N < 1 || casoPrueba.N > 100)
                                    {
                                        respuesta += "El valor ingresado para N es invalido.";
                                        return respuesta; //Corta la prueba y retorna el error
                                    }

                                    casoPrueba.M = Convert.ToInt32(valoresNyM[1]);

                                    //Si es mayor que 1000 y menor que 1 es invalido
                                    if (casoPrueba.M < 1 || casoPrueba.M > 1000)
                                    {
                                        respuesta += "El valor ingresado para N es invalido.";
                                        return respuesta; //Corta la prueba y retorna el error
                                    }

                                    indice++;

                                    int valorActual = indice;
                                    //Obtiene las operaciones del caso de prueba
                                    for (int i = valorActual; i < (casoPrueba.M + valorActual); i++)
                                    {
                                        casoPrueba.Operaciones.Add(instrucciones[i]);
                                        indice++;
                                    }

                                    //Valida el caso de prueba
                                    respuesta += EvaluarCasoPrueba(casoPrueba);
                                }
                            }
                        }
                    }
                }
                else
                {
                    respuesta += "La entrada no es correcta.";
                }
             
            }
            //Manejo de excepciones, para a futuro implementar un log4net
            catch (ArgumentException ae)
            {
                respuesta += "La entrada no es correcta.";
            }
            catch (FormatException fe)
            {
                respuesta += "La entrada no es correcta.";
            }
            catch (OverflowException oe)
            {
                respuesta += "La entrada no es correcta.";
            }


            return respuesta;
        }

        /// <summary>
        /// Metodo que evalua cada caso de prueba y retorna los valores de las operaciones
        /// </summary>
        /// <param name="caso"></param>
        /// <returns></returns>
        private static string EvaluarCasoPrueba(CasoPrueba caso)
        {
            string resultado = "";

            try
            {
                int[,,] array = new int[caso.N, caso.N, caso.N];

                foreach (string operacion in caso.Operaciones)
                {
                    //Establece la operacion
                    if (operacion.ToLower().Contains("update"))
                    {
                        string detalleOperacion = operacion.Remove(0, 7); //7 es los caracteres que tiene Update mas el espacio
                        List<string> valoresOperacion = detalleOperacion.Split(' ').ToList();

                        //Obtiene los valores del arreglo
                        if (valoresOperacion.Count == 4)
                        {
                            int x = Convert.ToInt32(valoresOperacion[0]) - 1;
                            int y = Convert.ToInt32(valoresOperacion[1]) - 1;
                            int z = Convert.ToInt32(valoresOperacion[2]) - 1;

                            int valorCelda = Convert.ToInt32(valoresOperacion[3]);

                            if (valorCelda < -1000000000 || valorCelda > 1000000000)
                            {
                                resultado += "Valor para W =" + valorCelda + " es invalido";
                            }
                            else
                            {
                                //Actualiza el valor en el arreglo
                                array[x, y, z] = valorCelda;
                            }
                        }
                        else
                        {
                            resultado += "Operacion invalida";
                        }

                    }
                    else if (operacion.ToLower().Contains("query"))
                    {
                        string detalleOperacion = operacion.Remove(0, 6); //5 es los caracteres que tiene Query mas el espacio
                        List<string> valoresOperacion = detalleOperacion.Split(' ').ToList();

                        //Obtiene los valores del arreglo
                        if (valoresOperacion.Count == 6)
                        {
                            int x = Convert.ToInt32(valoresOperacion[0]) - 1;
                            int y = Convert.ToInt32(valoresOperacion[1]) - 1;
                            int z = Convert.ToInt32(valoresOperacion[2]) - 1;

                            int x2 = Convert.ToInt32(valoresOperacion[3]) - 1;
                            int y2 = Convert.ToInt32(valoresOperacion[4]) - 1;
                            int z2 = Convert.ToInt32(valoresOperacion[5]) - 1;

                            //Realiza la suma de los valores
                            int suma = 0;
                            while (x < x2 + 1 && y < y2 + 1 && z < z2 + 1)
                            {
                                suma += array[x, y, z];
                                x++;
                                y++;
                                z++;
                            }

                            resultado += System.Environment.NewLine + suma;
                        }
                        else
                        {
                            resultado += "Operacion invalida";
                        }
                    }
                    else
                    {
                        resultado += "Operacion invalida";
                    }
                }
            }
            //Manejo de excepciones, para a futuro implementar un log4net
            catch (Exception e)
            {
                resultado += "Operacion invalida";
            }
           

            return resultado;
        }
    }
}
