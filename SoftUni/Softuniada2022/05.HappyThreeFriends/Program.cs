int wineC = int.Parse(Console.ReadLine());


List<int> prices = new List<int>();
int index = 0;
int index2 = 1;

int sum = 0;
int newsum = 0;
for (int q = 0; q < wineC; q++)
{
    sum = 0;
    bool succes = false;
    bool unsucces = false;

    int[] array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

    prices = array.ToList();

    int girls = 3;

    for (int z = 0; z < prices.Count; z++)
    {
        sum = 0;
        for (int i = 0; i <= prices.Count - 1; i++)
        {
            sum += prices[i];
        }

        if (sum % girls == 1)
            break;


        if (prices.Count <= 3)
        {
            if (prices[z] == sum / girls)
            {
                sum -= prices[z];
                prices.Remove(prices[z]);

                girls--;

                if (prices.Count == 0)
                {
                    Console.WriteLine("Yes");
                    succes = true;
                    break;
                }
                else if (sum == sum / girls)
                {
                    prices.ToList().Clear();
                    Console.WriteLine("Yes");
                    prices.Clear();
                    succes = true;
                    break;
                }
            }
        }

        if (prices.Count > 3)
        {
            for (int i = 0; i <= prices.Count - 1; i++)
            {
                for (int j = 0; j <= prices.Count - 1; j++)
                {
                    if (j != i)
                    {
                        if (prices[i] + prices[j] == sum / girls)
                        {
                            sum -= prices[i];
                            sum -= prices[j];
                            prices.Remove(prices[Math.Max(i, j)]);
                            prices.Remove(prices[Math.Max(i, j)]);

                            girls--;

                            if (prices.Count == 0)
                            {
                                Console.WriteLine("Yes");
                                succes = true;
                                break;
                            }
                            else if (sum == sum / girls)
                            {
                                prices.ToList().Clear();
                                Console.WriteLine("Yes");
                                prices.Clear();
                                succes = true;
                                break;
                            }

                        }
                        else
                        {
                            if (prices.Count > 3)
                            {
                                for (int b = 0; b <= prices.Count - 1; b++)
                                {
                                    if (i != j && i != b && j != b)
                                    {

                                        if (prices[i] + prices[j] + prices[b] == sum / girls)
                                        {
                                            sum -= prices[b];
                                            sum -= prices[j];
                                            sum -= prices[i];

                                            prices.Remove(prices[Math.Max(b, Math.Max(j, i))]);
                                            prices.Remove(prices[Math.Max(b, Math.Max(j, i))]);
                                            prices.Remove(prices[Math.Max(b, Math.Max(j, i))]);


                                            girls--;
                                        }

                                        if (prices.Count == 0)
                                        {
                                            Console.WriteLine("Yes");
                                            succes = true;
                                            break;
                                        }
                                        else if (sum == sum / girls)
                                        {
                                            prices.ToList().Clear();
                                            Console.WriteLine("Yes");
                                            prices.Clear();
                                            succes = true;
                                            break;
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        if(prices.Count > 4) 
                                        {
                                            for(int h = 0; h <= prices.Count - 1; h++)
                                            {
                                                if (i != j && i != b && i != h && j != b && j != h && b != h)
                                                {

                                                    if (prices[i] + prices[j] + prices[b] + prices[h] == sum / girls)
                                                    {
                                                        sum -= prices[j];
                                                        sum -= prices[b];
                                                        sum -= prices[i];
                                                        sum -= prices[h];

                                                        prices.Remove(prices[Math.Max(b, Math.Max(j, Math.Max(i,h)))]);
                                                        prices.Remove(prices[Math.Max(b, Math.Max(j, Math.Max(i, h)))]);
                                                        prices.Remove(prices[Math.Max(b, Math.Max(j, Math.Max(i, h)))]);
                                                        prices.Remove(prices[Math.Max(b, Math.Max(j, Math.Max(i, h)))]);


                                                        girls--;
                                                    }

                                                    if (prices.Count == 0)
                                                    {
                                                        Console.WriteLine("Yes");
                                                        succes = true;
                                                        break;
                                                    }
                                                    else if (sum == sum / girls)
                                                    {
                                                        prices.ToList().Clear();
                                                        Console.WriteLine("Yes");
                                                        prices.Clear();
                                                        succes = true;
                                                        break;
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    for (int y = 0; y <= prices.Count - 1; y++)
                                                    {
                                                        if (i != j && i != b && i != h && i != y && j != b && j != h && j != y && b != h && b != y && h != y)
                                                        {

                                                            if (prices[i] + prices[j] + prices[b] + prices[h] + prices[y] == sum / girls)
                                                            {
                                                                sum -= prices[j];
                                                                sum -= prices[b];
                                                                sum -= prices[i];
                                                                sum -= prices[h];
                                                                sum -= prices[y];

                                                                prices.Remove(prices[Math.Max(b, Math.Max(j, Math.Max(i, Math.Max(h,y))))]);
                                                                prices.Remove(prices[Math.Max(b, Math.Max(j, Math.Max(i, Math.Max(h, y))))]);
                                                                prices.Remove(prices[Math.Max(b, Math.Max(j, Math.Max(i, Math.Max(h, y))))]);
                                                                prices.Remove(prices[Math.Max(b, Math.Max(j, Math.Max(i, Math.Max(h, y))))]);
                                                                prices.Remove(prices[Math.Max(b, Math.Max(j, Math.Max(i, Math.Max(h, y))))]);


                                                                girls--;
                                                            }

                                                            if (prices.Count == 0)
                                                            {
                                                                Console.WriteLine("Yes");
                                                                succes = true;
                                                                break;
                                                            }
                                                            else if (sum == sum / girls)
                                                            {
                                                                prices.ToList().Clear();
                                                                Console.WriteLine("Yes");
                                                                prices.Clear();
                                                                succes = true;
                                                                break;
                                                            }
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                    }

                                    if (succes)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
          
                    }

                    if (succes)
                        break;
                }

                if (succes) break;

                if (unsucces) break;
            }

        }

    }

    if (!succes)
        Console.WriteLine("No");
}


