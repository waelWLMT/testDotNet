*********************
*** Alerting .NET ***
*********************

Le projet Alerting propose une solution de sérialisation d'alertes.

Les alertes sont modélisées par la classe Alert.
La sérialisation est effectuée par la classe Formatter.

Une instance de Formatter est construite à partir d'une configuration sérialisée en JSON.

Un Formatter contient une liste de champs conditionnés.
Un champ conditionné permet de sérialiser une propriété A ou une propriété B de l'alerte selon 
la présence d'une catégorie (= une chaîne) dans la propriété Categories de l'alerte

La méthode Formatter.FormatAlert permet de sérialiser une alerte selon la configuration des champs conditonnés.

Le projet AlertingUnitTest implémente les tests unitaires du projet Alerting.
Il permet également d'avoir des exemples d'utilisation.

-----

L'objectif de l'exercice est de faire évoluer le projet Alerting et la fonctionnalité de "champ conditionné".
pour permettre de conditionner la sérialisation d'un champ d'une alerte sur une valeur d'état 
(propriété Status de Alert).

Les tests unitaires existants doivent toujours fonctionner suite à l'évolution (notion de compatibilité ascendante).
Par exemple, les valeurs sérialisés pour la configuration des Formatter doivent continuer à fonctionner et fournir le même résultat.