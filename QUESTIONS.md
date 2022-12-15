# Réponses aux questions

```C#
// Étant donné que la valeur du type short est supérieur à la valeur que peut contenir un type byte
// Le type byte fait un modulo de la taille qu'il peut stocker avec la valeur du type short
// Taille max type byte = 256
// Type short = 300
// 256 % 300 = 44
// Le type byte est alors éguale à 44
short s = 300;
byte b = (byte)s; // 256 % 300 = 44
Console.WriteLine(b); // 44
```

```C#
// Enum permet de définir un ensemble fini de constantes nommées
// Les énumérations permettent de grouper des constantes sémantiquement liées.
public enum joursDeLaSemaine { Lundi, Mardi, Mercredi, Jeudi, Vendredi, Samedi, Dimanche };

joursDeLaSemaine premierJourDeLaSemaine = joursDeLaSemaine.Lundi;
Console.WriteLine(premierJourDeLaSemaine); // Lundi
```

```C#
// Ceci est un tableau multidimensionnel
int [,] Tableau = new int[1, 2]; // = { { 1, 2 }, { 3, 4 } };
int [,,] Tableau2 = new int[2, 2, 3]; // = { { { 1, 2, 3 }, { 4, 5, 6 } }, { { 7, 8, 9 }, { 10, 11, 12 } } };

// Ceci est un tableau en escalier
int[][] Tableau3 = new int[3][];
Tableau3[0] = new int[] { 45, 2 };
Tableau3[1] = new int[] { 34, 34, 4, 67 };
Tableau3[2] = new int[] { 0 };

// Affichage des valeurs du tableau en escalier
Console.WriteLine("Display Tableau3 :");
for (int i = 0; i < Tableau3.Length; i++)
{
	Console.Write("Element({0}): ", i);
	for (int j = 0; j < Tableau3[i].Length; j++)
	{
		Console.Write("{0}{1}", Tableau3[i][j], j == (Tableau3[i].Length - 1) ? "" : " ");
	}
Console.WriteLine();
}
```

### Que signifie le terme "assembly" (assemblage) ?
Le terme "assembly" (assemblage) fait référence à un groupe de fichiers qui constituent une unité logique de déploiement en C#.
Les assemblies sont généralement utilisés pour regrouper des classes et d'autres éléments de code en vue de leur réutilisation dans d'autres applications

### Citez un exemple reel d'un usage pertinent du mot clé private.
```C#
// "monEntier" peut seulement être lu ou modifié depuis la méthode "MonEntier" de ma classe "MaClasse"
class MaClasse { 
	private int monEntier;

	public int MonEntier { 
		get { return monEntier; }
		set { monEntier = value; }
	}
	...
}

MaClasse test = new MaClasse();

// Par exemple nous ne pouvons pas faire
Console.WriteLine(test.monEntier); // je n'y ai pas accès
// Pour pouvoir get "monEntier", il faut utiliser la méthode "MonEntier"
Console.WriteLine(test.MonEntier); // return monEntier

// De même pour changer la valeur de "monEntier"
test.monEntier = 100; // Je n'y ai pas accès
// Pour pouvoir set "monEntier", il faut utiliser la méthode "MonEntier"
test.MonEntier = 100; // monEntier a été modifié
```

### Qu'est ce qu'un ORM ?
Un ORM est un outil informatique qui permet de gérer la conversion des données entre le format des bases de données et le format dans un programme informatique.
Ça veut dire qu'il peut récupérer des données d'une BDD et les convertir en objet que le programme va pouvoir utiliser et il peut aussi faire l'inverse c'est à dire convertir les objets du programme en données qui peuvent être stockées en BDD.
