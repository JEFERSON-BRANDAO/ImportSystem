using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Classes
{
    public class Moeda
    {
        public string Conversao(string Cotacao, string valor)
        {
            decimal resultado = 0;
            //
            string aux = string.Empty;
            int fim = 0;
            for (int index = 0; index < valor.Length; index++)
            {
                if (valor[index].ToString() == ",")
                    fim++;

                if (fim == 0)
                    aux += valor[index];

            }

            valor = aux.Replace(".", "");
            resultado = (Convert.ToDecimal(valor) * Convert.ToDecimal(Cotacao));

            //arredondamento  de 0.060  para mais 0.10   duas casas
            resultado = Decimal.Round(resultado, 2);

            return resultado.ToString();

        }

        public string Cotacao(string valorCotacao)
        {
            Moeda moeda = new Moeda();
            string valor = valorCotacao;
            string strTotal = "";

            //
            if (valor.Length == 4)
            {
                //
                for (int linha = 0; linha < valor.Length; linha++)
                {
                    if (valor.Length == 3)
                    {
                        valor = valor.Remove(valor.Length - 1);
                        strTotal = "0" + valor;
                    }

                    //
                    if (valor.Length == 4)
                    {
                        strTotal += linha == 0 ? valor[linha].ToString().Replace(",", "").Replace(".", "").Trim() + "," : valor[linha].ToString().Replace(",", "").Replace(".", "").Trim();
                    }
                    else if (valor.Length == 5)
                    {
                        strTotal += linha == 1 ? valor[linha].ToString().Replace(",", "").Replace(".", "").Trim() + "," : valor[linha].ToString().Replace(",", "").Replace(".", "").Trim();
                        //remove ultimo digito zero  0,999'0'
                        if (strTotal.Length == 6)//6 posicoes contando com --> ,
                            strTotal = strTotal.Remove(strTotal.Length - 1);
                    }
                    else if (valor.Length == 6)
                    {
                        strTotal += linha == 1 ? valor[linha].ToString().Replace(",", "").Replace(".", "").Trim() + "," : valor[linha].ToString().Replace(",", "").Replace(".", "").Trim();

                    }
                    else if (valor.Length == 7)
                    {
                        strTotal += linha == 2 ? valor[linha].ToString().Replace(",", "").Replace(".", "").Trim() + "," : valor[linha].ToString().Replace(",", "").Replace(".", "").Trim();

                    }

                    //
                    if (valor.Length == 1)
                        strTotal = string.IsNullOrEmpty(valor) ? "00" : valor;

                    if (valor.Length == 2)
                        strTotal = string.IsNullOrEmpty(valor) ? "0" : valor;

                }
            }
            else
            {
                strTotal = string.IsNullOrEmpty(valor) ? "0" : moeda.FormataValor((decimal.Parse(valor.Replace(".", "").Replace(",", ""))).ToString());
            }

            //resultado          
            valor = strTotal;// moeda.FormataValor(strTotal.Replace(",", ""));

            //
            return valor;

        }

        public string FormataValor(string value)
        {
            string valorCompra = (string.IsNullOrEmpty(value) ? "0" : value);
            string novoValor = string.Empty;
            //
            string aux = valorCompra;
            //
            if (valorCompra.Length == 4 && valorCompra[0].ToString() == "0")
            {
                for (int indice = 0; indice <= aux.Length - 1; indice++)
                {
                    if (valorCompra.Length == 4)//0,999
                    {
                        novoValor += aux[indice];
                        //
                        if (indice == (1 - 1))// 
                        {
                            novoValor = novoValor + ",";
                        }
                    }
                }

            }
            else if (valorCompra.Length == 5 && valorCompra[0].ToString() == "0")
            {
                for (int indice = 0; indice <= aux.Length - 1; indice++)
                {
                    if (valorCompra.Length == 5)//0,9999
                    {
                        novoValor += aux[indice];
                        //
                        if (indice == (1 - 1))// 
                        {
                            novoValor = novoValor + ",";
                        }
                    }
                }
            }
            else
            {
                for (int indice = 0; indice <= aux.Length - 1; indice++)
                {
                    if (valorCompra.Length == 1)//00,9
                    {
                        novoValor += aux[indice];
                        //
                        if (indice == (1 - 1))// 
                        {
                            novoValor = "0,0" + novoValor;
                        }

                    }
                    if (valorCompra.Length == 2)//0,99
                    {
                        novoValor += aux[indice];
                        //
                        if (indice == (1 - 1))// 
                        {
                            novoValor = "0," + novoValor;
                        }

                    }
                    if (valorCompra.Length == 3)//9,99
                    {
                        novoValor += aux[indice];
                        //
                        if (indice == (1 - 1))//9, 
                        {
                            novoValor = novoValor + ",";
                        }

                    }
                    else if (valorCompra.Length == 4)//99,99
                    {
                        novoValor += aux[indice];
                        //
                        if (indice == (2 - 1))//99, 
                        {
                            novoValor = novoValor + ",";
                        }

                    }
                    else if (valorCompra.Length == 5)//999,99
                    {
                        if ((valorCompra[0].ToString() == "0") && (indice == 0))//Se houver 0 (0,999,9) na frente, remove
                        {
                            //
                        }
                        else
                        {
                            novoValor += aux[indice];
                        }
                        //
                        if (indice == (3 - 1))//999, 
                        {
                            novoValor = novoValor + ",";
                        }

                    }
                    else if (valorCompra.Length == 6)//9.999,99
                    {
                        novoValor += aux[indice];

                        if (indice == 0)//add 9.xxx,xx
                        {
                            novoValor = novoValor + ".";
                        }

                        if (indice == (4 - 1))
                        {
                            novoValor = novoValor + ",";
                        }

                    }
                    else if (valorCompra.Length == 7)//99.999,99
                    {
                        novoValor += aux[indice];

                        if (indice == 1)//add 99.xxx,xx
                        {
                            novoValor = novoValor + ".";
                        }

                        if (indice == (5 - 1))
                        {
                            novoValor = novoValor + ",";
                        }

                    }
                    else if (valorCompra.Length == 8)//999.999,99
                    {
                        novoValor += aux[indice];

                        if (indice == 2)//add 999.xxx,xx
                        {
                            novoValor = novoValor + ".";
                        }

                        if (indice == (6 - 1))
                        {
                            novoValor = novoValor + ",";
                        }

                    }
                    else if (valorCompra.Length == 9)//9.999.999,99
                    {
                        novoValor += aux[indice];

                        if (indice == 0)//add 9.xxx.xxx,xx
                        {
                            novoValor = novoValor + ".";
                        }
                        if (indice == 3)//add x.999.xxx,xx
                        {
                            novoValor = novoValor + ".";
                        }

                        if (indice == (7 - 1))
                        {
                            novoValor = novoValor + ",";
                        }

                    }
                    else if (valorCompra.Length == 10)//99.999.999,99
                    {
                        novoValor += aux[indice];

                        if (indice == 1)//add 99.xxx.xxx,xx
                        {
                            novoValor = novoValor + ".";
                        }
                        if (indice == 4)//add xx.999.xxx,xx
                        {
                            novoValor = novoValor + ".";
                        }

                        if (indice == (8 - 1))
                        {
                            novoValor = novoValor + ",";
                        }

                    }
                    else if (valorCompra.Length == 11)//999.999.999,99
                    {
                        novoValor += aux[indice];
                        //
                        if (indice == 2)//add 999.xxx.xxx,xx
                        {
                            novoValor = novoValor + ".";
                        }
                        if (indice == 5)//add xxx.999.xxx,xx
                        {
                            novoValor = novoValor + ".";
                        }

                        if (indice == (9 - 1))//xxx.xxx.xxx,99
                        {
                            novoValor = novoValor + ",";
                        }
                    }
                }
            }
            //
            return novoValor;
        }
    }
}